namespace Micube.SmartMES.Equipment
{
    partial class EquipDailyCheck
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
            this.grdInfo = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.lblEquipLegend = new Micube.Framework.SmartControls.SmartLabel();
            this.lblEquipmentGroup = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblEquipment = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.grdDetail = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartButton1 = new Micube.Framework.SmartControls.SmartButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEquipmentGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEquipment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(371, 557);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(986, 30);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Size = new System.Drawing.Size(986, 560);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1367, 596);
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Horizontal = false;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.grdInfo);
            this.smartSpliterContainer1.Panel1.Controls.Add(this.smartPanel1);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.grdDetail);
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartPanel2);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(986, 560);
            this.smartSpliterContainer1.SplitterPosition = 396;
            this.smartSpliterContainer1.TabIndex = 0;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grdInfo
            // 
            this.grdInfo.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInfo.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdInfo.IsUsePaging = false;
            this.grdInfo.LanguageKey = "EQUIPMENTCHECKINFO";
            this.grdInfo.Location = new System.Drawing.Point(0, 27);
            this.grdInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grdInfo.Name = "grdInfo";
            this.grdInfo.ShowBorder = true;
            this.grdInfo.Size = new System.Drawing.Size(986, 369);
            this.grdInfo.TabIndex = 1;
            this.grdInfo.UseAutoBestFitColumns = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel1.Controls.Add(this.smartButton1);
            this.smartPanel1.Controls.Add(this.lblEquipLegend);
            this.smartPanel1.Controls.Add(this.lblEquipmentGroup);
            this.smartPanel1.Controls.Add(this.lblEquipment);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(986, 27);
            this.smartPanel1.TabIndex = 0;
            // 
            // lblEquipLegend
            // 
            this.lblEquipLegend.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblEquipLegend.LanguageKey = "EQUIPCHECKLEGEND";
            this.lblEquipLegend.Location = new System.Drawing.Point(845, 0);
            this.lblEquipLegend.Name = "lblEquipLegend";
            this.lblEquipLegend.Size = new System.Drawing.Size(141, 18);
            this.lblEquipLegend.TabIndex = 2;
            this.lblEquipLegend.Text = "EQUIPCHECKLEGEND";
            // 
            // lblEquipmentGroup
            // 
            this.lblEquipmentGroup.LabelText = "EQUIPMENTGROUP";
            this.lblEquipmentGroup.LanguageKey = "EQUIPMENTCLASSID";
            this.lblEquipmentGroup.Location = new System.Drawing.Point(314, 0);
            this.lblEquipmentGroup.Name = "lblEquipmentGroup";
            this.lblEquipmentGroup.Size = new System.Drawing.Size(291, 24);
            this.lblEquipmentGroup.TabIndex = 1;
            // 
            // lblEquipment
            // 
            this.lblEquipment.LabelText = "EQUIPMENTNAME";
            this.lblEquipment.LanguageKey = "EQUIPMENTNAME";
            this.lblEquipment.Location = new System.Drawing.Point(0, 0);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(291, 24);
            this.lblEquipment.TabIndex = 0;
            // 
            // grdDetail
            // 
            this.grdDetail.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdDetail.IsUsePaging = false;
            this.grdDetail.LanguageKey = "ISSUERESULTINFO";
            this.grdDetail.Location = new System.Drawing.Point(0, 24);
            this.grdDetail.Margin = new System.Windows.Forms.Padding(0);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ShowBorder = true;
            this.grdDetail.Size = new System.Drawing.Size(986, 134);
            this.grdDetail.TabIndex = 2;
            this.grdDetail.UseAutoBestFitColumns = false;
            // 
            // smartPanel2
            // 
            this.smartPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 0);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(986, 24);
            this.smartPanel2.TabIndex = 1;
            // 
            // smartButton1
            // 
            this.smartButton1.AllowFocus = false;
            this.smartButton1.IsBusy = false;
            this.smartButton1.IsWrite = false;
            this.smartButton1.Location = new System.Drawing.Point(902, 22);
            this.smartButton1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.smartButton1.Name = "smartButton1";
            this.smartButton1.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton1.Size = new System.Drawing.Size(80, 25);
            this.smartButton1.TabIndex = 3;
            this.smartButton1.Text = "smartButton1";
            this.smartButton1.TooltipLanguageKey = "";
            // 
            // EquipDailyCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 634);
            this.Name = "EquipDailyCheck";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "EquipDailyCheck";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            this.smartPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEquipmentGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEquipment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartBandedGrid grdInfo;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartBandedGrid grdDetail;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartLabelTextBox lblEquipment;
        private Framework.SmartControls.SmartLabelTextBox lblEquipmentGroup;
        private Framework.SmartControls.SmartLabel lblEquipLegend;
        private Framework.SmartControls.SmartButton smartButton1;
    }
}