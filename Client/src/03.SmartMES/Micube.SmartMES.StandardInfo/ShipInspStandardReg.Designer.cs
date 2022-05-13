namespace Micube.SmartMES.StandardInfo
{
    partial class ShipInspStandardReg
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
            this.smartSpliterContainer1 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdRevision = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSpliterContainer2 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdIsnpInfo = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.txtRef = new Micube.Framework.SmartControls.SmartRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).BeginInit();
            this.smartSpliterContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(371, 678);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(981, 30);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Size = new System.Drawing.Size(981, 681);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1362, 717);
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.grdRevision);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartSpliterContainer2);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(981, 681);
            this.smartSpliterContainer1.SplitterPosition = 578;
            this.smartSpliterContainer1.TabIndex = 0;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grdRevision
            // 
            this.grdRevision.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdRevision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRevision.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdRevision.IsUsePaging = false;
            this.grdRevision.LanguageKey = "REVISIONINFO";
            this.grdRevision.Location = new System.Drawing.Point(0, 0);
            this.grdRevision.Margin = new System.Windows.Forms.Padding(0);
            this.grdRevision.Name = "grdRevision";
            this.grdRevision.ShowBorder = true;
            this.grdRevision.Size = new System.Drawing.Size(578, 681);
            this.grdRevision.TabIndex = 0;
            this.grdRevision.UseAutoBestFitColumns = false;
            // 
            // smartSpliterContainer2
            // 
            this.smartSpliterContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer2.Horizontal = false;
            this.smartSpliterContainer2.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer2.Name = "smartSpliterContainer2";
            this.smartSpliterContainer2.Panel1.Controls.Add(this.grdIsnpInfo);
            this.smartSpliterContainer2.Panel1.Text = "Panel1";
            this.smartSpliterContainer2.Panel2.Controls.Add(this.smartPanel1);
            this.smartSpliterContainer2.Panel2.Text = "Panel2";
            this.smartSpliterContainer2.Size = new System.Drawing.Size(397, 681);
            this.smartSpliterContainer2.SplitterPosition = 622;
            this.smartSpliterContainer2.TabIndex = 0;
            this.smartSpliterContainer2.Text = "smartSpliterContainer2";
            // 
            // grdIsnpInfo
            // 
            this.grdIsnpInfo.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdIsnpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIsnpInfo.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdIsnpInfo.IsUsePaging = false;
            this.grdIsnpInfo.LanguageKey = "INSPECTIONSTANDARDLIST";
            this.grdIsnpInfo.Location = new System.Drawing.Point(0, 0);
            this.grdIsnpInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grdIsnpInfo.Name = "grdIsnpInfo";
            this.grdIsnpInfo.ShowBorder = true;
            this.grdIsnpInfo.ShowStatusBar = false;
            this.grdIsnpInfo.Size = new System.Drawing.Size(397, 622);
            this.grdIsnpInfo.TabIndex = 1;
            this.grdIsnpInfo.UseAutoBestFitColumns = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.Appearance.BackColor = System.Drawing.Color.White;
            this.smartPanel1.Appearance.Options.UseBackColor = true;
            this.smartPanel1.Controls.Add(this.txtRef);
            this.smartPanel1.Controls.Add(this.smartLabel1);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(397, 53);
            this.smartPanel1.TabIndex = 0;
            // 
            // smartLabel1
            // 
            this.smartLabel1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.smartLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel1.Appearance.Options.UseBackColor = true;
            this.smartLabel1.Appearance.Options.UseFont = true;
            this.smartLabel1.Appearance.Options.UseTextOptions = true;
            this.smartLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.smartLabel1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.smartLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.smartLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.smartLabel1.Location = new System.Drawing.Point(2, 2);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(76, 49);
            this.smartLabel1.TabIndex = 0;
            this.smartLabel1.Text = "참조";
            // 
            // txtRef
            // 
            this.txtRef.AlignCenterVisible = false;
            this.txtRef.AlignLeftVisible = false;
            this.txtRef.AlignRightVisible = false;
            this.txtRef.BoldVisible = false;
            this.txtRef.BulletsVisible = false;
            this.txtRef.ChooseFontVisible = false;
            this.txtRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRef.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRef.FontColorVisible = false;
            this.txtRef.FontFamilyVisible = false;
            this.txtRef.FontSizeVisible = false;
            this.txtRef.INDENT = 10;
            this.txtRef.ItalicVisible = false;
            this.txtRef.Location = new System.Drawing.Point(78, 2);
            this.txtRef.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtRef.Name = "txtRef";
            this.txtRef.Rtf = "{\\rtf1\\ansi\\ansicpg949\\deff0\\deflang1033\\deflangfe1042{\\fonttbl{\\f0\\fnil\\fcharset" +
    "204 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\lang1042\\f0\\fs18\\par\r\n}\r\n";
            this.txtRef.SeparatorAlignVisible = false;
            this.txtRef.SeparatorBoldUnderlineItalicVisible = false;
            this.txtRef.SeparatorFontColorVisible = false;
            this.txtRef.SeparatorFontVisible = false;
            this.txtRef.Size = new System.Drawing.Size(317, 49);
            this.txtRef.TabIndex = 1;
            this.txtRef.ToolStripVisible = false;
            this.txtRef.UnderlineVisible = false;
            this.txtRef.WordWrapVisible = false;
            // 
            // ShipInspStandardReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 755);
            this.Name = "ShipInspStandardReg";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "SmartConditionBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).EndInit();
            this.smartSpliterContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartBandedGrid grdRevision;
        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer2;
        private Framework.SmartControls.SmartBandedGrid grdIsnpInfo;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartRichTextBox txtRef;
    }
}