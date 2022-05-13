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
    public partial class ShipmentReportMgt : SmartConditionBaseForm
    {
        public ShipmentReportMgt()
        {
            InitializeComponent();
            InitializeGrid1();
            InitializeGrid2();

        }

        private void InitializeGrid1()
        {
            grd1.GridButtonItem = GridButtonItem.All;
            grd1.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grd1.View.AddTextBoxColumn("출하성적서ID", 150);
            grd1.View.AddTextBoxColumn("품목코드", 150);
            grd1.View.AddTextBoxColumn("기종", 150);
            grd1.View.AddTextBoxColumn("파일", 150);
            grd1.View.AddTextBoxColumn("Rev", 100);
            grd1.View.AddTextBoxColumn("파일위치", 200);
            grd1.View.AddTextBoxColumn("파일명", 200);
            grd1.View.AddTextBoxColumn("비고사항", 200);

            grd1.View.AddTextBoxColumn("CREATOR", 80)
             .SetIsReadOnly()
             .SetTextAlignment(TextAlignment.Center);
            grd1.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);
            grd1.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grd1.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            grd1.View.PopulateColumns();

        }

        private void InitializeGrid2()
        {
            grd2.GridButtonItem = GridButtonItem.All;
            grd2.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grd2.View.AddTextBoxColumn("출하성적서ID", 150);
            grd2.View.AddTextBoxColumn("Rev명", 200);
            grd2.View.AddTextBoxColumn("파일위치", 200);
            grd2.View.AddTextBoxColumn("파일명", 200);
            grd2.View.AddTextBoxColumn("비고사항", 200);

            grd2.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grd2.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            grd2.View.PopulateColumns();
        }
    }
}
