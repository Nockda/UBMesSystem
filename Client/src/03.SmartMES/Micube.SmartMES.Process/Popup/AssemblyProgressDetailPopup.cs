#region using

using DevExpress.XtraGrid.Views.Grid;
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
    /// 업  무  설  명  : 품목하나에 대한 상세 조립진척현황을 확인하는 팝업이다.
    /// 생    성    자  : 유태근
    /// 생    성    일  : 2020-06-12
    /// 수  정  이  력  : 2020-07-28 | 이준용 | PRODUCTORDERID => WORKORDERID 변경
    /// 
    /// 
    /// </summary>
    public partial class AssemblyProgressDetailPopup : SmartPopupBaseForm, ISmartCustomPopup
    {
        #region Local Variables

        /// <summary>
        /// 팝업진입전 그리드의 Row
        /// </summary>
        public DataRow CurrentDataRow { get; set; }

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public AssemblyProgressDetailPopup()
        {
            InitializeComponent();

            InitializeEvent();
        }

        #endregion

        #region 컨텐츠 영역 초기화
        
        /// <summary>
        /// 상단 컨트롤 데이터 바인딩
        /// </summary>
        private void InitializeControl()
        {
            txtProductionOrderId.EditValue = CurrentDataRow["WORKORDERID"];
            txtProductDefId.EditValue = CurrentDataRow["PARTNUMBER"];
            txtProductDefName.EditValue = CurrentDataRow["PRODUCTDEFNAME"];
            txtModel.EditValue = CurrentDataRow["MODELNAME"];
            txtLotNo.EditValue = CurrentDataRow["LOTID"];
            txtQty.EditValue = CurrentDataRow["QTY"];
        }

        /// <summary>
        /// 하단 세부공정 진척정보 그리드 바인딩
        /// </summary>
        private void InitializeGrid()
        {
            grdProgressDetail.GridButtonItem = GridButtonItem.Export;
            grdProgressDetail.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdProgressDetail.View.SetIsReadOnly();

            // 공정순서
            grdProgressDetail.View.AddTextBoxColumn("USERSEQUENCE", 80)
                .SetTextAlignment(TextAlignment.Center);
            // 세부공정명
            grdProgressDetail.View.AddTextBoxColumn("SUBPROCESSSEGMENTNAME", 150);
            // 진행상태
            grdProgressDetail.View.AddTextBoxColumn("PROGRESSSTATE", 80)
                .SetTextAlignment(TextAlignment.Center);
            // 작업자
            grdProgressDetail.View.AddTextBoxColumn("WORKUSER", 150);
            // 작업시작일시
            grdProgressDetail.View.AddTextBoxColumn("WORKSTARTTIME", 160)
                .SetTextAlignment(TextAlignment.Center);
            // 작업종료일시
            grdProgressDetail.View.AddTextBoxColumn("WORKENDTIME", 160)
                .SetTextAlignment(TextAlignment.Center);
            // 작업시간
            grdProgressDetail.View.AddTextBoxColumn("WORKTIME", 80)
                .SetTextAlignment(TextAlignment.Center);
            // 작업설비
            grdProgressDetail.View.AddTextBoxColumn("WORKEQUIPMENT", 150);
            // 특이사항
            grdProgressDetail.View.AddTextBoxColumn("COMMENTS", 200);

            grdProgressDetail.View.PopulateColumns();

            grdProgressDetail.View.OptionsNavigation.AutoMoveRowFocus = false;

            Dictionary<string, object> param = new Dictionary<string, object>()
            {
                { "P_LANGUAGETYPE", UserInfo.Current.LanguageType },
                { "P_LOTID", CurrentDataRow["LOTID"] },
                { "P_PROCESSSEGMENTID", CurrentDataRow["PROCESSSEGMENTID"] },
                { "P_SPECDEFID", CurrentDataRow["SPECDEFID"] },
            };

            // 세부공정 진척정보 쿼리
            DataTable dt = SqlExecuter.Query("SelectAssemblyProgressDetail", "00001", param);

            if (dt.Rows.Count > 0) grdProgressDetail.DataSource = dt;
        }

        #endregion

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            this.Load += DefectRoutingPathPopup_Load;

            btnClose.Click += BtnClose_Click;
        }

        /// <summary>
        /// 폼 로드시 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefectRoutingPathPopup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            InitializeControl();
            InitializeGrid();
        }

        /// <summary>
        /// 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
 
        #region Private Function

        #endregion
    }
}
