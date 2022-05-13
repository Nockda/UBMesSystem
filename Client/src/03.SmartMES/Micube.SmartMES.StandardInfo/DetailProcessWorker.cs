#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 항목관리 > 세부공정별 작업자 정보
    /// 업  무  설  명  : 공정별로 작업자를 조회, 등록, 수정, 삭제한다
    /// 생    성    자  : 한주석
    /// 생    성    일  : 2020-06-09
    /// 수  정  이  력  : 
    /// 
    /// </summary>
    public partial class DetailProcessWorker : SmartConditionBaseForm
    {
        #region Local Variables
        // TODO : 화면에서 사용할 내부 변수 추가
        private string _Text;                                       // 설명
        #endregion

        #region 생성자
        public DetailProcessWorker()
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

            // TODO : 컨트롤 초기화 로직 구성
            InitializeGrid();
        }

        /// <summary>        
        /// 코드그룹 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            // TODO : 그리드 초기화 로직 추가
            grddetailprocess.GridButtonItem = GridButtonItem.None;
            grddetailprocess.View.SetIsReadOnly();
            // 세부공정ID                            
            grddetailprocess.View.AddTextBoxColumn("SUBPROCESSSEGMENTID", 90);
            // 세부공정명
            grddetailprocess.View.AddTextBoxColumn("SUBPROCESSSEGMENTNAME", 200);
            // 인원
            grddetailprocess.View.AddTextBoxColumn("WORKERNUMBER", 70)
                .SetTextAlignment(TextAlignment.Right);
            grddetailprocess.View.PopulateColumns();

            // 세부공정ID
            grdworker.View.AddTextBoxColumn("SUBPROCESSSEGMENTID", 150)
                .SetIsHidden();
            InitializeGrid_ProcessListPopup();
            // 메인공정명
            grdworker.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 150)
                .SetIsReadOnly();
            // 유저ID
            InitializeGrid_UserListPopup();
            // 유저명
            grdworker.View.AddTextBoxColumn("USERNAME", 150)
                .SetIsReadOnly();
            //유효상태
            grdworker.View.AddComboBoxColumn("VALIDSTATE", 110
                    , new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetDefault("Valid")
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center);
            //생성자
            grdworker.View.AddTextBoxColumn("CREATOR", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //생성일시
            grdworker.View.AddTextBoxColumn("CREATEDTIME", 140)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //수정자
            grdworker.View.AddTextBoxColumn("MODIFIER", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //수정일시
            grdworker.View.AddTextBoxColumn("MODIFIEDTIME", 140)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            grdworker.View.PopulateColumns();
        }

        private void InitializeGrid_UserListPopup()
        {

            var userpopup = this.grdworker.View.AddSelectPopupColumn("USERID", 100, new SqlQuery("GetUserAreaPerson", "10001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("USERID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetValidationKeyColumn()
                .SetPopupLayoutForm(800, 600, FormBorderStyle.FixedToolWindow)
                                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                                {

                                    DataRow focusrow = grddetailprocess.View.GetFocusedDataRow();

                                    foreach (DataRow row in selectedRows)
                                    {

                                        dataGridRow["USERID"] = row["USERID"];
                                        dataGridRow["USERNAME"] = row["USERNAME"];
                                        dataGridRow["SUBPROCESSSEGMENTID"] = focusrow["SUBPROCESSSEGMENTID"];
                                        dataGridRow["VALIDSTATE"] = "Valid";

                           
                                    }
                                });

            // 팝업에서 사용할 조회조건 항목 추가
            userpopup.Conditions.AddTextBox("USERID");
            userpopup.Conditions.AddTextBox("USERNAME");
            // 팝업 그리드 설정
            userpopup.GridColumns.AddTextBoxColumn("USERID", 150);
            userpopup.GridColumns.AddTextBoxColumn("USERNAME", 200);
        }

        private void InitializeGrid_ProcessListPopup()
        {
            var userpopup = this.grdworker.View.AddSelectPopupColumn("PROCESSSEGMENTID", 100, new SqlQuery("GetMainProcessSegment", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("PROCESSSEGMENT", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetValidationKeyColumn()
                .SetPopupLayoutForm(800, 600, FormBorderStyle.FixedToolWindow)
                                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                                {
                                    foreach (DataRow row in selectedRows)
                                    {

                                        dataGridRow["PROCESSSEGMENTID"] = row["PROCESSSEGMENTID"];
                                        dataGridRow["PROCESSSEGMENTNAME"] = row["PROCESSSEGMENTNAME"];
          
                                    }
                                });

            // 팝업에서 사용할 조회조건 항목 추가
            userpopup.Conditions.AddTextBox("PROCESSSEGMENTID");
            userpopup.Conditions.AddTextBox("PROCESSSEGMENTNAME");
            // 팝업 그리드 설정
            userpopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150);
            userpopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);
        }
        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            this.Load += DetailProcessWorker_LoadAsync;
           grddetailprocess.View.FocusedRowChanged += View_FocusedRowChanged;
        }

        private async void DetailProcessWorker_LoadAsync(object sender, EventArgs e)
        {
            await OnSearchAsync();
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            grdProcessFocusedRowChanged();
        }
        #endregion

        #region 툴바
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            // TODO : 저장 Rule 변경
            DataTable changed = grdworker.GetChangedRows();
            ExecuteRule("SaveProcessWorker", changed);
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
            values.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable dtCodeClass = SqlExecuter.Query("GetSubProcess", "00001", values);

            if (dtCodeClass.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grddetailprocess.DataSource = dtCodeClass;
            grdProcessFocusedRowChanged();
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
            // TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
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
            grdworker.View.CheckValidation();
            DataTable changed = grdworker.GetChangedRows();
            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }
        #endregion

        #region Private Function
        // TODO : 화면에서 사용할 내부 함수 추가
        /// <summary>
        /// 마스터 정보를 조회한다.
        /// </summary>
        private void grdProcessFocusedRowChanged()
        {
            DataRow dr = grddetailprocess.View.GetFocusedDataRow();
            var values = Conditions.GetValues();
            Dictionary<string, object> param = new Dictionary<string, object>();
            if (!values["P_PROCESSSEGMENT"].Equals("*"))
            {
                grddetailprocess.View.FocusedRowHandle = 0;
                dr = grddetailprocess.View.GetFocusedDataRow();
                param.Add("P_PROCESSSEGMENT", dr["SUBPROCESSSEGMENTID"]);
            }
            else
            {
                param.Add("P_PROCESSSEGMENT", dr["SUBPROCESSSEGMENTID"]);
            }

            param.Add("p_validstate", values["P_VALIDSTATE"]);
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable areaworker = SqlExecuter.Query("GetUserProcessPerson", "00001", param);
            grdworker.DataSource = areaworker;
        }
        #endregion
    }
}