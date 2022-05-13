namespace Micube.SmartMES.Process
{
    partial class EquipCheckRegPopup
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
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartButton1 = new Micube.Framework.SmartControls.SmartButton();
            this.smartLabelComboBox1 = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.smartLabelTextBox1 = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartButton2 = new Micube.Framework.SmartControls.SmartButton();
            this.smartButton3 = new Micube.Framework.SmartControls.SmartButton();
            this.grdCheckInfo = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelComboBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grdCheckInfo);
            this.pnlMain.Controls.Add(this.smartPanel3);
            this.pnlMain.Controls.Add(this.smartPanel2);
            this.pnlMain.Controls.Add(this.smartPanel1);
            // 
            // smartPanel1
            // 
            this.smartPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel1.Controls.Add(this.smartButton1);
            this.smartPanel1.Controls.Add(this.smartLabel1);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(780, 40);
            this.smartPanel1.TabIndex = 0;
            // 
            // smartLabel1
            // 
            this.smartLabel1.Location = new System.Drawing.Point(3, 14);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(88, 14);
            this.smartLabel1.TabIndex = 0;
            this.smartLabel1.Text = "설비보전 점검 등록";
            // 
            // smartPanel2
            // 
            this.smartPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel2.Controls.Add(this.smartLabelTextBox1);
            this.smartPanel2.Controls.Add(this.smartLabelComboBox1);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 40);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(780, 40);
            this.smartPanel2.TabIndex = 1;
            // 
            // smartButton1
            // 
            this.smartButton1.AllowFocus = false;
            this.smartButton1.IsBusy = false;
            this.smartButton1.IsWrite = false;
            this.smartButton1.Location = new System.Drawing.Point(697, 9);
            this.smartButton1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.smartButton1.Name = "smartButton1";
            this.smartButton1.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton1.Size = new System.Drawing.Size(80, 25);
            this.smartButton1.TabIndex = 1;
            this.smartButton1.Text = "조회";
            this.smartButton1.TooltipLanguageKey = "";
            // 
            // smartLabelComboBox1
            // 
        //    this.smartLabelComboBox1.CenterMargin = 10F;
            this.smartLabelComboBox1.Label.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.smartLabelComboBox1.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.smartLabelComboBox1.LabelText = "점검일자";
            this.smartLabelComboBox1.LanguageKey = null;
            this.smartLabelComboBox1.Location = new System.Drawing.Point(4, 7);
            this.smartLabelComboBox1.Name = "smartLabelComboBox1";
            this.smartLabelComboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.smartLabelComboBox1.Properties.NullText = "";
            this.smartLabelComboBox1.Size = new System.Drawing.Size(220, 20);
            this.smartLabelComboBox1.TabIndex = 0;
            // 
            // smartLabelTextBox1
            // 
        //    this.smartLabelTextBox1.CenterMargin = 10F;
            this.smartLabelTextBox1.Label.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.smartLabelTextBox1.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.smartLabelTextBox1.LabelText = "설비코드(명)";
            this.smartLabelTextBox1.LanguageKey = null;
            this.smartLabelTextBox1.Location = new System.Drawing.Point(277, 6);
            this.smartLabelTextBox1.Name = "smartLabelTextBox1";
            this.smartLabelTextBox1.Size = new System.Drawing.Size(409, 20);
            this.smartLabelTextBox1.TabIndex = 1;
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Controls.Add(this.smartButton3);
            this.smartPanel3.Controls.Add(this.smartButton2);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 390);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(780, 40);
            this.smartPanel3.TabIndex = 2;
            // 
            // smartButton2
            // 
            this.smartButton2.AllowFocus = false;
            this.smartButton2.IsBusy = false;
            this.smartButton2.IsWrite = false;
            this.smartButton2.Location = new System.Drawing.Point(697, 9);
            this.smartButton2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.smartButton2.Name = "smartButton2";
            this.smartButton2.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton2.Size = new System.Drawing.Size(80, 25);
            this.smartButton2.TabIndex = 1;
            this.smartButton2.Text = "취소";
            this.smartButton2.TooltipLanguageKey = "";
            // 
            // smartButton3
            // 
            this.smartButton3.AllowFocus = false;
            this.smartButton3.IsBusy = false;
            this.smartButton3.IsWrite = false;
            this.smartButton3.Location = new System.Drawing.Point(611, 9);
            this.smartButton3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.smartButton3.Name = "smartButton3";
            this.smartButton3.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton3.Size = new System.Drawing.Size(80, 25);
            this.smartButton3.TabIndex = 2;
            this.smartButton3.Text = "저장";
            this.smartButton3.TooltipLanguageKey = "";
            // 
            // grdCheckInfo
            // 
            this.grdCheckInfo.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdCheckInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCheckInfo.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdCheckInfo.IsUsePaging = false;
            this.grdCheckInfo.LanguageKey = null;
            this.grdCheckInfo.Location = new System.Drawing.Point(0, 80);
            this.grdCheckInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grdCheckInfo.Name = "grdCheckInfo";
            this.grdCheckInfo.ShowBorder = true;
            this.grdCheckInfo.Size = new System.Drawing.Size(780, 310);
            this.grdCheckInfo.TabIndex = 3;
            // 
            // EquipCheckRegPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "EquipCheckRegPopup";
            this.Text = "EquipCheckRegPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            this.smartPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelComboBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartButton smartButton1;
        private Framework.SmartControls.SmartBandedGrid grdCheckInfo;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton smartButton3;
        private Framework.SmartControls.SmartButton smartButton2;
        private Framework.SmartControls.SmartLabelTextBox smartLabelTextBox1;
        private Framework.SmartControls.SmartLabelComboBox smartLabelComboBox1;
    }
}