#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using DevExpress.Utils;
using DevExpress.XtraCharts;
#endregion

namespace Micube.SmartMES.DashBoard
{
    /// <summary>
    /// 프 로 그 램 명  : DashBoard > 생산 현황
    /// 업  무  설  명  : 대쉬보드 - 생산 현황 팝업
    /// 생    성    자  : jhpark
    /// 생    성    일  : 2020-06-18
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class DashWorkResultPop : SmartPopupBaseForm, ISmartCustomPopup
    {
        #region ◆ Variables |
        public DataRow CurrentDataRow { get; set; }

        // Thread Time 설정
        public int? ThreadTime { get; set; }

        public string DashArea { get; set; }

        public string DashAreaName { get; set; }

        // Thread
        private Thread _threadReading;
        // Timer 동작여부
        private bool _isRunTimer = false;

        // Delegate
        public delegate void tDelegate();
        #endregion

        #region ◆ 생성자 |
        /// <summary>
        /// 생성자
        /// </summary>
        public DashWorkResultPop()
        {
            InitializeComponent();

            InitializeEvent();
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form_Load(object sender, EventArgs e)
        {
            InitializeControls();

            // Thread Start
            ThreadStart();
        }
        #endregion

        #region ◆ Control 초기화 |
        /// <summary>
        /// Control 초기화
        /// </summary>
        private void InitializeControls()
        {
            lblDate.Text = DateTime.Now.ToShortDateString();

            lblMainTitle.Text = DashAreaName;

            if (DashArea.Equals("T01"))
            {
                pictureBox2.BackgroundImage = global::Micube.SmartMES.DashBoard.Properties.Resources.LINE01;
            }
            else if (DashArea.Equals("T02"))
            {
                pictureBox2.BackgroundImage = global::Micube.SmartMES.DashBoard.Properties.Resources.LINE04;
            }
            else if (DashArea.Equals("T03") || DashArea.Equals("T05"))
            {
                pictureBox2.BackgroundImage = global::Micube.SmartMES.DashBoard.Properties.Resources.LINE03;
            }
            else if (DashArea.Equals("T04") || DashArea.Equals("T06"))
            {
                pictureBox2.BackgroundImage = global::Micube.SmartMES.DashBoard.Properties.Resources.LINE03;
            }
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }
        #endregion

        #region ◆ Event |
        /// <summary>
        /// Event
        /// </summary>
        private void InitializeEvent()
        {
            this.Load += Form_Load;

            // 날짜 Event
            lblDate.MouseHover += LblDate_MouseHover;
            lblDate.MouseLeave += LblDate_MouseLeave;

            lblDate.Click += LblDate_Click;
        }

        #region ▶ Form Close |
        /// <summary>
        /// Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblDate_Click(object sender, EventArgs e)
        {
            ThreadStop();

            this.Close();
        }
        #endregion

        #region ▶ Mouse Hover / Leave Event |
        /// <summary>
        /// MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblDate_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblDate_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
        #endregion

        #endregion

        #region ◆ 데이터 검색 |
        /// <summary>
        /// 데이터 검색
        /// </summary>
        private void SearchData()
        {
            lblDate.Text = DateTime.Now.ToShortDateString();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TEAMID", DashArea);
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataSet ds = SqlExecuter.ProcedureToDataSet("USP_DASH_AREAWORKSTATUS", param);

            ClearScreen();

            if (ds.Tables.Count > 0)
            {
                DataTable dt1 = ds.Tables[0];
                DataRow dr = dt1.Rows[0];
                lblMonthTargetQty.Text = dr["PLANQTY"].ToString();
                lblMonthResultQty.Text = dr["RESULTQTY"].ToString();
                lblMonthPercent.Text = dr["MONTHPERCENT"].ToString();

                DataTable dt2 = ds.Tables[1];
                DataRow dr2 = dt2.Rows[0];
                lblDayTargetQty.Text = dr2["PLANQTY"].ToString();
                lblDayWorkResultQty.Text = dr2["RESULTQTY"].ToString();
                lblDayPercent.Text = dr2["MONTHPERCENT"].ToString();

                //DataTable dt3 = ds.Tables[2];
                //SetChart1(chart1, dt3);

                if (ds.Tables.Count > 2)
                {
                    DataTable dt4 = ds.Tables[2];
                    SetChart2(chart2, dt4);
                }
            }
        }

        private void ClearScreen()
        {
            lblMonthTargetQty.Text = "0";
            lblMonthResultQty.Text = "0";
            lblMonthPercent.Text = "0 %";

            lblDayTargetQty.Text = "0";
            lblDayWorkResultQty.Text = "0";
            lblDayPercent.Text = "0 %";
        }
        #endregion

        #region ◆ Function |

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
        #endregion

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

        #region ▶ Pie Chart 1 설정 |
        /// <summary>
        /// Pie Chart 1 설정
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="dt"></param>
        private void SetChart1(SmartChart chart, DataTable dt)
        {
            chart.DataSource = dt;
            //Plot Chart
            chart.Series["Series01Value"].ValueDataMembers.Clear();
            chart.Series["Series01Value"].ChangeView(ViewType.Pie);
            chart.Series["Series01Value"].ArgumentDataMember = "MODELNAME";
            chart.Series["Series01Value"].ValueDataMembers.AddRange(new string[] { "PERCENTQTY" });
            chart.Series["Series01Value"].CrosshairLabelPattern = Language.Get("QTY") + " : {V}";
            chart.Series["Series01Value"].LegendTextPattern = "{A}";

            chart.Series["Series01Value"].Visible = true;
        }
        #endregion

        #region ▶ 막대 그래프 설정 :: SetChart2 |
        /// <summary>
        /// 막대 그래프 설정
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="dt"></param>
        private void SetChart2(SmartChart chart, DataTable dt)
        {
            //StackedBar Chart

            if (chart.Series.Count > 0)
            {
                chart.Series.RemoveAt(0);
            }
            Series series = new Series("Series01Value", ViewType.Bar);

            series.ArgumentDataMember = "MODELNAME";
            series.ValueDataMembers.AddRange(new string[] { "PERCENTQTY" });
            series.CrosshairLabelPattern = Language.Get("QTY") + " : {V}";
            series.LegendTextPattern = "{A}";

            series.DataSource = dt;

            series.LabelsVisibility = DefaultBoolean.True;
            series.Visible = true;
            series.View.Color = Color.Wheat;

            chart.Series.Add(series);

            // Top Label Setting
            BarSeriesLabel seriesLabel = chart.Series[0].Label as BarSeriesLabel;
            seriesLabel.BackColor = Color.Transparent;
            seriesLabel.Border.Color = Color.Transparent;
            seriesLabel.Font = new Font("Tahoma", 16, FontStyle.Regular);
            seriesLabel.TextColor = Color.White;
            seriesLabel.Position = BarSeriesLabelPosition.Top;
            seriesLabel.TextOrientation = TextOrientation.Horizontal;
            seriesLabel.TextPattern = "{V:F1}";
        } 
        #endregion
        #endregion
    }
}
