#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;

#endregion

namespace Micube.SmartMES.Equipment
{
    /// <summary>
    /// 프 로 그 램 명  : 설비관리 > 설비점검 > 설비일상점검모니터링
    /// 업  무  설  명  : 설비일상점검표를 모니터링한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2020-06-30
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class EquipDailyCheckMonitoring : SmartConditionBaseForm
    {
        public EquipDailyCheckMonitoring()
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

            this.smartSpliterContainer1.SplitterPosition = 600;

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeList();
            InitializeDetail();
        }

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeList()
        {
            grdList.GridButtonItem = GridButtonItem.Export;
            grdList.View.SetIsReadOnly();

            grdList.View.SetSortOrder("EQUIPMENTCLASSID");

            grdList.View.AddTextBoxColumn("EQUIPMENTCLASSID", 80)
                .SetIsHidden();
            grdList.View.AddComboBoxColumn("EQUIPMENTCLASSID", 120, new SqlQuery("GetEquipmentClassList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "EQUIPMENTCLASSNAME", "EQUIPMENTCLASSID")
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("EQUIPMENTCLASSNAME");
            grdList.View.AddTextBoxColumn("EQUIPMENTID", 80)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("EQUIPMENTID", 120, new SqlQuery("GetComboEquipment", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("EQUIPMENTNAME");
            grdList.View.AddSpinEditColumn("OTOTAL", 70)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("TOTALCHECK");
            grdList.View.AddSpinEditColumn("TTOTAL", 70)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("PARTCHECK");
            grdList.View.AddSpinEditColumn("XTOTAL", 70)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("NONCHECK");
            grdList.View.AddTextBoxColumn("DAY01", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY02", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY03", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY04", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY05", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY06", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY07", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY08", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY09", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY10", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY11", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY12", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY13", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY14", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY15", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY16", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY17", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY18", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY19", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY20", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY21", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY22", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY23", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY24", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY25", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY26", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY27", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY28", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY29", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY30", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DAY31", 40)
                .SetTextAlignment(TextAlignment.Center);

            grdList.View.PopulateColumns();
        }

        private void InitializeDetail()
        {
            grdDetail.GridButtonItem = GridButtonItem.Export;
            grdDetail.View.SetIsReadOnly();

            grdDetail.View.SetSortOrder("SEQ");
            grdDetail.View.SetAutoFillColumn("OCCURDESCRIPTION");

            grdDetail.View.AddTextBoxColumn("SEQ")
                .SetIsHidden();
            grdDetail.View.AddTextBoxColumn("EQUIPMENTID")
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddComboBoxColumn("EQUIPMENTID", 120, new SqlQuery("GetComboEquipment", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("EQUIPMENTNAME");
            grdDetail.View.AddDateEditColumn("OCCURDATE", 100)
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("OCCURDESCRIPTION", 200);

            grdDetail.View.PopulateColumns();
        }

        #endregion

        #region Event
        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdList.View.RowCellStyle += ListView_RowCellStyle;
        }

        private void ListView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName.Contains("DAY"))
                e.Column.AppearanceCell.Reset();

            string sDay = e.Column.FieldName;

            if (sDay.Substring(0, 3) == "DAY")
            {
                sDay = sDay.Substring(3);

                var values = Conditions.GetValues();
                DateTime date = Convert.ToDateTime(values["P_YEARMONTH"].ToString());
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                int iYear = date.Year;
                int iMonth = date.Month;
                int iDay = Convert.ToInt32(sDay);

                if (iDay <= lastDayOfMonth.Day)
                {
                    DateTime tmpDate = new DateTime(iYear, iMonth, iDay);

                    if (tmpDate.DayOfWeek == DayOfWeek.Saturday || tmpDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        e.Column.AppearanceCell.BackColor = Color.FromArgb(30, 255, 0, 0);
                    }
                }
            }

            if (e.Column.FieldName.Substring(0,3) == "DAY")
            {
                var temp = grdList.View.GetRowCellValue(e.RowHandle, e.Column.FieldName);
                if (temp.Equals("x") || temp.Equals("△"))
                {
                    e.Appearance.ForeColor = Color.FromArgb(30, 255, 0, 0);  
                }

                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

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

            DateTime date = Convert.ToDateTime(values["P_YEARMONTH"].ToString());
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            values.Add("P_STARTDATE", firstDayOfMonth.ToString("yyyy-MM-dd"));
            values.Add("P_ENDDATE", lastDayOfMonth.ToString("yyyy-MM-dd"));
            values.Remove("P_YEARMONTH");

            DataTable dtInfo = await ProcedureAsync("USP_EQUIPMENTDAILYCHECKMONITORING",  values);

            if (dtInfo.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdList.DataSource = dtInfo;

            DataTable dtDetail = await QueryAsync("GetEquipCheckDataDetailLog", "00001", values);

            grdDetail.DataSource = dtDetail;

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

            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").DataSource = null;
            Conditions.GetControl<SmartComboBox>("P_AREACODE").EditValueChanged += AreaCode_EditValueChanged;
        }

        #endregion

        #region Private Function
        private void AreaCode_EditValueChanged(object sender, EventArgs e)
        {
            SqlQuery condition = new SqlQuery("GetEquipmentClassList", "00003", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_AREACODE={Conditions.GetControl<SmartComboBox>("P_AREACODE").EditValue}");
            DataTable conditionTable = condition.Execute();
            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").ValueMember = "EQUIPMENTCLASSID";
            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").DisplayMember = "EQUIPMENTCLASSNAME";
            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").DataSource = conditionTable;
            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").EditValue = "*";
        }

        #endregion
    }

}