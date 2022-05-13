namespace Micube.SmartMES.Quality
{
    partial class XManageReg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XManageReg));
            this.grdXmanage = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.tabXmanage = new Micube.Framework.SmartControls.SmartTabControl();
            this.actionStatus = new DevExpress.XtraTab.XtraTabPage();
            this.tplXmanage = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.txtStateDesc = new Micube.Framework.SmartControls.SmartMemoEdit();
            this.smartLabel2 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.txtResponseDesc = new Micube.Framework.SmartControls.SmartMemoEdit();
            this.detShipmentDate = new Micube.Framework.SmartControls.SmartDateEdit();
            this.lblShipmentDate = new Micube.Framework.SmartControls.SmartLabel();
            this.lblOrderNumber = new Micube.Framework.SmartControls.SmartLabel();
            this.lblRequestDate = new Micube.Framework.SmartControls.SmartLabel();
            this.lblProgressDesc = new Micube.Framework.SmartControls.SmartLabel();
            this.lblPublishDate = new Micube.Framework.SmartControls.SmartLabel();
            this.lblCompleteDate = new Micube.Framework.SmartControls.SmartLabel();
            this.txtOrderNumber = new Micube.Framework.SmartControls.SmartTextBox();
            this.txtPublishDate = new Micube.Framework.SmartControls.SmartTextBox();
            this.txtCompleteDate = new Micube.Framework.SmartControls.SmartTextBox();
            this.txtOccurDate = new Micube.Framework.SmartControls.SmartTextBox();
            this.txtProgressDesc = new Micube.Framework.SmartControls.SmartMemoEdit();
            this.fileInfo = new DevExpress.XtraTab.XtraTabPage();
            this.fileControl = new Micube.SmartMES.Quality.ucFileControl();
            this.splXmanage = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.pnlInfo = new Micube.Framework.SmartControls.SmartPanel();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.pnlStateInfo = new Micube.Framework.SmartControls.SmartPanel();
            this.txtWorking = new Micube.Framework.SmartControls.SmartTextBox();
            this.txtRequest = new Micube.Framework.SmartControls.SmartTextBox();
            this.lblWorking = new Micube.Framework.SmartControls.SmartLabel();
            this.lblRequest = new Micube.Framework.SmartControls.SmartLabel();
            this.lblState = new Micube.Framework.SmartControls.SmartLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabXmanage)).BeginInit();
            this.tabXmanage.SuspendLayout();
            this.actionStatus.SuspendLayout();
            this.tplXmanage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStateDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResponseDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detShipmentDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detShipmentDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPublishDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompleteDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOccurDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgressDesc.Properties)).BeginInit();
            this.fileInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).BeginInit();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlStateInfo)).BeginInit();
            this.pnlStateInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorking.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequest.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(371, 552);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(760, 30);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.grdXmanage);
            this.pnlContent.Controls.Add(this.splXmanage);
            this.pnlContent.Controls.Add(this.pnlInfo);
            this.pnlContent.Size = new System.Drawing.Size(760, 555);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1141, 591);
            // 
            // grdXmanage
            // 
            this.grdXmanage.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdXmanage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdXmanage.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdXmanage.IsUsePaging = false;
            this.grdXmanage.LanguageKey = "XMANAGELIST";
            this.grdXmanage.Location = new System.Drawing.Point(0, 0);
            this.grdXmanage.Margin = new System.Windows.Forms.Padding(0);
            this.grdXmanage.Name = "grdXmanage";
            this.grdXmanage.ShowBorder = true;
            this.grdXmanage.Size = new System.Drawing.Size(760, 249);
            this.grdXmanage.TabIndex = 0;
            this.grdXmanage.UseAutoBestFitColumns = false;
            this.grdXmanage.Load += new System.EventHandler(this.grdXmanage_Load);
            // 
            // tabXmanage
            // 
            this.tabXmanage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabXmanage.Location = new System.Drawing.Point(0, 0);
            this.tabXmanage.Name = "tabXmanage";
            this.tabXmanage.SelectedTabPage = this.actionStatus;
            this.tabXmanage.Size = new System.Drawing.Size(504, 300);
            this.tabXmanage.TabIndex = 1;
            this.tabXmanage.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.actionStatus,
            this.fileInfo});
            // 
            // actionStatus
            // 
            this.actionStatus.Controls.Add(this.tplXmanage);
            this.actionStatus.Name = "actionStatus";
            this.actionStatus.Size = new System.Drawing.Size(497, 264);
            this.actionStatus.Text = "조치 현황";
            // 
            // tplXmanage
            // 
            this.tplXmanage.ColumnCount = 13;
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.980148F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.159435F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.980147F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.159435F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.383034F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.261956F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.261956F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.383033F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.261956F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.261956F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.383033F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.261956F));
            this.tplXmanage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.261956F));
            this.tplXmanage.Controls.Add(this.txtStateDesc, 5, 0);
            this.tplXmanage.Controls.Add(this.smartLabel2, 4, 0);
            this.tplXmanage.Controls.Add(this.smartLabel1, 7, 0);
            this.tplXmanage.Controls.Add(this.txtResponseDesc, 8, 0);
            this.tplXmanage.Controls.Add(this.detShipmentDate, 1, 2);
            this.tplXmanage.Controls.Add(this.lblShipmentDate, 0, 2);
            this.tplXmanage.Controls.Add(this.lblOrderNumber, 0, 0);
            this.tplXmanage.Controls.Add(this.lblRequestDate, 2, 0);
            this.tplXmanage.Controls.Add(this.lblProgressDesc, 10, 0);
            this.tplXmanage.Controls.Add(this.lblPublishDate, 0, 1);
            this.tplXmanage.Controls.Add(this.lblCompleteDate, 2, 1);
            this.tplXmanage.Controls.Add(this.txtOrderNumber, 1, 0);
            this.tplXmanage.Controls.Add(this.txtPublishDate, 1, 1);
            this.tplXmanage.Controls.Add(this.txtCompleteDate, 3, 1);
            this.tplXmanage.Controls.Add(this.txtOccurDate, 3, 0);
            this.tplXmanage.Controls.Add(this.txtProgressDesc, 11, 0);
            this.tplXmanage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplXmanage.Location = new System.Drawing.Point(0, 0);
            this.tplXmanage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tplXmanage.Name = "tplXmanage";
            this.tplXmanage.Padding = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.tplXmanage.RowCount = 4;
            this.tplXmanage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplXmanage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplXmanage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplXmanage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplXmanage.Size = new System.Drawing.Size(497, 264);
            this.tplXmanage.TabIndex = 0;
            // 
            // txtStateDesc
            // 
            this.tplXmanage.SetColumnSpan(this.txtStateDesc, 2);
            this.txtStateDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStateDesc.Location = new System.Drawing.Point(163, 13);
            this.txtStateDesc.Name = "txtStateDesc";
            this.tplXmanage.SetRowSpan(this.txtStateDesc, 4);
            this.txtStateDesc.Size = new System.Drawing.Size(84, 248);
            this.txtStateDesc.TabIndex = 20;
            // 
            // smartLabel2
            // 
            this.smartLabel2.Appearance.Options.UseTextOptions = true;
            this.smartLabel2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.smartLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.smartLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartLabel2.LanguageKey = "STATEDESC";
            this.smartLabel2.Location = new System.Drawing.Point(137, 13);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Size = new System.Drawing.Size(20, 24);
            this.smartLabel2.TabIndex = 24;
            this.smartLabel2.Text = "현상";
            // 
            // smartLabel1
            // 
            this.smartLabel1.Appearance.Options.UseTextOptions = true;
            this.smartLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.smartLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.smartLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartLabel1.LanguageKey = "RESPONSEDESC";
            this.smartLabel1.Location = new System.Drawing.Point(253, 13);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(20, 24);
            this.smartLabel1.TabIndex = 23;
            this.smartLabel1.Text = "대응";
            // 
            // txtResponseDesc
            // 
            this.tplXmanage.SetColumnSpan(this.txtResponseDesc, 2);
            this.txtResponseDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponseDesc.Location = new System.Drawing.Point(279, 13);
            this.txtResponseDesc.Name = "txtResponseDesc";
            this.tplXmanage.SetRowSpan(this.txtResponseDesc, 4);
            this.txtResponseDesc.Size = new System.Drawing.Size(84, 248);
            this.txtResponseDesc.TabIndex = 21;
            // 
            // detShipmentDate
            // 
            this.detShipmentDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detShipmentDate.EditValue = null;
            this.detShipmentDate.LabelText = null;
            this.detShipmentDate.LanguageKey = null;
            this.detShipmentDate.Location = new System.Drawing.Point(36, 73);
            this.detShipmentDate.Name = "detShipmentDate";
            this.detShipmentDate.Properties.AutoHeight = false;
            this.detShipmentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detShipmentDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detShipmentDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.detShipmentDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.detShipmentDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.detShipmentDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.detShipmentDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.detShipmentDate.Properties.XlsxFormatString = "yyyy-MM-dd";
            this.detShipmentDate.Size = new System.Drawing.Size(28, 24);
            this.detShipmentDate.TabIndex = 17;
            // 
            // lblShipmentDate
            // 
            this.lblShipmentDate.Appearance.Options.UseTextOptions = true;
            this.lblShipmentDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblShipmentDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblShipmentDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShipmentDate.LanguageKey = "SHIPMENTDATE";
            this.lblShipmentDate.Location = new System.Drawing.Point(3, 73);
            this.lblShipmentDate.Name = "lblShipmentDate";
            this.lblShipmentDate.Size = new System.Drawing.Size(27, 24);
            this.lblShipmentDate.TabIndex = 19;
            this.lblShipmentDate.Text = "출하일자";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Appearance.Options.UseTextOptions = true;
            this.lblOrderNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblOrderNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblOrderNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderNumber.LanguageKey = "ORDERNUMBER";
            this.lblOrderNumber.Location = new System.Drawing.Point(3, 13);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(27, 24);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "작업지시번호";
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.Appearance.Options.UseTextOptions = true;
            this.lblRequestDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblRequestDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRequestDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRequestDate.LanguageKey = "REQUESTDATE";
            this.lblRequestDate.Location = new System.Drawing.Point(70, 13);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(27, 24);
            this.lblRequestDate.TabIndex = 1;
            this.lblRequestDate.Text = "의뢰서발행일";
            // 
            // lblProgressDesc
            // 
            this.lblProgressDesc.Appearance.Options.UseTextOptions = true;
            this.lblProgressDesc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblProgressDesc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProgressDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgressDesc.LanguageKey = "REMARK";
            this.lblProgressDesc.Location = new System.Drawing.Point(369, 13);
            this.lblProgressDesc.Name = "lblProgressDesc";
            this.lblProgressDesc.Size = new System.Drawing.Size(20, 24);
            this.lblProgressDesc.TabIndex = 2;
            this.lblProgressDesc.Text = "비고";
            // 
            // lblPublishDate
            // 
            this.lblPublishDate.Appearance.Options.UseTextOptions = true;
            this.lblPublishDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPublishDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPublishDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPublishDate.LanguageKey = "PUBLISHDATE";
            this.lblPublishDate.Location = new System.Drawing.Point(3, 43);
            this.lblPublishDate.Name = "lblPublishDate";
            this.lblPublishDate.Size = new System.Drawing.Size(27, 24);
            this.lblPublishDate.TabIndex = 3;
            this.lblPublishDate.Text = "발행일자";
            // 
            // lblCompleteDate
            // 
            this.lblCompleteDate.Appearance.Options.UseTextOptions = true;
            this.lblCompleteDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblCompleteDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCompleteDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompleteDate.LanguageKey = "COMPLETEDATE2";
            this.lblCompleteDate.Location = new System.Drawing.Point(70, 43);
            this.lblCompleteDate.Name = "lblCompleteDate";
            this.lblCompleteDate.Size = new System.Drawing.Size(27, 24);
            this.lblCompleteDate.TabIndex = 4;
            this.lblCompleteDate.Text = "완료일자";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrderNumber.LabelText = null;
            this.txtOrderNumber.LanguageKey = null;
            this.txtOrderNumber.Location = new System.Drawing.Point(36, 13);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Properties.AutoHeight = false;
            this.txtOrderNumber.Size = new System.Drawing.Size(28, 24);
            this.txtOrderNumber.TabIndex = 10;
            // 
            // txtPublishDate
            // 
            this.txtPublishDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPublishDate.LabelText = null;
            this.txtPublishDate.LanguageKey = null;
            this.txtPublishDate.Location = new System.Drawing.Point(36, 43);
            this.txtPublishDate.Name = "txtPublishDate";
            this.txtPublishDate.Properties.AutoHeight = false;
            this.txtPublishDate.Size = new System.Drawing.Size(28, 24);
            this.txtPublishDate.TabIndex = 16;
            // 
            // txtCompleteDate
            // 
            this.txtCompleteDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCompleteDate.LabelText = null;
            this.txtCompleteDate.LanguageKey = null;
            this.txtCompleteDate.Location = new System.Drawing.Point(103, 43);
            this.txtCompleteDate.Name = "txtCompleteDate";
            this.txtCompleteDate.Properties.AutoHeight = false;
            this.txtCompleteDate.Size = new System.Drawing.Size(28, 24);
            this.txtCompleteDate.TabIndex = 19;
            // 
            // txtOccurDate
            // 
            this.txtOccurDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOccurDate.LabelText = null;
            this.txtOccurDate.LanguageKey = null;
            this.txtOccurDate.Location = new System.Drawing.Point(103, 13);
            this.txtOccurDate.Name = "txtOccurDate";
            this.txtOccurDate.Size = new System.Drawing.Size(28, 24);
            this.txtOccurDate.TabIndex = 18;
            // 
            // txtProgressDesc
            // 
            this.tplXmanage.SetColumnSpan(this.txtProgressDesc, 2);
            this.txtProgressDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProgressDesc.Location = new System.Drawing.Point(395, 13);
            this.txtProgressDesc.Name = "txtProgressDesc";
            this.tplXmanage.SetRowSpan(this.txtProgressDesc, 4);
            this.txtProgressDesc.Size = new System.Drawing.Size(89, 248);
            this.txtProgressDesc.TabIndex = 22;
            // 
            // fileInfo
            // 
            this.fileInfo.Controls.Add(this.fileControl);
            this.fileInfo.Name = "fileInfo";
            this.fileInfo.Size = new System.Drawing.Size(568, 264);
            this.fileInfo.Text = "파일 등록 정보";
            // 
            // fileControl
            // 
            this.fileControl.docId = "";
            this.fileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileControl.Location = new System.Drawing.Point(0, 0);
            this.fileControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileControl.Name = "fileControl";
            this.fileControl.Padding = new System.Windows.Forms.Padding(10);
            this.fileControl.Size = new System.Drawing.Size(568, 264);
            this.fileControl.TabIndex = 0;
            // 
            // splXmanage
            // 
            this.splXmanage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splXmanage.Location = new System.Drawing.Point(0, 249);
            this.splXmanage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.splXmanage.Name = "splXmanage";
            this.splXmanage.Size = new System.Drawing.Size(760, 6);
            this.splXmanage.TabIndex = 2;
            this.splXmanage.TabStop = false;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlInfo.Controls.Add(this.tabXmanage);
            this.pnlInfo.Controls.Add(this.smartSpliterControl1);
            this.pnlInfo.Controls.Add(this.pnlStateInfo);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfo.Location = new System.Drawing.Point(0, 255);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(760, 300);
            this.pnlInfo.TabIndex = 3;
            // 
            // smartSpliterControl1
            // 
            this.smartSpliterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartSpliterControl1.Location = new System.Drawing.Point(504, 0);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(6, 300);
            this.smartSpliterControl1.TabIndex = 3;
            this.smartSpliterControl1.TabStop = false;
            // 
            // pnlStateInfo
            // 
            this.pnlStateInfo.Controls.Add(this.txtWorking);
            this.pnlStateInfo.Controls.Add(this.txtRequest);
            this.pnlStateInfo.Controls.Add(this.lblWorking);
            this.pnlStateInfo.Controls.Add(this.lblRequest);
            this.pnlStateInfo.Controls.Add(this.lblState);
            this.pnlStateInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlStateInfo.Location = new System.Drawing.Point(510, 0);
            this.pnlStateInfo.Name = "pnlStateInfo";
            this.pnlStateInfo.Size = new System.Drawing.Size(250, 300);
            this.pnlStateInfo.TabIndex = 2;
            // 
            // txtWorking
            // 
            this.txtWorking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorking.LabelText = null;
            this.txtWorking.LanguageKey = null;
            this.txtWorking.Location = new System.Drawing.Point(135, 102);
            this.txtWorking.Name = "txtWorking";
            this.txtWorking.Properties.Appearance.BackColor = System.Drawing.Color.Moccasin;
            this.txtWorking.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtWorking.Properties.Appearance.Options.UseBackColor = true;
            this.txtWorking.Properties.Appearance.Options.UseFont = true;
            this.txtWorking.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWorking.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtWorking.Properties.AutoHeight = false;
            this.txtWorking.Properties.ReadOnly = true;
            this.txtWorking.Size = new System.Drawing.Size(90, 40);
            this.txtWorking.TabIndex = 4;
            // 
            // txtRequest
            // 
            this.txtRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequest.LabelText = null;
            this.txtRequest.LanguageKey = null;
            this.txtRequest.Location = new System.Drawing.Point(135, 56);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Properties.Appearance.BackColor = System.Drawing.Color.Moccasin;
            this.txtRequest.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtRequest.Properties.Appearance.Options.UseBackColor = true;
            this.txtRequest.Properties.Appearance.Options.UseFont = true;
            this.txtRequest.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRequest.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtRequest.Properties.AutoHeight = false;
            this.txtRequest.Properties.ReadOnly = true;
            this.txtRequest.Size = new System.Drawing.Size(90, 40);
            this.txtRequest.TabIndex = 3;
            // 
            // lblWorking
            // 
            this.lblWorking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorking.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblWorking.Appearance.Options.UseFont = true;
            this.lblWorking.Appearance.Options.UseTextOptions = true;
            this.lblWorking.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblWorking.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblWorking.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWorking.LanguageKey = "PROCEEDING";
            this.lblWorking.Location = new System.Drawing.Point(29, 102);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(90, 40);
            this.lblWorking.TabIndex = 2;
            this.lblWorking.Text = "진행중";
            // 
            // lblRequest
            // 
            this.lblRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRequest.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblRequest.Appearance.Options.UseFont = true;
            this.lblRequest.Appearance.Options.UseTextOptions = true;
            this.lblRequest.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblRequest.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblRequest.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRequest.LanguageKey = "REQUEST";
            this.lblRequest.Location = new System.Drawing.Point(29, 56);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(90, 40);
            this.lblRequest.TabIndex = 1;
            this.lblRequest.Text = "접수";
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblState.Appearance.Options.UseFont = true;
            this.lblState.Appearance.Options.UseTextOptions = true;
            this.lblState.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblState.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblState.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblState.LanguageKey = "STATEINFO";
            this.lblState.Location = new System.Drawing.Point(3, 5);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(242, 40);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "진행상태 현황";
            // 
            // XManageReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 629);
            this.Name = "XManageReg";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "XManageReg";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabXmanage)).EndInit();
            this.tabXmanage.ResumeLayout(false);
            this.actionStatus.ResumeLayout(false);
            this.tplXmanage.ResumeLayout(false);
            this.tplXmanage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStateDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResponseDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detShipmentDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detShipmentDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPublishDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompleteDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOccurDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgressDesc.Properties)).EndInit();
            this.fileInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlStateInfo)).EndInit();
            this.pnlStateInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWorking.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequest.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private Framework.SmartControls.SmartSpliterControl splXmanage;
		private Framework.SmartControls.SmartTabControl tabXmanage;
		private DevExpress.XtraTab.XtraTabPage actionStatus;
		private DevExpress.XtraTab.XtraTabPage fileInfo;
		private Framework.SmartControls.SmartBandedGrid grdXmanage;
		private Framework.SmartControls.SmartSplitTableLayoutPanel tplXmanage;
		private Framework.SmartControls.SmartLabel lblOrderNumber;
		private Framework.SmartControls.SmartLabel lblRequestDate;
		private Framework.SmartControls.SmartLabel lblProgressDesc;
		private Framework.SmartControls.SmartLabel lblPublishDate;
		private Framework.SmartControls.SmartLabel lblCompleteDate;
		private Framework.SmartControls.SmartTextBox txtOrderNumber;
		private Framework.SmartControls.SmartTextBox txtPublishDate;
		private Framework.SmartControls.SmartTextBox txtCompleteDate;
		private Quality.ucFileControl fileControl;
		private Framework.SmartControls.SmartPanel pnlInfo;
		private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
		private Framework.SmartControls.SmartPanel pnlStateInfo;
		private Framework.SmartControls.SmartTextBox txtWorking;
		private Framework.SmartControls.SmartTextBox txtRequest;
		private Framework.SmartControls.SmartLabel lblWorking;
		private Framework.SmartControls.SmartLabel lblRequest;
		private Framework.SmartControls.SmartLabel lblState;
		private Framework.SmartControls.SmartTextBox txtOccurDate;
        private Framework.SmartControls.SmartLabel lblShipmentDate;
        private Framework.SmartControls.SmartDateEdit detShipmentDate;
        private Framework.SmartControls.SmartMemoEdit txtProgressDesc;
        private Framework.SmartControls.SmartMemoEdit txtStateDesc;
        private Framework.SmartControls.SmartLabel smartLabel2;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartMemoEdit txtResponseDesc;
    }
}