namespace Micube.SmartMES.Equipment
{
	partial class EquipmentMonitoring
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
			this.timer = new System.Windows.Forms.Timer();
			this.diagramControl = new Micube.Framework.SmartControls.SmartDiagramControl();
			((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
			this.pnlContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.diagramControl)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlCondition
			// 
			this.pnlCondition.Location = new System.Drawing.Point(0, 30);
			this.pnlCondition.Size = new System.Drawing.Size(0, 0);
			// 
			// pnlToolbar
			// 
			this.pnlToolbar.Size = new System.Drawing.Size(1231, 24);
			// 
			// pnlContent
			// 
			this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.pnlContent.Appearance.Options.UseBackColor = true;
			this.pnlContent.Controls.Add(this.diagramControl);
			this.pnlContent.Size = new System.Drawing.Size(1231, 653);
			// 
			// pnlMain
			// 
			this.pnlMain.Size = new System.Drawing.Size(1231, 682);
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			// 
			// diagramControl
			// 
			this.diagramControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.diagramControl.IsReadOnly = false;
			this.diagramControl.Location = new System.Drawing.Point(0, 0);
			this.diagramControl.Margin = new System.Windows.Forms.Padding(0);
			this.diagramControl.Name = "diagramControl";
			this.diagramControl.OptionsBehavior.SelectedStencils = new DevExpress.Diagram.Core.StencilCollection(new string[] {
            "BasicShapes",
            "BasicFlowchartShapes"});
			this.diagramControl.OptionsView.PageMargin = new System.Windows.Forms.Padding(0);
			this.diagramControl.OptionsView.PageSize = new System.Drawing.SizeF(1470F, 1000F);
			this.diagramControl.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Custom;
			this.diagramControl.OptionsView.ShowGrid = false;
			this.diagramControl.OptionsView.ShowPageBreaks = false;
			this.diagramControl.OptionsView.ShowRulers = false;
			this.diagramControl.OptionsView.Theme = DevExpress.Diagram.Core.DiagramThemes.NoTheme;
			this.diagramControl.Size = new System.Drawing.Size(1231, 653);
			this.diagramControl.TabIndex = 1;
			this.diagramControl.Text = "smartDiagramControl1";
			// 
			// EquipmentMonitoring
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1251, 702);
			this.ConditionsVisible = false;
			this.Name = "EquipmentMonitoring";
			this.Text = "SmartConditionBaseForm";
			((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
			this.pnlContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.diagramControl)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer timer;
		private Framework.SmartControls.SmartDiagramControl diagramControl;
	}
}