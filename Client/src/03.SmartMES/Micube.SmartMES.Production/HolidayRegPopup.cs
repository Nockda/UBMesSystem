#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

#endregion

namespace Micube.SmartMES.Production
{
    /// <summary>
    /// 프 로 그 램 명  : 생산관리 > 생산관리 > 생산효율 > 작업일팝업
    /// 업  무  설  명  : 작업일 팝업에서 평일/휴일/주차 등을 조회 및 수정한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-04-13
    /// 수  정  이  력  : 개발중지!!! 생산효율 메인폼으로 처리하는 방안
    /// 
    /// 
    /// </summary>
    public partial class HolidayRegPopup : SmartPopupBaseForm
    {
        public HolidayRegPopup()
        {
            InitializeComponent();

            InitializeEvent();

            InitializeControl();
            InitializeGrid();
        }

        #region 컨텐츠 영역 초기화

        private void InitializeControl()
        {
            this.dtPicker.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            dtPicker.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPicker.Properties.Mask.EditMask = "yyyy-MM";
            dtPicker.EditValue = DateTime.Now;
            dtPicker.Properties.DisplayFormat.FormatString = "yyyy-MM";
        }

        private void InitializeGrid()
        {
            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdInfo.GridButtonItem = GridButtonItem.All;

            grdInfo.View.SetSortOrder("WORKDATE");
            grdInfo.View.SetAutoFillColumn("WORKDATETYPE");

            grdInfo.View.AddDateEditColumn("WORKDATE", 100)
                .SetValidationIsRequired()
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("WORKYEAR", 80)
                .SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("WORKMONTH", 80)
                .SetIsReadOnly();
            grdInfo.View.AddComboBoxColumn("WORKDAY", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=DayCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetIsReadOnly();
            grdInfo.View.AddSpinEditColumn("WORKWEEK", 80)
                .SetIsReadOnly();
            grdInfo.View.AddComboBoxColumn("WORKDATETYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=WorkDateType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center);

            grdInfo.View.PopulateColumns();
        }

        #endregion

        #region Event
        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdInfo.View.AddingNewRow += View_AddingNewRow;
            grdInfo.View.CellValueChanged += View_CellValueChanged;

            btnSearch.Click += BtnSearch_Click;
            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            //string newDate = this.dtPicker.EditValue.ToString();
            //args.NewRow["WORKDATE"] = newDate;
        }

        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SmartBandedGridView view = sender as SmartBandedGridView;
            DataRow row = view.GetDataRow(e.RowHandle);

            if (e.Column.FieldName.Equals("WORKDATE"))
            {

                var date = Convert.ToDateTime(e.Value.ToString());

                var iYear = date.Year;
                var iMonth = date.Month;
                var sDayOfWeek = date.DayOfWeek.ToString().Substring(0, 3);

                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int iWeekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Friday);

                row["WORKYEAR"] = iYear;
                row["WORKMONTH"] = iMonth;
                row["WORKDAY"] = sDayOfWeek;
                row["WORKWEEK"] = iWeekNum;
            }

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var date = this.dtPicker.EditValue.ToString();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_YEAR", date.Split('-')[0]);
            param.Add("P_MONTH", date.Split('-')[1]);

            DataTable dtInfo = SqlExecuter.Query("GetWorkingDay", "00001", param);

            if (dtInfo.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdInfo.DataSource = dtInfo;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = System.Windows.Forms.DialogResult.No;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
