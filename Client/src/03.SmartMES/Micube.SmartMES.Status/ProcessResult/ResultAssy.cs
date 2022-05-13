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

namespace Micube.SmartMES.Status
{
    /// <summary>
    /// 프 로 그 램 명  : 현황관리 > 실적관리 > 조립공정 실적 현황
    /// 업  무  설  명  : 수리관리대장정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-10
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ResultAssy : SmartConditionBaseForm
    {
        public ResultAssy()
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
        /// 마스터 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeMaster()
        {
            // 그리드 초기화
            grdMaster.GridButtonItem = GridButtonItem.Refresh;
            grdMaster.View.SetIsReadOnly();

            grdMaster.View.SetSortOrder("라우팅명");
            grdMaster.View.SetAutoFillColumn("비고사항");

            grdMaster.View.AddTextBoxColumn("라우팅명", 100);
            grdMaster.View.AddTextBoxColumn("기종", 80);
            grdMaster.View.AddTextBoxColumn("구분", 80);
            grdMaster.View.AddTextBoxColumn("사업장", 80);
            grdMaster.View.AddTextBoxColumn("공장", 80);
            grdMaster.View.AddTextBoxColumn("작업장", 80);
            grdMaster.View.AddTextBoxColumn("공정", 100);
            grdMaster.View.AddTextBoxColumn("작업그룹", 80);
            grdMaster.View.AddTextBoxColumn("비고", 120);
            grdMaster.View.PopulateColumns();
        }


        /// <summary>        
        /// 아이템 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeItem()
        {
            // 그리드 초기화
            grdItem.GridButtonItem = GridButtonItem.Refresh | GridButtonItem.Expand | GridButtonItem.Restore;
            grdItem.View.SetIsReadOnly();

            grdItem.View.SetSortOrder("그룹코드");
            grdItem.View.SetAutoFillColumn("비고");

            grdItem.View.AddTextBoxColumn("그룹코드", 80);
            grdItem.View.AddTextBoxColumn("세부공정", 120);
            grdItem.View.AddTextBoxColumn("스테이지", 80);
            grdItem.View.AddTextBoxColumn("투입인원", 80);
            grdItem.View.AddTextBoxColumn("작업자", 80);
            grdItem.View.AddTextBoxColumn("완료일", 100);
            grdItem.View.AddTextBoxColumn("완성수", 80);
            grdItem.View.AddTextBoxColumn("비고", 120);
            grdItem.View.PopulateColumns();
        }

        #endregion
    }
}
