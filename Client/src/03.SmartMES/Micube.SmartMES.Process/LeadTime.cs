#region using
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 공정실적 > LeadTime
    /// 업  무  설  명  : LeadTime
    /// 생    성    자  : jhpark
    /// 생    성    일  : 2019-06-24
    /// 수  정  이  력  : 
    /// </summary>
    public partial class LeadTime : SmartConditionBaseForm
    {
        #region ◆ Variables |
        #endregion

        #region ◆ 생성자 |
        /// <summary>
        /// 생성자
        /// </summary>
        public LeadTime()
        {
            InitializeComponent();

            tpgLTProduct.PageVisible = false;
        }

        #region ▶ Form_Load |
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form_Load(object sender, EventArgs e)
        {
            InitializeGrid();
        }
        #endregion

        #endregion

        #region ◆ Control 초기화  |
        /// <summary>
        /// Control 초기화
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();
        }

        #region ▶ 조회조건 초기화 |
        /// <summary>
        /// 조회조건 초기화
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // 품목 조회 조건
            InitializeConditionProductDef_Popup();

        }

        #region # 품목코드 검색조건 팝업 :: InitializeConditionProductDef_Popup |
        /// <summary>
        /// 품목코드 검색조건 팝업
        /// </summary>
        private void InitializeConditionProductDef_Popup()
        {
            var popup = Conditions.AddSelectPopup("PRODUCTDEFID", new SqlQuery("GetProductDefListPopup", "00001"
                    , $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PRODUCTDEFNAME", "PRODUCTDEFID")
                .SetPopupLayout("PRODUCTDEFLIST", PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(880, 600, FormBorderStyle.Sizable)
                .SetLabel("PRODUCTDEFID")
                .SetPosition(4);

            // 검색조건 
            popup.Conditions.AddComboBox("PRODUCTDEFTYPE", new SqlQuery("GetCodeList", "00001"
                        , "CODECLASSID=ProductDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetEmptyItem();
            popup.Conditions.AddTextBox("PRODUCTDEFID");
            popup.Conditions.AddTextBox("PRODUCTDEFNAME");

            // 그리드
            popup.GridColumns.AddTextBoxColumn("PRODUCTDEFTYPE", 65);
            popup.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 155).SetIsHidden();
            popup.GridColumns.AddTextBoxColumn("PARTNUMBER", 155).SetLabel("PRODUCTDEFID");
            popup.GridColumns.AddTextBoxColumn("PRODUCTDEFVERSION", 60);
            popup.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 100);
            popup.GridColumns.AddTextBoxColumn("MODEL", 115);
        } 
        #endregion
        #endregion

        #region ▶ 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용 |
        /// <summary>
        /// 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            Conditions.GetControl<SmartComboBox>("P_PROCESSSEGMENT").EditValueChanged += LeadTime_EditValueChanged;


        }

        private void LeadTime_EditValueChanged(object sender, EventArgs e)
        {


            SqlQuery condition = new SqlQuery("GetModelByProcess", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_PROCESSSEGMENT={Conditions.GetControl<SmartComboBox>("P_PROCESSSEGMENT").EditValue}", $"P_VALIDSTATE=Valid");
            DataTable conditionTable = condition.Execute();
            this.Conditions.GetControl<SmartComboBox>("p_model").ValueMember = "MODELID";
            this.Conditions.GetControl<SmartComboBox>("p_model").DisplayMember = "MODELNAME";
            this.Conditions.GetControl<SmartComboBox>("p_model").EditValue = "";
            this.Conditions.GetControl<SmartComboBox>("p_model").DataSource = conditionTable;




        }
        #endregion

        #region ▶ Grid 설정 :: InitializeGrid |
        /// <summary>
        /// Grid 설정
        /// </summary>
        private void InitializeGrid()
        {
            #region # Lot별 LeadTime Grid 설정 |
            grdLotLeadTime.GridButtonItem = GridButtonItem.Export;

            grdLotLeadTime.View.SetIsReadOnly();

            grdLotLeadTime.View.AddTextBoxColumn("WORKDATE", 120).SetTextAlignment(TextAlignment.Center).SetLabel("WORKDAY");
            grdLotLeadTime.View.AddTextBoxColumn("LOTID", 120).SetTextAlignment(TextAlignment.Center);
            grdLotLeadTime.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 150).SetTextAlignment(TextAlignment.Center);
            grdLotLeadTime.View.AddTextBoxColumn("PRODUCTDEFID", 100).SetTextAlignment(TextAlignment.Center).SetIsHidden();
            grdLotLeadTime.View.AddTextBoxColumn("PARTNUMBER", 100).SetTextAlignment(TextAlignment.Center).SetLabel("PRODUCTDEFID");
            grdLotLeadTime.View.AddTextBoxColumn("PRODUCTDEFNAME", 250);
            grdLotLeadTime.View.AddTextBoxColumn("WORKENDQTY", 80).SetTextAlignment(TextAlignment.Center).SetLabel("QTY");
            grdLotLeadTime.View.AddTextBoxColumn("WORKSTARTTIME", 170).SetTextAlignment(TextAlignment.Center);
            grdLotLeadTime.View.AddTextBoxColumn("WORKENDTIME", 170).SetTextAlignment(TextAlignment.Center);
            grdLotLeadTime.View.AddTextBoxColumn("LEADTIME", 70).SetTextAlignment(TextAlignment.Right).SetLabel("LEADTIMEBYHOUR");
            grdLotLeadTime.View.AddTextBoxColumn("SPECSEQUENCE", 70).SetTextAlignment(TextAlignment.Center).SetLabel("SPECSEQ").SetIsHidden();
            grdLotLeadTime.View.AddTextBoxColumn("SUBPROCESSSEGMENTNAME", 150).SetTextAlignment(TextAlignment.Center);
            grdLotLeadTime.View.AddTextBoxColumn("SUBWORKSTARTTIME", 170).SetTextAlignment(TextAlignment.Center).SetLabel("WORKSTARTTIME");
            grdLotLeadTime.View.AddTextBoxColumn("SUBWORKENDTIME", 170).SetTextAlignment(TextAlignment.Center).SetLabel("WORKENDTIME");
            grdLotLeadTime.View.AddTextBoxColumn("SUBLEADTIME", 70).SetTextAlignment(TextAlignment.Right).SetLabel("LEADTIMEBYMINUTE");
            grdLotLeadTime.View.AddTextBoxColumn("WAITTIME", 80).SetTextAlignment(TextAlignment.Right).SetLabel("WAITTIMEBYMINUTE");

            grdLotLeadTime.View.PopulateColumns();

            #endregion

            #region # Model별 LeadTime |
            grdModelLeadTime.GridButtonItem = GridButtonItem.Export;

            grdModelLeadTime.View.SetIsReadOnly();

            grdModelLeadTime.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 150).SetTextAlignment(TextAlignment.Center);
            grdModelLeadTime.View.AddTextBoxColumn("MODELNAME", 150).SetTextAlignment(TextAlignment.Center).SetLabel("MODELID");
            grdModelLeadTime.View.AddTextBoxColumn("WORKENDQTY", 80).SetTextAlignment(TextAlignment.Center).SetLabel("QTY");
            grdModelLeadTime.View.AddTextBoxColumn("LEADTIME", 70).SetTextAlignment(TextAlignment.Right).SetLabel("LEADTIMEBYHOUR");
            grdModelLeadTime.View.AddTextBoxColumn("SPECSEQUENCE", 70).SetTextAlignment(TextAlignment.Center).SetLabel("SPECSEQ");
            grdModelLeadTime.View.AddTextBoxColumn("SUBPROCESSSEGMENTNAME", 150).SetTextAlignment(TextAlignment.Center);
            grdModelLeadTime.View.AddTextBoxColumn("SUBLEADTIME", 70).SetTextAlignment(TextAlignment.Right).SetLabel("LEADTIMEBYMINUTE");
            grdModelLeadTime.View.AddTextBoxColumn("WAITTIME", 80).SetTextAlignment(TextAlignment.Right).SetLabel("WAITTIMEBYMINUTE");

            grdModelLeadTime.View.PopulateColumns();
            #endregion

            #region # 제품별 LeadTime |
            grdProductLeadTime.GridButtonItem = GridButtonItem.Export;

            grdProductLeadTime.View.SetIsReadOnly();

            grdProductLeadTime.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 150).SetTextAlignment(TextAlignment.Center);
            grdProductLeadTime.View.AddTextBoxColumn("MODELID", 150).SetTextAlignment(TextAlignment.Center);
            grdProductLeadTime.View.AddTextBoxColumn("PRODUCTDEFID", 120).SetTextAlignment(TextAlignment.Center);
            grdProductLeadTime.View.AddTextBoxColumn("PRODUCTDEFNAME", 250).SetTextAlignment(TextAlignment.Center);
            grdProductLeadTime.View.AddTextBoxColumn("WORKENDQTY", 80).SetTextAlignment(TextAlignment.Center).SetLabel("QTY");
            grdProductLeadTime.View.AddTextBoxColumn("LEADTIME", 70).SetTextAlignment(TextAlignment.Right).SetLabel("LEADTIMEBYHOUR");
            grdProductLeadTime.View.AddTextBoxColumn("SPECSEQUENCE", 70).SetTextAlignment(TextAlignment.Center).SetLabel("SPECSEQ");
            grdProductLeadTime.View.AddTextBoxColumn("SUBPROCESSSEGMENTNAME", 150).SetTextAlignment(TextAlignment.Center);
            grdProductLeadTime.View.AddTextBoxColumn("SUBLEADTIME", 70).SetTextAlignment(TextAlignment.Right).SetLabel("LEADTIMEBYMINUTE");
            grdProductLeadTime.View.AddTextBoxColumn("WAITTIME", 80).SetTextAlignment(TextAlignment.Right).SetLabel("WAITTIMEBYMINUTE");

            grdProductLeadTime.View.PopulateColumns();
            #endregion
        }
        #endregion

        #endregion

        #region ◆ Event 설정 |
        /// <summary>
        /// Event 설정
        /// </summary>
        private void InitializeEvent()
        {
            this.Load += Form_Load;
        }
        #endregion

        #region ◆ 검색 :: OnSearchAsync |
        //// <summary>
        /// 검색
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dt = await QueryAsync("SelectLeadTimeList", "00001", values);

            if (dt.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdLotLeadTime.DataSource = dt;

            DataTable dt2 = await SqlExecuter.QueryAsync("SelectLeadTimeByModel", "00001", values);

            grdModelLeadTime.DataSource = dt2;

            //DataTable dt3 = await SqlExecuter.QueryAsync("SelectLeadTimeByProduct", "00001", values);

            //grdProductLeadTime.DataSource = dt3;
        }
        #endregion

        #region ◆ ToolBar :: OnToolbarClick |
        /// <summary>
        /// 툴바 버튼 이벤트
        /// </summary>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
        }
        #endregion

        #region ◆ Private Function |
        #endregion
    }
}
