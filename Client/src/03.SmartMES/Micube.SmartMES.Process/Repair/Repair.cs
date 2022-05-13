#region using
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace Micube.SmartMES.Process
{
    public partial class Repair : SmartConditionBaseForm
    {
        // 상수
        private const string TOOLBAR_CREATELOT = "CreateLOT";               // LOT 생성
        private const string TOOLBAR_INPUTMATERIAL = "InputMaterial";       // 자재투입
        private const string TOOLBAR_RESULTSAVE = "ResultSave";             // 실적저장
        private const string TOOLBAR_FINISHREPORT = "FinishedReport";       // 완료보고
        private const string TOOLBAR_CANCELCREATELOT = "CancelCreateLot";   // LOT 취소

        private string lastSelectedWorkorder = null;

        //작업완료 시 작업시간 수정여부 체크 변수
        private string checkEditYn = "Y";

        public Repair()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeWorkorderGrid();
            InitializeUserGrid();
            InitializeMaterialGrid();
            InitializeEvent();

            chkLabel.Checked = true;
        }

        private string ReturnYn() 
        {
            string workTimeYn = "Y";
            
            //공통코드 내 SystemOption 작업종료시간수동입력여부에 따라 화면구성 달라짐.
            DataTable dt = new SqlQuery("GetManualInputYn", "00001", $"CODECLASSID=SystemOption", $"CODEID=WorkTimeManualInputRepair").Execute();
            if (dt.Rows[0]["YNVALUE"].ToString() == "N")
            {
                workTimeYn = "N";
            }
           
            return workTimeYn;
        }

        private void InitializeWorkorderGrid()
        {
            grdWorkorder.GridButtonItem = GridButtonItem.Export;
            grdWorkorder.View.SetIsReadOnly();
            grdWorkorder.View.AddTextBoxColumn("WORKORDERID", 140);                     // 작업지시 번호
            grdWorkorder.View.AddTextBoxColumn("WORKORDERDATE", 120)    
                .SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd"); // 지시일자
            grdWorkorder.View.AddTextBoxColumn("LOTID", 110);                           // Lot No.
            grdWorkorder.View.AddTextBoxColumn("LOTSTATE", 80);                         // LOT 상태
            grdWorkorder.View.AddTextBoxColumn("PROCESSDEFNAME", 70)
                .SetTextAlignment(TextAlignment.Center);                                // 공정
            grdWorkorder.View.AddTextBoxColumn("PRODUCTDEFID", 150).SetIsHidden();      // 품목코드
            grdWorkorder.View.AddTextBoxColumn("PARTNUMBER", 150);                      // 품번
            grdWorkorder.View.AddTextBoxColumn("PRODUCTDEFNAME", 170);                  // 품목명
            grdWorkorder.View.AddTextBoxColumn("MODEL", 130);                           // 기종
            grdWorkorder.View.AddTextBoxColumn("VENDOR", 100);                          // 고객사
            grdWorkorder.View.AddTextBoxColumn("TEAMNAME", 100);                        // 팀
            grdWorkorder.View.AddTextBoxColumn("WORKTIME", 80).SetIsHidden();           // 작업시간
            grdWorkorder.View.AddTextBoxColumn("LEADTIME", 80);                         // 리드타임
            grdWorkorder.View.AddTextBoxColumn("PLANENDTIME", 120)
                .SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd"); // 완료예정시간
            grdWorkorder.View.AddTextBoxColumn("STATE", 80).SetLabel("WORKORDERSTATE")
                .SetTextAlignment(TextAlignment.Center);                                // 진행상태
            grdWorkorder.View.AddTextBoxColumn("VALIDSTATE", 120)
                .SetTextAlignment(TextAlignment.Center);                                // 유효상태
            grdWorkorder.View.AddTextBoxColumn("DESCRIPTION", 200);                     // 비고
            grdWorkorder.View.AddTextBoxColumn("LOTCREATEDTIME", 120).SetIsHidden();    //LOT 생성시간
            grdWorkorder.View.PopulateColumns();
        }

        private void InitializeUserGrid()
        {
            grdUser.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdUser.View.SetIsReadOnly();
            grdUser.GridButtonItem = GridButtonItem.None;
            grdUser.View.AddTextBoxColumn("USERID");                                    // 사용자 ID
            grdUser.View.AddTextBoxColumn("USERNAME");                                  // 사용자 이름
            grdUser.View.PopulateColumns();
        }

        private void InitializeMaterialGrid()
        {
            grdMaterial.GridButtonItem = GridButtonItem.None;
            grdMaterial.View.SetIsReadOnly();
            grdMaterial.View.AddTextBoxColumn("CONSUMABLETYPE", 80);                    // 자재구분
            grdMaterial.View.AddTextBoxColumn("CONSUMABLEDEFID", 100).SetIsHidden();    // 자재코드
            grdMaterial.View.AddTextBoxColumn("PARTNUMBER", 100);                       // 품번
            grdMaterial.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 220);                // 자재명
            grdMaterial.View.AddTextBoxColumn("MATERIALLOTID", 100);                    // 자재 LOT
            grdMaterial.View.AddTextBoxColumn("QTY", 60);                               // 투입수량
            grdMaterial.View.AddTextBoxColumn("UNIT", 60);                              // 단위
            grdMaterial.View.AddTextBoxColumn("DESCRIPTION", 190).SetLabel("COMMENT");  // 특이사항
            grdMaterial.View.PopulateColumns();
        }

        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            base.OnToolbarClick(sender, e);
            SmartButton btn = sender as SmartButton;
            switch(btn.Name)
            {
                case TOOLBAR_CREATELOT:
                    CreateLot();
                    break;
                case TOOLBAR_INPUTMATERIAL:
                    InputMaterial();
                    break;
                case TOOLBAR_RESULTSAVE:
                    SaveResult();
                    break;
                case TOOLBAR_FINISHREPORT:
                    FinishReport();
                    break;
                case TOOLBAR_CANCELCREATELOT:
                    CancelCreateLot();
                    break;
            }
        }

        private void CreateLot()
        {
            DataRow woRow = grdWorkorder.View.GetFocusedDataRow();
            if(woRow == null)
            {
                // 선택된 작업지시가 없습니다.
                throw MessageException.Create("WorkorderNotSelected");
            }
            string processSegmentId = string.Empty;
            string lotCreateRuleId = string.Empty;
            // 개조 공정이면 공정선택 팝업 표시
            if (woRow["PROCESSDEFID"].ToString() == "RT0006")
            {
                Repair_CreateLot_Popup popup = new Repair_CreateLot_Popup();
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    processSegmentId = popup.ProcessSegmentId;
                    lotCreateRuleId = popup.LotCreateRuleId;
                }
                else
                {
                    return;
                }
            }
            MessageWorker messageWorker = new MessageWorker("CreateRepairLot");
            messageWorker.SetBody(new MessageBody()
            {
                { "workorderid", woRow["WORKORDERID"] }
                , { "processsegmentid", processSegmentId }
                , { "lotcreateruleid", lotCreateRuleId }
            });
            var saveResult = messageWorker.Execute<DataTable>();
            DataTable resultData = saveResult.GetResultSet();

            // 라벨 인쇄
            if (chkLabel.Checked)
            {
                foreach (DataRow each in resultData.Rows)
                {
                    Commons.CommonFunction.PrintRepairLabel(each["LOTID"].ToString());
                }
            }
            lastSelectedWorkorder = woRow["WORKORDERID"].ToString();
            SearchWorkorderAsync();
        }

        private void InputMaterial()
        {
            DataRow woRow = grdWorkorder.View.GetFocusedDataRow();
            if (woRow == null)
            {
                // 선택된 작업지시가 없습니다.
                throw MessageException.Create("WorkorderNotSelected");
            }
            if(woRow["LOTID"] == DBNull.Value || string.IsNullOrEmpty(woRow["LOTID"].ToString()))
            {
                // 선택된 LOT이 없습니다.
                throw MessageException.Create("LotNotSelected");
            }
            popup_inputmaterial popup = new popup_inputmaterial(woRow["LOTID"].ToString());
            if(popup.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                RefreshMaterialGrid();
            }
        }

        private void SaveResult()
        {
            string trackOutTime = null;
            string editWorkTimeYn = ReturnYn();

            //화면 로드 시 가져온 작업시간 수정여부 체크 값과 작업완료 시 가져온 작업시간 수정여부 값이 다르면
            //메시지 뿌리기
            if (!checkEditYn.Equals(editWorkTimeYn)) 
            {
                //작업시간 수동입력기능이 관리자에 의해 거부되었습니다. 본 화면을 다시 열어주세요.
                ShowMessage("WorkTimeOptionChange");
                return;
            }

            DataRow woRow = grdWorkorder.View.GetFocusedDataRow();
            if (woRow == null)
            {
                // 선택된 작업지시가 없습니다.
                throw MessageException.Create("WorkorderNotSelected");
            }
            if (woRow["LOTID"] == DBNull.Value || string.IsNullOrEmpty(woRow["LOTID"].ToString()))
            {
                // LOT이 생성되지 않은 작업지시 입니다.
                throw MessageException.Create("WorkorderWithoutLot");
            }

            //2021-05-20 정송은 추가
            //작업완료시 workTimeYn이 N이면 getDate()
            if (editWorkTimeYn.Equals("Y"))
            {
   
                decimal dWorkTime = spnWorkTime.Value;

                //작업시간이 null이거나 없으면
                if (dWorkTime <= 0)
                {
                    trackOutTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else 
                {
                    //작업시간 입력한 데이터 있으면 시작일시 + 작업시간 계산 한 값이 종료시간
                    DateTime dt = dtpTrackInTime.Value;
                    string getWorkTimeVal = spnWorkTime.Value.ToString();
                    double dVal = double.Parse(getWorkTimeVal);
                    dt = dt.AddHours(dVal);

                    trackOutTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            else 
            {
                trackOutTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }


            MessageWorker messageWorker = new MessageWorker("TrackInOutRepair");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", woRow["LOTID"] },
                { "userids", GetUserIds() },
                { "trackintime", dtpTrackInTime.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                //{ "trackouttime", dtpTrackOutTime.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                { "trackouttime", trackOutTime },
                { "worktime", spnWorkTime.Value },
                { "comment", memDescription.Text }
            });
            messageWorker.Execute();
            lastSelectedWorkorder = woRow["WORKORDERID"].ToString();
            SearchWorkorderAsync();
            ShowMessage("ResponseCompletion");
        }

        private void FinishReport()
        {
            DataRow woRow = grdWorkorder.View.GetFocusedDataRow();
            if (woRow == null)
            {
                // 선택된 작업지시가 없습니다.
                throw MessageException.Create("WorkorderNotSelected");
            }
            if (woRow["LOTID"] == DBNull.Value || string.IsNullOrEmpty(woRow["LOTID"].ToString()))
            {
                // LOT이 생성되지 않은 작업지시 입니다.
                throw MessageException.Create("WorkorderWithoutLot");
            }
            // 완료보고를 하시겠습니까?
            if (MSGBox.Show(MessageBoxType.Question, "DoYouWantToFinishLot", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            MessageWorker messageWorker = new MessageWorker("DispatchRepair");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", woRow["LOTID"] }
            });
            messageWorker.Execute();
            lastSelectedWorkorder = woRow["WORKORDERID"].ToString();
            SearchWorkorderAsync();
            ShowMessage("ResponseCompletion");
        }

        private string GetUserIds()
        {
            DataTable checkedUsers = grdUser.View.GetCheckedRows();
            List<string> userList = new List<string>();
            foreach(DataRow each in checkedUsers.Rows)
            {
                userList.Add(each["USERID"].ToString());
            }
            return string.Join(",", userList.ToArray<string>());
        }

        private void CancelCreateLot()
        {
            DataRow woRow = grdWorkorder.View.GetFocusedDataRow();
            if (woRow == null)
            {
                // 선택된 작업지시가 없습니다.
                throw MessageException.Create("WorkorderNotSelected");
            }
            if (woRow["LOTID"] == DBNull.Value || string.IsNullOrEmpty(woRow["LOTID"].ToString()))
            {
                // LOT이 생성되지 않은 작업지시 입니다.
                throw MessageException.Create("WorkorderWithoutLot");
            }
            CommonFunction.LotCancelPopup(woRow["LOTID"].ToString());
            lastSelectedWorkorder = woRow["WORKORDERID"].ToString();
            SearchWorkorderAsync();
        }

        #region Search
        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();
            SearchWorkorderAsync();
        }

        private async void SearchWorkorderAsync()
        {
            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable dtWorkorder = await QueryAsync("GetRepairWorkorder", "00001", values);
            if (dtWorkorder.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }
            grdWorkorder.DataSource = dtWorkorder;
            if(lastSelectedWorkorder != null)
            {
                grdWorkorder.View.FocusAndSelect("WORKORDERID", lastSelectedWorkorder);
                lastSelectedWorkorder = null;
            }
            RefreshMaterialGrid();
            RefreshWorkInfo();
            RefreshUserGrid();
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

        #region Event
        private void InitializeEvent()
        {
            grdWorkorder.View.FocusedRowChanged += View_FocusedRowChanged;
            dtpTrackInTime.ValueChanged += DtpTrackInTime_ValueChanged;
            dtpTrackOutTime.ValueChanged += DtpTrackInTime_ValueChanged;

            //작업시간 수정여부 체크
            checkEditYn = ReturnYn();
        }



        private void DtpTrackInTime_ValueChanged(object sender, EventArgs e)
        {
            spnLeadTime.Value = Math.Round((dtpTrackOutTime.Value - dtpTrackInTime.Value).TotalMinutes / 60, 2).ToDecimal();
            spnWorkTime.Value = Math.Round((dtpTrackOutTime.Value - dtpTrackInTime.Value).TotalMinutes / 60, 2).ToDecimal();
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RefreshMaterialGrid();
            RefreshWorkInfo();
            RefreshUserGrid();
        }

        private void RefreshMaterialGrid()
        {
            DataRow row = grdWorkorder.View.GetFocusedDataRow();
            if (row == null || row["LOTID"] == null || string.IsNullOrEmpty(row["LOTID"].ToString()))
            {
                grdMaterial.View.ClearDatas();
                return;
            }
            var param = new Dictionary<string, object>()
            {
                { "LOTID", row["LOTID"] }
                , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };
            grdMaterial.DataSource = SqlExecuter.Query("GetMaterialList", "00001", param);
        }

        private void RefreshUserGrid()
        {
            DataRow row = grdWorkorder.View.GetFocusedDataRow();
            if (row == null)
            {
                grdUser.View.ClearDatas();
                return;
            }
            string lotId = string.Empty;
            if (row != null && row["LOTID"] != DBNull.Value)
            {
                lotId = row["LOTID"].ToString();
            }
            // 완료보고가 안되었으면
            if (row["LOTSTATECODE"] == DBNull.Value || row["LOTSTATECODE"].ToString() == "InProduction")
            {
                var param = new Dictionary<string, object>()
                {
                    { "P_AREAID", row["AREAID"].ToString() }
                    , { "LOTID", lotId }
                };
                // 작업장별 작업자
                grdUser.DataSource = SqlExecuter.Query("ProceeResultUserList", "00002", param);
                SetCheckGrdUser();
            }
            else // 완료보고 되었으면
            {
                var param = new Dictionary<string, object>()
                {
                    { "LOTID", lotId }
                };
                // 수리 작업자
                grdUser.DataSource = SqlExecuter.Query("GetRepairUser", "00001", param);
            }
        }

        private void SetCheckGrdUser()
        {
            DataTable user = grdUser.DataSource as DataTable;
            for (int i = 0; i < user.Rows.Count; i++)
            {
                if (user.Rows[i]["ISCHECKED"].ToString() == "Y")
                {
                    grdUser.View.CheckRow(grdUser.View.GetRowHandle(i), true);
                }
            }
        }

        private void RefreshWorkInfo()
        {
            //시작일시, 종료일시 enabled false 처리
            dtpTrackInTime.Enabled = false;
            dtpTrackOutTime.Enabled = false;

            DataRow row = grdWorkorder.View.GetFocusedDataRow();
            if (row == null || row["WORKSTARTTIME"] == DBNull.Value || string.IsNullOrEmpty(row["WORKSTARTTIME"].ToString()))  // 작업완료 전
            {
               
                //LOT 생성 후 면 CREATEDTIME으로 시작시간 바인딩
                if (row == null || string.IsNullOrEmpty(row["LOTCREATEDTIME"].ToString()))
                {
                    //null 이면 현재시간으로
                    dtpTrackInTime.Value = DateTime.Now;
                }
                else 
                {
                    //null아니면 LOT 생성된 시간으로
                    dtpTrackInTime.Value = DateTime.Parse(row["LOTCREATEDTIME"].ToString());

                }
              
                dtpTrackOutTime.Value = DateTime.Now;
                spnLeadTime.Value = 0;
                spnWorkTime.Value = 0;
                memDescription.Text = "";

                //2021-05-20 정송은 주석처리
                //dtpTrackInTime.Enabled = true;
                //dtpTrackOutTime.Enabled = true;
                memDescription.ReadOnly = false;

                string editWorkTimeYn = ReturnYn();

                //작업여부Y/N에 따라 작업시간 readonly 처리
                if (editWorkTimeYn.Equals("Y"))
                {
                    spnWorkTime.ReadOnly = false;
                }
                else 
                {
                    spnWorkTime.ReadOnly = true;
                }
                
                grdUser.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
                grdUser.View.PopulateColumns();
            }
            else if(row["LOTSTATECODE"] != DBNull.Value && row["LOTSTATECODE"].ToString() == "InProduction") // 작업완료 후 완료보고 전
            {
                //dtpTrackInTime.Value = DateTime.Parse(row["WORKSTARTTIME"].ToString());
                //2021-05-20 정송은 trackinTime lot createdtime으로 보여지도록 수정
                dtpTrackInTime.Value = DateTime.Parse(row["LOTCREATEDTIME"].ToString());

                dtpTrackOutTime.Value = DateTime.Parse(row["WORKENDTIME"].ToString());
                spnLeadTime.Value = Math.Round((dtpTrackOutTime.Value - dtpTrackInTime.Value).TotalMinutes / 60, 2).ToDecimal();
                spnWorkTime.Value = decimal.Parse(row["WORKTIME"].ToString());
                memDescription.Text = row["COMMENTS"].ToString();

                //2021-05-20 정송은 주석처리
                //dtpTrackInTime.Enabled = true;
                //dtpTrackOutTime.Enabled = true;
                
                memDescription.ReadOnly = false;

                string editWorkTimeYn = ReturnYn();

                //작업여부Y/N에 따라 작업시간 readonly 처리
                if (editWorkTimeYn.Equals("Y"))
                {
                    spnWorkTime.ReadOnly = false;
                }
                else 
                {
                    spnWorkTime.ReadOnly = true;
                }

                
                grdUser.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
                grdUser.View.PopulateColumns();
            }
            else // 완료보고 후
            {
                dtpTrackInTime.Value = DateTime.Parse(row["WORKSTARTTIME"].ToString());
                dtpTrackOutTime.Value = DateTime.Parse(row["WORKENDTIME"].ToString());
                spnLeadTime.Value = Math.Round((dtpTrackOutTime.Value - dtpTrackInTime.Value).TotalMinutes / 60, 2).ToDecimal();
                spnWorkTime.Value = decimal.Parse(row["WORKTIME"].ToString());
                memDescription.Text = row["COMMENTS"].ToString();

                dtpTrackInTime.Enabled = false;
                dtpTrackOutTime.Enabled = false;
                memDescription.ReadOnly = true;
                spnWorkTime.ReadOnly = true;
                grdUser.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
                grdUser.View.PopulateColumns();
            }
        }
        #endregion
    }
}
