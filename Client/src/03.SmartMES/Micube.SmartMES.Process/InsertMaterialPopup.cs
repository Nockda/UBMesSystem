#region using
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using Micube.SmartMES.Commons.Popup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
#endregion

/// <summary>
/// 프 로 그 램 명  : 공정관리 > 공정실적등록 > 공정
/// 업  무  설  명  : 공정실적등록 자재투입 팝업
/// 생    성    자  : JYLEE
/// 생    성    일  : 2020-05-25
/// 수  정  이  력  : 
/// </summary>
namespace Micube.SmartMES.Process
{
    public partial class InsertMaterialPopup : SmartPopupBaseForm
    {
        private string lotId;           // LOT ID
        private string workorderId;     // 작업지시번호

        public InsertMaterialPopup(string lotId, string workorderId, bool disableBadQty)
        {
            InitializeComponent();
            this.lotId = lotId;
            this.workorderId = workorderId;
            if (disableBadQty)
            {
                txtBadQty.ReadOnly = true;
            }
            InitializeGrid();
            InitializeEvent();
        }

        #region 컨텐츠 초기화
        private void InitializeGrid()
        {
            InitializeBomGrid();
            InitializeMaterialGrid();
            InitializeUnTrackingGrid();
        }

        // BOM 그리드 초기화
        private void InitializeBomGrid()
        {
            grdBom.GridButtonItem = GridButtonItem.None;
            grdBom.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdBom.View.SetIsReadOnly();
            grdBom.View.AddTextBoxColumn("CONSUMABLEDEFID", 120).SetIsHidden(); 		// 자재ID
            grdBom.View.AddTextBoxColumn("PARTNUMBER", 120).SetLabel("CONSUMABLEDEFID");
            grdBom.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 200); 	// 자재명
            grdBom.View.AddTextBoxColumn("CONSUMABLETYPE", 65)
                .SetTextAlignment(TextAlignment.Center);				// 자재 타입
            grdBom.View.AddTextBoxColumn("NEEDQTY", 60); 				// 필요 수량
            grdBom.View.AddTextBoxColumn("INPUTQTY", 60); 				// 투입 수량
            grdBom.View.AddTextBoxColumn("ISINBOM", 50)
                .SetTextAlignment(TextAlignment.Center);				// BOM 자재여부
            grdBom.View.PopulateColumns();
        }

        // 자재 LOT 그리드 초기화
        private void InitializeMaterialGrid()
        {
            grdMaterial.GridButtonItem = GridButtonItem.None;
            grdMaterial.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdMaterial.View.SetIsReadOnly();
            grdMaterial.View.AddTextBoxColumn("CONSUMABLEDEFID", 120).SetIsHidden();                  // 자재 정의ID
            grdMaterial.View.AddTextBoxColumn("PARTNUMBER", 120).SetLabel("CONSUMABLEDEFID");
            grdMaterial.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 200);				// 자재명
            grdMaterial.View.AddTextBoxColumn("MATERIALLOTID", 100); 					// 자재 LOT
            grdMaterial.View.AddTextBoxColumn("SERIALNO", 100); 						// 일련번호
            grdMaterial.View.AddTextBoxColumn("GOODQTY", 50); 							// 양품 수량
            grdMaterial.View.AddTextBoxColumn("BADQTY", 50); 							// 불량 수량
            grdMaterial.View.AddTextBoxColumn("DESCRIPTION", 100).SetLabel("COMMENT");	// 특이사항
            grdMaterial.View.PopulateColumns();
        }

        private void InitializeUnTrackingGrid()
        {
            grdUnTracking.GridButtonItem = GridButtonItem.None;
            grdUnTracking.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdUnTracking.View.OptionsNavigation.EnterMoveNextColumn = true;
            grdUnTracking.View.AddTextBoxColumn("CONSUMABLEDEFID", 40).SetIsHidden();
            AddConsumableDefIdSelectPopup();                                                // 자재 정의 ID
            grdUnTracking.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 200).SetIsReadOnly();  // 자재명
            grdUnTracking.View.AddTextBoxColumn("ISINBOM", 40)
                .SetTextAlignment(TextAlignment.Center).SetIsReadOnly();				    // BOM 자재여부
            grdUnTracking.View.AddTextBoxColumn("UNIT", 80).SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);                                    // 단위
            grdUnTracking.View.AddTextBoxColumn("BOMQTY", 80).SetIsReadOnly();              // BOM 수량
            grdUnTracking.View.AddTextBoxColumn("ORG_INPUTQTY", 80)
                .SetIsReadOnly().SetLabel("INPUTQTY");                                      // 투입수량
            grdUnTracking.View.AddTextBoxColumn("NEEDQTY", 80)
                .SetIsReadOnly().SetIsHidden();                                             // 필요수량
            grdUnTracking.View.AddTextBoxColumn("ORG_STOCKQTY", 80)
                .SetIsReadOnly().SetLabel("STOCKQTY");                                      // 재고수량
            grdUnTracking.View.AddTextBoxColumn("STOCKQTY", 80)
                .SetIsReadOnly().SetLabel("STOCKQTYAFTERINPUT");                            // 투입후 재고수량
            grdUnTracking.View.AddSpinEditColumn("GOODQTY", 80)
                .SetDisplayFormat("#,##0.#########");                                       // 양품수량
            grdUnTracking.View.AddSpinEditColumn("BADQTY", 80)
                .SetDisplayFormat("#,##0.#########");                                       // 불량수량
            grdUnTracking.View.AddTextBoxColumn("COMMENT", 220);                            // 특이사항
            grdUnTracking.View.PopulateColumns();
        }
        
        private void AddConsumableDefIdSelectPopup()
        {
            var popup = grdUnTracking.View.AddSelectPopupColumn("PARTNUMBER", 120,
                    new SqlQuery("GetConsumableDefListPopupWithStock", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"
                        , $"LOTID={this.lotId}"))
                .SetPopupLayout("SELECTCONSUMABLEDEFLIST", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("PARTNUMBER", "PARTNUMBER")
                .SetPopupLayoutForm(800, 600, System.Windows.Forms.FormBorderStyle.Sizable)
                .SetPopupAutoFillColumns("CONSUMABLEDEFNAME")
                .SetValidationIsRequired()
                .SetValidationKeyColumn()
                .SetClearButtonInvisible()
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow focusedRow = grdUnTracking.View.GetFocusedDataRow();
                    foreach (DataRow row in selectedRows)
                    {
                        focusedRow["CONSUMABLEDEFID"] = row["CONSUMABLEDEFID"];
                        focusedRow["CONSUMABLEDEFNAME"] = row["CONSUMABLEDEFNAME"];
                        focusedRow["UNIT"] = row["UNIT"];
                        focusedRow["NEEDQTY"] = 0;
                        focusedRow["STOCKQTY"] = row["STOCKQTY"];
                        focusedRow["ORG_STOCKQTY"] = row["STOCKQTY"];
                        focusedRow["GOODQTY"] = 0;
                        focusedRow["BADQTY"] = 0;
                        focusedRow["ORG_GOODQTY"] = 0;
                        focusedRow["ORG_BADQTY"] = 0;
                        focusedRow["ISINBOM"] = "N";
                    }
                });
            // 조회 컬럼
            popup.GridColumns.AddTextBoxColumn("CONSUMABLETYPE", 65);
            popup.GridColumns.AddTextBoxColumn("PARTNUMBER", 155).SetLabel("CONSUMABLEDEFID");
            popup.GridColumns.AddTextBoxColumn("CONSUMABLEDEFNAME", 100);
            popup.GridColumns.AddTextBoxColumn("STOCKQTY", 100);

            // 검색조건
            popup.Conditions.AddTextBox("CONSUMABLEDEFIDNAME");
        }
        #endregion

        #region Event
        private void InitializeEvent()
        {
            this.Load += Popup_Load;
            grdMaterial.View.FocusedRowChanged += GrdMaterial_FocusedRowChanged;
            txtMaterialLot.KeyDown += TxtMaterialLot_KeyDown;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnAddUnTracked.Click += BtnAddUnTracked_Click;
            btnDeleteUnTracked.Click += BtnDeleteUnTracked_Click;
            btnSaveUnTracked.Click += BtnSaveUnTracked_Click;
            btnClose.Click += BtnClose_Click;
            grdUnTracking.View.RowCellStyle += GrdUnTracking_RowCellStyle;
            grdUnTracking.View.CellValueChanged += GrdUnTracking_CellValueChanged;
            grdBom.View.RowStyle += GrdBom_RowStyle;
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtMaterialLot;
            LoadWarehouseAndArea();
            LoadBomGrid();
            LoadMaterialGrid();
            LoadUnTrackingGrid();
        }

        // 창고 및 작업장 정보 조회
        private void LoadWarehouseAndArea()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LOTID", lotId);
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable dt = SqlExecuter.Query("GetAreaAndWarehouseOfLot", "00001", param);
            if(dt.Rows.Count > 0)
            {
                txtWarehouse.Text = dt.Rows[0]["WAREHOUSENAME"].ToString();
                txtArea.Text = dt.Rows[0]["AREANAME"].ToString();
            }
            else
            {
                txtWarehouse.Text = string.Empty;
                txtArea.Text = string.Empty;
            }
        }

        // BOM 조회
        private void LoadBomGrid()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LOTID", lotId);
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable dt = SqlExecuter.Query("GetMachiningBomInfoByLotId", "00001", param);
            grdBom.DataSource = dt;
        }

        // 투입자재 리스트 조회
        private void LoadMaterialGrid()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_LOTID", lotId);
            DataTable dt = SqlExecuter.Query("GetMachiningInsertMaterialInfo", "00001", param);
            grdMaterial.DataSource = dt;
        }

        private void LoadUnTrackingGrid()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LOTID", lotId);
            DataTable dt = SqlExecuter.Query("GetUnTrackingBom", "00001", param);
            grdUnTracking.DataSource = dt;
        }

        // 자재 LOT 그리드 선택ROW 변경
        private void GrdMaterial_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grdMaterial.View.FocusedRowHandle < 0)
            {
                return;
            }
            grdBom.View.FocusAndSelect("CONSUMABLEDEFID", grdMaterial.View.GetFocusedRowCellValue("CONSUMABLEDEFID").ToString());
        }

        // 자재 LOT 조회
        private void TxtMaterialLot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            string consumableLotId = txtMaterialLot.Text;

            var param = new Dictionary<string, object>()
            {
                { "CONSUMABLELOTID", consumableLotId }
                , { "LOTID", lotId }
                , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };
            DataTable material = SqlExecuter.Query("SearchMaterial", "00001", param);

            if (material.Rows.Count == 0)
            {
                // 시스템에 등록되지 않은 자재입니다. {0}
                throw MessageException.Create("ConsumableLotNotFound", consumableLotId);
            }
            if (material.Rows[0]["ISINBOM"].ToString() == "N")
            {
                // BOM 에 없는 자재입니다. 투입하시겠습니까? {0}
                if (MSGBox.Show(MessageBoxType.Question, "MaterialNotInBom", MessageBoxButtons.YesNo
                    , string.Format("ConsumableDefId={0}", material.Rows[0]["PARTNUMBER"].ToString())) != DialogResult.Yes)
                {
                    return;
                }
            }

            grdBom.View.FocusAndSelect("CONSUMABLEDEFID", material.Rows[0]["PARTNUMBER"].ToString());
            if (material.Rows[0]["ISSERIAL"].ToString() == "Y")
            {
                txtSerialNumber.ReadOnly = false;
            }
            else
            {
                txtSerialNumber.ReadOnly = true;
            }
            UpdateInputMaterialInfo(material);
        }

        // 사용자 입력 자재LOT 결과 => TextBox출력
        private void UpdateInputMaterialInfo(DataTable dt)
        {
            txtMaterialCode.Text = dt.Rows[0]["PARTNUMBER"].ToString();
            txtMaterialName.Text = dt.Rows[0]["CONSUMABLEDEFNAME"].ToString();
            txtMaterialType.Text = dt.Rows[0]["CONSUMABLETYPE"].ToString();
            txtMaterialQty.Text = dt.Rows[0]["CONSUMABLELOTQTY"].ToString();
            txtGoodQty.Text = dt.Rows[0]["INPUTQTY"].ToString();
            txtBadQty.Text = "0";
            txtSerialNumber.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        // 추가 버튼
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string consumableLotId = txtMaterialLot.EditValue.ToString();          // 자재 LOT ID
            decimal goodQty = Format.GetDecimal(txtGoodQty.EditValue.ToString());        // 양품 수량
            decimal badQty = Format.GetDecimal(txtBadQty.EditValue.ToString());          // 불량품 수량
            string serialNo = txtSerialNumber.Text;

            DataTable materials = new DataTable();
            materials.Columns.Add("CONSUMABLELOTID");
            materials.Columns.Add("GOODQTY");
            materials.Columns.Add("BADQTY");
            materials.Columns.Add("SERIALNO");
            materials.Columns.Add("COMMENT");

            DataRow row = materials.NewRow();
            row["CONSUMABLELOTID"] = consumableLotId;
            row["GOODQTY"] = goodQty;
            row["BADQTY"] = badQty;
            row["SERIALNO"] = serialNo;
            row["COMMENT"] = txtDescription.Text;

            materials.Rows.Add(row);

            MessageWorker messageWorker = new MessageWorker("InputMaterial");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", lotId }
                , { "isoverwrite", "N" }
                , { "isallowinputuntracked", "N" }
                , { "materials", materials }
            });
            messageWorker.Execute();
            LoadBomGrid();
            LoadMaterialGrid();
            grdBom.View.FocusAndSelect("CONSUMABLEDEFID", txtMaterialCode.Text);

            ClearMaterialInfo();
            grdMaterial.View.FocusAndSelect("MATERIALLOTID", consumableLotId);
            this.ActiveControl = txtMaterialLot;
        }

        // 자재정보 클리어
        private void ClearMaterialInfo()
        {
            txtMaterialCode.Text = string.Empty;
            txtMaterialName.Text = string.Empty;
            txtMaterialType.Text = string.Empty;
            txtMaterialQty.Text = string.Empty;
            txtGoodQty.Text = string.Empty;
            txtBadQty.Text = string.Empty;
            txtSerialNumber.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtMaterialLot.Text = string.Empty;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DataRow materialRow = grdMaterial.View.GetFocusedDataRow();
            if (materialRow == null)
            {
                return;
            }

            DataTable materials = new DataTable();
            materials.Columns.Add("CONSUMABLELOTID");

            DataRow row = materials.NewRow();
            row["CONSUMABLELOTID"] = materialRow["MATERIALLOTID"].ToString();

            materials.Rows.Add(row);

            MessageWorker messageWorker = new MessageWorker("CancelInputMaterial");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", lotId },
                { "materials", materials }
            });
            messageWorker.Execute();
            LoadBomGrid();
            LoadMaterialGrid();
            this.ActiveControl = txtMaterialLot;
        }

        private void BtnAddUnTracked_Click(object sender, EventArgs e)
        {
            // 2022-02-7 자재투입시 팝업그리드창 통해서 일괄추가 기능 
            // 사용안함 
            //List<GridTextAddColumn> grdColumns = new List<GridTextAddColumn>();

            //grdColumns.Add(new GridTextAddColumn("CONSUMABLETYPE", 65));
            //grdColumns.Add(new GridTextAddColumn("PARTNUMBER", 155, "CONSUMABLEDEFID"));
            //grdColumns.Add(new GridTextAddColumn("CONSUMABLEDEFNAME", 100));
            //grdColumns.Add(new GridTextAddColumn("STOCKQTY", 100));

            //Dictionary<string, object> _parameters = new Dictionary<string, object>();
            //_parameters.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            //_parameters.Add("LOTID", this.lotId);

            //SelectedGridPopup popup = new SelectedGridPopup(_parameters, "GetConsumableDefListPopupWithStock", "00001",  true, "SELECTCONSUMABLEDEFLIST", grdColumns
            //                , "CONSUMABLEDEFIDNAME", "CONSUMABLEDEFIDNAME", true);

            //if (popup.ShowDialog() == DialogResult.OK)
            //{
            //    foreach (DataRow row in popup.selectedRows)
            //    {
            //        grdUnTracking.View.AddNewRow();
            //        DataRow focusedRow = grdUnTracking.View.GetFocusedDataRow();
            //        focusedRow["PARTNUMBER"] = row["PARTNUMBER"];
            //        focusedRow["CONSUMABLEDEFID"] = row["CONSUMABLEDEFID"];
            //        focusedRow["CONSUMABLEDEFNAME"] = row["CONSUMABLEDEFNAME"];
            //        focusedRow["UNIT"] = row["UNIT"];
            //        focusedRow["NEEDQTY"] = 0;
            //        focusedRow["STOCKQTY"] = row["STOCKQTY"];
            //        focusedRow["ORG_STOCKQTY"] = row["STOCKQTY"];
            //        focusedRow["GOODQTY"] = 0;
            //        focusedRow["BADQTY"] = 0;
            //        focusedRow["ORG_GOODQTY"] = 0;
            //        focusedRow["ORG_BADQTY"] = 0;
            //        focusedRow["ISINBOM"] = "N";
            //    }
            //}

            grdUnTracking.View.AddNewRow();

        }

        private void BtnDeleteUnTracked_Click(object sender, EventArgs e)
        {
            DataRow row = grdUnTracking.View.GetFocusedDataRow();
            if (row == null || row["ISINBOM"].ToString() == "Y")
            {
                return;
            }
            grdUnTracking.View.RemoveRow(grdUnTracking.View.FocusedRowHandle);
        }

        private void BtnSaveUnTracked_Click(object sender, EventArgs e)
        {
            grdUnTracking.View.PostEditor();
            grdUnTracking.View.UpdateCurrentRow();

            MessageWorker messageWorker = new MessageWorker("InputUnTrackingMaterial");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", lotId }
                , { "materials", grdUnTracking.DataSource as DataTable }
            });
            messageWorker.Execute();
            ShowMessage("ResponseCompletion");

            LoadUnTrackingGrid();
        }

        // 닫기 버튼
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // 비추적 자재 그리드 입력가능 컬럼 색상변경
        private void GrdUnTracking_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                return;
            }
            GridView view = sender as GridView;
            if (e.Column.FieldName == "GOODQTY" || e.Column.FieldName == "BADQTY" || e.Column.FieldName == "COMMENT")
            {
                if (Format.GetDecimal(view.GetRowCellValue(e.RowHandle, "STOCKQTY").ToString()) < 0)
                {
                    e.Appearance.BackColor = System.Drawing.Color.Orange;
                    e.Appearance.ForeColor = System.Drawing.Color.Black;
                }
                else if (Format.GetDecimal(view.GetRowCellValue(e.RowHandle, "GOODQTY").ToString())
                    < Format.GetDecimal(view.GetRowCellValue(e.RowHandle, "BOMQTY").ToString()))
                {
                    e.Appearance.BackColor = System.Drawing.Color.PaleVioletRed;
                    e.Appearance.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                    e.Appearance.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void GrdUnTracking_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "GOODQTY" && e.Column.FieldName != "BADQTY")
            {
                return;
            }
            GridView view = sender as GridView;
            DataRow row = view.GetDataRow(e.RowHandle);
            row["NEEDQTY"] = Format.GetDecimal(row["BOMQTY"].ToString()) - Format.GetDecimal(row["GOODQTY"].ToString());
            row["STOCKQTY"] = Format.GetDecimal(row["ORG_STOCKQTY"]) - 
                ((Format.GetDecimal(row["GOODQTY"]) + Format.GetDecimal(row["BADQTY"]))
                    - (Format.GetDecimal(row["ORG_GOODQTY"]) + Format.GetDecimal(row["ORG_BADQTY"])));
        }

        // 투입수량이 부족하면 다른색으로 표시
        private void GrdBom_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                return;
            }
            GridView view = sender as GridView;
            if (Format.GetDecimal(view.GetRowCellValue(e.RowHandle, "INPUTQTY").ToString())
                < Format.GetDecimal(view.GetRowCellValue(e.RowHandle, "NEEDQTY").ToString()))
            {
                e.Appearance.BackColor = System.Drawing.Color.PaleVioletRed;
                e.Appearance.ForeColor = System.Drawing.Color.Black;
                e.HighPriority = true;
            }
        }
        #endregion
    }
}