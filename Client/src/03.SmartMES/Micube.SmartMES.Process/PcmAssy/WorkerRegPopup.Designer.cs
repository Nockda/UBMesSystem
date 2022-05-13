namespace Micube.SmartMES.Process
{
    partial class WorkerRegPopup
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
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnClose = new Micube.Framework.SmartControls.SmartButton();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.smartSplitTableLayoutPanel1 = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.smartGroupBox2 = new Micube.Framework.SmartControls.SmartGroupBox();
            this.smartSplitTableLayoutPanel2 = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.grdUser = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.ucDataLeftRightBtn = new Micube.SmartMES.Commons.Controls.ucDataLeftRightBtn();
            this.grdWorker = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdEquipment = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSplitTableLayoutPanel3 = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.txtSubProcessName = new Micube.Framework.SmartControls.SmartTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            this.smartSplitTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartGroupBox2)).BeginInit();
            this.smartGroupBox2.SuspendLayout();
            this.smartSplitTableLayoutPanel2.SuspendLayout();
            this.smartSplitTableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubProcessName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.smartSplitTableLayoutPanel1);
            this.pnlMain.Controls.Add(this.smartPanel2);
            this.pnlMain.Size = new System.Drawing.Size(764, 733);
            // 
            // smartPanel2
            // 
            this.smartPanel2.Controls.Add(this.btnClose);
            this.smartPanel2.Controls.Add(this.btnSave);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel2.Location = new System.Drawing.Point(0, 675);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(764, 58);
            this.smartPanel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.IsBusy = false;
            this.btnClose.IsWrite = false;
            this.btnClose.LanguageKey = "CLOSE";
            this.btnClose.Location = new System.Drawing.Point(617, 12);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnClose.Size = new System.Drawing.Size(133, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "닫기";
            this.btnClose.TooltipLanguageKey = "";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AllowFocus = false;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.IsBusy = false;
            this.btnSave.IsWrite = false;
            this.btnSave.LanguageKey = "SAVE";
            this.btnSave.Location = new System.Drawing.Point(478, 12);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(133, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "저장";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // smartSplitTableLayoutPanel1
            // 
            this.smartSplitTableLayoutPanel1.ColumnCount = 1;
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartGroupBox2, 0, 2);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.grdEquipment, 0, 1);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartSplitTableLayoutPanel3, 0, 0);
            this.smartSplitTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSplitTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartSplitTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSplitTableLayoutPanel1.Name = "smartSplitTableLayoutPanel1";
            this.smartSplitTableLayoutPanel1.RowCount = 3;
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44445F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55555F));
            this.smartSplitTableLayoutPanel1.Size = new System.Drawing.Size(764, 675);
            this.smartSplitTableLayoutPanel1.TabIndex = 2;
            // 
            // smartGroupBox2
            // 
            this.smartGroupBox2.Controls.Add(this.smartSplitTableLayoutPanel2);
            this.smartGroupBox2.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.smartGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartGroupBox2.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((Micube.Framework.SmartControls.GridButtonItem.Expand | Micube.Framework.SmartControls.GridButtonItem.Restore)));
            this.smartGroupBox2.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.smartGroupBox2.LanguageKey = "";
            this.smartGroupBox2.Location = new System.Drawing.Point(3, 320);
            this.smartGroupBox2.Name = "smartGroupBox2";
            this.smartGroupBox2.ShowBorder = true;
            this.smartGroupBox2.Size = new System.Drawing.Size(758, 352);
            this.smartGroupBox2.TabIndex = 1;
            // 
            // smartSplitTableLayoutPanel2
            // 
            this.smartSplitTableLayoutPanel2.ColumnCount = 3;
            this.smartSplitTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.smartSplitTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.smartSplitTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.smartSplitTableLayoutPanel2.Controls.Add(this.grdUser, 0, 0);
            this.smartSplitTableLayoutPanel2.Controls.Add(this.ucDataLeftRightBtn, 1, 0);
            this.smartSplitTableLayoutPanel2.Controls.Add(this.grdWorker, 2, 0);
            this.smartSplitTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSplitTableLayoutPanel2.Location = new System.Drawing.Point(2, 31);
            this.smartSplitTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSplitTableLayoutPanel2.Name = "smartSplitTableLayoutPanel2";
            this.smartSplitTableLayoutPanel2.RowCount = 1;
            this.smartSplitTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.smartSplitTableLayoutPanel2.Size = new System.Drawing.Size(754, 319);
            this.smartSplitTableLayoutPanel2.TabIndex = 0;
            // 
            // grdUser
            // 
            this.grdUser.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUser.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdUser.IsUsePaging = false;
            this.grdUser.LanguageKey = "GRIDUSERLIST";
            this.grdUser.Location = new System.Drawing.Point(0, 0);
            this.grdUser.Margin = new System.Windows.Forms.Padding(0);
            this.grdUser.Name = "grdUser";
            this.grdUser.ShowBorder = true;
            this.grdUser.Size = new System.Drawing.Size(347, 319);
            this.grdUser.TabIndex = 0;
            this.grdUser.UseAutoBestFitColumns = false;
            // 
            // ucDataLeftRightBtn
            // 
            this.ucDataLeftRightBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataLeftRightBtn.Location = new System.Drawing.Point(350, 5);
            this.ucDataLeftRightBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucDataLeftRightBtn.Name = "ucDataLeftRightBtn";
            this.ucDataLeftRightBtn.Size = new System.Drawing.Size(54, 309);
            this.ucDataLeftRightBtn.SourceGrid = null;
            this.ucDataLeftRightBtn.TabIndex = 2;
            this.ucDataLeftRightBtn.TargetGrid = null;
            // 
            // grdWorker
            // 
            this.grdWorker.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorker.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdWorker.IsUsePaging = false;
            this.grdWorker.LanguageKey = "GRIDWORKERLIST";
            this.grdWorker.Location = new System.Drawing.Point(407, 0);
            this.grdWorker.Margin = new System.Windows.Forms.Padding(0);
            this.grdWorker.Name = "grdWorker";
            this.grdWorker.ShowBorder = true;
            this.grdWorker.Size = new System.Drawing.Size(347, 319);
            this.grdWorker.TabIndex = 3;
            this.grdWorker.UseAutoBestFitColumns = false;
            // 
            // grdEquipment
            // 
            this.grdEquipment.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEquipment.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdEquipment.IsUsePaging = false;
            this.grdEquipment.LanguageKey = "MAINEQUIPMENTLIST";
            this.grdEquipment.Location = new System.Drawing.Point(0, 32);
            this.grdEquipment.Margin = new System.Windows.Forms.Padding(0);
            this.grdEquipment.Name = "grdEquipment";
            this.grdEquipment.ShowBorder = true;
            this.grdEquipment.Size = new System.Drawing.Size(764, 285);
            this.grdEquipment.TabIndex = 2;
            this.grdEquipment.UseAutoBestFitColumns = false;
            // 
            // smartSplitTableLayoutPanel3
            // 
            this.smartSplitTableLayoutPanel3.ColumnCount = 3;
            this.smartSplitTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.smartSplitTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.smartSplitTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.smartSplitTableLayoutPanel3.Controls.Add(this.smartLabel1, 0, 0);
            this.smartSplitTableLayoutPanel3.Controls.Add(this.txtSubProcessName, 1, 0);
            this.smartSplitTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSplitTableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.smartSplitTableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSplitTableLayoutPanel3.Name = "smartSplitTableLayoutPanel3";
            this.smartSplitTableLayoutPanel3.RowCount = 1;
            this.smartSplitTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.smartSplitTableLayoutPanel3.Size = new System.Drawing.Size(764, 32);
            this.smartSplitTableLayoutPanel3.TabIndex = 3;
            // 
            // smartLabel1
            // 
            this.smartLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.smartLabel1.Appearance.Options.UseFont = true;
            this.smartLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartLabel1.LanguageKey = "SUBPROCESSSEGMENTNAME";
            this.smartLabel1.Location = new System.Drawing.Point(3, 3);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.smartLabel1.Size = new System.Drawing.Size(94, 26);
            this.smartLabel1.TabIndex = 0;
            this.smartLabel1.Text = "세부공정명";
            // 
            // txtSubProcessName
            // 
            this.txtSubProcessName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSubProcessName.LabelText = null;
            this.txtSubProcessName.LanguageKey = null;
            this.txtSubProcessName.Location = new System.Drawing.Point(103, 3);
            this.txtSubProcessName.Name = "txtSubProcessName";
            this.txtSubProcessName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtSubProcessName.Properties.Appearance.Options.UseFont = true;
            this.txtSubProcessName.Properties.ReadOnly = true;
            this.txtSubProcessName.Properties.UseReadOnlyAppearance = false;
            this.txtSubProcessName.Size = new System.Drawing.Size(326, 24);
            this.txtSubProcessName.TabIndex = 1;
            // 
            // WorkerRegPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 753);
            this.LanguageKey = "WORKSTART";
            this.Name = "WorkerRegPopup";
            this.Text = "WorkerRegPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            this.smartSplitTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartGroupBox2)).EndInit();
            this.smartGroupBox2.ResumeLayout(false);
            this.smartSplitTableLayoutPanel2.ResumeLayout(false);
            this.smartSplitTableLayoutPanel3.ResumeLayout(false);
            this.smartSplitTableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubProcessName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartButton btnClose;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel1;
        private Framework.SmartControls.SmartGroupBox smartGroupBox2;
        private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel2;
        private Framework.SmartControls.SmartBandedGrid grdUser;
        private Commons.Controls.ucDataLeftRightBtn ucDataLeftRightBtn;
        private Framework.SmartControls.SmartBandedGrid grdWorker;
        private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel3;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartTextBox txtSubProcessName;
        private Framework.SmartControls.SmartBandedGrid grdEquipment;
    }
}