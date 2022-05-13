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

namespace Micube.SmartMES.StandardInfo
{
    public partial class ItemScopeMgt : SmartConditionBaseForm
    {
        public ItemScopeMgt()
        {
            InitializeComponent();
        }
        #region 컨텐츠 영역 초기화
        protected override void InitializeContent() 
        {
            base.InitializeContent();

            //InitializeEvent();

            InitializeItemStandardInfo();
            InitializeSubInfo();
        }
        /// <summary>
        /// 사전그룹 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeItemStandardInfo()
        {

            grdItemInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdItemInfo.View.AddTextBoxColumn("품목코드", 150);
            grdItemInfo.View.AddTextBoxColumn("품목명", 150);
            grdItemInfo.View.AddTextBoxColumn("기종", 80);
            grdItemInfo.View.AddTextBoxColumn("품목분류",100);
            grdItemInfo.View.AddTextBoxColumn("품목구분",150);
            grdItemInfo.View.AddTextBoxColumn("LOT 구분",100);
            grdItemInfo.View.AddTextBoxColumn("LOT 수량",100);

            grdItemInfo.View.PopulateColumns();
        }

        private void InitializeSubInfo() 
        {
            grdSubInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdSubInfo.View.AddTextBoxColumn("순서", 100);
            grdSubInfo.View.AddTextBoxColumn("SUB 공정코드", 150);
            grdSubInfo.View.AddTextBoxColumn("외주여부", 100);
            grdSubInfo.View.AddTextBoxColumn("표준공수", 150);

            grdSubInfo.View.PopulateColumns();
        }

        #endregion



        private void pnlContent_Click(object sender, EventArgs e)
        {

        }

        private void smartLabel1_Click(object sender, EventArgs e)
        {

        }

        private void smartLabelTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void smartSplitTableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void smartLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void smartLabel3_Click(object sender, EventArgs e)
        {

        }

        private void grdSubInfo_Load(object sender, EventArgs e)
        {

        }

        private void smartSplitTableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grdSubInfo_Load_1(object sender, EventArgs e)
        {

        }
    }
}
