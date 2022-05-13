namespace Micube.SmartMES.Lot
{
    partial class LotTrace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LotTrace));
            this.treeLotGeneal = new Micube.Framework.SmartControls.SmartTreeList();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.treeReverseTrace = new Micube.Framework.SmartControls.SmartTreeList();
            this.smartSpliterControl2 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.smartLabel2 = new Micube.Framework.SmartControls.SmartLabel();
            this.lblExportReverse = new Micube.Framework.SmartControls.SmartLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.smartLabel3 = new Micube.Framework.SmartControls.SmartLabel();
            this.lblExportForward2 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartSpliterContainer1 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.treeFowardTrace = new Micube.Framework.SmartControls.SmartTreeList();
            this.tabMain = new Micube.Framework.SmartControls.SmartTabControl();
            this.tpgWorkResult = new DevExpress.XtraTab.XtraTabPage();
            this.grdLotWorkResult = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.tpgInputMaterial = new DevExpress.XtraTab.XtraTabPage();
            this.grdInputMaterial = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.tpgLotEquipment = new DevExpress.XtraTab.XtraTabPage();
            this.grdLotEquipment = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.tpgShippingInsp = new DevExpress.XtraTab.XtraTabPage();
            this.grdShippingInsp = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.tpgXmanage = new DevExpress.XtraTab.XtraTabPage();
            this.grdXmanage = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.tblWorkResultDetail = new DevExpress.XtraTab.XtraTabPage();
            this.grdWorkresultDetail = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeLotGeneal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeReverseTrace)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeFowardTrace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpgWorkResult.SuspendLayout();
            this.tpgInputMaterial.SuspendLayout();
            this.tpgLotEquipment.SuspendLayout();
            this.tpgShippingInsp.SuspendLayout();
            this.tpgXmanage.SuspendLayout();
            this.tblWorkResultDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 592);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(1306, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Controls.Add(this.panel5);
            this.pnlContent.Controls.Add(this.smartSpliterControl2);
            this.pnlContent.Controls.Add(this.panel2);
            this.pnlContent.Controls.Add(this.smartSpliterControl1);
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Size = new System.Drawing.Size(1306, 596);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1611, 625);
            // 
            // treeLotGeneal
            // 
            this.treeLotGeneal.DisplayMember = null;
            this.treeLotGeneal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeLotGeneal.LabelText = null;
            this.treeLotGeneal.LanguageKey = null;
            this.treeLotGeneal.Location = new System.Drawing.Point(0, 51);
            this.treeLotGeneal.MaxHeight = 0;
            this.treeLotGeneal.Name = "treeLotGeneal";
            this.treeLotGeneal.NodeTypeFieldName = "NODETYPE";
            this.treeLotGeneal.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeLotGeneal.OptionsBehavior.AutoPopulateColumns = false;
            this.treeLotGeneal.OptionsBehavior.Editable = false;
            this.treeLotGeneal.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.treeLotGeneal.OptionsFilter.AllowColumnMRUFilterList = false;
            this.treeLotGeneal.OptionsFilter.AllowMRUFilterList = false;
            this.treeLotGeneal.OptionsFind.AlwaysVisible = true;
            this.treeLotGeneal.OptionsFind.ClearFindOnClose = false;
            this.treeLotGeneal.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.FindClick;
            this.treeLotGeneal.OptionsFind.FindNullPrompt = "";
            this.treeLotGeneal.OptionsFind.ShowClearButton = false;
            this.treeLotGeneal.OptionsFind.ShowCloseButton = false;
            this.treeLotGeneal.OptionsFind.ShowFindButton = false;
            this.treeLotGeneal.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeLotGeneal.OptionsView.ShowColumns = false;
            this.treeLotGeneal.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeLotGeneal.OptionsView.ShowHorzLines = false;
            this.treeLotGeneal.OptionsView.ShowIndentAsRowStyle = true;
            this.treeLotGeneal.OptionsView.ShowIndicator = false;
            this.treeLotGeneal.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeLotGeneal.OptionsView.ShowVertLines = false;
            this.treeLotGeneal.ParentMember = "ParentID";
            this.treeLotGeneal.ResultIsLeafLevel = true;
            this.treeLotGeneal.Size = new System.Drawing.Size(364, 545);
            this.treeLotGeneal.TabIndex = 1;
            this.treeLotGeneal.ValueMember = "ID";
            this.treeLotGeneal.ValueNodeTypeFieldName = "Equipment";
            // 
            // smartSpliterControl1
            // 
            this.smartSpliterControl1.Location = new System.Drawing.Point(364, 0);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(5, 596);
            this.smartSpliterControl1.TabIndex = 11;
            this.smartSpliterControl1.TabStop = false;
            // 
            // treeReverseTrace
            // 
            this.treeReverseTrace.DisplayMember = null;
            this.treeReverseTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeReverseTrace.LabelText = null;
            this.treeReverseTrace.LanguageKey = null;
            this.treeReverseTrace.Location = new System.Drawing.Point(0, 51);
            this.treeReverseTrace.MaxHeight = 0;
            this.treeReverseTrace.Name = "treeReverseTrace";
            this.treeReverseTrace.NodeTypeFieldName = "NODETYPE";
            this.treeReverseTrace.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeReverseTrace.OptionsBehavior.AutoPopulateColumns = false;
            this.treeReverseTrace.OptionsBehavior.Editable = false;
            this.treeReverseTrace.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.treeReverseTrace.OptionsFilter.AllowColumnMRUFilterList = false;
            this.treeReverseTrace.OptionsFilter.AllowMRUFilterList = false;
            this.treeReverseTrace.OptionsFind.AlwaysVisible = true;
            this.treeReverseTrace.OptionsFind.ClearFindOnClose = false;
            this.treeReverseTrace.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.FindClick;
            this.treeReverseTrace.OptionsFind.FindNullPrompt = "";
            this.treeReverseTrace.OptionsFind.ShowClearButton = false;
            this.treeReverseTrace.OptionsFind.ShowCloseButton = false;
            this.treeReverseTrace.OptionsFind.ShowFindButton = false;
            this.treeReverseTrace.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeReverseTrace.OptionsView.ShowColumns = false;
            this.treeReverseTrace.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeReverseTrace.OptionsView.ShowHorzLines = false;
            this.treeReverseTrace.OptionsView.ShowIndentAsRowStyle = true;
            this.treeReverseTrace.OptionsView.ShowIndicator = false;
            this.treeReverseTrace.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeReverseTrace.OptionsView.ShowVertLines = false;
            this.treeReverseTrace.ParentMember = "ParentID";
            this.treeReverseTrace.ResultIsLeafLevel = true;
            this.treeReverseTrace.Size = new System.Drawing.Size(373, 545);
            this.treeReverseTrace.TabIndex = 13;
            this.treeReverseTrace.ValueMember = "ID";
            this.treeReverseTrace.ValueNodeTypeFieldName = "Equipment";
            // 
            // smartSpliterControl2
            // 
            this.smartSpliterControl2.Location = new System.Drawing.Point(742, 0);
            this.smartSpliterControl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl2.Name = "smartSpliterControl2";
            this.smartSpliterControl2.Size = new System.Drawing.Size(5, 596);
            this.smartSpliterControl2.TabIndex = 14;
            this.smartSpliterControl2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeLotGeneal);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 596);
            this.panel1.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.smartLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(364, 51);
            this.panel3.TabIndex = 3;
            // 
            // smartLabel1
            // 
            this.smartLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.smartLabel1.Appearance.Options.UseFont = true;
            this.smartLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.smartLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartLabel1.LanguageKey = "FORWARDLOOKUP";
            this.smartLabel1.Location = new System.Drawing.Point(0, 0);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.smartLabel1.Size = new System.Drawing.Size(364, 51);
            this.smartLabel1.TabIndex = 2;
            this.smartLabel1.Text = "정방향 조회";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeReverseTrace);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(369, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 596);
            this.panel2.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.smartLabel2);
            this.panel4.Controls.Add(this.lblExportReverse);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(373, 51);
            this.panel4.TabIndex = 15;
            // 
            // smartLabel2
            // 
            this.smartLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.smartLabel2.Appearance.Options.UseFont = true;
            this.smartLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.smartLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartLabel2.LanguageKey = "REVERSELOOKUP";
            this.smartLabel2.Location = new System.Drawing.Point(0, 0);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.smartLabel2.Size = new System.Drawing.Size(339, 51);
            this.smartLabel2.TabIndex = 14;
            this.smartLabel2.Text = "역방향 조회";
            // 
            // lblExportReverse
            // 
            this.lblExportReverse.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblExportReverse.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExportReverse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblExportReverse.ImageOptions.Image")));
            this.lblExportReverse.Location = new System.Drawing.Point(339, 0);
            this.lblExportReverse.Name = "lblExportReverse";
            this.lblExportReverse.Size = new System.Drawing.Size(34, 51);
            this.lblExportReverse.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.smartLabel3);
            this.panel5.Controls.Add(this.lblExportForward2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(747, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(559, 51);
            this.panel5.TabIndex = 19;
            // 
            // smartLabel3
            // 
            this.smartLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.smartLabel3.Appearance.Options.UseFont = true;
            this.smartLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.smartLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartLabel3.LanguageKey = "FORWARDLOOKUP";
            this.smartLabel3.Location = new System.Drawing.Point(0, 0);
            this.smartLabel3.Name = "smartLabel3";
            this.smartLabel3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.smartLabel3.Size = new System.Drawing.Size(525, 51);
            this.smartLabel3.TabIndex = 14;
            this.smartLabel3.Text = "정방향 조회";
            // 
            // lblExportForward2
            // 
            this.lblExportForward2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblExportForward2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExportForward2.Location = new System.Drawing.Point(525, 0);
            this.lblExportForward2.Name = "lblExportForward2";
            this.lblExportForward2.Size = new System.Drawing.Size(34, 51);
            this.lblExportForward2.TabIndex = 15;
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Horizontal = false;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(747, 51);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.treeFowardTrace);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.tabMain);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(559, 545);
            this.smartSpliterContainer1.SplitterPosition = 299;
            this.smartSpliterContainer1.TabIndex = 20;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // treeFowardTrace
            // 
            this.treeFowardTrace.DisplayMember = null;
            this.treeFowardTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFowardTrace.HorzScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Always;
            this.treeFowardTrace.LabelText = null;
            this.treeFowardTrace.LanguageKey = null;
            this.treeFowardTrace.Location = new System.Drawing.Point(0, 0);
            this.treeFowardTrace.MaxHeight = 0;
            this.treeFowardTrace.Name = "treeFowardTrace";
            this.treeFowardTrace.NodeTypeFieldName = "NODETYPE";
            this.treeFowardTrace.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeFowardTrace.OptionsBehavior.AutoPopulateColumns = false;
            this.treeFowardTrace.OptionsBehavior.Editable = false;
            this.treeFowardTrace.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.treeFowardTrace.OptionsFilter.AllowColumnMRUFilterList = false;
            this.treeFowardTrace.OptionsFilter.AllowMRUFilterList = false;
            this.treeFowardTrace.OptionsFind.AlwaysVisible = true;
            this.treeFowardTrace.OptionsFind.ClearFindOnClose = false;
            this.treeFowardTrace.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.FindClick;
            this.treeFowardTrace.OptionsFind.FindNullPrompt = "";
            this.treeFowardTrace.OptionsFind.ShowClearButton = false;
            this.treeFowardTrace.OptionsFind.ShowCloseButton = false;
            this.treeFowardTrace.OptionsFind.ShowFindButton = false;
            this.treeFowardTrace.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeFowardTrace.OptionsSelection.MultiSelectMode = DevExpress.XtraTreeList.TreeListMultiSelectMode.CellSelect;
            this.treeFowardTrace.OptionsView.ShowColumns = false;
            this.treeFowardTrace.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeFowardTrace.OptionsView.ShowHorzLines = false;
            this.treeFowardTrace.OptionsView.ShowIndentAsRowStyle = true;
            this.treeFowardTrace.OptionsView.ShowIndicator = false;
            this.treeFowardTrace.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeFowardTrace.OptionsView.ShowVertLines = false;
            this.treeFowardTrace.ParentMember = "ParentID";
            this.treeFowardTrace.ResultIsLeafLevel = true;
            this.treeFowardTrace.Size = new System.Drawing.Size(559, 299);
            this.treeFowardTrace.TabIndex = 16;
            this.treeFowardTrace.ValueMember = "ID";
            this.treeFowardTrace.ValueNodeTypeFieldName = "Equipment";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpgWorkResult;
            this.tabMain.Size = new System.Drawing.Size(559, 241);
            this.tabMain.TabIndex = 17;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpgWorkResult,
            this.tpgInputMaterial,
            this.tpgLotEquipment,
            this.tpgShippingInsp,
            this.tpgXmanage,
            this.tblWorkResultDetail});
            // 
            // tpgWorkResult
            // 
            this.tpgWorkResult.Controls.Add(this.grdLotWorkResult);
            this.tabMain.SetLanguageKey(this.tpgWorkResult, "LOTRESULTINFO");
            this.tpgWorkResult.Name = "tpgWorkResult";
            this.tpgWorkResult.Padding = new System.Windows.Forms.Padding(3);
            this.tpgWorkResult.Size = new System.Drawing.Size(553, 212);
            this.tpgWorkResult.Text = "생산실적";
            // 
            // grdLotWorkResult
            // 
            this.grdLotWorkResult.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdLotWorkResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLotWorkResult.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdLotWorkResult.IsUsePaging = false;
            this.grdLotWorkResult.LanguageKey = "LOTRESULTINFO";
            this.grdLotWorkResult.Location = new System.Drawing.Point(3, 3);
            this.grdLotWorkResult.Margin = new System.Windows.Forms.Padding(0);
            this.grdLotWorkResult.Name = "grdLotWorkResult";
            this.grdLotWorkResult.ShowBorder = true;
            this.grdLotWorkResult.ShowStatusBar = false;
            this.grdLotWorkResult.Size = new System.Drawing.Size(547, 206);
            this.grdLotWorkResult.TabIndex = 10;
            this.grdLotWorkResult.UseAutoBestFitColumns = false;
            // 
            // tpgInputMaterial
            // 
            this.tpgInputMaterial.Controls.Add(this.grdInputMaterial);
            this.tabMain.SetLanguageKey(this.tpgInputMaterial, "MATERIALSTOINPUT");
            this.tpgInputMaterial.Name = "tpgInputMaterial";
            this.tpgInputMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tpgInputMaterial.Size = new System.Drawing.Size(553, 212);
            this.tpgInputMaterial.Text = "투입자재";
            // 
            // grdInputMaterial
            // 
            this.grdInputMaterial.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdInputMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInputMaterial.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdInputMaterial.IsUsePaging = false;
            this.grdInputMaterial.LanguageKey = "MATERIALSTOINPUT";
            this.grdInputMaterial.Location = new System.Drawing.Point(3, 3);
            this.grdInputMaterial.Margin = new System.Windows.Forms.Padding(0);
            this.grdInputMaterial.Name = "grdInputMaterial";
            this.grdInputMaterial.ShowBorder = true;
            this.grdInputMaterial.ShowStatusBar = false;
            this.grdInputMaterial.Size = new System.Drawing.Size(547, 206);
            this.grdInputMaterial.TabIndex = 11;
            this.grdInputMaterial.UseAutoBestFitColumns = false;
            // 
            // tpgLotEquipment
            // 
            this.tpgLotEquipment.Controls.Add(this.grdLotEquipment);
            this.tabMain.SetLanguageKey(this.tpgLotEquipment, "EQUIPMENT");
            this.tpgLotEquipment.Name = "tpgLotEquipment";
            this.tpgLotEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.tpgLotEquipment.Size = new System.Drawing.Size(553, 212);
            this.tpgLotEquipment.Text = "설비";
            // 
            // grdLotEquipment
            // 
            this.grdLotEquipment.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdLotEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLotEquipment.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdLotEquipment.IsUsePaging = false;
            this.grdLotEquipment.LanguageKey = "EQUIPMENT";
            this.grdLotEquipment.Location = new System.Drawing.Point(3, 3);
            this.grdLotEquipment.Margin = new System.Windows.Forms.Padding(0);
            this.grdLotEquipment.Name = "grdLotEquipment";
            this.grdLotEquipment.ShowBorder = true;
            this.grdLotEquipment.ShowStatusBar = false;
            this.grdLotEquipment.Size = new System.Drawing.Size(547, 206);
            this.grdLotEquipment.TabIndex = 12;
            this.grdLotEquipment.UseAutoBestFitColumns = false;
            // 
            // tpgShippingInsp
            // 
            this.tpgShippingInsp.Controls.Add(this.grdShippingInsp);
            this.tpgShippingInsp.Name = "tpgShippingInsp";
            this.tpgShippingInsp.Padding = new System.Windows.Forms.Padding(3);
            this.tpgShippingInsp.Size = new System.Drawing.Size(553, 212);
            this.tpgShippingInsp.Text = "출하검사";
            // 
            // grdShippingInsp
            // 
            this.grdShippingInsp.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdShippingInsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdShippingInsp.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdShippingInsp.IsUsePaging = false;
            this.grdShippingInsp.LanguageKey = "SELECTOUTGOINGLOTLIST";
            this.grdShippingInsp.Location = new System.Drawing.Point(3, 3);
            this.grdShippingInsp.Margin = new System.Windows.Forms.Padding(0);
            this.grdShippingInsp.Name = "grdShippingInsp";
            this.grdShippingInsp.ShowBorder = true;
            this.grdShippingInsp.ShowStatusBar = false;
            this.grdShippingInsp.Size = new System.Drawing.Size(547, 206);
            this.grdShippingInsp.TabIndex = 2;
            this.grdShippingInsp.UseAutoBestFitColumns = false;
            // 
            // tpgXmanage
            // 
            this.tpgXmanage.Controls.Add(this.grdXmanage);
            this.tpgXmanage.Name = "tpgXmanage";
            this.tpgXmanage.Padding = new System.Windows.Forms.Padding(3);
            this.tpgXmanage.Size = new System.Drawing.Size(553, 212);
            this.tpgXmanage.Text = "X번 관리 이력";
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
            this.grdXmanage.Location = new System.Drawing.Point(3, 3);
            this.grdXmanage.Margin = new System.Windows.Forms.Padding(0);
            this.grdXmanage.Name = "grdXmanage";
            this.grdXmanage.ShowBorder = true;
            this.grdXmanage.ShowStatusBar = false;
            this.grdXmanage.Size = new System.Drawing.Size(547, 206);
            this.grdXmanage.TabIndex = 1;
            this.grdXmanage.UseAutoBestFitColumns = false;
            // 
            // tblWorkResultDetail
            // 
            this.tblWorkResultDetail.Controls.Add(this.grdWorkresultDetail);
            this.tabMain.SetLanguageKey(this.tblWorkResultDetail, "WORKRESULT");
            this.tblWorkResultDetail.Name = "tblWorkResultDetail";
            this.tblWorkResultDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tblWorkResultDetail.Size = new System.Drawing.Size(553, 212);
            this.tblWorkResultDetail.Text = "작업실적";
            // 
            // grdWorkresultDetail
            // 
            this.grdWorkresultDetail.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdWorkresultDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorkresultDetail.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdWorkresultDetail.IsUsePaging = false;
            this.grdWorkresultDetail.LanguageKey = "XMANAGELIST";
            this.grdWorkresultDetail.Location = new System.Drawing.Point(3, 3);
            this.grdWorkresultDetail.Margin = new System.Windows.Forms.Padding(0);
            this.grdWorkresultDetail.Name = "grdWorkresultDetail";
            this.grdWorkresultDetail.ShowBorder = true;
            this.grdWorkresultDetail.ShowStatusBar = false;
            this.grdWorkresultDetail.Size = new System.Drawing.Size(547, 206);
            this.grdWorkresultDetail.TabIndex = 2;
            this.grdWorkresultDetail.UseAutoBestFitColumns = false;
            // 
            // LotTrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1649, 663);
            this.Name = "LotTrace";
            this.Padding = new System.Windows.Forms.Padding(19);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeLotGeneal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeReverseTrace)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeFowardTrace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpgWorkResult.ResumeLayout(false);
            this.tpgInputMaterial.ResumeLayout(false);
            this.tpgLotEquipment.ResumeLayout(false);
            this.tpgShippingInsp.ResumeLayout(false);
            this.tpgXmanage.ResumeLayout(false);
            this.tblWorkResultDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
        private Framework.SmartControls.SmartTreeList treeLotGeneal;
        private Framework.SmartControls.SmartTreeList treeReverseTrace;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl2;
        private System.Windows.Forms.Panel panel2;
        private Framework.SmartControls.SmartLabel smartLabel2;
        private System.Windows.Forms.Panel panel1;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private System.Windows.Forms.Panel panel4;
        private Framework.SmartControls.SmartLabel lblExportReverse;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private Framework.SmartControls.SmartLabel smartLabel3;
        private Framework.SmartControls.SmartLabel lblExportForward2;
        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartTreeList treeFowardTrace;
        private Framework.SmartControls.SmartTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpgWorkResult;
        private Framework.SmartControls.SmartBandedGrid grdLotWorkResult;
        private DevExpress.XtraTab.XtraTabPage tpgInputMaterial;
        private Framework.SmartControls.SmartBandedGrid grdInputMaterial;
        private DevExpress.XtraTab.XtraTabPage tpgLotEquipment;
        private Framework.SmartControls.SmartBandedGrid grdLotEquipment;
        private DevExpress.XtraTab.XtraTabPage tpgShippingInsp;
        private Framework.SmartControls.SmartBandedGrid grdShippingInsp;
        private DevExpress.XtraTab.XtraTabPage tpgXmanage;
        private Framework.SmartControls.SmartBandedGrid grdXmanage;
        private DevExpress.XtraTab.XtraTabPage tblWorkResultDetail;
        private Framework.SmartControls.SmartBandedGrid grdWorkresultDetail;
    }
}