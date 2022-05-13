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

namespace Micube.SmartMES.SystemManagement
{
    /// <summary>
    /// 프 로 그 램 명  : 시스템관리 > 모니터링 > TABLE RAW 데이터 조회
    /// 업  무  설  명  : 시스템에 있는 테이블 Raw Data를 조회한다.
    /// 생    성    자  : 유태근
    /// 생    성    일  : 2020-07-10
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class TableRawDataSearch : SmartConditionBaseForm
    {
        #region Local Variables

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public TableRawDataSearch()
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
        }

        /// <summary>        
        /// 초기 그리드 설정
        /// </summary>
        private void InitializeGrid()
        {
            grdRawData.GridButtonItem = GridButtonItem.Export;
            grdRawData.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdRawData.View.SetIsReadOnly();
            grdRawData.View.OptionsNavigation.AutoMoveRowFocus = false;
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            grdRawData.View.RowStyle += View_RowStyle;
        }

        /// <summary>
        /// 포커스 받은 Row 색깔 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            int rowIndex = grdRawData.View.FocusedRowHandle;

            if (rowIndex == e.RowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(254, 254, 16);
                e.HighPriority = true;
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

            DataTable changed = grdRawData.GetChangedRows();

            ExecuteRule("SaveCodeClass", changed);
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
            values.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);

            
            DataTable dt = await SqlExecuter.ProcedureAsync("USP_GETTABLERAWDATA", values);

            if (dt.Rows.Count < 1)
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            InitializeGridColumnAndDataBinding(dt);
            grdRawData.View.FocusedRowHandle = -1;

        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // TODO : 조회조건 추가 구성이 필요한 경우 사용
            InitializeConditionTablePopup();
            InitializeConditionColumnPopup();
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            DateTime today = DateTime.Now.Date;
            DateTime fisrtDay = today.AddDays(1 - today.Day); // 현재월의 첫째날
            DateTime lastDay = fisrtDay.AddMonths(1).AddDays(-1); // 현재월의 마지막날

            // TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
            SmartPeriodEdit fromDate = Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD");
            fromDate.datePeriodFr.EditValue = fisrtDay;

            SmartPeriodEdit toDate = Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD");
            toDate.datePeriodTo.EditValue = lastDay;

            //SmartSelectPopupEdit tablePopup = Conditions.GetControl<SmartSelectPopupEdit>("P_TABLEID");
            //SmartSelectPopupEdit columnPopup = Conditions.GetControl<SmartSelectPopupEdit>("P_COLUMNID");
        }

        /// <summary>
        /// 테이블 조회조건 팝업
        /// </summary>
        private void InitializeConditionTablePopup()
        {
            // 팝업 컬럼설정
            var conditionPopup = Conditions.AddSelectPopup("p_tableId", new SqlQuery("GetTableList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "TABLENAME", "TABLEID")
               .SetPopupLayout("TABLE", PopupButtonStyles.Ok_Cancel, true, true)
               .SetPopupLayoutForm(600, 800)
               .SetLabel("TABLE")
               .SetPopupResultCount(1)
               .SetPosition(1.1)
               .SetValidationKeyColumn()
               .SetPopupAutoFillColumns("TABLEID");

            // 팝업 조회조건
            conditionPopup.Conditions.AddTextBox("TABLEIDNAME");

            // 팝업 그리드
            conditionPopup.GridColumns.AddTextBoxColumn("TABLEID", 200);
            conditionPopup.GridColumns.AddTextBoxColumn("TABLENAME", 200);
        }

        /// <summary>
        /// 컬럼 조회조건 팝업
        /// </summary>
        private void InitializeConditionColumnPopup()
        {
            // 팝업 컬럼설정
            var conditionPopup = Conditions.AddSelectPopup("p_columnId", new SqlQuery("GetTableColumnList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "COLUMNNAME", "COLUMNID")
               .SetPopupLayout("COLUMN", PopupButtonStyles.Ok_Cancel, true, true)
               .SetPopupLayoutForm(600, 800)
               .SetLabel("COLUMN")
               .SetPopupResultCount(0)
               .SetPosition(1.2)
               .SetPopupAutoFillColumns("COLUMNID")
               .SetRelationIds("p_tableId");

            // 팝업 조회조건
            conditionPopup.Conditions.AddTextBox("COLUMNIDNAME");

            // 팝업 그리드
            conditionPopup.GridColumns.AddTextBoxColumn("COLUMNID", 200);
            conditionPopup.GridColumns.AddTextBoxColumn("COLUMNNAME", 200);
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
            grdRawData.View.CheckValidation();

            DataTable changed = grdRawData.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        /// <summary>
        /// 조회해온 데이터 컬럼 세팅 및 데이터 바인딩 한다.
        /// </summary>
        private void InitializeGridColumnAndDataBinding(DataTable dt)
        {
            grdRawData.View.ClearColumns();


            var values = Conditions.GetValues();

            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic.Add("TABLEID", Format.GetTrimString(values["P_TABLEID"]));
            dic.Add("COLUMNID", Format.GetTrimString(values["P_COLUMNID"]));

            DataTable dtCol = SqlExecuter.Query("GetColumnDescription", "00001",dic);

            Dictionary<string, string> dicCol = dtCol.AsEnumerable().ToDictionary<DataRow,string,string>(c=> c.Field<string>("NAME"),C=> C.Field<string>("VALUE"));
            foreach (DataColumn col in dt.Columns)
            {
                string lang = string.Empty;
                if(dicCol.ContainsKey(col.ColumnName))
                {
                    lang = Format.GetTrimString(dicCol[col.ColumnName]);
                }
                else
                {
                    lang = col.ColumnName;
                }
                grdRawData.View.AddTextBoxColumn(col.ColumnName).SetLabel(lang);
            }

            grdRawData.View.PopulateColumns();

            grdRawData.DataSource = dt;

            grdRawData.View.BestFitColumns();
        }

        #endregion
    }
}