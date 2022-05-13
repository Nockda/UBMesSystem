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
    public partial class DetailProcessMgt : SmartConditionBaseForm
    {
        public DetailProcessMgt()
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
            grdDetailProcess.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdDetailProcess.View.SetSortOrder("DISPLAYSEQUENCE");

            grdDetailProcess.View.AddTextBoxColumn("세부공정ID", 200)
                                  .SetValidationKeyColumn();

            grdDetailProcess.View.AddTextBoxColumn("세부공정명(KOR)", 200);
            grdDetailProcess.View.AddTextBoxColumn("세부공정명(ENG)", 200);
            grdDetailProcess.View.AddTextBoxColumn("세부공정명(JPN)", 200);
            grdDetailProcess.View.AddTextBoxColumn("비고사항", 200);

            grdDetailProcess.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdDetailProcess.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);
            grdDetailProcess.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdDetailProcess.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            grdDetailProcess.View.PopulateColumns();
        }
    }
}
