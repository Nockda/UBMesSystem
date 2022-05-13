namespace Micube.SmartMES.SystemManagement
{
    partial class DeployFileListPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.smartSplitTableLayoutPanel1 = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.chkDeployDirect = new Micube.Framework.SmartControls.SmartCheckEdit();
            this.btnCancel = new Micube.Framework.SmartControls.SmartButton();
            this.btnDeploy = new Micube.Framework.SmartControls.SmartButton();
            this.btnDefault = new Micube.Framework.SmartControls.SmartButton();
            this.lblDeplyPlanDate = new Micube.Framework.SmartControls.SmartLabel();
            this.lblDeployNote = new Micube.Framework.SmartControls.SmartLabel();
            this.txtDeployNote = new Micube.Framework.SmartControls.SmartMemoEdit();
            this.dateDeployPlan = new Micube.Framework.SmartControls.SmartDateEdit();
            this.grdFileList = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.smartSplitTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeployDirect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeployNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDeployPlan.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDeployPlan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grdFileList);
            this.pnlMain.Controls.Add(this.smartSplitTableLayoutPanel1);
            // 
            // smartSplitTableLayoutPanel1
            // 
            this.smartSplitTableLayoutPanel1.ColumnCount = 4;
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.smartSplitTableLayoutPanel1.Controls.Add(this.chkDeployDirect, 2, 0);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.btnCancel, 3, 2);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.btnDeploy, 3, 1);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.btnDefault, 3, 0);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.lblDeplyPlanDate, 0, 0);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.lblDeployNote, 0, 1);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.txtDeployNote, 1, 1);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.dateDeployPlan, 1, 0);
            this.smartSplitTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartSplitTableLayoutPanel1.Location = new System.Drawing.Point(0, 330);
            this.smartSplitTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSplitTableLayoutPanel1.Name = "smartSplitTableLayoutPanel1";
            this.smartSplitTableLayoutPanel1.RowCount = 3;
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.smartSplitTableLayoutPanel1.Size = new System.Drawing.Size(780, 100);
            this.smartSplitTableLayoutPanel1.TabIndex = 0;
            // 
            // chkDeployDirect
            // 
            this.chkDeployDirect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkDeployDirect.LabelText = null;
            this.chkDeployDirect.LanguageKey = "DEPLOYDIRECT";
            this.chkDeployDirect.Location = new System.Drawing.Point(303, 3);
            this.chkDeployDirect.Name = "chkDeployDirect";
            this.chkDeployDirect.Properties.Caption = "DeployDirect";
            this.chkDeployDirect.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkDeployDirect.Properties.ValueChecked = "Y";
            this.chkDeployDirect.Properties.ValueUnchecked = "N";
            this.chkDeployDirect.Size = new System.Drawing.Size(369, 26);
            this.chkDeployDirect.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.IsBusy = false;
            this.btnCancel.IsWrite = false;
            this.btnCancel.LanguageKey = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(678, 64);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnCancel.Size = new System.Drawing.Size(99, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TooltipLanguageKey = "";
            // 
            // btnDeploy
            // 
            this.btnDeploy.AllowFocus = false;
            this.btnDeploy.IsBusy = false;
            this.btnDeploy.IsWrite = false;
            this.btnDeploy.LanguageKey = "Deploy";
            this.btnDeploy.Location = new System.Drawing.Point(678, 32);
            this.btnDeploy.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnDeploy.Size = new System.Drawing.Size(99, 26);
            this.btnDeploy.TabIndex = 0;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.TooltipLanguageKey = "";
            // 
            // btnDefault
            // 
            this.btnDefault.AllowFocus = false;
            this.btnDefault.IsBusy = false;
            this.btnDefault.IsWrite = false;
            this.btnDefault.LanguageKey = "SetDefault";
            this.btnDefault.Location = new System.Drawing.Point(678, 0);
            this.btnDefault.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnDefault.Size = new System.Drawing.Size(99, 26);
            this.btnDefault.TabIndex = 1;
            this.btnDefault.Text = "SetDefault";
            this.btnDefault.TooltipLanguageKey = "";
            // 
            // lblDeplyPlanDate
            // 
            this.lblDeplyPlanDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeplyPlanDate.LanguageKey = "DeployPlanDate";
            this.lblDeplyPlanDate.Location = new System.Drawing.Point(3, 3);
            this.lblDeplyPlanDate.Name = "lblDeplyPlanDate";
            this.lblDeplyPlanDate.Size = new System.Drawing.Size(94, 26);
            this.lblDeplyPlanDate.TabIndex = 3;
            this.lblDeplyPlanDate.Text = "DeployPlanDate";
            // 
            // lblDeployNote
            // 
            this.lblDeployNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeployNote.LanguageKey = "DeployNote";
            this.lblDeployNote.Location = new System.Drawing.Point(3, 35);
            this.lblDeployNote.Name = "lblDeployNote";
            this.smartSplitTableLayoutPanel1.SetRowSpan(this.lblDeployNote, 2);
            this.lblDeployNote.Size = new System.Drawing.Size(94, 62);
            this.lblDeployNote.TabIndex = 4;
            this.lblDeployNote.Text = "DeployNote";
            // 
            // txtDeployNote
            // 
            this.smartSplitTableLayoutPanel1.SetColumnSpan(this.txtDeployNote, 2);
            this.txtDeployNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeployNote.Location = new System.Drawing.Point(103, 35);
            this.txtDeployNote.Name = "txtDeployNote";
            this.smartSplitTableLayoutPanel1.SetRowSpan(this.txtDeployNote, 2);
            this.txtDeployNote.Size = new System.Drawing.Size(569, 62);
            this.txtDeployNote.TabIndex = 6;
            // 
            // dateDeployPlan
            // 
            this.dateDeployPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateDeployPlan.EditValue = null;
            this.dateDeployPlan.LabelText = null;
            this.dateDeployPlan.LanguageKey = null;
            this.dateDeployPlan.Location = new System.Drawing.Point(103, 3);
            this.dateDeployPlan.Name = "dateDeployPlan";
            this.dateDeployPlan.Properties.AutoHeight = false;
            this.dateDeployPlan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDeployPlan.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDeployPlan.Size = new System.Drawing.Size(194, 26);
            this.dateDeployPlan.TabIndex = 5;
            // 
            // grdFileList
            // 
            this.grdFileList.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFileList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy)
            | Micube.Framework.SmartControls.GridButtonItem.Delete)
            | Micube.Framework.SmartControls.GridButtonItem.Preview)
            | Micube.Framework.SmartControls.GridButtonItem.Import)
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdFileList.IsUsePaging = false;
            this.grdFileList.LanguageKey = null;
            this.grdFileList.Location = new System.Drawing.Point(0, 0);
            this.grdFileList.Margin = new System.Windows.Forms.Padding(0);
            this.grdFileList.Name = "grdFileList";
            this.grdFileList.ShowBorder = true;
            this.grdFileList.Size = new System.Drawing.Size(780, 330);
            this.grdFileList.TabIndex = 1;
            // 
            // DeployFileListPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "DeployFileListPopup";
            this.Text = "DeployFileListPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.smartSplitTableLayoutPanel1.ResumeLayout(false);
            this.smartSplitTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeployDirect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeployNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDeployPlan.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDeployPlan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel1;
        private Framework.SmartControls.SmartButton btnDeploy;
        private Framework.SmartControls.SmartButton btnDefault;
        private Framework.SmartControls.SmartButton btnCancel;
        private Framework.SmartControls.SmartLabel lblDeplyPlanDate;
        private Framework.SmartControls.SmartLabel lblDeployNote;
        private Framework.SmartControls.SmartBandedGrid grdFileList;
        private Framework.SmartControls.SmartDateEdit dateDeployPlan;
        private Framework.SmartControls.SmartMemoEdit txtDeployNote;
        private Framework.SmartControls.SmartCheckEdit chkDeployDirect;
    }
}