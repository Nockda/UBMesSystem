#region using

using DevExpress.XtraEditors.Repository;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;
using Micube.Framework.SmartControls.Validations;
using Micube.SmartMES.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Quality
{
    /// <summary>
    /// 프 로 그 램 명  : 품질관리 > 불량관리 > 불량통지서 등록
    /// 업  무  설  명  : 불량통지서를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-11
    /// 수  정  이  력  : 2020-04-21 강유라
    /// 
    /// 
    /// </summary>
    public partial class DefectReg : SmartConditionBaseForm
    {
        #region Local Variables

        // TODO : 화면에서 사용할 내부 변수 추가

        #endregion

        #region 생성자
        public DefectReg()
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

            // 컨트롤 초기화 로직 구성
            InitializeGrid();

            InitializeEvent();
            if (pnlToolbar.Controls["layoutToolbar"].Controls.ContainsKey("DefectNotice"))
            {
                pnlToolbar.Controls["layoutToolbar"].Controls["DefectNotice"].Width = 100;
            }

        }

        #region 그리드 초기화

        /// <summary>        
        /// 불량 통지서 등록 그리드 초기화
        /// </summary>
        private void InitializeGrid()
        {
            // 그리드 초기화
            grdDefectRegist.GridButtonItem = GridButtonItem.Add | GridButtonItem.Export | GridButtonItem.Import | GridButtonItem.Copy;
            grdDefectRegist.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;

            grdDefectRegist.View.SetSortOrder("DOCID");
            grdDefectRegist.View.SetAutoFillColumn("DEFECTDESC");

            grdDefectRegist.View.AddTextBoxColumn("DOCID", 80).SetIsReadOnly();//발행번호
            grdDefectRegist.View.AddTextBoxColumn("PUBLISHDATE", 80).SetIsReadOnly();//발행일자
            grdDefectRegist.View.AddTextBoxColumn("PROGRESSSTATENAME", 80).SetLabel("PROGRESSSTATE").SetIsReadOnly();//진행상태
            InitializeClaimNoPopup();
            grdDefectRegist.View.AddComboBoxColumn("DEPARTMENTID", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCodeQc", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetValidationKeyColumn();//발견부서 

            // grdDefectRegist.View.AddComboBoxColumn("DETECTID", 80,new SqlQuery("GetUser", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "USERNAME", "USERID").SetLabel("DEFECTDISCOVERER")
            //               .SetValidationKeyColumn();
            grdDefectRegist.View.AddTextBoxColumn("FINDID").SetIsHidden();
            InitializeFindIdListPopup();
            //발견자
            grdDefectRegist.View.AddTextBoxColumn("DETECTID").SetIsHidden().SetValidationKeyColumn();
            grdDefectRegist.View.AddTextBoxColumn("DETECTNAME").SetLabel("WRITER").SetIsReadOnly().SetValidationKeyColumn();
            //InitializeDetectIdListPopup();

            InitializeProductListPopup();
            // 2020-07-16 유태근 / 품목코드 변경
            grdDefectRegist.View.AddTextBoxColumn("DEFECTITEMNUMBER").SetIsHidden(); // 불량품 PARTNUMBER
            grdDefectRegist.View.AddTextBoxColumn("DEFECTITEMNAME", 150).SetIsReadOnly();//불량품명
            InitializeCompanyListPopup();
            grdDefectRegist.View.AddTextBoxColumn("COMPANYID").SetIsHidden().SetValidationKeyColumn();
            //grdDefectRegist.View.AddComboBoxColumn("COMPANYID", 150, new SqlQuery("GetCustomer", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"COMP=Y"), "CUSTOMERNAME", "CUSTOMERID")
            //    .SetValidationKeyColumn()
            //    .SetVisibleColumns("CUSTOMERID", "CUSTOMERNAME", "CUSTKINDNAME");//업체코드
            grdDefectRegist.View.AddTextBoxColumn("CUSTKINDNAME", 100).SetIsReadOnly().SetLabel("NATIONALITY");//국적
            grdDefectRegist.View.AddTextBoxColumn("DRAWINGNUMBER", 100);//도면번호
            grdDefectRegist.View.AddDateEditColumn("PAYMENTDATE", 80).SetDisplayFormat("yyyy-MM-dd",MaskTypes.DateTime);//납입일자
            grdDefectRegist.View.AddSpinEditColumn("PAYMENTQTY", 80).SetDisplayFormat("{0:#,##0}").SetValidationCustom(QtyValidation);//납입수량
            grdDefectRegist.View.AddSpinEditColumn("UNITPRICE", 80).SetDisplayFormat("#,##0.#####", MaskTypes.Numeric, true);//단가
            grdDefectRegist.View.AddDateEditColumn("DEFECTDATE", 80).SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime);//불량일자
            grdDefectRegist.View.AddSpinEditColumn("DEFECTQTY", 80).SetDisplayFormat("{0:#,##0}");//.SetValidationCustom(QtyValidation);//불량수량
            grdDefectRegist.View.AddSpinEditColumn("DEFECTPRICE", 80).SetDisplayFormat("#,##0.#####", MaskTypes.Numeric, true).SetIsReadOnly();//불량금액
            grdDefectRegist.View.AddTextBoxColumn("DEFECTRATE", 50).SetIsReadOnly();//불량율
            grdDefectRegist.View.AddTextBoxColumn("RECURRCNT", 80).SetIsReadOnly();//재발횟수
            grdDefectRegist.View.AddTextBoxColumn("DEFECTDESC", 120);//불량내용

            grdDefectRegist.View.PopulateColumns();
        }

        #region Claim No 팝업 초기화
        private void InitializeClaimNoPopup()
        {
            var claimNoPopup = grdDefectRegist.View.AddSelectPopupColumn("CLAIMNUMBER", 100, new SqlQuery("GetClaimNo", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
              .SetPopupLayout("CLAIMNUMBER", PopupButtonStyles.Ok_Cancel, true, true)
              .SetPopupResultCount(1)
              .SetPopupLayoutForm(600, 400, FormBorderStyle.FixedToolWindow)
              .SetPopupAutoFillColumns("CLAIMNUMBER")
              .SetLabel("CLAIMNUMBER")
              //.SetValidationKeyColumn()
              .SetPopupApplySelection((selectedRows, dataGridRow) =>
              {
                  // selectedRows : 팝업에서 선택한 DataRow(컬렉션)
                  // dataGridRow : 현재 Focus가 있는 그리드의 DataRow

                  if (selectedRows.Count() < 1)
                  {
                      return;
                  }

                  DataRow dr = selectedRows.FirstOrDefault();
                  string selectedClaimNo = Format.GetString(dr["CLAIMNUMBER"]);

                  DataTable dt = grdDefectRegist.DataSource as DataTable;

                  int duplicatedCNT = dt.AsEnumerable()
                      .Where(r => Format.GetString(r["CLAIMNUMBER"]).Equals(selectedClaimNo))
                      .ToList().Count;

                  //저장되지 않은 항목중 팝업선택 ClaimNo와 중복이 있을 경우
                  if (duplicatedCNT > 1)
                  {
                      dataGridRow["CLAIMNUMBER"] = string.Empty;
                      throw MessageException.Create("DuplicationDefectClaimNumber", selectedClaimNo);
                  }

              });

            claimNoPopup.Conditions.AddTextBox("P_DOCID").SetLabel("DOCID");
            claimNoPopup.Conditions.AddTextBox("P_CLAIMNUMBER").SetLabel("CLAIMNUMBER");

            claimNoPopup.GridColumns.AddTextBoxColumn("DOCID", 150)
                .SetIsReadOnly();

            claimNoPopup.GridColumns.AddTextBoxColumn("CLAIMNUMBER", 200)
                .SetIsReadOnly();
        }
        #endregion

        #region 불량품코드 팝업 초기화
        private void InitializeProductListPopup()
        {
            var productPopup = grdDefectRegist.View.AddSelectPopupColumn("DEFECTITEMID", 100, new SqlQuery("GetConsumableDefListDefect", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
              .SetPopupLayout("PRODUCTDEFLIST", PopupButtonStyles.Ok_Cancel, true, true)
              .SetPopupResultCount(1)
              .SetPopupResultMapping("DEFECTITEMID", "CONSUMABLEDEFID")
              .SetPopupLayoutForm(800, 600, FormBorderStyle.FixedToolWindow)
              //.SetPopupAutoFillColumns("CONSUMABLEDEFNAME")
              .SetLabel("DEFECTITEMID")
              .SetValidationKeyColumn()
              .SetPopupApplySelection((IEnumerable<DataRow> selectedRow, DataRow dataGirdRow) =>
              {
                  if (selectedRow.Count() > 0)
                  {
                      grdDefectRegist.View.SetFocusedRowCellValue("DEFECTITEMNUMBER", selectedRow.FirstOrDefault()["CONSUMABLEDEFSEQ"]);
                      grdDefectRegist.View.SetFocusedRowCellValue("DEFECTITEMNAME", selectedRow.FirstOrDefault()["CONSUMABLEDEFNAME"]);
                  }
                  else
                  {
                      grdDefectRegist.View.SetFocusedRowCellValue("DEFECTITEMNUMBER", "");
                      grdDefectRegist.View.SetFocusedRowCellValue("DEFECTITEMNAME", "");
                  }
              });

            // 팝업의 검색조건 항목 추가 (품목타입)
            productPopup.Conditions.AddComboBox("P_PRODUCTDEFTYPE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=CondDefectConsum", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem().SetLabel("PRODUCTDEFTYPE");
            productPopup.Conditions.AddTextBox("P_PRODUCTDEFTXT").SetLabel("PRODUCTDEFIDNAME");

            productPopup.GridColumns.AddTextBoxColumn("CONSUMABLEDEFID", 150)
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("CONSUMABLEDEFNAME", 200)
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("CONSUMABLETYPENAME", 150)
                .SetIsReadOnly().SetLabel("TYPE");
            productPopup.GridColumns.AddTextBoxColumn("DESCRIPTION", 200)
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("CONSUMABLEDEFSEQ", 100)
                .SetIsHidden();
        }

        #endregion
        
        #region 업체 팝업 초기화
        private void InitializeCompanyListPopup()
        {
            var customerPopup = grdDefectRegist.View.AddSelectPopupColumn("CUSTOMERNAME", 180, new SqlQuery("GetCustomer", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"COMP=Y", $"DBLINKNAME={CommonFunction.DbLinkName}"), "CUSTOMERNAME")
                .SetPopupLayout("SELECTVENDORID", PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(600, 500, System.Windows.Forms.FormBorderStyle.FixedToolWindow)
                .SetTextAlignment(TextAlignment.Left)
                .SetValidationKeyColumn()
                .SetPopupAutoFillColumns("CUSTOMERNAME")
                .SetLabel("VENDORNAME2")
                .SetPopupApplySelection((IEnumerable<DataRow> selectedRow, DataRow dataGirdRow) =>
                {
                    if (selectedRow.Count() > 0)
                    {
                        grdDefectRegist.View.SetFocusedRowCellValue("COMPANYID", selectedRow.FirstOrDefault()["CUSTOMERID"]);
                        grdDefectRegist.View.SetFocusedRowCellValue("CUSTKINDNAME", selectedRow.FirstOrDefault()["CUSTKINDNAME"]);
                    }
                    else
                    {
                        grdDefectRegist.View.SetFocusedRowCellValue("COMPANYID", "");
                        grdDefectRegist.View.SetFocusedRowCellValue("CUSTKINDNAME", "");
                    }
                });

            // 검색조건
            customerPopup.Conditions.AddTextBox("CUSTOMERIDNAME").SetLabel("TXTVENDOR");

            // 팝업의 그리드에 컬럼 추가
            customerPopup.GridColumns.AddTextBoxColumn("CUSTOMERID", 100).SetLabel("COMPANYID");
            customerPopup.GridColumns.AddTextBoxColumn("CUSTOMERNAME", 150).SetLabel("COMPANYNAME");
            customerPopup.GridColumns.AddTextBoxColumn("CUSTKINDNAME", 100).SetLabel("NATIONALITY");
            //customerPopup.GridColumns.AddTextBoxColumn("PHONE", 100);
            //customerPopup.GridColumns.AddTextBoxColumn("ADDRESS", 250);
        }
        #endregion

        #region 발견자 팝업 초기화

        private void InitializeFindIdListPopup()
        {
            var userPopup = grdDefectRegist.View.AddSelectPopupColumn("FINDNAME", 100, new SqlQuery("GetUserSelectPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
              .SetPopupLayout("CONFIRMUSER", PopupButtonStyles.Ok_Cancel, true, true)
              .SetPopupResultCount(1)
              .SetPopupResultMapping("FINDNAME", "USERNAME")
              .SetPopupLayoutForm(800, 600, FormBorderStyle.FixedToolWindow)
              //.SetPopupAutoFillColumns("CONSUMABLEDEFNAME")
              .SetLabel("DEFECTDISCOVERER")
              .SetPopupApplySelection((IEnumerable<DataRow> selectedRow, DataRow dataGirdRow) =>
              {
                  // selectedRows : 팝업에서 선택한 DataRow(컬렉션)
                  // dataGridRow : 현재 Focus가 있는 그리드의 DataRow

                  if (selectedRow.Count() > 0)
                  {
                      grdDefectRegist.View.SetFocusedRowCellValue("FINDID", selectedRow.FirstOrDefault()["USERID"]);
                  }
                  else
                  {
                      grdDefectRegist.View.SetFocusedRowCellValue("FINDNAME", string.Empty);
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
        }

        private void InitializeDetectIdListPopup()
        {
            var userPopup = grdDefectRegist.View.AddSelectPopupColumn("DETECTNAME", 100, new SqlQuery("GetUserSelectPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
              .SetPopupLayout("CONFIRMUSER", PopupButtonStyles.Ok_Cancel, true, true)
              .SetPopupResultCount(1)
              .SetPopupResultMapping("DETECTNAME", "USERNAME")
              .SetPopupLayoutForm(800, 600, FormBorderStyle.FixedToolWindow)
              //.SetPopupAutoFillColumns("CONSUMABLEDEFNAME")
              .SetLabel("DEFECTDISCOVERER")
              .SetValidationKeyColumn()
              .SetPopupApplySelection((IEnumerable<DataRow> selectedRow, DataRow dataGirdRow) =>
              {
                  // selectedRows : 팝업에서 선택한 DataRow(컬렉션)
                  // dataGridRow : 현재 Focus가 있는 그리드의 DataRow

                  if (selectedRow.Count() > 0)
                  {
                      grdDefectRegist.View.SetFocusedRowCellValue("DETECTID", selectedRow.FirstOrDefault()["USERID"]);
                  }
                  else
                  {
                      grdDefectRegist.View.SetFocusedRowCellValue("DETECTNAME", string.Empty);
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
        }

        #endregion

        #endregion

        #endregion

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            //Add Row 가 있을 때 Delete버튼 생성
            new SetGridDeleteButonVisibleSimple(grdDefectRegist);

            //그리드 addingRow 시 발견부서/발견자는 로그인 사용자 정보를 자동 Display
            grdDefectRegist.View.AddingNewRow += (s, e) => 
            {
                e.NewRow["PUBLISHDATE"] = DateTime.Now.ToString("yyyy-MM-dd");
                e.NewRow["DETECTID"] = UserInfo.Current.Id;
                e.NewRow["DETECTNAME"] = UserInfo.Current.Name;
            };

            (grdDefectRegist.View.Columns["DEFECTITEMID"].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).ButtonClick += (s, e) =>
            {
                if (e.Button.Kind.Equals(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear))
                {
                    DataRow row = grdDefectRegist.View.GetFocusedDataRow();
                    if (row == null) return;
                    row["DEFECTITEMNAME"] = string.Empty;
                }
            };


            (grdDefectRegist.View.Columns["CUSTOMERNAME"].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).ButtonClick += (s, e) =>
            {
                if (e.Button.Kind.Equals(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear))
                {
                    DataRow row = grdDefectRegist.View.GetFocusedDataRow();
                    if (row == null) return;
                    row["COMPANYID"] = string.Empty;
                    row["CUSTKINDNAME"] = string.Empty;
                }
            };


            //등록된 발견자와 로그인 유저가 일치하지 않을 경우, 진행상태가 등록이 아닌경우 수정 불가
            grdDefectRegist.View.ShowingEditor += (s, e) => 
            {
                DataRow row = grdDefectRegist.View.GetFocusedDataRow();

                if (row == null) return;

                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Deleted) return;

                string defectId = Format.GetString(row["DETECTID"]);//발견자
                                                                  
                if (!IsUpdatable(defectId))
                {//등록된 발견자와 로그인 유저가 일치하지 않을 경우 등록 취소 불가
                    ShowMessage("NotMatchDiscovererWithLoginUser");// 발견자만 수정 및 등록취소 가능합니다.
                    e.Cancel = true;
                }
                else
                {//진행상태가 등록이 아닌경우 수정 불가 
                    if (!Format.GetString(row["PROGRESSSTATE"]).Equals("Registration"))
                    {
                        ShowMessage("CantUpdatedefectProgressstate");//진행상태가 등록이 아닌경우 수정 할 수 없습니다.
                        e.Cancel = true;
                    }
                    else
                    {//수정 가능 할 경우

                        //클레임번호
                        if (grdDefectRegist.View.FocusedColumn.FieldName == "CLAIMNUMBER" && Format.GetString(row["HASCLAIMNUMBER"]).Equals("Y"))
                            {//이미 입력된 클레임번호가 있으면 수정 불가
                            ShowMessage("CantUpdatedWithClaimNo"); // Claim No가 매핑되어 있는경우 수정 할 수 없습니다.
                            e.Cancel = true;
                        }
                    }
                }
            };

            //업체 컬럼 바뀔때 국적값 바인딩 이벤트
            //grdDefectRegist.View.CellValueChanged += View_CellValueChanged;

            //입력, 읽기전용 컬럼 표시
            grdDefectRegist.View.RowCellStyle += (s, e) =>
            {
                if (e.Column.FieldName.Equals("DOCID") ||
                    e.Column.FieldName.Equals("PROGRESSSTATENAME") ||
                    e.Column.FieldName.Equals("DEFECTITEMNAME") ||
                    e.Column.FieldName.Equals("CUSTKINDNAME") ||
                    e.Column.FieldName.Equals("DEFECTPRICE") ||
                    e.Column.FieldName.Equals("DEFECTRATE") ||
                    e.Column.FieldName.Equals("RECURRCNT") )
                {
                    e.Column.AppearanceCell.BackColor = Color.FromArgb(242, 242, 242);
                }

            };

            //불량금액 = 단가 * 불량수량
            //품목정보 또는 거래처 조회시 단가 자동불러오기(FROM ERP)
            grdDefectRegist.View.CellValueChanged += (s, e) =>
            {
                if (e.Column.FieldName.Equals("UNITPRICE") || e.Column.FieldName.Equals("DEFECTQTY"))
                {
                    double defectPrice = 0;

                    double unitPrice = Format.GetDouble(grdDefectRegist.View.GetRowCellValue(e.RowHandle, "UNITPRICE"),0);
                    double defectQty = Format.GetDouble(grdDefectRegist.View.GetRowCellValue(e.RowHandle, "DEFECTQTY"), 0);

                    defectPrice = unitPrice * defectQty;
                    grdDefectRegist.View.SetRowCellValue(e.RowHandle, "DEFECTPRICE", defectPrice);
                }

                if (e.Column.FieldName.Equals("COMPANYID") || e.Column.FieldName.Equals("DEFECTITEMNUMBER"))
                {
                    var sItemSeq = grdDefectRegist.View.GetRowCellValue(e.RowHandle, "DEFECTITEMNUMBER");
                    var sCompanySeq = grdDefectRegist.View.GetRowCellValue(e.RowHandle, "COMPANYID");
                    var sDate = grdDefectRegist.View.GetRowCellValue(e.RowHandle, "PUBLISHDATE");

                    if (sItemSeq.ToString().Length > 0 && sCompanySeq.ToString().Length > 0)
                    {
                        Dictionary<string, object> dicParam = new Dictionary<string, object>();
                        dicParam.Add("ITEMSEQ", sItemSeq.ToString());
                        dicParam.Add("CUSTSEQ", sCompanySeq.ToString());
                        dicParam.Add("BDATE", sDate.ToString().Replace("-", string.Empty));
                        dicParam.Add("DBLINKNAME", CommonFunction.DbLinkName);
                        
                        DataTable dt = SqlExecuter.Query("GetUnitPriceList", "00001", dicParam);

                        if(dt.Rows.Count > 0)
                        {
                            grdDefectRegist.View.SetRowCellValue(e.RowHandle, "UNITPRICE", dt.Rows[0]["Price"].ToString());
                        }
                    }
                }
            };

        }

        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("COMPANYID"))
            {
                if(e.Column.ColumnEdit is RepositoryItemLookUpEdit lookup)
                {
                    object custKindName = lookup.GetDataSourceValue("CUSTKINDNAME", lookup.GetDataSourceRowIndex("CUSTOMERID", e.Value));
                    grdDefectRegist.View.SetFocusedRowCellValue("CUSTKINDNAME", Format.GetString(custKindName));
                }
            }
        }


        #endregion

        #region 툴바

        /// <summary>
        /// 툴바 버튼 기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;

            //불량통지서 버튼 클릭
            if (btn.Name.ToString().Equals("DefectNotice"))
            {//엑셀export 버튼
                Btn_DefectNoticeClick();
            }
            //등록 취소 버튼 클릭
            else if (btn.Name.ToString().Equals("CancelRegistration"))
            {
                Btn_CancelRegistrationClick(btn.Name.ToString(), btn.Text);
            }
            //저장버튼 클릭
            else if (btn.Name.ToString().Equals("Save") || btn.Name.ToString().Equals("SaveBehind"))
            {
                Btn_SaveClick(btn.Text);
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
            values.Add("LANGUAGETYPE", Framework.UserInfo.Current.LanguageType);
            values.Add("DBLINKNAME", CommonFunction.DbLinkName);

            DataTable dt = await SqlExecuter.QueryAsync("SelectDefectRegistList", "00001", values);

            if (dt.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdDefectRegist.DataSource = dt;

        }

        #region 조회조건 구성
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
            DateTime today = DateTime.Now;
            Dictionary<string, object> defaultValue = new Dictionary<string, object>
            {
                {"P_DATEPERIOD_PERIODFR",today.AddDays(1- today.Day)},
                {"P_DATEPERIOD_PERIODTO",today}
            };
            this.Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD").SetValue(defaultValue);
          
        }
        #endregion

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            // TODO : 유효성 로직 변경
            grdDefectRegist.GetChangedRows();

            DataTable changed = grdDefectRegist.View.GetCheckedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Public Function

        #endregion

        #region Private Function

        /// <summary>
        /// 불량통지서 버튼 클릭 함수
        /// </summary>
        private void Btn_DefectNoticeClick()
        {
            DataRow row = grdDefectRegist.View.GetFocusedDataRow();
            if (row == null) return;

            /*
            DataTable dt = new DataTable();

            dt.Columns.Add("@TEST1");
            dt.Columns.Add("@TEST2");

            dt.Rows.Add("aa", "bb");
            */

            if (Format.GetString(row["PROGRESSSTATE"]).Equals("CancelRegistration"))
            {
                ShowMessage("DefectCancelRegState");
                return;
            }

            DataTable dt = new DataTable();
            dt = (grdDefectRegist.DataSource as DataTable).Clone();
            dt.ImportRow(row);
            CommonFunction.ExuteExcelBindingData(Constants.DecfectDoc, dt);
            return;


            pnlContent.ShowWaitArea();

            DefectExcelPopup popup = new DefectExcelPopup();
            popup.Owner = this;
            popup.CurrentDataRow = row;
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ShowDialog();

            pnlContent.CloseWaitArea();
        }

        /// <summary>
        /// 등록취소 버튼 클릭 함수
        /// </summary>
        private void Btn_CancelRegistrationClick(string toState, string toStateDic)
        {
            DataRow row = grdDefectRegist.View.GetFocusedDataRow();

            if (row == null) return;
            if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Deleted) return;

            //선택된 row 수정 상태이면 상태변경불가 메시지
            if (row.RowState == DataRowState.Modified)
            {
                ShowMessage("NeedToSaveToChangeState");//저장 후 상태변경 가능 합니다.
                return;
            }

            string detectId = Format.GetString(row["DETECTID"]);//발견자
            //등록된 발견자와 로그인 유저가 일치하지 않을 경우 등록 취소 불가
            if (!IsUpdatable(detectId))
            {
                ShowMessage("NotMatchDiscovererWithLoginUser");//발견자만 수정 및 등록취소 가능합니다.
                return;
            }


            if (!Format.GetString(row["PROGRESSSTATE"]).Equals("Registration"))
            {
                ShowMessage("CantCancelRegistrationState");//등록 상태가 아닌 건은 등록 취소 할 수 없습니다.
                return;
            }

            //현재 상태와 변경하려는 상태 같을 경우 
            if (CheckcurrentStateToState(Format.GetString(row["PROGRESSSTATE"]), toState, toStateDic))
                return;

            ChangeStateToCancelRegist(row);
        }

        /// <summary>
        /// 저장 함수
        /// </summary>
        /// <param name="strtitle"></param>
        private void Btn_SaveClick(string strtitle)
        {
            grdDefectRegist.View.CloseEditor();
            grdDefectRegist.View.CheckValidation();

            DataTable changed = grdDefectRegist.GetChangedRows();
            
            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                this.ShowMessage(MessageBoxButtons.OK, "NoSaveData");
                return;
            }

            DialogResult result = System.Windows.Forms.DialogResult.No;

            result = this.ShowMessage(MessageBoxButtons.YesNo, "InfoSave", strtitle);//저장하시겠습니까? 

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    this.ShowWaitArea();

                    MessageWorker messageWorker = new MessageWorker("SaveDefectRegist");

                    messageWorker.SetBody(new MessageBody()
                    {
                        { "list", changed }
                    });

                    messageWorker.Execute();

                    ShowMessage("SuccessSave");
                    //재조회 
                    SearchMainGrid();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
                finally
                {
                    this.CloseWaitArea();


                }
            }
        }

        /// <summary>
        /// 등록취소 함수
        /// </summary>
        /// <param name="row"></param>
        private void ChangeStateToCancelRegist(DataRow row)
        {
            CallStateChangeRule(row, "InfoCancelDefectRegist" , "CancelRegistration");
        }

        /// <summary>
        /// 불량통지서 관리 상태변경 룰을 호출하는 함수
        /// </summary>
        /// <param name="row"></param>
        /// <param name="MessageId"></param>
        /// <param name="toChangestate"></param>
        private void CallStateChangeRule(DataRow row, string MessageId, string toChangestate)
        {
            DialogResult result = System.Windows.Forms.DialogResult.No;

            result = this.ShowMessage(MessageBoxButtons.YesNo, MessageId);//불량품통지서 등록취소 하시겠습니까? 

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    this.ShowWaitArea();

                    MessageWorker messageWorker = new MessageWorker("SaveDefectRegistChangeState");

                    messageWorker.SetBody(new MessageBody()
                    {
                        { "DocId", row["DOCID"] },
                        { "toChangeState", toChangestate }
                    });

                    messageWorker.Execute();

                    ShowMessage("SuccessSave");
                    //재조회 
                    SearchMainGrid();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
                finally
                {
                    this.CloseWaitArea();
                }

            }
        }

        private async void SearchMainGrid()
        {
            await OnSearchAsync();
        }

        /// <summary>
        /// 발견자와 로그인 유저 일치여부 체크하여 수정 및 등록취소 여부 판단하는 함수
        /// </summary>
        /// <param name="discoverer"></param>
        /// <returns></returns>
        private bool IsUpdatable(string discoverer)
        {
            bool isUpdatable = true;

            if (!discoverer.Equals(UserInfo.Current.Id))
            {
                isUpdatable = false;
            }

            return isUpdatable;
        }

        /// <summary>
        /// 납입수량 보다 불량 수량이 크지않은지 체크
        /// </summary>
        /// <param name="rowHandle"></param>
        /// <returns></returns>
        private IEnumerable<ValidationResult> QtyValidation(int rowHandle)
        {
            DataRow row = grdDefectRegist.View.GetDataRow(rowHandle);

            List<ValidationResult> result = new List<ValidationResult>();
            ValidationResult checkResult = new ValidationResult();

            if (row["PAYMENTQTY"] == DBNull.Value || row["DEFECTQTY"] == DBNull.Value)
            {
                return result;
            }

            if (Convert.ToInt32(row["PAYMENTQTY"]) < Convert.ToInt32(row["DEFECTQTY"]))
            {
                checkResult.Caption = "Message";
                checkResult.Id = "DEFECTQTY";
                checkResult.FailMessage = Language.GetMessage("DefectQtyCantMoreThanPaymentQty").Message;//불량수량은 납입수량보다 클수 없습니다.
                checkResult.IsSucced = false;

                result.Add(checkResult);
            }

            return result;
        }


        /// <summary>
        /// 현재 상태와 바꾸려는 상태 비교하여 같으면 불가 함수
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="toState"></param>
        /// <returns></returns>
        private bool CheckcurrentStateToState(string currentState , string toState, string toStateDic)
        {
            bool isEqualsState = false;

            if (currentState.Equals(toState))
            {
                ShowMessage("EqualsDefectCurrentToState", toStateDic);//이미 {0} 상태입니다.
                isEqualsState = true;
            }

            return isEqualsState;
        }

        #endregion
    }
}
