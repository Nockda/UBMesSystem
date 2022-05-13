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
using System.IO;

namespace Micube.SmartMES.StandardInfo
{
	public partial class InspectionStdImagePopup : SmartPopupBaseForm, ISmartCustomPopup
	{
		public DataRow CurrentDataRow { get; set; }

		public string _fileId = string.Empty;
		public string _inspectionType = string.Empty;

		public InspectionStdImagePopup()
		{
			InitializeComponent();

			InitializeEvent();

			InitializeControl();
			InitializeGrid();
		}

		/// <summary>
		/// 이벤트
		/// </summary>
		private void InitializeEvent()
		{
			btnSearch.Click += BtnSearch_Click;
			btnClose.Click += BtnClose_Click;
			btnConfirm.Click += BtnConfirm_Click;
			grdImageList.View.CheckStateChanged += View_CheckStateChanged;
			grdImageList.View.FocusedRowChanged += View_FocusedRowChanged;
			this.KeyDown += InspectionStdImagePopup_KeyDown;
			this.Load += InspectionStdImagePopup_Load;
		}

		/// <summary>
		/// Load
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InspectionStdImagePopup_Load(object sender, EventArgs e)
		{
			if(!string.IsNullOrWhiteSpace(_inspectionType))
			{
				cboInspectionType.EditValue = _inspectionType;
			}

			Search(_inspectionType, _fileId, null);
		}

		/// <summary>
		/// KEY DOWN 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InspectionStdImagePopup_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.F5)
			{
				Search(cboInspectionType.EditValue, null, txtFileName.EditValue);
			}
		}


		/// <summary>
		/// 포커스 이동 시 이미지 바인드
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			FocusRowDataBind();
		}

		/// <summary>
		/// 포커스 데이터(이미지) 바인드
		/// </summary>
		private void FocusRowDataBind()
		{
			DataRow row = grdImageList.View.GetFocusedDataRow();
			if (row == null) return;

			if (string.IsNullOrWhiteSpace(Format.GetString(row["FILEDATA"])))
			{
				picImage.Image = null;
				return;
			}

			try
			{
				this.ShowWaitArea();
				//DialogManager.ShowWaitDialog();

				MemoryStream ms = new MemoryStream(Convert.FromBase64String(Format.GetString(row["FILEDATA"])));
				picImage.Image = Image.FromStream(ms);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				this.CloseWaitArea();
				//DialogManager.Close();
			}
		}

		/// <summary>
		/// 한 ROW만 체크 가능하도록 강제
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_CheckStateChanged(object sender, EventArgs e)
		{
			grdImageList.View.CheckStateChanged -= View_CheckStateChanged;
			grdImageList.View.CheckedAll(false);
			grdImageList.View.CheckRow(grdImageList.View.GetFocusedDataSourceRowIndex(), true);
			grdImageList.View.CheckStateChanged += View_CheckStateChanged;

			DataTable dt = grdImageList.View.GetCheckedRows();
			if (dt.Rows.Count > 0)
			{
				this.CurrentDataRow = dt.Rows[0];
			}
			else
			{
				this.CurrentDataRow = null;
			}
		}

		/// <summary>
		/// 확인
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnConfirm_Click(object sender, EventArgs e)
		{
			DataTable dt = grdImageList.View.GetCheckedRows();
			if (dt.Rows.Count != 1)
			{
				//이미지를 체크하십시오.
				ShowMessage("SELECTIMAGE");
				return;
			}

			FireSelected(grdImageList.View);
			
			this.Close();
		}

		/// <summary>
		/// 닫기 클릭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 조회
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSearch_Click(object sender, EventArgs e)
		{
			Search(cboInspectionType.EditValue, null, txtFileName.EditValue);
		}

		/// <summary>
		/// 조회 함수
		/// </summary>
		/// <param name="inspectionType"></param>
		/// <param name="fileId"></param>
		/// <param name="fileName"></param>
		private void Search(object inspectionType, object fileId, object fileName)
		{
			this.ShowWaitArea();

			int prevHandle = grdImageList.View.FocusedRowHandle;

			Dictionary<string, object> param = new Dictionary<string, object>();
			param.Add("P_INSPECTIONTYPE", inspectionType);
			param.Add("FILEID", fileId);
			param.Add("FILENAME", fileName);

			grdImageList.DataSource = SqlExecuter.Query("SelectInspectionFileList", "00001", param);

			if((grdImageList.DataSource as DataTable).Rows.Count > 0)
			{
				grdImageList.View.FocusedRowHandle = prevHandle;
				FocusRowDataBind();
			}

			this.CloseWaitArea();
		}

		/// <summary>
		/// 컨트롤 초기화
		/// </summary>
		private void InitializeControl()
		{
			cboInspectionType.Editor.DisplayMember = "CODENAME";
			cboInspectionType.Editor.ValueMember = "CODEID";
			cboInspectionType.Editor.DataSource = SqlExecuter.Query("GetCodeList", "00001", new Dictionary<string, object>() { { "CODECLASSID", "MaterialInspCode" }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });
			cboInspectionType.Editor.UseEmptyItem = true;
			cboInspectionType.Editor.ShowHeader = false;
		}

		/// <summary>
		/// 그리드 초기화
		/// </summary>
		private void InitializeGrid()
		{
			grdImageList.View.OptionsSelection.MultiSelect = false;
			grdImageList.GridButtonItem = GridButtonItem.None;
			grdImageList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
			grdImageList.View.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
			grdImageList.View.CheckMarkSelection.ShowCheckBoxHeader = false;
			grdImageList.View.SetIsReadOnly();
			grdImageList.View.SetAutoFillColumn("FILENAME");

			grdImageList.View.AddComboBoxColumn("INSPECTIONTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=MaterialInspCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			grdImageList.View.AddTextBoxColumn("FILENAME", 150);
			grdImageList.View.AddTextBoxColumn("FILEID").SetIsHidden();
			grdImageList.View.AddTextBoxColumn("FILEDATA").SetIsHidden();

			grdImageList.View.PopulateColumns();
		}
	}
}
