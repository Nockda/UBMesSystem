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
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 작업장코드 관리
    /// 업  무  설  명  : 작업장코드 정보를 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-05-25
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class Area : SmartConditionBaseForm
    {
        public Area()
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
            InitializeListGrid();
        }

        /// <summary>        
        /// 관리 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeListGrid()
        {
            // 그리드 초기화
            grdList.GridButtonItem = GridButtonItem.All;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetSortOrder("AREAID");

            grdList.View.AddTextBoxColumn("AREAID", 80)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdList.View.AddLanguageColumn("AREANAME", 150);
            grdList.View.AddTextBoxColumn("DESCRIPTION", 200);
            grdList.View.AddComboBoxColumn("WAREHOUSEID", 150, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            grdList.View.AddTextBoxColumn("DESCRIPTION", 150);
            grdList.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetIsHidden()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetIsHidden()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetIsHidden()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetIsHidden()
                .SetTextAlignment(TextAlignment.Center);

            grdList.View.PopulateColumns();

            //grdList.View.OptionsCustomization.AllowFilter = false;
            //grdList.View.OptionsCustomization.AllowSort = false;
        }

        #endregion

        #region Event
        private void InitializeEvent()
        {
            this.Load += Area_LoadAsync;
        }

        private async void Area_LoadAsync(object sender, EventArgs e)
        {
            await OnSearchAsync();
        }
        #endregion

        #region ToolBar

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdList.GetChangedRows();

            ExecuteRule("SaveArea", changed);
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

            DataTable dtArea = await QueryAsync("GetArea", "00001", values);

            if (dtArea.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdList.DataSource = dtArea;
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
            grdList.View.CheckValidation();

            DataTable changed = grdList.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion
    }
}
