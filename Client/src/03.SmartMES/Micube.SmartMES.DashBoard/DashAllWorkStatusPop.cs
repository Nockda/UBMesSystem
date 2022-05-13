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
    public partial class DashAllWorkStatusPop : SmartPopupBaseForm, ISmartCustomPopup
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
        public DashAllWorkStatusPop()
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
            // 각 Line별 Panel의 색상 및 투명도 지정
        }
        #endregion

        #region ◆ Event |
        /// <summary>
        /// Event
        /// </summary>
        private void InitializeEvent()
        {
            this.Load += Form_Load;

            this.picLogo.Click += PicLogo_Click;

            picLogo.MouseHover += PicLogo_MouseHover;
            picLogo.MouseLeave += PicLogo_MouseLeave;
        }

        #region ▶ Mouse Event Leave  :: PicLogo_MouseLeave |
        /// <summary>
        /// Mouse Event Leave 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicLogo_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region ▶ Mouse Hover  :: PicLogo_MouseHover |
        /// <summary>
        /// Mouse Hover 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicLogo_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        } 
        #endregion

        #region ▶ Form Close |
        /// <summary>
        /// Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicLogo_Click(object sender, EventArgs e)
        {
            ThreadStop();

            this.Close();
        } 
        #endregion

        #endregion

        #region ◆ 데이터 검색 |
        /// <summary>
        /// 데이터 검색
        /// </summary>
        private void SearchData()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            DataTable dt = SqlExecuter.Procedure("USP_DASH_ALLWORKSTATUS", param, null);

            ClearScreen();

            if (dt != null && dt.Rows.Count > 0)
            {
                // MACH LINE
                var mach = from dr in dt.AsEnumerable()
                           where dr["TEAMID"].ToString().Equals("T01")
                           select new
                           {
                               PlanQty = dr["PLANQTY"].ToString(),
                               ResultQty = dr["RESULTQTY"].ToString(),
                               Ratio = dr["MONTHPERCENT"].ToString()
                           };

                foreach(var row in mach)
                {
                    this.lblMachTargetQty.Text = row.PlanQty;
                    this.lblMachResultQty.Text = row.ResultQty;
                    this.lblMachRatioQty.Text = row.Ratio;
                }

                // COMP LINE
                var comp = from dr in dt.AsEnumerable()
                           where dr["TEAMID"].ToString().Equals("T02")
                           select new
                           {
                               PlanQty = dr["PLANQTY"].ToString(),
                               ResultQty = dr["RESULTQTY"].ToString(),
                               Ratio = dr["MONTHPERCENT"].ToString()
                           };

                foreach (var row in comp)
                {
                    this.lblCompTargetQty.Text = row.PlanQty;
                    this.lblCompResultQty.Text = row.ResultQty;
                    this.lblCompRatioQty.Text = row.Ratio;
                }

                // REF LINE
                var refline = from dr in dt.AsEnumerable()
                           where dr["TEAMID"].ToString().Equals("T03")
                           select new
                           {
                               PlanQty = dr["PLANQTY"].ToString(),
                               ResultQty = dr["RESULTQTY"].ToString(),
                               Ratio = dr["MONTHPERCENT"].ToString()
                           };

                foreach (var row in refline)
                {
                    this.lblRefTargetQty.Text = row.PlanQty;
                    this.lblRefResultQty.Text = row.ResultQty;
                    this.lblRefRatioQty.Text = row.Ratio;
                }

                // PUMP LINE
                var pump = from dr in dt.AsEnumerable()
                              where dr["TEAMID"].ToString().Equals("T04")
                              select new
                              {
                                  PlanQty = dr["PLANQTY"].ToString(),
                                  ResultQty = dr["RESULTQTY"].ToString(),
                                  Ratio = dr["MONTHPERCENT"].ToString()
                              };

                foreach (var row in pump)
                {
                    this.lblPumpTargetQty.Text = row.PlanQty;
                    this.lblPumpResultQty.Text = row.ResultQty;
                    this.lblPumpRatioQty.Text = row.Ratio;
                }

                // RMC PUMP LINE
                var rmc_pump = from dr in dt.AsEnumerable()
                           where dr["TEAMID"].ToString().Equals("T05")
                           select new
                           {
                               PlanQty = dr["PLANQTY"].ToString(),
                               ResultQty = dr["RESULTQTY"].ToString(),
                               Ratio = dr["MONTHPERCENT"].ToString()
                           };

                foreach (var row in rmc_pump)
                {
                    this.lblRMCPumpTargetQty.Text = row.PlanQty;
                    this.lblRMCPumpResultQty.Text = row.ResultQty;
                    this.lblRMCPumpRatioQty.Text = row.Ratio;
                }

                // RMC COMP LINE
                var rmc_comp = from dr in dt.AsEnumerable()
                               where dr["TEAMID"].ToString().Equals("T06")
                               select new
                               {
                                   PlanQty = dr["PLANQTY"].ToString(),
                                   ResultQty = dr["RESULTQTY"].ToString(),
                                   Ratio = dr["MONTHPERCENT"].ToString()
                               };

                foreach (var row in rmc_comp)
                {
                    this.lblRMCCompTargetQty.Text = row.PlanQty;
                    this.lblRMCCompResultQty.Text = row.ResultQty;
                    this.lblRMCCompRatioQty.Text = row.Ratio;
                }
            }
        }

        private void ClearScreen()
        {
            this.lblMachTargetQty.Text = "0";
            this.lblMachResultQty.Text = "0";
            this.lblMachRatioQty.Text = "0 %";

            this.lblCompTargetQty.Text = "0";
            this.lblCompResultQty.Text = "0";
            this.lblCompRatioQty.Text = "0 %";

            this.lblRefTargetQty.Text = "0";
            this.lblRefResultQty.Text = "0";
            this.lblRefRatioQty.Text = "0 %";

            this.lblPumpTargetQty.Text = "0";
            this.lblPumpResultQty.Text = "0";
            this.lblPumpRatioQty.Text = "0 %";

            this.lblRMCPumpTargetQty.Text = "0";
            this.lblRMCPumpResultQty.Text = "0";
            this.lblRMCPumpRatioQty.Text = "0 %";

            this.lblRMCCompTargetQty.Text = "0";
            this.lblRMCCompResultQty.Text = "0";
            this.lblRMCCompRatioQty.Text = "0 %";
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

        #endregion
    }
}
