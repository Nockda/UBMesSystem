#region using

using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.StandardInfo
{
	/// <summary>
	/// 프 로 그 램 명  : 기준정보 > 코드 관리 > Spec 관리
	/// 업  무  설  명  : Spec 등록 및 세부공정 관리
	/// 생    성    자  : 정승원
	/// 생    성    일  : 2020-05-20
	/// 수  정  이  력  : 2020-07-28 | 세부공정 중복 X , 유효성 검사(필수컬럼) 추가
	///					  2020-09-17 | 이준용 | 유효상태 컬럼 추가	
	/// 
	/// 
	/// </summary>
	public partial class SpecManagement : SmartConditionBaseForm
	{
		#region Local Variables

		private readonly string MAIN_SEGMENT = "MAIN";
		private readonly string SUB_SEGMENT = "SUB";
		private readonly string INSP_ITEM = "ITEM";
		private readonly string SPEC_SEARCH = "SPEC";

		private DataTable _specTypeLUB = new DataTable();
		private DataTable _specTypeS = new DataTable();
		#endregion

		#region 생성자

		public SpecManagement()
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
			InitializeGridMask();

			_specTypeLUB = SqlExecuter.Query("GetCodeList", "00001", new Dictionary<string, object>(){  { "NOTINCODEID", "STRING" },
																										{ "CODECLASSID", "SpecType" },
																										{ "LANGUAGETYPE", UserInfo.Current.LanguageType } });

			_specTypeS = SqlExecuter.Query("GetCodeList", "00001", new Dictionary<string, object>(){ { "NOTINCODEID", "BOTH','LOWER','UPPER" },
																									 { "CODECLASSID", "SpecType" },
																									 { "LANGUAGETYPE", UserInfo.Current.LanguageType } });

		}

		/// <summary>
		/// 정규식 적용
		/// </summary>
		private void InitializeGridMask()
		{
			DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repository = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

			repository = grdSubSpec.View.Columns["USERSEQUENCE"].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemTextEdit;
			repository.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			repository.Mask.EditMask = @"\d*";
			repository.Mask.UseMaskAsDisplayFormat = true;

			repository = grdSpecDetail.View.Columns["DISPLAYSEQUENCE"].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemTextEdit;
			repository.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			repository.Mask.EditMask = @"\d*";
			repository.Mask.UseMaskAsDisplayFormat = true;
		}

		/// <summary>        
		/// 그리드를 초기화한다.
		/// </summary>
		private void InitializeGrid()
		{
			// TODO : 그리드 초기화 로직 추가
			#region SPEC 등록
			grdMainSpec.GridButtonItem = GridButtonItem.All;
			grdMainSpec.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

			//SPECID
			grdMainSpec.View.AddTextBoxColumn("SPECDEFID", 100).SetValidationKeyColumn();
			//SPEC명
			grdMainSpec.View.AddLanguageColumn("SPECDEFNAME", 150);
			//공정ID
			grdMainSpec.View.AddTextBoxColumn("PROCESSSEGMENTID", 80).SetIsHidden();
			//grdMainSpec.View.AddTextBoxColumn("PROCESSSEGMENTVERSION").SetIsHidden();
			//공정명
			InitializeGrid_MainProcesssegment();
			//분할여부
			grdMainSpec.View.AddComboBoxColumn("ISDIVIDE", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YesNo", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center).SetLabel("ISSPLIT");
			//유효
			grdMainSpec.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetDefault("Valid").SetValidationIsRequired().SetTextAlignment(TextAlignment.Center);
			//생성자
			grdMainSpec.View.AddTextBoxColumn("CREATOR", 80).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//생성시간
			grdMainSpec.View.AddTextBoxColumn("CREATEDTIME", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//수정자
			grdMainSpec.View.AddTextBoxColumn("MODIFIER", 80).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//수정시간
			grdMainSpec.View.AddTextBoxColumn("MODIFIEDTIME", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);

			//다국어ID
			grdMainSpec.View.AddTextBoxColumn("DICTIONARYID").SetIsHidden();
			//ENTERPRISEID
			grdMainSpec.View.AddTextBoxColumn("ENTERPRISEID").SetIsHidden();
			//PLANTID
			grdMainSpec.View.AddTextBoxColumn("PLANTID").SetIsHidden();

			grdMainSpec.View.PopulateColumns();
			#endregion

			#region 세부 작업 공정 정보
			grdSubSpec.GridButtonItem = GridButtonItem.All;
			grdSubSpec.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
			grdSubSpec.View.SetSortOrder("SPECSEQ");

			//SEQ
			grdSubSpec.View.AddTextBoxColumn("SPECSEQUENCE").SetIsHidden();
			//SPEC ID
			grdSubSpec.View.AddTextBoxColumn("SPECDEFID").SetIsHidden();
			//순서
			grdSubSpec.View.AddTextBoxColumn("USERSEQUENCE", 50).SetTextAlignment(TextAlignment.Center).SetLabel("SPECSEQ");
			//SUB 공정 ID
			grdSubSpec.View.AddTextBoxColumn("SUBPROCESSSEGMENTID", 100).SetIsHidden();
			//SUB 공정
			InitializeGrid_SubProcesssegment();
			//실적여부
			grdSubSpec.View.AddComboBoxColumn("ISRESULT", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YesNo", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			//외주여부
			grdSubSpec.View.AddComboBoxColumn("ISOUTSOURCING", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YesNo", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			//유효상태
			grdSubSpec.View.AddComboBoxColumn("VALIDSTATE", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetValidationIsRequired().SetTextAlignment(TextAlignment.Center)
				.SetDefault("Valid");

			grdSubSpec.View.PopulateColumns();
			#endregion

			#region 실적 입력 항목 정보
			grdSpecDetail.GridButtonItem = GridButtonItem.All;
			grdSpecDetail.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

			//SPEC ID
			grdSpecDetail.View.AddTextBoxColumn("SPECDEFID").SetIsHidden();
			//SEQ
			grdSpecDetail.View.AddTextBoxColumn("SPECSEQUENCE").SetIsHidden();
			//표시순서
			grdSpecDetail.View.AddTextBoxColumn("DISPLAYSEQUENCE", 70).SetTextAlignment(TextAlignment.Center);
			//입력항목ID
			grdSpecDetail.View.AddTextBoxColumn("PARAMETERID", 80).SetIsHidden().SetValidationKeyColumn();
			//입력항목명
			InitializeGrid_InspItem();
			//입력타입
			grdSpecDetail.View.AddComboBoxColumn("INPUTTYPE", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=InspItemInputType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetLabel("SPECDEFTYPE").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//단위
			grdSpecDetail.View.AddTextBoxColumn("UNIT", 70).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//스펙타입
			grdSpecDetail.View.AddComboBoxColumn("SPECTYPE", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=SpecType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			//하한치
			grdSpecDetail.View.AddSpinEditColumn("LSL", 80).SetDisplayFormat("#,##0.######;-#,##0.######", MaskTypes.Numeric, true).SetValueRange(decimal.MinValue, decimal.MaxValue);
			//상한치
			grdSpecDetail.View.AddSpinEditColumn("USL", 80).SetDisplayFormat("#,##0.######;-#,##0.######", MaskTypes.Numeric, true).SetValueRange(decimal.MinValue, decimal.MaxValue);
			//측정여부
			grdSpecDetail.View.AddComboBoxColumn("ISMEASURE", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YesNo", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			//스펙강제여부
			grdSpecDetail.View.AddComboBoxColumn("ISSPECFORCE", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YesNo", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			//유효상태
			grdSpecDetail.View.AddComboBoxColumn("VALIDSTATE", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetValidationIsRequired().SetTextAlignment(TextAlignment.Center)
				.SetDefault("Valid");

			grdSpecDetail.View.PopulateColumns();
            #endregion

            #region 스펙조회 그리드
            grdSpecSearch.GridButtonItem = GridButtonItem.Export;
            grdSpecSearch.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            //grdSpecSearch.View.SetIsReadOnly();
            grdSpecSearch.View.AddTextBoxColumn("SPECDEFID", 70).SetIsReadOnly();
            grdSpecSearch.View.AddTextBoxColumn("SPECDEFNAME", 120).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 120).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("ISDIVIDE", 60).SetTextAlignment(TextAlignment.Center).SetLabel("ISSPLIT").SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("USERSEQUENCE", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("SUBPROCESSSEGMENTNAME", 130).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("ISRESULT", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("ISOUTSOURCING", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("DISPLAYSEQUENCE", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("PARAMETERNAME", 300).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("INPUTTYPENAME", 90).SetLabel("INPUTTYPE").SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("CODECLASSNAME", 100).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("UNIT", 110).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("DECIMALPLACE", 100).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("SPECTYPENAME", 80).SetTextAlignment(TextAlignment.Center).SetLabel("SPECTYPE").SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("LSL", 80).SetTextAlignment(TextAlignment.Right).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("USL", 80).SetTextAlignment(TextAlignment.Right).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("ISMEASURE", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			//grdSpecSearch.View.AddTextBoxColumn("ISSPECFORCE", 80).SetTextAlignment(TextAlignment.Center);
			//스펙강제여부컬럼 수정 가능하도록 구조 변경 2021-06-08 정송은
			grdSpecSearch.View.AddComboBoxColumn("ISSPECFORCE", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YesNo", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			grdSpecSearch.View.AddTextBoxColumn("ISNOTREQUIRED", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("VALIDSTATE", 140).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			grdSpecSearch.View.AddTextBoxColumn("SPECSEQUENCE", 70).SetIsHidden(); //SPECSEQUENCE 컬럼 추가 2021-06-08 정송은
			grdSpecSearch.View.PopulateColumns();
            #endregion
        }

        /// <summary>
        /// 팝업형 컬럼 초기화 - 공정명
        /// </summary>
        private void InitializeGrid_MainProcesssegment()
		{
			var processsegment = grdMainSpec.View.AddSelectPopupColumn("PROCESSSEGMENTNAME", 150, new SqlQuery("GetProcessList", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", "PROCESSSEGMENTTYPE=MAIN"))
				.SetPopupLayout("SELECTPROCESSSEGMENT", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupResultCount(1)
				.SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
				.SetPopupAutoFillColumns("PROCESSSEGMENTNAME")
				.SetPopupApplySelection((selectedRows, dataGridRows) =>
				{
					if (dataGridRows == null) return;

					DataRow r = selectedRows.AsEnumerable().FirstOrDefault();
					if (r == null)
					{
						dataGridRows["PROCESSSEGMENTID"] = string.Empty;
						//dataGridRows["PROCESSSEGMENTVERSION"] = string.Empty; 
					}
					else
					{
						dataGridRows["PROCESSSEGMENTID"] = r["PROCESSSEGMENTID"];
						//dataGridRows["PROCESSSEGMENTVERSION"] = r["PROCESSSEGMENTVERSION"];
					}

				})
				.SetValidationIsRequired();

			//공정 코드 / 명
			processsegment.Conditions.AddTextBox("TXTPROCESSSEGMENT");

			processsegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 100);
			processsegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 150);
			//processsegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTVERSEION", 70);
		}

		/// <summary>
		/// 팝업형 컬럼 초기화 - SUB 공정명
		/// </summary>
		private void InitializeGrid_SubProcesssegment()
		{
			var processsegment = grdSubSpec.View.AddSelectPopupColumn("SUBPROCESSSEGMENTNAME", 150, new SqlQuery("GetProcessList", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", "PROCESSSEGMENTTYPE=SUB", $"ENTERPRISEID={UserInfo.Current.Enterprise}", $"PLANTID={UserInfo.Current.Plant}"))
				.SetPopupLayout("SELECTSUBPROCESSSEGMENT", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupResultCount(1)
				.SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
				.SetPopupAutoFillColumns("PROCESSSEGMENTNAME")
				.SetPopupResultMapping("SUBPROCESSSEGMENTNAME", "PROCESSSEGMENTNAME")
				.SetPopupApplySelection((selectedRows, dataGridRows) =>
				{
					if (dataGridRows == null) return;

					DataRow r = selectedRows.AsEnumerable().FirstOrDefault();
					if (r == null)
					{
						dataGridRows["SUBPROCESSSEGMENTID"] = string.Empty;
					}
					else
					{
						dataGridRows["SUBPROCESSSEGMENTID"] = r["PROCESSSEGMENTID"];
					}

				})
				.SetValidationIsRequired();

			//공정 코드 / 명
			processsegment.Conditions.AddTextBox("TXTPROCESSSEGMENT");

			processsegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 100);
			processsegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 150);
		}

		/// <summary>
		/// 팝업형 컬럼 초기화 - 입력항목명
		/// </summary>
		private void InitializeGrid_InspItem()
		{
			var processsegment = grdSpecDetail.View.AddSelectPopupColumn("PARAMETERNAME", 150, new SqlQuery("GetParameterDefList", "00001", "PARAMETERTYPE=Process", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetPopupLayout("SELECTINSPITEM", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupResultCount(1)
				.SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
				.SetPopupAutoFillColumns("ITEMNAME")
				.SetPopupApplySelection((selectedRows, dataGridRows) =>
				{
					if (dataGridRows == null) return;

					DataRow r = selectedRows.AsEnumerable().FirstOrDefault();
					if (r == null)
					{
						dataGridRows["PARAMETERID"] = string.Empty;
						dataGridRows["UNIT"] = string.Empty;
						dataGridRows["INPUTTYPE"] = string.Empty;
						dataGridRows["SPECTYPE"] = string.Empty;
					}
					else
					{
						dataGridRows["PARAMETERID"] = r["PARAMETERID"];
						dataGridRows["UNIT"] = r["UNIT"];
						dataGridRows["INPUTTYPE"] = r["INPUTTYPE"];
						//if(Format.GetTrimString(r["INPUTTYPE"]).Equals("FLOAT") || Format.GetTrimString(r["INPUTTYPE"]).Equals("INT"))
						//{
						//	dataGridRows["SPECTYPE"] = "BOTH";
						//}
						//else
						//{
						//	dataGridRows["SPECTYPE"] = "STRING";
						//}
					}
				})
				.SetLabel("SPECITEMNAME")
				.SetValidationKeyColumn();

			//항목코드 / 명
			processsegment.Conditions.AddTextBox("TXTITEMID");

			processsegment.GridColumns.AddTextBoxColumn("PARAMETERID", 100);
			processsegment.GridColumns.AddTextBoxColumn("PARAMETERNAME", 150);
			processsegment.GridColumns.AddTextBoxColumn("UNIT", 60);
			processsegment.GridColumns.AddComboBoxColumn("INPUTTYPE", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=InspItemInputType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
		}
		#endregion

		#region Event

		/// <summary>
		/// 화면에서 사용되는 이벤트를 초기화한다.
		/// </summary>
		public void InitializeEvent()
		{
			grdMainSpec.ToolbarAddingRow += GrdMainSpec_ToolbarAddingRow;// += GrdMainSpec_AddingNewRow;
			grdSubSpec.ToolbarAddingRow += GrdSubSpec_ToolbarAddingRow;// += GrdSubSpec_AddingNewRow;
			grdSpecDetail.ToolbarAddingRow += GrdSpecDetail_ToolbarAddingRow;// += GrdSpecDetail_AddingNewRow;
																			 //grdMainSpec.View.AddingNewRow += GrdMainSpec_AddingNewRow;
			grdSubSpec.View.AddingNewRow += GrdSubSpec_AddingNewRow;
			grdSpecDetail.View.AddingNewRow += GrdSpecDetail_AddingNewRow;

			grdMainSpec.View.FocusedRowChanged += GrdMainSpec_FocusedRowChanged;
			grdSubSpec.View.FocusedRowChanged += GrdSubSpec_FocusedRowChanged;

			grdSpecDetail.View.ShowingEditor += View_ShowingEditor;
			grdSpecDetail.View.RowCellStyle += View_RowCellStyle;
			grdSpecDetail.View.CustomRowCellEdit += View_CustomRowCellEdit;
		}

		private void View_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
		{
			DataRow r = grdSpecDetail.View.GetDataRow(e.RowHandle);

			if (e.Column.FieldName.Equals("SPECTYPE"))
			{
				RepositoryItemLookUpEdit newEditor = new RepositoryItemLookUpEdit();
				newEditor.Assign(e.Column.ColumnEdit as RepositoryItemLookUpEdit);

				if (Format.GetFullTrimString(r["INPUTTYPE"]).ToUpper().Equals("INT")
				|| Format.GetFullTrimString(r["INPUTTYPE"]).ToUpper().Equals("FLOAT"))
				{
					newEditor.DataSource = _specTypeLUB;
				}
				else
				{
					newEditor.DataSource = _specTypeS;
					//grdSpecDetail.View.SetFocusedRowCellValue("SPECTYPE", "STRING");
				}

				e.RepositoryItem = newEditor;
			}
		}

		private void GrdMainSpec_ToolbarAddingRow(object sender, CancelEventArgs e)
		{
			CancelNewRow(grdSubSpec, grdSpecDetail, e);
		}

		private void GrdSubSpec_ToolbarAddingRow(object sender, CancelEventArgs e)
		{
			bool isCancel = CancelNewRow(grdMainSpec, e);
			if (isCancel) return;

			isCancel = CancelNewRow(grdMainSpec, grdSpecDetail, e);
			if (isCancel) return;
		}

		private void GrdSpecDetail_ToolbarAddingRow(object sender, CancelEventArgs e)
		{
			bool isCancel = CancelNewRow(grdSubSpec, e);
			if (isCancel) return;

			isCancel = CancelNewRow(grdMainSpec, grdSubSpec, e);
			if (isCancel) return;
		}

		/// <summary>
		/// 세부작업 공정 정보 행 추가 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void GrdSubSpec_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
		{
			//MAIN공정 값 넣어주기
			DataRow row = grdMainSpec.View.GetFocusedDataRow();
			if (row == null) return;

			if (string.IsNullOrWhiteSpace(Format.GetFullTrimString(row["PROCESSSEGMENTID"])))
			{
				//MAIN 공정을 먼저 등록하여 주세요.
				ShowMessage("INPUTMAINSEGMENTID");
				args.IsCancel = true;
				return;
			}

			args.NewRow["SPECDEFID"] = row["SPECDEFID"];
			int maxSeq = (grdSubSpec.DataSource as DataTable).AsEnumerable().Select(r => Format.GetInteger(r["SPECSEQUENCE"])).Distinct().Max();
			args.NewRow["SPECSEQUENCE"] = maxSeq + 1;
		}

		/// <summary>
		/// 실적 입력 항목 정보 행 추가 시 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void GrdSpecDetail_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
		{
			//SPECID, SUB공정 값 넣어주기
			DataRow row = grdSubSpec.View.GetFocusedDataRow();
			if (row == null) return;

			if (string.IsNullOrWhiteSpace(Format.GetFullTrimString(row["SPECDEFID"]))
			|| string.IsNullOrWhiteSpace(Format.GetFullTrimString(row["SPECSEQUENCE"])))
			{
				//SUB 공정을 먼저 등록하여 주세요.
				ShowMessage("INPUTSUBSEGMENTID");
				return;
			}

			args.NewRow["SPECDEFID"] = row["SPECDEFID"];
			//args.NewRow["SUBPROCESSSEGMENTID"] = row["SUBPROCESSSEGMENTID"];
			//int maxSeq = (grdSpecDetail.DataSource as DataTable).AsEnumerable().Select(r => Format.GetInteger(r["SPECSEQUENCE"])).Distinct().Max();
			args.NewRow["SPECSEQUENCE"] = row["SPECSEQUENCE"];
		}

		/// <summary>
		/// Style
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
		{
			if (e == null) return;

			string value = Format.GetTrimString(grdSpecDetail.View.GetRowCellValue(e.RowHandle, "SPECTYPE"));
			switch (value)
			{
				case "STRING":
					if (e.Column.FieldName == "LSL" || e.Column.FieldName == "USL" || e.Column.FieldName == "SPECTYPE")
					{
						e.Appearance.BackColor = Color.DarkGray;
					}
					break;
				case "LOWER":
					if (e.Column.FieldName == "USL")
					{
						e.Appearance.BackColor = Color.DarkGray;
					}
					break;
				case "UPPER":
					if (e.Column.FieldName == "LSL")
					{
						e.Appearance.BackColor = Color.DarkGray;
					}
					break;
			}
		}

		/// <summary>
		/// ReadOnly 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_ShowingEditor(object sender, CancelEventArgs e)
		{
			DataRow row = grdSpecDetail.View.GetFocusedDataRow();
			if (row == null) return;

			string focusColumn = grdSpecDetail.View.FocusedColumn.FieldName;

			string value = Format.GetFullTrimString(row["SPECTYPE"]);

			switch (value)
			{
				case "STRING":
					if (focusColumn.Equals("LSL") || focusColumn.Equals("USL"))
					{
						e.Cancel = true;
					}
					break;
				case "LOWER":
					if (focusColumn.Equals("USL"))
					{
						e.Cancel = true;
					}
					break;
				case "UPPER":
					if (focusColumn.Equals("LSL"))
					{
						e.Cancel = true;
					}
					break;
			}

		}

		/// <summary>
		/// 세부작업 공정 정보 그리드 행 변경 시 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GrdSubSpec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if (grdSubSpec.View.FocusedRowHandle < 0) return;

			DataTable dt = grdSpecDetail.GetChangedRows();
			if (dt.Rows.Count > 0)
			{
				//행을 변경하시겠습니까? 현지 입력중인 정보는 사라집니다.
				if (ShowMessageBox("ChangeRowCurrentInputDataDelete", Language.Get("MESSAGEINFO"), MessageBoxButtons.OKCancel) != DialogResult.OK)
				{
					grdSubSpec.View.FocusedRowChanged -= GrdSubSpec_FocusedRowChanged;

					if (grdSubSpec.View.GetDataRow(e.FocusedRowHandle).RowState == DataRowState.Added)
					{
						grdSubSpec.View.DeleteRow(e.FocusedRowHandle);
					}

					grdSubSpec.View.FocusedRowHandle = e.PrevFocusedRowHandle;
					grdSubSpec.View.FocusedRowChanged += GrdSubSpec_FocusedRowChanged;
					return;
				}
			}


			DataRow focusRow = grdSubSpec.View.GetFocusedDataRow();
			if (focusRow == null) return;

			DataBindInspItemInfo(focusRow);
		}

		/// <summary>
		/// 실적 입력 항목 정보 데이터 바인드
		/// </summary>
		/// <param name="r"></param>
		private void DataBindInspItemInfo(DataRow r)
		{
			if (string.IsNullOrWhiteSpace(Format.GetFullTrimString(r["SPECDEFID"]))
			|| string.IsNullOrWhiteSpace(Format.GetFullTrimString(r["SPECSEQUENCE"])))
				return;

			var values = Conditions.GetValues();
			grdSpecDetail.DataSource = SqlExecuter.Query("GetSubSegmentDetailList", "00001", new Dictionary<string, object>() { { "LANGUAGETYPE", UserInfo.Current.LanguageType },
																																{ "SPECDEFID", r["SPECDEFID"] },
																																{ "SPECSEQUENCE", r["SPECSEQUENCE"] },
																																{ "P_VALIDSTATE", values["P_VALIDSTATE"] } });
		}

		/// <summary>
		/// SPEC 등록 그리드 행 변경 시 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GrdMainSpec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if (grdMainSpec.View.FocusedRowHandle < 0) return;

			DataTable subDt = grdSubSpec.GetChangedRows();
			DataTable detailDt = grdSpecDetail.GetChangedRows();
			if (subDt.Rows.Count > 0 || detailDt.Rows.Count > 0)
			{
				//행을 변경하시겠습니까? 현재 입력중인 정보는 사라집니다.
				if (ShowMessageBox("ChangeRowCurrentInputDataDelete", Language.Get("MESSAGEINFO"), MessageBoxButtons.OKCancel) != DialogResult.OK)
				{
					grdMainSpec.View.FocusedRowChanged -= GrdMainSpec_FocusedRowChanged;

					if (grdMainSpec.View.GetDataRow(e.FocusedRowHandle).RowState == DataRowState.Added)
					{
						grdMainSpec.View.DeleteRow(e.FocusedRowHandle);
					}

					grdMainSpec.View.FocusedRowHandle = e.PrevFocusedRowHandle;
					grdMainSpec.View.FocusedRowChanged += GrdMainSpec_FocusedRowChanged;
					return;
				}
			}


			grdSpecDetail.View.ClearDatas();

			DataRow focusRow = grdMainSpec.View.GetFocusedDataRow();
			if (focusRow == null) return;

			bool isNext = DataBindSubSegmentInfo(focusRow);
			if (!isNext)
			{
				grdSubSpec.View.ClearDatas();
				grdSpecDetail.View.ClearDatas();
				return;
			}

			DataRow detailFocusRow = grdSubSpec.View.GetFocusedDataRow();
			if (detailFocusRow == null) return;

			DataBindInspItemInfo(detailFocusRow);
		}

		/// <summary>
		/// 세부작업 공정 정보 데이터 바인드
		/// </summary>
		/// <param name="r"></param>
		private bool DataBindSubSegmentInfo(DataRow r)
		{
			if (string.IsNullOrWhiteSpace(Format.GetFullTrimString(r["SPECDEFID"])))
				return false;

			int prevHandle = grdSubSpec.View.FocusedRowHandle + 1;

			DataTable dt = SqlExecuter.Query("GetSubSegmentList", "00001", new Dictionary<string, object>() { { "SPECDEFID", r["SPECDEFID"] },
																													   { "LANGUAGETYPE", UserInfo.Current.LanguageType } });

			grdSubSpec.DataSource = dt;
			if (dt.Rows.Count < prevHandle)
			{
				grdSubSpec.View.FocusedRowHandle = 0;
			}

			return true;
		}

		/// <summary>
		/// 다른 그리드에서 행 추가하여 입력 작업을 하는 경우 행 추가 취소
		/// </summary>
		/// <param name="target1"></param>
		/// <param name="tartget2"></param>
		/// <param name="args"></param>
		private bool CancelNewRow(SmartBandedGrid target1, SmartBandedGrid tartget2, CancelEventArgs e)
		{
			DataTable targetDt1 = target1.GetChangesAdded();
			DataTable targetDt2 = tartget2.GetChangesAdded();

			if (targetDt1.Rows.Count > 0 || targetDt2.Rows.Count > 0)
			{
				//다른 정보의 입력사항을 먼저 저장해 주세요.
				ShowMessage("FIRSTSAVEINPUTINFO");
				e.Cancel = true;
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 부모 그리드 Row Focus 없을 때 행 추가 취소
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="args"></param>
		private bool CancelNewRow(SmartBandedGrid grid, CancelEventArgs e)
		{
			if (grid.View.FocusedRowHandle < 0)
			{
				e.Cancel = true;
				return true;
			}
			else
			{
				return false;
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
			//스펙조회 탭에서 스펙강제여부 수정 가능하도록 구조 변경으로 인해 주석처리
			/*
			if(smartTabControl1.SelectedTabPageIndex != 0)
            {
                return;
            }
			*/

			SmartButton btn = sender as SmartButton;
			switch (btn.Name.ToString())
			{
				case "Save":
					DataTable dt = new DataTable();
					string type = null;

					if (smartTabControl1.SelectedTabPageIndex == 0)
					{
						//스펙등록 탭일 때
						UpdateCurrentRow(grdMainSpec);
						UpdateCurrentRow(grdSubSpec);
						UpdateCurrentRow(grdSpecDetail);


						bool isCancel = Validation();
						if (isCancel) return;

						dt = grdMainSpec.GetChangedRows();
                        
                        type = MAIN_SEGMENT;
						if (dt.Rows.Count < 1)
						{
							dt = grdSubSpec.GetChangedRows();
                            type = SUB_SEGMENT;
							if (dt.Rows.Count < 1)
							{
								dt = grdSpecDetail.GetChangedRows();
								type = INSP_ITEM;
							}
						}

						//세부공정 중복 확인
						checkSubProcessOnlyOne();

						//필수값 유효성 검사
						grdMainSpec.View.CheckValidation();
						grdSpecDetail.View.CheckValidation();
						grdSubSpec.View.CheckValidation();

					}
					else 
					{
						//스펙조회 탭일 때
						UpdateCurrentRow(grdSpecSearch);

						dt = grdSpecSearch.GetChangedRows();
						type = SPEC_SEARCH;
					}


					MessageWorker worker = new MessageWorker("SaveSpecManagement");
					worker.SetBody(new MessageBody()
					{
						{ "specList", dt },
						{ "type", type },
						{ "enterpriseid", UserInfo.Current.Enterprise },
						{ "plantid", UserInfo.Current.Plant }
					});

					worker.Execute();

					ShowMessage("SuccessSave");

					break;

                // 2021-06-24 SPECID 복사팝업 추가
				case "CopySpec":
					//스펙복사 툴바 버튼 클릭했을 때 
					dt = grdMainSpec.View.GetCheckedRows();
                    DataTable changeDt = grdMainSpec.GetChangedRows();


                    if (dt.Rows.Count == 0) // 선택한 행이 없을때
					{
                        ShowMessage("NoSelected");

					}
                    else if (changeDt.Rows.Count != 0) // 상위그리드 마스터 데이터 저장안하고 스펙복사 버튼 클릭 시
                    {
                        ShowMessage("AfterSaveMasterRow");
                    }
                    else if (dt.Rows.Count > 1) // 여러행 선택 시
                    {
                        ShowMessage("CopyOnlyOneRow");
                    }
                    else if (((DataTable)grdSubSpec.DataSource).Rows.Count > 0) // 선택한 행의 하위항목이 존재 시
                    {
                        ShowMessage("AlreadySubSpecData");
                    }
					else
					{
                        //팝업 창 띄우기
                        CopySpecPopup copySpecPopup = new CopySpecPopup(dt);
                        copySpecPopup.ShowDialog();
					}

					break;

			}

			OnSearchAsync();
		}


		/// <summary>
		/// 저장 전 Validation
		/// 그리드 단위로 입력&수정 가능
		/// </summary>
		/// <returns></returns>
		private bool Validation()
		{
			bool result;

			DataTable mainDt = grdMainSpec.GetChangedRows();
			DataTable subDt = grdSubSpec.GetChangedRows();
			DataTable detailDt = grdSpecDetail.GetChangedRows();
		
			if ((mainDt.Rows.Count > 0 && subDt.Rows.Count > 0)
			|| (subDt.Rows.Count > 0 && detailDt.Rows.Count > 0)
			|| (detailDt.Rows.Count > 0 && mainDt.Rows.Count > 0)
			|| (mainDt.Rows.Count > 0 && subDt.Rows.Count > 0 && detailDt.Rows.Count > 0))
			{
				//등록 및 수정은 한 그룹정보 단위로 가능합니다.
				ShowMessage("SAVEBYONEGROUP");
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		#endregion

		#region 검색

		/// <summary>
		/// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
		/// </summary>
		protected async override Task OnSearchAsync()
		{
			await base.OnSearchAsync();
            if (smartTabControl1.SelectedTabPageIndex == 0)
            {
                int iPrevHandle = grdMainSpec.View.FocusedRowHandle;
                int iSubPrevHandle = grdSubSpec.View.FocusedRowHandle;

                grdMainSpec.View.ClearDatas();
                grdSubSpec.View.ClearDatas();
                grdSpecDetail.View.ClearDatas();

                var values = Conditions.GetValues();
                values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

                DataTable dtSpecList = await QueryAsync("SelectSpecList", "00001", values);

                if (dtSpecList.Rows.Count < 1)
                {
                    //조회할 데이터가 없습니다.
                    ShowMessage("NoSelectData");
                }

                grdMainSpec.DataSource = dtSpecList;

                grdMainSpec.View.FocusedRowChanged -= GrdMainSpec_FocusedRowChanged;
                grdMainSpec.View.FocusedRowHandle = iPrevHandle;
                DataRow row = grdMainSpec.View.GetFocusedDataRow();
                if (row != null)
                {
                    bool isNext = DataBindSubSegmentInfo(row);
                    if (!isNext)
                    {
                        grdSubSpec.View.ClearDatas();
                        grdSpecDetail.View.ClearDatas();
                        return;
                    }

                    grdSubSpec.View.FocusedRowChanged -= GrdSubSpec_FocusedRowChanged;
                    grdSubSpec.View.FocusedRowHandle = iSubPrevHandle;
                    DataRow subRow = grdSubSpec.View.GetFocusedDataRow();
                    if (subRow == null)
                    {
                        grdSpecDetail.View.ClearDatas();
                    }
                    else
                    {
                        DataBindInspItemInfo(subRow);
                    }
                    grdSubSpec.View.FocusedRowChanged += GrdSubSpec_FocusedRowChanged;
                }
                grdMainSpec.View.FocusedRowChanged += GrdMainSpec_FocusedRowChanged;
            }
            else
            {
                var values = Conditions.GetValues();
                values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

                DataTable dtSpecList = await QueryAsync("GetSpecListForCheck", "00001", values);
                grdSpecSearch.DataSource = dtSpecList;
                if (dtSpecList.Rows.Count < 1)
                {
                    //조회할 데이터가 없습니다.
                    ShowMessage("NoSelectData");
                }
            }
		}

		/// <summary>
		/// 조회조건 항목을 추가한다.
		/// </summary>
		protected override void InitializeCondition()
		{
			base.InitializeCondition();

			//SPECID
			InitializeCondition_SpedId();
			//공정
			InitializeCondition_Segement();
		}

		/// <summary>
		/// 조회조건의 컨트롤을 추가한다.
		/// </summary>
		protected override void InitializeConditionControls()
		{
			base.InitializeConditionControls();
		}

		/// <summary>
		/// 팝업형 조회조건 생성 - SPEC ID
		/// </summary>
		private void InitializeCondition_SpedId()
		{
			var specId = Conditions.AddSelectPopup("SPECDEFID", new SqlQuery("GetSpecList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")
                    , "SPECDEFNAME", "SPECDEFID")
				.SetPopupLayout("SELECTSPECID", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupResultCount(0)
				.SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
				.SetPopupAutoFillColumns("SPECDEFNAME")
				.SetPosition(0.1);

			specId.Conditions.AddTextBox("TXTSPECDEF");

			specId.GridColumns.AddTextBoxColumn("SPECDEFID", 150);
			specId.GridColumns.AddTextBoxColumn("SPECDEFNAME", 200);
		}

		/// <summary>
		/// 팝업형 조회조건 생성 - 공정
		/// </summary>
		private void InitializeCondition_Segement()
		{
			var segmentId = Conditions.AddSelectPopup("PROCESSSEGMENTID", new SqlQuery("GetProcessList", "00002"
                    , $"LANGUAGETYPE={UserInfo.Current.LanguageType}", "PROCESSSEGMENTTYPE=MAIN"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
                .SetPopupLayout("SELECTPROCESSSEGMENT", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupResultCount(0)
				.SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
				.SetPopupAutoFillColumns("PROCESSSEGMENTNAME")
				.SetPosition(0.2)
				.SetLabel("PROCESSSEGMENT");

			segmentId.Conditions.AddTextBox("TXTPROCESSSEGMENT");

			segmentId.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150);
			segmentId.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);
		}
		#endregion

		#region Private Function
		private void UpdateCurrentRow(SmartBandedGrid grid)
		{
			grid.View.PostEditor();
			grid.View.UpdateCurrentRow();
		}

		//세부공정 중복 확인
		private void checkSubProcessOnlyOne()
		{
			DataTable rows = grdSubSpec.DataSource as DataTable;

			foreach (DataRow each in rows.Rows)
			{
				foreach (DataRow other in rows.Rows)
				{
					if (each["SUBPROCESSSEGMENTID"].ToString() == other["SUBPROCESSSEGMENTID"].ToString() && each != other)
					{
						//동일한 세부공정이 존재합니다.
						throw MessageException.Create("SubProcessOnlyOne");
					}
				}
			}
		}
		#endregion
    }
}