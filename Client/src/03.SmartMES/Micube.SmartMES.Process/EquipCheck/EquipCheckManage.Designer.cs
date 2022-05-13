namespace Micube.SmartMES.Process
{
    partial class EquipCheckManage
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
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartLabelTextBox2 = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartLabelTextBox1 = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.grdCheck = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.grdResult = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 397);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(792, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.grdResult);
            this.pnlContent.Controls.Add(this.smartSpliterControl1);
            this.pnlContent.Controls.Add(this.smartPanel2);
            this.pnlContent.Controls.Add(this.smartPanel1);
            this.pnlContent.Size = new System.Drawing.Size(792, 401);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(1097, 430);
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.smartLabel1);
            this.smartPanel1.Controls.Add(this.smartLabelTextBox2);
            this.smartPanel1.Controls.Add(this.smartLabelTextBox1);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(792, 27);
            this.smartPanel1.TabIndex = 0;
            // 
            // smartLabel1
            // 
            this.smartLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartLabel1.Location = new System.Drawing.Point(582, 2);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(208, 14);
            this.smartLabel1.TabIndex = 2;
            this.smartLabel1.Text = "※ 양호(O), 불량(X), 수리완료(Y), 조정(r)";
            // 
            // smartLabelTextBox2
            // 
          //  this.smartLabelTextBox2.CenterMargin = 10F;
            this.smartLabelTextBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.smartLabelTextBox2.Label.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.smartLabelTextBox2.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.smartLabelTextBox2.LabelHAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.smartLabelTextBox2.LabelText = "설비그룹 : ";
            this.smartLabelTextBox2.LanguageKey = null;
            this.smartLabelTextBox2.Location = new System.Drawing.Point(366, 2);
            this.smartLabelTextBox2.Name = "smartLabelTextBox2";
            this.smartLabelTextBox2.Size = new System.Drawing.Size(220, 20);
            this.smartLabelTextBox2.TabIndex = 1;
            // 
            // smartLabelTextBox1
            // 
        //    this.smartLabelTextBox1.CenterMargin = 10F;
            this.smartLabelTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.smartLabelTextBox1.Label.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.smartLabelTextBox1.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.smartLabelTextBox1.LabelHAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.smartLabelTextBox1.LabelText = "설비명 :";
            this.smartLabelTextBox1.LanguageKey = null;
            this.smartLabelTextBox1.Location = new System.Drawing.Point(2, 2);
            this.smartLabelTextBox1.Name = "smartLabelTextBox1";
            this.smartLabelTextBox1.Size = new System.Drawing.Size(364, 20);
            this.smartLabelTextBox1.TabIndex = 0;
            // 
            // smartPanel2
            // 
            this.smartPanel2.Controls.Add(this.grdCheck);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 27);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(792, 176);
            this.smartPanel2.TabIndex = 1;
            // 
            // grdCheck
            // 
            this.grdCheck.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCheck.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdCheck.IsUsePaging = false;
            this.grdCheck.LanguageKey = null;
            this.grdCheck.Location = new System.Drawing.Point(2, 2);
            this.grdCheck.Margin = new System.Windows.Forms.Padding(0);
            this.grdCheck.Name = "grdCheck";
            this.grdCheck.ShowBorder = true;
            this.grdCheck.Size = new System.Drawing.Size(788, 172);
            this.grdCheck.TabIndex = 0;
            // 
            // smartSpliterControl1
            // 
            this.smartSpliterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartSpliterControl1.Location = new System.Drawing.Point(0, 203);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(792, 5);
            this.smartSpliterControl1.TabIndex = 2;
            this.smartSpliterControl1.TabStop = false;
            // 
            // grdResult
            // 
            this.grdResult.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdResult.IsUsePaging = false;
            this.grdResult.LanguageKey = null;
            this.grdResult.Location = new System.Drawing.Point(0, 208);
            this.grdResult.Margin = new System.Windows.Forms.Padding(0);
            this.grdResult.Name = "grdResult";
            this.grdResult.ShowBorder = true;
            this.grdResult.Size = new System.Drawing.Size(792, 193);
            this.grdResult.TabIndex = 3;
            // 
            // EquipCheckManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 450);
            this.Name = "EquipCheckManage";
            this.Text = "EquipCheckManage";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            this.smartPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartBandedGrid grdResult;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartBandedGrid grdCheck;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartLabelTextBox smartLabelTextBox2;
        private Framework.SmartControls.SmartLabelTextBox smartLabelTextBox1;
    }
}