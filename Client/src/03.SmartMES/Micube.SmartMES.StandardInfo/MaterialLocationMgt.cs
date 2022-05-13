#region using

using Micube.Framework;
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
    public partial class MaterialLocationMgt : SmartConditionBaseForm
    {
        public MaterialLocationMgt()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeList();

        }

        private void InitializeList()
        {
            //그리드 초기화
            grdLocationList.GridButtonItem |= GridButtonItem.Copy;
            grdLocationList.GridButtonItem |= GridButtonItem.Import;
            grdLocationList.GridButtonItem |= GridButtonItem.Export;
            grdLocationList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdLocationList.View.SetSortOrder("L_TYPEID");

            //로케이션ID
            grdLocationList.View.AddTextBoxColumn("L_TYPEID", 150)
                .SetValidationKeyColumn()
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center);
            //로케이션명
            grdLocationList.View.AddTextBoxColumn("L_TYPENAME", 120)
                .SetTextAlignment(TextAlignment.Center);
            //로케이션설명
            grdLocationList.View.AddTextBoxColumn("L_TPYEDESCRIPTION", 200);
            //TEAM
            grdLocationList.View.AddTextBoxColumn("TEAM", 100)
                .SetTextAlignment(TextAlignment.Center);
            //품목코드
            grdLocationList.View.AddTextBoxColumn("ITEMID", 150)
                .SetTextAlignment(TextAlignment.Center);
            //품목명
            grdLocationList.View.AddTextBoxColumn("ITEMNAME", 250);
            //재고수량
            //grdLocationList.View.AddTextBoxColumn("TYPECNT", 80);
            //최종입고일
            //grdLocationList.View.AddTextBoxColumn("CREATEDT", 200);
            //최종출고일
            //grdLocationList.View.AddTextBoxColumn("UPDATEDT", 200);


            grdLocationList.View.PopulateColumns();

        }

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtWarehouse = await QueryAsync("UL_GET_STANDARD_ITEM_WAREHOUSE_LOCATION_LIST", "00001", values);

            if (dtWarehouse.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdLocationList.DataSource = dtWarehouse;
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
    }
}
