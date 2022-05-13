#region using

using DevExpress.XtraEditors.Repository;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;
using Micube.Framework.SmartControls.Grid.Conditions;
using Micube.SmartMES.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Quality
{
    /// <summary>
    /// 프 로 그 램 명  : 품질관리 > 클레임관리 > X번관리대장
    /// 업  무  설  명  : X번관리대장정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-09
    /// 수  정  이  력  : 2022-04-18 scmo 제조번호 중복발생시 표시이벤트
    ///                   2022-05-11 이종건 진행상태현황 COUNT 조회기간 적용
    /// 
    /// </summary>
    public partial class XManageReg : SmartConditionBaseForm
    {
		private object[] _originalRowData = null;
        string txtName = null;

        public XManageReg()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

			InitalizeControls();
            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeGrid();

            //테이블 구조 복사
            //_compareDt = (grdXmanage.DataSource as DataTable).Clone();

            //진행상태현황 텍스트 명 복사
            txtName = lblState.Text;
        }

		/// <summary>
		/// 컨트롤 초기화
		/// </summary>
		private void InitalizeControls()
		{
			//작업지시번호
			txtOrderNumber.ReadOnly = true;
			txtOrderNumber.Tag = "ORDERNUMBER";
			//의뢰서 발행일
			txtOccurDate.ReadOnly = true;
			txtOccurDate.Tag = "REQUESTDATE";
			//진행현황
			txtProgressDesc.Tag = "PROGRESSDESC";
            //현상 
            txtStateDesc.Tag = "STATEDESC";
            //대응 
            txtResponseDesc.Tag = "RESPONSEDESC";
            //발행일자
            txtPublishDate.ReadOnly = true;
			txtPublishDate.Tag = "PUBLISHDATE";
			//완료일자
			txtCompleteDate.ReadOnly = true;
			txtCompleteDate.Tag = "COMPLETEDATE";
			//출하일자
			detShipmentDate.ReadOnly = true;
			detShipmentDate.Enabled = false;
			detShipmentDate.Tag = "SHIPMENTDATE";
		}

		/// <summary>        
		/// X번 발행정보 그리드를 초기화한다.
		/// </summary>
		private void InitializeGrid()
        {
			// 그리드 초기화
			grdXmanage.GridButtonItem = GridButtonItem.Add | GridButtonItem.Export | GridButtonItem.Delete;
			grdXmanage.View.OptionsNavigation.AutoMoveRowFocus = false;

			//관리번호
			var group1 = grdXmanage.View.AddGroupColumn("MANAGENUMBER");
			//X번호
			group1.AddTextBoxColumn("XNUMBER", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			//Claim no
			group1.AddTextBoxColumn("CLAIMNUMBER", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			//발행일자
			group1.AddTextBoxColumn("PUBLISHDATE", 90).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			//Claim 구분
			group1.AddComboBoxColumn("CLAIMTYPE", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ClaimType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			//보고서
			group1.AddComboBoxColumn("ISREPORT", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ReportType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetLabel("REPORT");
			//발행자
			group1.AddTextBoxColumn("PUBLISHER", 60).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			//희망납기일
			group1.AddDateEditColumn("HOPEDELEVERYDATE", 90).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime);

            //유형구분
            var group2 = grdXmanage.View.AddGroupColumn("DIVISIONTYPE");
			//진행상태
			group2.AddComboBoxColumn("PROGRESSSTATE", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=XManageState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
			//경과일
			group2.AddTextBoxColumn("ELAPSEDDAY", 50).SetTextAlignment(TextAlignment.Right).SetIsReadOnly();
			//유/무상
			group2.AddComboBoxColumn("CHARGETYPE", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=FreeType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			//유형
			group2.AddComboBoxColumn("XTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=XType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetEmptyItem("");
			//Troble분류
			group2.AddComboBoxColumn("TROUBLETYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TrobleType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem("", "", true);

			//제품정보
			var group3 = grdXmanage.View.AddGroupColumn("PRODUCTINFO");
			//제품군
			group3.AddComboBoxColumn("ITEMFAMILY", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCodeXmanage", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
			//제조사
			group3.AddTextBoxColumn("MANUFACTURERID", 70);
			//기종
			group3.AddTextBoxColumn("MODELID", 100).SetIsHidden();
			var modelIdPopup = group3.AddSelectPopupColumn("MODELNAME", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ModelCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetPopupLayout("SELECTMODELID", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupResultCount(1)
				.SetPopupLayoutForm(600, 600, System.Windows.Forms.FormBorderStyle.FixedToolWindow)
				.SetTextAlignment(TextAlignment.Left)
				.SetPopupResultMapping("MODELNAME", "CODENAME")
				.SetPopupApplySelection((IEnumerable<DataRow> selectedRow, DataRow dataGirdRow) =>
				{
					if (selectedRow.Count() > 0)
					{
						grdXmanage.View.SetFocusedRowCellValue("MODELID", selectedRow.FirstOrDefault()["CODEID"]);
					}
					else
					{
						grdXmanage.View.SetFocusedRowCellValue("MODELID", string.Empty);
					}
				})
				.SetPopupAutoFillColumns("CODENAME");
			modelIdPopup.Conditions.AddTextBox("TXTMODELID");
			modelIdPopup.GridColumns.AddTextBoxColumn("CODEID", 100).SetLabel("MODELID");
			modelIdPopup.GridColumns.AddTextBoxColumn("CODENAME", 150).SetLabel("MODELNAME");

			//수량
			group3.AddSpinEditColumn("QTY", 60).SetTextAlignment(TextAlignment.Right);
            //제조번호
            // 2022-05-10 주시은 textbox -> selectPopup으로 변경
            group3.AddTextBoxColumn("MANUFACTURENUMBER", 70).SetTextAlignment(TextAlignment.Center);
            /*
            var manufacturePopup = group3.AddSelectPopupColumn("MANUFACTURENUMBER", 100, new SqlQuery("GetLotIdForXManage", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                                         .SetPopupLayout("SELECTMANUFACTURE", PopupButtonStyles.Ok_Cancel, true, false)
                                         .SetPopupResultCount(1)
                                         .SetPopupLayoutForm(800, 800, FormBorderStyle.FixedToolWindow)
                                         .SetTextAlignment(TextAlignment.Left)
                                         .SetPopupResultMapping("MANUFACTURENUMBER", "LOTID");
            manufacturePopup.SetPopupApplySelection((selectedRow, gridRow) => 
            {
                if (selectedRow == null) return;
                else
                {
                    foreach (DataRow row in selectedRow)
                    {
                        DataTable dt = grdXmanage.DataSource as DataTable;
                        int s = dt.AsEnumerable().Where(r => r.Field<string>("MANUFACTURENUMBER") == row["LOTID"].ToString()).Count();

                        if (s > 1)
                        {
                            // 이미 선택된 Lot은 선택할 수 없습니다.
                            throw MessageException.Create("CantSelectAlreadySelectedLot");
                        }
                        else
                        {
                            grdXmanage.View.SetFocusedRowCellValue("MANUFACTURENUMBER", selectedRow.FirstOrDefault()["LOTID"]);
                        }
                    }
                }
            });
            manufacturePopup.Conditions.AddTextBox("TXTPRODUCTDEFNAME");
            manufacturePopup.Conditions.AddTextBox("TXTLOTID").SetLabel("LOTID");

            manufacturePopup.GridColumns.AddTextBoxColumn("LOTID", 100);
            manufacturePopup.GridColumns.AddTextBoxColumn("PRODUCTDEFTYPE", 100);
            manufacturePopup.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 130);
            manufacturePopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 100);
            manufacturePopup.GridColumns.AddTextBoxColumn("QTY", 50);
            */
            //ETM(H)
            group3.AddSpinEditColumn("ETMHOUR", 70).SetTextAlignment(TextAlignment.Right);
            // 제품입고일자
            group3.AddDateEditColumn("INDATE", 120).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime);
			// 입고확인자
			//group3.AddComboBoxColumn("CONFIRMUSER", 100, new SqlQuery("GetUserSelectPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_USERCLASSID=ReceivingChecker"), "USERNAME", "USERID");
			group3.AddTextBoxColumn("CONFIRMUSER", 90).SetIsHidden();
			var userPopup = group3.AddSelectPopupColumn("CONFIRMUSERNAME", 100, new SqlQuery("GetUserSelectPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetPopupLayout("CONFIRMUSER", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupResultCount(1)
				.SetPopupResultMapping("CONFIRMUSERNAME", "USERNAME")
				.SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
				.SetTextAlignment(TextAlignment.Center)
				.SetLabel("CONFIRMUSER")
				.SetPopupApplySelection((IEnumerable<DataRow> selectedRow, DataRow dataGirdRow) =>
				{
					if (selectedRow.Count() > 0)
					{
						grdXmanage.View.SetFocusedRowCellValue("CONFIRMUSER", selectedRow.FirstOrDefault()["USERID"]);
					}
					else
					{
						grdXmanage.View.SetFocusedRowCellValue("CONFIRMUSER", string.Empty);
					}
				});
			userPopup.Conditions.AddTextBox("P_USERNAME").SetLabel("USERNAME");
			userPopup.Conditions.AddComboBox("P_DEPARTMENTID", new SqlQuery("GetDepartmentList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetTextAlignment(TextAlignment.Center)
				.SetLabel("DEPARTMENT");
			userPopup.GridColumns.AddTextBoxColumn("USERID", 100).SetIsHidden();
			userPopup.GridColumns.AddTextBoxColumn("USERNAME", 100).SetTextAlignment(TextAlignment.Center);
			userPopup.GridColumns.AddComboBoxColumn("DEPARTMENT", 100, new SqlQuery("GetDepartmentList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetTextAlignment(TextAlignment.Center);

			//고객정보
			var group4 = grdXmanage.View.AddGroupColumn("CUSTOMERINFO");
			//지역
			group4.AddComboBoxColumn("CUSTOMERREGIONID", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=NationalType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			//거래선
			group4.AddTextBoxColumn("CUSTOMERBASE", 100);
			//장치사
			group4.AddTextBoxColumn("DEVICECUSTOMERID", 80);
			//고객사
			group4.AddTextBoxColumn("CUSTOMERID", 80).SetIsHidden();
			var customerPopup = group4.AddSelectPopupColumn("CUSTOMERNAME", 100, new SqlQuery("GetCustomer", "00002", "XMANAGECUSTOMER=Y", $"DBLINKNAME={CommonFunction.DbLinkName}", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
				.SetPopupLayout("CUSTOMER", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupResultCount(1)
				.SetPopupLayoutForm(800, 800, System.Windows.Forms.FormBorderStyle.FixedToolWindow)
				.SetTextAlignment(TextAlignment.Left)
				.SetPopupResultMapping("CUSTOMERBASE", "CUSTOMERNAME")
				.SetPopupApplySelection((IEnumerable<DataRow> selectedRow, DataRow dataGirdRow) =>
				{
					if (selectedRow.Count() > 0)
					{
						grdXmanage.View.SetFocusedRowCellValue("CUSTOMERID", selectedRow.FirstOrDefault()["CUSTOMERID"]);
					}
					else
					{
						grdXmanage.View.SetFocusedRowCellValue("CUSTOMERID", string.Empty);
					}
				})
				.SetPopupAutoFillColumns("ADDRESS");

			// 검색조건
			customerPopup.Conditions.AddTextBox("CUSTOMERIDNAME");

			// 팝업의 그리드에 컬럼 추가
			customerPopup.GridColumns.AddTextBoxColumn("CUSTOMERID", 70).SetTextAlignment(TextAlignment.Left);
			customerPopup.GridColumns.AddTextBoxColumn("CUSTOMERNAME", 150);
			customerPopup.GridColumns.AddTextBoxColumn("PHONE", 100);
			//customerPopup.GridColumns.AddTextBoxColumn("FAXNO", 100);
			customerPopup.GridColumns.AddTextBoxColumn("ADDRESS", 250);

			//LINE
			group4.AddTextBoxColumn("LINEID", 50).SetTextAlignment(TextAlignment.Center);
			//소재지 
			group4.AddTextBoxColumn("CUSTOMERLOCATION", 80);
			//담당자 
			group4.AddTextBoxColumn("CUSTOMERMANAGER", 60).SetTextAlignment(TextAlignment.Center);
			//연락처 
			group4.AddTextBoxColumn("TELLNUMBER", 100).SetTextAlignment(TextAlignment.Center);

			//무상비용
			var group5 = grdXmanage.View.AddGroupColumn("UNPAID");
			//고정비
			group5.AddSpinEditColumn("FIXEDCOST", 70).SetTextAlignment(TextAlignment.Right);
			//변동비
			group5.AddSpinEditColumn("VARIABLECOST", 70).SetTextAlignment(TextAlignment.Right);
			//처리월
			var processMonth = group5.AddSpinEditColumn("PROCESSMONTH", 60).SetTextAlignment(TextAlignment.Center);
			processMonth.MinValue = 1;
			processMonth.MaxValue = 12;
			//group5.AddDateEditColumn("PROCESSMONTH", 60).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("MM", MaskTypes.DateTime);

			//유상비용
			var group6 = grdXmanage.View.AddGroupColumn("PAID");
			//수주액
			group6.AddSpinEditColumn("ORDERPRICE", 70).SetTextAlignment(TextAlignment.Right);
			//수주월
			var orderMonth = group6.AddSpinEditColumn("ORDERMONTH", 60).SetTextAlignment(TextAlignment.Center);
			orderMonth.MinValue = 1;
			orderMonth.MaxValue = 12;
			//group6.AddDateEditColumn("ORDERMONTH", 60).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("MM", MaskTypes.DateTime);
			//매출액
			group6.AddSpinEditColumn("SALESPRICE", 70).SetTextAlignment(TextAlignment.Right);
			//매출월
			var salesMonth = group6.AddSpinEditColumn("SALESMONTH", 60).SetTextAlignment(TextAlignment.Center);
			salesMonth.MinValue = 1;
			salesMonth.MaxValue = 12;
			//group6.AddDateEditColumn("SALESMONTH", 60).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("MM", MaskTypes.DateTime);

			//Claim 정보
			var group7 = grdXmanage.View.AddGroupColumn("CLAIMINFO");
			//발생일
			group7.AddDateEditColumn("OCCURDATE", 90).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime);
            //Claim 내용
            group7.AddTextBoxColumn("CLAIMCONTENT", 150);
            //현상 
            group7.AddTextBoxColumn("STATEDESC", 150).SetIsHidden();
            //대응 
            group7.AddTextBoxColumn("RESPONSEDESC", 150).SetIsHidden();
            //대응처
            group7.AddTextBoxColumn("RESPONSEFROM", 100);
			//완료일
			group7.AddDateEditColumn("COMPLETEDATE", 90).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime).SetIsReadOnly();

			//거래심사
			var group8 = grdXmanage.View.AddGroupColumn("BUSINESSPASS");
			//심사여부
			group8.AddComboBoxColumn("ISEXAM", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
			//작업지시번호
			grdXmanage.View.AddTextBoxColumn("ORDERNUMBER").SetIsHidden();
			//의뢰서발행일
			grdXmanage.View.AddTextBoxColumn("REQUESTDATE").SetIsHidden();
			//진행현황
			grdXmanage.View.AddTextBoxColumn("PROGRESSDESC").SetIsHidden();
			//출하일자
			grdXmanage.View.AddDateEditColumn("SHIPMENTDATE").SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime).SetIsHidden();

			grdXmanage.View.PopulateColumns();

			/*
			RepositoryItemDateEdit edit = new RepositoryItemDateEdit();

			edit.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
			edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			edit.Mask.EditMask = "MM";

			grdXmanage.View.Columns["SALESMONTH"].ColumnEdit = edit;
			grdXmanage.View.Columns["ORDERMONTH"].ColumnEdit = edit;
			grdXmanage.View.Columns["PROCESSMONTH"].ColumnEdit = edit; 
			*/
		}
		#endregion

		#region 조회 조건

		/// <summary>
		/// 조회조건의 컨트롤을 추가한다.
		/// </summary>
		protected override void InitializeConditionControls()
		{
			base.InitializeConditionControls();

			DateTime today = DateTime.Now.Date;

			SmartPeriodEdit fromDate = Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD");
			//2021-05-06 UCK 서지원님 요청. ('발행일자를 당월기준이아닌 2020-07-01을 고정으로 사용')
			fromDate.datePeriodFr.EditValue = "2020-07-01";

			SmartPeriodEdit toDate = Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD");
			toDate.datePeriodTo.EditValue = today;

		}

		#endregion

		#region EVENT
		private void InitializeEvent()
		{
			this.Paint += XManageReg_Paint;
			fileControl.StateEvent += FileControl_StateEvent;

			txtProgressDesc.EditValueChanging += EditValueChanging;
            txtStateDesc.EditValueChanging += EditValueChanging;
            txtResponseDesc.EditValueChanging += EditValueChanging;
            detShipmentDate.EditValueChanging += EditValueChanging;

			grdXmanage.View.FocusedRowChanged += View_FocusedRowChanged;
			grdXmanage.View.ShowingEditor += View_ShowingEditor;
			grdXmanage.View.AddingNewRow += View_AddingNewRow;
			grdXmanage.View.RowStyle += View_RowStyle;
			grdXmanage.View.RowCellStyle += View_RowCellStyle;

            grdXmanage.View.CellValueChanged += View_CellValueChanged;
		}

        /// <summary>
        /// '22.04.18 scmo 제조번호 중복발생시 표시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("MANUFACTURENUMBER"))
            {
                DataRow row = (sender as SmartBandedGridView).GetFocusedDataRow();

                string tempData = row["MANUFACTURENUMBER"].ToString();

                if (tempData.Length > 0)
                {
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
                    param.Add("P_MANUFACTURENUMBER", tempData);
                    param.Add("DBLINKNAME", CommonFunction.DbLinkName);

                    DataTable dt = SqlExecuter.Query("SelectLotTraceLotXManageList", "00002", param);

                    if(dt.Rows.Count> 0)
                    {
                        //제조번호가 중복되었습니다.
                        ShowMessage("OverlapManufactureNo");
                        grdXmanage.View.SetFocusedRowCellValue("MANUFACTURENUMBER", string.Empty);
                    }
                        
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{
			if(e.Column.FieldName.Equals("XNUMBER")
			|| e.Column.FieldName.Equals("CLAIMNUMBER")
			|| e.Column.FieldName.Equals("PUBLISHDATE")
			|| e.Column.FieldName.Equals("CLAIMTYPE")
			|| e.Column.FieldName.Equals("PUBLISHER")
			|| e.Column.FieldName.Equals("PROGRESSSTATE")
			|| e.Column.FieldName.Equals("ELAPSEDDAY")
			|| e.Column.FieldName.Equals("COMPLETEDATE"))
			{
				e.Column.AppearanceCell.BackColor = Color.FromArgb(242, 242, 242);
			}
		}

		/// <summary>
		/// 툴바 버튼 리사이즈
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XManageReg_Paint(object sender, PaintEventArgs e)
		{
			var buttons = pnlToolbar.Controls.Find<SmartButton>(true);
			foreach (SmartButton btn in buttons)
			{
				if(string.IsNullOrWhiteSpace(btn.Text)) continue;

				int w = (Size.Round(e.Graphics.MeasureString(btn.Text, btn.Font))).Width;

				btn.Size = new Size(w < 80 ? 80 : w, btn.Height);
			}
		}

		/// <summary>
		/// 파일상태 체크 이벤트
		/// </summary>
		/// <param name="stateFlag">ture 면 상단 메인 그리드 상태 modified로 변경</param>
		private void FileControl_StateEvent(bool stateFlag)
		{
			if(stateFlag)
			{
				if (grdXmanage.View.FocusedRowHandle < 0) return;

				DataRow row = grdXmanage.View.GetFocusedDataRow();

				if (row.RowState == DataRowState.Unchanged)
				{
					row.SetModified();
				}
			}
		}

		/// <summary>
		/// 행 추가 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void View_AddingNewRow(SmartBandedGridView sender, AddNewRowArgs args)
		{
			if (grdXmanage.GetChangedRows().Rows.Count > 1)
			{
				// 저장, 수정중인 행이 존재합니다.
				this.ShowMessage("RowBeingSaveOrModified");
				args.IsCancel = true;
				return;
			}

			ClearControls();
			fileControl.ClearGridDatas();

			args.NewRow["PUBLISHER"] = UserInfo.Current.Name;
		}

		/// <summary>
		/// 저장, 수정중인행이 존재했을때 다른행 ReadOnly
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (grdXmanage.View.GetFocusedDataRow().RowState != DataRowState.Modified
			&& grdXmanage.View.GetFocusedDataRow().RowState != DataRowState.Added)
			{
				if (grdXmanage.GetChangedRows().Rows.Count > 0)
				{
					// 저장, 수정중인 행이 존재합니다.
					this.ShowMessage("RowBeingSaveOrModified");
					e.Cancel = true;
				}
			}
		}

		/// <summary>
		/// 포커스 받은 Row 색깔변경
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			if (grdXmanage.View.FocusedRowHandle == e.RowHandle)
			{	
				e.Appearance.BackColor = Color.Yellow;
				e.HighPriority = true;
			}
		}

		/// <summary>
		/// Row 포커스 change 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if(e.FocusedRowHandle < 0 || e.PrevFocusedRowHandle < 0) return;

			DataRow row = grdXmanage.View.GetFocusedDataRow();
			DataRow prevRow = grdXmanage.View.GetDataRow(e.PrevFocusedRowHandle);
			if(row == null || prevRow == null) return;

			DataTable fileChanged = fileControl.GetChangedRows();
			DataTable changed = grdXmanage.GetChangedRows();
			if(fileChanged.Rows.Count > 0 || changed.Rows.Count > 0)
			{
				//행을 변경하시겠습니까? 현지 입력중인 정보는 사라집니다.
				if(ShowMessageBox("ChangeRowCurrentInputDataDelete", Language.Get("MESSAGEINFO"), MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					if(prevRow.RowState == DataRowState.Added)
					{
						grdXmanage.View.DeleteRow(e.PrevFocusedRowHandle);
					}
					else
					{
						if (_originalRowData != null && _originalRowData.Length > 0)
						{
							prevRow.ItemArray = _originalRowData;
							(grdXmanage.DataSource as DataTable).AcceptChanges();
						}
					}
				}
				else
				{
					grdXmanage.View.FocusedRowChanged -= View_FocusedRowChanged;
					//grdXmanage.View.SelectRow(e.PrevFocusedRowHandle);
					grdXmanage.View.FocusedRowHandle = e.PrevFocusedRowHandle;
					grdXmanage.View.FocusedRowChanged += View_FocusedRowChanged;
					return;
				}
			}

			if (row.RowState != DataRowState.Added)
			{
				//하위 데이터 바인드
				FocusDataBind(row);

				//original 데이터 update
				_originalRowData = row.ItemArray;
			}

			//접수상태일 때만 발행취소 가능
			ButtonsValidation(row);
		}

		/// <summary>
		/// 진행상태 별 버튼 활성 / 비활성
		/// </summary>
		/// <param name="r"></param>
		private void ButtonsValidation(DataRow r)
		{
			var buttons = pnlToolbar.Controls.Find<SmartButton>(true);
			foreach (SmartButton btn in buttons)
			{
				if (Format.GetString(r["PROGRESSSTATE"]) == "Request")
				{
					btn.Enabled = true;
				}
				else
				{
					switch (btn.Name)
					{
						case "PublishCancel":
							btn.Enabled = false;
							break;
						default:
							btn.Enabled = true;
							break;
					}
				}
			}
		}

		/// <summary>
		/// 하위 데이터 바인드
		/// </summary>
		/// <param name="row"></param>
		private void FocusDataBind(DataRow row)
		{
			//이전 포커스와 현재 포커스 비교되면서 수정상태로 바뀌어 이벤트 빼고 해야됨
			txtProgressDesc.EditValueChanging -= EditValueChanging;

			//조치현황 bind
			CommonFunction.BindDataToControlsTag(row, tplXmanage);

			//파일 bind
			FileDataBind(row);

			//파일 컨트롤 VALUE값 초기화
			fileControl.docId = Format.GetString(row["XNUMBER"]);

			txtProgressDesc.EditValueChanging += EditValueChanging;
		}

		/// <summary>
		/// Control Value 변경 시 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
		{
			DataRow focusRow = grdXmanage.View.GetFocusedDataRow();
			if (focusRow == null) return;

			if (grdXmanage.GetChangedRows().Rows.Count > 0)
			{
				if (focusRow.RowState != DataRowState.Added && focusRow.RowState != DataRowState.Modified)
				{
					// 저장, 수정중인행이 존재합니다.
					this.ShowMessage("RowBeingSaveOrModified");
					e.Cancel = true;
					return;
				}
			}

			Control control = null;

			string controlName = sender.GetType().Name;
			switch(controlName)
			{
				case "SmartTextBox":
					control = sender as SmartTextBox;
					break;
				case "SmartDateEdit":
					control = sender as SmartDateEdit;
					break;
				case "SmartSpinEdit":
					control = sender as SmartSpinEdit;
					break;
                case "SmartMemoEdit":
                    control = sender as SmartMemoEdit;
                    break;
            }

			if(control == null) return;

			string tag = control.Tag.ToString();
			if (e.OldValue != e.NewValue)
			{
                if (!string.IsNullOrWhiteSpace(Format.GetString(e.NewValue)))
				    focusRow[tag] = e.NewValue;
			}			
		}
		#endregion

		#region 툴바

		/// <summary>
		/// 툴바 Action
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void OnToolbarClick(object sender, EventArgs e)
		{
			MessageWorker worker = new MessageWorker("SaveXManage");

			DataRow selectedRow = grdXmanage.View.GetFocusedDataRow();
			if(selectedRow == null) return;

			string xNumber = selectedRow["XNUMBER"].ToString();
			DataTable dt = new DataTable();
			if (!string.IsNullOrWhiteSpace(xNumber))
			{
				DataRow[] rows = (grdXmanage.DataSource as DataTable).Select("XNUMBER='" + xNumber + "'");
				dt = rows.CopyToDataTable();
			}

			SmartButton btn = sender as SmartButton;
			string btnName = btn.Name.ToString();
				
			switch (btnName)
			{
				case "Save"://저장
					grdXmanage.View.PostEditor();
					grdXmanage.View.UpdateCurrentRow();

					fileControl.UpdateCurrentRow();

					DataTable saveDt = grdXmanage.GetChangedRows();
					DataTable fileDt = fileControl.GetChangedRows();

					if (saveDt.Rows.Count < 1 && fileDt.Rows.Count < 1)
					{
						//저장할 데이터가 없습니다. 
						ShowMessage("NoSaveData");
						return;
					}
					if (ShowMessage(MessageBoxButtons.YesNo, "InfoSave") == DialogResult.Yes)
					{

						worker.SetBody(new MessageBody()
						{
							{ "toolbarAction", "Save" },
							{ "xManageList", saveDt },
							{ "xFileList", fileDt },
							{ "userId", UserInfo.Current.Id }
						});
						worker.Execute();
						ShowMessage("SuccessSave");
						OnSearchAsync();
					}
                    break;
				case "RepairRequest"://수리의뢰발행
					if (selectedRow.RowState == DataRowState.Added
					|| selectedRow.RowState == DataRowState.Modified)
					{
						//저장 후 진행해 주세요.
						ShowMessage("DoActionAfterSave");
						return;
					}

					if (ShowMessage(MessageBoxButtons.YesNo, "CreateRepairReqYesNo") == DialogResult.Yes)
					{
						worker.SetBody(new MessageBody()
						{
							{ "toolbarAction", "RepairRequest" },
							{ "xManageList", dt },
							{ "userId", UserInfo.Current.Id }
						});
						worker.Execute();
						ShowMessage("SuccessSave");
						OnSearchAsync();
					}
					break;
				case "ClaimRequest"://Claim 의뢰
					if(selectedRow.RowState == DataRowState.Added
					|| selectedRow.RowState == DataRowState.Modified)
					{
						//저장 후 진행해 주세요.
						ShowMessage("DoActionAfterSave");
						return;
					}

					if(!string.IsNullOrWhiteSpace(Format.GetString(selectedRow["CLAIMNUMBER"])))
					{
						//이미 Claim 의뢰된 건 입니다.
						ShowMessage("AlreadyXManageClaimRequest");
						return;
					}

					if (ShowMessage(MessageBoxButtons.YesNo, "CreateClaimNoYesNo") == DialogResult.Yes)
					{
						worker.SetBody(new MessageBody()
						{
							{ "toolbarAction", "ClaimRequest" },
							{ "xManageList", dt },
						});
						worker.Execute();
						ShowMessage("SuccessSave");
						OnSearchAsync();
					}
                    break;
				case "ManeuverComplete"://조치완료
					if (selectedRow.RowState == DataRowState.Added 
					|| selectedRow.RowState == DataRowState.Modified)
					{
						//저장 후 진행해 주세요.
						ShowMessage("DoActionAfterSave");
						return;
					}

					if (selectedRow["PROGRESSSTATE"].Equals("Complete"))
					{
						//이미 조치완료된 건 입니다.
						ShowMessage("AlreadyXManageComplete");
						return;
					}

					if (ShowMessage(MessageBoxButtons.YesNo, "FixOkYesNo") == DialogResult.Yes)
					{
						worker.SetBody(new MessageBody()
						{
							{ "toolbarAction", "IssueComplete" },
							{ "xManageList", dt },
						});
						worker.Execute();
						ShowMessage("SuccessSave");
						OnSearchAsync();
					}
                    break;
				case "PublishCancel"://발행취소
					if (selectedRow.RowState == DataRowState.Added
					|| selectedRow.RowState == DataRowState.Modified)
					{
						//저장 후 진행해 주세요.
						ShowMessage("DoActionAfterSave");
						return;
					}

					if (selectedRow["PROGRESSSTATE"].Equals("Cancel"))
					{
						//이미 발행취소된 건 입니다.
						ShowMessage("AlreadyXManageCancel");
						return;
					}

					if(ShowMessage(MessageBoxButtons.YesNo, "PublishCancelYesNo") == DialogResult.Yes)
					{
						worker.SetBody(new MessageBody()
						{
							{ "toolbarAction", "PublishCancel" },
							{ "xManageList", dt },
						});
						worker.Execute();
						ShowMessage("SuccessSave");
						OnSearchAsync();
					}

                    break;

                // 2020-07-01 유태근 - 엑셀출력버튼 및 기능 추가

                case "ClaimNotice": // 클레임통지서
                    CallXManagerExcel(grdXmanage.View.GetFocusedDataRow(), "ClaimNotice");
                    break;
				//'21.05.12 scmo 고객요청으로 수리요청서(국내) 삭제, 수리요청서(제조,CS) 추가
				//case "RepairRequestFormLocal": // 수리요청서(국내)
				//    CallXManagerExcel(grdXmanage.View.GetFocusedDataRow(), "RepairRequestFormLocal");
				//    break;
				case "RepairRequestFormProduction": //수리요청서(제조)
					CallXManagerExcel(grdXmanage.View.GetFocusedDataRow(), "RepairRequestFormProduction");
					break;
				case "RepairRequestFormCs": //수리요청서(CS)
					CallXManagerExcel(grdXmanage.View.GetFocusedDataRow(), "RepairRequestFormCs");
					break;
				case "RepairRequestFormForeign": // 수리요청서(해외)
                    CallXManagerExcel(grdXmanage.View.GetFocusedDataRow(), "RepairRequestFormForeign");
                    break;
            }
		}
		#endregion

		#region 검색
		protected async override Task OnSearchAsync()
		{
			await base.OnSearchAsync();

			int prevFocusHandler = grdXmanage.View.FocusedRowHandle;

			//초기화 작업
			ClearControls();
			grdXmanage.View.ClearDatas();
			fileControl.ClearGridDatas();
			txtRequest.Text = string.Empty;
			txtWorking.Text = string.Empty;
			detShipmentDate.ReadOnly = true;
			detShipmentDate.Enabled = false;

			var values = Conditions.GetValues();
			values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
			values.Add("DBLINKNAME", CommonFunction.DbLinkName);

			DataTable dtXManage = await QueryAsync("SelectXManageList", "00001", values);

			if (dtXManage.Rows.Count == 0)
			{
				// 조회할 데이터가 없습니다.
				ShowMessage("NoSelectData");
			}

			grdXmanage.DataSource = dtXManage;

			if((grdXmanage.DataSource as DataTable).Rows.Count > 0)
			{
				grdXmanage.View.FocusedRowHandle = prevFocusHandler;

				DataRow currentRow = grdXmanage.View.GetFocusedDataRow();
				FocusDataBind(currentRow);

				ButtonsValidation(currentRow);

				_originalRowData = currentRow.ItemArray;

				detShipmentDate.ReadOnly = false;
				detShipmentDate.Enabled = true;
			}

            //2022 - 05 - 11 이종건 진행상태현황 COUNT 조회기간 적용
            lblState.Font = new Font(lblState.Font.Name, 10);
            lblState.Text = txtName + "\r\n" + Conditions.GetValues()["P_DATEPERIOD_PERIODFR"].ToString().Substring(0, 10) + " ~ " + Conditions.GetValues()["P_DATEPERIOD_PERIODTO"].ToString().Substring(0,10);


            //진행상태 현황
            DataTable stateDt = SqlExecuter.Query("GetXmanageProgressStateCount", "00001", values);
			if(stateDt.Rows.Count < 1) return;

			txtRequest.Text = Format.GetFullTrimString(stateDt.Rows[0]["REQUESTCNT"]);
			txtWorking.Text = Format.GetFullTrimString(stateDt.Rows[0]["WORKINGCNT"]);
		}
		#endregion

		#region Function

		/// <summary>
		/// 컨트롤 Clear
		/// </summary>
		private void ClearControls()
		{
			txtProgressDesc.EditValueChanging -= EditValueChanging;
			txtOrderNumber.EditValue = string.Empty;
			txtProgressDesc.EditValue = string.Empty;
			txtCompleteDate.EditValue = string.Empty;
			txtPublishDate.EditValue = string.Empty;
			txtOccurDate.EditValue = null;
			detShipmentDate.EditValue = null;
			txtProgressDesc.EditValueChanging += EditValueChanging;
		}

		/// <summary>
		/// 파일 데이터 바인드
		/// </summary>
		/// <param name="r"></param>
		private void FileDataBind(DataRow r)
		{
			if(r == null) return;

			Dictionary<string, object> param = new Dictionary<string, object>();
			param.Add("DOCID", r["XNUMBER"]);

			fileControl.dataSoruce = SqlExecuter.Query("GetQmFileList", "00001", param);
		}

        /// <summary>
        /// 수리요청서 팝업호출
        /// </summary>
        /// <param name="row"></param>
        /// <param name="type"></param>
        private void CallXManagerExcel(DataRow row, string type)
        {
            if (row == null) return;

            DataTable dt = new DataTable();

            dt = (grdXmanage.DataSource as DataTable).Clone();
            dt.ImportRow(row);

            switch (type)
            {
                case "ClaimNotice":
					dt.Columns.Add("OCCURDATE2", typeof(string));	//DateTime을 ShortDateTime으로도 변환해봤으나 DataSource에 적용된 자료형을 우선순위로 갖는듯함...

					foreach(DataRow trow in dt.Rows)
					{
						trow["OCCURDATE2"] = trow["OCCURDATE"].ToString().Substring(0, 10);
					}
					CommonFunction.ExuteExcelBindingData(Constants.Repair_Requset_Claim, dt);
                    break;
				//'21.05.12 scmo 고객요청으로 수리요청서(국내) 삭제, 수리요청서(제조,CS) 추가
				//case "RepairRequestFormLocal":
				//    CommonFunction.ExuteExcelBindingData(Constants.Repair_Requset_Local, dt);
				//    break;
				case "RepairRequestFormProduction": //수리요청서(제조)
					CommonFunction.ExuteExcelBindingData(Constants.Repair_Requset_Production, dt);
					break;
				case "RepairRequestFormCs": //수리요청서(CS)
					CommonFunction.ExuteExcelBindingData(Constants.Repair_Requset_Cs, dt);
					break;
				case "RepairRequestFormForeign":
                    CommonFunction.ExuteExcelBindingData(Constants.Repair_Requset_Foreign, dt);
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void grdXmanage_Load(object sender, EventArgs e)
        {

        }
    }
}
