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


namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 라우터관리 > 품목라우터관리
    /// 업  무  설  명  : 품목라운터 관리정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-09
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class RouterManage : SmartConditionBaseForm
    {
        public RouterManage()
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
            InitializeRouter();
            InitializeDetail();
            InitializeMapping();
            InitializeResult();

            //LoadDataManageGrid();
        }

        /// <summary>        
        /// 라우터 기본정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeRouter()
        {
            // 그리드 초기화
            grdRouter.GridButtonItem = GridButtonItem.Expand | GridButtonItem.Restore | GridButtonItem.All;
            //grdRouter.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdRouter.View.SetIsReadOnly();

            grdRouter.View.SetSortOrder("라우터ID");
            grdRouter.View.SetAutoFillColumn("라우터설명");
            
            grdRouter.View.AddTextBoxColumn("라우터ID", 70);
            grdRouter.View.AddTextBoxColumn("라우터 설명", 100);
            grdRouter.View.AddTextBoxColumn("공정코드", 70);
            grdRouter.View.AddTextBoxColumn("SUB유무", 50);
            grdRouter.View.AddTextBoxColumn("품목수", 50);
            grdRouter.View.AddTextBoxColumn("CREATOR", 50);
            grdRouter.View.AddTextBoxColumn("CREATEDTIME", 70);
            grdRouter.View.AddTextBoxColumn("MODIFIER", 50);
            grdRouter.View.AddTextBoxColumn("MODIFIEDTIME", 70);
            grdRouter.View.PopulateColumns();
        }

        /// <summary>        
        /// 세부작업 공정 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeDetail()
        {
            // 그리드 초기화
            grdDetail.GridButtonItem = GridButtonItem.Refresh;
            //grdMapping.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdDetail.View.SetIsReadOnly();

            grdDetail.View.SetSortOrder("순서");
            grdDetail.View.SetAutoFillColumn("SUB공정코드");

            grdDetail.View.AddTextBoxColumn("순서", 70);
            grdDetail.View.AddTextBoxColumn("SUB공정코드", 120);
            grdDetail.View.AddTextBoxColumn("실적유무", 50);
            grdDetail.View.AddTextBoxColumn("외주여부", 50);
            grdDetail.View.AddTextBoxColumn("실적수", 50);
            grdDetail.View.AddTextBoxColumn("CREATOR", 50);
            grdDetail.View.AddTextBoxColumn("CREATEDTIME", 70);
            grdDetail.View.AddTextBoxColumn("MODIFIER", 50);
            grdDetail.View.AddTextBoxColumn("MODIFIEDTIME", 70);
            grdDetail.View.PopulateColumns();
        }


        /// <summary>        
        /// 품목 Mapping정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeMapping()
        {
            // 그리드 초기화
            grdMapping.GridButtonItem = GridButtonItem.Refresh;
            //grdMapping.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdMapping.View.SetIsReadOnly();

            grdMapping.View.SetSortOrder("품목코드");
            grdMapping.View.SetAutoFillColumn("품목명");

            grdMapping.View.AddTextBoxColumn("품목코드", 70);
            grdMapping.View.AddTextBoxColumn("품목명", 120);
            grdMapping.View.AddTextBoxColumn("기종", 50);
            grdMapping.View.AddTextBoxColumn("품목분류", 50);
            grdMapping.View.AddTextBoxColumn("품목구분", 50);
            grdMapping.View.AddTextBoxColumn("LOT구분", 50);
            grdMapping.View.PopulateColumns();
        }

        /// <summary>        
        /// 실적 입력항목 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeResult()
        {
            // 그리드 초기화
            grdResult.GridButtonItem = GridButtonItem.Refresh;
            //grdResult.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdResult.View.SetIsReadOnly();

            grdResult.View.SetSortOrder("입력항목코드");
            grdResult.View.SetAutoFillColumn("입력항목코드");

            grdResult.View.AddTextBoxColumn("입력항목코드", 100);
            grdResult.View.AddTextBoxColumn("자리수", 50);
            grdResult.View.AddTextBoxColumn("단위", 50);
            grdResult.View.AddTextBoxColumn("CREATOR", 50);
            grdResult.View.AddTextBoxColumn("CREATEDTIME", 70);
            grdResult.View.AddTextBoxColumn("MODIFIER", 50);
            grdResult.View.AddTextBoxColumn("MODIFIEDTIME", 70);
            grdResult.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        private void InitializeEvent()
        {

        }

        private void btnMappProduct_Click(object sender, EventArgs e)
        {
            MappProductPopup itemPopup = new MappProductPopup();
            itemPopup.ShowDialog(this);
        }

        private void btnDetailProcess_Click(object sender, EventArgs e)
        {
            DetailProcessPopup itemPopup = new DetailProcessPopup();
            itemPopup.ShowDialog(this);
        }

        private void btnResultProduct_Click(object sender, EventArgs e)
        {
            ResultProductPopup itemPopup = new ResultProductPopup();
            itemPopup.ShowDialog(this);
        }

        #endregion

        #region 툴바

        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;


            if (btn.Name.ToString().Equals("MappProduct"))
                btnMappProduct_Click(null, null);
            else if (btn.Name.ToString().Equals("DetailProcess"))
                btnDetailProcess_Click(null, null);
            else if (btn.Name.ToString().Equals("ResultProduct"))
                btnResultProduct_Click(null, null);

        }

        #endregion
    }
}
