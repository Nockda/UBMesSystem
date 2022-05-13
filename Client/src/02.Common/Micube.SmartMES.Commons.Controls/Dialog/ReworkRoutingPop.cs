#region using

using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using Micube.Framework.SmartControls.Grid.BandedGrid;
using Micube.Framework.SmartControls.Grid;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Commons.Controls
{
    public partial class ReworkRoutingPop : SmartPopupBaseForm, ISmartCustomPopup
    {
        #region ◆ Public Variables |
        /// <summary>
        /// 팝업진입전 그리드의 Row
        /// </summary>
        public DataRow CurrentDataRow { get; set; }

        // 품목 ID
        public string ProductDefID { get; set; }

        // 품목 Version
        public string ProductDefVersion { get; set; }

        // Lot ID
        public string LotId { get; set; }

        // Routing DefId
        public string ProcessDefId { get; set; }

        // Routing Version
        public string ProcessDefVersion { get; set; }

        // 공정 ID
        public string ProcessSegmentId { get; set; }
        
        // 공정명
        public string ProcessSegmentName { get; set; }

        // 공정수순
        public string UserSequence { get; set; }

        // 공정수순
        public string PathSequence { get; set; }

        // PathID
        public string ProcessPathId { get; set; }

        // Return 공정
        public string ReturnProcessSegmentId { get; set; }

        // Return 공정 수순
        public string ReturnPathSequence { get; set; }
        
        // Return PathID
        public string ReturnPathId { get; set; }


        // Rework 유형
        public string ReworkType { get; set; }

        #endregion

        #region ◆ 생성자 |
        /// <summary>
        /// 생성자
        /// </summary>
        public ReworkRoutingPop()
        {
            InitializeComponent();

            this.Load += Form_Load;
        }

        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            // Control Setting
            InitControls();

            // Event Set
            InitEvents();

            // Data 조회
            Search();
        }
        #endregion

        #region ◆ Control 초기화 |
        /// <summary>
        /// Control 초기화
        /// </summary>
        private void InitControls()
        {
            InitGrid();
            InitializeCombobox();
            InitConditionEnable();
        }

        private void InitializeCombobox()
        {
            cboProcessClass.DisplayMember = "CODENAME";
            cboProcessClass.ValueMember = "CODEID";
            cboProcessClass.UseEmptyItem = true;
            cboProcessClass.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            cboProcessClass.ShowHeader = false;
            // 쿼리 틀린거 같음
            DataTable processClass = new SqlQuery("GetTypeList", "10001", $"CODECLASSID=ProcessClassType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}").Execute();
            cboProcessClass.DataSource = processClass;
        }

        private void InitConditionEnable()
        {
            cboProcessClass.Enabled = false;
            txtReworkNumber.Enabled = false;
            txtReworkName.Enabled = false;
        }

        #region ▶ Grid 초기화 |
        /// <summary>
        /// Grid 초기화
        /// </summary>
        private void InitGrid()
        {
            #region - 품목 Routing |
            // 품목 Routing
            grdProductRouting.GridButtonItem = GridButtonItem.None;
            grdProductRouting.View.SetIsReadOnly();

            // CheckBox 설정
            grdProductRouting.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdProductRouting.View.AddTextBoxColumn("PROCESSDEFID", 100).SetTextAlignment(TextAlignment.Center).SetIsHidden();
            grdProductRouting.View.AddTextBoxColumn("PROCESSDEFVERSION", 100).SetTextAlignment(TextAlignment.Center).SetIsHidden();
            grdProductRouting.View.AddTextBoxColumn("PROCESSPATHID", 200).SetTextAlignment(TextAlignment.Center).SetIsHidden();
            grdProductRouting.View.AddTextBoxColumn("PROCESSSEGMENTID", 150).SetTextAlignment(TextAlignment.Center);
            grdProductRouting.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);
            grdProductRouting.View.AddTextBoxColumn("USERSEQUENCE", 70).SetTextAlignment(TextAlignment.Center);
            grdProductRouting.View.AddTextBoxColumn("PLANTID", 70).SetTextAlignment(TextAlignment.Center);
            grdProductRouting.View.AddTextBoxColumn("PATHSEQUENCE", 70).SetIsHidden();

            grdProductRouting.View.PopulateColumns();
            #endregion

            #region - 재작업 Routing Grid |
            grdReworkRouting.GridButtonItem = GridButtonItem.None;
            grdReworkRouting.View.SetIsReadOnly();

            grdReworkRouting.View.AddTextBoxColumn("PROCESSCLASSTYPENAME", 80)     // 적용구분
                .SetLabel("APPLICATIONTYPE");
            grdReworkRouting.View.AddTextBoxColumn("PROCESSCLASSNAME", 120)        // 재작업구분
                .SetLabel("REWORKTYPE")
                .SetTextAlignment(TextAlignment.Left);
            grdReworkRouting.View.AddTextBoxColumn("TOPPROCESSSEGMENTID", 70)      // 대공정
                .SetTextAlignment(TextAlignment.Left);
            grdReworkRouting.View.AddTextBoxColumn("PROCESSDEFID", 100)            // 재작업번호
                .SetLabel("REWORKNUMBER")
                .SetTextAlignment(TextAlignment.Left);
            grdReworkRouting.View.AddTextBoxColumn("PROCESSDEFVERSION", 80)        // 재작업버전
                .SetLabel("REWORKVERSION")
                .SetTextAlignment(TextAlignment.Left);
            grdReworkRouting.View.AddTextBoxColumn("PROCESSDEFNAME", 100)          // 재작업명
                .SetLabel("REWORKNAME")
                .SetTextAlignment(TextAlignment.Left);
            grdReworkRouting.View.AddTextBoxColumn("PLANTID", 70)                  // Site ID
                .SetTextAlignment(TextAlignment.Center);

            grdReworkRouting.View.PopulateColumns();
            #endregion

            #region - 재작업 Routing 공정 수순 |
            grdReworkPath.GridButtonItem = GridButtonItem.None;
            grdReworkPath.View.SetIsReadOnly();

            grdReworkPath.View.AddTextBoxColumn("PROCESSPATHID", 200).SetTextAlignment(TextAlignment.Center).SetIsHidden();
            grdReworkPath.View.AddTextBoxColumn("PROCESSSEGMENTID", 100).SetTextAlignment(TextAlignment.Center);
            grdReworkPath.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 130);
            grdReworkPath.View.AddTextBoxColumn("USERSEQUENCE", 70);
            grdReworkPath.View.AddTextBoxColumn("PATHSEQUENCE", 70).SetIsHidden();
            grdReworkPath.View.AddTextBoxColumn("PLANTID", 70).SetTextAlignment(TextAlignment.Center);

            grdReworkPath.View.PopulateColumns();
            #endregion

            #region - Return 공정 수순 |
            grdReturnRouting.GridButtonItem = GridButtonItem.None;
            grdReturnRouting.View.SetIsReadOnly();

            grdReturnRouting.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdReturnRouting.View.AddTextBoxColumn("PROCESSDEFID", 100).SetTextAlignment(TextAlignment.Center).SetIsHidden();
            grdReturnRouting.View.AddTextBoxColumn("PROCESSDEFVERSION", 100).SetTextAlignment(TextAlignment.Center).SetIsHidden();
            grdReturnRouting.View.AddTextBoxColumn("PROCESSPATHID", 200).SetTextAlignment(TextAlignment.Center).SetIsHidden();
            grdReturnRouting.View.AddTextBoxColumn("PATHSEQUENCE", 70).SetIsHidden();
            grdReturnRouting.View.AddTextBoxColumn("PROCESSSEGMENTID", 100).SetTextAlignment(TextAlignment.Center);
            grdReturnRouting.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 130);
            grdReturnRouting.View.AddTextBoxColumn("USERSEQUENCE", 70).SetTextAlignment(TextAlignment.Center);
            grdReturnRouting.View.AddTextBoxColumn("PLANTID", 70).SetTextAlignment(TextAlignment.Center);

            grdReturnRouting.View.PopulateColumns(); 
            #endregion
        }
        #endregion

        #endregion

        #region ◆ Event 정의 |
        /// <summary>
        /// 이벤트 정의
        /// </summary>
        private void InitEvents()
        {
            // Button Event
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;

            // Grid Event
            this.grdProductRouting.View.RowStyle += ProductView_RowStyle;
            this.grdReworkRouting.View.RowStyle += ReworkView_RowStyle;
            this.grdReturnRouting.View.RowStyle += ReturnView_RowStyle;

            this.grdProductRouting.View.DoubleClick += ProductView_DoubleClick;
            this.grdProductRouting.View.RowClick += ProductView_RowClick;

            this.grdReworkRouting.View.RowClick += ReworkView_RowClick;
            this.grdReturnRouting.View.RowClick += ReturnView_RowClick;
            this.grdReturnRouting.View.DoubleClick += ReturnView_DoubleClick;

            this.cboProcessClass.EditValueChanged += CboProcessClass_EditValueChanged;
            this.txtReworkNumber.KeyDown += TxtReworkNumber_KeyDown;
            this.txtReworkName.KeyDown += TxtReworkName_KeyDown;

            this.tabRouting.SelectedPageChanged += TabRouting_SelectedPageChanged;
        }

        private void TabRouting_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(tabRouting.SelectedTabPageIndex == 1)
            {
                cboProcessClass.Enabled = true;
                txtReworkNumber.Enabled = true;
                txtReworkName.Enabled = true;
            }
            else
            {
                cboProcessClass.Enabled = false;
                txtReworkNumber.Enabled = false;
                txtReworkName.Enabled = false;
            }
        }

        private void CboProcessClass_EditValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void TxtReworkNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void TxtReworkName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
        #region ▶ Grid Event |

        #region - 품목 Routing Row Style |
        /// <summary>
        /// Row Style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductView_RowStyle(object sender, RowStyleEventArgs e)
        {
            RowStye(grdProductRouting, e);
        }
        #endregion

        #region - Rework Routing Row Style |
        /// <summary>
        /// Rework Routing Row Style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReworkView_RowStyle(object sender, RowStyleEventArgs e)
        {
            RowStye(grdReworkRouting, e);
        }
        #endregion

        #region - 품목 Return Routing Path |
        /// <summary>
        /// 품목 Return Routing Path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnView_RowStyle(object sender, RowStyleEventArgs e)
        {
            RowStye(grdReturnRouting, e);
        }
        #endregion

        #region - 품목 Routing Grid Double click |
        /// <summary>
        /// 품목 Routing 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductView_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = grdProductRouting.View.GetFocusedDataRow();

            if (dr == null) return;

            ProcessPathId = dr["PROCESSPATHID"].ToString();
            UserSequence = dr["USERSEQUENCE"].ToString();
            //PathSequence = dr["PATHSEQUENCE"].ToString();

            ProcessDefId = dr["PROCESSPATHID"].ToString();
            ProcessDefVersion = dr["PROCESSPATHID"].ToString();
            ProcessSegmentId = dr["PROCESSSEGMENTID"].ToString();
            ProcessSegmentName = dr["PROCESSSEGMENTNAME"].ToString();

            BtnSave_Click(null, null);
        }
        #endregion

        #region - 재작업 Routing Row 선택 |
        /// <summary>
        /// 재작업 Routing Row 선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReworkView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            DataRow dr = this.grdReworkRouting.View.GetFocusedDataRow();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("P_PROCESSDEFID", dr["PROCESSDEFID"].ToString());
            param.Add("P_PROCESSDEFVERSION", dr["PROCESSDEFVERSION"].ToString());

            DataTable reworkdt = SqlExecuter.Query("GetProcessPathByProcessDefId", "10001", param);

            if (reworkdt.Rows.Count < 1)
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdReworkPath.DataSource = reworkdt;
        }
        #endregion

        #region - 품목 공정 선택 Grid Event |
        /// <summary>
        /// 품목 공정 선택 Grid Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductView_RowClick(object sender, RowClickEventArgs e)
        {
            SetGridCheck(grdProductRouting, sender, e);
        }
        #endregion

        #region - Return 공정 선택 Grid Event |
        /// <summary>
        /// Return 공정 선택 Grid Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnView_RowClick(object sender, RowClickEventArgs e)
        {
            SetGridCheck(grdReturnRouting, sender, e);
        }
        #endregion

        #region - Return 공정 Grid Double click |
        /// <summary>
        /// Return 공정 Grid Double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnView_DoubleClick(object sender, EventArgs e)
        {
            SmartBandedGridView view = (SmartBandedGridView)sender;

            IEnumerable<int> chk = grdReturnRouting.View.GetCheckedRowsHandle();

            foreach (int row in chk)
            {
                grdReturnRouting.View.CheckRow(row, false);
            }

            grdReturnRouting.View.CheckRow(view.FocusedRowHandle, true);

            BtnSave_Click(null, null);
        }
        #endregion

        #endregion

        #region ▶ Button Event |
        /// <summary>
        /// 취소 Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ProcessPathId = string.Empty;
            UserSequence = string.Empty;
            PathSequence = string.Empty;

            ProcessDefId = string.Empty;
            ProcessDefVersion = string.Empty;
            ProcessSegmentId = string.Empty;
            ProcessSegmentName = string.Empty;

            ReturnProcessSegmentId = string.Empty;
            ReturnPathSequence = string.Empty;

            ReworkType = string.Empty;

            this.Close();
        }

        /// <summary>
        /// 선택 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 품목 Routing 인경우
            if(this.tabRouting.SelectedTabPageIndex == 0)
            {
                DataTable dt = this.grdProductRouting.View.GetCheckedRows();

                if(dt == null || dt.Rows.Count <= 0)
                {
                    throw MessageException.Create("NoSaveData");
                }

                DataRow dr = dt.Rows[0];

                ProcessPathId = dr["PROCESSPATHID"].ToString();
                UserSequence = dr["USERSEQUENCE"].ToString();
                PathSequence = dr["PATHSEQUENCE"].ToString();

                ProcessDefId = dr["PROCESSDEFID"].ToString();
                ProcessDefVersion = dr["PROCESSDEFVERSION"].ToString();
                ProcessSegmentId = dr["PROCESSSEGMENTID"].ToString();
                ProcessSegmentName = dr["PROCESSSEGMENTNAME"].ToString();

                ReworkType = "PRODUCT";
            }
            else
            {
                DataRow dr = this.grdReworkRouting.View.GetFocusedDataRow();

                if (dr == null || dr.ItemArray.Length <= 0)
                {
                    throw MessageException.Create("NoSaveData");
                }

                ProcessDefId = dr["PROCESSDEFID"].ToString();
                ProcessDefVersion = dr["PROCESSDEFVERSION"].ToString();

                // Routing 공정
                DataTable rdt = this.grdReworkPath.DataSource as DataTable;

                if (rdt != null && rdt.Rows.Count > 0)
                {
                    DataRow rwdr = rdt.Rows[0];
                    ProcessSegmentId = rwdr["PROCESSSEGMENTID"].ToString();
                    ProcessSegmentName = rwdr["PROCESSSEGMENTNAME"].ToString();

                    ProcessPathId = rwdr["PROCESSPATHID"].ToString();
                    UserSequence = rwdr["USERSEQUENCE"].ToString();
                    PathSequence = rwdr["PATHSEQUENCE"].ToString();
                }

                // Return 공정
                DataTable dt = this.grdReturnRouting.View.GetCheckedRows();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow rtdr = dt.Rows[0];

                    ReturnProcessSegmentId = rtdr["PROCESSSEGMENTID"].ToString();
                    ReturnPathSequence = rtdr["PATHSEQUENCE"].ToString();
                    ReturnPathId = rtdr["PROCESSPATHID"].ToString();
                }

                ReworkType = "REWORK";
            }
            if (string.IsNullOrWhiteSpace(ProcessDefId))
            {
                throw MessageException.Create("NoSaveData");
            }

            this.Close();
        }
        #endregion

        #endregion

        #region ◆ Private Function |

        #region - 데이터 조회 |
        /// <summary>
        /// 데이터 조회
        /// </summary>
        private void Search()
        {

            this.lblProductDefID.Text = ProductDefID;

            #region  - 품목 Routing 조회 |
            if (!string.IsNullOrWhiteSpace(ProductDefID))
            {
                // 품목 Routing 조회
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
                param.Add("PLANTID", UserInfo.Current.Plant);
                param.Add("P_TYPE", "BEFORE");
                param.Add("P_PRODUCTDEFID", ProductDefID);
                param.Add("P_PRODUCTDEFVERSION", ProductDefVersion);
                param.Add("P_USERSEQUENCE", PathSequence);

                DataTable productdt = SqlExecuter.Query("GetProcessPathByProductDefAndSequence", "10002", param);

                if (productdt.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
                }

                grdProductRouting.DataSource = productdt;
            }
            #endregion

            #region - 재작업 Routing 조회 |
            // 재작업 Routing 조회
            Dictionary<string, object> param2 = new Dictionary<string, object>();
            param2.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            param2.Add("PLANTID", UserInfo.Current.Plant);
            param2.Add("P_LOTID", this.LotId);
            param2.Add("P_PROCESSCLASSTYPE", cboProcessClass.EditValue);
            param2.Add("REWORKNUMBER", txtReworkNumber.Text);
            param2.Add("REWORKNAME", txtReworkName.Text);

            DataTable reworkdt = SqlExecuter.Query("SelectReworkRouting", "10002", param2);

            if (reworkdt.Rows.Count < 1)
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdReworkRouting.DataSource = reworkdt;
            #endregion

            #region  - 재작업 Routing 돌아갈 공정 조회 |
            if (!string.IsNullOrWhiteSpace(ProductDefID))
            {
                // 품목 Routing 조회
                Dictionary<string, object> param3 = new Dictionary<string, object>();
                param3.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
                param3.Add("PLANTID", UserInfo.Current.Plant);
                param3.Add("P_TYPE", "AFTER");
                param3.Add("P_PRODUCTDEFID", ProductDefID);
                param3.Add("P_PRODUCTDEFVERSION", ProductDefVersion);
                param3.Add("P_USERSEQUENCE", PathSequence);

                DataTable returndt = SqlExecuter.Query("GetProcessPathByProductDefAndSequence", "10002", param3);

                if (returndt.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
                }

                grdReturnRouting.DataSource = returndt;
            }
            #endregion
        }
        #endregion

        #region - Grid Row Style |
        /// <summary>
        /// Grid Row Style
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="e"></param>
        private void RowStye(SmartBandedGrid grd, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            int rowIndex = grd.View.FocusedRowHandle;

            if (rowIndex == e.RowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(254, 254, 16);
                e.HighPriority = true;
            }
        }
        #endregion

        #region - Row 선택 시 Row Check 및 해제 |
        /// <summary>
        /// Row 선택 시 Row Check 및 해제
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetGridCheck(SmartBandedGrid grid, object sender, RowClickEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            SmartBandedGridView view = (SmartBandedGridView)sender;

            IEnumerable<int> chk = grid.View.GetCheckedRowsHandle();

            foreach (int row in chk)
            {
                grid.View.CheckRow(row, false);
            }

            grid.View.CheckRow(view.FocusedRowHandle, true);
        } 
        #endregion
        #endregion
    }
}
