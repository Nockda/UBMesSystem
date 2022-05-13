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
using Micube.Framework;
using Micube.SmartMES.Commons.Controls;
using System.IO;
using Micube.Framework.Net;
using DevExpress.XtraEditors.Repository;
using Micube.Framework.Net.Data;

namespace Micube.SmartMES.StandardInfo
{
	public partial class WorkManualFilePopup : SmartPopupBaseForm, ISmartCustomPopup
	{
        #region Variable

        public DataRow CurrentDataRow { get; set; }
		public bool isFirst { get; set; }
        public bool isScrap { get; set; }

        #endregion

        #region 생성자

        public WorkManualFilePopup()
		{
			InitializeComponent();

			InitializeEvent();
			InitializeGrid();
		}

        #endregion

        #region 그리드 초기화

        /// <summary>
        /// 그리드 초기화
        /// </summary>
        private void InitializeGrid()
		{
            grdFileList.GridButtonItem = GridButtonItem.Add;       
			grdFileList.View.SetAutoFillColumn("MANUALNAME", "FILENAME");
			grdFileList.View.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;

			//관리번호
			grdFileList.View.AddTextBoxColumn("MANUALID", 80).SetIsReadOnly();
			//이름
			grdFileList.View.AddTextBoxColumn("MANUALNAME", 150).SetIsReadOnly();
			//개정번호
			grdFileList.View.AddTextBoxColumn("MANUALVERSION", 60).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//파일명
			grdFileList.View.AddTextBoxColumn("FILENAME", 150);
			//파일등록
			grdFileList.View.AddButtonColumn("REGIST", 60).SetTextAlignment(TextAlignment.Center);
			//열기
			grdFileList.View.AddButtonColumn("OPEN", 60).SetTextAlignment(TextAlignment.Center);
			//파일확장자
			grdFileList.View.AddTextBoxColumn("FILEEXT").SetIsHidden();
			//파일사이즈
			grdFileList.View.AddTextBoxColumn("FILESIZE").SetIsHidden();
			//파일데이터
			grdFileList.View.AddTextBoxColumn("FILEDATA").SetIsHidden();
			//MANUALNO
			grdFileList.View.AddTextBoxColumn("MANUALNO").SetIsHidden();
			//상태
			grdFileList.View.AddTextBoxColumn("STATE").SetIsHidden();
			//파일경로
			grdFileList.View.AddTextBoxColumn("FILEPATH").SetIsHidden();

			grdFileList.View.PopulateColumns();
		}

        #endregion

        #region Event

        /// <summary>
        /// 이벤트 초기화
        /// </summary>
        private void InitializeEvent() 
		{
			this.Shown += WorkManualFilePopup_Shown;
			grdFileList.View.GridCellButtonClickEvent += View_GridCellButtonClickEvent;
			grdFileList.View.AddingNewRow += View_AddingNewRow;
			grdFileList.View.CustomRowCellEdit += View_CustomRowCellEdit;
			btnSave.Click += BtnSave_Click;                                                                                                                
			btnClose.Click += BtnClose_Click;

            this.Load += WorkManualFilePopup_Load;
		}

        /// <summary>
        /// 폐기처리됬다면 저장, 수정 불가하고 파일 열기만 가능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkManualFilePopup_Load(object sender, EventArgs e)
        {
            ScrapStateAction();
        }

        private void View_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
		{
			DataRow r = grdFileList.View.GetDataRow(e.RowHandle);

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

		/// <summary>
		/// 그리드 + 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
		{
			if(isFirst)
			{
				if(CurrentDataRow == null)
				{
					args.IsCancel = true;
					return;
				}
				else
				{
					args.NewRow["MANUALNO"] = CurrentDataRow["MANUALNO"];
					args.NewRow["MANUALID"] = CurrentDataRow["MANUALID"];
					args.NewRow["MANUALNAME"] = CurrentDataRow["MANUALNAME"];
					args.NewRow["MANUALVERSION"] = CurrentDataRow["MANUALVERSION"];
					args.NewRow["STATE"] = CurrentDataRow["STATE"];
				}
			}
			else
			{
				DataTable dt = grdFileList.DataSource as DataTable;
				int max = dt.AsEnumerable().Select(r => Format.GetInteger(r["MANUALVERSION"], 0)).Max();

				DataRow prevRow = grdFileList.View.GetDataRow(max-1);
				if(prevRow == null)
				{
					args.NewRow["MANUALNO"] = CurrentDataRow["MANUALNO"];
					args.NewRow["MANUALID"] = CurrentDataRow["MANUALID"];
					args.NewRow["MANUALNAME"] = CurrentDataRow["MANUALNAME"];
					args.NewRow["MANUALVERSION"] = 1;
					args.NewRow["STATE"] = CurrentDataRow["STATE"];
					return;
				}

				args.NewRow["MANUALNO"] = prevRow["MANUALNO"];
				args.NewRow["MANUALID"] = prevRow["MANUALID"];
				args.NewRow["MANUALNAME"] = prevRow["MANUALNAME"];
				args.NewRow["MANUALVERSION"] = max + 1;
				args.NewRow["STATE"] = CurrentDataRow["STATE"];
			}
		}

		/// <summary>
		/// popup open 시 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WorkManualFilePopup_Shown(object sender, EventArgs e)
		{
			//파일 첫 등록이면 파일 브라우저 오픈
			if (isFirst)
			{
				grdFileList.View.AddNewRow();
				  
				DataRow focusRow = grdFileList.View.GetDataRow(grdFileList.View.FocusedRowHandle);

				if (focusRow.RowState != DataRowState.Added) return;

				FileDialog();

				//초기화
				CurrentDataRow = null;
				isFirst = false;
			}
			else
			{
				grdFileList.DataSource = SqlExecuter.Query("SelectManualFileList", "00001", new Dictionary<string, object>(){ { "MANUALNO", CurrentDataRow["MANUALNO"] }});
			}
		}

		/// <summary>
		/// 파일 다이얼로그 오픈
		/// </summary>
		private void FileDialog()
		{
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Multiselect = false;
			openDialog.Filter = "PDF Files(*.pdf)|*.pdf";

			if (openDialog.ShowDialog() == DialogResult.OK)
			{
				byte[] fileData = Commons.CommonFunction.FileToByteArray(openDialog.FileName);
				grdFileList.View.SetFocusedRowCellValue("FILEDATA", Convert.ToBase64String(fileData));

				long fileSize = fileData.Length;
				grdFileList.View.SetFocusedRowCellValue("FILESIZE", fileSize);

				string fileExt = Path.GetExtension(openDialog.FileName);
				grdFileList.View.SetFocusedRowCellValue("FILEEXT", fileExt);

				string fileName = Path.GetFileNameWithoutExtension(openDialog.FileName);
				grdFileList.View.SetFocusedRowCellValue("FILENAME", fileName);
			}
		}

		/// <summary>
		/// 파일등록, 파일열기 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void View_GridCellButtonClickEvent(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.GridCellButtonClickEventArgs args)
		{
			//if (Format.GetFullTrimString(args.CurrentRow["STATE"]).Equals("Scrap")) return;

			switch (args.FieldName)
			{
				case "REGIST":

                    if (Format.GetFullTrimString(args.CurrentRow["STATE"]).Equals("Scrap")) return;

                    try
					{
						this.ShowWaitArea();

						btnSave.Enabled = false;
						FileDialog();
					}
					catch(Exception ex)
					{
						ShowMessage(ex.ToString());
					}
					finally
					{
						btnSave.Enabled = true;
						grdFileList.View.PostEditor();
						grdFileList.View.UpdateCurrentRow();

						this.CloseWaitArea();
					}
					break;
				case "OPEN":
					if(args.CurrentRow.RowState == DataRowState.Added) return;

                    try
                    {
                        this.ShowWaitArea();

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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        this.CloseWaitArea();
                    }
					break;
			}

		}

		/// <summary>
		/// 저장 버튼 클릭 - 파일저장
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				grdFileList.View.PostEditor();
				grdFileList.View.UpdateCurrentRow();

				this.ShowWaitArea();

				DataTable dt = grdFileList.GetChangedRows();
				if (dt.Rows.Count == 0)
				{
					//저장할 데이터가 없습니다.
					ShowMessage("NoSaveData");
					return;
				}

				MessageWorker worker = new MessageWorker("SaveWorkManualManagement");
				worker.SetBody(new MessageBody()
				{
					{ "fileList", dt }
				});

				worker.Execute();
				ShowMessage("SuccessSave");
			}
			catch(Exception ex)
			{
				ShowMessage(ex.ToString());
			}
			finally
			{
				this.CloseWaitArea();
			}

			this.Close();
		}

		/// <summary>
		/// 닫기 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        #endregion

        #region Private Function

        /// <summary>
        /// 폐기상태일때 저장, 수정불가하고 열기만 가능
        /// </summary>
        private void ScrapStateAction()
        {
            if (isScrap)
            {
                grdFileList.GridButtonItem = GridButtonItem.None;
                btnSave.Enabled = false;
            }
            else
            {
                grdFileList.GridButtonItem = GridButtonItem.Add;
            }

            grdFileList.View.ShowingEditor += (s, args) =>
            {
                if (isScrap)
                {
                    if (!grdFileList.View.FocusedColumn.FieldName.Equals("OPEN"))
                    {
                        args.Cancel = true;
                    }
                }
            };
        }

        #endregion
    }
}
