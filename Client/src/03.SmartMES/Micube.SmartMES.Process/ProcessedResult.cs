#region using
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Micube.SmartMES.Commons;
using System.Windows.Forms;
#endregion

namespace Micube.SmartMES.Process
{    /// <summary>
     /// 프 로 그 램 명  : 공정관리 > 공정등록 > 가공
     /// 업  무  설  명  : 공정관리 - 가공
     /// 생    성    자  : jylee
     /// 생    성    일  : 2019-05-20
     /// 수  정  이  력  : 
     /// </summary>
    public partial class ProcessedResult : SmartConditionBaseForm
    {
        public ProcessedResult()
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
            InitializeGrid();
            InitializeEvent();
        }

        private void InitializeGrid()
        {
            InitializeWorkOrderGrid();
            InitializeLotGrid();
            InitializeEquipGrid();
            InitializeMaterialGrid();
        }

        /// <summary>        
        /// 그리드를 초기화한다.
        /// </summary>
        private void InitializeWorkOrderGrid()
        {
            grdWorkorder.GridButtonItem = GridButtonItem.Export;
            grdWorkorder.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdWorkorder.View.AddTextBoxColumn("WORKORDERID", 150).SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();	                                                                            // 작업지시번호
            grdWorkorder.View.AddTextBoxColumn("WORKORDERDATE", 90).SetDisplayFormat("yyyy-MM-dd").SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center); 														// 작업지시일
            grdWorkorder.View.AddTextBoxColumn("PARTNUMBER", 150).SetIsReadOnly();							// 품목번호
            grdWorkorder.View.AddTextBoxColumn("PRODUCTDEFNAME", 250).SetIsReadOnly(); 							// 품목명
            grdWorkorder.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 150).SetIsReadOnly(); 						// 공정명
            grdWorkorder.View.AddTextBoxColumn("AREANAME", 100);                                                // 작업장명
            grdWorkorder.View.AddTextBoxColumn("ORDERQTY", 80).SetDisplayFormat("#,##0").SetIsReadOnly(); 		// 지시수량
            grdWorkorder.View.AddTextBoxColumn("RESULTQTY", 80).SetDisplayFormat("#,##0").SetIsReadOnly(); 		// 실적수량
            grdWorkorder.View.AddTextBoxColumn("LOTSIZE", 80).SetDisplayFormat("#,##0"); 						// LOT Size
            grdWorkorder.View.AddTextBoxColumn("PLANENDTIME", 90).SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center).SetIsReadOnly(); 										// 완료예정일
            grdWorkorder.View.AddTextBoxColumn("STATE", 90).SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly(); 			                                                                    // 진행상태
            grdWorkorder.View.AddTextBoxColumn("DESCRIPTION", 120).SetIsReadOnly(); 							// 비고
            grdWorkorder.View.AddTextBoxColumn("VALIDSTATE", 120).SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center); 							                            // 유효상태
            grdWorkorder.View.PopulateColumns();
        }

        private void InitializeLotGrid()
        {
            grdLot.GridButtonItem = GridButtonItem.Export;
            grdLot.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdLot.View.AddTextBoxColumn("LOTID", 100).SetTextAlignment(TextAlignment.Center).SetIsReadOnly(); 		// LOT번호
            grdLot.View.AddTextBoxColumn("CREATEDQTY", 65); 												        // 생성수량
            grdLot.View.AddTextBoxColumn("QTY", 65); 												                // 수량
            grdLot.View.AddTextBoxColumn("TRACKINTIME", 140).SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss").SetTextAlignment(TextAlignment.Center); 	                // 시작일시
            grdLot.View.AddTextBoxColumn("TRACKOUTTIME", 140).SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss").SetTextAlignment(TextAlignment.Center).SetIsReadOnly(); 	// 종료일시
            grdLot.View.AddTextBoxColumn("WORKTIME", 65).SetIsReadOnly(); 											// 작업시간
            grdLot.View.AddTextBoxColumn("COUNT", 65).SetIsReadOnly(); 												// 횟수
            grdLot.View.PopulateColumns();
        }

        private void InitializeEquipGrid()
        {
            grdEquip.GridButtonItem = GridButtonItem.Export;
            grdEquip.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdEquip.View.SetIsReadOnly();
            grdEquip.View.AddTextBoxColumn("EQUIPMENTID", 100); 									// 설비ID
            grdEquip.View.AddTextBoxColumn("EQUIPMENTNAME", 150); 									// 설비명
            grdEquip.View.AddTextBoxColumn("WORKER", 80).SetTextAlignment(TextAlignment.Center); 	// 작업자
            grdEquip.View.AddTextBoxColumn("TRACKINTIME", 150)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss").SetTextAlignment(TextAlignment.Center); 	// 시작일시
            grdEquip.View.AddTextBoxColumn("TRACKOUTTIME", 150)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss").SetTextAlignment(TextAlignment.Center); 	// 종료일시
            grdEquip.View.AddTextBoxColumn("WORKTIME", 80); 										// 작업시간
            grdEquip.View.PopulateColumns();
        }

        private void InitializeMaterialGrid()
        {
            grdMaterial.GridButtonItem = GridButtonItem.Export;
            grdMaterial.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdMaterial.View.SetIsReadOnly();
            grdMaterial.View.AddTextBoxColumn("PARTNUMBER", 150).SetLabel("CONSUMABLEDEFID"); 					// 자재ID
            grdMaterial.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 260); 				// 자재명
            grdMaterial.View.AddTextBoxColumn("MATERIALLOTID", 100); 					// 자재LOT
            grdMaterial.View.AddTextBoxColumn("SERIALNO", 100); 						// SERIAL번호
            grdMaterial.View.AddTextBoxColumn("GOODQTY", 50); 							// 양품
            grdMaterial.View.AddTextBoxColumn("BADQTY", 50); 							// 불량품
            grdMaterial.View.AddTextBoxColumn("DESCRIPTION", 100).SetLabel("COMMENT"); 	// 특이사항
            grdMaterial.View.AddTextBoxColumn("CUSTOMERNAME", 120).SetLabel("VENDOR");  // 자재거래처

            grdMaterial.View.PopulateColumns();
        }
        #endregion

        #region Search
        //// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();
            SearchWorkOrder();
        }
        #endregion

        #region Event
        public void InitializeEvent()
        {
            this.Load += processResult_Load;
            grdWorkorder.View.FocusedRowChanged += GrdWorkorder_FocusedRowChanged;
            grdLot.View.FocusedRowChanged += GrdLot_FocusedRowChanged;
            btnWorkStart.Click += btnWorkStart_Click;
            btnWorkEnd.Click += btnWorkEnd_Click;
            btnCreateLot.Click += btnCreateLot_Click;
            btnCancelCreateLot.Click += BtnCancelCreateLot_Click;
            btnInputMaterial.Click += btnInputMaterial_Click;
            btnFinish.Click += btnFinish_Click;
            grdLot.View.RowCellStyle += GrdLot_RowCellStyle;
            grdLot.View.ShowingEditor += View_ShowingEditor;
            grdWorkorder.View.RowCellStyle += GrdWorkorder_RowCellStyle;
        }

        private void processResult_Load(object sender, EventArgs e)
        {
            SearchWorkOrder(true);
        }

        private void SearchWorkOrder(bool supressMessage = false)
        {
            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable dt = SqlExecuter.Query("GetProcessedWorkOrderList", "00001", values);
            if (dt.Rows.Count < 1 && !supressMessage)
            {
                ShowMessage("NoSelectData");
            }
            grdWorkorder.DataSource = dt;
            LotGridDataLoad();
            EquipmentGridDataLoad();
            MaterialGridDataLoad();
        }

        // 작업시작 버튼 클릭
        private void btnWorkStart_Click(object sender, EventArgs e)
        {
            if (grdLot.View.FocusedRowHandle < 0)
            {
                // 선택된 LOT이 없습니다.
                throw MessageException.Create("LotNotSelected");
            }
            grdLot.View.PostEditor();
            grdLot.View.UpdateCurrentRow();
            DataRow woRow = this.grdWorkorder.View.GetFocusedDataRow();
            DataRow lotRow = this.grdLot.View.GetFocusedDataRow();
            string lotId = lotRow["LOTID"].ToString();
            decimal qty = Format.GetDecimal(lotRow["QTY"].ToString());
            StartProcessPopup popup = new StartProcessPopup(lotId, woRow["AREAID"].ToString(), qty);
            popup.ShowDialog(this);
            LotGridDataLoad();
            EquipmentGridDataLoad();
            MaterialGridDataLoad();
        }

        // 작업종료 버튼
        private void btnWorkEnd_Click(object sender, EventArgs e)
        {
            if (grdLot.View.FocusedRowHandle < 0)
            {
                // 선택된 LOT이 없습니다.
                throw MessageException.Create("LotNotSelected");
            }
            grdLot.View.PostEditor();
            grdLot.View.UpdateCurrentRow();
            DataRow row = this.grdLot.View.GetFocusedDataRow();
            string lotId = row["LOTID"].ToString();
            decimal qty = Format.GetDecimal(row["QTY"].ToString());
            MessageWorker messageWorker = new MessageWorker("SubTrackOutMachining");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", lotId }
                , { "qty", qty }
            });
            messageWorker.Execute();
            EquipmentGridDataLoad();
            MaterialGridDataLoad();
        }

        // Lot생성 버튼 클릭
        private void btnCreateLot_Click(object sender, EventArgs e)
        {
            if (grdWorkorder.View.FocusedRowHandle < 0)
            {
                // 선택된 작업지시가 없습니다.
                throw MessageException.Create("WorkorderNotSelected");
            }
            grdWorkorder.View.PostEditor();
            grdWorkorder.View.UpdateCurrentRow();
            DataRow workOrderData = grdWorkorder.View.GetFocusedDataRow();
            string workorderId = workOrderData["WORKORDERID"].ToString();
            string lotSize = workOrderData["LOTSIZE"].ToString();
            if (lotSize == "")
            {
                // LOT SIZE가 등록되지 않았습니다.
                throw MessageException.Create("LotSizeNotRegistered");
            }
            MessageWorker messageWorker = new MessageWorker("CreateMachiningLot");
            messageWorker.SetBody(new MessageBody()
            {
                { "workorderid", workorderId }
                , { "createqty", Format.GetDecimal(lotSize) }
            });
            var saveResult = messageWorker.Execute<DataTable>();
            DataTable resultData = saveResult.GetResultSet();
            LotGridDataLoad();
        }

        // LOT 취소버튼 클릭
        private void BtnCancelCreateLot_Click(object sender, EventArgs e)
        {
            if (grdLot.View.FocusedRowHandle < 0)
            {
                // 선택된 LOT이 없습니다.
                throw MessageException.Create("LotNotSelected");
            }
            grdLot.View.PostEditor();
            grdLot.View.UpdateCurrentRow();
            DataRow row = this.grdLot.View.GetFocusedDataRow();
            CommonFunction.LotCancelPopup(row["LOTID"].ToString());
            LotGridDataLoad();
            MaterialGridDataLoad();
        }

        // 자재투입 버튼 클릭
        private void btnInputMaterial_Click(object sender, EventArgs e)
        {
            DataRow workorderRow = this.grdWorkorder.View.GetFocusedDataRow();
            if (workorderRow == null)
            {
                // 선택된 작업지시가 없습니다.
                throw MessageException.Create("WorkorderNotSelected");
            }
            DataRow lotRow = this.grdLot.View.GetFocusedDataRow();
            if (lotRow == null)
            {
                // 선택된 LOT이 없습니다.
                throw MessageException.Create("LotNotSelected");
            }
            string workorderId = workorderRow["WORKORDERID"].ToString();
            string lotId = lotRow["LOTID"].ToString();
            InsertMaterialPopup popup = new InsertMaterialPopup(lotId, workorderId, true);
            popup.ShowDialog(this);
            MaterialGridDataLoad();
        }

        // 완료보고 버튼 클릭
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (grdLot.View.FocusedRowHandle < 0)
            {
                // 선택된 LOT이 없습니다.
                throw MessageException.Create("LotNotSelected");
            }
            grdLot.View.PostEditor();
            grdLot.View.UpdateCurrentRow();
            DataRow row = this.grdLot.View.GetFocusedDataRow();
            string lotId = row["LOTID"].ToString();
            decimal qty = Format.GetDecimal(row["QTY"].ToString());
            if (IsMaterialNotEnough(lotId))
            {
                // 자재가 부족합니다. 계속 진행하시겠습니까?
                if (MSGBox.Show(MessageBoxType.Question, "MaterialIsNotEnough", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            // 완료보고를 하시겠습니까?
            if (MSGBox.Show(MessageBoxType.Question, "DoYouWantToFinishLot", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            MessageWorker messageWorker = new MessageWorker("DispatchMachining");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", lotId }
                , { "qty", qty }
            });
            messageWorker.Execute();
            LotGridDataLoad();
            grdLot.View.FocusAndSelect("LOTID", lotId);
            EquipmentGridDataLoad();
            MaterialGridDataLoad();
            CommonFunction.PrintLotLabel(lotId);
        }

        // BOM 수량만큼 자재투입을 했는지 확인
        private bool IsMaterialNotEnough(string lotId)
        {
            return IsTrackingMaterialNotEnough(lotId) || IsUnTrackingMaterialNotEnough(lotId);
        }

        private bool IsTrackingMaterialNotEnough(string lotId)
        {
            var param = new Dictionary<string, object>()
            {
                { "LOTID", lotId }
            };
            DataTable dt = SqlExecuter.Query("GetIsMaterialEnough", "00001", param);
            return int.Parse(dt.Rows[0]["NOTENOUGH"].ToString()) > 0;
        }

        private bool IsUnTrackingMaterialNotEnough(string lotId)
        {
            var param = new Dictionary<string, object>()
            {
                { "LOTID", lotId }
            };
            DataTable dt = SqlExecuter.Query("GetIsUnTrackingMaterialEnough", "00001", param);
            return int.Parse(dt.Rows[0]["NOTENOUGH"].ToString()) > 0;
        }

        private void GrdWorkorder_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LotGridDataLoad();
            EquipmentGridDataLoad();
            MaterialGridDataLoad();
        }

        private void GrdLot_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EquipmentGridDataLoad();
            MaterialGridDataLoad();
        }

        // 작업지시 선택 => 해당 Lot정보
        private void LotGridDataLoad()
        {
            if(grdWorkorder.View.FocusedRowHandle < 0)
            {
                grdLot.View.ClearDatas();
                grdEquip.View.ClearDatas();
                grdMaterial.View.ClearDatas();
                return;
            }
            var row = grdWorkorder.View.GetDataRow(grdWorkorder.View.FocusedRowHandle);
            if (row == null)
            {
                return;
            }
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("WORKORDERID", row["WORKORDERID"].ToString());
            grdEquip.View.ClearDatas();
            grdMaterial.View.ClearDatas();
            grdLot.DataSource = SqlExecuter.Query("GetProcessMachiningLot", "00001", param);
        }

        // LOT정보 선택 => 해당 설비정보
        private void EquipmentGridDataLoad()
        {
            if (grdLot.View.FocusedRowHandle < 0)
            {
                grdEquip.View.ClearDatas();
                grdMaterial.View.ClearDatas();
                return;
            }
            var row = grdLot.View.GetDataRow(grdLot.View.FocusedRowHandle);
            if (row == null)
            {
                return;
            }
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_LOTID", row["LOTID"].ToString());
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            grdEquip.DataSource = SqlExecuter.Query("GetProcessMachiningEquipment", "00001", param);
        }

        // 설비정보 선택 => 해당 투입자재
        private void MaterialGridDataLoad()
        {
            if (grdLot.View.FocusedRowHandle < 0)
            {
                grdEquip.View.ClearDatas();
                grdMaterial.View.ClearDatas();
                return;
            }
            var row = grdLot.View.GetDataRow(grdLot.View.FocusedRowHandle);
            if (row == null)
            {
                return;
            }
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_LOTID", row["LOTID"].ToString());
            param.Add("DBLINKNAME", CommonFunction.DbLinkName);

            if (row["TRACKOUTTIME"] == DBNull.Value || string.IsNullOrEmpty(row["TRACKOUTTIME"].ToString()))
            {
                // 작업완료되지 않은 LOT의 자재는 가투입 내역 조회
                grdMaterial.DataSource = SqlExecuter.Query("GetMachiningInsertMaterialInfo", "00003", param);
            }
            else
            {
                // 작업완료된 LOT의 자재는 실투입 내역 조회
                grdMaterial.DataSource = SqlExecuter.Query("GetMachiningInsertMaterialInfo", "00002", param);
            }
        }

        // 입력 가능컬럼 색상변경
        private void GrdLot_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if ((grdLot.View.GetRowCellValue(e.RowHandle, "TRACKOUTTIME") == DBNull.Value
                    || string.IsNullOrEmpty(grdLot.View.GetRowCellValue(e.RowHandle, "TRACKOUTTIME").ToString()))
                && e.Column.FieldName == "QTY")
            {
                e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                e.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }

        // 작업 완료된 LOT의 수량컬럼 읽기전용 처리
        private void View_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var row = grdLot.View.GetDataRow(grdLot.View.FocusedRowHandle);
            if (row == null)
            {
                return;
            }
            if (row["TRACKOUTTIME"] != DBNull.Value && !string.IsNullOrEmpty(row["TRACKOUTTIME"].ToString()))
            {
                e.Cancel = true;
            }
        }

        // 입력가능 셀 색상 변경
        private void GrdWorkorder_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if(e.Column.FieldName == "LOTSIZE")
            {
                e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                e.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion
    }
}
