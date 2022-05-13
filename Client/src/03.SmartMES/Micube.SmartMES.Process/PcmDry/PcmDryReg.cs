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

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 실적관리 > 공정실적 등록(가공,건조)
    /// 업  무  설  명  : 공정실적(가공,건조)을 등록한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-05
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class PcmDryReg : SmartConditionBaseForm
    {
        public PcmDryReg()
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
            InitializeWorkOrder();
            InitializeLotResult();

            //LoadDataWarehouse();

        }

        /// <summary>        
        /// 작업지시 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeWorkOrder()
        {
            // 그리드 초기화
            grdWorkOrder.GridButtonItem = GridButtonItem.Refresh;

            grdWorkOrder.View.SetIsReadOnly();

            grdWorkOrder.View.SetSortOrder("생산지시번호");
            grdWorkOrder.View.SetAutoFillColumn("품목명");

            grdWorkOrder.View.AddTextBoxColumn("생산지시번호", 150);
            grdWorkOrder.View.AddTextBoxColumn("작업지시일", 100);
            grdWorkOrder.View.AddTextBoxColumn("품목명", 200);
            grdWorkOrder.View.AddTextBoxColumn("공정", 100);
            grdWorkOrder.View.AddTextBoxColumn("지시수량", 100);
            grdWorkOrder.View.AddTextBoxColumn("실적수량", 100);
            grdWorkOrder.View.AddTextBoxColumn("LOT Size", 100);
            grdWorkOrder.View.AddTextBoxColumn("완료예정일", 100);
            grdWorkOrder.View.AddTextBoxColumn("진행상태", 100);
            grdWorkOrder.View.AddTextBoxColumn("완료보고일", 100);
            grdWorkOrder.View.AddTextBoxColumn("비고사항", 200);
            grdWorkOrder.View.PopulateColumns();
        }

        /// <summary>        
        /// LOT실적 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeLotResult()
        {
            // 그리드 초기화
            grdLotResult.GridButtonItem = GridButtonItem.Refresh;

            grdWorkOrder.View.SetIsReadOnly();

            grdLotResult.View.SetSortOrder("LOT번호");
            grdLotResult.View.SetAutoFillColumn("자재명");

            grdLotResult.View.AddTextBoxColumn("LOT번호", 150);
            grdLotResult.View.AddTextBoxColumn("수량", 100);
            grdLotResult.View.AddTextBoxColumn("설비", 200);
            grdLotResult.View.AddTextBoxColumn("시작일시", 120);
            grdLotResult.View.AddTextBoxColumn("종료일시", 120);
            grdLotResult.View.AddTextBoxColumn("상태", 80);
            grdLotResult.View.AddTextBoxColumn("작업자", 100);
            grdLotResult.View.AddTextBoxColumn("작업시간", 100);
            grdLotResult.View.AddTextBoxColumn("투입LOT", 100);
            grdLotResult.View.AddTextBoxColumn("자재명", 150);
            grdLotResult.View.AddTextBoxColumn("수량", 100);
            grdLotResult.View.PopulateColumns();
        }

        #endregion
    }
}
