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
    public partial class WorkOrder : SmartConditionBaseForm
    {
        public WorkOrder()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializePoPlanGrid();
        }

        private void InitializePoPlanGrid()
        {
            grdPoPlanList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdPoPlanList.View.SetSortOrder("확정");

            grdPoPlanList.View.AddTextBoxColumn("확정", 80);
            grdPoPlanList.View.AddTextBoxColumn("확정일자", 130);
            grdPoPlanList.View.AddTextBoxColumn("생산계획번호", 150);
            grdPoPlanList.View.AddTextBoxColumn("작업그룹", 100);
            grdPoPlanList.View.AddTextBoxColumn("품명", 200);
            grdPoPlanList.View.AddTextBoxColumn("품번", 150);
            grdPoPlanList.View.AddTextBoxColumn("규격", 150);
            grdPoPlanList.View.AddTextBoxColumn("분류", 80);
            grdPoPlanList.View.AddTextBoxColumn("계획수량", 150);
            grdPoPlanList.View.AddTextBoxColumn("생산시작일", 130);
            grdPoPlanList.View.AddTextBoxColumn("생산완료일", 130);
            grdPoPlanList.View.AddTextBoxColumn("출하예정일", 130);
            grdPoPlanList.View.AddTextBoxColumn("담당자", 100);
            grdPoPlanList.View.AddButtonColumn("버튼", 100);
            grdPoPlanList.View.CancelFixColumn();
            grdPoPlanList.View.CanCancelFixColumn();
            grdPoPlanList.View.AddTextBoxColumn("CREATEDTIME", 130)
               .SetIsReadOnly()
               .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
               .SetTextAlignment(TextAlignment.Center);

            grdPoPlanList.View.PopulateColumns();

        }
    }
}
