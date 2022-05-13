namespace Micube.SmartMES.StandardInfo
{
    partial class BomInfo
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
            this.gbxBomTree = new Micube.Framework.SmartControls.SmartGroupBox();
            this.bomTree = new Micube.Framework.SmartControls.SmartTreeList();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBomTree)).BeginInit();
            this.gbxBomTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bomTree)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 379);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(457, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.gbxBomTree);
            this.pnlContent.Size = new System.Drawing.Size(457, 383);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(762, 412);
            // 
            // gbxBomTree
            // 
            this.gbxBomTree.Controls.Add(this.bomTree);
            this.gbxBomTree.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.gbxBomTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxBomTree.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.gbxBomTree.Location = new System.Drawing.Point(0, 0);
            this.gbxBomTree.Name = "gbxBomTree";
            this.gbxBomTree.ShowBorder = true;
            this.gbxBomTree.Size = new System.Drawing.Size(457, 383);
            this.gbxBomTree.TabIndex = 0;
            this.gbxBomTree.Text = "BOM 조회";
            // 
            // bomTree
            // 
            this.bomTree.DisplayMember = null;
            this.bomTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bomTree.LabelText = null;
            this.bomTree.LanguageKey = null;
            this.bomTree.Location = new System.Drawing.Point(2, 31);
            this.bomTree.MaxHeight = 0;
            this.bomTree.Name = "bomTree";
            this.bomTree.NodeTypeFieldName = "NODETYPE";
            this.bomTree.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.bomTree.OptionsBehavior.AutoPopulateColumns = false;
            this.bomTree.OptionsBehavior.Editable = false;
            this.bomTree.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.bomTree.OptionsFilter.AllowColumnMRUFilterList = false;
            this.bomTree.OptionsFilter.AllowMRUFilterList = false;
            this.bomTree.OptionsFind.AlwaysVisible = true;
            this.bomTree.OptionsFind.ClearFindOnClose = false;
            this.bomTree.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.FindClick;
            this.bomTree.OptionsFind.FindNullPrompt = "";
            this.bomTree.OptionsFind.ShowClearButton = false;
            this.bomTree.OptionsFind.ShowCloseButton = false;
            this.bomTree.OptionsFind.ShowFindButton = false;
            this.bomTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bomTree.OptionsView.ShowColumns = false;
            this.bomTree.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.True;
            this.bomTree.OptionsView.ShowHorzLines = false;
            this.bomTree.OptionsView.ShowIndentAsRowStyle = true;
            this.bomTree.OptionsView.ShowIndicator = false;
            this.bomTree.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.bomTree.OptionsView.ShowVertLines = false;
            this.bomTree.ParentMember = "ParentID";
            this.bomTree.ResultIsLeafLevel = true;
            this.bomTree.Size = new System.Drawing.Size(453, 350);
            this.bomTree.TabIndex = 0;
            this.bomTree.ValueMember = "ID";
            this.bomTree.ValueNodeTypeFieldName = "Equipment";
            // 
            // BomInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "BomInfo";
            this.Padding = new System.Windows.Forms.Padding(19);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBomTree)).EndInit();
            this.gbxBomTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bomTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartGroupBox gbxBomTree;
        private Framework.SmartControls.SmartTreeList bomTree;
    }
}