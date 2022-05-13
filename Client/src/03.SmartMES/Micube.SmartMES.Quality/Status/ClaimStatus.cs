#region using

using DevExpress.XtraGrid.Views.Grid;
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
    /// 프 로 그 램 명  : 품질관리 > 항목 > 클레임 발생 현황
    /// 업  무  설  명  : 클레임 발생 진행현황 조회 한다.
    /// 생    성    자  : 강유라
    /// 생    성    일  : 2020-06-02
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ClaimStatus : SmartConditionBaseForm
    {
        #region Local Variables

        // TODO : 화면에서 사용할 내부 변수 추가
        string thisYear = "";//ex) 조회년도 2019년일때 2019 7월1~ 
        string nextYear = "";//2020 6월 30일
        string yearDic = Language.Get("YEAR");


        #endregion

        #region 생성자

        public ClaimStatus()
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
            
        }

        /// <summary>        
        /// 코드그룹 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid(string FYear, string sYear)
        {
            // TODO : 그리드 초기화 로직 추가           
            grdClaimStatus.GridButtonItem = GridButtonItem.Export;
            grdClaimStatus.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdClaimStatus.View.OptionsView.AllowCellMerge = true;
            grdClaimStatus.View.SetIsReadOnly();
            grdClaimStatus.View.ClearColumns();

            var type = grdClaimStatus.View.AddGroupColumn("");
            type.AddComboBoxColumn("MAIN", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=XmCapaMainCategory", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetLabel("TYPE");
            type.AddComboBoxColumn("DATATYPE", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=XmCapaDataType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetLabel("TYPE");

            //전년도 하반기
            // TODO : 조회조건에따라 그룹 캡션 변경
            var secondHalf = grdClaimStatus.View.AddGroupColumn(FYear);//조회조건에따라 변경
            secondHalf.AddTextBoxColumn("MON7",90).SetLabel("JULY").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);
            secondHalf.AddTextBoxColumn("MON8",90).SetLabel("AUGUST").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);
            secondHalf.AddTextBoxColumn("MON9",90).SetLabel("SEPTEMBER").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);
            secondHalf.AddTextBoxColumn("MON10",90).SetLabel("OCTOBER").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);
            secondHalf.AddTextBoxColumn("MON11",90).SetLabel("NOVEMBER").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);
            secondHalf.AddTextBoxColumn("MON12",90).SetLabel("DECEMBER").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);

            //올해 상반기
            // TODO : 조회조건에따라 그룹 캡션 변경
            var firstHalf = grdClaimStatus.View.AddGroupColumn(sYear);//조회조건에따라 변경
            firstHalf.AddTextBoxColumn("MON1",90).SetLabel("JANUARY").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);
            firstHalf.AddTextBoxColumn("MON2",90).SetLabel("FEBURARY").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);
            firstHalf.AddTextBoxColumn("MON3",90).SetLabel("MARCH").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);
            firstHalf.AddTextBoxColumn("MON4",90).SetLabel("APRIL").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);
            firstHalf.AddTextBoxColumn("MON5",90).SetLabel("MAY").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);
            firstHalf.AddTextBoxColumn("MON6",90).SetLabel("JUNE").SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);

            //합계
            var sum = grdClaimStatus.View.AddGroupColumn("");
            sum.AddTextBoxColumn("SUM",90).SetDisplayFormat("#,##0.#####", MaskTypes.Numeric); ;
 
            grdClaimStatus.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // TODO : 화면에서 사용할 이벤트 추가
            Load += (s, e) =>
              {
                  InitializeGrid(thisYear, nextYear);
              };
            //특정 컬럼만 Merge하는 이벤트 
            grdClaimStatus.View.CellMerge += View_CellMerge;
        }

        /// <summary>
        /// CellMerge이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == "MAIN")
            {
                string str1 = view.GetRowCellDisplayText(e.RowHandle1, e.Column);
                string str2 = view.GetRowCellDisplayText(e.RowHandle2, e.Column);
                e.Merge = (str1 == str2);
            }
            else
            {
                e.Merge = false;
            }

            e.Handled = true;
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
            //DataTable changed = grdClaimStatus.GetChangedRows();

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

            //조회조건 2020년일 때 : 2020-7-01~ 2021-6-30 까지
            //AND CONVERT(DATE,'2020-6-30') < CONVERT(DATE,CP.PUBLISHDATE) --현재 년도 7월~ 내년 6월까지
            //AND CONVERT(DATE, CP.PUBLISHDATE) <= CONVERT(DATE, '2021-6-30')
            DateTime condYear = Convert.ToDateTime(Conditions.GetValue("p_year"));

            thisYear = Format.GetString(condYear.Year);
            nextYear = Format.GetString(condYear.Year + 1);

            string fromDate = thisYear + "-06-30";
            string toDate = nextYear + "-06-30";

            values.Add("P_FROMDATE", fromDate);
            values.Add("P_TODATE", toDate);

            thisYear = Format.GetString(condYear.Year) + yearDic;
            nextYear = Format.GetString(condYear.Year + 1) + yearDic;

            DataTable dt = await SqlExecuter.QueryAsync("SelectXmCapaStatus", "00001", values);

            if (dt.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            InitializeGrid(thisYear, nextYear);

            grdClaimStatus.DataSource = dt;
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

            thisYear = Format.GetString(DateTime.Now.Year) + yearDic;
            nextYear = Format.GetString(DateTime.Now.Year + 1) + yearDic;

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
            grdClaimStatus.View.CheckValidation();

            DataTable changed = grdClaimStatus.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function
        // TODO : 화면에서 사용할 내부 함수 추가

        #endregion
    }
}