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
using System.IO;
using Micube.Framework;
using System.Runtime.Serialization.Formatters.Binary;

namespace Micube.SmartMES.Quality
{
	/// <summary>
	/// 프 로 그 램 명  : 품질관리 > 파일 등록 정보 공통 컨트롤
	/// 업  무  설  명  : 
	/// 생    성    자  : swjeong
	/// 생    성    일  : 2020-04-22
	/// 수  정  이  력  : 2020-04-27 유태근 / 파일 그리드에 발행번호 추가할 수 있도록 속성추가
    ///                   2020-04-28 유태근 / 파일 Add & Download 수정
    ///                   2022-05-10 주시은 / 파일 생성자 컬럼 추가
	/// 
	/// 
	/// </summary>
	public partial class ucFileControl : UserControl
	{
		#region Variable

		public delegate void StateEventHandler(bool stateFlag = false);
		public event StateEventHandler StateEvent;


        private string _docId = ""; // 발행번호

        public DataTable dataSoruce
		{
			get { return grdFileInfo.DataSource as DataTable; }
			set { grdFileInfo.DataSource = value; }
		}

        public string docId
        {
            get { return _docId; }
            set { _docId = value; }
        }

        #endregion

        #region 생성자

        public ucFileControl()
		{
			InitializeComponent();

			InitializeEvent();
			InitializeGrid();
		}

        #endregion

        #region Event

        /// <summary>
        /// 이벤트 초기화
        /// </summary>
        private void InitializeEvent()
		{
			btnDownload.Click += BtnDownload_Click;
			btnAddFile.Click += BtnAddFile_Click;
			grdFileInfo.View.CellValueChanged += View_CellValueChanged;
            grdFileInfo.View.AddingNewRow += View_AddingNewRow;
            grdFileInfo.ToolbarDeletingRow += GrdFileInfo_ToolbarDeletingRow;
        }

        /// <summary>
        /// 파일 삭제시 상태변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdFileInfo_ToolbarDeletingRow(object sender, CancelEventArgs e)
        {
            DataTable dt = grdFileInfo.View.GetCheckedRows();

            if (dt.Rows.Count > 0)
            {
                this.StateEvent(true);
            }
        }

        /// <summary>
        /// 파일 추가시 상태변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            this.StateEvent(true);           
        }

        /// <summary>
        /// 파일 그리드 셀 value 변경 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if(e == null) return;

			if (e.Column.FieldName == "DESCRIPTION")
			{
				this.StateEvent(true);
			}
		}

		/// <summary>
		/// 다운로드 버튼 클릭 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDownload_Click(object sender, EventArgs e)
		{
			DataTable checkedDt = grdFileInfo.View.GetCheckedRows();
			if(checkedDt.Rows.Count < 1) return;

			FolderBrowserDialog folderDialog = new FolderBrowserDialog();

			if (folderDialog.ShowDialog() == DialogResult.OK)
			{
				foreach(DataRow row in checkedDt.Rows)
				{
					try
					{
						string fileFullPath = folderDialog.SelectedPath + "\\" + row["FILENAME"].ToString();
                        //ByteArrayToFile(fileFullPath, (byte[])row["FILEDATA"]);
                        ByteArrayToFile(fileFullPath, Convert.FromBase64String(Format.GetString(row["FILEDATA"])));
                    }
                    catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}
				}
			}

			SmartBaseForm form = new SmartBaseForm();
			form.ShowMessage("Completed");

			grdFileInfo.View.CheckedAll(false);
		}

		/// <summary>
		/// 파일첨부 클릭 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAddFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Multiselect = true;
			openDialog.Filter = "All files (*.*)|*.*";

			if (openDialog.ShowDialog() == DialogResult.OK)
			{
				foreach(string file in openDialog.FileNames)
				{
					try
					{
						grdFileInfo.View.AddNewRow();

						DataTable dt = grdFileInfo.DataSource as DataTable;
						int maxSeq = dt.AsEnumerable().Select(r => Format.GetInteger(r["SEQNUMBER"])).Distinct().Max();
                        grdFileInfo.View.GetFocusedDataRow()["SEQNUMBER"] = maxSeq + 1;

                        string fileName = Path.GetFileName(file);
                        grdFileInfo.View.GetFocusedDataRow()["FILENAME"] = fileName;

                        byte[] fileByte = FileToByteArray(file);
                        grdFileInfo.View.GetFocusedDataRow()["FILEDATA"] = Convert.ToBase64String(fileByte);

						grdFileInfo.View.GetFocusedDataRow()["DOCID"] = _docId; // 발행번호
                        grdFileInfo.View.GetFocusedDataRow()["CREATOR"] = UserInfo.Current.Name;
                        grdFileInfo.View.GetFocusedDataRow()["CREATEDTIME"] = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // 생성일
                    }
					catch(Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}
				}
			}

			//this.StateEvent(true);
		}

		#endregion

		#region 초기화

		/// <summary>
		/// 그리드 초기화
		/// </summary>
		private void InitializeGrid()
		{
			grdFileInfo.GridButtonItem = GridButtonItem.Delete;
			grdFileInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdFileInfo.View.SetAutoFillColumn("DESCRIPTION");

            grdFileInfo.View.AddTextBoxColumn("CREATOR", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdFileInfo.View.AddTextBoxColumn("CREATEDTIME", 100).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdFileInfo.View.AddTextBoxColumn("SEQNUMBER", 80).SetIsReadOnly();
            grdFileInfo.View.AddTextBoxColumn("DESCRIPTION", 200);
            grdFileInfo.View.AddTextBoxColumn("FILENAME", 200).SetIsReadOnly();
            //grdFileInfo.View.AddTextBoxColumn("CREATOR", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly().SetIsHidden();
			grdFileInfo.View.AddTextBoxColumn("DOCID").SetIsReadOnly().SetIsHidden();
			grdFileInfo.View.AddTextBoxColumn("FILEDATA").SetIsReadOnly().SetIsHidden();

			grdFileInfo.View.PopulateColumns();
		}

		#endregion

		#region Function

		public void UpdateCurrentRow()
		{
			grdFileInfo.View.PostEditor();
			grdFileInfo.View.UpdateCurrentRow();
		}

		/// <summary>
		/// 그리드 초기화
		/// </summary>
		public void ClearGridDatas()
		{
			grdFileInfo.View.ClearDatas();
		}

		/// <summary>
		/// 변경된 Row 가져오기
		/// </summary>
		/// <returns></returns>
		public DataTable GetChangedRows()
		{
            DataTable dt = grdFileInfo.GetChangedRows();
            dt.TableName = "fileList";
            return dt;
		}

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

		/// <summary>
		/// byte[] To File
		/// </summary>
		/// <param name="path"></param>
		/// <param name="buffer"></param>
		/// <returns></returns>
		private bool ByteArrayToFile(string path, byte[] bytes)
		{
			try
			{
				using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
				{
					fs.Write(bytes, 0, bytes.Length);
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
		}

        /// <summary>
        /// object To byte[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private byte[] ObjectToByteArray(object obj)
        {
            if (obj == null) return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        public void CloseEditor()
        {
            grdFileInfo.View.CloseEditor();
        }

        #endregion
    }
}
