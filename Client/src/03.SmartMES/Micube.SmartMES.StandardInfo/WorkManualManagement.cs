#region using

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.Net.Data;
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
	/// 프 로 그 램 명  : 기준정보 > 공정코드 > 작업매뉴얼 등록/조회
	/// 업  무  설  명  : 
	/// 생    성    자  : 정승원
	/// 생    성    일  : 2020-06-16
	/// 수  정  이  력  : 
	/// 
	/// 
	/// </summary>
	public partial class WorkManualManagement : SmartConditionBaseForm
	{
		#region 생성자

		public WorkManualManagement()
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

			InitializeGrid();
		}

		/// <summary>        
		/// 그리드를 초기화한다.
		/// </summary>
		private void InitializeGrid()
		{
			// TODO : 그리드 초기화 로직 추가
			grdManualList.GridButtonItem = GridButtonItem.Add;
			grdManualList.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
			grdManualList.View.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;

			//관리번호
			grdManualList.View.AddTextBoxColumn("MANUALID", 80).SetValidationIsRequired();
			//이름
			grdManualList.View.AddTextBoxColumn("MANUALNAME", 150).SetValidationIsRequired();
			//개정번호
			grdManualList.View.AddTextBoxColumn("MANUALVERSION", 60).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//공정
			grdManualList.View.AddComboBoxColumn("PROCESSSEGMENTID", 150, new SqlQuery("GetProcessSegmentList", "00001", "PROCESSSEGMENTTYPE=MAIN"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID").SetValidationIsRequired().SetLabel("PROCESSSEGMENT");
			//타입
			grdManualList.View.AddComboBoxColumn("MANUALTYPE", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ManualType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetValidationIsRequired();
			//도면번호
			grdManualList.View.AddTextBoxColumn("DRAWINGNO", 60).SetTextAlignment(TextAlignment.Right);
			//상태
			grdManualList.View.AddComboBoxColumn("STATE", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=WorkManualStatus", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			//등록자
			grdManualList.View.AddTextBoxColumn("REGISTUSER", 80).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//등록일
			grdManualList.View.AddTextBoxColumn("REGISTDATE", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//수정자
			grdManualList.View.AddTextBoxColumn("MODIFIER", 60).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//수정일
			grdManualList.View.AddTextBoxColumn("MODIFIEDTIME", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//폐기자
			grdManualList.View.AddTextBoxColumn("SCRAPUSER", 80).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//폐기일자
			grdManualList.View.AddTextBoxColumn("SCRAPDATE", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//팝업열기
			grdManualList.View.AddButtonColumn("OPEN", 60).SetTextAlignment(TextAlignment.Center);
			//FILENAME
			grdManualList.View.AddTextBoxColumn("FILENAME").SetIsHidden();
			//FILEPATH
			grdManualList.View.AddTextBoxColumn("FILEPATH").SetIsHidden();
			//FILEEXT
			grdManualList.View.AddTextBoxColumn("FILEEXT").SetIsHidden();
			//HIDDEN FLAG
			grdManualList.View.AddTextBoxColumn("FLAG").SetIsHidden();

			grdManualList.View.PopulateColumns();
		}

		#endregion

		#region Event

		/// <summary>
		/// 화면에서 사용되는 이벤트를 초기화한다.
		/// </summary>
		public void InitializeEvent()
		{
			grdManualList.ToolbarAddingRow += GrdManualList_ToolbarAddingRow;
			grdManualList.View.AddingNewRow += View_AddingNewRow;
			grdManualList.View.GridCellButtonClickEvent += View_GridCellButtonClickEvent;
			grdManualList.View.CustomRowCellEdit += View_CustomRowCellEdit;
			grdManualList.View.ShowingEditor += View_ShowingEditor;
            grdManualList.View.RowCellStyle += View_RowCellStyle;
		}

		private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
		{
			GridView view = sender as GridView;
			DataRow dr = view.GetDataRow(e.RowHandle);

			if (dr["MANUALTYPE"].ToString().Equals("Drawing"))
			{
				if (e.Column.FieldName.Equals("DRAWINGNO") ||
					e.Column.FieldName.Equals("MODIFIEDTIME") ||
					e.Column.FieldName.Equals("MODIFIER"))
				{
					e.Appearance.BackColor = Color.White;
				}
			}
			else 
			{

				if (e.Column.FieldName.Equals("DRAWINGNO") ||
					e.Column.FieldName.Equals("MODIFIEDTIME") ||
					e.Column.FieldName.Equals("MODIFIER"))
				{
					e.Appearance.BackColor = Color.LightGray;
				}
			}

			
        }

        private void View_ShowingEditor(object sender, CancelEventArgs e)
		{
			//타입이 도면인 경우 도면번호 readonly = false, 아닌경우 readonly = true
			GridView view = sender as GridView;

			string sType = view.GetFocusedDataRow()["MANUALTYPE"].ToString();
			string focusColumn = grdManualList.View.FocusedColumn.FieldName;

			if (!sType.Equals("Drawing"))
			{
				if (focusColumn.Equals("DRAWINGNO")) 
				{
					e.Cancel = true;
				}
			}
			
		}


		private void View_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
		{
			DataRow r = grdManualList.View.GetDataRow(e.RowHandle);

			if (e.Column.FieldName.Equals("OPEN"))
			{
				RepositoryItemButtonEdit newEditor = new RepositoryItemButtonEdit();
				newEditor.Assign(e.Column.ColumnEdit as RepositoryItemButtonEdit);

				if (!string.IsNullOrWhiteSpace(Format.GetFullTrimString(r["FILEPATH"])))
				{
					newEditor.Buttons[0].Appearance.BackColor = Color.Blue;
					newEditor.Buttons[0].Appearance.ForeColor = Color.White;
				}
				else
				{
					newEditor.Buttons[0].Appearance.BackColor = Color.Gray;
					newEditor.Buttons[0].Appearance.ForeColor = Color.White;
				}
				e.RepositoryItem = newEditor;
			}

		}

		private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
		{
			args.NewRow["MANUALVERSION"] = 1;
			args.NewRow["STATE"] = "Use";
		}

		/// <summary>
		/// 열기 버튼 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void View_GridCellButtonClickEvent(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.GridCellButtonClickEventArgs args)
		{
			if(args.CurrentRow.RowState == DataRowState.Added) return;

			if(string.IsNullOrWhiteSpace(Format.GetFullTrimString(args.CurrentRow["FILEPATH"]))) return;

			//if(Format.GetFullTrimString(args.CurrentRow["STATE"]).Equals("Scrap")) return;

			try
			{
				//this.ShowWaitArea();

				string executePath = System.Windows.Forms.Application.StartupPath;
				string serverPath = Format.GetFullTrimString(args.CurrentRow["FILEPATH"]);

				string filePath = executePath + serverPath.Replace("D:", "");
				if (!Directory.Exists(filePath))
				{
					Directory.CreateDirectory(filePath);
				}

				string fileName = Format.GetFullTrimString(args.CurrentRow["FILENAME"]) + Format.GetFullTrimString(args.CurrentRow["FILEEXT"]);
				string fullPath = filePath + "\\" + fileName;
				if (!File.Exists(fullPath))
				{
					MessageWorker worker = new MessageWorker("SaveWorkManualManagement");
					worker.SetBody(new MessageBody()
					{
						{ "manualNo", Format.GetFullTrimString(args.CurrentRow["MANUALNO"]) },
						{ "manualVersion", Format.GetFullTrimString(args.CurrentRow["MANUALVERSION"]) }
					});
					IResponse<DataTable> response = worker.Execute<DataTable>();
					DataTable dt = response.GetResultSet();
					if (dt.Rows.Count > 0)
					{
						Commons.CommonFunction.ByteArrayToFile(fullPath, Convert.FromBase64String(Format.GetString(dt.Rows[0]["FILEDATA"])));
					}
				}

				System.Diagnostics.Process.Start(fullPath);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				this.CloseWaitArea();
			}
		}

		/// <summary>
		/// + 눌렀을 때 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GrdManualList_ToolbarAddingRow(object sender, CancelEventArgs e)
		{
			DataTable dt = grdManualList.GetChangesAdded();
			if(dt.Rows.Count > 0)
			{
				e.Cancel = true;
			}
		}

		#endregion

		#region 툴바

		/// <summary>
		/// 툴바 기능
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void OnToolbarClick(object sender, EventArgs e)
		{
			try
			{
				this.ShowWaitArea();

				SmartButton btn = sender as SmartButton;
				switch (btn.Name)
				{
					case "Save":
						grdManualList.View.CheckValidation();

						DataTable changed = grdManualList.GetChangedRows();

						if (changed.Rows.Count == 0)
						{
							// 저장할 데이터가 존재하지 않습니다.
							throw MessageException.Create("NoSaveData");
						}

						DataRow row = changed.AsEnumerable().FirstOrDefault();

						MessageWorker worker = new MessageWorker("SaveWorkManualManagement");
						worker.SetBody(new MessageBody()
						{
							{ "manualList",  changed}
						});

						IResponse<DataTable> response = worker.Execute<DataTable>();

						//폐기상태일땐 파일등록 X
						if (Format.GetFullTrimString(row["STATE"]).Equals("Scrap"))
						{
							break;
						}

						DataTable resultDt = response.GetResultSet();
						if (resultDt.Rows.Count > 0)
						{
							//최초 등록일 경우 파일등록 GO ~
							if (Format.GetInteger(resultDt.Rows[0]["COUNT"], 0) == 0)
							{
								//파일을 등록하시겠습니까?
								if (ShowMessageBox("REGISTWORKMANUAL", Language.Get("INFORMATION"), MessageBoxButtons.OKCancel) == DialogResult.OK)
								{
									row["MANUALNO"] = resultDt.Rows[0]["MANUALNO"];

									WorkManualFilePopup popup = new WorkManualFilePopup();
									popup.isFirst = true;
                                    popup.isScrap = row["STATE"].Equals("Scrap") ? true : false;
                                    popup.CurrentDataRow = row;
									popup.ShowDialog();
								}
							}
						}

						ShowMessage("SuccessSave");

						break;//case
					case "FileUpload":
						DataRow r = grdManualList.View.GetFocusedDataRow();

						//2021-01-28 정송은 추가
						//그리드에 행 데이터가 없으면 메시지 출력
						if(r == null)
                        {
							//선택된 행이 없습니다.
							ShowMessage("NoSelected");
							return;
                        }

						if (r.RowState == DataRowState.Added) return;

						//if(Format.GetFullTrimString(r["STATE"]).Equals("Scrap")) return;

						WorkManualFilePopup popup2 = new WorkManualFilePopup();
						popup2.isFirst = false;
                        popup2.isScrap = r["STATE"].Equals("Scrap") ? true : false;
                        popup2.CurrentDataRow = r;
						popup2.ShowDialog();
						break;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				this.CloseWaitArea();
				OnSearchAsync();
			}
			
		}
		#endregion

		#region 검색

		/// <summary>
		/// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
		/// </summary>
		protected async override Task OnSearchAsync()
		{
			await base.OnSearchAsync();

			// TODO : 조회 SP 변경
			var values = Conditions.GetValues();

			DataTable dtList = await QueryAsync("SelectManualList", "00001", values);

			if (dtList.Rows.Count < 1)
			{
				// 조회할 데이터가 없습니다.
				ShowMessage("NoSelectData");
			}

			grdManualList.DataSource = dtList;
			
		}


		/// <summary>
		/// 조회조건 항목을 추가한다.
		/// </summary>
		protected override void InitializeCondition()
		{
			base.InitializeCondition();

			//공정
			InitailizeCondition_Processsegment();

		}

		/// <summary>
		/// 팝업형 조회조건 초기화 - 공정
		/// </summary>
		private void InitailizeCondition_Processsegment()
		{
			var processSegmentIdPopup = Conditions.AddSelectPopup("P_PROCESSSEGMENT", new SqlQuery("GetProcessSegmentList", "00001", "PROCESSSEGMENTTYPE=MAIN", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
				.SetPopupLayout("PROCESSSEGMENTLIST", PopupButtonStyles.Ok_Cancel, true, true)
				.SetPopupLayoutForm(600, 600)
				.SetPopupAutoFillColumns("PROCESSSEGMENTNAME")
				.SetLabel("PROCESSSEGMENT")
				.SetPosition(0.1)
				.SetPopupResultCount(0);

			processSegmentIdPopup.Conditions.AddTextBox("P_PROCESSSEGMENTTXT").SetLabel("TXTPROCESSSEGMENT");

			processSegmentIdPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 100);
			processSegmentIdPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 150);
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
	}
}