#region using

using DevExpress.XtraGrid.Views.Grid;
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

namespace Micube.SmartMES.Material
{
     /// <summary>
     /// 프 로 그 램 명  : 자재관리 > 기타입출고 > 입고처리 팝업
     /// 업  무  설  명  : 기타입출고 - 입고 처리 하는 팝업
     /// 생    성    자  : 주시은
     /// 생    성    일  : 2021-07-06
     /// 수  정  이  력  : 
     /// 
     /// 
     /// </summary>
     
    public partial class EtcInPopup_Grid : SmartPopupBaseForm
    {
        private string _ItemDefType { get; set; }

        private string _codeClassId = "EtcInTypeMate";

        public EtcInPopup_Grid()
        {
            InitializeComponent();
            InitializeEvent();

            InitializeGrid();
        }
        private void InitializeGrid()
        {
            grdEtcIn.GridButtonItem = GridButtonItem.All;
            grdEtcIn.ShowStatusBar = false;

            grdEtcIn.View.SetSortOrder("SEQ");

            // 품목 코드
            InitializePopup_ItemId();
            //품목명
            grdEtcIn.View.AddTextBoxColumn("PRODUCTDEFNAME", 120)
                .SetIsReadOnly();
            //입고 유형
            grdEtcIn.View.AddComboBoxColumn("INOUTTYPE", 80, new SqlQuery("GetCodeList", "00001", $"CODECLASSID={_codeClassId}", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CODENAME", "CODEID")
                .SetLabel("InType")
                .SetValidationIsRequired()
                .SetIsRefreshByOpen(true);
            //창고
            grdEtcIn.View.AddComboBoxColumn("WAREHOUSEID", 80, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center);
            //셀 형
            grdEtcIn.View.AddComboBoxColumn("CELLID", 80, new SqlQuery("GetCellId", "00001"), "CELLNAME", "LOCATIONID")
                .SetLabel("CELLNAME")
                .SetTextAlignment(TextAlignment.Center);
            //수량
            grdEtcIn.View.AddSpinEditColumn("CONSUMABLELOTQTY", 80)
                .SetValidationIsRequired()
                .SetLabel("INQTY");
            //설명
            grdEtcIn.View.AddTextBoxColumn("DESCRIPTION", 150);
            //품목 유형
            grdEtcIn.View.AddTextBoxColumn("ITEMDEFTYPE", 80)
                .SetIsHidden();

            grdEtcIn.View.PopulateColumns();
        }

        ///<summary>
        /// 팝업형 컬럼 초기화 - 품목 코드
        /// </summary>
        private void InitializePopup_ItemId()
        {
            var itemId = grdEtcIn.View.AddSelectPopupColumn("PRODUCTDEFID", new SqlQuery("GetAllItemDefinitionListForEtc", "00001", $"PLANTID={UserInfo.Current.Plant}", $"LANGUAGETYPE={ UserInfo.Current.LanguageType }"))
                .SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(800, 800)
                .SetPopupAutoFillColumns("PRODUCTDEFID")
                .SetLabel("PRODUCTDEFID")
                .SetValidationIsRequired()
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    List<DataRow> list = selectedRows.ToList<DataRow>();

                    if (list.Count == 0) return;

                    dataGridRow["PRODUCTDEFID"] = list[0]["PRODUCTDEFID"];
                    dataGridRow["PRODUCTDEFNAME"] = list[0]["PRODUCTDEFNAME"];

                    _ItemDefType = list[0]["PRODUCTDEFTYPE"].ToString();

                    dataGridRow["ITEMDEFTYPE"] = _ItemDefType;

                    // 품목 선택시 해당 품목 유형을 파라미터로 사용하여 입고 유형 쿼리 refresh하는 함수로 전송
                    InitializeReasonId(_ItemDefType);
                });


            itemId.Conditions.AddTextBox("TXTPRODUCTDEFNAME");
            itemId.Conditions.AddComboBox("P_PRODUCTDEFTYPE", new SqlQuery("GetCodeList", "00001", $"CODECLASSID=ItemDefTypeForEtc", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CODENAME", "CODEID")
                    .SetDefault("Material")
                    .SetLabel("PRODUCTDEFTYPE");

            itemId.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 100)
                .SetIsReadOnly();
            itemId.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 120)
                .SetIsReadOnly();
            itemId.GridColumns.AddComboBoxColumn("PRODUCTDEFTYPE", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetIsReadOnly();
            itemId.GridColumns.AddComboBoxColumn("UNIT", 90, new SqlQuery("GetUnitList", "00001"))
                .SetIsReadOnly();



        }

        /// <summary>
        /// 창고 선택 이벤트 이후 cell 콤보에 나오는 데이터 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblWarehouseId_Changed(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "WAREHOUSEID")
            {
                DataRow row = grdEtcIn.View.GetFocusedDataRow();
                string sWarehouseId = row["WAREHOUSEID"].ToString();

                grdEtcIn.View.RefreshComboBoxDataSource("CELLID", new SqlQuery("GetCellId", "00001", $"P_WAREHOUSEID={sWarehouseId}"));

            }
            
        }



        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            // 컬럼 변경시 이벤트
            grdEtcIn.View.CellValueChanged += LblWarehouseId_Changed;
        }

        /// <summary>
        /// Form Road시 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnSave.Focus();
                btnSave.Enabled = false;

                if(ValidateContent())
                {
                    if(ShowMessage(MessageBoxButtons.YesNo, "InfoSave") == DialogResult.Yes)
                    {
                        DataTable dtEtcIn = grdEtcIn.DataSource as DataTable;
                        MessageWorker worker = new MessageWorker("CreateConsumableLotByEtc_Grid");
                        worker.SetBody(new MessageBody()
                        {
                            { "dtEtcIn", dtEtcIn }
                            ,{ "consumablestate", "Available" }
                        }); ;
                        
                        var saveResult = worker.Execute<DataTable>();
                        DataTable resultData = saveResult.GetResultSet();

                        ShowMessage("SuccessSave");

                        // 라벨 발행 
                        if (MSGBox.Show(MessageBoxType.Question, "NewLotByEtcIn", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string lotId = string.Empty;
                            string itemDefType = string.Empty;
                            if (resultData.Rows.Count > 0)
                            {
                                foreach (DataRow row in resultData.Rows)
                                {
                                    lotId = row["LOTID"].ToString();
                                    itemDefType = row["ITEMDEFTYPE"].ToString();
                                    if (itemDefType == "Material")
                                    {
                                        CommonFunction.PrintMaterialLabel(lotId);
                                    }
                                    else
                                    {
                                        CommonFunction.PrintLotLabel(lotId);
                                    }
                                }
                            }
                        }


                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnSave.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        #endregion

        #region Private Function

        /// <summary>
        /// 저장시 Validation 체크
        /// </summary>
        /// <returns></returns>
        private bool ValidateContent()
        {
            bool result = true;

            DataTable dt = grdEtcIn.DataSource as DataTable;
            
            foreach (DataRow row in dt.Rows)
            {
                if (row["INOUTTYPE"] == null || row["INOUTTYPE"].Equals(""))
                    result = false;

                if (row["PRODUCTDEFID"] == null || row["PRODUCTDEFID"].Equals(""))
                    result = false;

                if (row["WAREHOUSEID"] == null || row["WAREHOUSEID"].Equals(""))
                    result = false;

                if (row["CONSUMABLELOTQTY"] == null || row["CONSUMABLELOTQTY"].Equals("") || Convert.ToInt32(row["CONSUMABLELOTQTY"]) == 0)
                    result = false;
            }
            
            return result;
        }

        
        private void InitializeReasonId(string _ItemDefType)
        {
            if (_ItemDefType == "Material")
            {
                _codeClassId = "EtcInTypeMate";
            }
            else if (_ItemDefType == "HalfProduct")
            {
                _codeClassId = "EtcInTypeProd";
            }

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("CODECLASSID", _codeClassId);
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            grdEtcIn.View.RefreshComboBoxDataSource("INOUTTYPE", new SqlQuery("GetCodeList", "00001", param));
            
        }
        


        #endregion
    }
}
