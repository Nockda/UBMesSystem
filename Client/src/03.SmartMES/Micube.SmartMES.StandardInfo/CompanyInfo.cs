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
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 업체 관리
    /// 업  무  설  명  : 업체 정보를 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2020-03-25
    /// 수  정  이  력  : 2020-05-14    ERP I/F VIEW로 인한 변경
    /// 
    /// 
    /// </summary>
    public partial class CompanyInfo : SmartConditionBaseForm
    {
        public CompanyInfo()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();
            InitializeList();
        }

        /// <summary>
        /// 관리 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeList()
        {
            grdList.View.OptionsFind.AlwaysVisible = true;

            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdList.GridButtonItem = GridButtonItem.Export;
            grdList.View.SetSortOrder("COMPANYID");
            grdList.View.SetAutoFillColumn("COMPANYNAME");
            grdList.View.SetIsReadOnly();

            grdList.View.AddTextBoxColumn("COMPANYID", 80)
                .SetTextAlignment(TextAlignment.Center)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdList.View.AddTextBoxColumn("COMPANYNAME", 120);
            grdList.View.AddComboBoxColumn("COMPANYTYPE", 150, new SqlQuery("GetCodeList", "00001", "CODECLASSID=COMPANYTYPE", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("BUSINESSNO", 100)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CEONAME", 80);
            grdList.View.AddTextBoxColumn("LAWREGNO", 100)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("TELNO", 100);
            grdList.View.AddTextBoxColumn("PHONE", 100);
            grdList.View.AddTextBoxColumn("FAXNO", 100);
            grdList.View.AddTextBoxColumn("ZIPCODE", 80)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("ADDRESS", 200);

            grdList.View.PopulateColumns();
        }

        #region Event
        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가

        }

        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            //DataTable changed = grdList.GetChangedRows();

            //ExecuteRule("SaveCompany", changed);
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

            //DataTable dtCompany = await QueryAsync("GetCompany", "00001", values);
            DataTable dtCompany = await ProcedureAsync("USP_ERPIF_GETCOMPANY", values);

            if (dtCompany.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdList.DataSource = dtCompany;
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

        #region Private Function

        #endregion
    }
}
