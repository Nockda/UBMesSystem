#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

#endregion

namespace Micube.SmartMES.DashBoard
{
    /// <summary>
    /// 프 로 그 램 명  : DashBoard > 자재 입출고 현황
    /// 업  무  설  명  : 대쉬보드 - 자재입출고 현황
    /// 생    성    자  : jhpark
    /// 생    성    일  : 2020-06-17
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class DashBoardMain : SmartConditionBaseForm
    {
        #region ◆ 생성자 |
        /// <summary>
        /// 생성자
        /// </summary>
        public DashBoardMain()
        {
            InitializeComponent();
        } 
        #endregion

        #region ◆ 컨텐츠 영역 초기화 |

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            base.ConditionsVisible = false;

            InitializeControls();

            InitializeEvent();
        }

        #region ▶ Control 초기화 |
        /// <summary>
        /// Control 초기화
        /// </summary>
        private void InitializeControls()
        {
            this.txtTimer.Text = "5";

            #region ＃ 작업장 ComboBox |
            cboArea.DisplayMember = "CODENAME";
            cboArea.ValueMember = "CODEID";
            DataTable dt = SqlExecuter.Query("GetTeamList", "00001", new Dictionary<string, object>() { { "LANGUAGETYPE", "en-US" } });
            dt.AcceptChanges();
            foreach (DataRow each in dt.Rows)
            {
                if (each["CODEID"].ToString() == "T06") // ACC 팀 제외
                {
                    each.Delete();
                }
            }
            dt.AcceptChanges();
            cboArea.DataSource = dt;
            cboArea.UseEmptyItem = true;
            cboArea.ShowHeader = false;
            #endregion
        } 
        #endregion
        #endregion

        #region ◆ Event |
        private void InitializeEvent()
        {
            btnConsumable.Click += btnConsumable_Click;
            btnWorkResult.Click += btnWorkResult_Click;
            btnAllWorkStatus.Click += btnAllWorkStatus_Click;
            btnTotalStatus_kor.Click += btnTotalStatus_kor_Click;
            btnTotalStatus_eng.Click += btnTotalStatus_eng_Click;
        }

        #region ▶ 자재 입/출고 현황 :: btnConsumable_Click |
        /// <summary>
        /// 자재 입/출고 현황
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsumable_Click(object sender, EventArgs e)
        {
            int time = 10;

            if (this.txtTimer.EditValue != null && !string.IsNullOrWhiteSpace(this.txtTimer.EditValue.ToString()))
            {
                time = int.Parse(this.txtTimer.EditValue.ToString());
            }

            DashConsumablePop pop = new DashConsumablePop();
            pop.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            pop.ThreadTime = time;
            pop.ShowDialog();
        }
        #endregion

        #region ▶ 생산현황 :: btnWorkResult_Click |
        /// <summary>
        /// 생산현황
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWorkResult_Click(object sender, EventArgs e)
        {
            int time = 10;

            if (this.txtTimer.EditValue != null && !string.IsNullOrWhiteSpace(this.txtTimer.EditValue.ToString()))
            {
                time = int.Parse(this.txtTimer.EditValue.ToString());
            }

            if (cboArea.GetDataValue() == null || string.IsNullOrWhiteSpace(cboArea.GetDataValue().ToString()))
            {
                // 선택된 팀이 없습니다.
                ShowMessage("NoTeamSelected");

                return;
            }

            DashWorkResultPop pop = new DashWorkResultPop();
            pop.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            pop.ThreadTime = time;
            pop.DashArea = cboArea.GetDataValue().ToString();
            pop.DashAreaName = cboArea.GetDisplayText();
            pop.ShowDialog();
        }
        #endregion

        #region ▶ 전체 생산현황 :: btnAllWorkStatus_Click |
        /// <summary>
        /// 전체 생산현황
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllWorkStatus_Click(object sender, EventArgs e)
        {
            int time = 10;

            if (this.txtTimer.EditValue != null && !string.IsNullOrWhiteSpace(this.txtTimer.EditValue.ToString()))
            {
                time = int.Parse(this.txtTimer.EditValue.ToString());
            }

            DashAllWorkStatusPop pop = new DashAllWorkStatusPop();
            pop.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            pop.ThreadTime = time;
            pop.ShowDialog();
        }
        #endregion

        #region ▶ 제조 종합 현황 :: btnTotalStatus_Click |
        /// <summary>
        /// 제조 종합 현황
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTotalStatus_kor_Click(object sender, EventArgs e)
        {
            int time = 10;
            int LanguageType = 1;

            if (this.txtTimer.EditValue != null && !string.IsNullOrWhiteSpace(this.txtTimer.EditValue.ToString()))
            {
                time = int.Parse(this.txtTimer.EditValue.ToString());
            }

            TotalDashBoardStatusPop pop = new TotalDashBoardStatusPop(LanguageType);
            pop.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            pop.ThreadTime = time;
            pop.ShowDialog();
        }
        #endregion

        #region ▶ 제조 종합 현황 :: btnTotalStatus_Click |
        /// <summary>
        /// 제조 종합 현황
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTotalStatus_eng_Click(object sender, EventArgs e)
        {
            int time = 10;
            int LanguageType = 2;

            if (this.txtTimer.EditValue != null && !string.IsNullOrWhiteSpace(this.txtTimer.EditValue.ToString()))
            {
                time = int.Parse(this.txtTimer.EditValue.ToString());
            }

            TotalDashBoardStatusPop pop = new TotalDashBoardStatusPop(LanguageType);
            pop.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            pop.ThreadTime = time;
            pop.ShowDialog();
        }
        #endregion

        #endregion
    }
}
