#region using

using DevExpress.XtraEditors.Repository;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;
using Micube.SmartMES.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Quality
{
    /// <summary>
    /// 프 로 그 램 명  : 품질관리 > 클레임관리 > 시정예방조치서 발행대장
    /// 업  무  설  명  : 클레임정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-06
    /// 수  정  이  력  : 2020-04-21 유태근 / 화면 디자인 수정 및 툴바버튼 등록
    ///                   2020-05-12 유태근 / 화면 구조 및 데이터 바인딩 방식 수정
    ///                   2020-07-28 이준용 / 현황탭 추가
    ///                   2020-09-18 이준용 / 사용자입력 컬럼 색상구분
    ///                   2020-09-21 이준용 / 고객사명 selectPopup readOnly로 변경
    ///                   2021-01-08 이준용 / 불량통지서 상관없이 조치완료 가능하도록 변경
    ///                   2022-05-10 주시은 / X번관리대장의 비고란 내용 넘어오도록 비고란 추가,
    ///                                       제조번호 컬럼 추가
    ///                                       X번관리대장 진행상태가 취소일 경우 취소 가능하도록 변경
    ///                   2022-05-11 이종건 / 진행상태현황 COUNT 조회기간 적용
    /// </summary>
    public partial class ClaimManagerReg : SmartConditionBaseForm
    {
        #region Local Variables

        private string _prevDocId = "";
        private string _dataBindingFlag = "";
        private DataTable _searchDt = new DataTable();
        private string txtName = null;

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public ClaimManagerReg()
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
            InitializeGrid();
            InitializeSubGrid();
            InitializeGridStatus();
            //텍스트 명 복사
            txtName = smartLabel1.Text;
        }

        /// <summary>        
        /// 관리 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            grdClaimInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdClaimInfo.GridButtonItem = GridButtonItem.Add | GridButtonItem.Export;

            grdClaimInfo.View.AddTextBoxColumn("DOCID", 150)
                .SetIsReadOnly(); // 발행번호
            grdClaimInfo.View.AddTextBoxColumn("CLAIMNUMBER", 150)
                .SetIsReadOnly(); // Claim No
            grdClaimInfo.View.AddTextBoxColumn("DEFECTNOTICECOUNT", 100)
                .SetTextAlignment(TextAlignment.Right)
                .SetIsReadOnly(); // 불량통지건수
            grdClaimInfo.View.AddTextBoxColumn("DEFECTDOCID", 150)
                .SetIsReadOnly()
                .SetLabel("DEFECTNOTICE"); // 불량통지서
            grdClaimInfo.View.AddTextBoxColumn("DEFECTPROGRESSSTATE", 100)
                .SetIsHidden(); // 불량통지서 진행상태(코드)
            grdClaimInfo.View.AddTextBoxColumn("DEFECTPROGRESSSTATENAME", 100)
                .SetIsReadOnly(); // 불량통지서 진행상태(명)
            grdClaimInfo.View.AddDateEditColumn("PUBLISHDATE", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime); // 발행일자
            grdClaimInfo.View.AddTextBoxColumn("PROGRESSSTATE", 100)
                .SetIsHidden(); // 진행상태(코드)
            grdClaimInfo.View.AddTextBoxColumn("PROGRESSSTATENAME", 120)
                .SetIsReadOnly()
                .SetLabel("PROGRESSSTATE"); // 진행상태(명)
            grdClaimInfo.View.AddTextBoxColumn("CUSTOMERID")
                .SetIsHidden(); // 고객사ID
            CustomerListPopup(); // 고객사명
            grdClaimInfo.View.AddTextBoxColumn("MANUFACTURENUMBER", 100)
                .SetIsReadOnly(); // 제조번호(S/N)
                //.SetIsHidden(); 
            grdClaimInfo.View.AddTextBoxColumn("MODELID")
                .SetIsHidden(); // 기종 ID
            grdClaimInfo.View.AddTextBoxColumn("MODELNAME", 100)
                .SetIsReadOnly(); // 기종명
            grdClaimInfo.View.AddTextBoxColumn("TROUBLETYPE", 100)
                .SetIsReadOnly(); // Troble분류
            grdClaimInfo.View.AddComboBoxColumn("CLAIMTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ClaimType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")); // Claim 구분
            grdClaimInfo.View.AddTextBoxColumn("STATEDESC", 150)
                .SetIsReadOnly(); // 현상
            grdClaimInfo.View.AddComboBoxColumn("REQDEPARTMENTID", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCodeQc", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("REQDEPARTMENT"); // 요청부서
            grdClaimInfo.View.AddTextBoxColumn("REQUSER", 100)
                .SetIsHidden(); // 요청자ID
            UserListPopup(); // 요청자명
            //grdClaimInfo.View.AddComboBoxColumn("REQUSER", 100, new SqlQuery("GetUser", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "USERNAME", "USERID"); // 요청자
            grdClaimInfo.View.AddComboBoxColumn("PUBLISHTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=PublishType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")); // 발행구분
            grdClaimInfo.View.AddTextBoxColumn("REQCONFDATE", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
               // .SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime); // 회담 희망일
            grdClaimInfo.View.AddTextBoxColumn("RECIEPTDATE", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("CLAIMRECIEPTDATE"); // Claim 접수일
            grdClaimInfo.View.AddTextBoxColumn("COMPLETEDATE", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center); // 발행완료일
            grdClaimInfo.View.AddTextBoxColumn("COMPLETEDAY", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Right); // 발행소요일
            grdClaimInfo.View.AddTextBoxColumn("ACTIONDATE", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center); // 조치완료일
            grdClaimInfo.View.AddTextBoxColumn("ACTIONDAY", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Right); // 조치소요일
            grdClaimInfo.View.AddDateEditColumn("INDATE", 120)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime)
                .SetIsReadOnly(); // 제품입고일자
            grdClaimInfo.View.AddComboBoxColumn("CONFIRMUSER", 100, new SqlQuery("GetUser", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "USERNAME", "USERID")
                .SetIsReadOnly(); // 입고확인자
            grdClaimInfo.View.AddTextBoxColumn("RESPONSEDATE", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Right); // 현장대응소요일
            grdClaimInfo.View.AddTextBoxColumn("DESCRIPTION", 200)
                .SetIsHidden(); // 비고사항
            grdClaimInfo.View.AddSpinEditColumn("VARIABLECOST", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Right); // 변동비
            grdClaimInfo.View.AddSpinEditColumn("FIXEDCOST", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Right); // 고정비

            grdClaimInfo.View.AddTextBoxColumn("XNUMBER", 100)
                .SetIsHidden(); // X번호
            grdClaimInfo.View.AddTextBoxColumn("ETMHOUR", 100)
                .SetIsHidden(); // 사용시간(ETM)
            grdClaimInfo.View.AddTextBoxColumn("CLAIMDATE", 100)
                .SetIsHidden(); // Claim 발생일
            grdClaimInfo.View.AddTextBoxColumn("CLAIMDESC", 100)
                .SetIsHidden(); // Claim 내용
            grdClaimInfo.View.AddTextBoxColumn("ISMODIFIEDFILE", 100)
                .SetIsHidden(); // 파일수정여부

            grdClaimInfo.View.PopulateColumns();

            grdClaimInfo.View.OptionsNavigation.AutoMoveRowFocus = false;
        }

        /// <summary>        
        /// 해당 팀별 조치정보 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeSubGrid()
        {
            grdTeamActionInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdTeamActionInfo.GridButtonItem = GridButtonItem.Add | GridButtonItem.Delete | GridButtonItem.Export;
            
            //grdTeamActionInfo.View.AddComboBoxColumn("TARGETDEPARTMENTID", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=Part", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
            //    .SetLabel("TARGETDEPARTMENT"); // 대상부서
            grdTeamActionInfo.View.AddComboBoxColumn("TEAMID", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCodeQc", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("TEAM")
                .SetEmptyItem(""); // 해당팀
            grdTeamActionInfo.View.AddComboBoxColumn("DEFECTTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=DefectType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem(""); // 불량구분
            grdTeamActionInfo.View.AddTextBoxColumn("PROGRESSDESC", 150); // 진행사항      
            grdTeamActionInfo.View.AddTextBoxColumn("REASONDESC", 150); // 원인
            grdTeamActionInfo.View.AddTextBoxColumn("ACTIONDESC", 150); // 대책
            grdTeamActionInfo.View.AddDateEditColumn("ACTIONDATE", 120)
                .SetLabel("MEASURESCOMPLETEDDATE")
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime); // 대책완료일
            grdTeamActionInfo.View.AddComboBoxColumn("REASONTEAMID", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCodeQc", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("REASONTEAM")
                .SetEmptyItem(""); // 발행팀
            grdTeamActionInfo.View.AddComboBoxColumn("REASONTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ReasonType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem(""); // 원인구분   
            grdTeamActionInfo.View.AddTextBoxColumn("DOCID", 100)
                .SetIsHidden(); // 발행번호
            grdTeamActionInfo.View.AddTextBoxColumn("DOCSEQUENCE", 100)
                .SetIsHidden(); // 발행시퀀스

            grdTeamActionInfo.View.PopulateColumns();

            grdTeamActionInfo.View.OptionsNavigation.AutoMoveRowFocus = false;
        }

        private void InitializeGridStatus()
        {
            grdStatus.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdStatus.GridButtonItem = GridButtonItem.Export;

            grdStatus.View.SetIsReadOnly();

            grdStatus.View.AddTextBoxColumn("DOCID", 150)
                .SetIsReadOnly(); // 발행번호
            grdStatus.View.AddTextBoxColumn("CLAIMNUMBER", 150)
                .SetIsReadOnly(); // Claim No
            grdStatus.View.AddTextBoxColumn("DEFECTNOTICECOUNT", 100)
                .SetTextAlignment(TextAlignment.Right)
                .SetIsReadOnly(); // 불량통지건수
            grdStatus.View.AddTextBoxColumn("DEFECTDOCID", 150)
                .SetIsReadOnly()
                .SetLabel("DEFECTNOTICE"); // 불량통지서
            grdStatus.View.AddTextBoxColumn("DEFECTPROGRESSSTATE", 100)
                .SetIsHidden(); // 불량통지서 진행상태(코드)
            grdStatus.View.AddTextBoxColumn("DEFECTPROGRESSSTATENAME", 100)
                .SetIsReadOnly(); // 불량통지서 진행상태(명)
            grdStatus.View.AddDateEditColumn("PUBLISHDATE", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime); // 발행일자
            grdStatus.View.AddTextBoxColumn("PROGRESSSTATE", 100)
                .SetIsHidden(); // 진행상태(코드)
            grdStatus.View.AddTextBoxColumn("PROGRESSSTATENAME", 120)
                .SetIsReadOnly()
                .SetLabel("PROGRESSSTATE"); // 진행상태(명)
            grdStatus.View.AddTextBoxColumn("CUSTOMERID")
                .SetIsHidden(); // 고객사ID
            // 고객사명
            grdStatus.View.AddTextBoxColumn("CUSTOMERNAME", 100).SetTextAlignment(TextAlignment.Left);
            //CustomerListPopup();
            grdStatus.View.AddTextBoxColumn("MODELID")
                .SetIsHidden(); // 기종 ID
            grdStatus.View.AddTextBoxColumn("MODELNAME", 100)
                .SetIsReadOnly(); // 기종명
            grdStatus.View.AddTextBoxColumn("TROUBLETYPE", 100)
                .SetIsReadOnly(); // Troble분류
            grdStatus.View.AddComboBoxColumn("CLAIMTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ClaimType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")); // Claim 구분
            grdStatus.View.AddTextBoxColumn("STATEDESC", 150)
                .SetIsReadOnly(); // 현상
            grdStatus.View.AddComboBoxColumn("REQDEPARTMENTID", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCodeQc", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("REQDEPARTMENT"); // 요청부서
            grdStatus.View.AddTextBoxColumn("REQUSER", 100)
                .SetIsHidden(); // 요청자ID
            grdStatus.View.AddTextBoxColumn("REQUSERNAME", 100);
            //UserListPopup(); // 요청자명
            //grdClaimInfo.View.AddComboBoxColumn("REQUSER", 100, new SqlQuery("GetUser", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "USERNAME", "USERID"); // 요청자
            grdStatus.View.AddComboBoxColumn("PUBLISHTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=PublishType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")); // 발행구분
            grdStatus.View.AddTextBoxColumn("REQCONFDATE", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center); //회담 희망일
               // .SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime); // 회담 희망일
            grdStatus.View.AddTextBoxColumn("RECIEPTDATE", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("CLAIMRECIEPTDATE"); // Claim 접수일
            grdStatus.View.AddTextBoxColumn("COMPLETEDATE", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center); // 발행완료일
            grdStatus.View.AddTextBoxColumn("COMPLETEDAY", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Right); // 발행소요일
            grdStatus.View.AddTextBoxColumn("ACTIONDATE", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center); // 조치완료일
            grdStatus.View.AddTextBoxColumn("ACTIONDAY", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Right); // 조치소요일
            grdStatus.View.AddDateEditColumn("INDATE", 120)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime)
                .SetIsReadOnly(); // 제품입고일자
            grdStatus.View.AddComboBoxColumn("CONFIRMUSER", 100, new SqlQuery("GetUser", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "USERNAME", "USERID")
                .SetIsReadOnly(); // 입고확인자
            grdStatus.View.AddTextBoxColumn("RESPONSEDATE", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Right); // 현장대응소요일
            grdStatus.View.AddTextBoxColumn("DESCRIPTION", 200)
                .SetIsHidden(); // 비고사항
            grdStatus.View.AddSpinEditColumn("VARIABLECOST", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Right); // 변동비
            grdStatus.View.AddSpinEditColumn("FIXEDCOST", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Right); // 고정비

            grdStatus.View.AddTextBoxColumn("XNUMBER", 100)
                .SetIsHidden(); // X번호
            grdStatus.View.AddTextBoxColumn("MANUFACTURENUMBER", 100)
                .SetIsHidden(); // 제조번호(S/N)
            grdStatus.View.AddTextBoxColumn("ETMHOUR", 100)
                .SetIsHidden(); // 사용시간(ETM)
            grdStatus.View.AddTextBoxColumn("CLAIMDATE", 100)
                .SetIsHidden(); // Claim 발생일
            grdStatus.View.AddTextBoxColumn("CLAIMDESC", 100)
                .SetIsHidden(); // Claim 내용
            grdStatus.View.AddTextBoxColumn("ISMODIFIEDFILE", 100)
                .SetIsHidden(); // 파일수정여부

            grdStatus.View.AddComboBoxColumn("TEAMID", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCodeQc", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
             .SetLabel("TEAM")
             .SetEmptyItem(""); // 해당팀
            grdStatus.View.AddComboBoxColumn("DEFECTTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=DefectType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem(""); // 불량구분
            grdStatus.View.AddTextBoxColumn("PROGRESSDESC", 150); // 진행사항      
            grdStatus.View.AddTextBoxColumn("REASONDESC", 150); // 원인
            grdStatus.View.AddTextBoxColumn("ACTIONDESC", 150); // 대책
            grdStatus.View.AddDateEditColumn("ACTIONDATE", 120)
                .SetLabel("MEASURESCOMPLETEDDATE")
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime); // 대책완료일
            grdStatus.View.AddComboBoxColumn("REASONTEAMID", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCodeQc", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("REASONTEAM")
                .SetEmptyItem(""); // 발행팀
            grdStatus.View.AddComboBoxColumn("REASONTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ReasonType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem(""); // 원인구분   
           // grdStatus.View.AddTextBoxColumn("DOCID", 100)
           //    .SetIsHidden(); // 발행번호
            grdStatus.View.AddTextBoxColumn("DOCSEQUENCE", 100)
                .SetIsHidden(); // 발행시퀀스

            grdStatus.View.PopulateColumns();

   
        }

        /// <summary>
        /// ComboBox 컨트롤 초기화
        /// </summary>
        //private void InitializeComboBox()
        //{
        //    Dictionary<string, object> param = new Dictionary<string, object>
        //    {
        //        { "LANGUAGETYPE", UserInfo.Current.LanguageType }
        //    };

        //    cboWareHousingCheckUser.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberAndValueMember;
        //    cboWareHousingCheckUser.ValueMember = "USERID";
        //    cboWareHousingCheckUser.DisplayMember = "USERNAME";
        //    cboWareHousingCheckUser.DataSource = SqlExecuter.Query("GetUser", "00001", param);
        //    cboWareHousingCheckUser.ShowHeader = false;
        //}

        #endregion

        #region 그리드 팝업

        /// <summary>
        /// 그리드 고객사 팝업
        /// </summary>
        private void CustomerListPopup()
        {
            var customerPopup = grdClaimInfo.View.AddSelectPopupColumn("CUSTOMERNAME", 180, new SqlQuery("GetCustomer", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"DBLINKNAME={CommonFunction.DbLinkName}"), "CUSTOMERNAME")
                .SetPopupLayout("CUSTOMER", PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetIsReadOnly()
                .SetPopupLayoutForm(800, 800, System.Windows.Forms.FormBorderStyle.FixedToolWindow)
                .SetTextAlignment(TextAlignment.Left)
                .SetPopupApplySelection((IEnumerable<DataRow> selectedRow, DataRow dataGirdRow) =>
                {
                    if (selectedRow.Count() > 0)
                    {
                        grdClaimInfo.View.SetFocusedRowCellValue("CUSTOMERID", selectedRow.FirstOrDefault()["CUSTOMERID"]);
                    }
                    else
                    {
                        grdClaimInfo.View.SetFocusedRowCellValue("CUSTOMERID", "");
                    }
                }); 

            // 검색조건
            customerPopup.Conditions.AddTextBox("CUSTOMERIDNAME");

            // 팝업의 그리드에 컬럼 추가
            customerPopup.GridColumns.AddTextBoxColumn("CUSTOMERID", 100);
            customerPopup.GridColumns.AddTextBoxColumn("CUSTOMERNAME", 150);
            customerPopup.GridColumns.AddTextBoxColumn("PHONE", 100);
            //customerPopup.GridColumns.AddTextBoxColumn("FAXNO", 100);
            customerPopup.GridColumns.AddTextBoxColumn("ADDRESS", 250);
        }

        /// <summary>
        /// 그리드 유저 팝업
        /// </summary>
        private void UserListPopup()
        {
            var userPopup = grdClaimInfo.View.AddSelectPopupColumn("REQUSERNAME", 100, new SqlQuery("GetUser", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("REQUSERNAME", PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(600, 500, System.Windows.Forms.FormBorderStyle.FixedToolWindow)
                .SetTextAlignment(TextAlignment.Left)
                .SetPopupAutoFillColumns("EMAILADDRESS")
                .SetPopupResultMapping("REQUSERNAME", "USERNAME")
                .SetPopupApplySelection((IEnumerable<DataRow> selectedRow, DataRow dataGirdRow) =>
                {
                    if (selectedRow.Count() > 0)
                    {
                        grdClaimInfo.View.SetFocusedRowCellValue("REQUSER", selectedRow.FirstOrDefault()["USERID"]);
                    }
                    else
                    {
                        grdClaimInfo.View.SetFocusedRowCellValue("REQUSER", "");
                    }
                });

            // 검색조건
            userPopup.Conditions.AddTextBox("USERIDNAME");

            // 팝업의 그리드에 컬럼 추가
            userPopup.GridColumns.AddTextBoxColumn("USERID", 100);
            userPopup.GridColumns.AddTextBoxColumn("USERNAME", 100);
            userPopup.GridColumns.AddTextBoxColumn("EMAILADDRESS", 150);
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            grdClaimInfo.View.FocusedRowChanged += View_FocusedRowChanged;
            grdClaimInfo.View.AddingNewRow += View_AddingNewRow;
            grdClaimInfo.View.ShowingEditor += View_ShowingEditor;
            grdClaimInfo.Paint += GrdClaimInfo_Paint;
            grdClaimInfo.View.RowCellStyle += View_RowCellStyle;

            // 2020-07-08 - 진행정보저장버튼 추가함으로써 데이터 수정 따로관리
            //grdTeamActionInfo.ToolbarDeletingRow += SubGridDeleteRow;
            //grdTeamActionInfo.View.AddingNewRow += SubGridAddRow;
            //grdTeamActionInfo.View.CellValueChanged += SubGridModifiedRow;

            ucFile.StateEvent += UcFile_StateEvent;
            grdTeamActionInfo.View.ShowingEditor += View_ShowingEditor1;
            memoDescription.EditValueChanging += EditValueChanging;
        }

        /// <summary>
        /// 입력, 읽기전용 컬럼 표시
        /// </summary>
        private void View_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName.Equals("DOCID") ||
                e.Column.FieldName.Equals("CLAIMNUMBER") ||
                e.Column.FieldName.Equals("DEFECTNOTICECOUNT") ||
                e.Column.FieldName.Equals("DEFECTDOCID") ||
                e.Column.FieldName.Equals("DEFECTPROGRESSSTATENAME") ||
                e.Column.FieldName.Equals("PUBLISHDATE") ||
                e.Column.FieldName.Equals("PROGRESSSTATENAME") ||
                e.Column.FieldName.Equals("MANUFACTURENUMBER") ||
                e.Column.FieldName.Equals("MODELNAME") ||
                e.Column.FieldName.Equals("TROUBLETYPE") ||
                e.Column.FieldName.Equals("RECIEPTDATE") ||
                e.Column.FieldName.Equals("COMPLETEDATE") ||
                e.Column.FieldName.Equals("COMPLETEDAY") ||
                e.Column.FieldName.Equals("ACTIONDATE") ||
                e.Column.FieldName.Equals("ACTIONDAY") ||
                e.Column.FieldName.Equals("RESPONSEDATE") ||
                e.Column.FieldName.Equals("VARIABLECOST") ||
                e.Column.FieldName.Equals("FIXEDCOST") ||
                e.Column.FieldName.Equals("STATEDESC") ||
                e.Column.FieldName.Equals("INDATE") ||
                e.Column.FieldName.Equals("CONFIRMUSER") ||
                e.Column.FieldName.Equals("CUSTOMERNAME") ||
                e.Column.FieldName.Equals("CLAIMTYPE") ||
                e.Column.FieldName.Equals("REQDEPARTMENTID") ||
                e.Column.FieldName.Equals("REQUSERNAME") ||
                e.Column.FieldName.Equals("PUBLISHTYPE") ||
                e.Column.FieldName.Equals("REQCONFDATE"))
            {
                e.Column.AppearanceCell.BackColor = Color.FromArgb(242, 242, 242);
            }
            //입력항목 색상 처리
            if(e.Column.FieldName.Equals("PUBLISHDATE") ||
               e.Column.FieldName.Equals("PROGRESSSTATENAME") ||
               e.Column.FieldName.Equals("CLAIMTYPE") ||
               e.Column.FieldName.Equals("REQDEPARTMENTID") ||
               e.Column.FieldName.Equals("REQUSERNAME") ||
               e.Column.FieldName.Equals("PUBLISHTYPE"))
            {
                e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                e.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 조치완료상태라면 팀별조치정보 그리드의 대책완료일자 수정불가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_ShowingEditor1(object sender, CancelEventArgs e)
        {
            DataRow row = grdClaimInfo.View.GetFocusedDataRow();

            if (grdTeamActionInfo.View.FocusedColumn.FieldName.Equals("ACTIONDATE"))
            {
                if (row["PROGRESSSTATE"].Equals("ActionCompleted"))
                {
                    // 시정예방 조치완료상태에서는 대책완료일자가 수정 불가능합니다.
                    this.ShowMessage("MeasuresCompletedDateIsNotModifiy");
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 툴바버튼 사이즈 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdClaimInfo_Paint(object sender, PaintEventArgs e)
        {
            var buttons = pnlToolbar.Controls.Find<SmartButton>(true);

            foreach (SmartButton btn in buttons)
            {
                if (string.IsNullOrWhiteSpace(btn.Text)) continue;

                int w = (Size.Round(e.Graphics.MeasureString(btn.Text, btn.Font))).Width;

                btn.Size = new Size(w < 80 ? 80 : w, btn.Height);
            }
        }

        /// <summary>
        /// 팀별 조치정보 행 삭제시 상태변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubGridDeleteRow(object sender, CancelEventArgs e)
        {
            DataTable dt = grdTeamActionInfo.View.GetCheckedRows();

            if (dt.Rows.Count > 0)
            {
                UcFile_StateEvent(false);
            }
        }

        /// <summary>
        /// 팀별 조치정보 행 추가시 상태변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SubGridAddRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow row = grdClaimInfo.View.GetFocusedDataRow();
            args.NewRow["DOCID"] = row.GetString("DOCID"); // 발행번호
            //args.NewRow["TARGETDEPARTMENTID"] = UserInfo.Current.Department; // 대상부서
            UcFile_StateEvent(true);
        }

        /// <summary>
        /// 팀별 조치정보 행 수정시 상태변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubGridModifiedRow(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e == null) return;
            UcFile_StateEvent(true);
        }

        /// <summary>
        /// 파일컨트롤의 그리드를 체크하여 추가, 수정, 삭제된 행이 있으면 상단그리드 수정상태로 변경
        /// </summary>
        /// <param name="stateFlag">ture 면 상단 메인 그리드 상태 modified로 변경</param>
        private void UcFile_StateEvent(bool stateFlag)
        {
            stateFlag = false;

            if (stateFlag)
            {
                if (grdClaimInfo.View.FocusedRowHandle < 0) return;

                DataRow row = grdClaimInfo.View.GetFocusedDataRow();

                if (row.RowState == DataRowState.Unchanged)
                {
                    row.SetModified();
                }
            }
        }

        /// <summary>
        /// Control Value 변경 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataRow focusRow = grdClaimInfo.View.GetFocusedDataRow();
            if (focusRow == null) return;

            if (_dataBindingFlag.Equals("NonComplete")) return;

            if (grdClaimInfo.GetChangedRows().Rows.Count > 0)
            {
                if (focusRow.RowState != DataRowState.Added && focusRow.RowState != DataRowState.Modified)
                {
                    // 저장, 수정중인행이 존재합니다.
                    this.ShowMessage("RowBeingSaveOrModified");
                    e.Cancel = true;
                    return;
                }
            }
            
            if (!string.IsNullOrWhiteSpace(_prevDocId) && !_prevDocId.Equals(Format.GetString(focusRow["DOCID"])))
            {
                if (e.OldValue.Equals(e.NewValue))
                {
                    _prevDocId = Format.GetString(focusRow["DOCID"]);
                    return;
                }
            }

            Control control = null;

            string controlName = sender.GetType().Name;
            switch (controlName)
            {
                case "SmartTextBox":
                    control = sender as SmartTextBox;
                    break;
                case "SmartDateEdit":
                    control = sender as SmartDateEdit;
                    break;
                case "SmartComboBox":
                    control = sender as SmartComboBox;
                    break;
                case "SmartMemoEdit":
                    control = sender as SmartMemoEdit;
                    break;
            }

            if (control == null) return;
            if (string.IsNullOrWhiteSpace(Format.GetString(control.Tag))) return;

            string tag = Format.GetString(control.Tag);

            if (Format.GetString(e.OldValue) != Format.GetString(e.NewValue))
            {
                if (controlName.Equals("SmartDateEdit"))
                {
                    string newValue = Format.GetString(e.NewValue).Substring(0, 10);
                    focusRow[tag] = newValue;
                }
                else
                {
                    focusRow[tag] = Format.GetString(e.NewValue);
                }            
            }
        }

        /// <summary>
        /// 포커스 받은 Row 색깔변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void View_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        //{
        //    if (grdClaimInfo.View.FocusedRowHandle == e.RowHandle)
        //    {
        //        e.HighPriority = true;
        //        e.Appearance.BackColor = Color.Yellow;
        //    }
        //}

        /// <summary>
        /// 저장, 수정중인행이 존재했을때 다른행 ReadOnly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (grdClaimInfo.View.GetFocusedDataRow().RowState != DataRowState.Modified 
                && grdClaimInfo.View.GetFocusedDataRow().RowState != DataRowState.Added)
            {
                if (grdClaimInfo.GetChangedRows().Rows.Count > 0)
                {
                    // 저장, 수정중인 행이 존재합니다.
                    this.ShowMessage("RowBeingSaveOrModified");
                    e.Cancel = true;
                    return;
                }
            }
        }

        /// <summary>
        /// 행 추가시 발행일자 및 회담 희망일 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void View_AddingNewRow(SmartBandedGridView sender, AddNewRowArgs args)
        {
            if (grdClaimInfo.GetChangedRows().Rows.Count > 1)
            {
                args.IsCancel = true;

                // 저장, 수정중인 행이 존재합니다.
                this.ShowMessage("RowBeingSaveOrModified");
                return;
            }
            args.NewRow["REQUSER"] = UserInfo.Current.Id; // 요청자ID(현재 로그인한 유저)
            args.NewRow["REQUSERNAME"] = UserInfo.Current.Name; // 요청자명(현재 로그인한 유저)
            args.NewRow["PUBLISHDATE"] = DateTime.Now; // 발행일자(현재날짜)
            //args.NewRow["REQCONFDATE"] = DateTime.Now.AddDays(15); // 회담희망일(발행일자 + 15일)
        }

        /// <summary>
        /// 선택한 Row에 따라 아래 Claim정보 탭의 정보가 변경되도록 하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = grdClaimInfo.View.GetFocusedDataRow();
            DataRow prevRow = grdClaimInfo.View.GetDataRow(e.PrevFocusedRowHandle);

            if (row == null) return;

            // 현재 Row의 상태가 시정예방조치의뢰일때만 발행취소버튼 활성화
            if (grdClaimInfo.View.GetDataRow(grdClaimInfo.View.FocusedRowHandle)["PROGRESSSTATE"].Equals("CorrectiveActionPublish"))
            {
                if (pnlToolbar.Controls["layoutToolbar"].Controls.ContainsKey("PublishCancel"))
                {
                    pnlToolbar.Controls["layoutToolbar"].Controls["PublishCancel"].Enabled = true;
                }
            }
            else
            {
                if (pnlToolbar.Controls["layoutToolbar"].Controls.ContainsKey("PublishCancel"))
                {
                    pnlToolbar.Controls["layoutToolbar"].Controls["PublishCancel"].Enabled = false;
                }
            }

            if (prevRow == null) return;
            else _prevDocId = Format.GetString(prevRow["DOCID"]);

            DataTable dt = grdClaimInfo.GetChangedRows();
            DataTable tdt = grdTeamActionInfo.GetChangedRows();
            DataTable fdt = ucFile.GetChangedRows();

            if (row.RowState != DataRowState.Detached && prevRow.RowState == DataRowState.Added)
            {
                // 행을 변경하시겠습니까? 현재 입력중인 정보는 사라집니다.
                if (this.ShowMessageBox("ChangeRowCurrentInputDataDelete", "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SelectRowDataBinding(row);
                    grdClaimInfo.View.GetDataRow(e.PrevFocusedRowHandle).Delete();     
                }
                else
                {
                    grdClaimInfo.View.FocusedRowChanged -= View_FocusedRowChanged;
                    grdClaimInfo.View.SelectRow(e.PrevFocusedRowHandle);
                    grdClaimInfo.View.FocusedRowHandle = e.PrevFocusedRowHandle;
                    grdClaimInfo.View.FocusedRowChanged += View_FocusedRowChanged;
                }
            }
            else if (tdt != null && fdt != null)
            {
                if (tdt.Rows.Count + fdt.Rows.Count + dt.Rows.Count > 0)
                {
                    if (prevRow.RowState == DataRowState.Added || prevRow.RowState == DataRowState.Modified)
                    {
                        // 행을 변경하시겠습니까? 현재 입력중인 정보는 사라집니다.
                        if (this.ShowMessageBox("ChangeRowCurrentInputDataDelete", "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (prevRow.RowState == DataRowState.Added)
                            {
                                SelectRowDataBinding(row);
                                grdClaimInfo.View.GetDataRow(e.PrevFocusedRowHandle).Delete();
                            }
                            else
                            {
                                SelectRowDataBinding(row);
                                ucFile.docId = Format.GetString(row["DOCID"]);
                                SetUnchangedRow(_searchDt, prevRow);
                            }
                        }
                        else
                        {
                            grdClaimInfo.View.FocusedRowChanged -= View_FocusedRowChanged;
                            grdClaimInfo.View.SelectRow(e.PrevFocusedRowHandle);
                            grdClaimInfo.View.FocusedRowHandle = e.PrevFocusedRowHandle;
                            grdClaimInfo.View.FocusedRowChanged += View_FocusedRowChanged;
                        }
                    }
                    else
                    {
                        SelectRowDataBinding(row);
                        ucFile.docId = Format.GetString(row["DOCID"]);
                    }
                }
                else
                {
                    SelectRowDataBinding(row);
                    ucFile.docId = Format.GetString(row["DOCID"]);
                }
            }
            else
            {
                SelectRowDataBinding(row);
                ucFile.docId = Format.GetString(row["DOCID"]);
            }
        }

        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            if(smartTabControl1.SelectedTabPageIndex == 0) //시정예방조치 탭
            {
               
                grdClaimInfo.View.PostEditor();
                grdClaimInfo.View.UpdateCurrentRow();

                DataTable changed = grdClaimInfo.GetChangedRows();

                if (changed.Rows.Count < 1)
                {
                    this.ShowMessage("NoSaveData");
                    return;
                }

                MessageWorker worker = new MessageWorker("SaveClaimManagerReg");
                worker.SetBody(new MessageBody()
            {
                { "list", changed }, // 저장할 데이터테이블
            });

                worker.Execute();
            }
        }

        /// <summary>
        /// 툴바버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            if (smartTabControl1.SelectedTabPageIndex == 0)   //시정예방조치 탭
            {

                SmartButton btn = sender as SmartButton;

                // 시정조치의뢰서 버튼클릭
                if (btn.Name.ToString().Equals("ClaimReferral"))
                {
                    CallClaimManagerExcel(grdClaimInfo.View.GetFocusedDataRow());
                    //CallClaimManagerExcelPopup(grdClaimInfo.View.GetFocusedDataRow());
                }
                // Claim접수 버튼클릭
                else if (btn.Name.ToString().Equals("ClaimReceipt"))
                {
                    ProgressStateChange(grdClaimInfo.View.GetFocusedDataRow(), "ClaimReceipt");
                }
                // 대응완료 버튼클릭
                else if (btn.Name.ToString().Equals("RespondComplete"))
                {
                    ProgressStateChange(grdClaimInfo.View.GetFocusedDataRow(), "ResponseCompleted");
                }
                // 조치완료 버튼클릭
                else if (btn.Name.ToString().Equals("ManeuverComplete"))
                {
                    ProgressStateChange(grdClaimInfo.View.GetFocusedDataRow(), "ActionCompleted");
                }
                // 발행취소 버튼클릭
                else if (btn.Name.ToString().Equals("PublishCancel"))
                {
                    ProgressStateChange(grdClaimInfo.View.GetFocusedDataRow(), "PublishCancel");
                }
                // 진행정보저장 버튼클릭
                else if (btn.Name.ToString().Equals("ProgressSave"))
                {
                    SaveProgressInfo();
                }
                // 저장 버튼클릭
                else if (btn.Name.ToString().Equals("SaveBehind"))
                {
                    SaveClaimInfo();
                }
                // 2022-05-11 주시은 취소 버튼 추가
                else if (btn.Name.ToString().Equals("Cancel"))
                {
                    ProgressStateChange(grdClaimInfo.View.GetFocusedDataRow(), "Cancel");
                }
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

            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            values.Add("DBLINKNAME", CommonFunction.DbLinkName);

            string dblink = CommonFunction.DbLinkName;

            if (smartTabControl1.SelectedTabPageIndex == 0) // 시정예방조치 탭
            {
                DataTable dt = await SqlExecuter.QueryAsync("SelectClaimManager", "00002", values);

                if (dt.Rows.Count < 1)
                {
                    this.ShowMessage("NoSelectData");
                }

                grdClaimInfo.DataSource = dt;
                SelectRowDataBinding(grdClaimInfo.View.GetFocusedDataRow());

                // 메인그리드 조회
                _searchDt = SetOriginalTable(dt);

                // 진행상태현황 갯수 바인딩
                SetProgressStateCount();

                if (grdClaimInfo.View.GetFocusedDataRow() == null) return;

                // 검색된 Row가 한개일때 포커스를 강제로 부여하여 하위 그리드 검색
                if (dt.Rows.Count == 1) grdClaimInfo.View.FocusedRowHandle = 0;

                // 현재 Row의 상태가 시정예방조치의뢰일때만 발행취소버튼 활성화
                if (grdClaimInfo.View.GetDataRow(grdClaimInfo.View.FocusedRowHandle)["PROGRESSSTATE"].Equals("CorrectiveActionPublish"))
                {
                    if (pnlToolbar.Controls["layoutToolbar"].Controls.ContainsKey("PublishCancel"))
                    {
                        pnlToolbar.Controls["layoutToolbar"].Controls["PublishCancel"].Enabled = true;
                    }
                }
                else
                {
                    if (pnlToolbar.Controls["layoutToolbar"].Controls.ContainsKey("PublishCancel"))
                    {
                        pnlToolbar.Controls["layoutToolbar"].Controls["PublishCancel"].Enabled = false;
                    }
                }
            }
            else if (smartTabControl1.SelectedTabPageIndex == 1) // 시정예방조치현황 탭
            {
                DataTable dt = await SqlExecuter.QueryAsync("SelectClaimManagerStatus", "00002", values);

                if (dt.Rows.Count < 1)
                {
                    this.ShowMessage("NoSelectData");
                }

                grdStatus.DataSource = dt;

            }
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // TODO : 조회조건 추가 구성이 필요한 경우 사용
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            DateTime today = DateTime.Now.Date;

            SmartPeriodEdit fromDate = Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD");
            fromDate.datePeriodFr.EditValue = DateTime.Now.AddDays(1 - today.Day);

            SmartPeriodEdit toDate = Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD");
            toDate.datePeriodTo.EditValue = today;
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            // TODO : 유효성 로직 변경
            grdClaimInfo.View.CheckValidation();

            DataTable changed = grdClaimInfo.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        /// <summary>
        /// Select Row 데이터 바인딩 함수
        /// </summary>
        /// <param name="row"></param>
        private void SelectRowDataBinding(DataRow row)
        {
            if (row == null)
            {
                grdTeamActionInfo.View.ClearDatas();
                ucFile.ClearGridDatas();
                return;
            }

            _dataBindingFlag = "NonComplete";

            // Claim 정보탭
            txtCustomer.EditValue = row["CUSTOMERNAME"];
            txtProductDefId.EditValue = row["XNUMBER"];
            txtMakingNumber.EditValue = row["MANUFACTURENUMBER"];
            txtUseTime.EditValue = row["ETMHOUR"];
            txtClaimDate.EditValue = row["CLAIMDATE"];
            txtStateDesc.EditValue = row["STATEDESC"];
            txtResponseDesc.EditValue = row["RESPONSEDESC"];
            txtClaimDesc.EditValue = row["CLAIMDESC"];
            memoDescription.Text = Format.GetString(row["DESCRIPTION"]);

            // 진행정보탭의 해당팀별 조치정보그리드 및 파일그리드
            Dictionary<string, object> param = new Dictionary<string, object>()
            {
                { "DOCID", row["DOCID"]}
            };

            DataTable tdt = SqlExecuter.Query("GetTeamActionInfo", "00001", param);
            grdTeamActionInfo.DataSource = tdt;

            DataTable fdt = SqlExecuter.Query("GetClaimManagerFileList", "00001", param);
            ucFile.dataSoruce = fdt;

            _dataBindingFlag = "Complete";
        }

        /// <summary>
        /// Claim 정보 저장
        /// </summary>
        /// <param name="strtitle"></param>
        private void SaveClaimInfo()
        {
            grdClaimInfo.View.CloseEditor();
            grdClaimInfo.View.CheckValidation();

            DataTable tdt = grdTeamActionInfo.GetChangedRows();
            tdt.TableName = "teamActionList";

            DataSet ds = new DataSet();
            ds.Tables.Add(grdClaimInfo.GetChangedRows());
            ds.Tables.Add(ucFile.GetChangedRows().Clone());
            ds.Tables.Add(tdt.Clone());

            if (ds.Tables["list"].Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                this.ShowMessage(MessageBoxButtons.OK, "NoSaveData");
                return;
            }

            string docId = Format.GetString(grdClaimInfo.View.GetFocusedRowCellValue("DOCID"));

            if (grdClaimInfo.GetChangedRows().AsEnumerable().Where(r => !r["_STATE_"].Equals("deleted")).ToList().Count > 0)
            {
                DataTable docDt = grdClaimInfo.GetChangedRows().AsEnumerable().Where(r => !r["_STATE_"].Equals("deleted")).CopyToDataTable();
                docId = string.IsNullOrWhiteSpace(Format.GetString(docDt.Rows[0]["DOCID"])) ? "" : Format.GetString(docDt.Rows[0]["DOCID"]);             
            }

            try
            {
                this.ShowWaitArea();

                MessageWorker messageWorker = new MessageWorker("SaveClaimManagerReg");

                messageWorker.SetBody(new MessageBody()
                {
                    { "list", ds.Tables["list"] },
                    { "fileList", ds.Tables["fileList"] },
                    { "teamActionList", ds.Tables["teamActionList"] },
                    { "docId", docId },
                    { "flag", "Upsert" }
                });

                messageWorker.Execute();

                this.ShowMessage("SuccessSave");
                SearchMainGrid(); // 재조회 
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

        /// <summary>
        /// 진행정보 저장
        /// </summary>
        /// <param name="strtitle"></param>
        private void SaveProgressInfo()
        {
            grdTeamActionInfo.View.CloseEditor();
            ucFile.CloseEditor();

            DataRow currentRow = grdClaimInfo.View.GetFocusedDataRow();
            DataTable tdt = grdTeamActionInfo.GetChangedRows();
            tdt.TableName = "teamActionList";
            DataTable dt = currentRow.Table.Clone();
            dt.TableName = "list";

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables.Add(ucFile.GetChangedRows());
            ds.Tables.Add(tdt);

            if (currentRow == null || (ds.Tables["fileList"].Rows.Count == 0 && ds.Tables["teamActionList"].Rows.Count == 0))
            {
                // 저장할 데이터가 존재하지 않습니다.
                this.ShowMessage(MessageBoxButtons.OK, "NoSaveData");
                return;
            }

            // 발행번호
            string docId = Format.GetString(currentRow["DOCID"]);

            try
            {
                this.ShowWaitArea();

                MessageWorker messageWorker = new MessageWorker("SaveClaimManagerReg");

                messageWorker.SetBody(new MessageBody()
                {
                    { "list", ds.Tables["list"] },
                    { "fileList", ds.Tables["fileList"] },
                    { "teamActionList", ds.Tables["teamActionList"] },
                    { "docId", docId },
                    { "flag", "Upsert" }
                });

                messageWorker.Execute();

                this.ShowMessage("SuccessSave");
                SearchMainGrid(); // 재조회 
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

        /// <summary>
        /// 메인그리드 조회
        /// </summary>
        private async void SearchMainGrid()
        {
            await OnSearchAsync();
        }

        /// <summary>
        /// 상태변경 버튼 이벤트
        /// </summary>
        /// <param name="row"></param>
        /// <param name="state"></param>
        private void ProgressStateChange(DataRow row, string state)
        {
            // 선행되어야할 상태를 지나오지 않았다면 Message
            if (state.Equals("ResponseCompleted"))
            {
                if (string.IsNullOrWhiteSpace(Format.GetString(row["RECIEPTDATE"])))
                {
                    // Claim 접수가 먼저 선행되어야 합니다.
                    this.ShowMessage("ClaimMustbeFiledFirst");
                    return;
                }
            }
            else if (state.Equals("ActionCompleted"))
            {
                if (string.IsNullOrWhiteSpace(Format.GetString(row["COMPLETEDATE"])))
                {
                    // 대응완료가 먼저 선행되어야 합니다.
                    this.ShowMessage("ResponseCompletedMustbeFiledFirst");
                    return;
                }
                if (!Format.GetString(row["DEFECTPROGRESSSTATE"]).Equals("ActionCompleted"))
                {
                    //불량통지서 조치완료 상태가 아닙니다. 그래도 시정예방조치서 조치완료를 진행하시겠습니까?
                    if (this.ShowMessageBox("NotFinishDefectState", "Information", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        return;
                    }
                    // 불량통지서 진행상태가 조치완료상태이어야 시정예방 조치완료가 가능합니다.
                    //this.ShowMessage("CapaDefectStateValidation");
                    //return;
                }
            }

            // 이미 지나온 상태의 버튼을 클릭한다면 Message
            if (state.Equals("ClaimReceipt"))
            {
                if (!string.IsNullOrWhiteSpace(Format.GetString(row["RECIEPTDATE"])))
                {
                    // 이미 Claim 접수가 완료된 항목입니다.
                    this.ShowMessage("HasAlreadyBeenClaimed");
                    return;
                }
            }
            else if (state.Equals("ResponseCompleted"))
            {
                if (!string.IsNullOrWhiteSpace(Format.GetString(row["COMPLETEDATE"])))
                {
                    // 이미 대응완료가 완료된 항목입니다.
                    this.ShowMessage("HasAlreadyBeenResponseComplete");
                    return;
                }
            }
            else if (state.Equals("ActionCompleted"))
            {
                if (!string.IsNullOrWhiteSpace(Format.GetString(row["ACTIONDATE"])))
                {
                    // 이미 조치완료가 완료된 항목입니다.
                    this.ShowMessage("HasAlreadyBeenActionCompleted");
                    return;
                }
            }
            // 2022-05-11 주시은 취소 상태 추가
            else if (state.Equals("Cancel"))
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("DOCID", row["DOCID"].ToString());

                DataTable dt = SqlExecuter.Query("GetXManagerProgressState", "00001", param);

                if(!dt.Rows[0]["PROGRESSSTATE"].ToString().Equals("Cancel"))
                {
                    // X번 관리대장의 진행상태가 취소가 아닙니다.
                    this.ShowMessage("XManageStateIsNotCancel");
                    return;
                }
            }

            try
            {
                this.ShowWaitArea();

                MessageWorker messageWorker = new MessageWorker("SaveClaimManagerReg");

                messageWorker.SetBody(new MessageBody()
                {
                    { "docId", row["DOCID"] },
                    { "state", state },
                    { "flag", "StateChange" }
                });

                messageWorker.Execute();

                // 상태가 변경되었습니다.
                this.ShowMessage("StateChangeCompleted");
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

        /// <summary>
        /// 최초 조회했을 당시 데이터테이블을 반환하는 함수
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetOriginalTable(DataTable dt)
        { 
            DataTable returnDt = new DataTable();

            returnDt = dt.Clone();

            foreach(DataRow row in dt.Rows)
            {
                returnDt.ImportRow(row);
            }

            return returnDt;
        }

        /// <summary>
        /// Row데이터를 사용자가 수정하기 이전상태로 되돌리는 함수
        /// </summary>
        /// <param name="row">modified된 데이터</param>
        private void SetUnchangedRow(DataTable dt, DataRow row)
        {
            DataTable inputDt = dt.AsEnumerable().Where(r => r["DOCID"].Equals(row["DOCID"])).CopyToDataTable();

            if (dt.Rows.Count == 0) return;

            row["DOCID"] = inputDt.Rows[0]["DOCID"];
            row["CLAIMNUMBER"] = inputDt.Rows[0]["CLAIMNUMBER"];
            row["PUBLISHDATE"] = inputDt.Rows[0]["PUBLISHDATE"];
            row["DEFECTDOCID"] = inputDt.Rows[0]["DEFECTDOCID"];
            row["PROGRESSSTATE"] = inputDt.Rows[0]["PROGRESSSTATE"];
            row["PROGRESSSTATENAME"] = inputDt.Rows[0]["PROGRESSSTATENAME"];
            row["CUSTOMERID"] = inputDt.Rows[0]["CUSTOMERID"];
            row["CUSTOMERNAME"] = inputDt.Rows[0]["CUSTOMERNAME"];
            row["MODELID"] = inputDt.Rows[0]["MODELID"];
            row["CLAIMTYPE"] = inputDt.Rows[0]["CLAIMTYPE"];
            row["REQDEPARTMENTID"] = inputDt.Rows[0]["REQDEPARTMENTID"];
            row["REQUSER"] = inputDt.Rows[0]["REQUSER"];
            row["PUBLISHTYPE"] = inputDt.Rows[0]["PUBLISHTYPE"];
            row["REQCONFDATE"] = inputDt.Rows[0]["REQCONFDATE"];
            row["RECIEPTDATE"] = inputDt.Rows[0]["RECIEPTDATE"];
            row["COMPLETEDATE"] = inputDt.Rows[0]["COMPLETEDATE"];
            row["COMPLETEDAY"] = inputDt.Rows[0]["COMPLETEDAY"];
            row["ACTIONDATE"] = inputDt.Rows[0]["ACTIONDATE"];
            row["ACTIONDAY"] = inputDt.Rows[0]["ACTIONDAY"];
            row["INDATE"] = inputDt.Rows[0]["INDATE"];
            row["CONFIRMUSER"] = inputDt.Rows[0]["CONFIRMUSER"];
            row["RESPONSEDATE"] = inputDt.Rows[0]["RESPONSEDATE"];
            row["DESCRIPTION"] = inputDt.Rows[0]["DESCRIPTION"];
            row["VARIABLECOST"] = inputDt.Rows[0]["VARIABLECOST"];
            row["FIXEDCOST"] = inputDt.Rows[0]["FIXEDCOST"];
            row["XNUMBER"] = inputDt.Rows[0]["XNUMBER"];
            row["MANUFACTURENUMBER"] = inputDt.Rows[0]["MANUFACTURENUMBER"];
            row["ETMHOUR"] = inputDt.Rows[0]["ETMHOUR"];
            row["CLAIMDATE"] = inputDt.Rows[0]["CLAIMDATE"];
            row["CLAIMDESC"] = inputDt.Rows[0]["CLAIMDESC"];
            row["ISMODIFIEDFILE"] = inputDt.Rows[0]["ISMODIFIEDFILE"];

            row.AcceptChanges();
        }

        /// <summary>
        /// 시정예방조치 의뢰서 팝업호출
        /// </summary>
        /// <param name="row"></param>
        private void CallClaimManagerExcel(DataRow row)
        {
            if (row == null) return;

            // 회담희망일 yyyy-MM-dd
            string date = Format.GetString(row["REQCONFDATE"]).Substring(0, 10);

            DataTable dt = new DataTable();

            dt = (grdClaimInfo.DataSource as DataTable).Clone();
            dt.Columns.Add("REQCONFDATESTR");

            dt.ImportRow(row);
            dt.Rows[0]["REQCONFDATESTR"] = date;

            CommonFunction.ExuteExcelBindingData(Constants.ClaimRequestDoc, dt);
        }

        /// <summary>
        /// 진행현황상태의 전체갯수를 조회하여 바인딩한다.
        /// </summary>
        /// <param name="dt"></param>
        private void SetProgressStateCount()
        {
            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            values.Add("DBLINKNAME", CommonFunction.DbLinkName);

            DataTable dt = SqlExecuter.Query("GetClaimProgressStateCount", "00001", values);

            if (dt.Rows.Count < 1) return;

            txtCorrectiveActionPublish.EditValue = dt.Rows[0]["CURRENTIVEACTIONPUBLISHCOUNT"];
            txtClaimRequest.EditValue = dt.Rows[0]["CLAIMREQUESTCOUNT"];
            txtClaimReceipt.EditValue = dt.Rows[0]["CLAIMRECEIPTCOUNT"];
            txtResponseCompleted.EditValue = dt.Rows[0]["RESPONSECOMPLETEDCOUNT"];
            txtActionCompleted.EditValue = dt.Rows[0]["ACTIONCOMPLETEDCOUNT"];

            //2022 - 05 - 11 이종건 진행상태현황 COUNT 조회기간 적용
            smartLabel1.Font = new Font(smartLabel1.Font.Name, 10);
            smartLabel1.Text = txtName + "\r\n" + Conditions.GetValues()["P_DATEPERIOD_PERIODFR"].ToString().Substring(0, 10) + " ~ " + Conditions.GetValues()["P_DATEPERIOD_PERIODTO"].ToString().Substring(0, 10);


        }

        ///// <summary>
        ///// 진행현황상태의 갯수를 계산하여 바인딩한다.
        ///// </summary>
        ///// <param name="dt"></param>
        //private void SetProgressStateCount(DataTable dt)
        //{
        //    string[] codeArray = { "CorrectiveActionPublish", "ClaimRequest", "ClaimReceipt", "ResponseCompleted", "ActionCompleted" };

        //    foreach(string code in codeArray)
        //    {
        //        var data = from row in dt.AsEnumerable()
        //                   where row.Field<string>("PROGRESSSTATE") == code
        //                   select row;

        //        switch (code)
        //        {
        //            case "CorrectiveActionPublish": txtCorrectiveActionPublish.EditValue = data.Count(); break;
        //            case "ClaimRequest": txtClaimRequest.EditValue = data.Count(); break;
        //            case "ClaimReceipt": txtClaimReceipt.EditValue = data.Count(); break;
        //            case "ResponseCompleted": txtResponseCompleted.EditValue = data.Count(); break;
        //            case "ActionCompleted": txtActionCompleted.EditValue = data.Count(); break;
        //            default: break;
        //        }
        //    }
        //}
        
        #endregion
    }
}
