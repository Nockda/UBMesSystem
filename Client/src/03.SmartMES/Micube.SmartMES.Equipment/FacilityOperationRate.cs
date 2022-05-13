#region using

using DevExpress.XtraCharts;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Equipment
{
	/// <summary>
	/// 프 로 그 램 명  : 설비관리 > 모니터링 > 설비가동률
	/// 업  무  설  명  : 
	/// 생    성    자  : 정승원
	/// 생    성    일  : 2020-06-22
	/// 수  정  이  력  : 
	/// 
	/// 
	/// </summary>
	public partial class FacilityOperationRate : SmartConditionBaseForm
	{
		#region 생성자

		public FacilityOperationRate()
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
		/// 차트 초기화
		/// </summary>
		private void InitializeChart(SmartChart chart, string titleText)
		{
			ChartTitle title = new ChartTitle();
			title.Font = new Font("맑은 고딕", 16);
			title.Text = titleText;

			if (chart.Titles.Count > 0)
			{
				chart.Titles.RemoveAt(0);
			}

			chart.Titles.Add(title);
			chart.Legend.Title.Text = string.Empty;

			chart.ClearSeries();
		}

		/// <summary>
		/// 그리드 초기화
		/// </summary>
		private void InitializeGrid(SmartBandedGrid grid)
		{
			grid.GridButtonItem = GridButtonItem.None;
			grid.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
			grid.View.SetIsReadOnly();
			grid.View.ClearColumns();
			grid.View.ClearDatas();
		}


		/// <summary>        
		/// 그리드를 초기화한다.
		/// </summary>
		private void InitializeGrid()
		{
			#region 금일 기준 & 조회 기준
			InitializeGrid(grdToday);
			InitializeGrid(grdCondition);
			#endregion

			#region Row Data
			InitializeGridByRowData();
			#endregion
		}

		/// <summary>
		/// Row Data 그리드
		/// </summary>
		private void InitializeGridByRowData()
		{
			#region - 일별  Row Data
			grdRowData.GridButtonItem = GridButtonItem.None;
			grdRowData.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
			grdRowData.View.SetIsReadOnly();

			//발생일자
			grdRowData.View.AddTextBoxColumn("OCCURRDATE", 120).SetTextAlignment(TextAlignment.Center);
			//설비코드
			grdRowData.View.AddTextBoxColumn("EQUIPMENTID", 100).SetTextAlignment(TextAlignment.Center);
			//설비명
			grdRowData.View.AddTextBoxColumn("EQUIPMENTNAME", 150);
			//근무시간
			grdRowData.View.AddTextBoxColumn("WORKINGTIME", 70).SetTextAlignment(TextAlignment.Right);
			//가동시간
			grdRowData.View.AddTextBoxColumn("RUNTIME", 70).SetTextAlignment(TextAlignment.Right);
			//가동률
			grdRowData.View.AddTextBoxColumn("RUNTIMERATE", 70).SetTextAlignment(TextAlignment.Right);

			grdRowData.View.PopulateColumns();
			#endregion

			#region - 설비상태 Row Data
			grdRowDataDetail.GridButtonItem = GridButtonItem.None;
			grdRowDataDetail.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
			grdRowDataDetail.View.SetIsReadOnly();

			//발생일시
			grdRowDataDetail.View.AddTextBoxColumn("OCCURRDATETIME", 160).SetTextAlignment(TextAlignment.Center);
			//상태
			grdRowDataDetail.View.AddTextBoxColumn("STATE", 60);
			grdRowDataDetail.View.PopulateColumns();
			#endregion
		}
		#endregion

		#region Event
		private void InitializeEvent()
		{
			tabStateInfo.SelectedPageChanged += TabStateInfo_SelectedPageChanged;
			grdRowData.View.FocusedRowChanged += View_FocusedRowChanged;
		}

		/// <summary>
		/// ROW DATA 포커스 이동 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if(e.FocusedRowHandle < 0) return;

			DataRow row = grdRowData.View.GetDataRow(e.FocusedRowHandle);
			if(row == null) return;

			grdRowDataDetail.DataSource = SqlExecuter.Query("SelectEquipmentRunStopState", "00001", 
															new Dictionary<string, object>() {  { "TXNTIME", row["OCCURRDATE"] },
																								{ "EQUIPMENTID", row["EQUIPMENTID"] },
																								{ "LANGUAGETYPE", UserInfo.Current.LanguageType } });
		}

		/// <summary>
		/// 탭 변경 이벤트 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TabStateInfo_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			int index = tabStateInfo.SelectedTabPageIndex;
			switch(index)
			{
				case 0:
					SetConditionVisiblility("P_EQUIPCODE", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
					SetConditionVisiblility("P_YEARMONTH", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
					SetConditionVisiblility("P_DATEDIVISION", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
					break;
				case 1:
					SetConditionVisiblility("P_EQUIPCODE", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
					SetConditionVisiblility("P_YEARMONTH", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
					SetConditionVisiblility("P_DATEDIVISION", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
					break;
				case 2:
					SetConditionVisiblility("P_EQUIPCODE", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
					SetConditionVisiblility("P_YEARMONTH", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
					SetConditionVisiblility("P_DATEDIVISION", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
					break;
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

			int index = tabStateInfo.SelectedTabPageIndex;
			switch(index)
			{
				case 0:
					values.Remove("P_EQUIPCODE");
					values.Remove("P_YEARMONTH");
					values.Remove("P_DATEDIVISION");
					DataTable dtToday = await ProcedureAsync("USP_GETEQUIPMENTRUNRATETODAY", values);
					DataTable dtTodayChart = await ProcedureAsync("USP_GETEQUIPMENTRUNRATETODAYCHART", values);
					if (dtTodayChart.Rows.Count < 1 || dtToday.Rows.Count < 1)
					{
						// 조회할 데이터가 없습니다.
						ShowMessage("NoSelectData");
						InitializeChart(chartToday, string.Empty);
						InitializeGrid(grdToday);
						return;
					}

					//차트
					InitializeChart(chartToday, Language.Get("RUNTIMERATEBYEQUIPMENT"));

					DataTable dtWorkingTime = dtTodayChart.Select("TYPE='WORKINGTIME'").CopyToDataTable();
					DataTable dtRunTime = dtTodayChart.Select("TYPE='RUNTIME'").CopyToDataTable();
					DataTable dtRunTimeRate = dtTodayChart.Select("TYPE='RUNTIMERATE'").CopyToDataTable();

					//차트 시리즈 설정
					chartToday.AddBarSeries(Language.Get("WORKINGTIME"), dtWorkingTime)
						.SetSeriesColor(true, "Blue")
						.SetX_DataMember(ScaleType.Auto, "EQUIPMENTNAME")
						.SetY_DataMember(ScaleType.Numerical, "VALUE")
						.SetLegendTextPattern("{A}");

					chartToday.AddBarSeries(Language.Get("RUNTIME"), dtRunTime)
						.SetSeriesColor(true, "Green")
						.SetX_DataMember(ScaleType.Auto, "EQUIPMENTNAME")
						.SetY_DataMember(ScaleType.Numerical, "VALUE")
						.SetLegendTextPattern("{A}");

					chartToday.AddLineSeries(Language.Get("RUNTIMERATE"), dtRunTimeRate)
						.SetSeriesColor(true, "Orange")
						.SetX_DataMember(ScaleType.Auto, "EQUIPMENTNAME")
						.SetY_DataMember(ScaleType.Numerical, "VALUE")
						.SetLegendTextPattern("{A}");

					chartToday.PopulateSeries();

					//차트 설정
					SetChartProperty(chartToday);

					//그리드
					InitializeGrid(grdToday);
					DataColumnCollection dataColumn = dtToday.Columns;
					dataColumn.Remove("DIVISION");
					dataColumn.Remove("TYPE");
					foreach (DataColumn col in dataColumn)
					{
						grdToday.View.AddTextBoxColumn(col.ColumnName, 130);
					}
					grdToday.View.PopulateColumns();
					grdToday.DataSource = dtToday;
					break;
				case 1:
					if(values["P_DATEDIVISION"].Equals("Daily"))
					{
						//일 기준
						values.Remove("P_DATEDIVISION");

						values.Add("STARTDATE", Format.GetFullTrimString(values["P_YEARMONTH"]).Substring(0, 8) + "01");
						values["P_YEARMONTH"] = Format.GetFullTrimString(values["P_YEARMONTH"]).Substring(0, 7);
						DataTable dtDaily = await ProcedureAsync("USP_GETFACILITYOPERATIONRATEDAILY", values);
						DataTable dtDailyChart = await ProcedureAsync("USP_GETFACILITYOPERATIONRATEDAILYCHART", values);
						if (dtDailyChart.Rows.Count < 1 || dtDaily.Rows.Count < 1)
						{
							// 조회할 데이터가 없습니다.
							ShowMessage("NoSelectData");
							InitializeChart(chartCondition, string.Empty);
							InitializeGrid(grdCondition);
							return;
						}

						//차트
						InitializeChart(chartCondition, Language.Get(Format.GetFullTrimString(dtDailyChart.Rows[0]["EQUIPMENTID"])));

						DataTable dtWorkingTime2 = dtDailyChart.Select("COL='WORKINGTIME'").CopyToDataTable();
						DataTable dtRunTime2 = dtDailyChart.Select("COL='RUNTIME'").CopyToDataTable();
						DataTable dtRunTimeRate2 = dtDailyChart.Select("COL='RUNTIMERATE'").CopyToDataTable();
						//DataTable dtAllTimeRate2 = dtDailyChart.Select("COL='ALLTIMERATE'").CopyToDataTable();

						//차트 시리즈 설정
						chartCondition.AddBarSeries(Language.Get("WORKINGTIME"), dtWorkingTime2)
							.SetSeriesColor(true, "Blue")
							.SetX_DataMember(ScaleType.Auto, "TXNDATE2")
							.SetY_DataMember(ScaleType.Numerical, "VALUE")
							.SetLegendTextPattern("{A}");

						chartCondition.AddBarSeries(Language.Get("RUNTIME"), dtRunTime2)
							.SetSeriesColor(true, "Green")
							.SetX_DataMember(ScaleType.Auto, "TXNDATE2")
							.SetY_DataMember(ScaleType.Numerical, "VALUE")
							.SetLegendTextPattern("{A}");

						chartCondition.AddLineSeries(Language.Get("RUNTIMERATE"), dtRunTimeRate2)
							.SetSeriesColor(true, "Orange")
							.SetX_DataMember(ScaleType.Auto, "TXNDATE2")
							.SetY_DataMember(ScaleType.Numerical, "VALUE")
							.SetLegendTextPattern("{A}");

						chartCondition.PopulateSeries();

						//차트 설정
						SetChartProperty(chartCondition);


						//그리드
						InitializeGrid(grdCondition);
						DataColumnCollection dataColumn2 = dtDaily.Columns;
						dataColumn2.Remove("COL");
						dataColumn2.Remove("SEQ");
						foreach (DataColumn col in dataColumn2)
						{
							if(col.ColumnName.Equals("TYPE"))
							{
								grdCondition.View.AddTextBoxColumn(col.ColumnName, 130);
							}
							else
							{
								grdCondition.View.AddTextBoxColumn(col.ColumnName, 60).SetLabel(col.ColumnName.Substring(col.ColumnName.Length - 2));
							}

						}
						grdCondition.View.PopulateColumns();
						grdCondition.DataSource = dtDaily;
					}
					else 
					{
						//월 기준
						values.Remove("P_DATEDIVISION");
						//values.Remove("P_YEARMONTH");
						values["P_YEARMONTH"] = Format.GetFullTrimString(values["P_YEARMONTH"]).Substring(0, 4);
						DataTable dtMonthly = await ProcedureAsync("USP_GETFACILITYOPERATIONRATEMONTHLY", values);
						DataTable dtMonthlyChart = await ProcedureAsync("USP_GETFACILITYOPERATIONRATEMONTHLYCHART", values);
						if (dtMonthlyChart.Rows.Count < 1 || dtMonthly.Rows.Count < 1)
						{
							// 조회할 데이터가 없습니다.
							ShowMessage("NoSelectData");
							InitializeChart(chartCondition, string.Empty);
							InitializeGrid(grdCondition);
							return;
						}

						//차트
						InitializeChart(chartCondition, Language.Get(Format.GetFullTrimString(dtMonthlyChart.Rows[0]["EQUIPMENTID"])));

						DataTable dtWorkingTime3 = dtMonthlyChart.Select("COL='WORKINGTIME'").CopyToDataTable();
						DataTable dtRunTime3 = dtMonthlyChart.Select("COL='RUNTIME'").CopyToDataTable();
						DataTable dtRunTimeRate3 = dtMonthlyChart.Select("COL='RUNTIMERATE'").CopyToDataTable();
						//DataTable dtAllTimeRate2 = dtDailyChart.Select("COL='ALLTIMERATE'").CopyToDataTable();

						//차트 시리즈 설정
						chartCondition.AddBarSeries(Language.Get("WORKINGTIME"), dtWorkingTime3)
							.SetSeriesColor(true, "Blue")
							.SetX_DataMember(ScaleType.Auto, "MONTH")
							.SetY_DataMember(ScaleType.Numerical, "VALUE")
							.SetLegendTextPattern("{A}");

						chartCondition.AddBarSeries(Language.Get("RUNTIME"), dtRunTime3)
							.SetSeriesColor(true, "Green")
							.SetX_DataMember(ScaleType.Auto, "MONTH")
							.SetY_DataMember(ScaleType.Numerical, "VALUE")
							.SetLegendTextPattern("{A}");

						chartCondition.AddLineSeries(Language.Get("RUNTIMERATE"), dtRunTimeRate3)
							.SetSeriesColor(true, "Orange")
							.SetX_DataMember(ScaleType.Auto, "MONTH")
							.SetY_DataMember(ScaleType.Numerical, "VALUE")
							.SetLegendTextPattern("{A}");

						chartCondition.PopulateSeries();

						//차트 설정
						SetChartProperty(chartCondition);

						//그리드
						InitializeGrid(grdCondition);
						DataColumnCollection dataColumn2 = dtMonthly.Columns;
						int monCnt = 1;
						foreach (DataColumn col in dataColumn2)
						{
							if (col.ColumnName.Equals("TYPE"))
							{
								grdCondition.View.AddTextBoxColumn(col.ColumnName, 130);
							}
							else
							{
								grdCondition.View.AddTextBoxColumn(col.ColumnName, 80).SetLabel(col.ColumnName + Language.Get("MON"));
								monCnt += 1;
							}
						}
						grdCondition.View.PopulateColumns();
						grdCondition.DataSource = dtMonthly;
					}

					break;
				case 2:
					grdRowData.View.ClearDatas();
					grdRowDataDetail.View.ClearDatas();

					values.Remove("P_DATEDIVISION");
					values["P_YEARMONTH"] = Format.GetFullTrimString(values["P_YEARMONTH"]).Substring(0, 7);
					DataTable dtRowData = await QueryAsync("SelectEquipmentRuntimeRateRowData", "00001", values);
					if (dtRowData.Rows.Count < 1)
					{
						// 조회할 데이터가 없습니다.
						ShowMessage("NoSelectData");
						return;
					}

					grdRowData.DataSource = dtRowData;

					break;
			}
		}

		/// <summary>
		/// 차트 옵션 설정
		/// </summary>
		/// <param name="chart"></param>
		private void SetChartProperty(SmartChart chart)
		{
			XYDiagram diagram = chart.Diagram as XYDiagram;

			//보조 Y축 설정
			diagram.SecondaryAxesY.Clear();

			SecondaryAxisY myAxisY = new SecondaryAxisY();
			diagram.SecondaryAxesY.Add(myAxisY);

			((LineSeriesView)chart.Series[Language.Get("RUNTIMERATE")].View).AxisY = myAxisY;

			//색상 설정
			((BarSeriesView)chart.Series[Language.Get("WORKINGTIME")].View).Color = Color.DodgerBlue;
			((BarSeriesView)chart.Series[Language.Get("RUNTIME")].View).Color = Color.Green;
			((LineSeriesView)chart.Series[Language.Get("RUNTIMERATE")].View).Color = Color.DarkOrange;
			((LineSeriesView)chart.Series[Language.Get("RUNTIMERATE")].View).LineStyle.Thickness = 2;
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

			SmartComboBox equip =  Conditions.GetControl<SmartComboBox>("P_EQUIPCODE");
			equip.ItemIndex = 0;

			SmartComboBox dateDivision = Conditions.GetControl<SmartComboBox>("P_DATEDIVISION");
			dateDivision.ItemIndex = 0;

			SetConditionVisiblility("P_EQUIPCODE", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
			SetConditionVisiblility("P_YEARMONTH", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
			SetConditionVisiblility("P_DATEDIVISION", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
		}

		#endregion
	}
}