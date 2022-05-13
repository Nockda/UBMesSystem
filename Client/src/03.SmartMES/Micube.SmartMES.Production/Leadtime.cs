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

namespace Micube.SmartMES.Production
{
    /// <summary>
    /// 프 로 그 램 명  : 생산관리 > 생산관리 > 제조리드타임 조회2
    /// 업  무  설  명  : 제조리드타임을 조회한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-19
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class Leadtime : SmartConditionBaseForm
    {
        public Leadtime()
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
            InitializeList();

            //LoadDataManageGrid();
        }

        /// <summary>        
        /// 관리 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeList()
        {
            // 그리드 초기화
            grdList.GridButtonItem = GridButtonItem.Export;
            //grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetIsReadOnly();

            grdList.View.SetSortOrder("작업시작계획일", DevExpress.Data.ColumnSortOrder.Descending);
            grdList.View.SetAutoFillColumn("품명");

            grdList.View.AddTextBoxColumn("작업시작계획일", 100);
            grdList.View.AddTextBoxColumn("작업그룹", 80);
            grdList.View.AddTextBoxColumn("기종", 80);
            grdList.View.AddTextBoxColumn("품목코드", 80);
            grdList.View.AddTextBoxColumn("품명", 150);
            grdList.View.AddTextBoxColumn("표준시간", 80);
            grdList.View.AddTextBoxColumn("작업시작시간", 120);
            grdList.View.AddTextBoxColumn("작업종료시간", 120);
            grdList.View.AddTextBoxColumn("소요시간", 100);
            grdList.View.PopulateColumns();
        }

        #endregion
    }
}
