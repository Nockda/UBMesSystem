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

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 자재 > 자재 재고 현황
    /// 업  무  설  명  : 자재재고현황 정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-16
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class MaterialStock : SmartConditionBaseForm
    {
        public MaterialStock()
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
            InitializeMaster();
            InitializeItem();

            //LoadDataManageGrid();
        }

        /// <summary>        
        /// 출고계획 그리드를 초기화한다.
        /// </summary>
        private void InitializeMaster()
        {
            // 그리드 초기화
            grdMaster.GridButtonItem = GridButtonItem.All;
            grdMaster.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdMaster.View.SetIsReadOnly();

            grdMaster.View.SetSortOrder("출고계획번호");
            grdMaster.View.SetAutoFillColumn("출고계획담당자");

            grdMaster.View.AddTextBoxColumn("출고계획번호", 100);
            grdMaster.View.AddTextBoxColumn("출고예정일", 100);
            grdMaster.View.AddTextBoxColumn("거래처", 100);
            grdMaster.View.AddTextBoxColumn("규격", 70);
            grdMaster.View.AddTextBoxColumn("품목", 100);
            grdMaster.View.AddTextBoxColumn("예정출고수량", 70);
            grdMaster.View.AddTextBoxColumn("단위", 50);
            grdMaster.View.AddTextBoxColumn("방향", 70);
            grdMaster.View.AddTextBoxColumn("종결", 70);
            grdMaster.View.AddTextBoxColumn("출고계획담당자", 200);
            grdMaster.View.PopulateColumns();
        }

        /// <summary>        
        /// 출고결과 그리드를 초기화한다.
        /// </summary>
        private void InitializeItem()
        {
            // 그리드 초기화
            grdItem.GridButtonItem = GridButtonItem.All;
            grdItem.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdItem.View.SetIsReadOnly();

            grdItem.View.SetSortOrder("출고일");
            grdItem.View.SetAutoFillColumn("비고");

            grdItem.View.AddTextBoxColumn("출고일", 100);
            grdItem.View.AddTextBoxColumn("출고수량", 100);
            grdItem.View.AddTextBoxColumn("불량수량", 100);
            grdItem.View.AddTextBoxColumn("미출고수량", 100);
            grdItem.View.AddTextBoxColumn("반입", 70);
            grdItem.View.AddTextBoxColumn("비고", 250);
            grdItem.View.AddTextBoxColumn("담당자", 150);
            grdItem.View.PopulateColumns();

            grdItem.View.OptionsView.ShowFooter = true;
            grdItem.ShowStatusBar = false;
    
        }

        #endregion
    }
}
