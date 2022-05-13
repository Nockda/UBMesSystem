#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 조회 > 품목조회
    /// 업  무  설  명  : 기준정보 품목정보를 조회
    /// 생    성    자  : jylee
    /// 생    성    일  : 2019-04-06
    /// 수  정  이  력  : 2020-05-06 | scmo | ERP연동에 따른 쿼리 및 컬럼변경
    ///                   2020-05-12 | jylee | 원자재 개별화면 구성, 맵핑기능 추가
    /// 
    /// </summary>
    public partial class ItemMgt : SmartConditionBaseForm
    {
        public ItemMgt()
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
            InitializeItemGrid();
        }

        /// <summary>        
        /// 그리드를 초기화한다.
        /// </summary>
        private void InitializeItemGrid()
        {
            grdItem.GridButtonItem = GridButtonItem.Refresh | GridButtonItem.Export;

            grdItem.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdItem.View.SetSortOrder("ITEMID");
            grdItem.View.SetAutoFillColumn("ITEMNAME");

            //품목코드
            grdItem.View.AddTextBoxColumn("ITEMID", 150)
                .SetValidationIsRequired()
                .SetIsReadOnly();
            //품목명
            grdItem.View.AddTextBoxColumn("ITEMNAME", 150)
                .SetIsReadOnly();
            //규격
            grdItem.View.AddTextBoxColumn("ITEMSTANDARD", 100)
                .SetIsReadOnly();
            //스팩ID
            grdItem.View.AddTextBoxColumn("SPECID", 150);

            //품목자산분류
            grdItem.View.AddTextBoxColumn("ITEMASSETCATEGORY", 150)
                .SetIsReadOnly();
            //단위
            grdItem.View.AddTextBoxColumn("UNIT", 100)
                .SetIsReadOnly();
            //대분류
            grdItem.View.AddTextBoxColumn("LARGECATEGORY", 150)
                .SetIsReadOnly();
            //중분류
            grdItem.View.AddTextBoxColumn("MEDIUMCATEGORY", 150)
                .SetIsReadOnly();
            //유효상태
            grdItem.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                   .SetTextAlignment(TextAlignment.Center)
                   .SetDefault("Valid")
                   .SetValidationIsRequired();

            grdItem.View.PopulateColumns();
        }


        #endregion

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            string[] prodTypes = {"16", "4", "2"};       //제품그룹

            DataTable dtItem = new DataTable();
            dtItem = await QueryAsync("GetProductItem", "00001");

            if (dtItem.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdItem.DataSource = dtItem;
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
            grdItem.View.CheckValidation();

            DataTable changed = grdItem.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdItem.GetChangedRows();

            ExecuteRule("MappingItemSpec", changed);
        }
        #endregion
    }
}
