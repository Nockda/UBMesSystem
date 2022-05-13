using Micube.Framework;
using Micube.Framework.Net;
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
    public partial class ResultListManage : SmartConditionBaseForm
    {
        public ResultListManage()
        {
            InitializeComponent();

        }

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeWorkResultGrid();
            InitializeSpecGrid();
        }

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeWorkResultGrid()
        {
            grdWorkResultInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdWorkResultInfo.View.SetSortOrder("항목코드");

            grdWorkResultInfo.View.AddTextBoxColumn("항목코드", 150);
            grdWorkResultInfo.View.AddTextBoxColumn("항목명(KOR)", 150);
            grdWorkResultInfo.View.AddTextBoxColumn("항목명(ENG)", 150);
            grdWorkResultInfo.View.AddTextBoxColumn("항목명(JPN)", 150);
            grdWorkResultInfo.View.AddTextBoxColumn("비고", 0);
            grdWorkResultInfo.View.AddTextBoxColumn("자리수", 100);
            grdWorkResultInfo.View.AddTextBoxColumn("단위", 50);

            grdWorkResultInfo.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
            .SetDefault("Valid")
            //.SetValidationIsRequired()
            .SetTextAlignment(TextAlignment.Center);

            grdWorkResultInfo.View.AddTextBoxColumn("CREATOR", 80)
             .SetIsReadOnly()
             .SetTextAlignment(TextAlignment.Center);
            grdWorkResultInfo.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);
            grdWorkResultInfo.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdWorkResultInfo.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            grdWorkResultInfo.View.PopulateColumns();
        }

        private void InitializeSpecGrid()
        {
            grdSpecInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdSpecInfo.View.SetSortOrder("기종코드(명)");
            grdSpecInfo.View.AddTextBoxColumn("기종코드(명)", 150);
            grdSpecInfo.View.AddTextBoxColumn("MIN", 100);
            grdSpecInfo.View.AddTextBoxColumn("MAX", 100);
            grdSpecInfo.View.AddTextBoxColumn("비고", 200);

            grdSpecInfo.View.PopulateColumns();
        }
    }
}
