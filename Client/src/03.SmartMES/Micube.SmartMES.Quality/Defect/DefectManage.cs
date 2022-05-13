#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;
using Micube.SmartMES.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Quality
{
    /// <summary>
    /// 프 로 그 램 명  : 품질관리 > 불량관리 > 불량통지서 관리대장 현황
    /// 업  무  설  명  : 불량통지서 관리대장정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-11
    /// 수  정  이  력  : 2020-04-21 강유라
    ///                 : 2020-09-10 이준용 | AutoFill 제거
    ///                   2022-05-11 이종건 진행상태현황 COUNT 조회기간 적용
    /// 
    /// 
    /// </summary>
    public partial class DefectManage : SmartConditionBaseForm
    {

        #region Local Variables
        // TODO : 화면에서 사용할 내부 변수 추가
        DataTable codeDt = null;
        string Notpublished = "";
        string ResidualCase = "";
        string Unexported = "";

        DataTable stateCodeDt = null;
        string registration = "";
        string receipt = "";
        string sendNotice = "";
        string measuresCompleted = "";
        //조회현항 이름 저장
        string txtName = null;


        #endregion

        #region 생성자
        public DefectManage()
        {
            InitializeComponent();
        }
        #endregion

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeGrid();

            //툴바 사이즈 조정
            if (pnlToolbar.Controls["layoutToolbar"].Controls.ContainsKey("SendNotice"))
            {
                pnlToolbar.Controls["layoutToolbar"].Controls["SendNotice"].Width = 100;
            }
            //컨트롤 포맷
            SetFormatControl();

            //조회현황 텍스트 명 복사
            txtName = lblStatusTitle.Text;
        }

        #region 그리드 초기화
        /// <summary>        
        /// 불량 통지서 관리대장 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            // 그리드 초기화
            grdDefectManage.GridButtonItem = GridButtonItem.Export;
            grdDefectManage.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;

            grdDefectManage.View.SetSortOrder("DOCID");
            //grdDefectManage.View.SetAutoFillColumn("DEFECTDESC");

            grdDefectManage.View.AddTextBoxColumn("DOCID", 80).SetIsReadOnly();//발행번호
            grdDefectManage.View.AddTextBoxColumn("CLAIMNUMBER", 80).SetIsReadOnly();//Claim No
            grdDefectManage.View.AddTextBoxColumn("PUBLISHDATE", 80).SetIsReadOnly();//발행일자
            grdDefectManage.View.AddTextBoxColumn("PROGRESSSTATENAME", 80).SetLabel("PROGRESSSTATE").SetIsReadOnly();//진행상태
            grdDefectManage.View.AddComboBoxColumn("DEPARTMENTID", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCodeQc", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetIsReadOnly();//발견부서
            grdDefectManage.View.AddTextBoxColumn("FINDNAME", 80).SetLabel("DEFECTDISCOVERER").SetIsReadOnly();//발견자
            grdDefectManage.View.AddTextBoxColumn("DETECTNAME", 80).SetLabel("WRITER").SetIsReadOnly();//발견자->작성자로 수정
            grdDefectManage.View.AddTextBoxColumn("DEFECTDESC", 150).SetIsReadOnly();//불량내용
            grdDefectManage.View.AddTextBoxColumn("DEFECTITEMNAME", 180).SetIsReadOnly();//불량품명
            grdDefectManage.View.AddTextBoxColumn("CUSTOMERNAME", 100).SetLabel("VENDORNAME2").SetIsReadOnly();//업체코드(명)
            grdDefectManage.View.AddTextBoxColumn("DRAWINGNUMBER", 100).SetIsReadOnly();//도면번호
            grdDefectManage.View.AddTextBoxColumn("DEFECTRATE", 50).SetIsReadOnly();//불량율
            grdDefectManage.View.AddTextBoxColumn("RECURRCNT", 80).SetIsReadOnly();//재발횟수
            grdDefectManage.View.AddComboBoxColumn("LARGECATEGORY", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=DefectLargeCategory", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));//대분류
            grdDefectManage.View.AddComboBoxColumn("SMALLCATEGROY", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=DefectSmallCategory", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));//소분류
            grdDefectManage.View.AddComboBoxColumn("ACTIONTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=DefectActionType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));//조치유형
            grdDefectManage.View.AddComboBoxColumn("COMPLETESTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=DefectCompleteState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));//대책진척현황
            grdDefectManage.View.AddTextBoxColumn("COMPLETEDAY", 80).SetIsReadOnly();//대책소요일
            grdDefectManage.View.AddTextBoxColumn("ACTIONDAY", 80).SetIsReadOnly();//대응처리일
            grdDefectManage.View.PopulateColumns();
        }
        #endregion

        #endregion

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            Load += (s, e) =>
            {
                //코드 다국어 적용을 위한 Dt
                GetCodeDictionary();
            };

            //그리드 선택 row 변경 이벤트
            grdDefectManage.View.FocusedRowChanged += View_FocusedRowChanged;
            grdDefectManage.View.RowClick += View_RowClick;
       
            //컨트롤 값 변경시 이벤트
            dteExportDate.Editor.EditValueChanging += Editor_EditValueChanging;
            memoReasonDesc.EditValueChanging += Editor_EditValueChanging;
            memoActionDesc.EditValueChanging += Editor_EditValueChanging;
            txtDescription.EditValueChanging += Editor_EditValueChanging;

            //행 readOnly 이벤트
            grdDefectManage.View.ShowingEditor += (s, e) =>
             {
                 DataRow row = grdDefectManage.View.GetFocusedDataRow();
                 if (row == null) return;

                 if (CheckcurrentStateToState(Format.GetString(row["PROGRESSSTATE"]),"NONE","NONE"))
                 {//현재 진행상태가 등록 취소인 경우
                     e.Cancel = true;
                 }
                 else if (HasUpdatedRow(row))
                 {//현재 row가 수정 상태가 아닌데, 수정 중인 행 존재 할경우 readOnly
                     e.Cancel = true;
                 }
             };

            //focusRow 색변경 이벤트
            grdDefectManage.View.RowStyle += View_RowStyle;

        }

        /// <summary>
        /// 포커스 받은 Row 색깔변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (grdDefectManage.View.FocusedRowHandle == e.RowHandle)
            {
                e.HighPriority = true;
                e.Appearance.BackColor = Color.Yellow;
            }
        }


        /// <summary>
        /// Row 클릭시 컨트롤에 값 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {  
            DataRow row = grdDefectManage.View.GetFocusedDataRow();
            BindingDataToContorl(row);
        }

        /// <summary>
        ///선택된 row변경되면 아래 컨트롤에 값 바인딩 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = grdDefectManage.View.GetFocusedDataRow();
            BindingDataToContorl(row);
        }

        /// <summary>
        /// 컨트롤의 값이 수정됐을때 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Editor_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataRow row = grdDefectManage.View.GetFocusedDataRow();
            if (row == null) return;
            if (HasUpdatedRow(row))
            {
                dteExportDate.Editor.EditValueChanging -= Editor_EditValueChanging;
                memoReasonDesc.EditValueChanging -= Editor_EditValueChanging;
                memoActionDesc.EditValueChanging -= Editor_EditValueChanging;
                txtDescription.EditValueChanging -= Editor_EditValueChanging;

                e.Cancel = true;

                dteExportDate.Editor.EditValueChanging += Editor_EditValueChanging;
                memoReasonDesc.EditValueChanging += Editor_EditValueChanging;
                memoActionDesc.EditValueChanging += Editor_EditValueChanging;
                txtDescription.EditValueChanging += Editor_EditValueChanging;
                return;
            }

            string columnId = "";
            string oldValue = "";
            string newValue = "";

            //dateControl
            if (sender is SmartDateEdit date)
            {
                columnId = "EXPORTDATE";
                oldValue = e.OldValue.ToString();
                newValue = e.NewValue.ToString().Substring(0, 10);
            }
            else if (sender is SmartMemoEdit mome)
            {
                columnId = mome.Tag.ToString();
                oldValue = e.OldValue.ToString();
                newValue = e.NewValue.ToString();
            }
            else if (sender is SmartTextBox txt)
            {
                columnId = txt.Tag.ToString();
                oldValue = e.OldValue.ToString();
                newValue = e.NewValue.ToString();
            }

            if (string.IsNullOrWhiteSpace(columnId))
                return;

            ChangedData(row, columnId, oldValue, newValue);
        }

        #endregion

        #region 툴바

        /// <summary>
        /// 툴바 버튼 기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;

            //접수 버튼 클릭
            if (btn.Name.ToString().Equals("Receipt"))
            {
                Btn_ReceiptClick(btn.Name.ToString(), btn.Text);
            }
            //통지서발송 버튼 클릭
            else if (btn.Name.ToString().Equals("SendNotice"))
            {
                Btn_SendNoticeClick(btn.Name.ToString(), btn.Text);
            }
            //대책 완료 버튼 클릭
            else if (btn.Name.ToString().Equals("MeasuresCompleted"))
            {
                Btn_MeasuresCompletedClick(btn.Name.ToString(), btn.Text);
            }
            //조치 완료 버튼 클릭
            else if (btn.Name.ToString().Equals("ActionCompleted"))
            {
                Btn_ActionCompletedClick(btn.Name.ToString(), btn.Text);
            }
            //진행 취소 버튼 클릭
            else if (btn.Name.ToString().Equals("CancelProgress"))
            {
                Btn_CancelProgressClick(btn.Name.ToString(), btn.Text);
            }
            //저장버튼 클릭
            else if (btn.Name.ToString().Equals("Save") || btn.Name.ToString().Equals("SaveBehind"))
            {
                Btn_SaveClick(btn.Text);
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

            // TODO : 조회 SP 변경
            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", Framework.UserInfo.Current.LanguageType);
            values.Add("DBLINKNAME", CommonFunction.DbLinkName);

            DataTable dt = await SqlExecuter.QueryAsync("SelectDefectRegistList", "00001", values);

            if (dt.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
                grdDefectManage.View.ClearDatas();
            }
            else
            {
                grdDefectManage.DataSource = dt;

                DataRow row = grdDefectManage.View.GetFocusedDataRow();
                BindingDataToContorl(row);

                //2020-06-26 강유라 진행상태 현황 조회 추가
                DataTable dtCount =  SqlExecuter.Query("SelectDefectProcessStateCount", "00001", values);
                DataRow countRow = dtCount.Rows[0];
                if (countRow == null) return;

                //2022-05-11 이종건 현황 조회기간 적용
                lblStatusTitle.Font = new Font(lblStatusTitle.Font.Name, 10);
                lblStatusTitle.Text = txtName + "\r\n" + Conditions.GetValues()["P_DATEPERIOD_PERIODFR"].ToString().Substring(0, 10) + " ~ " + Conditions.GetValues()["P_DATEPERIOD_PERIODTO"].ToString().Substring(0, 10);


                txtRegist.Text = Format.GetString(countRow["REGISTRATION"]);
                txtReceipt.Text = Format.GetString(countRow["RECEIPT"]);
                txtIssue.Text = Format.GetString(countRow["SENDNOTICE"]);
                txtComplete.Text = Format.GetString(countRow["ACTIONCOMPLETED"]);

            }
        }

        #region 조회조건 구성
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // TODO : 조회조건 추가 구성이 필요한 경우 사용
            InitializeConditionCustomerListPopup();
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            // TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
            DateTime today = DateTime.Now;
            Dictionary<string, object> defaultValue = new Dictionary<string, object>
            {
                {"P_DATEPERIOD_PERIODFR",today.AddDays(1- today.Day)},
                {"P_DATEPERIOD_PERIODTO",today}
            };
            this.Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD").SetValue(defaultValue);

        }

        /// <summary>
        /// 그리드 고객사 팝업
        /// </summary>
        private void InitializeConditionCustomerListPopup()
        {
            var customerPopup = Conditions.AddSelectPopup("P_VENDORCODE", new SqlQuery("GetCustomer", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"DBLINKNAME={CommonFunction.DbLinkName}"), "CUSTOMERNAME", "CUSTOMERID")
               .SetPopupLayout("CUSTOMER", PopupButtonStyles.Ok_Cancel, true, true)
               .SetPopupLayoutForm(800, 800)
               .SetLabel("CUSTOMER")
               .SetPopupResultCount(1)
               .SetPosition(2.1);

            // 검색조건
            customerPopup.Conditions.AddTextBox("CUSTOMERIDNAME");

            // 팝업의 그리드에 컬럼 추가
            customerPopup.GridColumns.AddTextBoxColumn("CUSTOMERID", 100);
            customerPopup.GridColumns.AddTextBoxColumn("CUSTOMERNAME", 150);
            customerPopup.GridColumns.AddTextBoxColumn("PHONE", 100);
            customerPopup.GridColumns.AddTextBoxColumn("ADDRESS", 250);
        }

        #endregion
        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            // TODO : 유효성 로직 변경
            grdDefectManage.View.CheckValidation();

            DataTable changed = grdDefectManage.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Public Function

        #endregion

        #region Private Function

        /// <summary>
        /// 접수 버튼 클릭
        /// </summary>
        /// <param name="toState"></param>
        /// <param name="toStateDic"></param>
        private void Btn_ReceiptClick(string toState, string toStateDic)
        {
            DataRow row = grdDefectManage.View.GetFocusedDataRow();
            if (row == null) return;

            string progressState = Format.GetString(row["PROGRESSSTATE"]);

            if (isChangedRow(row))
            {
                ShowMessage("NeedToSaveToChangeState");//저장 후 상태변경 가능 합니다.
                return;
            }

            //현재 상태와 변경하려는 상태 같을 경우 
            if (CheckcurrentStateToState(progressState, toState, toStateDic))
                return;

            //선행 상태 체크
            if (!isRightStateStep(progressState, "Registration", registration))
                return;        

            CallStateChangeRule(row, "InfoDefectReceipt", "Receipt");//불량품통지서를 접수 하시겠습니까? 
            
        }

        /// <summary>
        /// 통지서발송 버튼 클릭
        /// </summary>
        /// <param name="toState"></param>
        /// <param name="toStateDic"></param>
        private void Btn_SendNoticeClick(string toState, string toStateDic)
        {
            DataRow row = grdDefectManage.View.GetFocusedDataRow();
            if (row == null) return;

            string progressState = Format.GetString(row["PROGRESSSTATE"]);

            if (isChangedRow(row))
            {
                ShowMessage("NeedToSaveToChangeState");//저장 후 상태변경 가능 합니다.
                return;
            }

            //현재 상태와 변경하려는 상태 같을 경우 
            if (CheckcurrentStateToState(progressState, toState, toStateDic))
                return;

            //선행 상태 체크
            if (!isRightStateStep(progressState, "Receipt", receipt))
                return;
            
            CallStateChangeRule(row, "InfoDefectSendNotice", "SendNotice");//불량품통지서를 발송 하시겠습니까? 
            
        }

        /// <summary>
        /// 대책 완료 버튼 클릭
        /// </summary>
        /// <param name="toState"></param>
        /// <param name="toStateDic"></param>
        private void Btn_MeasuresCompletedClick(string toState, string toStateDic)
        {
            DataRow row = grdDefectManage.View.GetFocusedDataRow();
            if (row == null) return;

            string progressState = Format.GetString(row["PROGRESSSTATE"]);

            if (isChangedRow(row))
            {
                ShowMessage("NeedToSaveToChangeState");//저장 후 상태변경 가능 합니다.
                return;
            }

            //현재 상태와 변경하려는 상태 같을 경우 
            if (CheckcurrentStateToState(progressState, toState, toStateDic))
                return;

            //선행 상태 체크
            if (!isRightStateStep(progressState, "SendNotice", sendNotice))
                return;            

            if (string.IsNullOrWhiteSpace(Format.GetString(memoReasonDesc.Text)) || string.IsNullOrWhiteSpace(Format.GetString(memoActionDesc.Text)))
            {
                ShowMessage("NoInputReasonAction");//원인과 대책을 입력하세요.
                return;
            }

            CallStateChangeRule(row, "InfoDefectMeasuresCompleted", "MeasuresCompleted");//불량품통지서를 대책완료 하시겠습니까? 
            
        }

        /// <summary>
        /// 조치 완료 버튼 클릭
        /// </summary>
        /// <param name="toState"></param>
        /// <param name="toStateDic"></param>
        private void Btn_ActionCompletedClick(string toState, string toStateDic)
        {
            DataRow row = grdDefectManage.View.GetFocusedDataRow();
            if (row == null) return;

            string progressState = Format.GetString(row["PROGRESSSTATE"]);

            if (isChangedRow(row))
            {
                ShowMessage("NeedToSaveToChangeState");//저장 후 상태변경 가능 합니다.
                return;
            }

            //현재 상태와 변경하려는 상태 같을 경우 
            if (CheckcurrentStateToState(progressState, toState, toStateDic))
                return;

            //선행 상태 체크
            if (!isRightStateStep(progressState, "MeasuresCompleted", measuresCompleted))
                return;
            
            CallStateChangeRule(row, "InfoDefectActionCompleted", "ActionCompleted");//불량품통지서를 조치완료 하시겠습니까? 
            
        }

        /// <summary>
        /// 진행 취소 버튼 클릭
        /// </summary>
        /// <param name="toState"></param>
        /// <param name="toStateDic"></param>
        private void Btn_CancelProgressClick(string toState, string toStateDic)
        {
            DataRow row = grdDefectManage.View.GetFocusedDataRow();
            if (row == null) return;

            string progressState = Format.GetString(row["PROGRESSSTATE"]);

            if (isChangedRow(row))
            {
                ShowMessage("NeedToSaveToChangeState");//저장 후 상태변경 가능 합니다.
                return;
            }

            if (progressState.Equals("CancelRegistration") || progressState.Equals("MeasuresCompleted")
                || progressState.Equals("ActionCompleted"))
            {
                ShowMessage("CantChangeDefectStateToCancelProgress");//등록취소, 대책완료, 조치완료 상태에서는 진행 취소 할 수 없습니다.
                return;
            }

            //현재 상태와 변경하려는 상태 같을 경우 
            if (CheckcurrentStateToState(progressState, toState, toStateDic))
                return;

            CallStateChangeRule(row, "InfoDefectCancelProgress", "CancelProgress");//불량품통지서를 진행취소 하시겠습니까? 
            
        }

        /// <summary>
        /// 저장 함수
        /// </summary>
        /// <param name="strtitle"></param>
        private void Btn_SaveClick(string strtitle)
        {
            grdDefectManage.View.CloseEditor();
            grdDefectManage.View.CheckValidation();

            DataTable changed = grdDefectManage.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                this.ShowMessage(MessageBoxButtons.OK, "NoSaveData");
                return;
            }

            DialogResult result = System.Windows.Forms.DialogResult.No;

            result = this.ShowMessage(MessageBoxButtons.YesNo, "InfoSave", strtitle);//저장하시겠습니까? 

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    this.ShowWaitArea();

                    MessageWorker messageWorker = new MessageWorker("SaveDefectRegManagement");

                    messageWorker.SetBody(new MessageBody()
                    {
                        { "list", changed }
     
                    });

                    messageWorker.Execute();

                    ShowMessage("SuccessSave");
                    //재조회 
                    SearchMainGrid();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
                finally
                {
                    this.CloseWaitArea();


                }
            }
        }

        /// <summary>
        /// 불량통지서 관리 상태변경 룰을 호출하는 함수
        /// </summary>
        /// <param name="row"></param>
        /// <param name="MessageId"></param>
        /// <param name="toChangestate"></param>
        private void CallStateChangeRule(DataRow row, string MessageId, string toChangestate)
        {
            DialogResult result = System.Windows.Forms.DialogResult.No;

            result = this.ShowMessage(MessageBoxButtons.YesNo, MessageId);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    this.ShowWaitArea();

                    MessageWorker messageWorker = new MessageWorker("SaveDefectRegistChangeState");

                    messageWorker.SetBody(new MessageBody()
                    {
                        { "DocId", row["DOCID"] },
                        { "toChangeState", toChangestate }
                    });

                    messageWorker.Execute();

                    ShowMessage("SuccessSave");
                    //재조회 
                    SearchMainGrid();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
                finally
                {
                    this.CloseWaitArea();
                }

            }
        }

        /// <summary>
        /// 상태를 변경하려는 row의 수정상태 여부 체크 함수
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool isChangedRow(DataRow row)
        {
            bool isChanged = false;

            //선택된 row 수정 상태이면 상태변경불가 메시지
            if (row.RowState == DataRowState.Modified)
            isChanged = true;
            

            return isChanged;
        }
        /// <summary>
        /// 재조회 함수
        /// </summary>
        private async void SearchMainGrid()
        {
            await OnSearchAsync();
        }

        /// <summary>
        /// 그리드의 포커스 행이 바뀔때 아래 컨트롤에 data바인딩 해주는 함수
        /// </summary>
        private void BindingDataToContorl(DataRow row)
        {
            if (row == null) return;

            dteExportDate.Editor.EditValueChanging -= Editor_EditValueChanging;
            memoReasonDesc.EditValueChanging -= Editor_EditValueChanging;
            memoActionDesc.EditValueChanging -= Editor_EditValueChanging;
            txtDescription.EditValueChanging -= Editor_EditValueChanging;

            txtPaymentDate.Text = string.IsNullOrWhiteSpace(Format.GetString(row["PAYMENTDATE"])) ?string.Empty:Format.GetString(row["PAYMENTDATE"]).Substring(0, 10);//납입일자
            txtPaymentQty.Text = Format.GetString(row["PAYMENTQTY"]);//납입수량
            txtUnitPrice.Text = Format.GetString(row["UNITPRICE"]);//단가

            txtDefectDate.Text = string.IsNullOrWhiteSpace(Format.GetString(row["DEFECTDATE"])) ? string.Empty : Format.GetString(row["DEFECTDATE"]).Substring(0, 10);//불량일자
            txtDefectQty.Text = Format.GetString(row["DEFECTQTY"]);//불량수량
            txtDefectPrice.Text = Format.GetString(row["DEFECTPRICE"]);//불량금액

            txtReceiptDate.Text = string.IsNullOrWhiteSpace(Format.GetString(row["RECEIPTDATE"])) ? string.Empty : Format.GetString(row["RECEIPTDATE"]).Substring(0, 10);//접수일자
            txtDeliveryDate.Text = string.IsNullOrWhiteSpace(Format.GetString(row["DELIVERYDATE"])) ? string.Empty : Format.GetString(row["DELIVERYDATE"]).Substring(0, 10);//불량통지서발생일
            txtCompleteDate.Text = string.IsNullOrWhiteSpace(Format.GetString(row["COMPLETEDATE"])) ? string.Empty : Format.GetString(row["COMPLETEDATE"]).Substring(0, 10);//대책완료일자

            string completeDay = Format.GetString(row["COMPLETEDAY"]);//대책소요일
            if (string.IsNullOrWhiteSpace(completeDay))
            {// DB 대책소요일 없을때

                //대책완료일 없으면 "잔건" 표기
                if (!string.IsNullOrWhiteSpace(Format.GetString(row["DELIVERYDATE"]))
                   && string.IsNullOrWhiteSpace(Format.GetString(row["COMPLETEDATE"])))
                {
                    completeDay = ResidualCase;
                }
                //불량통지서 발행일이 없으면 "미발행" 표기
                else if (!string.IsNullOrWhiteSpace(Format.GetString(row["COMPLETEDATE"]))
                   && string.IsNullOrWhiteSpace(Format.GetString(row["DELIVERYDATE"])))
                {
                    completeDay = Notpublished;
                }
                else
                {
                    completeDay = string.Empty;
                }
            }

            txtCompleteDay.Text = completeDay;//대책소요일
           

            dteExportDate.Text = string.IsNullOrWhiteSpace(Format.GetString(row["EXPORTDATE"])) ? string.Empty : Format.GetString(row["EXPORTDATE"]).Substring(0, 10);//반출일자
            txtActionDate.Text = string.IsNullOrWhiteSpace(Format.GetString(row["ACTIONDATE"])) ? string.Empty : Format.GetString(row["ACTIONDATE"]).Substring(0, 10);//조치완료일자

            string actionDay = Format.GetString(row["ACTIONDAY"]);//대응처리일
            if (string.IsNullOrWhiteSpace(actionDay))
            {// DB 대응처리일 없을때

                //제품반출일 없으면 "미반출" 표기
                if (!string.IsNullOrWhiteSpace(Format.GetString(row["ACTIONDATE"]))
                    && string.IsNullOrWhiteSpace(Format.GetString(row["EXPORTDATE"])))
                {
                    actionDay = Unexported;
                }
                else
                {
                    actionDay = string.Empty;
                }  
            }

            txtActionDay.Text = actionDay;//대응처리일

            memoReasonDesc.Text = Format.GetString(row["REASONDESC"]);//원인
            memoActionDesc.Text = Format.GetString(row["ACTIONDESC"]);//대책
            txtDescription.Text = Format.GetString(row["DESCRIPTION"]);//비고사항

            SetReadOnlyContorl(Format.GetString(row["PROGRESSSTATE"]));

            dteExportDate.Editor.EditValueChanging += Editor_EditValueChanging;
            memoReasonDesc.EditValueChanging += Editor_EditValueChanging;
            memoActionDesc.EditValueChanging += Editor_EditValueChanging;
            txtDescription.EditValueChanging += Editor_EditValueChanging;
        }

        /// <summary>
        /// 컨트롤내용의 수정됐을때 그 상태를 row에 반영하는 함수
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnId"></param>
        /// <param name="contents"></param>
        private void ChangedData(DataRow row, string ColumnId, string oldValue, string newValue)
        {
            if (row == null) return;
            if(!oldValue.Equals(newValue))
            { 
                row["ISCHANGED"] = "Y";
                row[ColumnId] = newValue;
            }
        }

        /// <summary>
        /// 미발행/ 잔건/ 미반출 코드 다국어 가져올 dataTable
        /// </summary>
        private void GetCodeDictionary()
        {
            Dictionary<string, object> param = new Dictionary<string, object>()
            {
                { "CODECLASSID", "DefectDayCode"}
            };

            codeDt = SqlExecuter.Query("GetCodeList", "00001", param);

            Notpublished = codeDt.AsEnumerable()
                .Where(r => Format.GetString(r["CODEID"]).Equals("Notpublished"))
                .Select(r => Format.GetString(r["CODENAME"])).ToList()[0];

            ResidualCase = codeDt.AsEnumerable()
                .Where(r => Format.GetString(r["CODEID"]).Equals("ResidualCase"))
                .Select(r => Format.GetString(r["CODENAME"])).ToList()[0];

            Unexported = codeDt.AsEnumerable()
                .Where(r => Format.GetString(r["CODEID"]).Equals("Unexported"))
                .Select(r => Format.GetString(r["CODENAME"])).ToList()[0];

            Dictionary<string, object> param2 = new Dictionary<string, object>()
            {
                { "CODECLASSID", "DefectProcessState"}
            };

            stateCodeDt = SqlExecuter.Query("GetCodeList", "00001", param2);

            registration = stateCodeDt.AsEnumerable()
                .Where(r => Format.GetString(r["CODEID"]).Equals("Registration"))
                .Select(r => Format.GetString(r["CODENAME"])).ToList()[0];

            receipt = stateCodeDt.AsEnumerable()
                .Where(r => Format.GetString(r["CODEID"]).Equals("Receipt"))
                .Select(r => Format.GetString(r["CODENAME"])).ToList()[0];

            sendNotice = stateCodeDt.AsEnumerable()
                .Where(r => Format.GetString(r["CODEID"]).Equals("SendNotice"))
                .Select(r => Format.GetString(r["CODENAME"])).ToList()[0];

            measuresCompleted = stateCodeDt.AsEnumerable()
                .Where(r => Format.GetString(r["CODEID"]).Equals("MeasuresCompleted"))
                .Select(r => Format.GetString(r["CODENAME"])).ToList()[0];

        }

        /// <summary>
        /// 현재 상태와 바꾸려는 상태 비교하여 같으면 불가 함수
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="toState"></param>
        /// <returns></returns>
        private bool CheckcurrentStateToState(string currentState, string toState, string toStateDic)
        {
            bool isInValid = false;

            if (currentState.Equals("CancelRegistration"))
            {
                ShowMessage("DefectCancelRegState");//등록취소 된 건입니다.
                isInValid = true;
            }
            else if (currentState.Equals("ActionCompleted"))
            {
                ShowMessage("DefectActionCompletedState");//조치완료 된 건입니다.
                isInValid = true;
            }
            else if (currentState.Equals("CancelProgress"))
            {
                ShowMessage("DefectCancelProgressState");//진행취소 된 건입니다.
                isInValid = true;
            }
            else if (currentState.Equals(toState))
            {
                ShowMessage("EqualsDefectCurrentToState", toStateDic);//이미 {0} 상태입니다.
                isInValid = true;
            }

            return isInValid;
        }

        /// <summary>
        /// 등록취소 상태에서 컨트롤 입력 불가 함수
        /// </summary>
        /// <param name="currentState"></param>
        private void SetReadOnlyContorl(string currentState)
        {
            if (currentState.Equals("CancelRegistration"))
            {
                dteExportDate.Editor.ReadOnly = true;
                memoActionDesc.ReadOnly = true;
                memoReasonDesc.ReadOnly = true;
                txtDescription.ReadOnly = true;
            }
            else
            {
                dteExportDate.Editor.ReadOnly = false;
                memoActionDesc.ReadOnly = false;
                memoReasonDesc.ReadOnly = false;
                txtDescription.ReadOnly = false;
            }
        }

        /// <summary>
        /// 현재 focus 행 이외의 수정중인 행있는지 체크하는 함수
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool HasUpdatedRow(DataRow row)
        {
            bool hasUpdatedRow = false;

            if (row.RowState != DataRowState.Modified && grdDefectManage.GetChangedRows().Rows.Count > 0)
            {//현재 row가 수정 상태가 아닌데, 수정 중인 행 존재 할경우 readOnly
                ShowMessage("AlreadyModifiedDefectRow");
                hasUpdatedRow = true;
            }

            return hasUpdatedRow;
        }

        private void SetFormatControl()
        {
            txtDefectQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDefectQty.Properties.Mask.EditMask = "#,###,###,###,###";
            txtDefectQty.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtDefectPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDefectPrice.Properties.Mask.EditMask = "#,###,###,###,###";
            txtDefectPrice.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPaymentQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtPaymentQty.Properties.Mask.EditMask = "#,###,###,###,###";
            txtPaymentQty.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtUnitPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtUnitPrice.Properties.Mask.EditMask = "#,###,###,###,###";
            txtUnitPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        /// <summary>
        /// 현재 상태와 바꿀려는 상태의 이전상태 비교하여 동인한 경우 상태변경
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="compareState"></param>
        /// <returns></returns>
        private bool isRightStateStep(string currentState, string compareState, string dicState)
        {
            bool canChange = true;

            if (!currentState.Equals(compareState))
            {
                canChange = false;
                ShowMessage("NoMatchDefectProcefessState", dicState);//{0} 상태가 선행되어야 합니다.
            }

            return canChange;
        }
        #endregion
    }
}
