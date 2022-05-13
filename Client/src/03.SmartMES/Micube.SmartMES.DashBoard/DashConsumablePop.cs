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
#endregion

namespace Micube.SmartMES.DashBoard
{
    /// <summary>
    /// 프 로 그 램 명  : DashBoard > 자재 입출고 현황
    /// 업  무  설  명  : 대쉬보드 - 자재입출고 현황 팝업
    /// 생    성    자  : jhpark
    /// 생    성    일  : 2020-06-17
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class DashConsumablePop : SmartPopupBaseForm, ISmartCustomPopup
    {
        #region ◆ Variables |
        public DataRow CurrentDataRow { get; set; }

        // Thread Time 설정
        public int? ThreadTime { get; set; }

        // Thread
        private Thread _threadReading;
        // Timer 동작여부
        private bool _isRunTimer = false;

        // 입/출고 구분
        private int _isInOutType = 1;

        // Delegate
        public delegate void tDelegate();
        #endregion

        #region ◆ 생성자 |
        /// <summary>
        /// 생성자
        /// </summary>
        public DashConsumablePop()
        {
            InitializeComponent();

            InitializeControls();
            InitializeGrid();

            InitializeEvent();

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
        }

        /// <summary>
        /// Grid 초기화
        /// </summary>
        private void InitializeGrid()
        {
            //grdConsumable
            grdConsumable.GridButtonItem = GridButtonItem.None;

            grdConsumable.View.SetIsReadOnly();
            grdConsumable.SetIsUseContextMenu(false);

            grdConsumable.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 200).SetTextAlignment(TextAlignment.Left);
            grdConsumable.View.AddTextBoxColumn("CONSUMABLEDEFID", 120).SetTextAlignment(TextAlignment.Center);
            grdConsumable.View.AddTextBoxColumn("QTY", 80).SetTextAlignment(TextAlignment.Center);
            grdConsumable.View.AddTextBoxColumn("STATE", 100).SetTextAlignment(TextAlignment.Center);

            grdConsumable.View.PopulateColumns();

            Font fnt = new Font("Tahoma", 30F);
            grdConsumable.View.Appearance.HeaderPanel.Font = fnt;

            grdConsumable.View.Appearance.Row.Font = fnt;
            grdConsumable.View.Appearance.Row.BackColor = System.Drawing.Color.Black;
            grdConsumable.View.Appearance.Row.ForeColor = System.Drawing.Color.White;
            grdConsumable.View.Appearance.Empty.BackColor = Color.Black;

            grdConsumable.View.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            grdConsumable.View.RowHeight = 20;

            grdConsumable.View.OptionsView.ShowIndicator = false;

            grdConsumable.View.OptionsView.ColumnAutoWidth = true;
        }

        #endregion

        #region ◆ Event |
        /// <summary>
        /// Event
        /// </summary>
        private void InitializeEvent()
        {
            grdConsumable.View.RowStyle += View_RowStyle;

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

        #region ▶ Grid Row Style |
        /// <summary>
        /// Grid Row Style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            SmartBandedGridView view = sender as SmartBandedGridView;

            e.HighPriority = true;

            if (e.RowHandle >= 0)
            {
                string state = view.GetRowCellDisplayText(e.RowHandle, view.Columns["STATE"]);
                if (state.Equals("입고대기") || state.Equals("출고대기")) // 대기 상태
                {
                    e.Appearance.ForeColor = Color.LightSkyBlue;
                }
                else if (state.Equals("입고진행중") || state.Equals("출고진행중")) // 진행중
                {
                    e.Appearance.ForeColor = Color.Yellow;
                }
                else if (state.Equals("입고완료") || state.Equals("출고완료")) // 완료
                {
                    e.Appearance.ForeColor = Color.LawnGreen;
                }
            }

            e.Appearance.BackColor = Color.Black;
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
            string From = DateTime.Now.ToString("yyyy-MM-dd 00:00:01");
            string To = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

            if (_isInOutType == 1)
            {
                lblMainTitle.Text = Language.Get("DashTitleConsumeIn");

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("FROMDATE", From);
                param.Add("TODATE", To);

                DataSet ds = SqlExecuter.ProcedureToDataSet("USP_DASH_CONSUMABLEINCOMMING", param);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt1 = ds.Tables[0];
                    lblWaitCnt.Text = dt1.Rows[0][0].ToString();

                    DataTable dt2 = ds.Tables[1];
                    lblProcessCnt.Text = dt2.Rows[0][0].ToString();

                    DataTable dt3 = ds.Tables[2];
                    lblEndCnt.Text = dt3.Rows[0][0].ToString();

                    DataTable dt4 = ds.Tables[3];
                    this.grdConsumable.DataSource = dt4;
                }

                _isInOutType++;
            }
            else
            {
                lblMainTitle.Text = Language.Get("DashTitleConsumeOut");

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("FROMDATE", From);
                param.Add("TODATE", To);

                DataSet ds = SqlExecuter.ProcedureToDataSet("USP_DASH_CONSUMABLEOUTBOUND", param);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt1 = ds.Tables[0];
                    lblWaitCnt.Text = dt1.Rows[0][0].ToString();

                    DataTable dt2 = ds.Tables[1];
                    lblProcessCnt.Text = dt2.Rows[0][0].ToString();

                    DataTable dt3 = ds.Tables[2];
                    lblEndCnt.Text = dt3.Rows[0][0].ToString();

                    DataTable dt4 = ds.Tables[3];
                    this.grdConsumable.DataSource = dt4;
                }
                _isInOutType--;
            }
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

                    if(ThreadTime == null || ThreadTime == 0)
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
