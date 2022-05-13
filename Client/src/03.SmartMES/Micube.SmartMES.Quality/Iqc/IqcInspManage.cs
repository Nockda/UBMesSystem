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
    /// 프 로 그 램 명  : 품질관리 > 수입검사 > 수입검사관리대장
    /// 업  무  설  명  : 수입검사관리 정보를 확인 및 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-10
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class IqcInspManage : SmartConditionBaseForm
    {
        public IqcInspManage()
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
            InitializeInfo();

            //LoadDataManageGrid();
        }

        /// <summary>        
        /// 관리 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeInfo()
        {
            // 그리드 초기화
            grdInfo.GridButtonItem = GridButtonItem.Refresh;
            grdInfo.View.SetIsReadOnly();

            grdInfo.View.SetSortOrder("관리코드");
            grdInfo.View.SetAutoFillColumn("品名");

            grdInfo.View.AddTextBoxColumn("관리코드", 80);
            grdInfo.View.AddTextBoxColumn("品名", 120);
            grdInfo.View.AddTextBoxColumn("入庫日", 80);
            grdInfo.View.AddTextBoxColumn("検査日", 80);
            grdInfo.View.AddTextBoxColumn("PO No.", 100);
            grdInfo.View.AddTextBoxColumn("고객사", 100);
            grdInfo.View.AddTextBoxColumn("Chk. List", 80);
            grdInfo.View.AddTextBoxColumn("数量", 80);
            grdInfo.View.AddTextBoxColumn("不良数量", 80);
            grdInfo.View.AddTextBoxColumn("不良率", 80);
            grdInfo.View.AddTextBoxColumn("検査時間(分)", 80);
            grdInfo.View.AddTextBoxColumn("不良内容", 80);
            grdInfo.View.AddTextBoxColumn("備考", 80);
            grdInfo.View.AddTextBoxColumn("검수지연일", 80);
            grdInfo.View.PopulateColumns();
        }

        #endregion
    }
}
