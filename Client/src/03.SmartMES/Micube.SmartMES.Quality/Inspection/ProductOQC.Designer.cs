namespace Micube.SmartMES.Quality
{
	partial class ProductOQC
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
			Micube.Framework.SmartControls.ConditionItemSelectPopup conditionItemSelectPopup1 = new Micube.Framework.SmartControls.ConditionItemSelectPopup();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductOQC));
			Micube.Framework.SmartControls.ConditionCollection conditionCollection1 = new Micube.Framework.SmartControls.ConditionCollection();
			Micube.Framework.SmartControls.Grid.Conditions.ConditionCollection conditionCollection2 = new Micube.Framework.SmartControls.Grid.Conditions.ConditionCollection();
			this.tlpOQC = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
			this.pnlIQCInfo3 = new Micube.Framework.SmartControls.SmartPanel();
			this.txtComment = new Micube.Framework.SmartControls.SmartTextBox();
			this.lblComment = new Micube.Framework.SmartControls.SmartLabel();
			this.pnlIQCInfo2 = new Micube.Framework.SmartControls.SmartPanel();
			this.txtDegree = new Micube.Framework.SmartControls.SmartTextBox();
			this.lblDegree = new Micube.Framework.SmartControls.SmartLabel();
			this.cboInspector = new Micube.Framework.SmartControls.SmartComboBox();
			this.popInspector2 = new Micube.Framework.SmartControls.SmartSelectPopupEdit();
			this.lblInspector2 = new Micube.Framework.SmartControls.SmartLabel();
			this.lblInspector = new Micube.Framework.SmartControls.SmartLabel();
			this.txtQty = new Micube.Framework.SmartControls.SmartTextBox();
			this.lblQty = new Micube.Framework.SmartControls.SmartLabel();
			this.grdProductOQC = new Micube.Framework.SmartControls.SmartBandedGrid();
			this.pnlIQCInfo1 = new Micube.Framework.SmartControls.SmartPanel();
			this.cboProduct = new Micube.Framework.SmartControls.SmartComboBox();
			this.cboProcesssegment = new Micube.Framework.SmartControls.SmartComboBox();
			this.lblProcesssegment = new Micube.Framework.SmartControls.SmartLabel();
			this.txtProductName = new Micube.Framework.SmartControls.SmartTextBox();
			this.lblProductName = new Micube.Framework.SmartControls.SmartLabel();
			this.lblProduct = new Micube.Framework.SmartControls.SmartLabel();
			this.txtLOTId = new Micube.Framework.SmartControls.SmartTextBox();
			this.lblLOTId = new Micube.Framework.SmartControls.SmartLabel();
			this.picImage = new Micube.Framework.SmartControls.SmartPictureEdit();
			this.spcBottom = new Micube.Framework.SmartControls.SmartSpliterControl();
			((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
			this.pnlContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.tlpOQC.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlIQCInfo3)).BeginInit();
			this.pnlIQCInfo3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlIQCInfo2)).BeginInit();
			this.pnlIQCInfo2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtDegree.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cboInspector.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popInspector2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlIQCInfo1)).BeginInit();
			this.pnlIQCInfo1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cboProduct.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cboProcesssegment.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLOTId.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlCondition
			// 
			this.pnlCondition.Location = new System.Drawing.Point(0, 30);
			this.pnlCondition.Size = new System.Drawing.Size(0, 0);
			// 
			// pnlToolbar
			// 
			this.pnlToolbar.Size = new System.Drawing.Size(1405, 24);
			// 
			// pnlContent
			// 
			this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.pnlContent.Appearance.Options.UseBackColor = true;
			this.pnlContent.Controls.Add(this.tlpOQC);
			this.pnlContent.Controls.Add(this.spcBottom);
			this.pnlContent.Controls.Add(this.picImage);
			this.pnlContent.Size = new System.Drawing.Size(1405, 869);
			// 
			// pnlMain
			// 
			this.pnlMain.Size = new System.Drawing.Size(1405, 898);
			// 
			// tlpOQC
			// 
			this.tlpOQC.ColumnCount = 1;
			this.tlpOQC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpOQC.Controls.Add(this.pnlIQCInfo3, 0, 4);
			this.tlpOQC.Controls.Add(this.pnlIQCInfo2, 0, 2);
			this.tlpOQC.Controls.Add(this.grdProductOQC, 0, 6);
			this.tlpOQC.Controls.Add(this.pnlIQCInfo1, 0, 0);
			this.tlpOQC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpOQC.Location = new System.Drawing.Point(0, 0);
			this.tlpOQC.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.tlpOQC.Name = "tlpOQC";
			this.tlpOQC.RowCount = 7;
			this.tlpOQC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpOQC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpOQC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpOQC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpOQC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpOQC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpOQC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpOQC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpOQC.Size = new System.Drawing.Size(1405, 284);
			this.tlpOQC.TabIndex = 1;
			// 
			// pnlIQCInfo3
			// 
			this.pnlIQCInfo3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlIQCInfo3.Controls.Add(this.txtComment);
			this.pnlIQCInfo3.Controls.Add(this.lblComment);
			this.pnlIQCInfo3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlIQCInfo3.Location = new System.Drawing.Point(3, 83);
			this.pnlIQCInfo3.Name = "pnlIQCInfo3";
			this.pnlIQCInfo3.Size = new System.Drawing.Size(1399, 24);
			this.pnlIQCInfo3.TabIndex = 3;
			// 
			// txtComment
			// 
			this.txtComment.LabelText = null;
			this.txtComment.LanguageKey = null;
			this.txtComment.Location = new System.Drawing.Point(105, 2);
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(883, 20);
			this.txtComment.TabIndex = 14;
			this.txtComment.Tag = "COMMENT";
			// 
			// lblComment
			// 
			this.lblComment.Appearance.Options.UseTextOptions = true;
			this.lblComment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lblComment.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblComment.LanguageKey = "COMMENT";
			this.lblComment.Location = new System.Drawing.Point(3, 4);
			this.lblComment.Name = "lblComment";
			this.lblComment.Size = new System.Drawing.Size(95, 16);
			this.lblComment.TabIndex = 13;
			this.lblComment.Text = "특이사항";
			// 
			// pnlIQCInfo2
			// 
			this.pnlIQCInfo2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlIQCInfo2.Controls.Add(this.txtDegree);
			this.pnlIQCInfo2.Controls.Add(this.lblDegree);
			this.pnlIQCInfo2.Controls.Add(this.cboInspector);
			this.pnlIQCInfo2.Controls.Add(this.popInspector2);
			this.pnlIQCInfo2.Controls.Add(this.lblInspector2);
			this.pnlIQCInfo2.Controls.Add(this.lblInspector);
			this.pnlIQCInfo2.Controls.Add(this.txtQty);
			this.pnlIQCInfo2.Controls.Add(this.lblQty);
			this.pnlIQCInfo2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlIQCInfo2.Location = new System.Drawing.Point(3, 43);
			this.pnlIQCInfo2.Name = "pnlIQCInfo2";
			this.pnlIQCInfo2.Size = new System.Drawing.Size(1399, 24);
			this.pnlIQCInfo2.TabIndex = 2;
			// 
			// txtDegree
			// 
			this.txtDegree.EditValue = "";
			this.txtDegree.LabelText = null;
			this.txtDegree.LanguageKey = null;
			this.txtDegree.Location = new System.Drawing.Point(105, 2);
			this.txtDegree.Name = "txtDegree";
			this.txtDegree.Properties.Appearance.Options.UseTextOptions = true;
			this.txtDegree.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.txtDegree.Properties.ReadOnly = true;
			this.txtDegree.Size = new System.Drawing.Size(140, 20);
			this.txtDegree.TabIndex = 17;
			this.txtDegree.Tag = "DEGREE";
			// 
			// lblDegree
			// 
			this.lblDegree.Appearance.Options.UseTextOptions = true;
			this.lblDegree.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lblDegree.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblDegree.LanguageKey = "DEGREE";
			this.lblDegree.Location = new System.Drawing.Point(3, 4);
			this.lblDegree.Name = "lblDegree";
			this.lblDegree.Size = new System.Drawing.Size(95, 16);
			this.lblDegree.TabIndex = 16;
			this.lblDegree.Text = "검사차수";
			// 
			// cboInspector
			// 
			this.cboInspector.LabelText = null;
			this.cboInspector.LanguageKey = null;
			this.cboInspector.Location = new System.Drawing.Point(601, 2);
			this.cboInspector.Name = "cboInspector";
			this.cboInspector.PopupWidth = 0;
			this.cboInspector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cboInspector.Properties.NullText = "";
			this.cboInspector.Properties.ReadOnly = true;
			this.cboInspector.ShowHeader = true;
			this.cboInspector.Size = new System.Drawing.Size(140, 20);
			this.cboInspector.TabIndex = 15;
			this.cboInspector.Tag = "INSPECTOR";
			this.cboInspector.VisibleColumns = null;
			this.cboInspector.VisibleColumnsWidth = null;
			// 
			// popInspector2
			// 
			this.popInspector2.LabelText = null;
			this.popInspector2.LanguageKey = null;
			this.popInspector2.Location = new System.Drawing.Point(849, 2);
			this.popInspector2.Name = "popInspector2";
			conditionItemSelectPopup1.ApplySelection = null;
			conditionItemSelectPopup1.AutoFillColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("conditionItemSelectPopup1.AutoFillColumnNames")));
			conditionItemSelectPopup1.CanOkNoSelection = true;
			conditionItemSelectPopup1.ClearButtonRealOnly = false;
			conditionItemSelectPopup1.ClearButtonVisible = true;
			conditionItemSelectPopup1.ConditionDefaultId = null;
			conditionItemSelectPopup1.ConditionLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
			conditionItemSelectPopup1.ConditionRequireId = "";
			conditionItemSelectPopup1.Conditions = conditionCollection1;
			conditionItemSelectPopup1.CustomPopup = null;
			conditionItemSelectPopup1.CustomValidate = null;
			conditionItemSelectPopup1.DefaultDisplayValue = null;
			conditionItemSelectPopup1.DefaultValue = null;
			conditionItemSelectPopup1.DisplayFieldName = "";
			conditionItemSelectPopup1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			conditionItemSelectPopup1.GreatThenEqual = false;
			conditionItemSelectPopup1.GreatThenId = "";
			conditionItemSelectPopup1.GridColumns = conditionCollection2;
			conditionItemSelectPopup1.Id = null;
			conditionItemSelectPopup1.InitAction = null;
			conditionItemSelectPopup1.IsCaptionWordWrap = false;
			conditionItemSelectPopup1.IsEnabled = true;
			conditionItemSelectPopup1.IsHidden = false;
			conditionItemSelectPopup1.IsImmediatlyUpdate = true;
			conditionItemSelectPopup1.IsKeyColumn = false;
			conditionItemSelectPopup1.IsMultiGrid = false;
			conditionItemSelectPopup1.IsReadOnly = false;
			conditionItemSelectPopup1.IsRequired = false;
			conditionItemSelectPopup1.IsSearchOnLoading = true;
			conditionItemSelectPopup1.IsUseMultiColumnPaste = true;
			conditionItemSelectPopup1.IsUseRowCheckByMouseDrag = false;
			conditionItemSelectPopup1.LabelText = null;
			conditionItemSelectPopup1.LanguageKey = null;
			conditionItemSelectPopup1.LessThenEqual = false;
			conditionItemSelectPopup1.LessThenId = "";
			conditionItemSelectPopup1.NoSelectionMessageId = "";
			conditionItemSelectPopup1.PopupButtonStyle = Micube.Framework.SmartControls.PopupButtonStyles.Ok_Cancel;
			conditionItemSelectPopup1.PopupCustomValidation = null;
			conditionItemSelectPopup1.Position = 0D;
			conditionItemSelectPopup1.QueryPopup = null;
			conditionItemSelectPopup1.RelationIds = ((System.Collections.Generic.List<string>)(resources.GetObject("conditionItemSelectPopup1.RelationIds")));
			conditionItemSelectPopup1.ResultAction = null;
			conditionItemSelectPopup1.ResultCount = 1;
			conditionItemSelectPopup1.SearchButtonReadOnly = false;
			conditionItemSelectPopup1.SearchQuery = null;
			conditionItemSelectPopup1.SearchText = null;
			conditionItemSelectPopup1.SearchTextControlId = null;
			conditionItemSelectPopup1.SelectionQuery = null;
			conditionItemSelectPopup1.ShowSearchButton = true;
			conditionItemSelectPopup1.TextAlignment = Micube.Framework.SmartControls.TextAlignment.Default;
			conditionItemSelectPopup1.Title = null;
			conditionItemSelectPopup1.ToolTip = null;
			conditionItemSelectPopup1.ToolTipLanguageKey = null;
			conditionItemSelectPopup1.ValueFieldName = "";
			conditionItemSelectPopup1.WindowSize = new System.Drawing.Size(800, 500);
			this.popInspector2.SelectPopupCondition = conditionItemSelectPopup1;
			this.popInspector2.Size = new System.Drawing.Size(140, 20);
			this.popInspector2.TabIndex = 14;
			this.popInspector2.Tag = "INSPECTOR2";
			// 
			// lblInspector2
			// 
			this.lblInspector2.Appearance.Options.UseTextOptions = true;
			this.lblInspector2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lblInspector2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblInspector2.LanguageKey = "INSPECTOR2";
			this.lblInspector2.Location = new System.Drawing.Point(747, 4);
			this.lblInspector2.Name = "lblInspector2";
			this.lblInspector2.Size = new System.Drawing.Size(95, 16);
			this.lblInspector2.TabIndex = 12;
			this.lblInspector2.Text = "검사자2";
			// 
			// lblInspector
			// 
			this.lblInspector.Appearance.ForeColor = System.Drawing.Color.Red;
			this.lblInspector.Appearance.Options.UseForeColor = true;
			this.lblInspector.Appearance.Options.UseTextOptions = true;
			this.lblInspector.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lblInspector.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblInspector.LanguageKey = "INSPECTOR";
			this.lblInspector.Location = new System.Drawing.Point(499, 4);
			this.lblInspector.Name = "lblInspector";
			this.lblInspector.Size = new System.Drawing.Size(95, 16);
			this.lblInspector.TabIndex = 10;
			this.lblInspector.Text = "검사자";
			// 
			// txtQty
			// 
			this.txtQty.LabelText = null;
			this.txtQty.LanguageKey = null;
			this.txtQty.Location = new System.Drawing.Point(353, 2);
			this.txtQty.Name = "txtQty";
			this.txtQty.Properties.Appearance.Options.UseTextOptions = true;
			this.txtQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.txtQty.Properties.ReadOnly = true;
			this.txtQty.Size = new System.Drawing.Size(140, 20);
			this.txtQty.TabIndex = 9;
			this.txtQty.Tag = "QTY";
			// 
			// lblQty
			// 
			this.lblQty.Appearance.Options.UseTextOptions = true;
			this.lblQty.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lblQty.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblQty.LanguageKey = "QTY";
			this.lblQty.Location = new System.Drawing.Point(251, 4);
			this.lblQty.Name = "lblQty";
			this.lblQty.Size = new System.Drawing.Size(95, 16);
			this.lblQty.TabIndex = 8;
			this.lblQty.Text = "수량";
			// 
			// grdProductOQC
			// 
			this.grdProductOQC.Caption = "그리드제목( LanguageKey를 입력하세요)";
			this.grdProductOQC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdProductOQC.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
			this.grdProductOQC.IsUsePaging = false;
			this.grdProductOQC.LanguageKey = "OQCRESULTLIST";
			this.grdProductOQC.Location = new System.Drawing.Point(0, 120);
			this.grdProductOQC.Margin = new System.Windows.Forms.Padding(0);
			this.grdProductOQC.Name = "grdProductOQC";
			this.grdProductOQC.ShowBorder = true;
			this.grdProductOQC.Size = new System.Drawing.Size(1405, 164);
			this.grdProductOQC.TabIndex = 0;
			this.grdProductOQC.UseAutoBestFitColumns = false;
			// 
			// pnlIQCInfo1
			// 
			this.pnlIQCInfo1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlIQCInfo1.Controls.Add(this.cboProduct);
			this.pnlIQCInfo1.Controls.Add(this.cboProcesssegment);
			this.pnlIQCInfo1.Controls.Add(this.lblProcesssegment);
			this.pnlIQCInfo1.Controls.Add(this.txtProductName);
			this.pnlIQCInfo1.Controls.Add(this.lblProductName);
			this.pnlIQCInfo1.Controls.Add(this.lblProduct);
			this.pnlIQCInfo1.Controls.Add(this.txtLOTId);
			this.pnlIQCInfo1.Controls.Add(this.lblLOTId);
			this.pnlIQCInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlIQCInfo1.Location = new System.Drawing.Point(3, 3);
			this.pnlIQCInfo1.Name = "pnlIQCInfo1";
			this.pnlIQCInfo1.Size = new System.Drawing.Size(1399, 24);
			this.pnlIQCInfo1.TabIndex = 1;
			// 
			// cboProduct
			// 
			this.cboProduct.LabelText = null;
			this.cboProduct.LanguageKey = null;
			this.cboProduct.Location = new System.Drawing.Point(353, 2);
			this.cboProduct.Name = "cboProduct";
			this.cboProduct.PopupWidth = 0;
			this.cboProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cboProduct.Properties.NullText = "";
			this.cboProduct.Properties.ReadOnly = true;
			this.cboProduct.ShowHeader = true;
			this.cboProduct.Size = new System.Drawing.Size(140, 20);
			this.cboProduct.TabIndex = 17;
			this.cboProduct.Tag = "PRODUCTDEFID";
			this.cboProduct.VisibleColumns = null;
			this.cboProduct.VisibleColumnsWidth = null;
			// 
			// cboProcesssegment
			// 
			this.cboProcesssegment.LabelText = null;
			this.cboProcesssegment.LanguageKey = null;
			this.cboProcesssegment.Location = new System.Drawing.Point(1098, 2);
			this.cboProcesssegment.Name = "cboProcesssegment";
			this.cboProcesssegment.PopupWidth = 0;
			this.cboProcesssegment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cboProcesssegment.Properties.NullText = "";
			this.cboProcesssegment.Properties.ReadOnly = true;
			this.cboProcesssegment.ShowHeader = true;
			this.cboProcesssegment.Size = new System.Drawing.Size(140, 20);
			this.cboProcesssegment.TabIndex = 16;
			this.cboProcesssegment.Tag = "PROCESSSEGMENTID";
			this.cboProcesssegment.VisibleColumns = null;
			this.cboProcesssegment.VisibleColumnsWidth = null;
			// 
			// lblProcesssegment
			// 
			this.lblProcesssegment.Appearance.Options.UseTextOptions = true;
			this.lblProcesssegment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lblProcesssegment.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblProcesssegment.LanguageKey = "PROCESSSEGMENT";
			this.lblProcesssegment.Location = new System.Drawing.Point(996, 4);
			this.lblProcesssegment.Name = "lblProcesssegment";
			this.lblProcesssegment.Size = new System.Drawing.Size(95, 16);
			this.lblProcesssegment.TabIndex = 6;
			this.lblProcesssegment.Text = "공정";
			// 
			// txtProductName
			// 
			this.txtProductName.EditValue = "";
			this.txtProductName.LabelText = null;
			this.txtProductName.LanguageKey = null;
			this.txtProductName.Location = new System.Drawing.Point(601, 2);
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Properties.ReadOnly = true;
			this.txtProductName.Size = new System.Drawing.Size(387, 20);
			this.txtProductName.TabIndex = 5;
			this.txtProductName.Tag = "PRODUCTDEFNAME";
			// 
			// lblProductName
			// 
			this.lblProductName.Appearance.Options.UseTextOptions = true;
			this.lblProductName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lblProductName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblProductName.LanguageKey = "PRODUCTDEFNAME";
			this.lblProductName.Location = new System.Drawing.Point(499, 4);
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.Size = new System.Drawing.Size(95, 16);
			this.lblProductName.TabIndex = 4;
			this.lblProductName.Text = "품목명";
			// 
			// lblProduct
			// 
			this.lblProduct.Appearance.Options.UseTextOptions = true;
			this.lblProduct.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lblProduct.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblProduct.LanguageKey = "PRODUCTDEFID";
			this.lblProduct.Location = new System.Drawing.Point(251, 4);
			this.lblProduct.Name = "lblProduct";
			this.lblProduct.Size = new System.Drawing.Size(95, 16);
			this.lblProduct.TabIndex = 2;
			this.lblProduct.Text = "품목코드";
			// 
			// txtLOTId
			// 
			this.txtLOTId.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.txtLOTId.LabelText = null;
			this.txtLOTId.LanguageKey = null;
			this.txtLOTId.Location = new System.Drawing.Point(105, 2);
			this.txtLOTId.Name = "txtLOTId";
			this.txtLOTId.Size = new System.Drawing.Size(140, 20);
			this.txtLOTId.TabIndex = 1;
			this.txtLOTId.Tag = "LOTID";
			// 
			// lblLOTId
			// 
			this.lblLOTId.Appearance.ForeColor = System.Drawing.Color.Red;
			this.lblLOTId.Appearance.Options.UseForeColor = true;
			this.lblLOTId.Appearance.Options.UseTextOptions = true;
			this.lblLOTId.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lblLOTId.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblLOTId.LanguageKey = "LOTID";
			this.lblLOTId.Location = new System.Drawing.Point(3, 4);
			this.lblLOTId.Name = "lblLOTId";
			this.lblLOTId.Size = new System.Drawing.Size(95, 16);
			this.lblLOTId.TabIndex = 0;
			this.lblLOTId.Text = "LOT 번호";
			// 
			// picImage
			// 
			this.picImage.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.picImage.Location = new System.Drawing.Point(0, 289);
			this.picImage.Name = "picImage";
			this.picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.picImage.Properties.ShowScrollBars = true;
			this.picImage.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.ControlMouseWheel;
			this.picImage.Size = new System.Drawing.Size(1405, 580);
			this.picImage.TabIndex = 2;
			// 
			// spcBottom
			// 
			this.spcBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.spcBottom.Location = new System.Drawing.Point(0, 284);
			this.spcBottom.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.spcBottom.Name = "spcBottom";
			this.spcBottom.Size = new System.Drawing.Size(1405, 5);
			this.spcBottom.TabIndex = 3;
			this.spcBottom.TabStop = false;
			// 
			// ProductOQC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1425, 918);
			this.ConditionsVisible = false;
			this.Name = "ProductOQC";
			this.Text = "SmartConditionBaseForm";
			((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
			this.pnlContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.tlpOQC.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlIQCInfo3)).EndInit();
			this.pnlIQCInfo3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlIQCInfo2)).EndInit();
			this.pnlIQCInfo2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtDegree.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cboInspector.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popInspector2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlIQCInfo1)).EndInit();
			this.pnlIQCInfo1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cboProduct.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cboProcesssegment.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLOTId.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Framework.SmartControls.SmartSplitTableLayoutPanel tlpOQC;
		private Framework.SmartControls.SmartPanel pnlIQCInfo3;
		private Framework.SmartControls.SmartTextBox txtComment;
		private Framework.SmartControls.SmartLabel lblComment;
		private Framework.SmartControls.SmartPanel pnlIQCInfo2;
		private Framework.SmartControls.SmartLabel lblInspector2;
		private Framework.SmartControls.SmartLabel lblInspector;
		private Framework.SmartControls.SmartTextBox txtQty;
		private Framework.SmartControls.SmartLabel lblQty;
		private Framework.SmartControls.SmartBandedGrid grdProductOQC;
		private Framework.SmartControls.SmartPanel pnlIQCInfo1;
		private Framework.SmartControls.SmartLabel lblProcesssegment;
		private Framework.SmartControls.SmartTextBox txtProductName;
		private Framework.SmartControls.SmartLabel lblProductName;
		private Framework.SmartControls.SmartLabel lblProduct;
		private Framework.SmartControls.SmartTextBox txtLOTId;
		private Framework.SmartControls.SmartLabel lblLOTId;
		private Framework.SmartControls.SmartPictureEdit picImage;
		private Framework.SmartControls.SmartSpliterControl spcBottom;
		private Framework.SmartControls.SmartSelectPopupEdit popInspector2;
		private Framework.SmartControls.SmartComboBox cboInspector;
		private Framework.SmartControls.SmartComboBox cboProduct;
		private Framework.SmartControls.SmartComboBox cboProcesssegment;
		private Framework.SmartControls.SmartTextBox txtDegree;
		private Framework.SmartControls.SmartLabel lblDegree;
	}
}