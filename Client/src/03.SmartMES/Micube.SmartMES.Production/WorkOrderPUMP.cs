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
    public partial class WorkOrderPUMP : SmartConditionBaseForm
    {
        public WorkOrderPUMP()
        {
            InitializeComponent();
        }

        protected override void InitializeCondition()
        {
            base.InitializeCondition();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            grdPump.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdPump.View.SetSortOrder("");

            grdPump.View.AddTextBoxColumn("작업지시번호", 150);
            grdPump.View.AddTextBoxColumn("생산계획번호", 100);
            grdPump.View.AddTextBoxColumn("작업지시일", 200);
            grdPump.View.AddTextBoxColumn("생산부서", 150);
            grdPump.View.AddTextBoxColumn("워크센터", 150);
            grdPump.View.AddTextBoxColumn("제품명", 80);
            grdPump.View.AddTextBoxColumn("제품번호", 150);
            grdPump.View.AddTextBoxColumn("규격", 130);
            grdPump.View.AddTextBoxColumn("단위", 130);
            grdPump.View.AddTextBoxColumn("공정흐름차수명", 130);
            grdPump.View.AddTextBoxColumn("BOM차수", 100);
            grdPump.View.AddTextBoxColumn("계획수량", 100);
            grdPump.View.AddTextBoxColumn("지시수량", 100);
            grdPump.View.AddTextBoxColumn("진행수량", 100);
            grdPump.View.AddTextBoxColumn("양품수량", 100);
            grdPump.View.AddTextBoxColumn("불량수량", 100);
            grdPump.View.AddTextBoxColumn("미진행수량", 100);
            grdPump.View.AddTextBoxColumn("작업일", 100);
            grdPump.View.AddTextBoxColumn("작업시작시간", 100);
            grdPump.View.AddTextBoxColumn("작업종료시간", 100);
            grdPump.View.AddTextBoxColumn("현장창고", 100);
            grdPump.View.AddTextBoxColumn("도면번호", 100);
            grdPump.View.AddTextBoxColumn("비고사항", 100);

            grdPump.View.PopulateColumns();
        }
    }
}
