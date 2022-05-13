using DevExpress.XtraCharts;
using Micube.Framework;
using Micube.Framework.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace Micube.SmartMES.DashBoard
{
    public partial class TotalDashBoardStatusPop : Form
    {
        #region ◆ Variables |
        public int? ThreadTime { get; set; }

        // Thread
        private Thread _threadReading;

        // Timer 동작여부
        private bool _isRunTimer = false;

        // Delegate
        public delegate void tDelegate();

        //한글/영문 언어타입 1:한글 / 2 영문
        private int LanguageType = 0;

        //쓰레드 동작시 Count => Count숫자로 팀명 출력
        private int count = 0;

        private String popMainTitle;
        private String totalProduction_Title;
        private String totalEquipment_Title;

        private String production_Efficiency_text;
        private String production_RetrieveRate_text;

        private String production_Result_Title;
        private String production_Efficiency_Title;

        private String taget_text;
        private String result_text;

        private String running_text;
        private String stopped_text;
        private String alarm_text;

        private String taget_short_text;
        private String result_short_text;

        private String efficiency_short_text;
        private String recovery_short_text;

        private String equipment4_text;
        private String equipment3_text;

        private String month_text;

        decimal TotalProductionGagueValue = 0;

        // T01:MACH / T02:COMP / T03:REF / T04:PUMP / T05:RM
        private String[] teamTitle = new string[5] { "MACH", "COMP", "REF", "PUMP", "RM" };
        private String[] teamCode = new string[5] { "T01", "T02", "T03", "T04", "T05" };

        #endregion

        public TotalDashBoardStatusPop(int LanguageType)
        {
            InitializeComponent();
            InitializeEvent();
            InitializeControls(LanguageType);
            // Thread Start
            ThreadStart();
        }

        #region 차트, Label 속성
        private void InitializeControls(int p_LanguageType)
        {
            this.LanguageType = p_LanguageType;

            //한글
            if (LanguageType == 1)
            {
                popMainTitle = DateTime.Now.ToString("MM") + "월 UCK 제조 종합 현황";
                totalProduction_Title = "종합생산실적";
                totalEquipment_Title = "설비가동률";

                production_Efficiency_text = "작업효율";
                production_RetrieveRate_text = "회수율";

                production_Result_Title = "생산실적";
                production_Efficiency_Title = "생산효율";

                taget_text = "목표";
                result_text = "실적";

                running_text = "가동";
                stopped_text = "비가동";
                alarm_text = "알람";

                taget_short_text = "목표";
                result_short_text = "실적";

                efficiency_short_text = "작업효율";
                recovery_short_text = "회수율";

                equipment4_text = "WT-250Ⅱ 1호기";
                equipment3_text = "WT-250Ⅱ 2호기";

                month_text = "(월)";

            }       
            //영문
            if (LanguageType == 2)
            {
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
                DateTime oDateTime = DateTime.Now;

                popMainTitle = "MONTHLY PERFORMANCE DASHBOARD(" + oDateTime.ToString("MMM", ci) + ")";
                totalProduction_Title = "ALL TEAMS PERFORMANCE";
                totalEquipment_Title = "EQUIPMENT EFFECTIVENESS";

                production_Efficiency_text = "Efficiency";
                production_RetrieveRate_text = "Recovery";

                production_Result_Title = "Throughput";
                production_Efficiency_Title = "Labour Effectiveness";

                taget_text = "Planned";
                result_text = "Actual";

                running_text = "Run";
                stopped_text = "Stop";
                alarm_text = "Alrm";

                taget_short_text = "Plnd";
                result_short_text = "Actl";

                efficiency_short_text = "Effcy";
                recovery_short_text = "Recy";

                equipment4_text = "WT-250Ⅱ 1st";
                equipment3_text = "WT-250Ⅱ 2nd";

                month_text = "(M)";

            }
            bodyLayoutPanel.BackColor = Color.FromArgb(250, 250, 253);

            totalChartLayoutPanel.BackColor = Color.White;
            TeamAllLayoutPanel.BackColor = Color.White;
            TotalEquipmentLayoutPanel.BackColor = Color.White;

            // 종합현황판 메인 타이틀
            mainTitle_label.Text = popMainTitle;
            mainTitle_label.ForeColor = Color.FromArgb(255, 255, 255);
            mainTitle_label.Font = new Font("S-CoreDream-5Medium", 23);

            // 종합생산실적 타이틀
            TotalProTitle_Label.Text = totalProduction_Title;
            //TotalProTitle_Label.Font = new Font("S-CoreDream-5Medium", 16);
            TotalProTitle_Label.ForeColor = Color.FromArgb(2, 121, 207);
            TotalProTitle_Label.Font = new Font("S-CoreDream-5Medium", 17, FontStyle.Bold);

            // 종합설비 가동률 타이틀
            TotalEquipTitle_Label.Text = totalEquipment_Title;
            //TotalEquipTitle_Label.Font = new Font("S-CoreDream-5Medium", 16);
            TotalEquipTitle_Label.ForeColor = Color.FromArgb(2, 121, 207);
            TotalEquipTitle_Label.Font = new Font("S-CoreDream-5Medium", 17, FontStyle.Bold);

            // 종합 - 생산실적 SUB 타이틀
            subTitle_Total_label_1.Text = production_Result_Title;
            subTitle_Total_label_1.Font = new Font("MalgunGothic", 14);
            subTitle_Total_label_1.ForeColor = Color.FromArgb(2, 121, 207);

            // 종합 - 생산효율 SUB 타이틀
            subTitle_Total_label_2.Text = production_Efficiency_Title;
            subTitle_Total_label_2.Font = new Font("MalgunGothic", 14);
            subTitle_Total_label_2.ForeColor = Color.FromArgb(2, 121, 207);

            //종합 생산효율 Line Chart 상단 작업효율
            TotalEfficiency_Label_1.Font = new Font("MalgunGothic-Semilight", 10);
            TotalEfficiency_Label_1.ForeColor = Color.FromArgb(0, 0, 0, 1);
            TotalEfficiency_Label_1.Text = efficiency_short_text;

            //종합 생산효율 Line Chart 상단 회수율
            TotalEfficiency_Label_2.Font = new Font("MalgunGothic-Semilight", 10);
            TotalEfficiency_Label_2.ForeColor = Color.FromArgb(0, 0, 0, 1);
            TotalEfficiency_Label_2.Text = recovery_short_text;

            //종합 설비가동률 이미지 상단 가동
            TotalEquipTitle_Label_1.Font = new Font("MalgunGothic-Semilight", 10);
            TotalEquipTitle_Label_1.ForeColor = Color.FromArgb(0, 0, 0, 1);
            TotalEquipTitle_Label_1.Text = running_text;

            //종합 설비가동률 이미지 상단 비가동
            TotalEquipTitle_Label_2.Font = new Font("MalgunGothic-Semilight", 10);
            TotalEquipTitle_Label_2.ForeColor = Color.FromArgb(0, 0, 0, 1);
            TotalEquipTitle_Label_2.Text = stopped_text;

            //종합 설비가동률 이미지 상단 알람
            TotalEquipTitle_Label_3.Font = new Font("MalgunGothic-Semilight", 10);
            TotalEquipTitle_Label_3.ForeColor = Color.FromArgb(0, 0, 0, 1);
            TotalEquipTitle_Label_3.Text = alarm_text;

            // 팀별 생산현황 타이틀
            TeamMainTitle_Label_1.ForeColor = Color.FromArgb(2, 121, 207);
            TeamMainTitle_Label_1.Font = new Font("S-CoreDream-5Medium", 17, FontStyle.Bold);

            // 팀별생산실적 - 생산실적 SUB 타이틀
            subTitle_Team_label_1.Text = production_Result_Title;
            subTitle_Team_label_1.Font = new Font("MalgunGothic", 16);
            subTitle_Team_label_1.ForeColor = Color.FromArgb(2, 121, 207);

            // 팀별생산실적 - 생산효율 타이틀
            subTitle_Team_label_2.Text = production_Efficiency_Title;
            subTitle_Team_label_2.Font = new Font("MalgunGothic", 16);
            subTitle_Team_label_2.ForeColor = Color.FromArgb(2, 121, 207);

            //팀별 생산효율 chart 상단 작업효율
            TeamEfficiency_Label_1.Font = new Font("MalgunGothic-Semilight", 10);
            TeamEfficiency_Label_1.ForeColor = Color.FromArgb(0, 0, 0, 1);
            TeamEfficiency_Label_1.Text = efficiency_short_text;

            //팀별 생산효율 chart 상단 회수율
            TeamEfficiency_Label_2.Font = new Font("MalgunGothic-Semilight", 10);
            TeamEfficiency_Label_2.ForeColor = Color.FromArgb(0, 0, 0, 1);
            TeamEfficiency_Label_2.Text = recovery_short_text;

            // 팀별생산실적 - Gauge차트
            TeamProductionChart_gaugeControl.ColorScheme.Color = Color.FromArgb(29, 116, 254);

            // 팀별생산실적 - 목표 / 수량
            TeamTaget_Label.Text = taget_text;
            TeamTaget_Label.ForeColor = Color.FromArgb(187, 187, 191);
            TeamTaget_Qty_Label.ForeColor = Color.FromArgb(45, 156, 252);

            // 팀별생산실적 - 실적 / 수량
            TeamResult_Label.Text = result_text;
            TeamResult_Label.ForeColor = Color.FromArgb(187, 187, 191);
            TeamResult_Qty_Label.ForeColor = Color.FromArgb(53, 207, 8);

            // 팀별생산실적 - Bar차트 상단 목표
            TeamPro_Taget_Label.Text = taget_short_text;
            TeamPro_Taget_Label.Font = new Font("MalgunGothic-Semilight", 10);
            TeamPro_Taget_Label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            // 팀별생산실적 - Bar차트 상단 실적
            TeamPro_Result_Label.Text = result_short_text;
            TeamPro_Result_Label.Font = new Font("MalgunGothic-Semilight", 10);
            TeamPro_Result_Label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            //종합생산실적 - Bar차트 상단 목표
            TotalPro_Taget_Label.Text = taget_short_text;
            TotalPro_Taget_Label.Font = new Font("MalgunGothic-Semilight", 10);
            TotalPro_Taget_Label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            //종합생산실적 - Bar차트 상단 실적
            TotalPro_Result_Label.Text = result_short_text;
            TotalPro_Result_Label.Font = new Font("MalgunGothic-Semilight", 10);
            TotalPro_Result_Label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            // 팀별 생산효율 Gauge차트
            TeamWorkAffect_gaugeControl.ColorScheme.Color = Color.FromArgb(30, 214, 208);

            // 팀별 회수율 Gague차트
            TeamRetrieveRate_gaugeControl.ColorScheme.Color = Color.FromArgb(255, 168, 17);

            TotalProductionGague_label_title.Text = production_Result_Title;
            TotalProductionGague_label_title.AppearanceText.Font = new Font("MalgunGothic", 13);

            TotalWorkAffect_Label_title.Text = production_Efficiency_text;
            TotalWorkAffect_Label_title.AppearanceText.Font = new Font("MalgunGothic", 13);

            TotalRetrieveRate_Label_title.Text = production_RetrieveRate_text;
            TotalRetrieveRate_Label_title.AppearanceText.Font = new Font("MalgunGothic", 13);

            //팀별생산실적 - 생산실적 차트
            XYDiagram diagramTeamPro = (XYDiagram)TeamProductionChart.Diagram;
            diagramTeamPro.AxisY.WholeRange.SetMinMaxValues(0, 200);
            diagramTeamPro.AxisY.NumericScaleOptions.GridSpacing = 50;

            //팀별생산실적 - 생산효율 차트
            XYDiagram diagramTeamEff = (XYDiagram)TeamEfficiencyChart.Diagram;
            diagramTeamEff.AxisY.WholeRange.SetMinMaxValues(0, 100);
            diagramTeamEff.AxisY.NumericScaleOptions.GridSpacing = 50;

            //종합생산실적 - 생산실적 차트
            XYDiagram diagramTotalPro = (XYDiagram)TotalProductionChart.Diagram;
            diagramTotalPro.AxisY.WholeRange.SetMinMaxValues(0, 100);
            diagramTotalPro.AxisY.NumericScaleOptions.GridSpacing = 20;
            diagramTotalPro.AxisX.NumericScaleOptions.GridSpacing = 10;


            //종합생산실적 - 생산효율 차트
            XYDiagram diagramTotalEffi = (XYDiagram)TotalEfficiencyChart.Diagram;
            diagramTotalEffi.AxisY.WholeRange.SetMinMaxValues(0, 100);
            diagramTotalEffi.AxisY.NumericScaleOptions.GridSpacing = 20;
            diagramTotalEffi.AxisX.NumericScaleOptions.GridSpacing = 10;

            Series series = new Series();
            series.ArgumentDataMember = "Section";
            SideBySideBarSeriesView view = series.View as SideBySideBarSeriesView;
            view.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            view.BarWidth = 3;
            TotalProductionChart.Series.Add(series);


            //설비가동률 ProgressBar
            equip_1_progressBar.Style = ProgressBarStyle.Blocks;
            equip_1_progressBar.Minimum = 0;
            equip_1_progressBar.Maximum = 100;
            equip_1_progressBar.Step = 1;

            TotalProductionChart_gaugeControl.ColorScheme.Color = Color.FromArgb(30, 117, 255);
            TotalWorkAffect_gaugeControl.ColorScheme.Color = Color.FromArgb(30, 214, 208);
            TotalRetrieveRate_gaugeControl.ColorScheme.Color = Color.FromArgb(255, 168, 17);

            Total_Pro_Y_Legend.Font = new Font("MalgunGothic", 8);
            Total_Pro_Y_Legend.ForeColor = Color.FromArgb(187, 187, 191);

            Total_Effi_X_Legend.Font = new Font("MalgunGothic", 8);
            Total_Effi_X_Legend.ForeColor = Color.FromArgb(187, 187, 191);
            Total_Effi_X_Legend.Text = month_text;

            Total_Effi_Y_Legend.Font = new Font("MalgunGothic", 8);
            Total_Effi_Y_Legend.ForeColor = Color.FromArgb(187, 187, 191);

            Team_Pro_Y_Legend.Font = new Font("MalgunGothic", 8);
            Team_Pro_Y_Legend.ForeColor = Color.FromArgb(187, 187, 191);

            Team_Pro_X_Legend.Font = new Font("MalgunGothic", 8);
            Team_Pro_X_Legend.ForeColor = Color.FromArgb(187, 187, 191);
            Team_Pro_X_Legend.Text = month_text;

            Team_Effi_Y_Legend.Font = new Font("MalgunGothic", 8);
            Team_Effi_Y_Legend.ForeColor = Color.FromArgb(187, 187, 191);

            Team_Effi_X_Legend.Font = new Font("MalgunGothic", 8);
            Team_Effi_X_Legend.ForeColor = Color.FromArgb(187, 187, 191);
            Team_Effi_X_Legend.Text = month_text;

            equip_1_name_label.Font = new Font("MalgunGothicBold", 9);
            equip_1_name_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_1_label.Font = new Font("MalgunGothicBold", 9);
            equip_1_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_2_name_label.Font = new Font("MalgunGothicBold", 9);
            equip_2_name_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_2_label.Font = new Font("MalgunGothicBold", 9);
            equip_2_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_3_name_label.Text = equipment3_text;
            equip_3_name_label.Font = new Font("MalgunGothicBold", 9);
            equip_3_name_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_3_label.Font = new Font("MalgunGothicBold", 9);
            equip_3_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_4_name_label.Text = equipment4_text;
            equip_4_name_label.Font = new Font("MalgunGothicBold", 9);
            equip_4_name_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_4_label.Font = new Font("MalgunGothicBold", 9);
            equip_4_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_5_name_label.Font = new Font("MalgunGothicBold", 9);
            equip_5_name_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_5_label.Font = new Font("MalgunGothicBold", 9);
            equip_5_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_6_name_label.Font = new Font("MalgunGothicBold", 9);
            equip_6_name_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_6_label.Font = new Font("MalgunGothicBold", 9);
            equip_6_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_7_name_label.Font = new Font("MalgunGothicBold", 9);
            equip_7_name_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

            equip_7_label.Font = new Font("MalgunGothicBold", 9);
            equip_7_label.ForeColor = Color.FromArgb(0, 0, 0, 1);

        }
        #endregion

        //이벤트
        private void InitializeEvent()
        {
            //ESC => Form 종료
            this.KeyPreview = true;
            this.KeyPress += TotalDashBoardStatusPop_KeyPress;

            // Team별 생산현황 레이아웃 테두리
            this.TeamProductionGaugeLayoutPanel.CellPaint += teamProductionGaugeLayoutPanel_CellPaint;
            this.TeamProductionGaugeLayoutPanel2.CellPaint += TeamProductionGaugeLayoutPanel2_CellPaint;
            this.TeamAllLayoutPanel.CellPaint += TeamAllLayoutPanel_CellPaint;

            // 종합 레이아웃 테두리
            this.TotalEquipmentLayoutPanel.CellPaint += TotalEquipmentLayoutPanel_CellPaint;
            this.totalChartLayoutPanel.CellPaint += TotalChartLayoutPanel_CellPaint;

            //this.bodyLayoutPanel.CellPaint += panel1_Paint;

        }

        //ESC버튼 => Form종료
        private void TotalDashBoardStatusPop_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char ESC_KEY = (char)Keys.Escape;
            if (e.KeyChar == ESC_KEY)
            {
                ThreadStop();
                this.Close();
            }

        }

        private void SearchTeamChart(DataSet ds)
        {
            this.TeamProductionChart.DataSource = SearchTeamChartData(ds);

            TeamProductionChart.SeriesDataMember = "Month";
            TeamProductionChart.SeriesTemplate.ArgumentDataMember = "Section";
            TeamProductionChart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });

            TeamProductionChart.SeriesTemplate.View = new SideBySideBarSeriesView();
        }

        private void SearchTotalProductionChart(DataSet ds)
        {
            this.TotalProductionChart.DataSource = SearchTotalProductionChartData(ds);

            TotalProductionChart.SeriesDataMember = "Month";
            TotalProductionChart.SeriesTemplate.ArgumentDataMember = "Section";
            TotalProductionChart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });

            TotalProductionChart.SeriesTemplate.View = new SideBySideBarSeriesView();
        }

        private object SearchTotalProductionChartData(DataSet ds)
        {
            DataTable table = new DataTable("Table");

            table.Columns.Add("Month", typeof(string));
            table.Columns.Add("Section", typeof(string));
            table.Columns.Add("Value", typeof(Int32));

            decimal T1_PlanQty = 0;
            decimal T2_PlanQty = 0;
            decimal T3_PlanQty = 0;
            decimal T4_PlanQty = 0;
            decimal T5_PlanQty = 0;

            int T1_ResultQty = 0;
            int T2_ResultQty = 0;
            int T3_ResultQty = 0;
            int T4_ResultQty = 0;
            int T5_ResultQty = 0;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                switch (row["TEAMID"].ToString())
                {
                    case "T01":
                        T1_PlanQty = decimal.Parse(row["PLANQTY"].ToString());
                        break;
                    case "T02":
                        T2_PlanQty = decimal.Parse(row["PLANQTY"].ToString());
                        break;
                    case "T03":
                        T3_PlanQty = decimal.Parse(row["PLANQTY"].ToString());
                        break;
                    case "T04":
                        T4_PlanQty = decimal.Parse(row["PLANQTY"].ToString());
                        break;
                    case "T05":
                        T5_PlanQty = decimal.Parse(row["PLANQTY"].ToString());
                        break;
                }
            }
            foreach (DataRow row in ds.Tables[1].Rows)
            {
                switch (row["TEAMID"].ToString())
                {
                    case "T01":
                        T1_ResultQty = int.Parse(row["RESULTQTY"].ToString());
                        break;
                    case "T02":
                        T2_ResultQty = int.Parse(row["RESULTQTY"].ToString());
                        break;
                    case "T03":
                        T3_ResultQty = int.Parse(row["RESULTQTY"].ToString());
                        break;
                    case "T04":
                        T4_ResultQty = int.Parse(row["RESULTQTY"].ToString());
                        break;
                    case "T05":
                        T5_ResultQty = int.Parse(row["RESULTQTY"].ToString());
                        break;
                }
            }

            table.Rows.Add(new object[] { taget_text, "MACH", T1_PlanQty });
            table.Rows.Add(new object[] { result_text, "MACH", T1_ResultQty });

            table.Rows.Add(new object[] { taget_text, "COMP", T2_PlanQty });
            table.Rows.Add(new object[] { result_text, "COMP", T2_ResultQty });

            table.Rows.Add(new object[] { taget_text, "REF", T3_PlanQty });
            table.Rows.Add(new object[] { result_text, "REF", T3_ResultQty });

            table.Rows.Add(new object[] { taget_text, "PUMP", T4_PlanQty });
            table.Rows.Add(new object[] { result_text, "PUMP", T4_ResultQty });

            table.Rows.Add(new object[] { taget_text, "RM", T5_PlanQty });
            table.Rows.Add(new object[] { result_text, "RM", T5_ResultQty });

            TotalProductionGagueValue = (T1_ResultQty + T2_ResultQty + T3_ResultQty + T4_ResultQty + T5_ResultQty) /
                                        (T1_PlanQty + T2_PlanQty + T3_PlanQty + T4_PlanQty + T5_PlanQty) * 100;

            return table;
        }

        private void SearchTeamEfficiencyChart(DataTable dt)
        {
            this.TeamEfficiencyChart.DataSource = SearchefficiencyChartData(dt);

            TeamEfficiencyChart.SeriesDataMember = "Month";
            TeamEfficiencyChart.SeriesTemplate.ArgumentDataMember = "Section";
            TeamEfficiencyChart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });

            TeamEfficiencyChart.SeriesTemplate.View = new SideBySideBarSeriesView();
        }

        //차트 그라데이션 효과
        private void Chart_BoundDataChanged(object sender, EventArgs e)
        {
            ChartControl chart = (ChartControl)sender;
            for (int i = 0; i < chart.Series.Count; i++)
            {
                BarSeriesView view = (BarSeriesView)chart.Series[i].View;
                view.Color = Color.FromArgb(135, 98, 222);
                //view.FillStyle.FillMode = FillMode.Solid;
                ((GradientFillOptionsBase)view.FillStyle.Options).Color2 = Color.Blue;
            }
        }

        //팀별 생산실적 차트
        private object SearchTeamChartData(DataSet ds)
        {

            DataTable table = new DataTable("Table");


            table.Columns.Add("Month", typeof(string));
            table.Columns.Add("Section", typeof(string));
            table.Columns.Add("Value", typeof(Int32));
            table.Columns.Add("Percent", typeof(Int32));

            int maxValue = 0;

            // 해당 월 포함 최근 6개월 데이터
            for (int i = 5; i > -1; i--)
            {
                table.Rows.Add(new object[] { taget_text, ds.Tables[0].Rows[i]["MONTH"].ToString(), ds.Tables[0].Rows[i]["PLANQTY"], 100 });
                table.Rows.Add(new object[] { result_text, ds.Tables[0].Rows[i]["MONTH"].ToString(), ds.Tables[0].Rows[i]["RESULTQTY"], 70 });

                /*                if(maxValue < int.Parse(ds.Tables[0].Rows[i]["PLANQTY"].ToString()))
                                {
                                    maxValue = int.Parse(ds.Tables[0].Rows[i]["PLANQTY"].ToString());
                                }*/
            }

            // setTeamProductionChartRange(maxValue);


            return table;
        }

        //팀별 생산효율 차트
        private object SearchefficiencyChartData(DataTable dt)
        {
            DataTable table = new DataTable("Table");

            table.Columns.Add("Month", typeof(string));
            table.Columns.Add("Section", typeof(string));
            table.Columns.Add("Value", typeof(Int32));

            String month = DateTime.Now.ToString("MM");

            table.Rows.Add(new object[] { production_Efficiency_text, DateTime.Now.AddMonths(-5).ToString("MM"), int.Parse(dt.Rows[7]["MONTH" + DateTime.Now.AddMonths(-5).ToString("MM")].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, DateTime.Now.AddMonths(-5).ToString("MM"), int.Parse(dt.Rows[8]["MONTH" + DateTime.Now.AddMonths(-5).ToString("MM")].ToString()) });

            table.Rows.Add(new object[] { production_Efficiency_text, DateTime.Now.AddMonths(-4).ToString("MM"), int.Parse(dt.Rows[7]["MONTH" + DateTime.Now.AddMonths(-4).ToString("MM")].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, DateTime.Now.AddMonths(-4).ToString("MM"), int.Parse(dt.Rows[8]["MONTH" + DateTime.Now.AddMonths(-4).ToString("MM")].ToString()) });

            table.Rows.Add(new object[] { production_Efficiency_text, DateTime.Now.AddMonths(-3).ToString("MM"), int.Parse(dt.Rows[7]["MONTH" + DateTime.Now.AddMonths(-3).ToString("MM")].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, DateTime.Now.AddMonths(-3).ToString("MM"), int.Parse(dt.Rows[8]["MONTH" + DateTime.Now.AddMonths(-3).ToString("MM")].ToString()) });

            table.Rows.Add(new object[] { production_Efficiency_text, DateTime.Now.AddMonths(-2).ToString("MM"), int.Parse(dt.Rows[7]["MONTH" + DateTime.Now.AddMonths(-2).ToString("MM")].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, DateTime.Now.AddMonths(-2).ToString("MM"), int.Parse(dt.Rows[8]["MONTH" + DateTime.Now.AddMonths(-2).ToString("MM")].ToString()) });

            table.Rows.Add(new object[] { production_Efficiency_text, DateTime.Now.AddMonths(-1).ToString("MM"), int.Parse(dt.Rows[7]["MONTH" + DateTime.Now.AddMonths(-1).ToString("MM")].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, DateTime.Now.AddMonths(-1).ToString("MM"), int.Parse(dt.Rows[8]["MONTH" + DateTime.Now.AddMonths(-1).ToString("MM")].ToString()) });

            table.Rows.Add(new object[] { production_Efficiency_text, month, int.Parse(dt.Rows[7]["MONTH" + month].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, month, int.Parse(dt.Rows[8]["MONTH" + month].ToString()) });

            return table;
        }

        private void SearchData()
        {
            // 팀별 생산실적 TEXT
            //한글 Ver
            if (LanguageType == 1)
            {
                TeamMainTitle_Label_1.Text = teamTitle[count] + " 생산현황";
            }
            //영문 Ver
            if (LanguageType == 2)
            {
                TeamMainTitle_Label_1.Text = teamTitle[count] + ".TEAM PERFORMANCE ";
            }

            //Dictionary<string, object> values = new Dictionary<string, object>();
            //values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TEAMID", teamCode[count]);
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            //월별 전체 생산현황
            DataSet dsTotalChart = SqlExecuter.ProcedureToDataSet("USP_TOTAL_AREAWORKSTATUSMONTH");
            totalProductionChart(dsTotalChart);

            //월별 전체 생산효율 / 회수율
            DataTable dtEquipTotal = SqlExecuter.Query("SelectKPIState", "00004");
            totalEffiRetriChart(dtEquipTotal);

            //월별 전체 설비가동률
            DataTable dtTotalEquip = SqlExecuter.Procedure("USP_TOTAL_GETFACILITYOPERATIONRATEMONTHLYCHART");
            totalEquipmentChart(dtTotalEquip);

            //월별 팀 생산현황(GaugeChart)
            DataSet dsGaugeChart = SqlExecuter.ProcedureToDataSet("USP_DASH_AREAWORKSTATUS", param);
            teamProductionChart(dsGaugeChart);

            //월별 팀 생산현황(목표/실적)
            DataSet dsTeamChart = SqlExecuter.ProcedureToDataSet("USP_TOTAL_AREAWORKSTATUS", param);
            teamProductionPlanTarget(dsTeamChart);

            //팀별 생산효율 / 회수율
            DataTable dtEquip = SqlExecuter.Query("SelectKPIState", "00003", param);
            teamEffiRetriChart(dtEquip);

            ++count;

            if (count == 5)
            {
                count = 0;
            }

        }

        private void teamEffiRetriChart(DataTable dtEquip)
        {
            if (dtEquip.Rows.Count > 0)
            {
                //작업효율
                String WorkAffect = dtEquip.Rows[7]["MONTH" + DateTime.Now.ToString("MM")].ToString();

                //회수율
                String RetrieveRate = dtEquip.Rows[8]["MONTH" + DateTime.Now.ToString("MM")].ToString();

                TeamWorkAffect_Gauge.Value = int.Parse(WorkAffect);
                TeamRetrieveRate_Gauge.Value = int.Parse(RetrieveRate);

                TeamWorkAffect_Label.Text = WorkAffect + '%';
                TeamRetrieveRate_Label.Text = RetrieveRate + '%';

                SearchTeamEfficiencyChart(dtEquip);
            }
        }

        private void teamProductionPlanTarget(DataSet dsTeamChart)
        {
            if (dsTeamChart.Tables.Count > 0)
            {
                SearchTeamChart(dsTeamChart);
            }
        }

        private void teamProductionChart(DataSet dsGauge)
        {
            if (dsGauge.Tables.Count > 0)
            {
                DataTable dt1 = dsGauge.Tables[0];
                DataRow dr = dt1.Rows[0];
                TeamTaget_Qty_Label.Text = dr["PLANQTY"].ToString();
                TeamResult_Qty_Label.Text = dr["RESULTQTY"].ToString();

                // MONTHPERCENT %제거
                String percent = dr["MONTHPERCENT"].ToString();
                percent = percent.Substring(0, percent.Length - 2);

                decimal tt = decimal.Parse(percent);
                tt = Math.Truncate(tt);

                TeamPerformance_GaugeArc.Value = (int)tt;
                labelComponent4.Text = tt + "%";
            }
        }

        private void totalEffiRetriChart(DataTable dtEquipTotal)
        {

            // 전체 작업효율 / 회수율
            if (dtEquipTotal.Rows.Count > 0)
            {
                //작업효율
                String WorkAffect = dtEquipTotal.Rows[7]["MONTH" + DateTime.Now.ToString("MM")].ToString();
                //회수율
                String RetrieveRate = dtEquipTotal.Rows[8]["MONTH" + DateTime.Now.ToString("MM")].ToString();

                SearchTotalEfficiencyChart(dtEquipTotal);

                TotalWorkAffect_Gauge.Value = int.Parse(WorkAffect);
                TotalRetrieveRate_Gauge.Value = int.Parse(RetrieveRate);

                TotalWorkAffect_Label.Text = WorkAffect + '%';
                TotalRetrieveRate_Label.Text = RetrieveRate + '%';
            }
        }

        private void totalProductionChart(DataSet dsTotalChart)
        {

            if (dsTotalChart.Tables.Count > 0)
            {
                SearchTotalProductionChart(dsTotalChart);

                decimal tt = TotalProductionGagueValue;
                tt = Math.Truncate(tt);

                TotalPerformance_GaugeArc.Value = (int)tt;
                TotalProduction_Label.Text = tt.ToString() + "%";
            }
        }

        private void totalEquipmentChart(DataTable dtTotalEquip)
        {

            if (dtTotalEquip.Rows.Count > 0)
            {
                foreach (DataRow row in dtTotalEquip.Rows)
                {
                    if (row["MONTH"].ToString().Equals(DateTime.Now.ToString("MM")))
                    {
                        int value = 0;
                        int state = 0;

                        switch (row["EQUIPMENTID"])
                        {
                            case "MG17007": //WT-300
                                value = removeDecimal(row["VALUE"].ToString());
                                equip_1_progressBar.Value = value;
                                equip_1_label.Text = Convert.ToString(value) + " %";
                                state = checkStateRunOrIdle("MG17007"); // 가동 / 비가동 / 알람 체크
                                equip_1_progressBar.SetState(state);
                                equip_1_label.ForeColor = changeProgessLableColor(state);
                                break;

                            case "MG17006": //MT-2000
                                value = removeDecimal(row["VALUE"].ToString());
                                equip_2_progressBar.Value = value;
                                equip_2_label.Text = Convert.ToString(value) + " %";
                                state = checkStateRunOrIdle("MG17006"); // 가동 / 비가동 / 알람 체크
                                equip_2_progressBar.SetState(state);
                                equip_2_label.ForeColor = changeProgessLableColor(state);
                                break;

                            case "MG17005": //NL2500/700
                                value = removeDecimal(row["VALUE"].ToString());
                                equip_5_progressBar.Value = value;
                                equip_5_label.Text = Convert.ToString(value) + " %";
                                state = checkStateRunOrIdle("MG17005"); // 가동 / 비가동 / 알람 체크
                                equip_5_progressBar.SetState(state);
                                equip_5_label.ForeColor = changeProgessLableColor(state);
                                break;

                            case "MG17004": //NL2500/1250SY
                                value = removeDecimal(row["VALUE"].ToString());
                                equip_7_progressBar.Value = value;
                                equip_7_label.Text = Convert.ToString(value) + " %";
                                state = checkStateRunOrIdle("MG17004"); // 가동 / 비가동 / 알람 체크
                                equip_7_progressBar.SetState(state);
                                equip_7_label.ForeColor = changeProgessLableColor(state);
                                break;

                            case "MG17003": //WT-250Ⅱ 2호기
                                value = removeDecimal(row["VALUE"].ToString());
                                equip_3_progressBar.Value = value;
                                equip_3_label.Text = Convert.ToString(value) + " %";
                                state = checkStateRunOrIdle("MG17003"); // 가동 / 비가동 / 알람 체크
                                equip_3_progressBar.SetState(state);
                                equip_3_label.ForeColor = changeProgessLableColor(state);
                                break;

                            case "MG17002": //WT-250Ⅱ 1호기
                                value = removeDecimal(row["VALUE"].ToString());
                                equip_4_progressBar.Value = value;
                                equip_4_label.Text = Convert.ToString(value) + " %";
                                state = checkStateRunOrIdle("MG17002"); // 가동 / 비가동 / 알람 체크
                                equip_4_progressBar.SetState(state);
                                equip_4_label.ForeColor = changeProgessLableColor(state);
                                break;

                            case "MG17001": //MCT/MYNX-7500
                                value = removeDecimal(row["VALUE"].ToString());
                                equip_6_progressBar.Value = value;
                                equip_6_label.Text = Convert.ToString(value) + " %";
                                state = checkStateRunOrIdle("MG17001"); // 가동 / 비가동 / 알람 체크
                                equip_6_progressBar.SetState(state);
                                equip_6_label.ForeColor = changeProgessLableColor(state);
                                break;
                        }
                    }
                }
            }
        }

        private void SearchTotalEfficiencyChart(DataTable dt)
        {

            this.TotalEfficiencyChart.DataSource = SearchEfficiencyChartTotalData(dt);

            TotalEfficiencyChart.SeriesDataMember = "Month";
            TotalEfficiencyChart.SeriesTemplate.ArgumentDataMember = "Section";
            TotalEfficiencyChart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
            TotalEfficiencyChart.SeriesTemplate.View = new SideBySideBarSeriesView();
            //TotalEfficiencyChart.SeriesNameTemplate.BeginText = "Month : ";
            TotalEfficiencyChart.BoundDataChanged += chart_BoundDataChanged_2;
        }

        private void chart_BoundDataChanged_2(object sender, EventArgs e)
        {
            ChartControl control = (ChartControl)sender;

            // 라인 차트로 변경
            //Series series = control.GetSeriesByName((LanguageType == 1) ? "Month : 작업효율" : "Month : Effcy");
            //if (series != null) series.ChangeView(ViewType.Line);
            //Series march = control.GetSeriesByName((LanguageType == 1) ? "Month : 회수율" : "Month : Recy");
            //if (march != null) march.ChangeView(ViewType.Line);
            Series series = control.GetSeriesByName(production_Efficiency_text);
            if (series != null) series.ChangeView(ViewType.Line);
            Series march = control.GetSeriesByName(production_RetrieveRate_text);
            if (march != null) march.ChangeView(ViewType.Line);

            //차트 위 둥근 점
            ((LineSeriesView)march.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((LineSeriesView)march.View).LineMarkerOptions.Kind = MarkerKind.Circle;

            ((LineSeriesView)series.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Circle;

        }

        private object SearchEfficiencyChartTotalData(DataTable dt)
        {
            DataTable table = new DataTable("Table");

            table.Columns.Add("Month", typeof(string));
            table.Columns.Add("Section", typeof(string));
            table.Columns.Add("Value", typeof(Int32));

            String month = DateTime.Now.ToString("MM");

            table.Rows.Add(new object[] { production_Efficiency_text, DateTime.Now.AddMonths(-5).ToString("MM"), int.Parse(dt.Rows[7]["MONTH" + DateTime.Now.AddMonths(-5).ToString("MM")].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, DateTime.Now.AddMonths(-5).ToString("MM"), int.Parse(dt.Rows[8]["MONTH" + DateTime.Now.AddMonths(-5).ToString("MM")].ToString()) });

            table.Rows.Add(new object[] { production_Efficiency_text, DateTime.Now.AddMonths(-4).ToString("MM"), int.Parse(dt.Rows[7]["MONTH" + DateTime.Now.AddMonths(-4).ToString("MM")].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, DateTime.Now.AddMonths(-4).ToString("MM"), int.Parse(dt.Rows[8]["MONTH" + DateTime.Now.AddMonths(-4).ToString("MM")].ToString()) });

            table.Rows.Add(new object[] { production_Efficiency_text, DateTime.Now.AddMonths(-3).ToString("MM"), int.Parse(dt.Rows[7]["MONTH" + DateTime.Now.AddMonths(-3).ToString("MM")].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, DateTime.Now.AddMonths(-3).ToString("MM"), int.Parse(dt.Rows[8]["MONTH" + DateTime.Now.AddMonths(-3).ToString("MM")].ToString()) });

            table.Rows.Add(new object[] { production_Efficiency_text, DateTime.Now.AddMonths(-2).ToString("MM"), int.Parse(dt.Rows[7]["MONTH" + DateTime.Now.AddMonths(-2).ToString("MM")].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, DateTime.Now.AddMonths(-2).ToString("MM"), int.Parse(dt.Rows[8]["MONTH" + DateTime.Now.AddMonths(-2).ToString("MM")].ToString()) });

            table.Rows.Add(new object[] { production_Efficiency_text, DateTime.Now.AddMonths(-1).ToString("MM"), int.Parse(dt.Rows[7]["MONTH" + DateTime.Now.AddMonths(-1).ToString("MM")].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, DateTime.Now.AddMonths(-1).ToString("MM"), int.Parse(dt.Rows[8]["MONTH" + DateTime.Now.AddMonths(-1).ToString("MM")].ToString()) });

            table.Rows.Add(new object[] { production_Efficiency_text, month, int.Parse(dt.Rows[7]["MONTH" + month].ToString()) });
            table.Rows.Add(new object[] { production_RetrieveRate_text, month, int.Parse(dt.Rows[8]["MONTH" + month].ToString()) });


            return table;
        }

        private int removeDecimal(String str)
        {
            decimal dec = decimal.Parse(str);
            dec = Math.Truncate(dec);
            return (int)dec;
        }

        private int checkStateRunOrIdle(String id)
        {
            int result = 0;

            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add("EQUIPMENTID", id);

            DataTable dt = SqlExecuter.Procedure("USP_TOTAL_GETEQUIPMENTSTATE", values);
            if(dt.Rows.Count > 0)
            {
                String state = dt.Rows[0]["EQUIPMENTSTATE"].ToString();
                if (state == "RUN")
                {
                    result = 1;
                }
                else if (state == "IDLE")
                {
                    result = 3;
                }
                else
                {
                    result = 2;
                }

              
            }
            return result;
        }

        private Color changeProgessLableColor(int state)
        {
            if (state == 3) // 비가동
            {
                return Color.FromArgb(232, 172, 12);
            }
            else if (state == 2) // 알람
            {
                return Color.Red;
            }
            else // 가동
            {
                return Color.Black;
            }
        }

        private void setTeamProductionChartRange(int value)
        {
            int maxVlaue;

            if (value < 100)
            {
                maxVlaue = 100;
            }
            else if (value >= 100 & value < 200)
            {
                maxVlaue = 200;
            }
            else
            {
                maxVlaue = 300;
            }

            XYDiagram diagramTeamPro = (XYDiagram)TeamProductionChart.Diagram;
            diagramTeamPro.AxisY.WholeRange.SetMinMaxValues(0, maxVlaue);

        }

        private void setTotalProductionChartRange(int value)
        {
            int maxVlaue;

            if (value < 100)
            {
                maxVlaue = 100;
            }
            else if (value >= 100 & value < 200)
            {
                maxVlaue = 200;
            }
            else
            {
                maxVlaue = 300;
            }

            XYDiagram diagramTeamPro = (XYDiagram)TotalProductionChart.Diagram;
            diagramTeamPro.AxisY.WholeRange.SetMinMaxValues(0, maxVlaue);

        }


        #region 디자인 레이아웃 // 색상

        private void TeamAllLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;

            using (Pen pen = new Pen(Color.FromArgb(229, 232, 235), 0 /*1px width despite of page scale, dpi, page units*/ ))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                // define border style
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                // decrease border rectangle height/width by pen's width for last row/column cell
                if (e.Row == (TeamAllLayoutPanel.RowCount - 1))
                {
                    r.Height -= 1;
                }

                if (e.Column == (TeamAllLayoutPanel.ColumnCount - 1))
                {
                    r.Width -= 1;
                }

                // use graphics mehtods to draw cell's border
                e.Graphics.DrawRectangle(pen, r);
            }
        }

        private void TotalChartLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;

            using (Pen pen = new Pen(Color.FromArgb(229, 232, 235), 0 /*1px width despite of page scale, dpi, page units*/ ))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                // define border style
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                // decrease border rectangle height/width by pen's width for last row/column cell
                if (e.Row == (totalChartLayoutPanel.RowCount - 1))
                {
                    r.Height -= 1;
                }

                if (e.Column == (totalChartLayoutPanel.ColumnCount - 1))
                {
                    r.Width -= 1;
                }

                // use graphics mehtods to draw cell's border
                e.Graphics.DrawRectangle(pen, r);
            }
        }

        private void TotalEquipmentLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;

            using (Pen pen = new Pen(Color.FromArgb(229, 232, 235), 0 /*1px width despite of page scale, dpi, page units*/ ))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                // define border style
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                // decrease border rectangle height/width by pen's width for last row/column cell
                if (e.Row == (TotalEquipmentLayoutPanel.RowCount - 1))
                {
                    r.Height -= 1;
                }

                if (e.Column == (TotalEquipmentLayoutPanel.ColumnCount - 1))
                {
                    r.Width -= 1;
                }

                // use graphics mehtods to draw cell's border
                e.Graphics.DrawRectangle(pen, r);
            }
        }

        private void TeamProductionGaugeLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;

            using (Pen pen = new Pen(Color.FromArgb(241, 244, 247), 0 /*1px width despite of page scale, dpi, page units*/ ))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                if (e.Row == (TeamProductionGaugeLayoutPanel2.RowCount - 1))
                {
                    r.Height -= 1;
                }

                if (e.Column == (TeamProductionGaugeLayoutPanel2.ColumnCount - 1))
                {
                    r.Width -= 1;
                }

                e.Graphics.DrawRectangle(pen, r);
            }
        }

        private void teamProductionGaugeLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;

            using (Pen pen = new Pen(Color.FromArgb(241, 244, 247), 0 /*1px width despite of page scale, dpi, page units*/ ))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                // define border style
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                // decrease border rectangle height/width by pen's width for last row/column cell
                if (e.Row == (TeamProductionGaugeLayoutPanel.RowCount - 1))
                {
                    r.Height -= 1;
                }

                if (e.Column == (TeamProductionGaugeLayoutPanel.ColumnCount - 1))
                {
                    r.Width -= 1;
                }

                // use graphics mehtods to draw cell's border
                e.Graphics.DrawRectangle(pen, r);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Solid);
        }

        #endregion

        #region ▶ ThreadStart |
        /// <summary>
        /// Start thread
        /// </summary>
        private void ThreadStart()
        {
            this._isRunTimer = true;

            if (this._threadReading == null || !this._threadReading.IsAlive)
                this.ThreadStartUp();
        }


        #region ▶ ThreadStop |
        /// <summary>
        /// Stop thread
        /// </summary>
        private void ThreadStop()
        {
            this._isRunTimer = false;
        }
        #endregion

        #region ▶ThreadStartUp |
        // <summary>
        /// ThreadStartUp
        /// </summary>
        private void ThreadStartUp()
        {
            this._threadReading = new Thread(new ThreadStart(delegate { ThreadReading(); }));

            this._threadReading.Start();

            this._threadReading.IsBackground = true;
        }
        #endregion

        #region ▶ ThreadReading |
        /// <summary>
        /// ThreadReading
        /// </summary>
        public void ThreadReading()
        {
            while (this._isRunTimer)
            {
                try
                {
                    Thread.Sleep(2 * 1000);

                    this.Invoke(new tDelegate(SearchData));

                    if (ThreadTime == null || ThreadTime == 0)
                    {
                        ThreadTime = 10;
                    }

                    Thread.Sleep(ThreadTime.ToInt32() * 1000);
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
            }
        }
        #endregion

        #endregion
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            // 1 : green, 2 : red, 3 : yellow
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
