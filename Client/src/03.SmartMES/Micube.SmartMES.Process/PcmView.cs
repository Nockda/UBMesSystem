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

namespace Micube.SmartMES.Process
{
    public partial class PcmView : SmartConditionBaseForm
    {
        public PcmView()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeGridOrder();
            InitializeGridList();
        }

        private void InitializeGridOrder()
        {
            grdOrder.GridButtonItem = GridButtonItem.All;
            grdOrder.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdOrder.View.AddTextBoxColumn("생산지시번호", 150);
            grdOrder.View.AddTextBoxColumn("생산지시일", 150);
            grdOrder.View.AddTextBoxColumn("LOT NO.", 150);
            grdOrder.View.AddTextBoxColumn("품목코드(명)", 150);
            grdOrder.View.AddTextBoxColumn("기종", 150);
            grdOrder.View.AddTextBoxColumn("작업그룹", 150);

            grdOrder.View.PopulateColumns();
        }

        private void InitializeGridList()
        {
            grdList.GridButtonItem = GridButtonItem.All;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdList.View.AddTextBoxColumn("SUB 공정", 150);
            grdList.View.AddTextBoxColumn("도번", 150);
            grdList.View.AddTextBoxColumn("작업자", 150);
            grdList.View.AddTextBoxColumn("시작일시", 150);
            grdList.View.AddTextBoxColumn("종료일시", 150);
            grdList.View.AddTextBoxColumn("작업시간(H)", 100);
            grdList.View.AddTextBoxColumn("설비명", 150);
            grdList.View.AddTextBoxColumn("가동시간(h)", 100);

            grdList.View.PopulateColumns();
        }
    

    }
}
