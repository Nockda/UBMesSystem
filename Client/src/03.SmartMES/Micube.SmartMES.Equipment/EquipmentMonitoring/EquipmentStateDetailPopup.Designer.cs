namespace Micube.SmartMES.Equipment
{
	partial class EquipmentStateDetailPopup
	{
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 구성 요소 디자이너에서 생성한 코드

		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.tplDetailPopup = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
			this.grdAlarmInfo = new Micube.Framework.SmartControls.SmartBandedGrid();
			this.pnlButton = new System.Windows.Forms.FlowLayoutPanel();
			this.btnClose = new Micube.Framework.SmartControls.SmartButton();
			this.tlpEquipmentInfo = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
			this.lblEquipmentName = new Micube.Framework.SmartControls.SmartLabel();
			this.lblProductDefId = new Micube.Framework.SmartControls.SmartLabel();
			this.lblProductDefName = new Micube.Framework.SmartControls.SmartLabel();
			this.lblStandard = new Micube.Framework.SmartControls.SmartLabel();
			this.lblModelName = new Micube.Framework.SmartControls.SmartLabel();
			this.lblTrackInTime = new Micube.Framework.SmartControls.SmartLabel();
			this.lblWorkTime = new Micube.Framework.SmartControls.SmartLabel();
			this.txtProductDefId = new Micube.Framework.SmartControls.SmartTextBox();
			this.txtProductDefName = new Micube.Framework.SmartControls.SmartTextBox();
			this.txtStandard = new Micube.Framework.SmartControls.SmartTextBox();
			this.txtModelName = new Micube.Framework.SmartControls.SmartTextBox();
			this.txtTrackInTime = new Micube.Framework.SmartControls.SmartTextBox();
			this.txtWorkTime = new Micube.Framework.SmartControls.SmartTextBox();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.SuspendLayout();
			this.tplDetailPopup.SuspendLayout();
			this.pnlButton.SuspendLayout();
			this.tlpEquipmentInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtProductDefId.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtProductDefName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStandard.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtModelName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTrackInTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtWorkTime.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.tplDetailPopup);
			this.pnlMain.Size = new System.Drawing.Size(632, 407);
			// 
			// tplDetailPopup
			// 
			this.tplDetailPopup.ColumnCount = 1;
			this.tplDetailPopup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tplDetailPopup.Controls.Add(this.grdAlarmInfo, 0, 1);
			this.tplDetailPopup.Controls.Add(this.pnlButton, 0, 3);
			this.tplDetailPopup.Controls.Add(this.tlpEquipmentInfo, 0, 0);
			this.tplDetailPopup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tplDetailPopup.Location = new System.Drawing.Point(0, 0);
			this.tplDetailPopup.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.tplDetailPopup.Name = "tplDetailPopup";
			this.tplDetailPopup.RowCount = 4;
			this.tplDetailPopup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
			this.tplDetailPopup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tplDetailPopup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tplDetailPopup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tplDetailPopup.Size = new System.Drawing.Size(632, 407);
			this.tplDetailPopup.TabIndex = 0;
			// 
			// grdAlarmInfo
			// 
			this.grdAlarmInfo.Caption = "그리드제목( LanguageKey를 입력하세요)";
			this.grdAlarmInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAlarmInfo.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
			this.grdAlarmInfo.IsUsePaging = false;
			this.grdAlarmInfo.LanguageKey = "ALARMLIST";
			this.grdAlarmInfo.Location = new System.Drawing.Point(0, 170);
			this.grdAlarmInfo.Margin = new System.Windows.Forms.Padding(0);
			this.grdAlarmInfo.Name = "grdAlarmInfo";
			this.grdAlarmInfo.ShowBorder = true;
			this.grdAlarmInfo.Size = new System.Drawing.Size(632, 197);
			this.grdAlarmInfo.TabIndex = 1;
			this.grdAlarmInfo.UseAutoBestFitColumns = false;
			// 
			// pnlButton
			// 
			this.pnlButton.Controls.Add(this.btnClose);
			this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.pnlButton.Location = new System.Drawing.Point(3, 380);
			this.pnlButton.Name = "pnlButton";
			this.pnlButton.Size = new System.Drawing.Size(626, 24);
			this.pnlButton.TabIndex = 2;
			// 
			// btnClose
			// 
			this.btnClose.AllowFocus = false;
			this.btnClose.IsBusy = false;
			this.btnClose.IsWrite = false;
			this.btnClose.LanguageKey = "CLOSE";
			this.btnClose.Location = new System.Drawing.Point(548, 0);
			this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "닫기";
			this.btnClose.TooltipLanguageKey = "";
			// 
			// tlpEquipmentInfo
			// 
			this.tlpEquipmentInfo.ColumnCount = 7;
			this.tlpEquipmentInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpEquipmentInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpEquipmentInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpEquipmentInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpEquipmentInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpEquipmentInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpEquipmentInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpEquipmentInfo.Controls.Add(this.lblEquipmentName, 0, 0);
			this.tlpEquipmentInfo.Controls.Add(this.lblProductDefId, 0, 2);
			this.tlpEquipmentInfo.Controls.Add(this.lblProductDefName, 3, 2);
			this.tlpEquipmentInfo.Controls.Add(this.lblStandard, 0, 4);
			this.tlpEquipmentInfo.Controls.Add(this.lblModelName, 3, 4);
			this.tlpEquipmentInfo.Controls.Add(this.lblTrackInTime, 0, 6);
			this.tlpEquipmentInfo.Controls.Add(this.lblWorkTime, 3, 6);
			this.tlpEquipmentInfo.Controls.Add(this.txtProductDefId, 1, 2);
			this.tlpEquipmentInfo.Controls.Add(this.txtProductDefName, 4, 2);
			this.tlpEquipmentInfo.Controls.Add(this.txtStandard, 1, 4);
			this.tlpEquipmentInfo.Controls.Add(this.txtModelName, 4, 4);
			this.tlpEquipmentInfo.Controls.Add(this.txtTrackInTime, 1, 6);
			this.tlpEquipmentInfo.Controls.Add(this.txtWorkTime, 4, 6);
			this.tlpEquipmentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpEquipmentInfo.Location = new System.Drawing.Point(0, 0);
			this.tlpEquipmentInfo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.tlpEquipmentInfo.Name = "tlpEquipmentInfo";
			this.tlpEquipmentInfo.RowCount = 8;
			this.tlpEquipmentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tlpEquipmentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEquipmentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpEquipmentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEquipmentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpEquipmentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEquipmentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpEquipmentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEquipmentInfo.Size = new System.Drawing.Size(632, 170);
			this.tlpEquipmentInfo.TabIndex = 3;
			// 
			// lblEquipmentName
			// 
			this.lblEquipmentName.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblEquipmentName.Appearance.Options.UseFont = true;
			this.lblEquipmentName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.tlpEquipmentInfo.SetColumnSpan(this.lblEquipmentName, 7);
			this.lblEquipmentName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblEquipmentName.Location = new System.Drawing.Point(3, 3);
			this.lblEquipmentName.Name = "lblEquipmentName";
			this.lblEquipmentName.Size = new System.Drawing.Size(626, 34);
			this.lblEquipmentName.TabIndex = 0;
			this.lblEquipmentName.Text = "설비명";
			// 
			// lblProductDefId
			// 
			this.lblProductDefId.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblProductDefId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblProductDefId.LanguageKey = "PRODUCTDEFID";
			this.lblProductDefId.Location = new System.Drawing.Point(3, 53);
			this.lblProductDefId.Name = "lblProductDefId";
			this.lblProductDefId.Size = new System.Drawing.Size(84, 24);
			this.lblProductDefId.TabIndex = 1;
			this.lblProductDefId.Text = "품목코드";
			// 
			// lblProductDefName
			// 
			this.lblProductDefName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblProductDefName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblProductDefName.LanguageKey = "PRODUCTDEFNAME";
			this.lblProductDefName.Location = new System.Drawing.Point(273, 53);
			this.lblProductDefName.Name = "lblProductDefName";
			this.lblProductDefName.Size = new System.Drawing.Size(84, 24);
			this.lblProductDefName.TabIndex = 2;
			this.lblProductDefName.Text = "품목명";
			// 
			// lblStandard
			// 
			this.lblStandard.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblStandard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblStandard.LanguageKey = "STANDARD";
			this.lblStandard.Location = new System.Drawing.Point(3, 93);
			this.lblStandard.Name = "lblStandard";
			this.lblStandard.Size = new System.Drawing.Size(84, 24);
			this.lblStandard.TabIndex = 3;
			this.lblStandard.Text = "규격";
			// 
			// lblModelName
			// 
			this.lblModelName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblModelName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblModelName.LanguageKey = "MODELID";
			this.lblModelName.Location = new System.Drawing.Point(273, 93);
			this.lblModelName.Name = "lblModelName";
			this.lblModelName.Size = new System.Drawing.Size(84, 24);
			this.lblModelName.TabIndex = 4;
			this.lblModelName.Text = "기종";
			// 
			// lblTrackInTime
			// 
			this.lblTrackInTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblTrackInTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTrackInTime.LanguageKey = "TRACKINTIME";
			this.lblTrackInTime.Location = new System.Drawing.Point(3, 133);
			this.lblTrackInTime.Name = "lblTrackInTime";
			this.lblTrackInTime.Size = new System.Drawing.Size(84, 24);
			this.lblTrackInTime.TabIndex = 5;
			this.lblTrackInTime.Text = "작업시작일시";
			// 
			// lblWorkTime
			// 
			this.lblWorkTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblWorkTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblWorkTime.LanguageKey = "WORKTIME2";
			this.lblWorkTime.Location = new System.Drawing.Point(273, 133);
			this.lblWorkTime.Name = "lblWorkTime";
			this.lblWorkTime.Size = new System.Drawing.Size(84, 24);
			this.lblWorkTime.TabIndex = 6;
			this.lblWorkTime.Text = "작업시간(h)";
			// 
			// txtProductDefId
			// 
			this.tlpEquipmentInfo.SetColumnSpan(this.txtProductDefId, 2);
			this.txtProductDefId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtProductDefId.LabelText = null;
			this.txtProductDefId.LanguageKey = null;
			this.txtProductDefId.Location = new System.Drawing.Point(93, 53);
			this.txtProductDefId.Name = "txtProductDefId";
			this.txtProductDefId.Properties.AutoHeight = false;
			this.txtProductDefId.Properties.ReadOnly = true;
			this.txtProductDefId.Size = new System.Drawing.Size(174, 24);
			this.txtProductDefId.TabIndex = 7;
			// 
			// txtProductDefName
			// 
			this.tlpEquipmentInfo.SetColumnSpan(this.txtProductDefName, 3);
			this.txtProductDefName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtProductDefName.LabelText = null;
			this.txtProductDefName.LanguageKey = null;
			this.txtProductDefName.Location = new System.Drawing.Point(363, 53);
			this.txtProductDefName.Name = "txtProductDefName";
			this.txtProductDefName.Properties.AutoHeight = false;
			this.txtProductDefName.Properties.ReadOnly = true;
			this.txtProductDefName.Size = new System.Drawing.Size(266, 24);
			this.txtProductDefName.TabIndex = 8;
			// 
			// txtStandard
			// 
			this.tlpEquipmentInfo.SetColumnSpan(this.txtStandard, 2);
			this.txtStandard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtStandard.LabelText = null;
			this.txtStandard.LanguageKey = null;
			this.txtStandard.Location = new System.Drawing.Point(93, 93);
			this.txtStandard.Name = "txtStandard";
			this.txtStandard.Properties.AutoHeight = false;
			this.txtStandard.Properties.ReadOnly = true;
			this.txtStandard.Size = new System.Drawing.Size(174, 24);
			this.txtStandard.TabIndex = 9;
			// 
			// txtModelName
			// 
			this.tlpEquipmentInfo.SetColumnSpan(this.txtModelName, 3);
			this.txtModelName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtModelName.LabelText = null;
			this.txtModelName.LanguageKey = null;
			this.txtModelName.Location = new System.Drawing.Point(363, 93);
			this.txtModelName.Name = "txtModelName";
			this.txtModelName.Properties.AutoHeight = false;
			this.txtModelName.Properties.ReadOnly = true;
			this.txtModelName.Size = new System.Drawing.Size(266, 24);
			this.txtModelName.TabIndex = 10;
			// 
			// txtTrackInTime
			// 
			this.tlpEquipmentInfo.SetColumnSpan(this.txtTrackInTime, 2);
			this.txtTrackInTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtTrackInTime.LabelText = null;
			this.txtTrackInTime.LanguageKey = null;
			this.txtTrackInTime.Location = new System.Drawing.Point(93, 133);
			this.txtTrackInTime.Name = "txtTrackInTime";
			this.txtTrackInTime.Properties.AutoHeight = false;
			this.txtTrackInTime.Properties.ReadOnly = true;
			this.txtTrackInTime.Size = new System.Drawing.Size(174, 24);
			this.txtTrackInTime.TabIndex = 11;
			// 
			// txtWorkTime
			// 
			this.tlpEquipmentInfo.SetColumnSpan(this.txtWorkTime, 3);
			this.txtWorkTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtWorkTime.LabelText = null;
			this.txtWorkTime.LanguageKey = null;
			this.txtWorkTime.Location = new System.Drawing.Point(363, 133);
			this.txtWorkTime.Name = "txtWorkTime";
			this.txtWorkTime.Properties.AutoHeight = false;
			this.txtWorkTime.Properties.ReadOnly = true;
			this.txtWorkTime.Size = new System.Drawing.Size(266, 24);
			this.txtWorkTime.TabIndex = 12;
			// 
			// EquipmentStateDetailPopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(652, 427);
			this.LanguageKey = "EQUIPMENTSTATEDETAILPOPUP";
			this.Name = "EquipmentStateDetailPopup";
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.tplDetailPopup.ResumeLayout(false);
			this.pnlButton.ResumeLayout(false);
			this.tlpEquipmentInfo.ResumeLayout(false);
			this.tlpEquipmentInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtProductDefId.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtProductDefName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStandard.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtModelName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTrackInTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtWorkTime.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Framework.SmartControls.SmartSplitTableLayoutPanel tplDetailPopup;
		private Framework.SmartControls.SmartBandedGrid grdAlarmInfo;
		private System.Windows.Forms.FlowLayoutPanel pnlButton;
		private Framework.SmartControls.SmartButton btnClose;
		private Framework.SmartControls.SmartSplitTableLayoutPanel tlpEquipmentInfo;
		private Framework.SmartControls.SmartLabel lblEquipmentName;
		private Framework.SmartControls.SmartLabel lblProductDefId;
		private Framework.SmartControls.SmartLabel lblProductDefName;
		private Framework.SmartControls.SmartLabel lblStandard;
		private Framework.SmartControls.SmartLabel lblModelName;
		private Framework.SmartControls.SmartLabel lblTrackInTime;
		private Framework.SmartControls.SmartLabel lblWorkTime;
		private Framework.SmartControls.SmartTextBox txtProductDefId;
		private Framework.SmartControls.SmartTextBox txtProductDefName;
		private Framework.SmartControls.SmartTextBox txtStandard;
		private Framework.SmartControls.SmartTextBox txtModelName;
		private Framework.SmartControls.SmartTextBox txtTrackInTime;
		private Framework.SmartControls.SmartTextBox txtWorkTime;
	}
}
