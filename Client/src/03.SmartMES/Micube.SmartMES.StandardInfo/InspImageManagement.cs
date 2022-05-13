#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.StandardInfo
{
	/// <summary>
	/// 프 로 그 램 명  : 기준정보 > 항목 관리 > 검사 기준 이미지 등록
	/// 업  무  설  명  : 검사 구분에 따라 기준 이미지 등록
	/// 생    성    자  : 정승원
	/// 생    성    일  : 2020-05-28
	/// 수  정  이  력  : 
	/// 
	/// 
	/// </summary>
	public partial class InspImageManagement : SmartConditionBaseForm
	{
		#region 생성자
		public InspImageManagement()
		{
			InitializeComponent();
		}

		#endregion

		#region 컨텐츠 영역 초기화

		/// <summary>
		/// 화면의 컨텐츠 영역을 초기화한다.
		/// </summary>
		protected override void InitializeContent()
		{
			base.InitializeContent();

			InitializeEvent();

			// TODO : 컨트롤 초기화 로직 구성
			InitializeGrid();
		}

		/// <summary>        
		/// 그리드를 초기화한다.
		/// </summary>
		private void InitializeGrid()
		{
			// TODO : 그리드 초기화 로직 추가
			grdInspList.GridButtonItem = GridButtonItem.All;
			grdInspList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

			//검사구분
			grdInspList.View.AddComboBoxColumn("INSPECTIONTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=MaterialInspCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetTextAlignment(TextAlignment.Center).SetValidationIsRequired().SetValidationKeyColumn();
			//기준서명
			grdInspList.View.AddTextBoxColumn("FILENAME", 200).SetLabel("INSPECTIONSTDNAME");

			//유효
			//grdInspList.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetDefault("Valid").SetValidationIsRequired().SetTextAlignment(TextAlignment.Center);
			//생성자
			grdInspList.View.AddTextBoxColumn("CREATOR", 80).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//생성시간
			grdInspList.View.AddTextBoxColumn("CREATEDTIME", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//수정자
			grdInspList.View.AddTextBoxColumn("MODIFIER", 80).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//수정시간
			grdInspList.View.AddTextBoxColumn("MODIFIEDTIME", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);

			//숨김컬럼
			grdInspList.View.AddTextBoxColumn("FILEID").SetIsHidden();
			grdInspList.View.AddTextBoxColumn("RESOURCEID").SetIsHidden();
			grdInspList.View.AddTextBoxColumn("FILESIZE").SetIsHidden();
			grdInspList.View.AddTextBoxColumn("FILEEXT").SetIsHidden();
			grdInspList.View.AddTextBoxColumn("FILEDATA").SetIsHidden();


			grdInspList.View.PopulateColumns();
		}

		#endregion

		#region Event

		/// <summary>
		/// 화면에서 사용되는 이벤트를 초기화한다.
		/// </summary>
		public void InitializeEvent()
		{
			btnSelectImage.Click += BtnSelectImage_Click;
			grdInspList.View.FocusedRowChanged += View_FocusedRowChanged;
		}

		/// <summary>
		/// 그리스 포커스 변경 시 이미지 BIND
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if(e.FocusedRowHandle < 0) return;

			DataRow row = grdInspList.View.GetFocusedDataRow();
			if(row == null) return;

			FocusDataBind(row);
		}

		/// <summary>
		/// 이미지 데이터 바인드
		/// </summary>
		/// <param name="r"></param>
		private void FocusDataBind(DataRow r)
		{
			if (string.IsNullOrWhiteSpace(Format.GetString(r["FILEDATA"])))
			{
				picImage.Image = null;
				return;
			}

			try
			{
				this.ShowWaitArea();
				//DialogManager.ShowWaitDialog();

				MemoryStream ms = new MemoryStream(Convert.FromBase64String(Format.GetString(r["FILEDATA"])));
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
		/// 이미지 선택 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSelectImage_Click(object sender, EventArgs e)
		{
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Multiselect = false;
			openDialog.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";

			if (openDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					//DialogManager.ShowWaitDialog();
					this.ShowWaitArea();

					string inspStdName = Path.GetFileNameWithoutExtension(openDialog.FileName);
					string ext = Path.GetExtension(openDialog.FileName);
					byte[] fileByte = FileToByteArray(openDialog.FileName);
					FileInfo fi = new FileInfo(openDialog.FileName);
					long fileSize = fi.Length;

					DataRow row = grdInspList.View.GetFocusedDataRow();
					if (row == null)
					{
						//add
						grdInspList.View.AddNewRow();
					}

					grdInspList.View.SetFocusedRowCellValue("FILENAME", inspStdName);
					grdInspList.View.SetFocusedRowCellValue("FILEEXT", ext);
					grdInspList.View.SetFocusedRowCellValue("FILEDATA", Convert.ToBase64String(fileByte));
					grdInspList.View.SetFocusedRowCellValue("FILESIZE", fileSize);

					MemoryStream ms = new MemoryStream(fileByte);
					picImage.Image = Image.FromStream(ms);

					grdInspList.View.PostEditor();
					grdInspList.View.UpdateCurrentRow();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
				finally
				{
					this.CloseWaitArea();
					//DialogManager.Close();
				}
			}
		}
		#endregion

		#region 툴바
		/// <summary>
		/// 툴바 기능 - 저장
		/// </summary>
		protected override void OnToolbarSaveClick()
		{
			base.OnToolbarSaveClick();

			DataTable dt = grdInspList.GetChangedRows();

			MessageWorker worker = new MessageWorker("SaveInspImageManagement");
			worker.SetBody(new MessageBody()
			{
				{ "inspList", dt },
				{ "enterpriseid", UserInfo.Current.Enterprise },
				{ "plantid", UserInfo.Current.Plant }
			});

			worker.Execute();
		}

		#endregion

		#region 검색
		/// <summary>
		/// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
		/// </summary>
		protected async override Task OnSearchAsync()
		{
			int prevHandle = grdInspList.View.FocusedRowHandle;

			var values = Conditions.GetValues();

			DataTable dtInspImageList = SqlExecuter.Query("SelectInspectionFileList", "00001", values);

			if (dtInspImageList.Rows.Count < 1)
			{
				// 조회할 데이터가 없습니다.
				ShowMessage("NoSelectData");
			}

			grdInspList.DataSource = dtInspImageList;

			if (prevHandle >= 0 &&(grdInspList.DataSource as DataTable).Rows.Count > 0)
			{
				grdInspList.View.FocusedRowChanged -= View_FocusedRowChanged;
				if (prevHandle >= (grdInspList.DataSource as DataTable).Rows.Count - 1)
				{
					grdInspList.View.FocusedRowHandle = 0;
					FocusDataBind(grdInspList.View.GetDataRow(0));
				}
				else
				{
					grdInspList.View.FocusedRowHandle = prevHandle;
					FocusDataBind(grdInspList.View.GetDataRow(prevHandle));
				}
				grdInspList.View.FocusedRowChanged += View_FocusedRowChanged;
			}
		}

		/// <summary>
		/// 조회조건 항목을 추가한다.
		/// </summary>
		protected override void InitializeCondition()
		{
			base.InitializeCondition();

			// TODO : 조회조건 추가 구성이 필요한 경우 사용
		}

		/// <summary>
		/// 조회조건의 컨트롤을 추가한다.
		/// </summary>
		protected override void InitializeConditionControls()
		{
			base.InitializeConditionControls();

			// TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
		}

		#endregion

		#region 유효성 검사
		protected override void OnValidateContent()
		{
			base.OnValidateContent();

			grdInspList.View.CheckValidation();

			DataTable dt = grdInspList.GetChangedRows();
			if(dt.Rows.Count == 0)
			{
				// 저장할 데이터가 존재하지 않습니다.
				throw MessageException.Create("NoSaveData");
			}
		}
		#endregion

		#region Private Function
		/// <summary>
		/// File To byte[]
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		private byte[] FileToByteArray(string path)
		{
			byte[] fileBytes = null;
			try
			{
				using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					fileBytes = new byte[fileStream.Length];
					fileStream.Read(fileBytes, 0, fileBytes.Length);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

			return fileBytes;
		}
		#endregion

	}
}