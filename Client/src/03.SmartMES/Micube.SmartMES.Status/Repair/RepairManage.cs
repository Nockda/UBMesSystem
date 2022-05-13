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
    /// 프 로 그 램 명  : 현황관리 > 수리관리 > 수리관리대장 현황
    /// 업  무  설  명  : 수리관리대장정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-10
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class RepairManage : SmartConditionBaseForm
    {
        public RepairManage()
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
            grdInfo.GridButtonItem = GridButtonItem.All;
            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdInfo.View.SetIsReadOnly();

            grdInfo.View.SetSortOrder("관리번호");
            grdInfo.View.SetAutoFillColumn("수리의뢰내용");

            grdInfo.View.AddTextBoxColumn("관리번호", 80);
            grdInfo.View.AddTextBoxColumn("LOT No", 80);
            grdInfo.View.AddTextBoxColumn("접수일", 80);
            grdInfo.View.AddTextBoxColumn("고객사", 80);
            grdInfo.View.AddTextBoxColumn("작업그룹", 80);
            grdInfo.View.AddTextBoxColumn("품목코드(명)", 80);
            grdInfo.View.AddTextBoxColumn("기종", 50);
            grdInfo.View.AddTextBoxColumn("제조번호", 80);
            grdInfo.View.AddTextBoxColumn("제품사용시간", 80);
            grdInfo.View.AddTextBoxColumn("수리의뢰일", 80);
            grdInfo.View.AddTextBoxColumn("수리의뢰번호", 80);
            grdInfo.View.AddTextBoxColumn("수리비용", 80);
            grdInfo.View.AddTextBoxColumn("진행상태", 80);
            grdInfo.View.AddTextBoxColumn("희망납기일", 80);
            grdInfo.View.AddTextBoxColumn("완료일", 80);
            grdInfo.View.AddTextBoxColumn("등록자", 80);
            grdInfo.View.AddTextBoxColumn("수리의뢰내용", 80);
            grdInfo.View.AddTextBoxColumn("출하일자", 80);
            grdInfo.View.PopulateColumns();
        }

        #endregion
    }
}
