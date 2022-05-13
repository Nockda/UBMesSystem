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

namespace Micube.SmartMES.Status
{
    public partial class ProductEfficiencyStatus : SmartConditionBaseForm
    {
        public ProductEfficiencyStatus()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            // 컨트롤 초기화 로직 구성
            InitializeList();

        }

        private void InitializeList()
        {
            grdList.GridButtonItem = GridButtonItem.All;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetIsReadOnly();

            var gPlantInfo = grdList.View.AddGroupColumn("작업장정보");
            gPlantInfo.AddTextBoxColumn("구분", 200);
            gPlantInfo.AddTextBoxColumn("1월", 150);
            gPlantInfo.AddTextBoxColumn("2월", 150);
            gPlantInfo.AddTextBoxColumn("3월", 150);
            gPlantInfo.AddTextBoxColumn("4월", 150);
            gPlantInfo.AddTextBoxColumn("5월", 150);
            gPlantInfo.AddTextBoxColumn("6월", 150);
            gPlantInfo.AddTextBoxColumn("7월", 150);
            gPlantInfo.AddTextBoxColumn("8월", 150);
            gPlantInfo.AddTextBoxColumn("9월", 150);
            gPlantInfo.AddTextBoxColumn("10월", 150);
            gPlantInfo.AddTextBoxColumn("11월", 150);
            gPlantInfo.AddTextBoxColumn("12월", 150);
            gPlantInfo.AddTextBoxColumn("Total", 100);

            grdList.View.PopulateColumns();

        }
    }
}
