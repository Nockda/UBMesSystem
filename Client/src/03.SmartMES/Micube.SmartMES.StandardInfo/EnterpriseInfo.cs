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
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 회사 관리
    /// 업  무  설  명  : 회사 정보를 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-24
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class EnterpriseInfo : SmartConditionBaseForm
    {
        public EnterpriseInfo()
        {
            InitializeComponent();
        }
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();
            InitializeCompany();

            LoadDataCompany();
        }

        /// <summary>
        /// 관리 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeCompany()
        {
            grdCompanyList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdCompanyList.View.SetSortOrder("ENTERPRISEID");

            grdCompanyList.View.AddTextBoxColumn("ENTERPRISEID", 150)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdCompanyList.View.AddTextBoxColumn("ENTERPRISENAME", 150);
            grdCompanyList.View.AddTextBoxColumn("DESCRIPTION", 200);
            grdCompanyList.View.AddTextBoxColumn("ADDRESS", 200);
            grdCompanyList.View.AddTextBoxColumn("PHONE", 150);
            grdCompanyList.View.AddTextBoxColumn("FAXNO", 150);
            grdCompanyList.View.AddTextBoxColumn("CREATOR", 80)
             .SetIsReadOnly()
             .SetTextAlignment(TextAlignment.Center);
            grdCompanyList.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);
            grdCompanyList.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdCompanyList.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);
            grdCompanyList.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();

            grdCompanyList.View.PopulateColumns();

        }


        #region Event
        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdCompanyList.View.AddingNewRow += View_AddingNewRow;
        }

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdCompanyList.View.GetFocusedDataRow();

        }
        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdCompanyList.GetChangedRows();

            ExecuteRule("SaveEnterprise", changed);
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

            DataTable dtCompany = await QueryAsync("GetEnterprise", "00001", values);

            if (dtCompany.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdCompanyList.DataSource = dtCompany;
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
            grdCompanyList.View.CheckValidation();

            DataTable changed = grdCompanyList.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function
        private void LoadDataCompany()
        {
            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);


            grdCompanyList.DataSource = SqlExecuter.Query("GetEnterprise", "00001", values);
        }
        #endregion
    }
}
