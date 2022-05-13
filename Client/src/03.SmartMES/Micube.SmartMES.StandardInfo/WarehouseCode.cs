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
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 창고코드 관리
    /// 업  무  설  명  : 창고코드 정보를 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-05
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class WarehouseCode : SmartConditionBaseForm
    {
        public WarehouseCode()
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
            InitializeWarehouse();

            LoadDataWarehouse();

        }

        /// <summary>        
        /// 창고코드 관리 그리드를 초기화한다.
        /// </summary>
        private void InitializeWarehouse()
        {
            // 그리드 초기화
            grdWarehouse.GridButtonItem = GridButtonItem.All;
            grdWarehouse.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdWarehouse.View.SetSortOrder("WAREHOUSEID");

            //창고코드
            grdWarehouse.View.AddTextBoxColumn("WAREHOUSEID", 100)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            //창고명
            grdWarehouse.View.AddLanguageColumn("WAREHOUSENAME", 150);
            //관리구분
            grdWarehouse.View.AddComboBoxColumn("WAREHOUSETYPE", 100
                    , new SqlQuery("GetCodeList", "00001", "CODECLASSID=WarehouseType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center);
            //관리부서
            grdWarehouse.View.AddTextBoxColumn("DEPARTMENTID", 100);
            //ERP창고코드
            grdWarehouse.View.AddTextBoxColumn("WAREHOUSESEQ", 100);
            //사용여부
            grdWarehouse.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            //생성자
            grdWarehouse.View.AddTextBoxColumn("CREATOR", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //생성일시
            grdWarehouse.View.AddTextBoxColumn("CREATEDTIME", 140)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetIsReadOnly();
            //수정자
            grdWarehouse.View.AddTextBoxColumn("MODIFIER", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //수정일시
            grdWarehouse.View.AddTextBoxColumn("MODIFIEDTIME", 140)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetIsReadOnly();
            //비고사항
            grdWarehouse.View.AddTextBoxColumn("DESCRIPTION", 150);

            grdWarehouse.View.PopulateColumns();

            grdWarehouse.View.OptionsCustomization.AllowFilter = false;
            grdWarehouse.View.OptionsCustomization.AllowSort = false;
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdWarehouse.View.AddingNewRow += View_AddingNewRow;
        }

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdWarehouse.View.GetFocusedDataRow();

        }

        #endregion

        #region ToolBar

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdWarehouse.GetChangedRows();

            ExecuteRule("SaveWarehouseCode", changed);
        }

        #endregion

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtWarehouse = await QueryAsync("GetListWarehouseCode", "00001", values);

            if (dtWarehouse.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdWarehouse.DataSource = dtWarehouse;
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdWarehouse.View.CheckValidation();

            DataTable changed = grdWarehouse.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        private void LoadDataWarehouse()
        {
            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);


            grdWarehouse.DataSource = SqlExecuter.Query("GetListWarehouseCode", "00001", values);
        }

        #endregion
    }
}
