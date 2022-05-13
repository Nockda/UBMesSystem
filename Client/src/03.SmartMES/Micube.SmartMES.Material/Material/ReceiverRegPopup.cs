#region using

using DevExpress.XtraGrid.Views.Grid;
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

#endregion

namespace Micube.SmartMES.Material
{
    public partial class ReceiverRegPopup : SmartPopupBaseForm
    {
        #region Local Variables

        public string _DeptCode { get; set; }
        public string _ReceiverId { get; set; }

        #endregion
        public ReceiverRegPopup()
        {
            InitializeComponent();
            InitializeEvent();
        }

        private void InitializeReceiver()
        {
            ConditionItemSelectPopup recvPopup = new ConditionItemSelectPopup();

            recvPopup.SetPopupLayoutForm(400, 600, FormBorderStyle.FixedToolWindow);
            recvPopup.SetPopupLayout("SELECTUSER", PopupButtonStyles.Ok_Cancel, true, false);
            recvPopup.Id = "SELECTUSER";
            recvPopup.LabelText = "RECEIVER";
            recvPopup.SearchQuery = new SqlQuery("GetUserSelectPopup", "00001", $"LANGUAGETYPE={ UserInfo.Current.LanguageType }", $"P_USERCLASSID=OutReceiver");

            recvPopup.IsMultiGrid = false;
            recvPopup.ValueFieldName = "USERID";
            recvPopup.DisplayFieldName = "USERNAME";

            recvPopup.LanguageKey = "RECEIVER";

            recvPopup.Conditions.AddTextBox("P_USERNAME")
                .SetLabel("USERNAME");

            recvPopup.GridColumns.AddTextBoxColumn("USERID", 80)
                .SetIsHidden();
            recvPopup.GridColumns.AddTextBoxColumn("USERNAME", 100)
                .SetTextAlignment(TextAlignment.Center);
            recvPopup.GridColumns.AddTextBoxColumn("DEPARTMENT", 80)
                .SetIsHidden();
            recvPopup.GridColumns.AddTextBoxColumn("DEPARTMENTNAME", 120)
                .SetLabel("DEPARTMENT")
                .SetTextAlignment(TextAlignment.Center);

            recvPopup.SetPopupApplySelection((selectedRows, dataGridRows) =>
            {
                List<DataRow> list = selectedRows.ToList<DataRow>();
                if (list.Count == 0) return;
                _DeptCode = list[0]["DEPARTMENT"].ToString();
                _ReceiverId = list[0]["USERID"].ToString();
            });

            lblReceiver.Editor.SelectPopupCondition = recvPopup;
        }

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            this.Load += ReceiverRegPopup_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void ReceiverRegPopup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeReceiver();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (lblReceiver.GetValue() == null || lblReceiver.GetValue().Equals(""))
            {
                throw MessageException.Create("NoReceiver");
                return;
            }
                

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
