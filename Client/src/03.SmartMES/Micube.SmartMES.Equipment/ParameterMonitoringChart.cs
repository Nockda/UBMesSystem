#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;

using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.Utils;


#endregion

namespace Micube.SmartMES.Equipment
{
    /// <summary>
    /// 프 로 그 램 명  : 설비관리 > 설비점검 > 설비일상점검모니터링
    /// 업  무  설  명  : 설비일상점검표를 모니터링한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-04-10
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ParameterMonitoringChart : SmartConditionBaseForm
    {
        public ParameterMonitoringChart ()
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
            // 컨트롤 초기화 로직 구성
        }

        
        #endregion

        #region 조회조건 구성
        protected override void InitializeCondition()
        {
            base.InitializeCondition();
            InitializeCondition_Parameter();
            parameterChart.Series.Clear();
            // TODO : 조회조건 추가 구성이 필요한 경우 사용
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            

           Conditions.GetControl<SmartComboBox>("p_equipmentGroup").EditValueChanged += EquipDailyCheckMonitoring_EditValueChanged;

        }

        private void EquipDailyCheckMonitoring_EditValueChanged(object sender, EventArgs e)
        {
            
            SqlQuery condition = new SqlQuery("GetEquipCode", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_EQUIPMENTGROUP={Conditions.GetControl<SmartComboBox>("p_equipmentGroup").EditValue}");
            DataTable conditionTable = condition.Execute();
            Conditions.GetControl<SmartComboBox>("p_Equipment").ValueMember = "EQUIPMENTID";
            Conditions.GetControl<SmartComboBox>("p_Equipment").DisplayMember = "EQUIPMENTNAME";
            Conditions.GetControl<SmartComboBox>("p_Equipment").DataSource = conditionTable;

            


        }
        /// <summary>
		/// 팝업형 조회조건 생성 - 공정
		/// </summary>
		private void InitializeCondition_Parameter()
        {
            var segmentId = Conditions.AddSelectPopup("PARAMETERID", new SqlQuery("GetParameterDefList", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("PARAMETERID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(0)
                .SetValidationKeyColumn()
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("PARAMETERNAME")
                .SetPosition(5.7)
                .SetLabel("PARAMETER");

            segmentId.Conditions.AddTextBox("TXTPARAMETER");

            segmentId.GridColumns.AddTextBoxColumn("PARAMETERID", 150);
            segmentId.GridColumns.AddTextBoxColumn("PARAMETERNAME", 200);
        }
        #endregion

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();
            

            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtParameterList = await QueryAsync("GetPatameterHistoryChart", "00001", values);

            if (dtParameterList.Rows.Count < 1)
            {
                //조회할 데이터가 없습니다.
                ShowMessage("NoSelectData");
            }

            else
            {
                this.parameterChart.Series.Clear();
                this.parameterChart.Controls.Clear();
                this.parameterChart.Legends.Clear();

                Dictionary<string, Series> seriesList = new Dictionary<string, Series>();

                foreach (DataRow row in dtParameterList.Rows)
                {
                    string parameterID = row["PARAMETERID"].ToString();
                    string dateTime = row["CREATEDTIME"].ToString();
                    double value = Convert.ToDouble(row["VALUE"]);

                    Series series;
                    if (seriesList.TryGetValue(parameterID, out series) == false)
                    {
                        seriesList.Add(parameterID, series = new Series(parameterID, ViewType.Line));

                        ((LineSeriesView)series.View).LineStyle.Thickness = 1;
                        //ArgumentScaleType 변경
                        series.ArgumentScaleType = ScaleType.Qualitative;

                        parameterChart.Series.Add(series);
                    }

                    SeriesPoint point = new SeriesPoint(dateTime, value);

                    series.Points.Add(point);
                }




                //DataTable dtUniqRecords = new DataTable();
                //dtUniqRecords = dtParameterList.DefaultView.ToTable(true, "PARAMETERID");

                //for(int i = 0; i < dtUniqRecords.Rows.Count; i++)
                //{
                //    string parameterid = dtUniqRecords.Rows[i][0].ToString();

                //    Series chartSeries = new Series(parameterid, ViewType.Line);
                //    LineSeriesView lineView = new LineSeriesView();
                //    lineView = (LineSeriesView)chartSeries.View;
                    
                //    DataRow[] drw = dtParameterList.Select("parameterid = '" + dtUniqRecords.Rows[i][0].ToString() + "'");

                //    chartSeries.Name = "Parameter History";
                //    chartSeries.LegendText = parameterid;

                //    DataTable dt = new DataTable();
                //    dt.TableName = parameterid;
                //    dt.Columns.Add("PARAMETERID");
                //    dt.Columns.Add("VALUE");
                //    dt.Columns.Add("CREATEDTIME");

                //    foreach (DataRow dr in drw)
                //    {
                //        DataRow newRow = dt.NewRow();
                //        newRow["PARAMETERID"] = dr["PARAMETERID"].ToString();
                //        newRow["VALUE"] = double.Parse(dr["VALUE"].ToString());
                //        newRow["CREATEDTIME"] = DateTime.Parse(dr["CREATEDTIME"].ToString());

                //        dt.Rows.Add(newRow);
                //    }
                //    //Label 표시

                //    chartSeries.DataSource = dt;

                //    XYDiagram xyDiagram = new XYDiagram();
                //    xyDiagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
                //    xyDiagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
                //    xyDiagram.AxisX.GridSpacingAuto = false;

                //    parameterChart.Diagram = xyDiagram;
                    
                //}



            }

    //else
    //{
    //    this.parameterChart.Controls.Clear();
    //    this.parameterChart.Legends.Clear();

    //    Series chartSeries = new Series("Parameter", ViewType.Point);
    //    chartSeries.Name = "Parameter History";
    //    chartSeries.LegendText = "ParameterID";               

    //    Dictionary<string, Series> seriesList = new Dictionary<string, Series>();

    //    foreach (DataRow row in dtParameterList.Rows)
    //    {


    //        string parameterID = row["PARAMETERID"].ToString();

    //        string dateTime = row["CREATEDTIME"].ToString();

    //        double value = Convert.ToDouble(row["VALUE"]);

    //        Series series;

    //        if (seriesList.TryGetValue(parameterID, out series) == false)
    //        {

    //            seriesList.Add(parameterID, series = new Series(parameterID, ViewType.Point));

    //            //Label 표시
    //            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
    //            parameterChart.Series.Add(series);


    //        }

    //        //SeriesPoint 생성
    //        SeriesPoint point = new SeriesPoint(dateTime, value);
    //        series.Points.Add(point);
    //    }

    //}         

}
        #endregion      


    }
}
