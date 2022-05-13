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
	/// 프 로 그 램 명  : 품질 관리 > 코드 관리 > 자재 수입 검사
	/// 업  무  설  명  : 자재 투입 전 검사
	/// 생    성    자  : 정승원
	/// 생    성    일  : 2020-06-03
	/// 수  정  이  력  : 
	/// 
	/// 
	/// </summary>
	public partial class MaterialIQC : SmartConditionBaseForm
	{
		#region Local Variables
		#endregion

		#region 생성자

		public MaterialIQC()
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
			InitializeControls();

			//tab 페이지 다국어
			pageMaterialIQCList.Text = Language.Get("SEARCH2");
			pageMaterialIQC.Text = Language.Get("IQC");
			pageInspectionHistory.Text = Language.Get("INSPECTIONHISTORY");
			
		}

		/// <summary>        
		/// 그리드를 초기화한다.
		/// </summary>
		private void InitializeGrid()
		{
			// TODO : 그리드 초기화 로직 추가
			#region 조회
			grdIQCList.GridButtonItem = GridButtonItem.None;
			grdIQCList.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
			grdIQCList.View.SetIsReadOnly();
            grdIQCList.GridButtonItem = GridButtonItem.Export;

            //납품번호
            grdIQCList.View.AddTextBoxColumn("DELIVERYNO", 90).SetTextAlignment(TextAlignment.Center);
			//납품내부순번
			grdIQCList.View.AddTextBoxColumn("DELIVERYSEQUENCE", 70)
				.SetTextAlignment(TextAlignment.Center)
				.SetLabel("DELVSERL")
				.SetIsHidden();
			//품목코드
			grdIQCList.View.AddTextBoxColumn("CONSUMABLEDEFID", 100).SetIsHidden();
			grdIQCList.View.AddTextBoxColumn("PARTNUMBER", 90).SetLabel("PRODUCTDEFID").SetTextAlignment(TextAlignment.Center);
			//품목명
			grdIQCList.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 150).SetLabel("PRODUCTDEFNAME");
			//규격
			grdIQCList.View.AddTextBoxColumn("STANDARD", 120);
			//납품일
			grdIQCList.View.AddTextBoxColumn("DELIVERYDATE", 80).SetTextAlignment(TextAlignment.Center).SetLabel("DELIVERYDATE2");
			//구매거래처
			grdIQCList.View.AddTextBoxColumn("VENDORNAME", 90).SetTextAlignment(TextAlignment.Center);
			//납품확인부서
			grdIQCList.View.AddComboBoxColumn("DELIVERYCONFIRMDEPT", 100, new SqlQuery("GetDepartmentList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetTextAlignment(TextAlignment.Center);
			//납품확인자
			grdIQCList.View.AddComboBoxColumn("DELIVERYCONFIRMUSER", 70, new SqlQuery("GetUserByEmpNo", "00001"), "USERNAME", "USERID")
				.SetTextAlignment(TextAlignment.Center);
			//납품창고
			grdIQCList.View.AddTextBoxColumn("DELIVERYWAREHOUSEID", 100)
				.SetTextAlignment(TextAlignment.Center);
			//납품수량
			grdIQCList.View.AddTextBoxColumn("DELIVERYQTY", 60).SetTextAlignment(TextAlignment.Right);
			//양품수량
			grdIQCList.View.AddTextBoxColumn("GOODQTY", 60).SetTextAlignment(TextAlignment.Right);
			//불량수량
			grdIQCList.View.AddTextBoxColumn("DEFECTQTY", 60).SetTextAlignment(TextAlignment.Right);
			//합격여부
			grdIQCList.View.AddTextBoxColumn("RESULTCODENAME", 70).SetLabel("ISPASS").SetTextAlignment(TextAlignment.Center);
			//검사자
			grdIQCList.View.AddTextBoxColumn("INSPECTOR", 70).SetTextAlignment(TextAlignment.Center);
			//검사일
			grdIQCList.View.AddTextBoxColumn("INSPECTIONDATE", 80).SetTextAlignment(TextAlignment.Center);
			//비고
			grdIQCList.View.AddTextBoxColumn("COMMENT", 120);

			//숨김
			
			grdIQCList.View.AddTextBoxColumn("PURCHASENO").SetIsHidden();
			grdIQCList.View.AddTextBoxColumn("FILEID").SetIsHidden();
			grdIQCList.View.AddTextBoxColumn("INSPECTIONTYPE").SetIsHidden();
			grdIQCList.View.AddTextBoxColumn("FILEDATA").SetIsHidden();

			grdIQCList.View.PopulateColumns();
			#endregion

			#region 수입검사
			grdMaterialIQC.GridButtonItem = GridButtonItem.Add | GridButtonItem.Delete;
			grdMaterialIQC.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

			//S/N
			grdMaterialIQC.View.AddTextBoxColumn("DELIVERYSERIALNO", 80).SetLabel("SERIALNO2").SetValidationKeyColumn();
			//A ~ T VALUE
			grdMaterialIQC.View.AddTextBoxColumn("A", 80);
			grdMaterialIQC.View.AddTextBoxColumn("B", 80);
			grdMaterialIQC.View.AddTextBoxColumn("C", 80);
			grdMaterialIQC.View.AddTextBoxColumn("D", 80);
			grdMaterialIQC.View.AddTextBoxColumn("E", 80);
			grdMaterialIQC.View.AddTextBoxColumn("F", 80);
			grdMaterialIQC.View.AddTextBoxColumn("G", 80);
			grdMaterialIQC.View.AddTextBoxColumn("H", 80);
			grdMaterialIQC.View.AddTextBoxColumn("I", 80);
			grdMaterialIQC.View.AddTextBoxColumn("J", 80);
			grdMaterialIQC.View.AddTextBoxColumn("K", 80);
			grdMaterialIQC.View.AddTextBoxColumn("L", 80);
			grdMaterialIQC.View.AddTextBoxColumn("M", 80);
			grdMaterialIQC.View.AddTextBoxColumn("N", 80);
			//grdMaterialIQC.View.AddTextBoxColumn("O", 80);
			//grdMaterialIQC.View.AddTextBoxColumn("P", 80);
			//grdMaterialIQC.View.AddTextBoxColumn("Q", 80);
			//grdMaterialIQC.View.AddTextBoxColumn("R", 80);
			//grdMaterialIQC.View.AddTextBoxColumn("S", 80);
			//grdMaterialIQC.View.AddTextBoxColumn("T", 80);
			//판정
			grdMaterialIQC.View.AddComboBoxColumn("RESULTCODE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=InspectionResult", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetValidationIsRequired().SetTextAlignment(TextAlignment.Center);

			grdMaterialIQC.View.PopulateColumns();

			#endregion

			#region 검사이력
			grdInspectionHistory.GridButtonItem = GridButtonItem.Export;
			grdInspectionHistory.View.SetIsReadOnly();

			grdInspectionHistory.View.AddTextBoxColumn("DELIVERYNO", 80).SetTextAlignment(TextAlignment.Center);
			grdInspectionHistory.View.AddTextBoxColumn("DELIVERYSEQUENCE", 70)
				.SetTextAlignment(TextAlignment.Center)
				.SetLabel("DELVSERL")
				.SetIsHidden();
			grdInspectionHistory.View.AddTextBoxColumn("CONSUMABLEDEFID", 100).SetIsHidden();
			grdInspectionHistory.View.AddTextBoxColumn("PARTNUMBER", 110).SetLabel("PRODUCTDEFID");
			grdInspectionHistory.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 150).SetLabel("PRODUCTDEFNAME");
			grdInspectionHistory.View.AddTextBoxColumn("STANDARD", 120);
			grdInspectionHistory.View.AddTextBoxColumn("DELIVERYDATE", 80).SetTextAlignment(TextAlignment.Center).SetLabel("DELIVERYDATE2");
			grdInspectionHistory.View.AddTextBoxColumn("DELIVERYQTY", 60).SetTextAlignment(TextAlignment.Right);
			grdInspectionHistory.View.AddTextBoxColumn("GOODQTY", 60).SetTextAlignment(TextAlignment.Right);
			grdInspectionHistory.View.AddTextBoxColumn("DEFECTQTY", 60).SetTextAlignment(TextAlignment.Right);
			grdInspectionHistory.View.AddTextBoxColumn("RESULTCODENAME", 70).SetLabel("ISPASS").SetTextAlignment(TextAlignment.Center);
			grdInspectionHistory.View.AddTextBoxColumn("INSPECTOR", 70).SetTextAlignment(TextAlignment.Center);
			grdInspectionHistory.View.AddTextBoxColumn("INSPECTIONDATE", 80).SetTextAlignment(TextAlignment.Center);
			grdInspectionHistory.View.AddTextBoxColumn("DELIVERYSERIALNO", 80).SetLabel("SERIALNO2").SetValidationKeyColumn();
			grdInspectionHistory.View.AddTextBoxColumn("A", 80);
			grdInspectionHistory.View.AddTextBoxColumn("B", 80);
			grdInspectionHistory.View.AddTextBoxColumn("C", 80);
			grdInspectionHistory.View.AddTextBoxColumn("D", 80);
			grdInspectionHistory.View.AddTextBoxColumn("E", 80);
			grdInspectionHistory.View.AddTextBoxColumn("F", 80);
			grdInspectionHistory.View.AddTextBoxColumn("G", 80);
			grdInspectionHistory.View.AddTextBoxColumn("H", 80);
			grdInspectionHistory.View.AddTextBoxColumn("I", 80);
			grdInspectionHistory.View.AddTextBoxColumn("J", 80);
			grdInspectionHistory.View.AddTextBoxColumn("K", 80);
			grdInspectionHistory.View.AddTextBoxColumn("L", 80);
			grdInspectionHistory.View.AddTextBoxColumn("M", 80);
			grdInspectionHistory.View.AddTextBoxColumn("N", 80);

			grdInspectionHistory.View.PopulateColumns();
			#endregion
		}

		/// <summary>
		/// 컨트롤 초기화
		/// </summary>
		private void InitializeControls()
		{
			txtProduct.Visible = false;

			txtDeliveryNo.EditValue = string.Empty;
			txtProduct.EditValue = string.Empty;
			txtProductName.EditValue = string.Empty;
			txtPartNumber.EditValue = string.Empty;
			txtPoNo.EditValue = string.Empty;
			txtVendor.EditValue = string.Empty;
			txtInspector.EditValue = string.Empty;
			txtDeliveryQty.EditValue = string.Empty;

			cboResult.DisplayMember = "CODENAME";
			cboResult.ValueMember = "CODEID";
			cboResult.DataSource = SqlExecuter.Query("GetCodeList", "00001", new Dictionary<string, object>() { { "CODECLASSID", "InspectionResult" }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });
			cboResult.UseEmptyItem = true;
			cboResult.ShowHeader = false;
			cboResult.ItemIndex = 0;

			spGoodQty.EditValue = 0;
			spDefectQty.EditValue = 0;
			txtComment.EditValue = string.Empty;
		}

		#endregion

		#region Event

		/// <summary>
		/// 화면에서 사용되는 이벤트를 초기화한다.
		/// </summary>
		public void InitializeEvent()
		{
			tabMaterialIQC.SelectedPageChanged += TabMaterialIQC_SelectedPageChanged;
			grdIQCList.View.DoubleClick += View_DoubleClick;
			grdIQCList.View.RowStyle += View_RowStyle;

			grdMaterialIQC.View.AddingNewRow += View_AddingNewRow;
			spGoodQty.ValueChanged += SpGoodQty_ValueChanged;
			spDefectQty.ValueChanged += SpDefectQty_ValueChanged;
		}

		/// <summary>
		/// 행 스타일
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			if(e == null) return;

			DataRow row = grdIQCList.View.GetDataRow(e.RowHandle);
			if(row == null) return;

			if (Format.GetFullTrimString(row["RESULTCODE"]).Equals("OK"))
			{
				e.Appearance.BackColor = Color.LightGray;
				e.HighPriority = true;
			}

			if (Format.GetFullTrimString(row["RESULTCODE"]).Equals("NG"))
			{
				e.Appearance.BackColor = Color.Salmon;
				e.HighPriority = true;
			}

			if (Format.GetFullTrimString(row["RESULTCODE"]).Equals("PartialOK"))
			{
				e.Appearance.BackColor = Color.SandyBrown;
				e.HighPriority = true;
			}
		}

		/// <summary>
		/// 불량수량 Value Change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SpDefectQty_ValueChanged(object sender, EventArgs e)
		{
			QtyValueChange(spDefectQty, spGoodQty);
		}

		/// <summary>
		/// 양품수량 Value Change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SpGoodQty_ValueChanged(object sender, EventArgs e)
		{
			QtyValueChange(spGoodQty, spDefectQty);
		}

		/// <summary>
		/// 양품수량 & 불량 수량 계산
		/// </summary>
		/// <param name="input"></param>
		/// <param name="output"></param>
		private void QtyValueChange(SmartSpinEdit input, SmartSpinEdit output)
		{
			double deliveryQty = Format.GetDouble(txtDeliveryQty.EditValue, 0);
			double inputQty = Format.GetDouble(input.EditValue, 0);

			double outputQty = deliveryQty - inputQty;
			if (outputQty < 0)
			{
				//수량을 초과하였습니다.
				ShowMessage("OVERQTY");
				input.EditValue = 0;
				output.EditValue = 0;
				return;
			}

			output.EditValue = outputQty;
		}

		/// <summary>
		/// 수입 검사 결과 행 추가 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
		{
			args.NewRow["DELIVERYNO"] = txtDeliveryNo.EditValue;
			args.NewRow["CONSUMABLEDEFID"] = txtProduct.EditValue;
			args.NewRow["DELIVERYSEQUENCE"] = txtDeliverySeq.EditValue;
		}

		/// <summary>
		///	ROW 더블클릭 시 수입검사 시작
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_DoubleClick(object sender, EventArgs e)
		{
			if(grdIQCList.View.FocusedRowHandle < 0) return;

			DataRow doubleClickRow = grdIQCList.View.GetFocusedDataRow();
			if(doubleClickRow == null) return;

			tabMaterialIQC.SelectedTabPageIndex = 1;

			spGoodQty.ValueChanged -= SpGoodQty_ValueChanged;
			spDefectQty.ValueChanged -= SpDefectQty_ValueChanged;
			Commons.CommonFunction.BindDataToControlsTag(doubleClickRow, tlpIQC);

			grdMaterialIQC.DataSource = SqlExecuter.Query("SelectMaterialIQCResultList", "00001", new Dictionary<string, object>() { { "DELIVERYNO", doubleClickRow["DELIVERYNO"] },
																																	 { "CONSUMABLEDEFID", doubleClickRow["CONSUMABLEDEFID"] },
																																	 { "DELIVERYSEQUENCE", doubleClickRow["DELIVERYSEQUENCE"] } });

			//수입 검사 전
			//검사자 = 로그인 USER
			if(string.IsNullOrEmpty(Format.GetFullTrimString(txtInspector.EditValue)))
			{
				txtInspector.EditValue = UserInfo.Current.Name;
			}
			//양품수량 = 0
			if (string.IsNullOrEmpty(Format.GetFullTrimString(spGoodQty.EditValue)))
			{
				spGoodQty.EditValue = 0;
			}
			//불량수량 = 0
			if (string.IsNullOrEmpty(Format.GetFullTrimString(spDefectQty.EditValue)))
			{
				spDefectQty.EditValue = 0;
			}

			spGoodQty.ValueChanged += SpGoodQty_ValueChanged;
			spDefectQty.ValueChanged += SpDefectQty_ValueChanged;

			//SET 검사 기준 이미지
			try
			{
				this.ShowWaitArea();
				//DialogManager.ShowWaitDialog();

				DataTable imgDt = SqlExecuter.Query("GetStdInspectionImage", "00001", new Dictionary<string, object>() { { "CONSUMABLEDEFID", doubleClickRow["CONSUMABLEDEFID"] } });

				MemoryStream ms = new MemoryStream(Convert.FromBase64String(Format.GetString(imgDt.Rows[0]["FILEDATA"])));
				picStdInspectionImage.Image = Image.FromStream(ms);
			}
			catch (Exception ex)
			{
				//등록된 검사 기준 이미지가 없습니다.
				ShowMessage("NOINSPECTIONSTDIMAGE");
				//MessageBox.Show(ex.ToString());
			}
			finally
			{
				this.CloseWaitArea();
				//DialogManager.Close();
			}
		}

		/// <summary>
		/// 탭 이동 시 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TabMaterialIQC_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			var buttons = pnlToolbar.Controls.Find<SmartButton>(true);
			SmartButton btn = buttons.FirstOrDefault();

			//버튼 SHOW & HIDDEN
			switch (tabMaterialIQC.SelectedTabPageIndex)
			{
				case 0://조회
					btn.Hide();
					break;
				case 1://수입검사
					btn.Show();
					break;
				case 2://검사이력
					btn.Hide();

					var values = Conditions.GetValues();
					values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

					grdInspectionHistory.DataSource = SqlExecuter.Query("SelectMaterialIQCHistoryList", "00001", values);
					break;
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
			SmartButton btn = sender as SmartButton;
			switch(btn.Name.ToString())
			{
				case "Save":
					if (string.IsNullOrEmpty(Format.GetFullTrimString(cboResult.EditValue)))
					{
						//판정결과를 선택하세요.
						ShowMessage("ISREQUIREDRESULTCODE");
						return;
					}

					double goodQty = Format.GetDouble(spGoodQty.EditValue, 0);
					double defectQty = Format.GetDouble(spDefectQty.EditValue, 0);
					double deliveryQty = Format.GetDouble(txtDeliveryQty.EditValue, 0);
					if(goodQty + defectQty != deliveryQty)
					{
						//수량을 입력하세요.
						ShowMessage("ISREQUIREDQTY");
						return;
					}

					grdMaterialIQC.View.CheckValidation();

					DataTable dtResult = grdMaterialIQC.GetChangedRows();
					if (dtResult.Rows.Count < 1)
					{
						//검사 결과를 입력하세요.
						ShowMessage("ISREQUIREDINSPECTIONRESULT");
						return;
					}

					DataTable dt = GetInspectionInfo();

					MessageWorker worker = new MessageWorker("SaveMaterialIQC");
					worker.SetBody(new MessageBody()
					{
						{ "iqcList",  dt },
						{ "iqcResultList",  dtResult }
					});

					worker.Execute();
					ShowMessage("SuccessSave");
					OnSearchAsync();
					break;
			}
		}
		#endregion

		/// <summary>
		/// Get 수입 검사 결과
		/// </summary>
		/// <returns></returns>
		private DataTable GetInspectionInfo()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("DELIVERYNO", typeof(string));
			dt.Columns.Add("CONSUMABLEDEFID", typeof(string));
			dt.Columns.Add("DELIVERYSEQUENCE", typeof(int));
			dt.Columns.Add("RESULTCODE", typeof(string));
			dt.Columns.Add("GOODQTY", typeof(double));
			dt.Columns.Add("DEFECTQTY", typeof(double));
			dt.Columns.Add("COMMENT", typeof(string));

			DataRow row = dt.NewRow();
			row["DELIVERYNO"] = Format.GetFullTrimString(txtDeliveryNo.EditValue);
			row["CONSUMABLEDEFID"] = Format.GetFullTrimString(txtProduct.EditValue);
			row["DELIVERYSEQUENCE"] = Format.GetInteger(txtDeliverySeq.EditValue);
			row["RESULTCODE"] = Format.GetFullTrimString(cboResult.EditValue);
			row["GOODQTY"] = Format.GetDouble(spGoodQty.EditValue, 0);
			row["DEFECTQTY"] = Format.GetDouble(spDefectQty.EditValue, 0);
			row["COMMENT"] = Format.GetFullTrimString(txtComment.EditValue);

			dt.Rows.Add(row);

			return dt;
		}

		#region 검색

		/// <summary>
		/// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
		/// </summary>
		protected async override Task OnSearchAsync()
		{
			await base.OnSearchAsync();

			//초기화
			spGoodQty.ValueChanged -= SpGoodQty_ValueChanged;
			spDefectQty.ValueChanged -= SpDefectQty_ValueChanged;
			InitializeControls();
			spGoodQty.ValueChanged += SpGoodQty_ValueChanged;
			spDefectQty.ValueChanged += SpDefectQty_ValueChanged;

			grdMaterialIQC.View.ClearDatas();
			grdIQCList.View.ClearDatas();
			grdInspectionHistory.View.ClearDatas();
			picStdInspectionImage.Image = null;
			
			var values = Conditions.GetValues();
			values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

			int index = tabMaterialIQC.SelectedTabPageIndex;

			if (tabMaterialIQC.SelectedTabPageIndex == 1)
			{
				tabMaterialIQC.SelectedTabPageIndex = 0;
			}
			
			switch(index)
			{
				case 2:
					grdInspectionHistory.DataSource = SqlExecuter.Query("SelectMaterialIQCHistoryList", "00001", values);
					break;
				default:
					DataTable dtIQCList = await QueryAsync("SelectMaterialIQCList", "00001", values);
					if (dtIQCList.Rows.Count < 1)
					{
						// 조회할 데이터가 없습니다.
						ShowMessage("NoSelectData");
					}
					grdIQCList.DataSource = dtIQCList;
					break;
			}
		}

		/// <summary>
		/// 조회조건 항목을 추가한다.
		/// </summary>
		protected override void InitializeCondition()
		{
			base.InitializeCondition();

			//납품번호
			InitializeCondition_DeliveryNo();
			//품목코드
			InitializeCondition_ConsumableDef();
		}

		/// <summary>
		/// 조회조건의 컨트롤을 추가한다.
		/// </summary>
		protected override void InitializeConditionControls()
		{
			base.InitializeConditionControls();

			// TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
		}

		/// <summary>
		/// 팝업형 조회조건 생성 - 납품번호
		/// </summary>
		private void InitializeCondition_DeliveryNo()
		{
			var deliveryNo = Conditions.AddSelectPopup("DELIVERYNO", new SqlQuery("GetDeliveryList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetPopupLayout("SELECTDELIVERYNO", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupResultCount(0)
				.SetPopupLayoutForm(800, 800, FormBorderStyle.FixedToolWindow)
				.SetPopupAutoFillColumns("CONSUMABLEDEFNAME")
				.SetPosition(1.1);

			deliveryNo.Conditions.AddTextBox("DELIVERYNO");
			deliveryNo.Conditions.AddTextBox("TXTCONSUMABELDEF").SetLabel("TXTPRODUCTDEFNAME");

			deliveryNo.GridColumns.AddTextBoxColumn("DELIVERYNO", 80).SetTextAlignment(TextAlignment.Center);
			deliveryNo.GridColumns.AddTextBoxColumn("CONSUMABLEDEFID", 100).SetLabel("PRODUCTDEFID");
			deliveryNo.GridColumns.AddTextBoxColumn("CONSUMABLEDEFNAME", 150).SetLabel("PRODUCTDEFNAME");
			deliveryNo.GridColumns.AddTextBoxColumn("DELIVERYDATE", 80).SetTextAlignment(TextAlignment.Center).SetLabel("DELIVERYDATE2");
		}

		/// <summary>
		/// 팝업형 조회조건 생성 - 품목코드
		/// </summary>
		private void InitializeCondition_ConsumableDef()
		{
			var consumableDef = Conditions.AddSelectPopup("CONSUMABLEDEFID", new SqlQuery("GetConsumableList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupResultCount(0)
				.SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
				.SetPopupAutoFillColumns("CONSUMABLEDEFNAME")
				.SetPosition(1.2)
				.SetLabel("PRODUCTDEFID");

			consumableDef.DisplayFieldName = "PARTNUMBER";

			consumableDef.Conditions.AddTextBox("TXTCONSUMABELDEF").SetLabel("TXTPRODUCTDEFNAME");

			consumableDef.GridColumns.AddTextBoxColumn("CONSUMABLEDEFID", 100).SetIsHidden();
			consumableDef.GridColumns.AddTextBoxColumn("PARTNUMBER", 100).SetLabel("PRODUCTDEFID");
			consumableDef.GridColumns.AddTextBoxColumn("CONSUMABLEDEFNAME", 150).SetLabel("PRODUCTDEFNAME");
		}

		#endregion

		#region 유효성 검사

		/// <summary>
		/// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
		/// </summary>
		protected override void OnValidateContent()
		{
			base.OnValidateContent();

			// TODO : 유효성 로직 변경
			//grdMaterialIQC.View.CheckValidation();
		}

		#endregion

	}
}