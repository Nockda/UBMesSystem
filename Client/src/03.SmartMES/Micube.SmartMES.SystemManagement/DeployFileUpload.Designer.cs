namespace Micube.SmartMES.SystemManagement
{
    partial class DeployFileUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeployFileUpload));
            this.smartSpliterContainer1 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grbFolderList = new Micube.Framework.SmartControls.SmartGroupBox();
            this.treeFolder = new Micube.Framework.SmartControls.SmartTreeList();
            this.smartSpliterContainer2 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.gbxLocalFileList = new Micube.Framework.SmartControls.SmartGroupBox();
            this.grdLocalFileList = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartAutoLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPathChange = new Micube.Framework.SmartControls.SmartButton();
            this.btnDeploy = new Micube.Framework.SmartControls.SmartButton();
            this.btnDeployHistory = new Micube.Framework.SmartControls.SmartButton();
            this.txtLocalPath = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.gbxServerFileList = new Micube.Framework.SmartControls.SmartGroupBox();
            this.grdServerFileList = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.lbService = new Micube.Framework.SmartControls.SmartLabel();
            this.trImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbFolderList)).BeginInit();
            this.grbFolderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).BeginInit();
            this.smartSpliterContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxLocalFileList)).BeginInit();
            this.gbxLocalFileList.SuspendLayout();
            this.smartAutoLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxServerFileList)).BeginInit();
            this.gbxServerFileList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.OptionsView.UseDefaultDragAndDropRendering = false;
            this.pnlCondition.Size = new System.Drawing.Size(296, 595);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(717, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Size = new System.Drawing.Size(717, 599);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(1022, 628);
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.grbFolderList);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartSpliterContainer2);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(717, 599);
            this.smartSpliterContainer1.SplitterPosition = 250;
            this.smartSpliterContainer1.TabIndex = 0;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grbFolderList
            // 
            this.grbFolderList.Controls.Add(this.treeFolder);
            this.grbFolderList.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.grbFolderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbFolderList.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.grbFolderList.LanguageKey = "FolderPath";
            this.grbFolderList.Location = new System.Drawing.Point(0, 0);
            this.grbFolderList.Name = "grbFolderList";
            this.grbFolderList.ShowBorder = true;
            this.grbFolderList.Size = new System.Drawing.Size(250, 599);
            this.grbFolderList.TabIndex = 0;
            this.grbFolderList.Text = "Folder Path";
            // 
            // treeFolder
            // 
            this.treeFolder.DisplayMember = null;
            this.treeFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFolder.LabelText = null;
            this.treeFolder.LanguageKey = null;
            this.treeFolder.Location = new System.Drawing.Point(2, 31);
            this.treeFolder.MaxHeight = 0;
            this.treeFolder.Name = "treeFolder";
            this.treeFolder.NodeTypeFieldName = "NODETYPE";
            this.treeFolder.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeFolder.OptionsBehavior.AutoPopulateColumns = false;
            this.treeFolder.OptionsBehavior.Editable = false;
            this.treeFolder.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.treeFolder.OptionsFilter.AllowColumnMRUFilterList = false;
            this.treeFolder.OptionsFilter.AllowMRUFilterList = false;
            this.treeFolder.OptionsFind.AlwaysVisible = true;
            this.treeFolder.OptionsFind.ClearFindOnClose = false;
            this.treeFolder.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.FindClick;
            this.treeFolder.OptionsFind.FindNullPrompt = "";
            this.treeFolder.OptionsFind.ShowClearButton = false;
            this.treeFolder.OptionsFind.ShowCloseButton = false;
            this.treeFolder.OptionsFind.ShowFindButton = false;
            this.treeFolder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeFolder.OptionsView.ShowColumns = false;
            this.treeFolder.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeFolder.OptionsView.ShowHorzLines = false;
            this.treeFolder.OptionsView.ShowIndentAsRowStyle = true;
            this.treeFolder.OptionsView.ShowIndicator = false;
            this.treeFolder.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeFolder.OptionsView.ShowVertLines = false;
            this.treeFolder.ParentMember = "ParentID";
            this.treeFolder.ResultIsLeafLevel = true;
            this.treeFolder.Size = new System.Drawing.Size(246, 566);
            this.treeFolder.TabIndex = 1;
            this.treeFolder.ValueMember = "ID";
            this.treeFolder.ValueNodeTypeFieldName = "Equipment";
            // 
            // smartSpliterContainer2
            // 
            this.smartSpliterContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer2.Horizontal = false;
            this.smartSpliterContainer2.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer2.Name = "smartSpliterContainer2";
            this.smartSpliterContainer2.Panel1.Controls.Add(this.gbxLocalFileList);
            this.smartSpliterContainer2.Panel2.Controls.Add(this.gbxServerFileList);
            this.smartSpliterContainer2.Size = new System.Drawing.Size(462, 599);
            this.smartSpliterContainer2.SplitterPosition = 396;
            this.smartSpliterContainer2.TabIndex = 1;
            // 
            // gbxLocalFileList
            // 
            this.gbxLocalFileList.Controls.Add(this.grdLocalFileList);
            this.gbxLocalFileList.Controls.Add(this.smartAutoLayoutPanel2);
            this.gbxLocalFileList.Controls.Add(this.txtLocalPath);
            this.gbxLocalFileList.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.gbxLocalFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxLocalFileList.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.gbxLocalFileList.LanguageKey = "LocalFileList";
            this.gbxLocalFileList.Location = new System.Drawing.Point(0, 0);
            this.gbxLocalFileList.Name = "gbxLocalFileList";
            this.gbxLocalFileList.ShowBorder = true;
            this.gbxLocalFileList.Size = new System.Drawing.Size(462, 396);
            this.gbxLocalFileList.TabIndex = 28;
            this.gbxLocalFileList.Text = "Local File";
            // 
            // grdLocalFileList
            // 
            this.grdLocalFileList.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdLocalFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLocalFileList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdLocalFileList.IsUsePaging = false;
            this.grdLocalFileList.LanguageKey = "GRIDOBJECTLIST";
            this.grdLocalFileList.Location = new System.Drawing.Point(2, 83);
            this.grdLocalFileList.Margin = new System.Windows.Forms.Padding(0);
            this.grdLocalFileList.Name = "grdLocalFileList";
            this.grdLocalFileList.ShowBorder = true;
            this.grdLocalFileList.Size = new System.Drawing.Size(458, 311);
            this.grdLocalFileList.TabIndex = 31;
            this.grdLocalFileList.UseAutoBestFitColumns = false;
            // 
            // smartAutoLayoutPanel2
            // 
            this.smartAutoLayoutPanel2.Controls.Add(this.btnPathChange);
            this.smartAutoLayoutPanel2.Controls.Add(this.btnDeploy);
            this.smartAutoLayoutPanel2.Controls.Add(this.btnDeployHistory);
            this.smartAutoLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartAutoLayoutPanel2.Location = new System.Drawing.Point(2, 51);
            this.smartAutoLayoutPanel2.Name = "smartAutoLayoutPanel2";
            this.smartAutoLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.smartAutoLayoutPanel2.Size = new System.Drawing.Size(458, 32);
            this.smartAutoLayoutPanel2.TabIndex = 30;
            // 
            // btnPathChange
            // 
            this.btnPathChange.AllowFocus = false;
            this.btnPathChange.Appearance.Options.UseFont = true;
            this.btnPathChange.IsBusy = false;
            this.btnPathChange.IsWrite = false;
            this.btnPathChange.LanguageKey = "PathChange";
            this.btnPathChange.Location = new System.Drawing.Point(6, 3);
            this.btnPathChange.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnPathChange.Name = "btnPathChange";
            this.btnPathChange.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnPathChange.Size = new System.Drawing.Size(104, 25);
            this.btnPathChange.TabIndex = 0;
            this.btnPathChange.Text = "PathChange";
            this.btnPathChange.TooltipLanguageKey = "";
            // 
            // btnDeploy
            // 
            this.btnDeploy.AllowFocus = false;
            this.btnDeploy.Appearance.Options.UseFont = true;
            this.btnDeploy.IsBusy = false;
            this.btnDeploy.IsWrite = false;
            this.btnDeploy.LanguageKey = "DEPLOY";
            this.btnDeploy.Location = new System.Drawing.Point(116, 3);
            this.btnDeploy.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnDeploy.Size = new System.Drawing.Size(104, 25);
            this.btnDeploy.TabIndex = 0;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.TooltipLanguageKey = "";
            // 
            // btnDeployHistory
            // 
            this.btnDeployHistory.AllowFocus = false;
            this.btnDeployHistory.Appearance.Options.UseFont = true;
            this.btnDeployHistory.IsBusy = false;
            this.btnDeployHistory.IsWrite = false;
            this.btnDeployHistory.LanguageKey = "DeployHistory";
            this.btnDeployHistory.Location = new System.Drawing.Point(226, 3);
            this.btnDeployHistory.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnDeployHistory.Name = "btnDeployHistory";
            this.btnDeployHistory.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnDeployHistory.Size = new System.Drawing.Size(104, 25);
            this.btnDeployHistory.TabIndex = 1;
            this.btnDeployHistory.Text = "DeployHistory";
            this.btnDeployHistory.TooltipLanguageKey = "";
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLocalPath.LabelText = "Local Path";
            this.txtLocalPath.LabelWidth = "120px";
            this.txtLocalPath.LanguageKey = "Path";
            this.txtLocalPath.Location = new System.Drawing.Point(2, 31);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(458, 20);
            this.txtLocalPath.TabIndex = 29;
            // 
            // gbxServerFileList
            // 
            this.gbxServerFileList.Controls.Add(this.grdServerFileList);
            this.gbxServerFileList.Controls.Add(this.lbService);
            this.gbxServerFileList.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.gbxServerFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxServerFileList.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.gbxServerFileList.LanguageKey = "DeployFileList";
            this.gbxServerFileList.Location = new System.Drawing.Point(0, 0);
            this.gbxServerFileList.Name = "gbxServerFileList";
            this.gbxServerFileList.ShowBorder = true;
            this.gbxServerFileList.Size = new System.Drawing.Size(462, 198);
            this.gbxServerFileList.TabIndex = 29;
            this.gbxServerFileList.Text = "Deploy File";
            // 
            // grdServerFileList
            // 
            this.grdServerFileList.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdServerFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdServerFileList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdServerFileList.IsUsePaging = false;
            this.grdServerFileList.LanguageKey = "GRIDOBJECTATTRIBUTELIST";
            this.grdServerFileList.Location = new System.Drawing.Point(2, 55);
            this.grdServerFileList.Margin = new System.Windows.Forms.Padding(0);
            this.grdServerFileList.Name = "grdServerFileList";
            this.grdServerFileList.ShowBorder = true;
            this.grdServerFileList.Size = new System.Drawing.Size(458, 141);
            this.grdServerFileList.TabIndex = 30;
            this.grdServerFileList.UseAutoBestFitColumns = false;
            // 
            // lbService
            // 
            this.lbService.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbService.Appearance.Options.UseBackColor = true;
            this.lbService.Appearance.Options.UseTextOptions = true;
            this.lbService.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbService.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbService.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbService.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbService.Location = new System.Drawing.Point(2, 31);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(458, 24);
            this.lbService.TabIndex = 7;
            this.lbService.Text = "Smart Deploy Service ";
            // 
            // trImageCollection
            // 
            this.trImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("trImageCollection.ImageStream")));
            this.trImageCollection.Images.SetKeyName(0, "Folder");
            this.trImageCollection.Images.SetKeyName(1, "File");
            // 
            // DeployFileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 648);
            this.Name = "DeployFileUpload";
            this.Text = "DeployFileUpload";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbFolderList)).EndInit();
            this.grbFolderList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).EndInit();
            this.smartSpliterContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxLocalFileList)).EndInit();
            this.gbxLocalFileList.ResumeLayout(false);
            this.smartAutoLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxServerFileList)).EndInit();
            this.gbxServerFileList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trImageCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartGroupBox grbFolderList;
        private Framework.SmartControls.SmartTreeList treeFolder;
        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer2;
        private Framework.SmartControls.SmartGroupBox gbxLocalFileList;
        private Framework.SmartControls.SmartLabelTextBox txtLocalPath;
        private System.Windows.Forms.FlowLayoutPanel smartAutoLayoutPanel2;
        private Framework.SmartControls.SmartButton btnPathChange;
        private Framework.SmartControls.SmartButton btnDeploy;
        private Framework.SmartControls.SmartButton btnDeployHistory;
        private Framework.SmartControls.SmartBandedGrid grdLocalFileList;
        private Framework.SmartControls.SmartGroupBox gbxServerFileList;
        private Framework.SmartControls.SmartBandedGrid grdServerFileList;
        private Framework.SmartControls.SmartLabel lbService;
        private DevExpress.Utils.ImageCollection trImageCollection;
    }
}