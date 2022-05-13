using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 출하검사기준
    /// 업  무  설  명  : 출하 검사 기준을 조회, 등록, 수정, 삭제한다.
    /// 생    성    자  : sejoo
    /// 생    성    일  : 2022-05-02
    /// 수  정  이  력  : 
    /// </summary>
    public partial class ShipInspStandardReg : SmartConditionBaseForm
    {
        #region Local Variables
        private string state = null;
        #endregion

        #region 생성자
        public ShipInspStandardReg()
        {
            InitializeComponent();
        }
        #endregion

        #region 컨텐츠 영역 초기화
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();
            
            InitializeRevisionGrid();
            InitializeInspInfoGrid();
        }

        /// <summary>        
        /// 리비전 정보 그리드 초기화
        /// </summary>
        private void InitializeRevisionGrid()
        {
            grdRevision.GridButtonItem = GridButtonItem.Add | GridButtonItem.Delete;
            grdRevision.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            // Rev No.
            grdRevision.View.AddTextBoxColumn("REVNO", 70)
                            .SetValidationIsRequired()
                            .SetTextAlignment(TextAlignment.Center);
            //생성자
            grdRevision.View.AddTextBoxColumn("CREATOR", 100)
                            .SetTextAlignment(TextAlignment.Center)
                            .SetIsReadOnly();
            //생성일시
            grdRevision.View.AddTextBoxColumn("CREATEDTIME", 120)
                            .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                            .SetTextAlignment(TextAlignment.Center)
                            .SetIsReadOnly();
            // 변경 사유
            grdRevision.View.AddTextBoxColumn("REASONDESCRIPTION", 200)
                            .SetLabel("REASONFORCHANGE");

            grdRevision.View.PopulateColumns();
        }

        /// <summary>        
        /// 출하검사 기준 정보 그리드 초기화
        /// </summary>
        private void InitializeInspInfoGrid()
        {
            grdIsnpInfo.GridButtonItem = GridButtonItem.None;

            // 검사 항목
            grdIsnpInfo.View.AddTextBoxColumn("INSPECTIONID", 80)
                            .SetLabel("INSPECTIONITEM")
                            .SetTextAlignment(TextAlignment.Center)
                            .SetIsReadOnly();
            // 내용
            grdIsnpInfo.View.AddTextBoxColumn("INSPECTIONNAME", 600)
                            .SetLabel("INSPECTIONCONTENT");

            grdIsnpInfo.View.PopulateColumns();

            grdIsnpInfo.View.OptionsView.RowAutoHeight = true;
        }

        #endregion
        
        #region Event
        
        public void InitializeEvent()
        {
            grdRevision.View.FocusedRowChanged += View_FocusedRowChanged;
            grdRevision.View.AddingNewRow += View_AddingNewRow;
            grdRevision.ToolbarDeletingRow += GrdRevision_ToolbarDeletingRow;
            grdRevision.View.ShowingEditor += View_ShowingEditor;
        }

        private void View_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataRow row = grdRevision.View.GetFocusedDataRow();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("REVNO", row["REVNO"].ToString());
            DataTable existsDatas = SqlExecuter.Query("GetShipInspecDataForDelete", "00001", param);

            for (int i = 0; i < existsDatas.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(existsDatas.Rows[i]["INSPECTIONNAME"].ToString()) || !existsDatas.Rows[i]["INSPECTIONNAME"].ToString().Equals(""))
                {
                    e.Cancel = true;
                    // 검사 데이터가 존재하면 수정할 수 없습니다.
                    throw MessageException.Create("CantModifyIfInspDataExists");
                }
            }
        }
        
        private void GrdRevision_ToolbarDeletingRow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(grdRevision.View.GetCheckedRows().Rows.Count > 1)
            {
                grdRevision.View.CheckedAll(false);
                // 하나의 리비전만 삭제할 수 있습니다.
                throw MessageException.Create("SelectOnlyOneRevision");
            }

            //DataTable dtRev = grdRevision.DataSource as DataTable;
            DataTable dtRev = SqlExecuter.Query("GetRevisionForShipInspStandard", "00001");
            DataTable dtChecked = grdRevision.View.GetCheckedRows();
            
            if(!dtChecked.Rows[0]["REVNO"].ToString().Equals(""))
            {
                int max = dtRev.AsEnumerable().Select(r => r.Field<Int32>("REVNO")).ToList().Max();
                int check = Int32.Parse(dtChecked.Rows[0]["REVNO"].ToString());

                if (check < max)
                {
                    grdRevision.View.CheckedAll(false);
                    // 가장 최근 리비전만 삭제할 수 있습니다.
                    throw MessageException.Create("OnlyDeleteLatestRevision");
                }
                else
                {
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("REVNO", check);
                    DataTable existsDatas = SqlExecuter.Query("GetShipInspecDataForDelete", "00001", param);

                    for (int i = 0; i < existsDatas.Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(existsDatas.Rows[i]["INSPECTIONNAME"].ToString()) || !existsDatas.Rows[i]["INSPECTIONNAME"].ToString().Equals(""))
                        {
                            // 검사 데이터가 존재하면 삭제할 수 없습니다.
                            throw MessageException.Create("CantDeleteIfInspDataExists");
                        }
                    }
                }
            }
            
        }
        
        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            if (grdRevision.GetChangedRows().Rows.Count > 1)
            {
                args.IsCancel = true;
                // 저장, 수정중인 행이 존재합니다.
                this.ShowMessage("RowBeingSaveOrModified");
                return;
            }

            List<string> itemList = new List<string>();
            itemList.Add("A");
            itemList.Add("B");
            itemList.Add("C");
            itemList.Add("D");
            itemList.Add("E");
            itemList.Add("F");
            itemList.Add("G");
            itemList.Add("H");
            itemList.Add("I");
            itemList.Add("J");
            itemList.Add("K");
            //itemList.Add("Ref");

            for (int i=0; i<itemList.Count; i++)
            {
                grdIsnpInfo.View.AddNewRow();
                grdIsnpInfo.View.SetRowCellValue(i, "INSPECTIONID", itemList[i]);
            }

            txtRef.Text = "";

        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = grdRevision.View.GetFocusedDataRow();

            if (row == null) return;

            SelectRevisionForInspData();
        }

        #endregion

        #region 툴바
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;

            if (btn.Name.ToString().Equals("Save"))
            {
                // 저장버튼 클릭
                OnToolbarSaveClick();
            }
        }
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();
            
            if(MSGBox.Show(MessageBoxType.Question, "InfoSave", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataTable dtRev = grdRevision.GetChangedRows();
                DataTable dtInsp = null;
                DataRow newRow = null;
                //DataRow newRow = dtInsp.NewRow();

                if(dtRev.Rows.Count > 0)
                {
                    for (int i = 0; i < dtRev.Rows.Count; i++)
                    {
                        if (dtRev.Rows[i]["_STATE_"].ToString() == "added")
                        {
                            if (string.IsNullOrEmpty(dtRev.Rows[i]["REVNO"].ToString()))
                            {
                                // 리비전 번호를 입력해 주세요.
                                throw MessageException.Create("InputRevisionNumber");
                            }
                            state = "Insert";

                            dtInsp = grdIsnpInfo.GetChangedRows();
                            newRow = dtInsp.NewRow();
                            newRow["INSPECTIONID"] = "REF";
                            newRow["INSPECTIONNAME"] = txtRef.Text;
                            dtInsp.Rows.Add(newRow);
                        }
                        else if(dtRev.Rows[i]["_STATE_"].ToString() == "modified")
                        {
                            state = "Update";

                            dtInsp = grdIsnpInfo.DataSource as DataTable;
                            newRow = dtInsp.NewRow();
                            newRow["REVNO"] = dtRev.Rows[i]["REVNO"];
                            newRow["INSPECTIONID"] = "REF";
                            newRow["INSPECTIONNAME"] = txtRef.Text;
                            dtInsp.Rows.Add(newRow);
                        }
                        else if (dtRev.Rows[i]["_STATE_"].ToString() == "deleted")
                        {
                            state = "Delete";

                            dtInsp = grdIsnpInfo.DataSource as DataTable;
                            newRow = dtInsp.NewRow();
                            newRow["REVNO"] = dtRev.Rows[i]["REVNO"];
                            newRow["INSPECTIONID"] = "REF";
                            newRow["INSPECTIONNAME"] = txtRef.Text;
                            dtInsp.Rows.Add(newRow);
                        }
                    }
                }
                else
                {
                    state = "UpdateInspData";

                    dtInsp = grdIsnpInfo.GetChangedRows();

                    DataRow row = grdRevision.View.GetFocusedDataRow();
                    int revNo = Int32.Parse(row["REVNO"].ToString());

                    newRow = dtInsp.NewRow();
                    newRow["REVNO"] = revNo;
                    newRow["INSPECTIONID"] = "REF";
                    newRow["INSPECTIONNAME"] = txtRef.Text;
                    dtInsp.Rows.Add(newRow);
                }
                
                MessageWorker worker = new MessageWorker("SaveShipInspectionStandard");
                worker.SetBody(new MessageBody()
                {
                    { "state", state },
                    { "dtRev", dtRev },
                    { "dtInsp", dtInsp }

                });

                worker.Execute();

                // '저장을 완료하였습니다.'
                ShowMessage("SuccedSave");

                // 재조회
                OnSearchAsync();
                
            }
        }
        #endregion

        #region 검색
        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            grdRevision.View.ClearDatas();
            grdIsnpInfo.View.ClearDatas();

            var values = Conditions.GetValues();
            DataTable dtRev = SqlExecuter.Query("GetRevisionForShipInspStandard", "00001", values);

            if (dtRev.Rows.Count < 1)
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdRevision.DataSource = dtRev;

            SelectRevisionForInspData();
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();
        }
        #endregion
        

        #region Private Function
        private void SelectRevisionForInspData()
        {
            grdIsnpInfo.View.ClearDatas();

            DataRow row = grdRevision.View.GetFocusedDataRow();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("REVNO", row["REVNO"].ToString());

            if (row["REVNO"].ToString().Equals(""))
            {
                grdIsnpInfo.View.ClearDatas();
                txtRef.Text = "";
            }
            else
            {
                DataTable dtInsp = SqlExecuter.Query("GetShipInspecData", "00001", param);
                DataTable dtRef = SqlExecuter.Query("GetShipInspecDataRef", "00001", param);

                grdIsnpInfo.DataSource = dtInsp;
                txtRef.Text = dtRef.Rows[0]["INSPECTIONNAME"].ToString();
            }
            
        }
        #endregion
    }
}