namespace Micube.SmartMES.StandardInfo
{
    partial class ProcessDefinitionMgt
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
            this.spcContainter = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdProcessDef = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdProductMapping = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcContainter)).BeginInit();
            this.spcContainter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 429);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(509, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.spcContainter);
            this.pnlContent.Size = new System.Drawing.Size(509, 433);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(814, 462);
            // 
            // spcContainter
            // 
            this.spcContainter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcContainter.Horizontal = false;
            this.spcContainter.Location = new System.Drawing.Point(0, 0);
            this.spcContainter.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.spcContainter.Name = "spcContainter";
            this.spcContainter.Panel1.Controls.Add(this.grdProcessDef);
            this.spcContainter.Panel1.Text = "Panel1";
            this.spcContainter.Panel2.Controls.Add(this.grdProductMapping);
            this.spcContainter.Panel2.Text = "Panel2";
            this.spcContainter.Size = new System.Drawing.Size(509, 433);
            this.spcContainter.SplitterPosition = 354;
            this.spcContainter.TabIndex = 0;
            this.spcContainter.Text = "smartSpliterContainer1";
            // 
            // grdProcessDef
            // 
            this.grdProcessDef.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdProcessDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProcessDef.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdProcessDef.IsUsePaging = false;
            this.grdProcessDef.LanguageKey = "ROUTERDEFLIST";
            this.grdProcessDef.Location = new System.Drawing.Point(0, 0);
            this.grdProcessDef.Margin = new System.Windows.Forms.Padding(0);
            this.grdProcessDef.Name = "grdProcessDef";
            this.grdProcessDef.ShowBorder = true;
            this.grdProcessDef.Size = new System.Drawing.Size(509, 354);
            this.grdProcessDef.TabIndex = 0;
            // 
            // grdProductMapping
            // 
            this.grdProductMapping.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdProductMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProductMapping.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdProductMapping.IsUsePaging = false;
            this.grdProductMapping.LanguageKey = "PRODUCTMAPPINGLIST";
            this.grdProductMapping.Location = new System.Drawing.Point(0, 0);
            this.grdProductMapping.Margin = new System.Windows.Forms.Padding(0);
            this.grdProductMapping.Name = "grdProductMapping";
            this.grdProductMapping.ShowBorder = true;
            this.grdProductMapping.Size = new System.Drawing.Size(509, 74);
            this.grdProductMapping.TabIndex = 0;
            // 
            // ProcessDefinitionMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 482);
            this.Name = "ProcessDefinitionMgt";
            this.Text = "SmartConditionBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcContainter)).EndInit();
            this.spcContainter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer spcContainter;
        private Framework.SmartControls.SmartBandedGrid grdProcessDef;
        private Framework.SmartControls.SmartBandedGrid grdProductMapping;
    }
}