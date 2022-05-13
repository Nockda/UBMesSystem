namespace Micube.SmartMES.Commons.Controls
{
    partial class ReworkRoutingPop
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
            this.pnlTop = new Micube.Framework.SmartControls.SmartPanel();
            this.txtReworkName = new Micube.Framework.SmartControls.SmartTextBox();
            this.smartLabel2 = new Micube.Framework.SmartControls.SmartLabel();
            this.txtReworkNumber = new Micube.Framework.SmartControls.SmartTextBox();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.cboProcessClass = new Micube.Framework.SmartControls.SmartComboBox();
            this.lblProcessClass = new Micube.Framework.SmartControls.SmartLabel();
            this.lblProductDefName = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblProductDefID = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.pnlBottom = new Micube.Framework.SmartControls.SmartPanel();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.btnCancel = new Micube.Framework.SmartControls.SmartButton();
            this.smartSpliterContainer1 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdReworkRouting = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdReturnRouting = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.controlSpliter = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.grdReworkPath = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.tabRouting = new Micube.Framework.SmartControls.SmartTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.grdProductRouting = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReworkName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReworkNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProcessClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProductDefName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProductDefID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabRouting)).BeginInit();
            this.tabRouting.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabRouting);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Size = new System.Drawing.Size(1164, 654);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtReworkName);
            this.pnlTop.Controls.Add(this.smartLabel2);
            this.pnlTop.Controls.Add(this.txtReworkNumber);
            this.pnlTop.Controls.Add(this.smartLabel1);
            this.pnlTop.Controls.Add(this.cboProcessClass);
            this.pnlTop.Controls.Add(this.lblProcessClass);
            this.pnlTop.Controls.Add(this.lblProductDefName);
            this.pnlTop.Controls.Add(this.lblProductDefID);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1164, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // txtReworkName
            // 
            this.txtReworkName.LabelText = null;
            this.txtReworkName.LanguageKey = null;
            this.txtReworkName.Location = new System.Drawing.Point(620, 33);
            this.txtReworkName.Name = "txtReworkName";
            this.txtReworkName.Size = new System.Drawing.Size(90, 20);
            this.txtReworkName.TabIndex = 12;
            // 
            // smartLabel2
            // 
            this.smartLabel2.LanguageKey = "REWORKNAME";
            this.smartLabel2.Location = new System.Drawing.Point(558, 36);
            this.smartLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Size = new System.Drawing.Size(40, 14);
            this.smartLabel2.TabIndex = 10;
            this.smartLabel2.Text = "재작업명";
            // 
            // txtReworkNumber
            // 
            this.txtReworkNumber.LabelText = null;
            this.txtReworkNumber.LanguageKey = null;
            this.txtReworkNumber.Location = new System.Drawing.Point(423, 33);
            this.txtReworkNumber.Name = "txtReworkNumber";
            this.txtReworkNumber.Size = new System.Drawing.Size(112, 20);
            this.txtReworkNumber.TabIndex = 13;
            // 
            // smartLabel1
            // 
            this.smartLabel1.LanguageKey = "REWORKNUMBER";
            this.smartLabel1.Location = new System.Drawing.Point(318, 36);
            this.smartLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(50, 14);
            this.smartLabel1.TabIndex = 11;
            this.smartLabel1.Text = "재작업번호";
            // 
            // cboProcessClass
            // 
            this.cboProcessClass.LabelText = null;
            this.cboProcessClass.LanguageKey = null;
            this.cboProcessClass.Location = new System.Drawing.Point(99, 33);
            this.cboProcessClass.Name = "cboProcessClass";
            this.cboProcessClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProcessClass.Properties.NullText = "";
            this.cboProcessClass.ShowHeader = true;
            this.cboProcessClass.Size = new System.Drawing.Size(200, 20);
            this.cboProcessClass.TabIndex = 9;
            // 
            // lblProcessClass
            // 
            this.lblProcessClass.LanguageKey = "PROCESSDEFCLASS";
            this.lblProcessClass.Location = new System.Drawing.Point(10, 36);
            this.lblProcessClass.Margin = new System.Windows.Forms.Padding(0);
            this.lblProcessClass.Name = "lblProcessClass";
            this.lblProcessClass.Size = new System.Drawing.Size(54, 14);
            this.lblProcessClass.TabIndex = 8;
            this.lblProcessClass.Text = "라우팅 구분";
            // 
            // lblProductDefName
            // 
            this.lblProductDefName.Enabled = false;
            this.lblProductDefName.LabelText = "품목명";
            this.lblProductDefName.LabelWidth = "20%";
            this.lblProductDefName.LanguageKey = "PRODUCTDEFNAME";
            this.lblProductDefName.Location = new System.Drawing.Point(318, 7);
            this.lblProductDefName.Name = "lblProductDefName";
            this.lblProductDefName.Size = new System.Drawing.Size(392, 20);
            this.lblProductDefName.TabIndex = 1;
            // 
            // lblProductDefID
            // 
            this.lblProductDefID.Enabled = false;
            this.lblProductDefID.LabelText = "품목 코드";
            this.lblProductDefID.LabelWidth = "30%";
            this.lblProductDefID.LanguageKey = "PRODUCTDEFID";
            this.lblProductDefID.Location = new System.Drawing.Point(10, 7);
            this.lblProductDefID.Name = "lblProductDefID";
            this.lblProductDefID.Size = new System.Drawing.Size(247, 20);
            this.lblProductDefID.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 612);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1164, 42);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.AllowFocus = false;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.IsBusy = false;
            this.btnSave.IsWrite = false;
            this.btnSave.LanguageKey = "PopupSelect";
            this.btnSave.Location = new System.Drawing.Point(993, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "선 택";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.IsBusy = false;
            this.btnCancel.IsWrite = false;
            this.btnCancel.LanguageKey = "CANCEL";
            this.btnCancel.Location = new System.Drawing.Point(1079, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취 소";
            this.btnCancel.TooltipLanguageKey = "";
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(3, 3);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.grdReworkRouting);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.grdReturnRouting);
            this.smartSpliterContainer1.Panel2.Controls.Add(this.controlSpliter);
            this.smartSpliterContainer1.Panel2.Controls.Add(this.grdReworkPath);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(768, 293);
            this.smartSpliterContainer1.SplitterPosition = 681;
            this.smartSpliterContainer1.TabIndex = 2;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grdReworkRouting
            // 
            this.grdReworkRouting.Caption = "재작업 라우팅";
            this.grdReworkRouting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReworkRouting.IsUsePaging = false;
            this.grdReworkRouting.LanguageKey = "REWORKROUTING";
            this.grdReworkRouting.Location = new System.Drawing.Point(0, 0);
            this.grdReworkRouting.Margin = new System.Windows.Forms.Padding(0);
            this.grdReworkRouting.Name = "grdReworkRouting";
            this.grdReworkRouting.ShowBorder = true;
            this.grdReworkRouting.ShowStatusBar = false;
            this.grdReworkRouting.Size = new System.Drawing.Size(681, 293);
            this.grdReworkRouting.TabIndex = 7;
            // 
            // grdReturnRouting
            // 
            this.grdReturnRouting.Caption = "재작업 후 공정";
            this.grdReturnRouting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReturnRouting.IsUsePaging = false;
            this.grdReturnRouting.LanguageKey = "PROCESSAFTERREWORK";
            this.grdReturnRouting.Location = new System.Drawing.Point(0, 246);
            this.grdReturnRouting.Margin = new System.Windows.Forms.Padding(0);
            this.grdReturnRouting.Name = "grdReturnRouting";
            this.grdReturnRouting.ShowBorder = true;
            this.grdReturnRouting.ShowStatusBar = false;
            this.grdReturnRouting.Size = new System.Drawing.Size(82, 47);
            this.grdReturnRouting.TabIndex = 10;
            // 
            // controlSpliter
            // 
            this.controlSpliter.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlSpliter.Location = new System.Drawing.Point(0, 241);
            this.controlSpliter.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.controlSpliter.Name = "controlSpliter";
            this.controlSpliter.Size = new System.Drawing.Size(82, 5);
            this.controlSpliter.TabIndex = 9;
            this.controlSpliter.TabStop = false;
            // 
            // grdReworkPath
            // 
            this.grdReworkPath.Caption = "재작업 수순";
            this.grdReworkPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdReworkPath.IsUsePaging = false;
            this.grdReworkPath.LanguageKey = "REWORKPROCESS";
            this.grdReworkPath.Location = new System.Drawing.Point(0, 0);
            this.grdReworkPath.Margin = new System.Windows.Forms.Padding(0);
            this.grdReworkPath.Name = "grdReworkPath";
            this.grdReworkPath.ShowBorder = true;
            this.grdReworkPath.ShowStatusBar = false;
            this.grdReworkPath.Size = new System.Drawing.Size(82, 241);
            this.grdReworkPath.TabIndex = 8;
            // 
            // tabRouting
            // 
            this.tabRouting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRouting.Location = new System.Drawing.Point(0, 60);
            this.tabRouting.Name = "tabRouting";
            this.tabRouting.Padding = new System.Windows.Forms.Padding(3);
            this.tabRouting.SelectedTabPage = this.xtraTabPage1;
            this.tabRouting.Size = new System.Drawing.Size(1164, 552);
            this.tabRouting.TabIndex = 3;
            this.tabRouting.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.grdProductRouting);
            this.tabRouting.SetLanguageKey(this.xtraTabPage1, "PRODUCTROUTING");
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.xtraTabPage1.Size = new System.Drawing.Size(1158, 523);
            this.xtraTabPage1.Text = "품목 Routing";
            // 
            // grdProductRouting
            // 
            this.grdProductRouting.Caption = "";
            this.grdProductRouting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProductRouting.IsUsePaging = false;
            this.grdProductRouting.LanguageKey = "";
            this.grdProductRouting.Location = new System.Drawing.Point(3, 3);
            this.grdProductRouting.Margin = new System.Windows.Forms.Padding(0);
            this.grdProductRouting.Name = "grdProductRouting";
            this.grdProductRouting.ShowBorder = true;
            this.grdProductRouting.ShowStatusBar = false;
            this.grdProductRouting.Size = new System.Drawing.Size(1152, 517);
            this.grdProductRouting.TabIndex = 8;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.smartSpliterContainer1);
            this.tabRouting.SetLanguageKey(this.xtraTabPage2, "ReworkRouting");
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.xtraTabPage2.Size = new System.Drawing.Size(774, 299);
            this.xtraTabPage2.Text = "재작업 Routing";
            // 
            // ReworkRoutingPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 674);
            this.LanguageKey = "SELECTREWORKROUTING";
            this.Name = "ReworkRoutingPop";
            this.Text = "ReworkRoutingPop";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReworkName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReworkNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProcessClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProductDefName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProductDefID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabRouting)).EndInit();
            this.tabRouting.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartPanel pnlBottom;
        private Framework.SmartControls.SmartPanel pnlTop;
        private Framework.SmartControls.SmartBandedGrid grdReworkRouting;
        private Framework.SmartControls.SmartBandedGrid grdReworkPath;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartButton btnCancel;
        private Framework.SmartControls.SmartTabControl tabRouting;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private Framework.SmartControls.SmartBandedGrid grdProductRouting;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private Framework.SmartControls.SmartLabelTextBox lblProductDefName;
        private Framework.SmartControls.SmartLabelTextBox lblProductDefID;
        private Framework.SmartControls.SmartBandedGrid grdReturnRouting;
        private Framework.SmartControls.SmartSpliterControl controlSpliter;
        private Framework.SmartControls.SmartTextBox txtReworkName;
        private Framework.SmartControls.SmartLabel smartLabel2;
        private Framework.SmartControls.SmartTextBox txtReworkNumber;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartComboBox cboProcessClass;
        private Framework.SmartControls.SmartLabel lblProcessClass;
    }
}