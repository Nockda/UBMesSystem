#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

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

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 공정실적 > 조립진척현황
    /// 업  무  설  명  : 제품별로 조립진척현황을 조회한다.
    /// 생    성    자  : 유태근
    /// 생    성    일  : 2020-06-12
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class AssemblyProgress : SmartConditionBaseForm
    {
        #region Local Variables

        #endregion

        #region 생성자
        
        /// <summary>
        /// 생성자
        /// </summary>
        public AssemblyProgress()
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
        /// 조립진척현황 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            grdAssemblyProgressInfo.GridButtonItem = GridButtonItem.Export;
            grdAssemblyProgressInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdAssemblyProgressInfo.View.SetIsReadOnly();

            // 작업장 ID
            grdAssemblyProgressInfo.View.AddTextBoxColumn("AREAID", 100)
                .SetIsHidden();
            // 작업장명
            grdAssemblyProgressInfo.View.AddTextBoxColumn("AREANAME", 120);
            // 생산지시번호
            grdAssemblyProgressInfo.View.AddTextBoxColumn("WORKORDERID", 130);
            // 품목코드
            grdAssemblyProgressInfo.View.AddTextBoxColumn("PRODUCTDEFID", 100).SetIsHidden();
            grdAssemblyProgressInfo.View.AddTextBoxColumn("PARTNUMBER", 100).SetLabel("PRODUCTDEFID");
            // 품목명
            grdAssemblyProgressInfo.View.AddTextBoxColumn("PRODUCTDEFNAME", 160);
            // 규격
            grdAssemblyProgressInfo.View.AddTextBoxColumn("STANDARD", 100);
            // 기종
            grdAssemblyProgressInfo.View.AddTextBoxColumn("MODELNAME", 80);
            // 완료예정일
            grdAssemblyProgressInfo.View.AddDateEditColumn("PLANENDTIME", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime);
            // Lot No
            grdAssemblyProgressInfo.View.AddTextBoxColumn("LOTID", 100);
            // 수량
            grdAssemblyProgressInfo.View.AddTextBoxColumn("QTY", 60)
                .SetTextAlignment(TextAlignment.Center);
            // 작업시작일시
            grdAssemblyProgressInfo.View.AddDateEditColumn("WORKSTARTTIME", 120)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss", MaskTypes.DateTime);
            // 경과일수
            grdAssemblyProgressInfo.View.AddTextBoxColumn("ELAPSEDDAY", 60)
                .SetTextAlignment(TextAlignment.Center);
            // 전체공정갯수
            grdAssemblyProgressInfo.View.AddTextBoxColumn("ALLSEGMENTCOUNT", 60)
                .SetTextAlignment(TextAlignment.Center);
            // 완료공정갯수
            grdAssemblyProgressInfo.View.AddTextBoxColumn("COMPLETESEGMENTCOUNT", 60)
                .SetTextAlignment(TextAlignment.Center);
            // 현재공정
            grdAssemblyProgressInfo.View.AddTextBoxColumn("CURRENTSEGMENT", 80);
            // 진척율
            grdAssemblyProgressInfo.View.AddTextBoxColumn("PROGRESSRATE", 60)
                .SetTextAlignment(TextAlignment.Center);
            // LotState
            grdAssemblyProgressInfo.View.AddTextBoxColumn("LOTSTATE", 60)
                .SetTextAlignment(TextAlignment.Center);

            grdAssemblyProgressInfo.View.PopulateColumns();

            grdAssemblyProgressInfo.View.OptionsNavigation.AutoMoveRowFocus = false;
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            grdAssemblyProgressInfo.View.RowClick += View_RowClick;
        }

        /// <summary>
        /// 조립진척 상세현황을 조회할 수 있는 팝업을 호출한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                pnlContent.ShowWaitArea();

                AssemblyProgressDetailPopup popup = new AssemblyProgressDetailPopup();
                popup.Owner = this;
                popup.CurrentDataRow = grdAssemblyProgressInfo.View.GetFocusedDataRow();
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.ShowDialog();

                pnlContent.CloseWaitArea();
            }
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

            var values = Conditions.GetValues();
            values.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dt = await QueryAsync("SelectAssemblyProgress", "00001", values);

            if (dt.Rows.Count < 1)
            {
                // 조회할 데이터가 없습니다.
                this.ShowMessage("NoSelectData");
                grdAssemblyProgressInfo.DataSource = null;
                return;
            }

            grdAssemblyProgressInfo.DataSource = dt;
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

            // TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
            Conditions.GetControl<SmartComboBox>("P_PROCESSSEGMENT").EditValueChanged += AssemblyProgress_EditValueChanged;
        }

        private void AssemblyProgress_EditValueChanged(object sender, EventArgs e)
        {
            var param = new Dictionary<string, object>()
            {
                { "LANGUAGETYPE", UserInfo.Current.LanguageType }
                , { "P_PROCESSSEGMENT", Conditions.GetValues()["P_PROCESSSEGMENT"] }
            };
            Conditions.GetControl<SmartComboBox>("P_SUBSEGMENT").DataSource = SqlExecuter.Query("GetSubSegmentList", "00002", param);
            Conditions.GetControl<SmartComboBox>("P_SUBSEGMENT").EditValue = "*";
        }
        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            // TODO : 유효성 로직 변경
            grdAssemblyProgressInfo.View.CheckValidation();

            DataTable changed = grdAssemblyProgressInfo.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        #endregion
    }
}