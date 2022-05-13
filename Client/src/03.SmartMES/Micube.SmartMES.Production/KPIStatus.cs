#region using

using DevExpress.XtraCharts;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.Frames.FrameHelper;
using Language = Micube.Framework.Language;

#endregion

namespace Micube.SmartMES.Production
{
    /// <summary>
    /// 프 로 그 램 명  : 생산관리 > 작업효율 > 작업효율현황
    /// 업  무  설  명  : 작업효율현황을 조회한다
    /// 생    성    자  : 한주석
    /// 생    성    일  : 2020-06-17
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class KPIStatus : SmartConditionBaseForm
    {
        #region Local Variables

        // TODO : 화면에서 사용할 내부 변수 추가
        string _Text;                                       // 설명

        
        #endregion

        #region 생성자

        public KPIStatus()
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
            SetHideCondition();
        }

        /// <summary>        
        /// 코드그룹 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            InitializeGridAll();
            InitiallzeGridTeam();
           
        }

        private void InitiallzeGridTeam()
        {
            // TODO : 그리드 초기화 로직 추가
            grdTeam.GridButtonItem = GridButtonItem.Export;
            grdTeam.View.ClearColumns();
            grdTeam.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;

            grdTeam.View.SetIsReadOnly();

            grdTeam.View.AddComboBoxColumn("TYPE", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=WorkAffectDiv", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetLabel("TYPE");

            //전년도 하반기
            // TODO : 조회조건에따라 그룹 캡션 변경
            grdTeam.View.AddTextBoxColumn("MONTH1", 90).SetLabel("JANUARY").SetTextAlignment(TextAlignment.Right);
            grdTeam.View.AddTextBoxColumn("MONTH2", 90).SetLabel("FEBURARY").SetTextAlignment(TextAlignment.Right);
            grdTeam.View.AddTextBoxColumn("MONTH3", 90).SetLabel("MARCH").SetTextAlignment(TextAlignment.Right);
            grdTeam.View.AddTextBoxColumn("MONTH4", 90).SetLabel("APRIL").SetTextAlignment(TextAlignment.Right);
            grdTeam.View.AddTextBoxColumn("MONTH5", 90).SetLabel("MAY").SetTextAlignment(TextAlignment.Right);
            grdTeam.View.AddTextBoxColumn("MONTH6", 90).SetLabel("JUNE").SetTextAlignment(TextAlignment.Right);

            grdTeam.View.AddTextBoxColumn("MONTH7", 90).SetLabel("JULY").SetTextAlignment(TextAlignment.Right);
            grdTeam.View.AddTextBoxColumn("MONTH8", 90).SetLabel("AUGUST").SetTextAlignment(TextAlignment.Right);
            grdTeam.View.AddTextBoxColumn("MONTH9", 90).SetLabel("SEPTEMBER").SetTextAlignment(TextAlignment.Right);
            grdTeam.View.AddTextBoxColumn("MONTH10", 90).SetLabel("OCTOBER").SetTextAlignment(TextAlignment.Right);
            grdTeam.View.AddTextBoxColumn("MONTH11", 90).SetLabel("NOVEMBER").SetTextAlignment(TextAlignment.Right);
            grdTeam.View.AddTextBoxColumn("MONTH12", 90).SetLabel("DECEMBER").SetTextAlignment(TextAlignment.Right);

            grdTeam.View.AddTextBoxColumn("SUM", 90).SetTextAlignment(TextAlignment.Right);

            grdTeam.View.PopulateColumns();
        }

        private void InitializeGridAll()
        {
            // TODO : 그리드 초기화 로직 추가
            grdAll.GridButtonItem = GridButtonItem.Export;
            grdAll.View.ClearColumns();
            grdAll.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;

            grdAll.View.SetIsReadOnly();

            grdAll.View.AddComboBoxColumn("TYPE", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=WorkAffectDiv", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetLabel("TYPE");

            //전년도 하반기
            // TODO : 조회조건에따라 그룹 캡션 변경
            grdAll.View.AddTextBoxColumn("MONTH1", 90).SetLabel("JANUARY").SetTextAlignment(TextAlignment.Right);
            grdAll.View.AddTextBoxColumn("MONTH2", 90).SetLabel("FEBURARY").SetTextAlignment(TextAlignment.Right);
            grdAll.View.AddTextBoxColumn("MONTH3", 90).SetLabel("MARCH").SetTextAlignment(TextAlignment.Right);
            grdAll.View.AddTextBoxColumn("MONTH4", 90).SetLabel("APRIL").SetTextAlignment(TextAlignment.Right);
            grdAll.View.AddTextBoxColumn("MONTH5", 90).SetLabel("MAY").SetTextAlignment(TextAlignment.Right);
            grdAll.View.AddTextBoxColumn("MONTH6", 90).SetLabel("JUNE").SetTextAlignment(TextAlignment.Right);

            grdAll.View.AddTextBoxColumn("MONTH7", 90).SetLabel("JULY").SetTextAlignment(TextAlignment.Right);
            grdAll.View.AddTextBoxColumn("MONTH8", 90).SetLabel("AUGUST").SetTextAlignment(TextAlignment.Right);
            grdAll.View.AddTextBoxColumn("MONTH9", 90).SetLabel("SEPTEMBER").SetTextAlignment(TextAlignment.Right);
            grdAll.View.AddTextBoxColumn("MONTH10", 90).SetLabel("OCTOBER").SetTextAlignment(TextAlignment.Right);
            grdAll.View.AddTextBoxColumn("MONTH11", 90).SetLabel("NOVEMBER").SetTextAlignment(TextAlignment.Right);
            grdAll.View.AddTextBoxColumn("MONTH12", 90).SetLabel("DECEMBER").SetTextAlignment(TextAlignment.Right);

            grdAll.View.AddTextBoxColumn("SUM", 90).SetTextAlignment(TextAlignment.Right);

            grdAll.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // TODO : 화면에서 사용할 이벤트 추가
            MainTab.SelectedPageChanged += MainTab_SelectedPageChanged;
         
        }

        private void MainTab_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            SetHideCondition();
        }

        private void SetHideCondition()
        {
            SmartComboBox combo = Conditions.GetControl<SmartComboBox>("p_team");

            DevExpress.XtraLayout.LayoutControlItem controlItem = this.pnlCondition.GetItemByControl(combo);

            if (this.MainTab.SelectedTabPageIndex == 0)
            {
                controlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.Conditions.GetCondition("P_TEAM").IsRequired = false;
            }
            else
            {
                controlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.Conditions.GetCondition("P_TEAM").IsRequired = true;
            }
        }

        /// <summary>
        /// 코드그룹 리스트 그리드에서 추가 버튼 클릭 시 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

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
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            if( this.MainTab.SelectedTabPageIndex == 0)
            {
                if(values.ContainsKey("P_TEAM"))
                    values.Remove("P_TEAM");
            }

            DataTable dtCodeClass = SqlExecuter.Query("SelectKPIState", "00002", values);

            if (this.MainTab.SelectedTabPageIndex == 0)
            {
                SetData(AllChart, grdAll, dtCodeClass, values);
            }
            else
            {
                SetData(TeamChart, grdTeam, dtCodeClass, values);
            }

        }

        private void SetData(SmartChart chart, SmartBandedGrid grd, DataTable dtCodeClass, Dictionary<string, object> values)
        {

            if (dtCodeClass.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                InitializeContent();
                chart.Series.Clear();
                chart.Controls.Clear();
                chart.Legends.Clear();
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.

            }

            else
            {
                grd.View.AddTextBoxColumn("MONTH1", 90).SetLabel("JANUARY").SetTextAlignment(TextAlignment.Right);
                grd.View.AddTextBoxColumn("MONTH2", 90).SetLabel("FEBURARY").SetTextAlignment(TextAlignment.Right);
                grd.View.AddTextBoxColumn("MONTH3", 90).SetLabel("MARCH").SetTextAlignment(TextAlignment.Right);
                grd.View.AddTextBoxColumn("MONTH4", 90).SetLabel("APRIL").SetTextAlignment(TextAlignment.Right);
                grd.View.AddTextBoxColumn("MONTH5", 90).SetLabel("MAY").SetTextAlignment(TextAlignment.Right);
                grd.View.AddTextBoxColumn("MONTH6", 90).SetLabel("JUNE").SetTextAlignment(TextAlignment.Right);

                grd.View.AddTextBoxColumn("MONTH7", 90).SetLabel("JULY").SetTextAlignment(TextAlignment.Right);
                grd.View.AddTextBoxColumn("MONTH8", 90).SetLabel("AUGUST").SetTextAlignment(TextAlignment.Right);
                grd.View.AddTextBoxColumn("MONTH9", 90).SetLabel("SEPTEMBER").SetTextAlignment(TextAlignment.Right);
                grd.View.AddTextBoxColumn("MONTH10", 90).SetLabel("OCTOBER").SetTextAlignment(TextAlignment.Right);
                grd.View.AddTextBoxColumn("MONTH11", 90).SetLabel("NOVEMBER").SetTextAlignment(TextAlignment.Right);
                grd.View.AddTextBoxColumn("MONTH12", 90).SetLabel("DECEMBER").SetTextAlignment(TextAlignment.Right);


                DataTable dtcopy = dtCodeClass.Copy();

                grd.DataSource = dtcopy;

                chart.Series.Clear();
                chart.Controls.Clear();
                chart.Legends.Clear();
                chart.Titles.Clear();


                Dictionary<string, Series> seriesList = new Dictionary<string, Series>();


                dtCodeClass.Rows.RemoveAt(0);
                dtCodeClass.Rows.RemoveAt(0);
                dtCodeClass.Rows.RemoveAt(0);
                dtCodeClass.Rows.RemoveAt(0);
                dtCodeClass.Rows.RemoveAt(0);
                dtCodeClass.Rows.RemoveAt(0);

                DataTable month = SqlExecuter.Query("GetMonth", "00001", values);

                DataTable dt = new DataTable();

                dt.Columns.Add("MONTH");
                dt.Columns.Add("VALUE");
                dt.Columns.Add("TYPENAME");
                var arrayNames = (from DataColumn x in dtCodeClass.Columns
                                  select x.ColumnName).ToArray();

                for (int j = 0; j < 3; j++)
                {
                    for (int i = 2; i < 14; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["MONTH"] = month.Rows[i - 2]["CODENAME"];
                        dr["VALUE"] = dtCodeClass.Rows[j][arrayNames[i]];
                        dr["TYPENAME"] = dtCodeClass.Rows[j]["TYPENAME"];
                        dt.Rows.Add(dr);
                    }


                }

                string teamName = Conditions.GetControl<SmartComboBox>("p_team").GetDisplayText();
                ChartTitle title = new ChartTitle();
                if (this.MainTab.SelectedTabPageIndex == 0)
                    teamName = "ALL";

                title.Text = Language.Get("PRODUCTINDICATOR") + "(" + teamName + ")";

                #region 주석처리
                /*
                string te = Format.GetString(values["P_TEAM"]);

                if(te.Equals("T01"))
                {
                    title.Text = Language.Get("MACH");

                }
                else if (te.Equals("T02"))
                {
                    title.Text = Language.Get("COMP");

                }
                else if (te.Equals("T03"))
                {
                    title.Text = Language.Get("REF");

                }
                else if (te.Equals("T04"))
                {
                    title.Text = Language.Get("PUMP");

                }
                else if (te.Equals("T05"))
                {
                    title.Text = Language.Get("RM");

                }
                else if (te.Equals("T06"))
                {
                    title.Text = Language.Get("ACC");

                }
                */
                #endregion

                title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;

                title.Font = new Font("Tahoma", 20, FontStyle.Bold);
                title.TextColor = Color.FromArgb(0, 91, 150);
                title.Indent = 10;

                chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                chart.Titles.Add(title);

                Font f;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];

                    string parameterID = row["TYPENAME"].ToString();
                    string dateTime = row["MONTH"].ToString();
                    double value = Convert.ToDouble(row["VALUE"]);

                    Series series;
                    if (seriesList.TryGetValue(parameterID, out series) == false)
                    {
                        if (i < 12)
                        {
                            seriesList.Add(parameterID, series = new Series(parameterID, ViewType.Bar));
                            ((BarSeriesView)series.View).Color = Color.FromArgb(255, 193, 177);
                            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        }
                        else if (i < 24)
                        {
                            seriesList.Add(parameterID, series = new Series(parameterID, ViewType.Line));
                            (series.View as LineSeriesView).Color = Color.FromArgb(163, 145, 147);
                            //라인크기
                            ((LineSeriesView)series.View).LineStyle.Thickness = 1;
                        }
                        else
                        {
                            seriesList.Add(parameterID, series = new Series(parameterID, ViewType.Line));
                            //라인크기
                            ((LineSeriesView)series.View).LineStyle.Thickness = 1;
                            (series.View as LineSeriesView).Color = Color.FromArgb(113, 174, 242);
                        }

                        //ArgumentScaleType 변경
                        series.ArgumentScaleType = ScaleType.Qualitative;
                        chart.Series.Add(series);
                    }
                    SeriesPoint point = new SeriesPoint(dateTime, value);
                    series.Points.Add(point);
                    string name = Language.Get("RECOVERYTIME");
                    f = new Font("Verdana", 15, FontStyle.Bold);
                    ((XYDiagram)chart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                    ((XYDiagram)chart.Diagram).AxisY.Title.Text = name;
                    ((XYDiagram)chart.Diagram).AxisY.Title.TextColor = Color.Black;
                    ((XYDiagram)chart.Diagram).AxisY.Title.Font = f;
                    name = Language.Get("MONTH");
                    ((XYDiagram)chart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                    ((XYDiagram)chart.Diagram).AxisX.Title.Text = name;
                    ((XYDiagram)chart.Diagram).AxisX.Title.TextColor = Color.Black;
                    ((XYDiagram)chart.Diagram).AxisX.Title.Font = f;
                    f = new Font("Verdana", 10, FontStyle.Bold);
                    ((XYDiagram)chart.Diagram).AxisX.Label.TextColor = Color.Black;
                    ((XYDiagram)chart.Diagram).AxisX.Label.Font = f;
                    ((XYDiagram)chart.Diagram).AxisY.Label.TextColor = Color.Black;
                    ((XYDiagram)chart.Diagram).AxisY.Label.Font = f;
                }
                chart.Dock = DockStyle.Fill;
                chart.Size = new Size(1000, 1000);
                Font f2 = new Font("Verdana", 8, FontStyle.Bold);
                ((XYDiagram)chart.Diagram).SecondaryAxesY.Clear();

                SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");
                myAxisY.Title.Text = "Percent(%)";
                myAxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                myAxisY.Title.TextColor = Color.Black;
                myAxisY.Label.Font = f2;

                ((XYDiagram)chart.Diagram).SecondaryAxesY.Add(myAxisY);
                ((LineSeriesView)chart.Series[1].View).AxisY = myAxisY;
                ((LineSeriesView)chart.Series[2].View).AxisY = myAxisY;
            }
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
            SmartDateEdit dateEdit = Conditions.GetControl<SmartDateEdit>("p_year");
            dateEdit.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            dateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateEdit.Properties.Mask.EditMask = "yyyy";
            dateEdit.EditValue = DateTime.Now;

            // 악세서리팀 제외하여 조회
            SqlQuery condition = new SqlQuery("GetTeamList", "00002", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_NOTIN=*");
            DataTable conditionTable = condition.Execute();
            this.Conditions.GetControl<SmartComboBox>("p_team").DataSource = conditionTable;
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

        }

        #endregion

        #region Private Function

        // TODO : 화면에서 사용할 내부 함수 추가
        /// <summary>
        /// 마스터 정보를 조회한다.
        /// </summary>
        private void LoadData()
        {

        }

        #endregion

        private void lblExportReverse_Click(object sender, EventArgs e)
        {
            if (this.MainTab.SelectedTabPageIndex == 0)
            {
                ExportToExcel(AllChart);
            }
            else
            {
                ExportToExcel(TeamChart);
            }
        }

        private void ExportToExcel(SmartChart parameterChart)
        {
            using (var saveFileDialog = new SaveFileDialog { Filter = "XLSX file|*.xlsx|XLS file|*.xls", Title = "Save an Excel File" })
            {
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != string.Empty)
                {
                    var fileStream = (System.IO.FileStream)saveFileDialog.OpenFile();

                    parameterChart.ExportToXlsx(fileStream);
                    fileStream.Close();

                    ProcessStartInfo psi = new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true };
                    Process.Start(psi);
                }
            }
        }
    }
}