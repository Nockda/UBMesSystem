using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Micube.SmartMES.Commons;
using Micube.Framework;
using Micube.Framework.Net;
using System.Windows.Forms;

namespace Micube.SmartMES.Production
{
    public partial class WorkOrderWithLotCreate : SmartConditionBaseForm
    {
        string WORK_ORDER_ID = string.Empty;
        string LOTID_TO_FOCUS = string.Empty;

        public WorkOrderWithLotCreate()
        {
            InitializeComponent();
            //NPOI.OpenXml4Net.Util.XmlHelper.
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeGrid();

            InitializeEvent();

            grdPoPlanList.GridButtonItem = GridButtonItem.Export;
            smartGroupBox1.GridButtonItem = GridButtonItem.None;

            chkLabel.Checked = true;

            SmartButton btnCreateLotAll = GetToolbarButtonById("CreateLotAll");
            btnCreateLotAll.SendToBack();
            btnCreateLotAll.Width = 110;
        }

        protected override void InitializeCondition()
        {
            base.InitializeCondition();
            CommonFunction.AddConditionProductPopup("P_PRODUCTDEFID", 1.1, false, Conditions, "PARTNUMBER");
     //       InitializeConditionPopup_ProcessSegmentId();
        }

        private void InitializeGrid()
        {
            #region 작업 지시 그리드
            grdPoPlanList.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdPoPlanList.View.SetIsReadOnly();
            grdPoPlanList.View.AddTextBoxColumn("PLANENDTIME", 110).SetLabel("EXPECTWORKDAY").SetDisplayFormat("yyyy-MM-dd").SetTextAlignment(TextAlignment.Center);
            grdPoPlanList.View.AddTextBoxColumn("WORKORDERID", 140).SetValidationIsRequired();
            grdPoPlanList.View.AddTextBoxColumn("PRODUCTDEFID", 100).SetIsHidden();
            grdPoPlanList.View.AddTextBoxColumn("PARTNUMBER", 100).SetLabel("PRODUCTDEFID");
            grdPoPlanList.View.AddTextBoxColumn("PRODUCTDEFNAME", 150);
            grdPoPlanList.View.AddTextBoxColumn("PRODUCTDEFTYPE", 80);
            grdPoPlanList.View.AddTextBoxColumn("STANDARD", 80).SetLabel("SPECIFICATION");
            grdPoPlanList.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 120);
            grdPoPlanList.View.AddTextBoxColumn("AREANAME", 120);
            grdPoPlanList.View.AddTextBoxColumn("TEAMNAME", 80);
            grdPoPlanList.View.AddSpinEditColumn("PLANQTY", 60);
            grdPoPlanList.View.AddSpinEditColumn("ORDERQTY", 60);
            grdPoPlanList.View.AddSpinEditColumn("PROCESSQTY", 60);
            grdPoPlanList.View.AddSpinEditColumn("NOTPROCESSQTY", 60);
            grdPoPlanList.View.AddSpinEditColumn("LOTSIZE", 80);
            grdPoPlanList.View.AddTextBoxColumn("STATE", 60);
            grdPoPlanList.View.AddTextBoxColumn("ISHOLD", 60);
            grdPoPlanList.View.AddTextBoxColumn("PRODUCTIONORDERID", 100);
            grdPoPlanList.View.AddTextBoxColumn("DEPARTMENTNAME", 100).SetLabel("PRODUCTDEPT");
            grdPoPlanList.View.AddTextBoxColumn("UNIT", 50);
            grdPoPlanList.View.AddTextBoxColumn("VALIDSTATE", 120).SetTextAlignment(TextAlignment.Center);

            grdPoPlanList.View.AddTextBoxColumn("CHECKQTY", 120).SetIsHidden();
            grdPoPlanList.View.AddTextBoxColumn("PROCESSDEFID", 120).SetIsHidden();
            grdPoPlanList.View.AddTextBoxColumn("PROCESSCLASSID", 120).SetIsHidden();
            grdPoPlanList.View.AddTextBoxColumn("PROCESSSEGMENTID", 120).SetIsHidden();
            grdPoPlanList.View.AddTextBoxColumn("ISUSEUSERLOTSERIAL", 120).SetIsHidden();
            grdPoPlanList.View.AddTextBoxColumn("USERLOTSERIAL", 120).SetIsHidden();
            grdPoPlanList.View.AddTextBoxColumn("PROCESSSEGMENTCLASSID", 120).SetIsHidden();
            grdPoPlanList.View.PopulateColumns();
            #endregion

            #region
            grdLotList.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdLotList.View.OptionsSelection.MultiSelect = true;
            grdLotList.View.SetIsReadOnly();
            grdLotList.View.AddTextBoxColumn("LOTID", 100);
            grdLotList.View.AddTextBoxColumn("PRODUCTDEFID", 100).SetIsHidden();
            grdLotList.View.AddTextBoxColumn("PARTNUMBER", 100).SetLabel("PRODUCTDEFID");
            grdLotList.View.AddTextBoxColumn("PRODUCTDEFNAME", 150);
            grdLotList.View.AddTextBoxColumn("PROCESSSEGMENTID", 80);
            grdLotList.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 120);
            grdPoPlanList.View.AddSpinEditColumn("CREATEDQTY", 60).SetLabel("QTY");
            grdLotList.View.AddTextBoxColumn("LOTSTATE", 70);
            grdLotList.View.AddTextBoxColumn("PROCESSSTATE", 70);
            grdLotList.View.AddSpinEditColumn("QTY", 70);
            grdLotList.View.AddButtonColumn("PRINTLABEL", 70);

            grdLotList.View.PopulateColumns();
            #endregion
        }
        public void InitializeEvent()
        {
            grdPoPlanList.View.FocusedRowChanged += View_FocusedRowChanged;
           // btnCreateLot.Click += BtnCreateLot_Click;
            grdPoPlanList.View.RowCellClick += grdPoPlanList_RowCellClick;
            grdLotList.View.RowCellClick += grdLotList_RowCellClick;
        }

        private void grdLotList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(e.Column.FieldName == "PRINTLABEL")
            {
                string lotId = grdLotList.View.GetRowCellValue(e.RowHandle, "LOTID").ToString();
                CommonFunction.PrintLotLabel(lotId);
            }
        }

        private void grdPoPlanList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ShowWorkorderInfo(grdPoPlanList.View.FocusedRowHandle);
        }

        private void ShowWorkorderInfo(int rowhandle)
        {
            if (rowhandle < 0) return;

            DataRow dr = grdPoPlanList.View.GetFocusedDataRow();

            string isUserDefine = Format.GetTrimString(dr["ISUSEUSERLOTSERIAL"]);
            string userLot = Format.GetTrimString(dr["USERLOTSERIAL"]);
            string lotSize = Format.GetTrimString(dr["LOTSIZE"]);

            if (isUserDefine.Equals("Y") )
            {
                txtUserDefine.Properties.ReadOnly = false;
                txtUserDefine.EditValue = string.Empty;
            }
            else
            {
                txtUserDefine.Properties.ReadOnly = true;
                txtUserDefine.EditValue = string.Empty;
            }

            if(lotSize.Equals("1"))
            {
                txtInputQty.Properties.ReadOnly = true;
            }
            else
            {
                txtInputQty.Properties.ReadOnly = false;
            }

           // WorkOrderID = Format.GetTrimString(dr["WORKORDERID"]);

            txtWorkOrder.Text = Format.GetTrimString(dr["WORKORDERID"]);
            txtProduct.Text = Format.GetTrimString(dr["PRODUCTDEFNAME"]);
            txtOrderQty.Text = Format.GetTrimString(dr["ORDERQTY"]);
            txtProcessQty.Text = Format.GetTrimString(dr["PROCESSQTY"]);
            txtInputQty.Editor.Value = Format.GetInteger(dr["LOTSIZE"]);
            
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("WORKORDERID", Format.GetTrimString(dr["WORKORDERID"]));
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dt = SqlExecuter.Query("SelectLotListByWorkOrder", "00001", param);

            grdLotList.DataSource = dt;

            if (!string.IsNullOrEmpty(LOTID_TO_FOCUS))
            {
                grdLotList.View.FocusAndSelect("LOTID", LOTID_TO_FOCUS);
                if (string.IsNullOrEmpty(WORK_ORDER_ID))
                {
                    LOTID_TO_FOCUS = string.Empty;
                }
            }
        }

        private void BtnCreateLot_Click(object sender, EventArgs e)
        {

        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ShowWorkorderInfo(grdPoPlanList.View.FocusedRowHandle);
        }

        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            clearControl();

            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            if(values.ContainsKey("P_WORKORDERNUM"))
            {
                string workorder = Format.GetTrimString(values["P_WORKORDERNUM"]);
                values.Remove("P_WORKORDERNUM");
                values.Add("P_WORKORDERNUM", workorder);
            }

            DataTable dt = null;

            dt = await QueryAsyncDirect("SelectWorkOrderList", "00001", values);

            if (dt.Rows.Count < 1)
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdPoPlanList.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                string workorderId = WORK_ORDER_ID;
                WORK_ORDER_ID = string.Empty;
                grdPoPlanList.View.FocusAndSelect("WORKORDERID", workorderId);
            }

            if (grdPoPlanList.View.FocusedRowHandle >= 0)
            {
                ShowWorkorderInfo(grdPoPlanList.View.FocusedRowHandle);
            }
        }

        private void clearControl()
        {
            grdLotList.DataSource = null;
            grdPoPlanList.DataSource = null;
            txtInputQty.Editor.Text = string.Empty;
            txtOrderQty.Editor.Text = string.Empty;
            txtWorkOrder.Editor.Text = string.Empty;
            txtProduct.Editor.Text = string.Empty;
        }
        #region 공정 조회조건 팝업 초기화
        /// <summary>
        /// ProcessDefId 선택하는 팝업
        /// </summary>
        private void InitializeConditionPopup_ProcessSegmentId()
        {
            // 팝업 컬럼 설정
            var processDefPopup = Conditions.AddSelectPopup("P_PROCESSSEGMENTID", new SqlQuery("GetProcessSegmentList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
                                        .SetPopupLayout("PROCESSSEGMENTLIST", PopupButtonStyles.Ok_Cancel, true, false)
                                        .SetPopupLayoutForm(600, 500)
                                        .SetPopupResultCount(1)
                                        .SetPosition(3.1)
                                        .SetLabel("PROCESSSEGMENTID")
                                        .SetPopupAutoFillColumns("PROCESSSEGMENTNAME");

            // 팝업 조회조건
            processDefPopup.Conditions.AddTextBox("P_PROCESSSEGMENTTXT")
                       .SetLabel("PROCESSSEGMENTIDNAME");

            // 팝업 그리드
            processDefPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150);
            //processDefPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTVERSION", 150);
            processDefPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);
        }
        #endregion

        #region ToolBar
        /// <summary>
        /// LOT생성 버튼 클릭
        /// </summary>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;

            if (btn.Name.ToString().Equals("CreateLOT"))
            {
                createLot();
            }
            else if(btn.Name.ToString().Equals("CancelCreateLot"))
            {
                CancelCreateLot();
            }
            else if(btn.Name.ToString().Equals("CreateLotAll"))
            {
                CreateLotAll();
            }
        }

        /// <summary>
        /// [생성수량]/[LOTSIZE] 선택 팝업 추가.
        /// '22.05.03 scmo
        /// </summary>
        /// <param name="dr"></param>
        private void ShowCreateCountPopup(DataRow dr)
        {

        }

        /// <summary>
        /// LOT일괄생성 툴바 추가. 
        /// '22.05.03 scmo
        /// 팝업을 통해 [생성수량]/[LOTSIZE] 만큼 LOT을 일괄생성한다.
        /// 단, 품목정보의 작업장이 'MBS-C조립'(AR-11)인 제품만 가능할 것!
        /// </summary>
        private void CreateLotAll()
        {
            if (grdPoPlanList.View.FocusedRowHandle < 0)
            {
                throw MessageException.Create("선택된 작업지시가 없습니다.");
            }

            DataRow dr = grdPoPlanList.View.GetFocusedDataRow();

            string state = Format.GetTrimString(dr["STATE"]);
            string checkQty = Format.GetTrimString(dr["CHECKQTY"]);
            string inputQty = Format.GetTrimString(txtInputQty.EditValue);
            string ProcessDefid = Format.GetTrimString(dr["PROCESSDEFID"]);
            string ProcessClassid = Format.GetTrimString(dr["PROCESSCLASSID"]);
            string lotSize = Format.GetTrimString(dr["LOTSIZE"]);
            string workOrderid = Format.GetTrimString(dr["WORKORDERID"]);
            string processSegmentid = Format.GetTrimString(dr["PROCESSSEGMENTID"]);
            string productdefid = Format.GetTrimString(dr["PRODUCTDEFID"]);
            string isUserDefine = Format.GetTrimString(dr["ISUSEUSERLOTSERIAL"]);
            string processSegmentClassid = Format.GetTrimString(dr["PROCESSSEGMENTCLASSID"]);
            string workOderQty = Format.GetTrimString(dr["ORDERQTY"]);
            string processQty = Format.GetTrimString(dr["PROCESSQTY"]);
            string isHold = Format.GetTrimString(dr["ISHOLD"]);
            string userDefineLot = Format.GetTrimString(txtUserDefine.EditValue);
            string areaId = Format.GetTrimString(dr["AREAID"]);

            if (processSegmentid.Equals("SGM009"))
            {
                userDefineLot = userDefineLot.PadLeft(2, '0');
            }
            if (state.Equals("Close"))
            {
                throw MessageException.Create("CheckWorkOrderState"); //해당 작업지시는 완료 되었습니다
            }
            if (state.Equals("Cancel"))
            {
                throw MessageException.Create("CheckWorkOrderStateCancel"); //해당 작업지시는 취소 되었습니다
            }
            if (string.IsNullOrEmpty(ProcessDefid))
            {
                throw MessageException.Create("NotExistRoutingByProduct"); //해당 품목에 라우팅이 매핑되어 있지 않습니다
            }
            //if (!ProcessClassid.Equals("RTC001"))
            if (!processSegmentClassid.Equals("SGC00002"))
            {
                throw MessageException.Create("CheckProcessAssembly"); //조립 공정만 Lot 생성 가능 합니다.
            }
            if (inputQty.Equals("0") || string.IsNullOrEmpty(inputQty))
            {
                throw MessageException.Create("CheckInputQty"); //투입수량이 입력 되지 않았습니다
            }
            if (lotSize.Equals("0") || string.IsNullOrEmpty(lotSize))
            {
                throw MessageException.Create("CheckLotSizeByProduct"); //해당 품목에 Lot Size가 등록 되어 있지 않습니다.
            }
            if (string.IsNullOrEmpty(processSegmentid))
            {
                throw MessageException.Create("NoneMappingRouting"); //해당 품목에 라우팅이 매핑 되지 않았습니다.
            }
            if (isUserDefine.Equals("Y") && (string.IsNullOrEmpty(userDefineLot) || userDefineLot.Equals("00")))
            {
                throw MessageException.Create("사용자 정의 Lot을 입력해주세요"); //사용자 정의 Lot을 입력해주세요
            }
            //CheckInputLotSize

            if (Format.GetInteger(inputQty) > Format.GetInteger(lotSize))
            {
                throw MessageException.Create("CheckInputLotSize", lotSize, inputQty);
            }
            if (Format.GetInteger(inputQty) + Format.GetInteger(processQty) > Format.GetInteger(workOderQty))
            {
                throw MessageException.Create("OverWorkOrderQty");
            }
            if (isHold.Equals("Y"))
            {
                throw MessageException.Create("HoldWorOrder"); //보류 중입니다.
            }
            if (!areaId.Equals("AR-11"))
            {
                throw MessageException.Create("AreaIsNotMBSC"); //MBS-C조립 작업장의 품목이 아닙니다.
            }

            CreateLotAllPopup popup = new CreateLotAllPopup(dr);
            popup.ShowDialog();
            if(popup.DialogResult == DialogResult.OK)
            {
                MessageWorker messageWorker = new MessageWorker("SaveCreateLotAll");
                messageWorker.SetBody(new MessageBody()
                {
                    { "EnterpriseId", UserInfo.Current.Enterprise },
                    { "PlantId", UserInfo.Current.Plant },
                    { "Worker", UserInfo.Current.Id },
                    { "ProcessSegmentid", processSegmentid },
                    { "ProductDefid", productdefid },
                    { "InputQty", inputQty },
                    { "UserLot", userDefineLot },
                    { "WorkOrderid", workOrderid },
                    { "createCount", popup._createCount}
                });

                var saveResult = messageWorker.Execute<DataTable>();
                DataTable resultData = saveResult.GetResultSet();

                ShowMessage("ProcessingSuccess");

                WORK_ORDER_ID = workOrderid;

                // 라벨 인쇄
                if (chkLabel.Checked && resultData.Rows.Count > 0)
                {
                    for (int i = 0; i < resultData.Rows.Count; i++)
                    {
                        string lotId = resultData.Rows[i]["LOTID"].ToString();
                        CommonFunction.PrintLotLabel(lotId);
                    }
                }
            }
        }

        private void CancelCreateLot()
        {
            DataRow dr = grdLotList.View.GetFocusedDataRow();
            if (dr == null)
            {
                return;
            }
            DataRow woRow = grdPoPlanList.View.GetFocusedDataRow();
            if (woRow != null)
            {
                WORK_ORDER_ID = woRow["WORKORDERID"].ToString();
            }
            CommonFunction.LotCancelPopup(Format.GetFullTrimString(dr["LOTID"]));
#pragma warning disable CS4014 // 이 호출을 대기하지 않으므로 호출이 완료되기 전에 현재 메서드가 계속 실행됩니다.
            OnSearchAsync();
#pragma warning restore CS4014 // 이 호출을 대기하지 않으므로 호출이 완료되기 전에 현재 메서드가 계속 실행됩니다.
        }

        private void createLot()
        {
            //FileStream stream = File.Open(@"D:\TEST1.xlsx", FileMode.Open, FileAccess.Read);

            if (grdPoPlanList.View.FocusedRowHandle < 0)
            {
                throw MessageException.Create("선택된 작업지시가 없습니다.");
            }

            DataRow dr = grdPoPlanList.View.GetFocusedDataRow();

            string state = Format.GetTrimString(dr["STATE"]);
            string checkQty = Format.GetTrimString(dr["CHECKQTY"]);
            string inputQty = Format.GetTrimString(txtInputQty.EditValue);
            string ProcessDefid = Format.GetTrimString(dr["PROCESSDEFID"]);
            string ProcessClassid = Format.GetTrimString(dr["PROCESSCLASSID"]);
            string lotSize = Format.GetTrimString(dr["LOTSIZE"]);
            string workOrderid = Format.GetTrimString(dr["WORKORDERID"]);
            string processSegmentid = Format.GetTrimString(dr["PROCESSSEGMENTID"]);
            string productdefid = Format.GetTrimString(dr["PRODUCTDEFID"]);
            string isUserDefine = Format.GetTrimString(dr["ISUSEUSERLOTSERIAL"]);
            string processSegmentClassid = Format.GetTrimString(dr["PROCESSSEGMENTCLASSID"]);
            string workOderQty = Format.GetTrimString(dr["ORDERQTY"]);
            string processQty = Format.GetTrimString(dr["PROCESSQTY"]);
            string isHold = Format.GetTrimString(dr["ISHOLD"]);

            string userDefineLot = Format.GetTrimString(txtUserDefine.EditValue);

            if (processSegmentid.Equals("SGM009"))
            {
                userDefineLot = userDefineLot.PadLeft(2, '0');
            }
            if (state.Equals("Close"))
            {
                throw MessageException.Create("CheckWorkOrderState"); //해당 작업지시는 완료 되었습니다
            }
            if (state.Equals("Cancel"))
            {
                throw MessageException.Create("CheckWorkOrderStateCancel"); //해당 작업지시는 취소 되었습니다
            }
            if (string.IsNullOrEmpty(ProcessDefid))
            {
                throw MessageException.Create("NotExistRoutingByProduct"); //해당 품목에 라우팅이 매핑되어 있지 않습니다
            }
            //if (!ProcessClassid.Equals("RTC001"))
            if (!processSegmentClassid.Equals("SGC00002"))
            {
                throw MessageException.Create("CheckProcessAssembly"); //조립 공정만 Lot 생성 가능 합니다.
            }
            if (inputQty.Equals("0") || string.IsNullOrEmpty(inputQty))
            {
                throw MessageException.Create("CheckInputQty"); //투입수량이 입력 되지 않았습니다
            }
            if (lotSize.Equals("0") || string.IsNullOrEmpty(lotSize))
            {
                throw MessageException.Create("CheckLotSizeByProduct"); //해당 품목에 Lot Size가 등록 되어 있지 않습니다.
            }
            if (string.IsNullOrEmpty(processSegmentid))
            {
                throw MessageException.Create("NoneMappingRouting"); //해당 품목에 라우팅이 매핑 되지 않았습니다.
            }
            if (isUserDefine.Equals("Y") && (string.IsNullOrEmpty(userDefineLot) || userDefineLot.Equals("00")))
            {
                throw MessageException.Create("사용자 정의 Lot을 입력해주세요"); //사용자 정의 Lot을 입력해주세요
            }
            //CheckInputLotSize

            if (Format.GetInteger(inputQty) > Format.GetInteger(lotSize))
            {
                throw MessageException.Create("CheckInputLotSize", lotSize, inputQty);
            }
            if (Format.GetInteger(inputQty) + Format.GetInteger(processQty) > Format.GetInteger(workOderQty))
            {
                throw MessageException.Create("OverWorkOrderQty");
            }
            if (isHold.Equals("Y"))
            {
                throw MessageException.Create("HoldWorOrder"); //보류 중입니다.
            }

            MessageWorker messageWorker = new MessageWorker("SaveCreateLot");
            messageWorker.SetBody(new MessageBody()
            {
                { "EnterpriseId", UserInfo.Current.Enterprise },
                { "PlantId", UserInfo.Current.Plant },
                { "Worker", UserInfo.Current.Id },
                { "ProcessSegmentid", processSegmentid },
                { "ProductDefid", productdefid },
                { "InputQty", inputQty },
                { "UserLot", userDefineLot },
                { "WorkOrderid", workOrderid },
            });

            var saveResult = messageWorker.Execute<DataTable>();
            DataTable resultData = saveResult.GetResultSet();

            ShowMessage("ProcessingSuccess");

            WORK_ORDER_ID = workOrderid;
            if (resultData.Rows.Count > 0)
            {
                LOTID_TO_FOCUS = resultData.Rows[0]["LOTID"].ToString();
            }

#pragma warning disable CS4014 // 이 호출을 대기하지 않으므로 호출이 완료되기 전에 현재 메서드가 계속 실행됩니다.
            OnSearchAsync();
#pragma warning restore CS4014 // 이 호출을 대기하지 않으므로 호출이 완료되기 전에 현재 메서드가 계속 실행됩니다.

            // 라벨 인쇄
            if (chkLabel.Checked && resultData.Rows.Count > 0)
            {
                string lotId = resultData.Rows[0]["LOTID"].ToString();
                CommonFunction.PrintLotLabel(lotId);
            }
        }

        #endregion
    }
}
