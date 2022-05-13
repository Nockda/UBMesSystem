using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Micube.Framework.SmartControls;
using Micube.Framework.Net;
using Micube.Framework;

namespace Micube.SmartMES.Equipment
{
	public partial class EquipmentStateDetailPopup : SmartPopupBaseForm, ISmartCustomPopup
	{
		public DataRow CurrentDataRow { get; set; }
		public string EquipmentId { get; set; }
		public string EquipmentName { get; set; }

		public EquipmentStateDetailPopup()
		{
			InitializeComponent();

			InitControls();
			InitGrid();
			IntiEvent();
		}

		/// <summary>
		/// 컨트롤 초기화
		/// </summary>
		private void InitControls()
		{
			lblEquipmentName.Tag = "EQUIPMENTNAME";
			txtProductDefId.Tag = "PARTNUMBER";
			txtProductDefName.Tag = "PRODUCTDEFNAME";
			txtStandard.Tag = "STANDARD";
			txtModelName.Tag = "MODELNAME";
			txtTrackInTime.Tag = "TRACKINTIME";
			txtWorkTime.Tag = "WORKTIME";

			lblEquipmentName.Text = string.Empty;
			txtProductDefId.EditValue = string.Empty;
			txtProductDefName.EditValue = string.Empty;
			txtStandard.EditValue = string.Empty;
			txtModelName.EditValue = string.Empty;
			txtTrackInTime.EditValue = string.Empty;
			txtWorkTime.EditValue = string.Empty;
		}

		/// <summary>
		/// 그리드 초기화
		/// </summary>
		private void InitGrid()
		{
			grdAlarmInfo.GridButtonItem = GridButtonItem.None;
			grdAlarmInfo.View.SetIsReadOnly();

			//알람ID
			grdAlarmInfo.View.AddTextBoxColumn("ALARMID", 100);
			//알람명
			grdAlarmInfo.View.AddTextBoxColumn("ALARMNAME", 150);
			//발생일시
			grdAlarmInfo.View.AddTextBoxColumn("OCCURETIME", 150).SetTextAlignment(TextAlignment.Center).SetLabel("OCCURRDATETIME");

			grdAlarmInfo.View.PopulateColumns();
		}

		private void IntiEvent()
		{
			this.Shown += EquipmentStateDetailPopup_Shown;
			btnClose.Click += BtnClose_Click;
		}

		/// <summary>
		/// 설비 디테일 정보 조회
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EquipmentStateDetailPopup_Shown(object sender, EventArgs e)
		{
			if(string.IsNullOrWhiteSpace(EquipmentId)) return;

			lblEquipmentName.Text = EquipmentName;

			DataTable detailDt = SqlExecuter.Query("SelectEquipmentStateDetail", "00001", new Dictionary<string, object>(){ { "EQUIPMENTID", EquipmentId },
																										{ "LANGUAGETYPE", UserInfo.Current.LanguageType } });
			if(detailDt.Rows.Count > 0)
			{
				Commons.CommonFunction.BindDataToControlsTag(detailDt.AsEnumerable().First(), tlpEquipmentInfo);
			}

			grdAlarmInfo.DataSource = SqlExecuter.Query("SelectEquipmentAlarmList", "00001", new Dictionary<string, object>() { { "EQUIPMENTID", EquipmentId } });
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
