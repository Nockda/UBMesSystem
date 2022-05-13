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
    /// 프 로 그 램 명  : 공정관리 > 설비관리 > 설비점검표 관리
    /// 업  무  설  명  : 설비점검표를 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-06
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class EquipCheckManage : SmartConditionBaseForm
    {
        public EquipCheckManage()
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
            InitializeResult();

            //LoadDataWarehouse();

        }

        /// <summary>        
        /// 작업지시 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeCheck()
        {
            // 그리드 초기화
            grdCheck.GridButtonItem = GridButtonItem.Refresh;

            grdCheck.View.SetIsReadOnly();

            grdCheck.View.SetSortOrder("점검구분");
            grdCheck.View.SetAutoFillColumn("점검항목명");

            grdCheck.View.AddTextBoxColumn("점검구분", 100);
            grdCheck.View.AddTextBoxColumn("점검부위", 100);
            grdCheck.View.AddTextBoxColumn("점검항목명", 200);
            grdCheck.View.AddTextBoxColumn("점검주기", 100);
            grdCheck.View.AddTextBoxColumn("점검방법", 100);
            grdCheck.View.AddTextBoxColumn("1", 25);
            grdCheck.View.AddTextBoxColumn("2", 25);
            grdCheck.View.AddTextBoxColumn("3", 25);
            grdCheck.View.AddTextBoxColumn("4", 25);
            grdCheck.View.AddTextBoxColumn("5", 25);
            grdCheck.View.AddTextBoxColumn("6", 25);
            grdCheck.View.AddTextBoxColumn("7", 25);
            grdCheck.View.AddTextBoxColumn("8", 25);
            grdCheck.View.AddTextBoxColumn("9", 25);
            grdCheck.View.AddTextBoxColumn("10", 25);
            grdCheck.View.AddTextBoxColumn("11", 25);
            grdCheck.View.AddTextBoxColumn("12", 25);
            grdCheck.View.AddTextBoxColumn("13", 25);
            grdCheck.View.AddTextBoxColumn("14", 25);
            grdCheck.View.AddTextBoxColumn("15", 25);
            grdCheck.View.AddTextBoxColumn("16", 25);
            grdCheck.View.AddTextBoxColumn("17", 25);
            grdCheck.View.AddTextBoxColumn("18", 25);
            grdCheck.View.AddTextBoxColumn("19", 25);
            grdCheck.View.AddTextBoxColumn("20", 25);
            grdCheck.View.AddTextBoxColumn("21", 25);
            grdCheck.View.AddTextBoxColumn("22", 25);
            grdCheck.View.AddTextBoxColumn("23", 25);
            grdCheck.View.AddTextBoxColumn("24", 25);
            grdCheck.View.AddTextBoxColumn("25", 25);
            grdCheck.View.AddTextBoxColumn("26", 25);
            grdCheck.View.AddTextBoxColumn("27", 25);
            grdCheck.View.AddTextBoxColumn("28", 25);
            grdCheck.View.AddTextBoxColumn("29", 25);
            grdCheck.View.PopulateColumns();
        }

        /// <summary>        
        /// LOT실적 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeResult()
        {
            // 그리드 초기화
            grdResult.GridButtonItem = GridButtonItem.All;
            grdResult.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdResult.View.SetSortOrder("발생일자");
            grdResult.View.SetAutoFillColumn("조치내용");

            grdResult.View.AddTextBoxColumn("발생일자", 150);
            grdResult.View.AddTextBoxColumn("문제점", 200);
            grdResult.View.AddTextBoxColumn("조치일자", 150);
            grdResult.View.AddTextBoxColumn("조치내용", 400);
            grdResult.View.AddTextBoxColumn("CREATOR", 100);
            grdResult.View.AddTextBoxColumn("CREATEDTIME", 150);
            grdResult.View.AddTextBoxColumn("MODIFIER", 100);
            grdResult.View.AddTextBoxColumn("MODIFIEDTIME", 150);
            grdResult.View.PopulateColumns();
        }

        #endregion

        #region ToolBar

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            EquipCheckRegPopup itemPopup = new EquipCheckRegPopup();
            itemPopup.ShowDialog(this);
        }

        #endregion
    }
}
