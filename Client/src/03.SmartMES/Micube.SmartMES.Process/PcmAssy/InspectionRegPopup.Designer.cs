namespace Micube.SmartMES.Process
{
    partial class InspectionRegPopup
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
            this.smartGroupBox1 = new Micube.Framework.SmartControls.SmartGroupBox();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartLabelTextBox1 = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartLabelTextBox2 = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartLabelTextBox3 = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartLabelTextBox4 = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartButton1 = new Micube.Framework.SmartControls.SmartButton();
            this.smartButton2 = new Micube.Framework.SmartControls.SmartButton();
            this.grdInsp = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartGroupBox1)).BeginInit();
            this.smartGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.smartGroupBox1);
            this.pnlMain.Size = new System.Drawing.Size(1279, 430);
            // 
            // smartGroupBox1
            // 
            this.smartGroupBox1.Controls.Add(this.grdInsp);
            this.smartGroupBox1.Controls.Add(this.smartPanel2);
            this.smartGroupBox1.Controls.Add(this.smartPanel1);
            this.smartGroupBox1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.smartGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartGroupBox1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.smartGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.smartGroupBox1.Name = "smartGroupBox1";
            this.smartGroupBox1.ShowBorder = true;
            this.smartGroupBox1.Size = new System.Drawing.Size(1279, 430);
            this.smartGroupBox1.TabIndex = 0;
            this.smartGroupBox1.Text = "검사실적 등록";
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.smartLabelTextBox4);
            this.smartPanel1.Controls.Add(this.smartLabelTextBox3);
            this.smartPanel1.Controls.Add(this.smartLabelTextBox2);
            this.smartPanel1.Controls.Add(this.smartLabelTextBox1);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(2, 31);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(1275, 30);
            this.smartPanel1.TabIndex = 0;
            // 
            // smartLabelTextBox1
            // 
        //    this.smartLabelTextBox1.CenterMargin = 10F;
            this.smartLabelTextBox1.Label.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.smartLabelTextBox1.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.smartLabelTextBox1.LabelText = "LOT번호";
            this.smartLabelTextBox1.LanguageKey = null;
            this.smartLabelTextBox1.Location = new System.Drawing.Point(5, 5);
            this.smartLabelTextBox1.Name = "smartLabelTextBox1";
            this.smartLabelTextBox1.Size = new System.Drawing.Size(182, 20);
            this.smartLabelTextBox1.TabIndex = 1;
            // 
            // smartLabelTextBox2
            // 
         //   this.smartLabelTextBox2.CenterMargin = 10F;
            this.smartLabelTextBox2.Label.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.smartLabelTextBox2.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.smartLabelTextBox2.LabelText = "품목명";
            this.smartLabelTextBox2.LanguageKey = null;
            this.smartLabelTextBox2.Location = new System.Drawing.Point(207, 5);
            this.smartLabelTextBox2.Name = "smartLabelTextBox2";
            this.smartLabelTextBox2.Size = new System.Drawing.Size(353, 20);
            this.smartLabelTextBox2.TabIndex = 2;
            // 
            // smartLabelTextBox3
            // 
      //      this.smartLabelTextBox3.CenterMargin = 10F;
            this.smartLabelTextBox3.Label.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.smartLabelTextBox3.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.smartLabelTextBox3.LabelText = "SUB공정";
            this.smartLabelTextBox3.LanguageKey = null;
            this.smartLabelTextBox3.Location = new System.Drawing.Point(580, 5);
            this.smartLabelTextBox3.Name = "smartLabelTextBox3";
            this.smartLabelTextBox3.Size = new System.Drawing.Size(182, 20);
            this.smartLabelTextBox3.TabIndex = 3;
            // 
            // smartLabelTextBox4
            // 
    //        this.smartLabelTextBox4.CenterMargin = 10F;
            this.smartLabelTextBox4.Label.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.smartLabelTextBox4.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.smartLabelTextBox4.LabelText = "기종";
            this.smartLabelTextBox4.LanguageKey = null;
            this.smartLabelTextBox4.Location = new System.Drawing.Point(782, 5);
            this.smartLabelTextBox4.Name = "smartLabelTextBox4";
            this.smartLabelTextBox4.Size = new System.Drawing.Size(182, 20);
            this.smartLabelTextBox4.TabIndex = 4;
            // 
            // smartPanel2
            // 
            this.smartPanel2.Controls.Add(this.smartButton2);
            this.smartPanel2.Controls.Add(this.smartButton1);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel2.Location = new System.Drawing.Point(2, 398);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(1275, 30);
            this.smartPanel2.TabIndex = 1;
            // 
            // smartButton1
            // 
            this.smartButton1.AllowFocus = false;
            this.smartButton1.IsBusy = false;
            this.smartButton1.IsWrite = false;
            this.smartButton1.Location = new System.Drawing.Point(1190, 3);
            this.smartButton1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.smartButton1.Name = "smartButton1";
            this.smartButton1.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton1.Size = new System.Drawing.Size(80, 25);
            this.smartButton1.TabIndex = 0;
            this.smartButton1.Text = "취소";
            this.smartButton1.TooltipLanguageKey = "";
            // 
            // smartButton2
            // 
            this.smartButton2.AllowFocus = false;
            this.smartButton2.IsBusy = false;
            this.smartButton2.IsWrite = false;
            this.smartButton2.Location = new System.Drawing.Point(1104, 3);
            this.smartButton2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.smartButton2.Name = "smartButton2";
            this.smartButton2.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton2.Size = new System.Drawing.Size(80, 25);
            this.smartButton2.TabIndex = 1;
            this.smartButton2.Text = "저장";
            this.smartButton2.TooltipLanguageKey = "";
            // 
            // grdInsp
            // 
            this.grdInsp.Caption = "검사측정 정보";
            this.grdInsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInsp.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdInsp.IsUsePaging = false;
            this.grdInsp.LanguageKey = null;
            this.grdInsp.Location = new System.Drawing.Point(2, 61);
            this.grdInsp.Margin = new System.Windows.Forms.Padding(0);
            this.grdInsp.Name = "grdInsp";
            this.grdInsp.ShowBorder = true;
            this.grdInsp.Size = new System.Drawing.Size(1275, 337);
            this.grdInsp.TabIndex = 2;
            // 
            // InspectionRegPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 450);
            this.Name = "InspectionRegPopup";
            this.Text = "InspectionRegPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartGroupBox1)).EndInit();
            this.smartGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartGroupBox smartGroupBox1;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartLabelTextBox smartLabelTextBox4;
        private Framework.SmartControls.SmartLabelTextBox smartLabelTextBox3;
        private Framework.SmartControls.SmartLabelTextBox smartLabelTextBox2;
        private Framework.SmartControls.SmartLabelTextBox smartLabelTextBox1;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartButton smartButton2;
        private Framework.SmartControls.SmartButton smartButton1;
        private Framework.SmartControls.SmartBandedGrid grdInsp;
    }
}