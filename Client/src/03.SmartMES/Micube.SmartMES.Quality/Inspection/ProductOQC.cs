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

namespace Micube.SmartMES.Quality
{
	/// <summary>
	/// 프 로 그 램 명  : 품질관리 > 검사 > 출하 검사
	/// 업  무  설  명  : 제품 출하 전 검사
	/// 생    성    자  : 정승원
	/// 생    성    일  : 2020-06-09
	/// 수  정  이  력  : 
	/// 
	/// 
	/// </summary>
	public partial class ProductOQC : SmartConditionBaseForm
	{
		#region 생성자

		public ProductOQC()
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
			InitializeControls();

			grdProductOQC.View.AddNewRow();
			(grdProductOQC.DataSource as DataTable).AcceptChanges();

			grdProductOQC.View.UnselectRow(0);
		}

		/// <summary>
		/// 컨트롤 초기화
		/// </summary>
		private void InitializeControls()
		{
			cboProduct.DisplayMember = "PARTNUMBER";
			cboProduct.ValueMember = "PRODUCTDEFSEQ";
			cboProduct.DataSource = SqlExecuter.Query("GetProductDefinitionList", "10001");

			cboProcesssegment.DisplayMember = "PROCESSSEGMENTNAME";
			cboProcesssegment.ValueMember = "PROCESSSEGMENTID";
			cboProcesssegment.DataSource = SqlExecuter.Query("GetProcessSegmentList", "00001", new Dictionary<string, object>(){ { "_TXNINFO.LANGUAGETYPE", UserInfo.Current.LanguageType } });

			cboInspector.DisplayMember = "USERNAME";
			cboInspector.ValueMember = "USERID";
			cboInspector.DataSource = SqlExecuter.Query("GetUser", "00001");
			cboInspector.EditValue = UserInfo.Current.Id;

			ConditionItemSelectPopup options = new ConditionItemSelectPopup();
			options.SetPopupLayoutForm(600, 600, FormBorderStyle.FixedDialog);
			options.SetPopupLayout("SELECTINSPECTORID", PopupButtonStyles.Ok_Cancel, true, false);
			options.Id = "USERID";
			options.SearchQuery = new SqlQuery("GetUser", "00001");
			options.IsMultiGrid = false;
			options.DisplayFieldName = "USERNAME";
			options.ValueFieldName = "USERID";
			options.SetValidationIsRequired();
			options.Conditions.AddTextBox("USERIDNAME");
			options.GridColumns.AddTextBoxColumn("USERID", 150);
			options.GridColumns.AddTextBoxColumn("USERNAME", 200);
			options.SetPopupAutoFillColumns("USERNAME");
			popInspector2.SelectPopupCondition = options;
		}

		/// <summary>        
		/// 그리드를 초기화한다.
		/// </summary>
		private void InitializeGrid()
		{
			// TODO : 그리드 초기화 로직 추가
			grdProductOQC.GridButtonItem = GridButtonItem.None;
			grdProductOQC.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
			grdProductOQC.View.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;

			//A ~ T VALUE
			grdProductOQC.View.AddCheckBoxColumn("A", 70).SetDefault(false);
			grdProductOQC.View.AddCheckBoxColumn("B", 70).SetDefault(false);
			grdProductOQC.View.AddCheckBoxColumn("C", 70).SetDefault(false);
			grdProductOQC.View.AddCheckBoxColumn("D", 70).SetDefault(false);
			grdProductOQC.View.AddCheckBoxColumn("E", 70).SetDefault(false);
			grdProductOQC.View.AddCheckBoxColumn("F", 70).SetDefault(false);
			grdProductOQC.View.AddCheckBoxColumn("G", 70).SetDefault(false);
			grdProductOQC.View.AddCheckBoxColumn("H", 70).SetDefault(false);
			
			grdProductOQC.View.PopulateColumns();
		}

		#endregion

		#region Event

		/// <summary>
		/// 화면에서 사용되는 이벤트를 초기화한다.
		/// </summary>
		public void InitializeEvent()
		{
			txtLOTId.KeyDown += TxtLOTId_KeyDown;
			txtLOTId.Click += TxtLOTId_Click;
		}

		/// <summary>
		/// 전체 선택
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtLOTId_Click(object sender, EventArgs e)
		{
			txtLOTId.SelectAll();
		}

		/// <summary>
		/// 출하 검사 대상 LOT 조회
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtLOTId_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(string.IsNullOrWhiteSpace(Format.GetFullTrimString(txtLOTId.EditValue)))
					return;

				DataTable dt = SqlExecuter.Query("SelectProductOqcTarget", "00001", new Dictionary<string, object>(){ { "LOTID", txtLOTId.EditValue } });
				if(dt.Rows.Count != 1)
				{
					//조회 대상 LOT이 없습니다.
					ShowMessage("NOTEXISTLOT");
					txtLOTId.EditValue = string.Empty;
					txtLOTId.Focus();
					return;
				}

				Commons.CommonFunction.BindDataToControlsTag(dt.Rows[0], tlpOQC);

				//SET 검사 기준 이미지
				try
				{
					this.ShowWaitArea();

					MemoryStream ms = new MemoryStream(Convert.FromBase64String(Format.GetString(dt.Rows[0]["FILEDATA"])));
					picImage.Image = Image.FromStream(ms);
				}
				catch (Exception ex)
				{
					//등록된 검사 기준 이미지가 없습니다.
					ShowMessage("NOINSPECTIONSTDIMAGE");
					txtLOTId.SelectAll();
					txtLOTId.Focus();
				}
				finally
				{
					this.CloseWaitArea();
				}

				txtLOTId.Focus();
			}
		}
		#endregion

		#region 툴바

		/// <summary>
		/// 출하 검사 완료
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void OnToolbarClick(object sender, EventArgs e)
		{
			SmartButton btn = sender as SmartButton;
			switch(btn.Name.ToString())
			{
				case "Save":
					if (string.IsNullOrWhiteSpace(Format.GetFullTrimString(txtLOTId.EditValue)))
					{
						//LOT은 필수입니다.
						ShowMessage("REQUIREDLOT");
						return;
					}

					if (string.IsNullOrWhiteSpace(Format.GetFullTrimString(txtLOTId.EditValue)))
					{
						//공정은 필수입니다.
						ShowMessage("REQUIREDSEGMENT");
						return;
					}

					DataTable dt = grdProductOQC.GetChangedRows();
					if(dt.Rows.Count < 1)
					{
						//결과 입력은 필수입니다.
						ShowMessage("REQUIREDSEGMENT");
						return;
					}

					try
					{
						this.ShowWaitArea();
						MessageWorker worker = new MessageWorker("SaveProductOQC");
						worker.SetBody(new MessageBody()
						{
							{ "lotId", txtLOTId.EditValue },
							{ "processsegmentId", cboProcesssegment.EditValue },
							{ "degree", txtDegree.EditValue },
							{ "inspector", UserInfo.Current.Id },
							{ "inspector2", popInspector2.GetValue() },
							{ "comment", txtComment.EditValue },
							{ "result", grdProductOQC.DataSource },
						});

						worker.Execute();
					}
					catch(Exception ex)
					{
						throw MessageException.Create(ex.ToString());
					}
					finally
					{
						this.CloseWaitArea();

						ShowMessage("SuccessSave");

						//초기화 작업
						InitAfeterSave();
					}
					break;
			}
		}
        #endregion

        #region private function

        /// <summary>
        /// 저장 후 초기화
        /// </summary>
        private void InitAfeterSave()
		{
			txtLOTId.EditValue = string.Empty;
			cboProduct.EditValue = string.Empty;
			txtProductName.EditValue = string.Empty;
			cboProcesssegment.EditValue = string.Empty;
			txtDegree.EditValue = string.Empty;
			txtQty.EditValue = string.Empty;
			popInspector2.SetValue(string.Empty);
			popInspector2.Text = string.Empty;
			txtComment.EditValue = string.Empty;

			picImage.Image = null;

			grdProductOQC.View.ClearDatas();
			grdProductOQC.View.AddNewRow();
			(grdProductOQC.DataSource as DataTable).AcceptChanges();

			grdProductOQC.View.UnselectRow(0);

			txtLOTId.Focus();
		}

        #endregion

    }
}