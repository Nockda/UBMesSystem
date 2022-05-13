#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Data;
using System.Threading.Tasks;

#endregion

namespace Micube.SmartMES.Quality
{
    /// <summary>
    /// 프 로 그 램 명  : 품질관리 > 수입검사 > 수입검사등록
    /// 업  무  설  명  : 수입검사 정보를 등록 및 수정한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-10
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class IqcInspReg : SmartConditionBaseForm
    {
        public IqcInspReg()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            //InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeCheck();
            InitializeStandard();
            InitializeData();

            //LoadDataManageGrid();
        }

        /// <summary>        
        /// 체크 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeCheck()
        {
            // 그리드 초기화
            grdCheck.GridButtonItem = GridButtonItem.Refresh;
            grdCheck.View.SetIsReadOnly();

            grdCheck.View.SetSortOrder("Check List");
            grdCheck.View.SetAutoFillColumn("品名");

            grdCheck.View.AddTextBoxColumn("Check List", 80);
            grdCheck.View.AddTextBoxColumn("Code", 80);
            grdCheck.View.AddTextBoxColumn("品名", 120);
            grdCheck.View.AddTextBoxColumn("入庫日", 80);
            grdCheck.View.AddTextBoxColumn("検査日", 80);
            grdCheck.View.AddTextBoxColumn("PO No.", 100);
            grdCheck.View.AddTextBoxColumn("Vendor", 100);
            grdCheck.View.AddTextBoxColumn("数量", 80);
            grdCheck.View.AddTextBoxColumn("不良数量", 80);
            grdCheck.View.AddTextBoxColumn("不良率", 80);
            grdCheck.View.AddTextBoxColumn("検査時間(分)", 80);
            grdCheck.View.AddTextBoxColumn("不良内容", 80);
            grdCheck.View.AddTextBoxColumn("備考", 80);
            grdCheck.View.AddTextBoxColumn("검수지연일", 80);
            grdCheck.View.PopulateColumns();
        }

        /// <summary>        
        /// 검사기준 그리드를 초기화한다.
        /// </summary>
        private void InitializeStandard()
        {
            // 그리드 초기화
            grdStandard.GridButtonItem = GridButtonItem.Refresh;
            grdStandard.View.SetIsReadOnly();
            grdStandard.View.ShowRowNumber = false;
            
            grdStandard.View.SetSortOrder("No");
            grdStandard.View.SetAutoFillColumn("기준");

            grdStandard.View.AddTextBoxColumn("No", 80);
            grdStandard.View.AddTextBoxColumn("기준", 150);
            grdStandard.View.AddTextBoxColumn("측정방법", 150);
            grdStandard.View.PopulateColumns();
        }

        /// <summary>        
        /// 검사입력 그리드를 초기화한다.
        /// </summary>
        private void InitializeData()
        {
            // 그리드 초기화
            grdData.GridButtonItem = GridButtonItem.All;
            grdData.View.SetIsReadOnly();

            grdData.View.SetSortOrder("S/N");
            grdData.View.SetAutoFillColumn("기타");

            grdData.View.AddTextBoxColumn("S/N", 100);
            grdData.View.AddTextBoxColumn("A", 50);
            grdData.View.AddTextBoxColumn("B", 50);
            grdData.View.AddTextBoxColumn("C", 50);
            grdData.View.AddTextBoxColumn("D", 50);
            grdData.View.AddTextBoxColumn("E", 50);
            grdData.View.AddTextBoxColumn("F", 50);
            grdData.View.AddTextBoxColumn("G", 50);
            grdData.View.AddTextBoxColumn("H", 50);
            grdData.View.AddTextBoxColumn("I", 50);
            grdData.View.AddTextBoxColumn("기타", 120);
            grdData.View.AddTextBoxColumn("합격", 80);
            grdData.View.PopulateColumns();
        }

        #endregion
    }
}
