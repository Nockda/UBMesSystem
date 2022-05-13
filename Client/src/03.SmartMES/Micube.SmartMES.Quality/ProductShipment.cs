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

namespace Micube.SmartMES.Quality
{
    public partial class ProductShipment : SmartConditionBaseForm
    {
        public ProductShipment()
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

            grdList.GridButtonItem = GridButtonItem.All;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetIsReadOnly();

            grdList.View.AddTextBoxColumn("주문No", 100);
            grdList.View.AddTextBoxColumn("S/N", 100);
            grdList.View.AddTextBoxColumn("출하예정일", 100);
            grdList.View.AddTextBoxColumn("제품번호", 100);
            grdList.View.AddTextBoxColumn("제품명", 100);
            grdList.View.AddTextBoxColumn("단위", 100);
            grdList.View.AddTextBoxColumn("수량", 100);
            grdList.View.AddTextBoxColumn("포장처", 100);
            grdList.View.SetAutoFillColumn("비고사항");

            grdList.View.AddTextBoxColumn("CREATOR", 80) // 생성자
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CREATEDTIME", 130) // 생성일시
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIER", 80) // 수정자
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIEDTIME", 130) // 수정일시
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly();

            grdList.View.PopulateColumns();


        }
    }
}
