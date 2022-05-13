namespace Micube.SmartMES.StandardInfo
{
    partial class ScopeByItemPopup
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
            this.search = new Micube.Framework.SmartControls.SmartButton();
            this.smartLabelTextBox1 = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.close = new Micube.Framework.SmartControls.SmartButton();
            this.select = new Micube.Framework.SmartControls.SmartButton();
            this.smartSpliterControl2 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.grdItem = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.smartPanel3);
            this.pnlMain.Controls.Add(this.smartSpliterControl2);
            this.pnlMain.Controls.Add(this.smartPanel2);
            this.pnlMain.Controls.Add(this.smartSpliterControl1);
            this.pnlMain.Controls.Add(this.smartPanel1);
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.search);
            this.smartPanel1.Controls.Add(this.smartLabelTextBox1);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(780, 64);
            this.smartPanel1.TabIndex = 0;
            // 
            // search
            // 
            this.search.AllowFocus = false;
            this.search.IsBusy = false;
            this.search.IsWrite = false;
            this.search.Location = new System.Drawing.Point(331, 11);
            this.search.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.search.Name = "search";
            this.search.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.search.Size = new System.Drawing.Size(101, 37);
            this.search.TabIndex = 1;
            this.search.Text = "검색";
            this.search.TooltipLanguageKey = "";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // smartLabelTextBox1
            // 
       //     this.smartLabelTextBox1.CenterMargin = 10F;
            this.smartLabelTextBox1.Label.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.smartLabelTextBox1.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.smartLabelTextBox1.LabelText = "품목명";
            this.smartLabelTextBox1.LanguageKey = null;
            this.smartLabelTextBox1.Location = new System.Drawing.Point(16, 18);
            this.smartLabelTextBox1.Name = "smartLabelTextBox1";
            this.smartLabelTextBox1.Size = new System.Drawing.Size(291, 24);
            this.smartLabelTextBox1.TabIndex = 0;
            // 
            // smartSpliterControl1
            // 
            this.smartSpliterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartSpliterControl1.Location = new System.Drawing.Point(0, 64);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(780, 6);
            this.smartSpliterControl1.TabIndex = 1;
            this.smartSpliterControl1.TabStop = false;
            // 
            // smartPanel2
            // 
            this.smartPanel2.Controls.Add(this.close);
            this.smartPanel2.Controls.Add(this.select);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel2.Location = new System.Drawing.Point(0, 364);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(780, 66);
            this.smartPanel2.TabIndex = 2;
            // 
            // close
            // 
            this.close.AllowFocus = false;
            this.close.IsBusy = false;
            this.close.IsWrite = false;
            this.close.Location = new System.Drawing.Point(404, 12);
            this.close.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.close.Name = "close";
            this.close.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.close.Size = new System.Drawing.Size(134, 43);
            this.close.TabIndex = 1;
            this.close.Text = "닫기";
            this.close.TooltipLanguageKey = "";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // select
            // 
            this.select.AllowFocus = false;
            this.select.IsBusy = false;
            this.select.IsWrite = false;
            this.select.Location = new System.Drawing.Point(238, 12);
            this.select.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.select.Name = "select";
            this.select.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.select.Size = new System.Drawing.Size(134, 43);
            this.select.TabIndex = 0;
            this.select.Text = "선택";
            this.select.TooltipLanguageKey = "";
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // smartSpliterControl2
            // 
            this.smartSpliterControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartSpliterControl2.Location = new System.Drawing.Point(0, 358);
            this.smartSpliterControl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl2.Name = "smartSpliterControl2";
            this.smartSpliterControl2.Size = new System.Drawing.Size(780, 6);
            this.smartSpliterControl2.TabIndex = 3;
            this.smartSpliterControl2.TabStop = false;
            // 
            // smartPanel3
            // 
            this.smartPanel3.Controls.Add(this.grdItem);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartPanel3.Location = new System.Drawing.Point(0, 70);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(780, 288);
            this.smartPanel3.TabIndex = 4;
            // 
            // grdItem
            // 
            this.grdItem.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdItem.IsUsePaging = false;
            this.grdItem.LanguageKey = null;
            this.grdItem.Location = new System.Drawing.Point(2, 2);
            this.grdItem.Margin = new System.Windows.Forms.Padding(0);
            this.grdItem.Name = "grdItem";
            this.grdItem.ShowBorder = true;
            this.grdItem.Size = new System.Drawing.Size(776, 284);
            this.grdItem.TabIndex = 0;
            // 
            // ScopeByItemPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ScopeByItemPopup";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl2;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton close;
        private Framework.SmartControls.SmartButton select;
        private Framework.SmartControls.SmartButton search;
        private Framework.SmartControls.SmartLabelTextBox smartLabelTextBox1;
        private Framework.SmartControls.SmartBandedGrid grdItem;
    }
}