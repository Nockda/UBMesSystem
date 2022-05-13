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
    public partial class WorkOrderREF : SmartConditionBaseForm
    {
        public WorkOrderREF()
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
            grdRef.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdRef.View.SetSortOrder("");

            grdRef.View.AddTextBoxColumn("작업지시번호", 150);
            grdRef.View.AddTextBoxColumn("생산계획번호", 100);
            grdRef.View.AddTextBoxColumn("작업지시일", 200);
            grdRef.View.AddTextBoxColumn("생산부서", 150);
            grdRef.View.AddTextBoxColumn("워크센터", 150);
            grdRef.View.AddTextBoxColumn("제품명", 80);
            grdRef.View.AddTextBoxColumn("제품번호", 150);
            grdRef.View.AddTextBoxColumn("규격", 130);
            grdRef.View.AddTextBoxColumn("단위", 130);
            grdRef.View.AddTextBoxColumn("공정흐름차수명", 130);
            grdRef.View.AddTextBoxColumn("BOM차수", 100);
            grdRef.View.AddTextBoxColumn("계획수량", 100);
            grdRef.View.AddTextBoxColumn("지시수량", 100);
            grdRef.View.AddTextBoxColumn("진행수량", 100);
            grdRef.View.AddTextBoxColumn("양품수량", 100);
            grdRef.View.AddTextBoxColumn("불량수량", 100);
            grdRef.View.AddTextBoxColumn("미진행수량", 100);
            grdRef.View.AddTextBoxColumn("작업일", 100);
            grdRef.View.AddTextBoxColumn("작업시작시간", 100);
            grdRef.View.AddTextBoxColumn("작업종료시간", 100);
            grdRef.View.AddTextBoxColumn("현장창고", 100);
            grdRef.View.AddTextBoxColumn("도면번호", 100);
            grdRef.View.AddTextBoxColumn("비고사항", 100);

            grdRef.View.PopulateColumns();
        }
    }
}
