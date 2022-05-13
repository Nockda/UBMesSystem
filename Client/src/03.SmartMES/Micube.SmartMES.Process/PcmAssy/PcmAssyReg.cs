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
    /// 프 로 그 램 명  : 공정관리 > 실적관리 > 조립실적 등록
    /// 업  무  설  명  : 조립실적을 등록한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-06
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class PcmAssyReg : SmartConditionBaseForm
    {
        public PcmAssyReg()
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

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeSub();
            InitializeDetail();
            InitializeInput();

            //LoadDataWarehouse();

        }

        /// <summary>        
        /// SUB 공정실적 그리드를 초기화한다.
        /// </summary>
        private void InitializeSub()
        {
            // 그리드 초기화
            grdSub.GridButtonItem = GridButtonItem.Refresh;

            grdSub.View.SetIsReadOnly();

            grdSub.View.SetSortOrder("SUB공정");
            grdSub.View.SetAutoFillColumn("특이사항");

            grdSub.View.AddTextBoxColumn("SUB공정", 150);
            grdSub.View.AddTextBoxColumn("세부작업", 150);
            grdSub.View.AddTextBoxColumn("작업자", 150);
            grdSub.View.AddTextBoxColumn("시작일시", 150);
            grdSub.View.AddTextBoxColumn("종료일시", 150);
            grdSub.View.AddTextBoxColumn("작업시간(h)", 150);
            grdSub.View.AddTextBoxColumn("설비명", 150);
            grdSub.View.AddTextBoxColumn("가동시간(h)", 150);
            grdSub.View.AddTextBoxColumn("완료", 100);
            grdSub.View.AddTextBoxColumn("특이사항", 250);
            grdSub.View.PopulateColumns();
        }

        /// <summary>        
        /// 세부실적 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeDetail()
        {
            // 그리드 초기화
            grdDetail.GridButtonItem = GridButtonItem.Refresh;

            grdDetail.View.SetIsReadOnly();

            grdDetail.View.SetSortOrder("실적항목");
            grdDetail.View.SetAutoFillColumn("SPEC");

            grdDetail.View.AddTextBoxColumn("실적항목", 100);
            grdDetail.View.AddTextBoxColumn("다중", 80);
            grdDetail.View.AddTextBoxColumn("결과", 100);
            grdDetail.View.AddTextBoxColumn("단위", 100);
            grdDetail.View.AddTextBoxColumn("SPEC", 150);
            grdDetail.View.PopulateColumns();
        }

        /// <summary>        
        /// 자재투입 실적 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeInput()
        {
            // 그리드 초기화
            grdInput.GridButtonItem = GridButtonItem.Refresh;

            grdInput.View.SetIsReadOnly();

            grdInput.View.SetSortOrder("구분");
            grdInput.View.SetAutoFillColumn("특이사항");

            grdInput.View.AddTextBoxColumn("구분", 100);
            grdInput.View.AddTextBoxColumn("자재명", 150);
            grdInput.View.AddTextBoxColumn("LOT번호", 150);
            grdInput.View.AddTextBoxColumn("양품", 80);
            grdInput.View.AddTextBoxColumn("불량", 80);
            grdInput.View.AddTextBoxColumn("단위", 80);
            grdInput.View.AddTextBoxColumn("특이사항", 200);
            grdInput.View.PopulateColumns();
        }

        #endregion


        #region Event
        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        private void InitializeEvent()
        {
            this.btnInputMaterial.Click += new System.EventHandler(this.btnInputMaterial_Click);
            this.btnInspection.Click += new System.EventHandler(this.btnInspection_Click);
            this.btnWorker.Click += new System.EventHandler(this.btnWorker_Click);
        }

        private void btnInputMaterial_Click(object sender, EventArgs e)
        {
            InputMaterialPopup itemPopup = new InputMaterialPopup();
            itemPopup.ShowDialog(this);
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            InspectionRegPopup itemPopup = new InspectionRegPopup();
            itemPopup.ShowDialog(this);
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
/*            WorkerRegPopup itemPopup = new WorkerRegPopup();
            itemPopup.ShowDialog(this);*/
        }

        #endregion


    }
}
