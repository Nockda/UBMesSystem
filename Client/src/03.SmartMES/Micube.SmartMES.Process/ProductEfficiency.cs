#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

#endregion

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 공정작업 > 근무시간관리
    /// 업  무  설  명  : 생산효율을 조회 및 수정한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-19
    /// 수  정  이  력  : 2020-06-10 | scmo
    /// 
    /// 
    /// </summary>
    public partial class ProductEfficiency : SmartConditionBaseForm
    {
        #region Local Variables
        private string _currentStatus;
        #endregion

        public ProductEfficiency()
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

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeList();

            //LoadDataManageGrid();
        }

        /// <summary>        
        /// 그리드를 초기화한다.
        /// </summary>
        private void InitializeList()
        {
            // 그리드 초기화
            grdInfo.GridButtonItem = GridButtonItem.Export;
            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdInfo.View.UseBandHeaderOnly = true;
            grdInfo.View.OptionsView.AllowCellMerge = true;

            grdInfo.View.SetSortOrder("WORKDATE", DevExpress.Data.ColumnSortOrder.Ascending);

            grdInfo.View.AddTextBoxColumn("WEEKNUMBER", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("WORKDATE", 90)
                .SetValidationIsRequired()
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("TEAMID", 80)
                .SetValidationIsRequired()
                .SetLabel("THISTEAM")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden()
                .SetIsReadOnly();
            grdInfo.View.AddComboBoxColumn("DAYOFWEEK", 40, new SqlQuery("GetCodeList", "00001", "CODECLASSID=DayCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetIsReadOnly();
            var gDayStd = grdInfo.View.AddGroupColumn("WORKHOURSTANDARD");
            gDayStd.AddSpinEditColumn("STANDWORKHOUR", 60)
                .SetDisplayFormat("#,##0.0");
            gDayStd.AddSpinEditColumn("STANDTRANSHOUR", 60)
                .SetDisplayFormat("#,##0.0");
            gDayStd.AddSpinEditColumn("STANDWORKERCNT", 60);

            var gWorkTime = grdInfo.View.AddGroupColumn("WORKHOUR");
            gWorkTime.AddSpinEditColumn("WORKHOUR", 60)
                .SetLabel("STANDWORKHOUR")
                .SetIsReadOnly()
                .SetDisplayFormat("#,##0.0");
            gWorkTime.AddSpinEditColumn("TRANSHOUR", 60)
                .SetLabel("STANDTRANSHOUR")
                .SetIsReadOnly()
                .SetDisplayFormat("#,##0.0");
            gWorkTime.AddSpinEditColumn("APPHOUR", 60)
                .SetDisplayFormat("#,##0.0");
            gWorkTime.AddSpinEditColumn("SUPPORTHOUR", 60)
                .SetDisplayFormat("#,##0.0");
            gWorkTime.AddSpinEditColumn("EXTENDHOUR", 60)
                .SetDisplayFormat("#,##0.0");

            var gNonWork = grdInfo.View.AddGroupColumn("NONWORKHOUR");
            gNonWork.AddSpinEditColumn("HOLIDAYHOUR", 60)
                .SetLabel("HOLIDAY")
                .SetDisplayFormat("#,##0.0");
            gNonWork.AddSpinEditColumn("EDUCATIONHOUR", 60)
                .SetLabel("EDUCATION")
                .SetDisplayFormat("#,##0.0");
            gNonWork.AddSpinEditColumn("TRAININGHOUR", 60)
                .SetLabel("TRAINING")
                .SetDisplayFormat("#,##0.0");
            gNonWork.AddSpinEditColumn("DISPATCHHOUR", 60)
                .SetLabel("DISPATCH")
                .SetDisplayFormat("#,##0.0");
            gNonWork.AddTextBoxColumn("DESCRIPTION", 160);
            grdInfo.View.AddSpinEditColumn("TOTALWORKHOUR", 90)
                .SetIsReadOnly()
                .SetDisplayFormat("#,##0.0");
            grdInfo.View.AddSpinEditColumn("TOTALAVAILABLEHOUR", 90)
                .SetIsReadOnly()
                .SetDisplayFormat("#,##0.0");
            grdInfo.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdInfo.View.PopulateColumns();
        }

        #endregion

        #region Event
        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        private void InitializeEvent()
        {
            grdInfo.View.CellValueChanged += View_CellValueChanged;
            grdInfo.View.CellMerge += View_CellMerge;
            grdInfo.View.RowCellStyle += View_RowCellStyle;
            grdInfo.View.ShowingEditor += View_ShowingEditor;
        }

        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SmartBandedGridView view = sender as SmartBandedGridView;
            DataRow row = view.GetDataRow(e.RowHandle);

            decimal dSTANDWORKHOUR = Convert.ToDecimal(row["STANDWORKHOUR"]);
            decimal dSTANDTRANSHOUR = Convert.ToDecimal(row["STANDTRANSHOUR"]);
            decimal dSTANDWORKERCNT = Convert.ToDecimal(row["STANDWORKERCNT"]);
            decimal dAPPHOUR = dSTANDWORKHOUR / 2;
            decimal dWORKHOUR = dSTANDWORKHOUR * dSTANDWORKERCNT;
            decimal dTRANSHOUR = dSTANDTRANSHOUR * dSTANDWORKERCNT;
            decimal dTOTALWORKHOUR = Math.Max(0, dWORKHOUR - dAPPHOUR + Convert.ToDecimal(row["EXTENDHOUR"]) + Convert.ToDecimal(row["SUPPORTHOUR"]) - Convert.ToDecimal(row["DISPATCHHOUR"]));
            decimal dTOTALAVAILABLEHOUR = Math.Max(0, dTOTALWORKHOUR - dTRANSHOUR - (Convert.ToDecimal(row["HOLIDAYHOUR"]) + Convert.ToDecimal(row["EDUCATIONHOUR"]) + Convert.ToDecimal(row["TRAININGHOUR"])));

            row["WORKHOUR"] = dWORKHOUR;
            row["TRANSHOUR"] = dTRANSHOUR;
            row["APPHOUR"] = dAPPHOUR;
            row["TOTALWORKHOUR"] = dTOTALWORKHOUR;
            row["TOTALAVAILABLEHOUR"] = dTOTALAVAILABLEHOUR;
        }

        /// <summary>
        /// WEEKNUMBER 컬럼 셀머지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == "WEEKNUMBER")
            {
                int val1 = (int)view.GetRowCellValue(e.RowHandle1, e.Column);
                int val2 = (int)view.GetRowCellValue(e.RowHandle2, e.Column);

                e.Merge = (val1 == val2);
            }
            else if (e.Column.FieldName == "TEAMID")
            {
                string sval1 = (string)view.GetRowCellValue(e.RowHandle1, e.Column);
                string sval2 = (string)view.GetRowCellValue(e.RowHandle2, e.Column);

                e.Merge = (sval1 == sval2);
            }
            else
            {
                e.Merge = false;
            }

            e.Handled = true;
        }

        private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (grdInfo.View.GetDataRow(e.RowHandle).GetString("DAYOFWEEK").Equals("Sat") || grdInfo.View.GetDataRow(e.RowHandle).GetString("DAYOFWEEK").Equals("Sun"))
            {
                if(e.Column.FieldName == "DAYOFWEEK" || e.Column.FieldName == "WORKDATE")
                    e.Appearance.ForeColor = Color.FromArgb(30, 255, 0, 0);
            }
            string sDate = grdInfo.View.GetDataRow(e.RowHandle).GetString("WORKDATE");
            if (Convert.ToDateTime(sDate).ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                e.Appearance.FontStyleDelta = FontStyle.Bold;
                e.Appearance.BackColor = Color.FromArgb(30, 0, 255, 0);
            }
        }

        private void View_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataRow row = grdInfo.View.GetFocusedDataRow();
            if(Convert.ToDateTime(row["WORKDATE"]) > DateTime.Now)
            {
                e.Cancel = true;
            }
        }

        #endregion


        #region ToolBar

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = new DataTable();

            if (_currentStatus == "added")
            {
                changed = grdInfo.DataSource as DataTable;
                changed.Columns.Add("_STATE_", typeof(String));
            }
            else if (_currentStatus == "modified")
            {
                changed = grdInfo.GetChangedRows();
            }

            for (int rowIndex = 0; rowIndex < changed.Rows.Count; rowIndex++)
            {
                changed.Rows[rowIndex]["_STATE_"] = _currentStatus;
            }

            ExecuteRule("SaveProdEfficiency", changed);
        }

        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            base.OnToolbarClick(sender, e);

            //SmartButton btn = sender as SmartButton;

            //if (btn.Name.ToString().Equals("Holiday"))
            //{
            //    btnHoliday_Click(null, null);
            //}
        }

        #endregion

        #region 검색
        //// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();

            int iYear = Convert.ToInt32(values["P_DATETIME"].ToString().Split('-')[0]);
            int iMonth = Convert.ToInt32(values["P_DATETIME"].ToString().Split('-')[1]);
            string sTeam = values["P_TEAM"].ToString();

            values.Add("P_YEAR", iYear);
            values.Add("P_MONTH", iMonth);
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtInfo = await QueryAsync("GetProdEfficiency", "00001", values);

            _currentStatus = "modified";

            //테이블 내 조회되지 않는 경우, 임시로 한달치 데이터 생성.
            if (dtInfo.Rows.Count < 1)
            {
                CultureInfo ciCurr = CultureInfo.CurrentCulture;

                int dayInMonth = DateTime.DaysInMonth(iYear, iMonth);


                _currentStatus = "added";

                for (int i = 0; i < dayInMonth; i++)
                {
                    DataRow newRow = dtInfo.NewRow();

                    var date = Convert.ToDateTime($"{iYear}-{iMonth.ToString("00")}-{(i + 1).ToString("00")}");

                    int iWeekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Friday);
                    string sDayOfWeek = date.DayOfWeek.ToString().Substring(0, 3);

                    newRow["WORKDATE"] = date.ToString("yyyy-MM-dd");
                    newRow["TEAMID"] = sTeam;
                    newRow["WORKYEAR"] = iYear;
                    newRow["WORKMONTH"] = iMonth;
                    newRow["WEEKNUMBER"] = iWeekNum;
                    newRow["DAYOFWEEK"] = sDayOfWeek;
                    if(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        newRow["STANDWORKHOUR"] = 0;
                        newRow["STANDTRANSHOUR"] = 0;
                    }
                    else
                    {
                        newRow["STANDWORKHOUR"] = 8;
                        newRow["STANDTRANSHOUR"] = 1;
                    }
                    newRow["STANDWORKERCNT"] = 0;
                    newRow["WORKHOUR"] = 0;
                    newRow["TRANSHOUR"] = 0;
                    newRow["APPHOUR"] = 0;
                    newRow["SUPPORTHOUR"] = 0;
                    newRow["EXTENDHOUR"] = 0;
                    newRow["HOLIDAYHOUR"] = 0;
                    newRow["EDUCATIONHOUR"] = 0;
                    newRow["TRAININGHOUR"] = 0;
                    newRow["DISPATCHHOUR"] = 0;
                    newRow["TOTALWORKHOUR"] = 0;
                    newRow["TOTALAVAILABLEHOUR"] = 0;

                    dtInfo.Rows.Add(newRow);


                }
            }

            grdInfo.DataSource = dtInfo;
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

            SmartDateEdit dateEdit = Conditions.GetControl<SmartDateEdit>("P_DATETIME");
            dateEdit.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            dateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateEdit.Properties.Mask.EditMask = "yyyy-MM";
            dateEdit.EditValue = DateTime.Now;

            // 악세서리팀 제외하여 조회
            SqlQuery condition = new SqlQuery("GetTeamList", "00002", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_NOTIN=*");
            DataTable conditionTable = condition.Execute();
            this.Conditions.GetControl<SmartComboBox>("p_team").DataSource = conditionTable;
        }

        #endregion
    }
}
