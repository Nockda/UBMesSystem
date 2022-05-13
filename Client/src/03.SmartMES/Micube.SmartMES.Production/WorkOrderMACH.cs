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

namespace Micube.SmartMES.Production
{
    public partial class WorkOrderMACH : SmartConditionBaseForm
    {
        public WorkOrderMACH()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            grdMach.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdMach.View.SetSortOrder("PLANNUM");

            grdMach.View.AddTextBoxColumn("WORKORDERNUM", 150);
            grdMach.View.AddTextBoxColumn("PLANNUM", 100)
                .SetValidationKeyColumn();
            grdMach.View.AddTextBoxColumn("WORKORDERDATE", 200);
            grdMach.View.AddTextBoxColumn("DEPT", 150);
            grdMach.View.AddTextBoxColumn("WORKCENTER", 150);
            grdMach.View.AddTextBoxColumn("ITEMID", 80);
            grdMach.View.AddTextBoxColumn("ITEMNAME", 150);
            grdMach.View.AddTextBoxColumn("STANDARD", 130);
            grdMach.View.AddTextBoxColumn("UNIT", 130);
            grdMach.View.AddTextBoxColumn("PROCESSCOUNTNAME", 130);
            grdMach.View.AddTextBoxColumn("BOMCOUNT", 100);
            grdMach.View.AddTextBoxColumn("PLANTQTY", 100);
            grdMach.View.AddTextBoxColumn("ORDERQTY", 100);
            grdMach.View.AddTextBoxColumn("PROGRESSQTY", 100);
            grdMach.View.AddTextBoxColumn("GOODQTY", 100);
            grdMach.View.AddTextBoxColumn("BADQTY", 100);
            grdMach.View.AddTextBoxColumn("NOTQTY", 100);
            grdMach.View.AddTextBoxColumn("WORKDATE", 100);
            grdMach.View.AddTextBoxColumn("STARTHOUR", 100);
            grdMach.View.AddTextBoxColumn("ENDHOUR", 100);
            grdMach.View.AddTextBoxColumn("WAREHOUSE", 100);
            grdMach.View.AddTextBoxColumn("DRAWINGNUM", 100);
            grdMach.View.AddTextBoxColumn("DESCRIPTION", 100);

            grdMach.View.PopulateColumns();
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

            DataTable dtItem = await QueryAsync("GetWorkOrderGrid", "00001", values);

            if (dtItem.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdMach.DataSource = dtItem;
        }

        #endregion

        #region ToolBar

        /// <summary>
        /// 엑셀 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarClick(ToolbarClickEventArgs e)
        {
            base.OnToolbarClick(e);

            Dictionary<string, object> cellValue = new Dictionary<string, object>();
             cellValue.Add("A1", 22);
             cellValue.Add("A2", 33);
             cellValue.Add("A3", 44);

            Commons.BindingExcel.File(@"E:\Excel\test.xlsx", cellValue);
        }

        #endregion
    }
}
