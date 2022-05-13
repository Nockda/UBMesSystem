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
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 자재창고렉관리
    /// 업  무  설  명  : 자재창고렉 정보를 조회하고 수정
    /// 생    성    자  : jylee
    /// 생    성    일  : 2019-04-02
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class MaterialRack : SmartConditionBaseForm
    {
        public MaterialRack()
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

            InitializeGrid();

        }

        /// <summary>        
        /// 창고코드 관리 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            //그리드 초기화
            grdItemFactory.GridButtonItem |= GridButtonItem.Copy;
            grdItemFactory.GridButtonItem |= GridButtonItem.Import;
            grdItemFactory.GridButtonItem |= GridButtonItem.Export;
            grdItemFactory.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdItemFactory.View.SetSortOrder("R_TYPEID");

            //렉ID
            grdItemFactory.View.AddTextBoxColumn("R_TYPEID", 150)
                .SetValidationKeyColumn()
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center);
            //렉명
            grdItemFactory.View.AddTextBoxColumn("R_TYPENAME", 120)
                .SetTextAlignment(TextAlignment.Center);
            //렉설명
            grdItemFactory.View.AddTextBoxColumn("R_TPYEDESCRIPTION", 200);
            //CELL명
            grdItemFactory.View.AddTextBoxColumn("CELLNAME", 80)
                .SetTextAlignment(TextAlignment.Center);
            //TEAM
            grdItemFactory.View.AddTextBoxColumn("TEAM", 100)
                .SetTextAlignment(TextAlignment.Center);
            //품목코드
            grdItemFactory.View.AddTextBoxColumn("ITEMID", 150)
                .SetTextAlignment(TextAlignment.Center);
            //품목명
            grdItemFactory.View.AddTextBoxColumn("ITEMNAME", 250);
            //재고수량
            //grdItemFactory.View.AddTextBoxColumn("TYPECNT", 80);
            //최종입고일
            //grdItemFactory.View.AddTextBoxColumn("CREATEDT", 200);
            //최종출고일
            //grdItemFactory.View.AddTextBoxColumn("UPDATEDT", 200);



            grdItemFactory.View.PopulateColumns();

        }

        #endregion

        #region ToolBar

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>

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

            DataTable dtWarehouse = await QueryAsync("UL_GET_STANDARD_ITEM_WAREHOUSE_RACK_LIST", "00001", values);

            if (dtWarehouse.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdItemFactory.DataSource = dtWarehouse;
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


        #endregion

        #region Private Function
        #endregion
    }
}
