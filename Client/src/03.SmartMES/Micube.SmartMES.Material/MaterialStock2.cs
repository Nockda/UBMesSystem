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

namespace Micube.SmartMES.Material
{
    public partial class MaterialStock2 : SmartConditionBaseForm
    {
        public MaterialStock2()
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
            grdList.GridButtonItem = GridButtonItem.All;
            grdList.View.SetIsReadOnly();
            grdList.View.AddTextBoxColumn("창고구분", 150);
            grdList.View.AddTextBoxColumn("품명", 200);
            grdList.View.AddTextBoxColumn("품번", 150);
            grdList.View.AddTextBoxColumn("규격", 150);
            grdList.View.AddTextBoxColumn("품목자산분류", 150);
            grdList.View.AddTextBoxColumn("단위", 100);
            grdList.View.AddTextBoxColumn("품목상태", 100);
            grdList.View.AddTextBoxColumn("내외자구분", 100);
            grdList.View.AddTextBoxColumn("부서", 150);
            grdList.View.AddTextBoxColumn("관리자", 100);
            grdList.View.AddTextBoxColumn("대분류", 150);
            grdList.View.AddTextBoxColumn("중분류", 150);
            grdList.View.AddTextBoxColumn("소분류", 150);
            grdList.View.AddTextBoxColumn("수량", 100);

            grdList.View.PopulateColumns();
        }
    }
}
