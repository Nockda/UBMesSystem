namespace Micube.SmartMES.Commons
{
    partial class SendInspectionMailPopup
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
            this.gbxUserList = new Micube.Framework.SmartControls.SmartGroupBox();
            this.grdUserList = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new Micube.Framework.SmartControls.SmartButton();
            this.btnAdd = new Micube.Framework.SmartControls.SmartButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new Micube.Framework.SmartControls.SmartButton();
            this.btnSend = new Micube.Framework.SmartControls.SmartButton();
            this.grpContents = new Micube.Framework.SmartControls.SmartGroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.memoCustom = new Micube.Framework.SmartControls.SmartMemoEdit();
            this.memoInfo = new Micube.Framework.SmartControls.SmartMemoEdit();
            this.txtTitle = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblInfo = new Micube.Framework.SmartControls.SmartLabel();
            this.lblDescription = new Micube.Framework.SmartControls.SmartLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.smartSplitTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxUserList)).BeginInit();
            this.gbxUserList.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpContents)).BeginInit();
            this.grpContents.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoCustom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.smartSplitTableLayoutPanel1);
            this.pnlMain.Size = new System.Drawing.Size(530, 545);
            // 
            // smartSplitTableLayoutPanel1
            // 
            this.smartSplitTableLayoutPanel1.ColumnCount = 2;
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.smartSplitTableLayoutPanel1.Controls.Add(this.gbxUserList, 0, 1);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartSpliterControl1, 0, 2);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 5);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.grpContents, 0, 3);
            this.smartSplitTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSplitTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartSplitTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSplitTableLayoutPanel1.Name = "smartSplitTableLayoutPanel1";
            this.smartSplitTableLayoutPanel1.RowCount = 6;
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.smartSplitTableLayoutPanel1.Size = new System.Drawing.Size(530, 545);
            this.smartSplitTableLayoutPanel1.TabIndex = 0;
            // 
            // gbxUserList
            // 
            this.smartSplitTableLayoutPanel1.SetColumnSpan(this.gbxUserList, 2);
            this.gbxUserList.Controls.Add(this.grdUserList);
            this.gbxUserList.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.gbxUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxUserList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((Micube.Framework.SmartControls.GridButtonItem.Expand | Micube.Framework.SmartControls.GridButtonItem.Restore)));
            this.gbxUserList.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.gbxUserList.LanguageKey = "RECEIVERLIST";
            this.gbxUserList.Location = new System.Drawing.Point(0, 30);
            this.gbxUserList.Margin = new System.Windows.Forms.Padding(0);
            this.gbxUserList.Name = "gbxUserList";
            this.gbxUserList.ShowBorder = true;
            this.gbxUserList.Size = new System.Drawing.Size(530, 178);
            this.gbxUserList.TabIndex = 0;
            this.gbxUserList.Text = "수신자 리스트";
            // 
            // grdUserList
            // 
            this.grdUserList.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdUserList.IsUsePaging = false;
            this.grdUserList.LanguageKey = null;
            this.grdUserList.Location = new System.Drawing.Point(2, 31);
            this.grdUserList.Margin = new System.Windows.Forms.Padding(0);
            this.grdUserList.Name = "grdUserList";
            this.grdUserList.ShowBorder = false;
            this.grdUserList.ShowButtonBar = false;
            this.grdUserList.Size = new System.Drawing.Size(526, 145);
            this.grdUserList.TabIndex = 0;
            // 
            // smartSpliterControl1
            // 
            this.smartSplitTableLayoutPanel1.SetColumnSpan(this.smartSpliterControl1, 2);
            this.smartSpliterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartSpliterControl1.Location = new System.Drawing.Point(0, 208);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(530, 5);
            this.smartSpliterControl1.TabIndex = 2;
            this.smartSpliterControl1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(265, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(265, 30);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.AllowFocus = false;
            this.btnDelete.IsBusy = false;
            this.btnDelete.IsWrite = false;
            this.btnDelete.Location = new System.Drawing.Point(185, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnDelete.Size = new System.Drawing.Size(80, 25);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "삭제";
            this.btnDelete.TooltipLanguageKey = "";
            // 
            // btnAdd
            // 
            this.btnAdd.AllowFocus = false;
            this.btnAdd.IsBusy = false;
            this.btnAdd.IsWrite = false;
            this.btnAdd.Location = new System.Drawing.Point(99, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnAdd.Size = new System.Drawing.Size(80, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "추가";
            this.btnAdd.TooltipLanguageKey = "";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSend);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(265, 515);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(265, 30);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.IsBusy = false;
            this.btnClose.IsWrite = false;
            this.btnClose.Location = new System.Drawing.Point(185, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            this.btnClose.TooltipLanguageKey = "";
            // 
            // btnSend
            // 
            this.btnSend.AllowFocus = false;
            this.btnSend.IsBusy = false;
            this.btnSend.IsWrite = false;
            this.btnSend.Location = new System.Drawing.Point(99, 5);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSend.Size = new System.Drawing.Size(80, 25);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "보내기";
            this.btnSend.TooltipLanguageKey = "";
            // 
            // grpContents
            // 
            this.smartSplitTableLayoutPanel1.SetColumnSpan(this.grpContents, 2);
            this.grpContents.Controls.Add(this.tableLayoutPanel1);
            this.grpContents.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.grpContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpContents.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((Micube.Framework.SmartControls.GridButtonItem.Expand | Micube.Framework.SmartControls.GridButtonItem.Restore)));
            this.grpContents.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.grpContents.LanguageKey = "COMMENTS";
            this.grpContents.Location = new System.Drawing.Point(0, 218);
            this.grpContents.Margin = new System.Windows.Forms.Padding(0);
            this.grpContents.Name = "grpContents";
            this.smartSplitTableLayoutPanel1.SetRowSpan(this.grpContents, 2);
            this.grpContents.ShowBorder = true;
            this.grpContents.Size = new System.Drawing.Size(530, 297);
            this.grpContents.TabIndex = 6;
            this.grpContents.Text = "smartGroupBox1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.memoCustom, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.memoInfo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDescription, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 31);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(526, 264);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // memoCustom
            // 
            this.memoCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoCustom.Location = new System.Drawing.Point(0, 170);
            this.memoCustom.Margin = new System.Windows.Forms.Padding(0);
            this.memoCustom.Name = "memoCustom";
            this.memoCustom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoCustom.Size = new System.Drawing.Size(526, 94);
            this.memoCustom.TabIndex = 2;
            // 
            // memoInfo
            // 
            this.memoInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoInfo.Location = new System.Drawing.Point(0, 52);
            this.memoInfo.Margin = new System.Windows.Forms.Padding(0);
            this.memoInfo.Name = "memoInfo";
            this.memoInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoInfo.Properties.ReadOnly = true;
            this.memoInfo.Properties.UseReadOnlyAppearance = false;
            this.memoInfo.Size = new System.Drawing.Size(526, 92);
            this.memoInfo.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.AutoHeight = false;
            this.tableLayoutPanel1.SetColumnSpan(this.txtTitle, 2);
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTitle.LabelText = "제목 :";
            this.txtTitle.LabelWidth = "10%";
            this.txtTitle.LanguageKey = "TITLE";
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Properties.AutoHeight = false;
            this.txtTitle.Size = new System.Drawing.Size(524, 26);
            this.txtTitle.TabIndex = 6;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.LanguageKey = "ABNORMALINFO";
            this.lblInfo.Location = new System.Drawing.Point(0, 26);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(526, 26);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "smartLabel1";
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.LanguageKey = "REMARK";
            this.lblDescription.Location = new System.Drawing.Point(0, 144);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(526, 26);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "smartLabel2";
            // 
            // SendInspectionMailPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 565);
            this.Name = "SendInspectionMailPopup";
            this.Text = "MailPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.smartSplitTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxUserList)).EndInit();
            this.gbxUserList.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpContents)).EndInit();
            this.grpContents.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoCustom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel1;
        private Framework.SmartControls.SmartGroupBox gbxUserList;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
        private Framework.SmartControls.SmartBandedGrid grdUserList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Framework.SmartControls.SmartButton btnDelete;
        private Framework.SmartControls.SmartButton btnAdd;
        private Framework.SmartControls.SmartButton btnClose;
        private Framework.SmartControls.SmartButton btnSend;
        private Framework.SmartControls.SmartGroupBox grpContents;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Framework.SmartControls.SmartLabelTextBox txtTitle;
        private Framework.SmartControls.SmartMemoEdit memoCustom;
        private Framework.SmartControls.SmartMemoEdit memoInfo;
        private Framework.SmartControls.SmartLabel lblInfo;
        private Framework.SmartControls.SmartLabel lblDescription;
    }
}