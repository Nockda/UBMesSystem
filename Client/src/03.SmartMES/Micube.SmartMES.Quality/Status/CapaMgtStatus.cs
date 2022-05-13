#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

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

namespace Micube.SmartMES.Quality
{
    /// <summary>
    /// 프 로 그 램 명  : 품질관리 > 항목 > 시정예방조치 진행현황
    /// 업  무  설  명  : 시정예방조치 진행현황 조회 한다.
    /// 생    성    자  : 강유라
    /// 생    성    일  : 2020-06-02
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class CapaMgtStatus : SmartConditionBaseForm
    {
        #region Local Variables

        // TODO : 화면에서 사용할 내부 변수 추가
        string caption = Language.Get("CAPASTATUSTEAM");
        #endregion

        #region 생성자

        public CapaMgtStatus()
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
            SetGridCaption(caption);
            grdCapaStatus.GridButtonItem = GridButtonItem.Export;
            grdCapaStatus.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdCapaStatus.View.SetIsReadOnly();

            var type = grdCapaStatus.View.AddGroupColumn("");
            type.AddTextBoxColumn("TYPE", 150).SetLabel("TYPE");
            type.AddTextBoxColumn("TYPENAME", 150).SetLabel("TYPE");

            //7월
            var july = grdCapaStatus.View.AddGroupColumn("JULY");
            july.AddTextBoxColumn("OCCUR7", 40).SetLabel("OCCUR");
            july.AddTextBoxColumn("PROGRESS7", 40).SetLabel("PROGRESS");
            july.AddTextBoxColumn("COMPLETE7", 40).SetLabel("COMPLETE");

            //8월
            var august = grdCapaStatus.View.AddGroupColumn("AUGUST");
            august.AddTextBoxColumn("OCCUR8", 40).SetLabel("OCCUR");
            august.AddTextBoxColumn("PROGRESS8", 40).SetLabel("PROGRESS");
            august.AddTextBoxColumn("COMPLETE8", 40).SetLabel("COMPLETE");

            //9월
            var september = grdCapaStatus.View.AddGroupColumn("SEPTEMBER");
            september.AddTextBoxColumn("OCCUR9", 40).SetLabel("OCCUR");
            september.AddTextBoxColumn("PROGRESS9", 40).SetLabel("PROGRESS");
            september.AddTextBoxColumn("COMPLETE9", 40).SetLabel("COMPLETE");

            //10월
            var october = grdCapaStatus.View.AddGroupColumn("OCTOBER");
            october.AddTextBoxColumn("OCCUR10", 40).SetLabel("OCCUR");
            october.AddTextBoxColumn("PROGRESS10", 40).SetLabel("PROGRESS");
            october.AddTextBoxColumn("COMPLETE10", 40).SetLabel("COMPLETE");

            //11월
            var november = grdCapaStatus.View.AddGroupColumn("NOVEMBER");
            november.AddTextBoxColumn("OCCUR11", 40).SetLabel("OCCUR");
            november.AddTextBoxColumn("PROGRESS11", 40).SetLabel("PROGRESS");
            november.AddTextBoxColumn("COMPLETE11", 40).SetLabel("COMPLETE");

            //12월
            var december = grdCapaStatus.View.AddGroupColumn("DECEMBER");
            december.AddTextBoxColumn("OCCUR12", 40).SetLabel("OCCUR");
            december.AddTextBoxColumn("PROGRESS12", 40).SetLabel("PROGRESS");
            december.AddTextBoxColumn("COMPLETE12", 40).SetLabel("COMPLETE");

            //1월
            var january = grdCapaStatus.View.AddGroupColumn("JANUARY");
            january.AddTextBoxColumn("OCCUR1", 40).SetLabel("OCCUR");
            january.AddTextBoxColumn("PROGRESS1", 40).SetLabel("PROGRESS");
            january.AddTextBoxColumn("COMPLETE1", 40).SetLabel("COMPLETE");

            //2월
            var feburary = grdCapaStatus.View.AddGroupColumn("FEBURARY");
            feburary.AddTextBoxColumn("OCCUR2", 40).SetLabel("OCCUR");
            feburary.AddTextBoxColumn("PROGRESS2", 40).SetLabel("PROGRESS");
            feburary.AddTextBoxColumn("COMPLETE2", 40).SetLabel("COMPLETE");

            //3월
            var march = grdCapaStatus.View.AddGroupColumn("MARCH");
            march.AddTextBoxColumn("OCCUR3", 40).SetLabel("OCCUR");
            march.AddTextBoxColumn("PROGRESS3", 40).SetLabel("PROGRESS");
            march.AddTextBoxColumn("COMPLETE3", 40).SetLabel("COMPLETE");

            //4월
            var april = grdCapaStatus.View.AddGroupColumn("APRIL");
            april.AddTextBoxColumn("OCCUR4", 40).SetLabel("OCCUR");
            april.AddTextBoxColumn("PROGRESS4", 40).SetLabel("PROGRESS");
            april.AddTextBoxColumn("COMPLETE4", 40).SetLabel("COMPLETE");

            //5월
            var may = grdCapaStatus.View.AddGroupColumn("MAY");
            may.AddTextBoxColumn("OCCUR5", 40).SetLabel("OCCUR");
            may.AddTextBoxColumn("PROGRESS5", 40).SetLabel("PROGRESS");
            may.AddTextBoxColumn("COMPLETE5", 40).SetLabel("COMPLETE");

            //6월
            var june = grdCapaStatus.View.AddGroupColumn("JUNE");
            june.AddTextBoxColumn("OCCUR6", 40).SetLabel("OCCUR");
            june.AddTextBoxColumn("PROGRESS6", 40).SetLabel("PROGRESS");
            june.AddTextBoxColumn("COMPLETE6", 40).SetLabel("COMPLETE");

            //합계
            var sum = grdCapaStatus.View.AddGroupColumn("SUM");
            sum.AddTextBoxColumn("OCCUR", 40).SetLabel("OCCUR");
            sum.AddTextBoxColumn("PROGRESS", 40).SetLabel("PROGRESS");
            sum.AddTextBoxColumn("COMPLETE", 40).SetLabel("COMPLETE");

            grdCapaStatus.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // TODO : 화면에서 사용할 이벤트 추가
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
            //DataTable changed = grdCapaStatus.GetChangedRows();

            //ExecuteRule("SaveCodeClass", changed);
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
            string queryId = "SelectCapaMgtStatusTeam";
            caption = Language.Get("CAPASTATUSTEAM");

            //조회조건 2020년일 때 : 2020-7-01~ 2021-6-30 까지
            //AND CONVERT(DATE,'2020-6-30') < CONVERT(DATE,CP.PUBLISHDATE) --현재 년도 7월~ 내년 6월까지
            //AND CONVERT(DATE, CP.PUBLISHDATE) <= CONVERT(DATE, '2021-6-30')
            DateTime condYear = Convert.ToDateTime(Conditions.GetValue("p_year"));
            string fromDate = Format.GetString(condYear.Year) + "-06-30";
            string toDate = Format.GetString(condYear.Year + 1) + "-06-30";

            values.Add("P_FROMDATE", fromDate);
            values.Add("P_TODATE", toDate);

            //조회조건에 따라 다른 쿼리 호출
            switch (Format.GetString(values["P_CONDTYPE"]))
            {
                case "Team":
                    queryId = "SelectCapaMgtStatusTeam";
                    caption = Language.Get("CAPASTATUSTEAM");
                    break;

                case "ReasonTeam":
                    queryId = "SelectCapaMgtStatusReasonTeam";
                    caption = Language.Get("CAPASTATUSREASONTEAM");
                    break;

                case "DefectType":
                    queryId = "SelectCapaMgtStatusDefectType";
                    caption = Language.Get("CAPASTATUSDEFECTTYPE");
                    break;

                case "ReasonType":
                    queryId = "SelectCapaMgtStatusReasonType";
                    caption = Language.Get("CAPASTATUSREASONTYPE");
                    break;
            }

            SetGridCaption(caption);
            DataTable dt = await SqlExecuter.QueryAsync(queryId, "00001", values);

            if (dt.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdCapaStatus.DataSource = dt;
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // TODO : 조회조건 추가 구성이 필요한 경우 사용
            // SmartDateEdit date = Conditions.AddDateEdit("P_YEAR");

        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            // TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
            SmartDateEdit dateEdit = Conditions.GetControl<SmartDateEdit>("p_year");
            dateEdit.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            dateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateEdit.Properties.Mask.EditMask = "yyyy";
            dateEdit.EditValue = DateTime.Now;

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
            grdCapaStatus.View.CheckValidation();

            DataTable changed = grdCapaStatus.GetChangedRows();

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
        /// 그리드 캡션 변경 함수
        /// </summary>
        private void SetGridCaption(string caption)
        {
            grdCapaStatus.Caption = caption;
        }
        #endregion
    }
}