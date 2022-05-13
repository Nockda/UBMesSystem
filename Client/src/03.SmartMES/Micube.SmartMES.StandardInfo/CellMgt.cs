#region using
using DevExpress.Charts.Native;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Filtering.Templates;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 창고관리 > 랙관리
    /// 업  무  설  명  : 창고별 랙을 관리한다.
    /// 생    성    자  : jylee
    /// 생    성    일  : 2020-04-14
    /// 수  정  이  력  : 2020-06-09 | JYLEE | 컬럼수정, 맵핑정보 테이블 변경으로 인한 수정
    /// 
    /// 
    /// </summary>
    public partial class CellMgt : SmartConditionBaseForm
    {
        public CellMgt()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화
        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeMaster();
            InitializeItem();
        }
        private void InitializeMaster()
        {
            grdMaster.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdMaster.GridButtonItem = GridButtonItem.Add | GridButtonItem.Delete | GridButtonItem.Export;

            grdMaster.View.SetSortOrder("CELLGROUPID");

            //CELL GROUP ID
            grdMaster.View.AddTextBoxColumn("CELLGROUPID", 100)
                .SetValidationKeyColumn()
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center);

            //CELL GROUP NAME
            grdMaster.View.AddTextBoxColumn("CELLGROUPNAME", 200)
                .SetValidationIsRequired();

            //창고ID(HIDDEN)
            grdMaster.View.AddTextBoxColumn("WAREHOUSEID", 150).SetIsHidden();

            //창고이름
            ClickWarehousePopup();

            //TYPE
            grdMaster.View.AddComboBoxColumn("TYPE", 150, new SqlQuery("GetCodeList", "00001", "CODECLASSID=RackKeepDivision", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));

            //TEAM
            grdMaster.View.AddComboBoxColumn("TEAM", 150, new SqlQuery("GetTeamList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));

            //비고
            grdMaster.View.AddTextBoxColumn("DESCRIPTION", 250);

            //담당자ID(정)
            grdMaster.View.AddTextBoxColumn("MAINUSERID", 250).SetIsHidden();
            ClickMainUserPopup();

            //담당자(부)
            grdMaster.View.AddTextBoxColumn("SUBUSERID", 250).SetIsHidden();
            ClickSubUserPopup();

            //유효상태
            grdMaster.View.AddComboBoxColumn("VALIDSTATE", 150, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetDefault("Valid")
               .SetValidationIsRequired()
               .SetTextAlignment(TextAlignment.Center);

            /*            //생성자
                        grdMaster.View.AddTextBoxColumn("CREATOR", 80)
                            .SetIsReadOnly()
                            .SetTextAlignment(TextAlignment.Center);
                        //생성일
                        grdMaster.View.AddTextBoxColumn("CREATEDTIME", 130)
                            .SetIsReadOnly()
                            .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                            .SetTextAlignment(TextAlignment.Center);
                        //수정자
                        grdMaster.View.AddTextBoxColumn("MODIFIER", 80)
                            .SetIsReadOnly()
                            .SetTextAlignment(TextAlignment.Center);
                        //수정일
                        grdMaster.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                            .SetIsReadOnly()
                            .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                            .SetTextAlignment(TextAlignment.Center);*/


            grdMaster.View.PopulateColumns();
        }

        private void InitializeItem()
        {
            grdItem.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdItem.GridButtonItem = GridButtonItem.Add | GridButtonItem.Delete | GridButtonItem.Export;
            //grdItem.View.SetSortOrder("CELLID");

            //CELL
            grdItem.View.AddTextBoxColumn("CELLID", 100)
                .SetValidationKeyColumn()
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center);

            //CELL이름
            grdItem.View.AddTextBoxColumn("CELLNAME", 120)
                .SetTextAlignment(TextAlignment.Center);

            //CELLGROUPID
            grdItem.View.AddTextBoxColumn("CELLGROUPID", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();

            //CELLGROUPNAME
            grdItem.View.AddTextBoxColumn("CELLGROUPNAME", 150)
                .SetIsHidden();

            //ITEMID
            grdItem.View.AddTextBoxColumn("ITEMID", 250)
                .SetIsHidden();

            //품번
            CheckItemPopup();

            //ITEMNAME
            grdItem.View.AddTextBoxColumn("ITEMNAME", 250)
                .SetIsReadOnly();

            //QTY
            grdItem.View.AddTextBoxColumn("QTY", 100);

            //위치
            grdItem.View.AddTextBoxColumn("LOCATION", 100)
                .SetTextAlignment(TextAlignment.Center);

            //표시순서
            grdItem.View.AddSpinEditColumn("DISPLAYSEQUENCE", 80)
                .SetDisplayFormat("#,##0", MaskTypes.Numeric, false);// 소수점 표시 안함

            //유효상태
            grdItem.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetDefault("Valid")
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center);


            /*            //생성자
                        grdItem.View.AddTextBoxColumn("CREATOR", 80)
                            .SetIsReadOnly()
                            .SetTextAlignment(TextAlignment.Center);

                        //생성일
                        grdItem.View.AddTextBoxColumn("CREATEDTIME", 130)
                            .SetIsReadOnly()
                            .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                            .SetTextAlignment(TextAlignment.Center);

                        //수정자
                        grdItem.View.AddTextBoxColumn("MODIFIER", 80)
                            .SetIsReadOnly()
                            .SetTextAlignment(TextAlignment.Center);

                        //수정일
                        grdItem.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                            .SetIsReadOnly()
                            .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                            .SetTextAlignment(TextAlignment.Center);*/

            grdItem.View.PopulateColumns();

        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>

        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdMaster.View.AddingNewRow += View_AddingNewRow;
            grdMaster.View.FocusedRowChanged += View_FocusedRowChanged;

            grdItem.View.AddingNewRow += View_AddingNewRowForItem;
            btnSaveItem.Click += BtnSaveItem_Click;
            btnPrintCellLabel.Click += BtnPrintLabel_Click;
            btnPrintKanbanLabel.Click += BtnPrintKanbanLabel_Click;
        }

        private void BtnSaveItem_Click(object sender, EventArgs e)
        {
            grdItem.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnSaveItem.Focus();
                btnSaveItem.Enabled = false;

                DataTable changed = grdItem.GetChangedRows();//변경된 row
                if (changed.Rows.Count == 0)
                {
                    throw MessageException.Create("NoSaveData");
                }

                ExecuteRule("SaveCell", changed);

                ShowMessage("SuccessSave");
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnSaveItem.Enabled = true;

                var row = grdMaster.View.GetDataRow(grdMaster.View.FocusedRowHandle);
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("P_CELLGROUPID", row["CELLGROUPID"].ToString());
                param.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);
                grdItem.DataSource = SqlExecuter.Query("GetCellList", "00001", param);

            }
        }

        private void BtnPrintLabel_Click(object sender, EventArgs e)
        {
            DataTable dt = grdItem.View.GetCheckedRows();

            if (dt.Rows.Count < 1)
            {
                return;
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    CommonFunction.PrintCellLabel(row["CELLID"].ToString());
                }
            }

            /*            DataRow row = grdItem.View.GetFocusedDataRow();
                        if (row == null)
                        {
                            return;
                        }
                        CommonFunction.PrintCellLabel(row["CELLID"].ToString());*/
        }

        private void BtnPrintKanbanLabel_Click(object sender, EventArgs e)
        {

            DataTable dt = grdItem.View.GetCheckedRows();

            if(dt.Rows.Count < 1)
            {
                return;
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    CommonFunction.PrintKanbanLabel(row["CELLID"].ToString());
                }
            }
        }

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdMaster.View.GetFocusedDataRow();
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //focusedRowChanged();

            

            var row = grdMaster.View.GetDataRow(grdMaster.View.FocusedRowHandle);

            if (row != null)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("P_CELLGROUPID", row["CELLGROUPID"].ToString());

                if (string.IsNullOrEmpty(row["CELLGROUPID"].ToString()))
                {
                    return;
                    /*   ShowMessage("NoSelectData");


                         return;*/
                }
                grdItem.View.ClearDatas();
                grdItem.DataSource = SqlExecuter.Query("GetCellList", "00001", param);
            }
        }

        private void View_AddingNewRowForItem(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdMaster.View.GetFocusedDataRow();
            string masterId = focusRow["CELLGROUPID"].ToString();
            string masterName = focusRow["CELLGROUPNAME"].ToString();
            args.NewRow["CELLGROUPID"] = masterId;
            args.NewRow["CELLGROUPNAME"] = masterName;

        }

        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdMaster.GetChangedRows();

            ExecuteRule("SaveCellGroup", changed);
        }
        #endregion

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();
            grdItem.DataSource = null;


            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtMaster = await QueryAsync("GetCellGroupMasterList", "00001", values);

            if (dtMaster.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
                grdMaster.DataSource = null;
                grdItem.DataSource = null;
            }
            else if(dtMaster.Rows.Count == 1)
            {
                grdMaster.DataSource = dtMaster;
                grdItem.DataSource = SqlExecuter.Query("GetCellList", "00001", values);
            }
            else 
            {
                grdMaster.DataSource = dtMaster;

                //품목코드 기본값 ""
                values.TryGetValue("P_ITEMCODE", out object consumableDefId);

                if ((string)consumableDefId != "")
                {
                    grdItem.DataSource = SqlExecuter.Query("GetCellList", "00001", values);
                    grdMaster.DataSource = null;
                }
            }
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
/*        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            Conditions.GetControl<SmartComboBox>("p_WAREHOUSE").EditValueChanged += WorkGroupCode_EditValueChanged;
        }*/

        #endregion

        #region 유효성 검사
        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            grdMaster.View.CheckValidation();

            DataTable changedMaster = grdMaster.GetChangedRows();
            if (changedMaster.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function
        //창고 맵핑
        private void ClickWarehousePopup()
        {
            var popupColumn = grdMaster.View.AddSelectPopupColumn("WAREHOUSENAME", 150, new SqlQuery("SelectWarehouseList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("GRIDWAREHOUSEINFO", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("WAREHOUSENAME", "WAREHOUSENAME")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
           .SetPopupApplySelection((selectedRows, dataGridRow) =>
           {
               DataRow classRow = grdMaster.View.GetFocusedDataRow();

               foreach (DataRow row in selectedRows)
               {
                   classRow["WAREHOUSEID"] = row["WAREHOUSEID"];
               }
           });
            popupColumn.GridColumns.AddTextBoxColumn("WAREHOUSEID", 150).SetIsHidden();
            popupColumn.GridColumns.AddTextBoxColumn("WAREHOUSENAME", 150);
            popupColumn.GridColumns.AddTextBoxColumn("WAREHOUSETYPE", 80).SetTextAlignment(TextAlignment.Center);
            popupColumn.GridColumns.AddTextBoxColumn("DESCRIPTION", 150);

            /*            popupColumn.Conditions.AddTextBox("P_WAREHOUSENAME")
                            .SetDefault("")
                            .SetLabel("WAREHOUSENAME");*/
        }

        //담당자(정) 맵핑
        private void ClickMainUserPopup()
        {
            var popupColumn = grdMaster.View.AddSelectPopupColumn("MAINUSERNAME", 150, new SqlQuery("GetUserSelectPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTUSER", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("MAINUSERNAME", "USERNAME")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetTextAlignment(TextAlignment.Center)
            .SetPopupApplySelection((selectedRows, dataGridRow) =>
            {
                DataRow classRow = grdMaster.View.GetFocusedDataRow();

                foreach (DataRow row in selectedRows)
                {
                    classRow["MAINUSERID"] = row["USERID"];
                }
            });
            popupColumn.GridColumns.AddTextBoxColumn("DEPARTMENT", 80).SetIsHidden();
            popupColumn.GridColumns.AddTextBoxColumn("DEPARTMENTNAME", 80).SetLabel("DEPARTMENT");
            popupColumn.GridColumns.AddTextBoxColumn("USERID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("USERNAME", 100);

            //검색조건
            //popupColumn.Conditions.AddTextBox("P_USERNAME").SetLabel("USERNAME");
        }

        //담당자(부) 맵핑
        private void ClickSubUserPopup()
        {
            var popupColumn = grdMaster.View.AddSelectPopupColumn("SUBUSERNAME", 150, new SqlQuery("GetUserSelectPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTUSER", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("SUBUSERNAME", "USERNAME")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetTextAlignment(TextAlignment.Center)
            .SetPopupApplySelection((selectedRows, dataGridRow) =>
            {
                DataRow classRow = grdMaster.View.GetFocusedDataRow();

                foreach (DataRow row in selectedRows)
                {
                    classRow["SUBUSERID"] = row["USERID"];
                }
            });
            popupColumn.GridColumns.AddTextBoxColumn("DEPARTMENT", 80).SetIsHidden();
            popupColumn.GridColumns.AddTextBoxColumn("DEPARTMENTNAME", 80).SetLabel("DEPARTMENT");
            popupColumn.GridColumns.AddTextBoxColumn("USERID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("USERNAME", 100);

            //검색조건
            // popupColumn.Conditions.AddTextBox("P_USERNAME").SetLabel("USERNAME");
        }

        //품목 맵핑
        private void CheckItemPopup()
        {
            var popupColumn = grdItem.View.AddSelectPopupColumn("PARTNUMBER", 150, new SqlQuery("GetItemPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTPARENTCODECLASSID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("PARTNUMBER", "PARTNUMBER")
                .SetPopupLayoutForm(800, 800, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("ITEMNAME")
                .SetTextAlignment(TextAlignment.Center)
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow classRow = grdItem.View.GetFocusedDataRow();

                    foreach (DataRow row in selectedRows)
                    {
                        classRow["ITEMNAME"] = row["ITEMNAME"];
                        classRow["ITEMID"] = row["ITEMID"];
                    }
                });
            popupColumn.GridColumns.AddTextBoxColumn("PARTNUMBER", 100);
            popupColumn.GridColumns.AddTextBoxColumn("ITEMNAME", 200);
            popupColumn.GridColumns.AddTextBoxColumn("MATERIALTYPE", 80);

            //검색조건
            /*  popupColumn.Conditions.AddTextBox("MATERIALNAME");*/
            popupColumn.Conditions.AddComboBox("MATERIALTYPE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetDefault("Material"); //원자재
        }


        /*        private void WorkGroupCode_EditValueChanged(object sender, EventArgs e)
                {
                    SqlQuery condition = new SqlQuery("GetComboRack", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_WORKGROUPCODE={Conditions.GetControl<SmartComboBox>("P_WORKGROUPCODE").EditValue}");
                    DataTable conditionTable = condition.Execute();
                    this.Conditions.GetControl<SmartComboBox>("p_RACKNAME").ValueMember = "CODEID";
                    this.Conditions.GetControl<SmartComboBox>("p_RACKNAME").DisplayMember = "CODENAME";
                    this.Conditions.GetControl<SmartComboBox>("p_RACKNAME").EditValue = "*";
                    this.Conditions.GetControl<SmartComboBox>("p_RACKNAME").DataSource = conditionTable;
                }*/
        #endregion
    }
}