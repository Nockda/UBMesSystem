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
     /// 프 로 그 램 명  : 자재관리 > 기타입출고 > 출고처리 팝업
     /// 업  무  설  명  : 기타입출고 - 출고 처리 하는 팝업
     /// 생    성    자  : 주시은
     /// 생    성    일  : 2021-07-12
     /// 수  정  이  력  : 
     /// 
     /// 
     /// </summary>
     
    public partial class EtcOutPopup_Grid : SmartPopupBaseForm
    {
        private string _ItemDefType { get; set; }

        public EtcOutPopup_Grid()
        {
            InitializeComponent();
            InitializeEvent();

            InitializeGrid();
        }
        private void InitializeGrid()
        {
            grdEtcOut.GridButtonItem = GridButtonItem.All;
            grdEtcOut.ShowStatusBar = false;

            grdEtcOut.View.SetSortOrder("SEQ");

            //LotNo.
            InitializePopup_LotNo();
            // 품목 코드
            grdEtcOut.View.AddTextBoxColumn("CONSUMABLEDEFID", 100)
                .SetLabel("PRODUCTDEFID")
                .SetIsReadOnly();
            //품목명
            grdEtcOut.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 120)
                .SetLabel("PRODUCTDEFNAME")
                .SetIsReadOnly();
            //출고 유형
            grdEtcOut.View.AddComboBoxColumn("INOUTTYPE", 80, new SqlQuery("GetCodeList", "00001", $"CODECLASSID=EtcOutType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CODENAME", "CODEID")
                .SetValidationIsRequired()
                .SetLabel("OutType")
                .SetIsRefreshByOpen(true);
            //창고
            grdEtcOut.View.AddComboBoxColumn("WAREHOUSEID", 80, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetValidationIsRequired()
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //셀 형
            grdEtcOut.View.AddComboBoxColumn("CELLID", 80, new SqlQuery("GetCellId", "00001"), "CELLNAME", "LOCATIONID")
                .SetLabel("CELLNAME")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //출고 수량
            grdEtcOut.View.AddSpinEditColumn("CONSUMABLELOTQTY", 80)
                .SetValidationIsRequired()
                .SetLabel("OUTQTY");
            //Lot 수량
            grdEtcOut.View.AddTextBoxColumn("LOTQTY", 80)
                .SetIsReadOnly();
            //설명
            grdEtcOut.View.AddTextBoxColumn("DESCRIPTION", 150);
            //품목 유형
            grdEtcOut.View.AddTextBoxColumn("ITEMDEFTYPE", 80)
                .SetIsHidden();

            grdEtcOut.View.PopulateColumns();
        }

        ///<summary>
        /// 팝업형 컬럼 초기화 - LotNo.
        /// </summary>
        private void InitializePopup_LotNo()
        {
            var lotNo = grdEtcOut.View.AddSelectPopupColumn("CONSUMABLELOTID", new SqlQuery("GetMaterialEtcOutList", "00001", $"LANGUAGETYPE={ UserInfo.Current.LanguageType }"))
                .SetPopupLayout("CONSUMABLELOTID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(900, 600)
                .SetPopupAutoFillColumns("CONSUMABLELOTID")
                .SetLabel("LOTID")
                .SetValidationIsRequired()
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    List<DataRow> list = selectedRows.ToList<DataRow>();

                    if (list.Count == 0) return;

                    dataGridRow["CONSUMABLEDEFID"] = list[0]["CONSUMABLEDEFID"];
                    dataGridRow["CONSUMABLEDEFNAME"] = list[0]["CONSUMABLEDEFNAME"];
                    dataGridRow["CONSUMABLELOTQTY"] = list[0]["CONSUMABLELOTQTY"];
                    dataGridRow["WAREHOUSEID"] = list[0]["WAREHOUSEID"];
                    dataGridRow["CELLID"] = list[0]["LOCATIONID"];
                    dataGridRow["LOTQTY"] = list[0]["CONSUMABLELOTQTY"];
                    dataGridRow["ITEMDEFTYPE"] = list[0]["CONSUMABLETYPE"].ToString();

                });
            lotNo.Conditions.AddTextBox("P_CONSUMABLELOTID")
                .SetLabel("CONSUMABLELOTID");
            lotNo.Conditions.AddTextBox("P_CONSUMABLEDEFID")
                .SetLabel("ITEMID");
            lotNo.Conditions.AddTextBox("P_CONSUMABLEDEFNAME")
                .SetLabel("ITEMNAME");

            lotNo.GridColumns.AddTextBoxColumn("CONSUMABLELOTID", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            lotNo.GridColumns.AddTextBoxColumn("CONSUMABLEDEFID", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            lotNo.GridColumns.AddTextBoxColumn("CONSUMABLEDEFNAME", 120)
                .SetIsReadOnly();
            lotNo.GridColumns.AddTextBoxColumn("STANDARD", 120)
                .SetIsReadOnly();
            lotNo.GridColumns.AddTextBoxColumn("CONSUMABLELOTQTY", 80)
                .SetIsReadOnly();
            lotNo.GridColumns.AddComboBoxColumn("UNIT", 90, new SqlQuery("GetUnitList", "00001"))
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            lotNo.GridColumns.AddTextBoxColumn("WAREHOUSEID", 50)
                .SetIsHidden();
            lotNo.GridColumns.AddTextBoxColumn("LOCATIONID", 50)
                .SetIsHidden();
            lotNo.GridColumns.AddComboBoxColumn("CONSUMABLETYPE", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);



        }

        /// <summary>
        /// 창고 선택 이벤트 이후 cell 콤보에 나오는 데이터 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblWarehouseId_Changed(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = grdEtcOut.View.GetFocusedDataRow();
            // 창고 변경시
            //if (e.Column.FieldName == "WAREHOUSEID")
            //{
            //    string sWarehouseId = row["WAREHOUSEID"].ToString();

            //    grdEtcOut.View.RefreshComboBoxDataSource("CELLID", new SqlQuery("GetCellId", "00001", $"P_WAREHOUSEID={sWarehouseId}"));

            //}
            // 출고 수량 변경시
            if (e.Column.FieldName == "CONSUMABLELOTQTY")
            {
                decimal dQty = Convert.ToDecimal(row["CONSUMABLELOTQTY"].ToString());
                decimal dTotal = Convert.ToDecimal(row["LOTQTY"].ToString());

                if (dQty > dTotal)
                {
                    row["CONSUMABLELOTQTY"] = dTotal;
                    return;
                }

                if (dQty < 0)
                {
                    row["CONSUMABLELOTQTY"] = 0;
                    return;
                }
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
            grdEtcOut.View.CellValueChanged += LblWarehouseId_Changed;
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
                    if (ShowMessage(MessageBoxButtons.YesNo, "InfoSave") == DialogResult.Yes)
                    {
                        DataTable dtEtcOut = grdEtcOut.DataSource as DataTable;
                        MessageWorker worker = new MessageWorker("DeliveryConsumableLotByEtc_Grid");
                        worker.SetBody(new MessageBody()
                        {
                            { "dtEtcOut", dtEtcOut }
                            ,{ "consumablestate", "Available" }
                            ,{ "userid", UserInfo.Current.Id}
                        });

                        worker.Execute();

                        ShowMessage("SuccessSave");

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

            DataTable dt = grdEtcOut.DataSource as DataTable;
            
            foreach(DataRow row in dt.Rows)
            {
                if (row["INOUTTYPE"] == null || row["INOUTTYPE"].Equals(""))
                    result = false;

                if (row["CONSUMABLELOTID"] == null || row["CONSUMABLELOTID"].Equals(""))
                    result = false;

                if (row["WAREHOUSEID"] == null || row["WAREHOUSEID"].Equals(""))
                    result = false;

                if (row["CONSUMABLELOTQTY"] == null || row["CONSUMABLELOTQTY"].Equals("") || Convert.ToInt32(row["CONSUMABLELOTQTY"]) <= 0)
                    result = false;
            }

            return result;
            
        }
        
        #endregion
    }
}
