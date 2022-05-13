#region using

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
    /// 프 로 그 램 명  : 기준정보 > 항목관리 > 품목 라우터 관리
    /// 업  무  설  명  : ex> 시스템에서 공통으로 사용되는 품목 라우터 관리한다.
    /// 생    성    자  : 강유라
    /// 생    성    일  : 2020-05-20
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ProcessDefinitionMgt : SmartConditionBaseForm
    {
        #region Local Variables

        // TODO : 화면에서 사용할 내부 변수 추가

        #endregion

        #region 생성자

        public ProcessDefinitionMgt()
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

            // TODO : 컨트롤 초기화 로직 구성
            InitializeGrid();

            InitializeEvent();

        }

        #region 그리드 초기화
        /// <summary>        
        /// 품목 라우터 관리 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            // TODO : 그리드 초기화 로직 추가
            #region ProcessDefinition Grd 초기화
            grdProcessDef.GridButtonItem = GridButtonItem.Add | GridButtonItem.Delete;
            grdProcessDef.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;

            grdProcessDef.View.AddTextBoxColumn("PROCESSDEFID", 150).SetValidationKeyColumn().SetLabel("ROUTERID");//라우터 ID
            grdProcessDef.View.AddComboBoxColumn("PROCESSCLASSID", 200, new SqlQuery("GetProcessClassIdList", "00001", "PLANTID=P1"), "PROCESSCLASSNAME", "PROCESSCLASSID").SetValidationIsRequired().SetLabel("라우팅그룹");

            //grdProcessDef.View.AddLanguageColumn("PROCESSDEFNAME", 100).SetValidationIsRequired().SetLabel("ROUTERNAME");//라우터 설명
            //======================> 다국어 코드정리 후 수정
            grdProcessDef.View.AddTextBoxColumn("PROCESSDEFNAME$$KO-KR", 200).SetValidationIsRequired().SetLabel("ROUTERNAME");//라우터 설명
            grdProcessDef.View.AddTextBoxColumn("PROCESSDEFNAME$$EN-US", 200).SetValidationIsRequired().SetLabel("ROUTERNAME");//라우터 설명
            grdProcessDef.View.AddTextBoxColumn("PROCESSDEFNAME$$JA-JP", 200).SetValidationIsRequired().SetLabel("ROUTERNAME");//라우터 설명

            grdProcessDef.View.AddTextBoxColumn("PROCESSDEFVERSION", 100).SetIsHidden();//라우터 Version

            InitializeProcessSegmentPopup();//공정명
            grdProcessDef.View.AddTextBoxColumn("PROCESSSEGMENTID", 100).SetIsHidden();//공정 ID
            grdProcessDef.View.AddTextBoxColumn("PROCESSSEGMENTVERSION", 100).SetIsHidden();//공정 Version

            grdProcessDef.View.AddTextBoxColumn("PRODUCTCNT", 80).SetIsReadOnly();//품목수

            grdProcessDef.View.AddTextBoxColumn("CREATOR")// 생성자
               .SetIsReadOnly()
               .SetTextAlignment(TextAlignment.Center);

            grdProcessDef.View.AddTextBoxColumn("CREATEDTIME", 130)//생성일
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdProcessDef.View.AddTextBoxColumn("MODIFIER", 80)//수정자
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdProcessDef.View.AddTextBoxColumn("MODIFIEDTIME", 130)//수정일
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdProcessDef.View.PopulateColumns();
            #endregion

            #region ProductMapping Grd 초기화
            grdProductMapping.GridButtonItem = GridButtonItem.Add | GridButtonItem.Delete;
            grdProductMapping.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;


            grdProductMapping.View.AddTextBoxColumn("PRODUCTDEFID", 200).SetIsReadOnly()
                .SetIsHidden();//품목코드 
            InitializeProductListPopup();//품목코드(PARANUMBER)
            grdProductMapping.View.AddTextBoxColumn("PRODUCTDEFNAME", 200).SetIsReadOnly();//품목명
            grdProductMapping.View.AddTextBoxColumn("PRODUCTDEFVERSION", 100).SetIsHidden();//품목버전
            grdProductMapping.View.AddTextBoxColumn("PRODUCTMODEL", 100).SetLabel("PRODUCTCLASSNAME").SetIsReadOnly();//기종
            grdProductMapping.View.AddTextBoxColumn("PRODUCTDEFTYPE", 100).SetLabel("PRODUCTDEFTYPENAME").SetIsReadOnly();//품목분류
            grdProductMapping.View.AddTextBoxColumn("품목구분_미정", 100).SetIsReadOnly();//품목구분
            grdProductMapping.View.AddTextBoxColumn("LOTSIZE", 100).SetIsReadOnly();//LOT구분

            grdProductMapping.View.AddTextBoxColumn("PROCESSDEFID", 100).SetIsHidden();
            grdProductMapping.View.AddTextBoxColumn("PROCESSDEFVERSION", 100).SetIsHidden();

            grdProductMapping.View.PopulateColumns();
            #endregion


        }
        #endregion

        #region 공정 팝업 초기화
        private void InitializeProcessSegmentPopup()
        {
            var ProcessSegmentPopup = grdProcessDef.View.AddSelectPopupColumn("PROCESSSEGMENTNAME", 200, new SqlQuery("GetProcessSegmentList", "00001", $"PROCESSSEGMENTTYPE=MAIN"))
              .SetPopupLayout("PROCESSSEGMENTLIST", PopupButtonStyles.Ok_Cancel, true, true)
              .SetPopupResultCount(1)
              .SetPopupLayoutForm(800, 600, FormBorderStyle.FixedToolWindow)
              .SetPopupAutoFillColumns("PROCESSSEGMENTNAME")
              .SetLabel("PROCESSSEGMENTNAME")
              .SetValidationKeyColumn()
              .SetPopupApplySelection((selectedRows, dataGridRow) =>
              {
                  // selectedRows : 팝업에서 선택한 DataRow(컬렉션)
                  // dataGridRow : 현재 Focus가 있는 그리드의 DataRow
                  if (selectedRows.Count() < 1)
                  {
                      return;
                  }

                  foreach (DataRow row in selectedRows)
                  {
                       dataGridRow["PROCESSSEGMENTID"] = row["PROCESSSEGMENTID"].ToString();
                       dataGridRow["PROCESSSEGMENTVERSION"] = row["PROCESSSEGMENTVERSION"].ToString();
                  }

              });

            // 팝업의 검색조건 항목 추가 (품목타입)
            ProcessSegmentPopup.Conditions.AddTextBox("P_PROCESSSEGMENTTXT").SetLabel("PROCESSSEGMENTIDNAME");

            ProcessSegmentPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150)
                .SetIsReadOnly();
            ProcessSegmentPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200)
                .SetIsReadOnly();
            ProcessSegmentPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTVERSION", 200)
                .SetIsReadOnly();
        }

        #endregion

        #region 품목 팝업 초기화
        private void InitializeProductListPopup()
        {
            var productPopup = grdProductMapping.View.AddSelectPopupColumn("PARTNUMBER", 150, new SqlQuery("GetProductDefByProductType", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
              .SetPopupLayout("PRODUCTDEFLIST", PopupButtonStyles.Ok_Cancel, true, true)
              .SetPopupResultCount(1)
              .SetPopupLayoutForm(800, 600, FormBorderStyle.FixedToolWindow)
              .SetLabel("PRODUCTDEFID")
              .SetValidationKeyColumn()             
              .SetPopupApplySelection((selectedRows, dataGridRow) =>
              {
                  // selectedRows : 팝업에서 선택한 DataRow(컬렉션)
                  // dataGridRow : 현재 Focus가 있는 그리드의 DataRow

                  if (selectedRows.Count() < 1)
                  {
                      return;
                  }

                  DataRow row = selectedRows.FirstOrDefault();
                  dataGridRow["PRODUCTDEFNAME"] = Format.GetString(row["PRODUCTDEFNAME"]);
                  dataGridRow["PRODUCTDEFID"] = Format.GetString(row["PRODUCTDEFID"]);
                  dataGridRow["PRODUCTDEFVERSION"] = Format.GetString(row["PRODUCTDEFVERSION"]);
                  dataGridRow["PRODUCTMODEL"] = Format.GetString(row["PRODUCTMODEL"]);
                  dataGridRow["PRODUCTDEFTYPE"] = Format.GetString(row["PRODUCTDEFTYPE"]);
                  dataGridRow["LOTSIZE"] = Format.GetDecimal(row["LOTSIZE"]);

                  DataTable dt = grdProductMapping.DataSource as DataTable;

                  int duplicatedCNT = dt.AsEnumerable()
                      .Where(r => Format.GetString(r["PARTNUMBER"]).Equals(Format.GetString(row["PARTNUMBER"]))
                      && Format.GetString(r["PRODUCTDEFVERSION"]).Equals(Format.GetString(row["PRODUCTDEFVERSION"])))
                      .ToList().Count;

                  if (duplicatedCNT > 1 )
                  {
                      dataGridRow["PRODUCTDEFID"] = string.Empty;
                      dataGridRow["PARTNUMBER"] = string.Empty;
                      dataGridRow["PRODUCTDEFNAME"] = string.Empty;
                      dataGridRow["PRODUCTDEFVERSION"] = string.Empty;
                      dataGridRow["PRODUCTMODEL"] = string.Empty;
                      dataGridRow["PRODUCTDEFTYPE"] = string.Empty;
                      dataGridRow["LOTSIZE"] = DBNull.Value;

                      throw MessageException.Create("DuplicationProductMapping", Format.GetString(row["PARTNUMBER"])+", "+ Format.GetString(row["PRODUCTDEFVERSION"]));
                      //품목 Mappinag 리스트가 중복되었습니다.
                  }


                  

              });

            // 팝업의 검색조건 항목 추가 (품목타입)
            productPopup.Conditions.AddComboBox("P_PRODUCTDEFTYPE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=ProductDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem().SetLabel("PRODUCTDEFTYPE");

            productPopup.Conditions.AddTextBox("P_PRODUCTDEFTXT").SetLabel("PRODUCTDEFIDNAME");

            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 150)
                .SetIsReadOnly()
                .SetIsHidden();
            productPopup.GridColumns.AddTextBoxColumn("PARTNUMBER", 150)
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200)
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFVERSION", 200)
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTMODEL", 200).SetLabel("PRODUCTCLASSNAME")
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFTYPE", 200).SetLabel("PRODUCTDEFTYPENAME")
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("LOTSIZE", 200)
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("DESCRIPTION", 200)
                .SetIsReadOnly();
        }

        #endregion

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // TODO : 화면에서 사용할 이벤트 추가

            //grdProductMapping에 추가, 수정, 삭제 된 항목있는지 체크하여 AddingRow막는 이벤트
            //=> 다른 그리드 수정중에는 추가 또는 수정 할 수 없음
            grdProcessDef.ToolbarAddingRow += (s, e) =>
            {
                if (!CheckGrdProductMappingChanged())
                    e.Cancel = true;
            };

            //grdProductMapping에 추가, 수정, 삭제 된 항목있는지 체크하여 DeletingRow이벤트
            //=> 다른 그리드 수정중에는 추가 또는 수정 할 수 없음
            grdProcessDef.ToolbarDeletingRow += (s, e) =>
            {
                if (!CheckGrdProductMappingChanged())
                    e.Cancel = true;
            };

            //grdProductMapping에 추가, 수정, 삭제 된 항목있는지 체크하여 수정막는 이벤트
            //=> 다른 그리드 수정중에는 추가 또는 수정 할 수 없음
            grdProcessDef.View.ShowingEditor += (s, e) =>
            {
                if (!CheckGrdProductMappingChanged())
                    e.Cancel = true;
            };

            //grdProcessDef 포커스 행이 바뀔 때 grdProductMapping에 재바인딩
            grdProcessDef.View.FocusedRowChanged += View_FocusedRowChanged;  

            //grdProcessDef 추가, 수정, 삭제 된 항목있는지 체크하여 AddingRow 이벤트
            //=> 다른 그리드 수정중에는 추가 또는 수정 할 수 없음
            grdProductMapping.ToolbarAddingRow += (s, e) =>
            {
                if(!CheckGrdgrdProcessDefChanged())
                    e.Cancel = true;

                DataRow row = grdProcessDef.View.GetFocusedDataRow();
                if (row == null)
                    e.Cancel = true;
            };

            //grdProcessDef 추가, 수정, 삭제 된 항목있는지 체크하여 DeletingRow 이벤트
            //=> 다른 그리드 수정중에는 추가 또는 수정 할 수 없음
            grdProductMapping.ToolbarDeletingRow += (s, e) =>
            {
                if (!CheckGrdgrdProcessDefChanged())
                    e.Cancel = true;

                DataRow row = grdProcessDef.View.GetFocusedDataRow();
                if (row == null)
                    e.Cancel = true;
            };


            //grdProcessDef 추가, 수정, 삭제 된 항목있는지 체크하여 수정막는 이벤트
            //=> 다른 그리드 수정중에는 추가 또는 수정 할 수 없음
            grdProductMapping.View.ShowingEditor += (s, e) =>
            {
                if (!CheckGrdgrdProcessDefChanged())
                    e.Cancel = true;
            };
            
            //grdProcessDef row 추가시 포컷 되어있는 processDef 그리드의
            //processDefId, ProcessDefversion 입력
            grdProductMapping.View.AddingNewRow += (s, e) =>
            {
                DataRow row = grdProcessDef.View.GetFocusedDataRow();

                if (row == null) return;
                e.NewRow["PROCESSDEFID"] = Format.GetString(row["PROCESSDEFID"]);
                e.NewRow["PROCESSDEFVERSION"] = Format.GetString(row["PROCESSDEFVERSION"]);
            };

            (grdProductMapping.View.Columns["PARTNUMBER"].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
                {

                    grdProductMapping.View.SetFocusedRowCellValue("PARTNUMBER", string.Empty);
                    grdProductMapping.View.SetFocusedRowCellValue("PRODUCTDEFID", string.Empty);
                    grdProductMapping.View.SetFocusedRowCellValue("PRODUCTDEFNAME", string.Empty);
                    grdProductMapping.View.SetFocusedRowCellValue("PRODUCTDEFVERSION", string.Empty);
                    grdProductMapping.View.SetFocusedRowCellValue("PRODUCTMODEL", string.Empty);
                    grdProductMapping.View.SetFocusedRowCellValue("PRODUCTDEFTYPE", string.Empty);
                    grdProductMapping.View.SetFocusedRowCellValue("LOTSIZE", DBNull.Value);

                }
            };
        }

        /// <summary>
        /// grdProductMapping 수정 사항있으면 포커스행 바꿀건지 알림 창 확인 
        /// Y => 포커스행 변경 / 저장하지 않은 grdProductMapping 없어짐
        /// N => 포커스행 바꾸지 않음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            grdProcessDef.View.FocusedRowChanged -= View_FocusedRowChanged;

            int prdMappingChangedCNT = grdProductMapping.GetChangedRows().Rows.Count;

            if (prdMappingChangedCNT > 0)
            {
                int beforeRowHandle = e.PrevFocusedRowHandle;

                DialogResult result = DialogResult.No;

                result = ShowMessage(MessageBoxButtons.YesNo, "ProcessDefFocusChangeConfirm");//저장 하지않은 품목Mapping 정보가 있습니다. 계속하시겠습니까?

                if (result == DialogResult.Yes)
                {
                    SearchProductMappingData();
                }
                else
                {
                    grdProcessDef.View.FocusedRowHandle = beforeRowHandle;
                }
            }
            else
            {
                SearchProductMappingData();
            }

            grdProcessDef.View.FocusedRowChanged += View_FocusedRowChanged;
        }

        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            // TODO : 저장 Rule 변경
            //DataTable changed = grdProcessDef.GetChangedRows();

            //ExecuteRule("SaveCodeClass", changed);
        }

        /// <summary>
        /// 툴바 버튼 기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;

            if (btn.Name.ToString().Equals("Save") || btn.Name.ToString().Equals("SaveBehind"))
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

            DataTable dt = await SqlExecuter.QueryAsync("SelectProcessDefinitionList","00001",values);

            if (dt.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdProcessDef.DataSource = dt;

            SearchProductMappingData();
        }

        #region 조회조건
        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // TODO : 조회조건 추가 구성이 필요한 경우 사용
            InitializeConditionPopup_ProcessDefId();
            InitializeConditionPopup_ProcessSegmentId();
        }

        #region 라우터 조회조건 팝업 초기화
        /// <summary>
        /// ProcessDefId 선택하는 팝업
        /// </summary>
        private void InitializeConditionPopup_ProcessDefId()
        {
            // 팝업 컬럼 설정
            var processDefPopup = Conditions.AddSelectPopup("P_PROCESSDEFID", new SqlQuery("GetProcessDefList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PROCESSDEFNAME", "PROCESSDEFID")
                                        .SetPopupLayout("ROUTERLIST", PopupButtonStyles.Ok_Cancel, true, false)
                                        .SetPopupLayoutForm(600,500)
                                        .SetPopupResultCount(1)
                                        .SetPosition(1)
                                        .SetLabel("ROUTERID")
                                        .SetPopupAutoFillColumns("PROCESSDEFNAME");

            // 팝업 조회조건
            processDefPopup.Conditions.AddTextBox("P_PROCESSDEFTXT")
                       .SetLabel("ROUTERIDNAME");

            // 팝업 그리드
            processDefPopup.GridColumns.AddTextBoxColumn("PROCESSDEFID", 150).SetLabel("ROUTERID");
            processDefPopup.GridColumns.AddTextBoxColumn("PROCESSDEFNAME", 200).SetLabel("ROUTERNAME");
        }
        #endregion

        #region 공정 조회조건 팝업 초기화
        /// <summary>
        /// ProcessDefId 선택하는 팝업
        /// </summary>
        private void InitializeConditionPopup_ProcessSegmentId()
        {
            // 팝업 컬럼 설정
            var processDefPopup = Conditions.AddSelectPopup("P_PROCESSSEGMENTID", new SqlQuery("GetProcessSegmentList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"PROCESSSEGMENTTYPE=MAIN"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
                                        .SetPopupLayout("PROCESSSEGMENTLIST", PopupButtonStyles.Ok_Cancel, true, false)
                                        .SetPopupLayoutForm(600, 500)
                                        .SetPopupResultCount(1)
                                        .SetPosition(1)
                                        .SetLabel("PROCESSSEGMENTID")
                                        .SetPopupAutoFillColumns("PROCESSSEGMENTNAME");

            // 팝업 조회조건
            processDefPopup.Conditions.AddTextBox("P_PROCESSSEGMENTTXT")
                       .SetLabel("PROCESSSEGMENTIDNAME");

            // 팝업 그리드
            processDefPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150);
            //processDefPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTVERSION", 150);
            processDefPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);
        }
        #endregion

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            // TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
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
            grdProcessDef.View.CheckValidation();

            DataTable changed = grdProcessDef.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        // TODO : 화면에서 사용할 내부 함수 추가
        /// <summary>
        /// 저장 함수
        /// </summary>
        /// <param name="strtitle"></param>
        private void Btn_SaveClick(string strtitle)
        {
            grdProcessDef.View.CloseEditor();
            grdProductMapping.View.CloseEditor();

            grdProcessDef.View.CheckValidation();
            grdProductMapping.View.CheckValidation();

            DataTable processDefchanged = grdProcessDef.GetChangedRows();
            int processDefchangedCNT = processDefchanged.Rows.Count;

            DataTable productMappingchanged = grdProductMapping.GetChangedRows();
            int productMappingchangedCNT = productMappingchanged.Rows.Count;

            //두 그리드 모두 수정사항 없는 경우
            if (processDefchangedCNT == 0 && productMappingchangedCNT == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                this.ShowMessage(MessageBoxButtons.OK, "NoSaveData");
                return;
            }

            //두 그리드 모두 수정사항 있는 경우 => 에러
            if (processDefchangedCNT != 0 && productMappingchangedCNT != 0)
            {
                this.ShowMessage(MessageBoxButtons.OK, "저장 중 오류가 발생 하였습니다.");
                return;
            }

            DialogResult result = System.Windows.Forms.DialogResult.No;

            result = this.ShowMessage(MessageBoxButtons.YesNo, "InfoSave", strtitle);//저장하시겠습니까? 

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    this.ShowWaitArea();

                    DataTable toSave = new DataTable();//두 그리드 중 저장할 DataTable
                    string type = string.Empty;//저장 로직 타입 구분

                    if (processDefchangedCNT > 0)
                    {//라우터 정보 저장하는 경우
                        toSave = processDefchanged;
                        type = "processDef";
                    }
                    else if (productMappingchangedCNT > 0)
                    {// 품목 Mapping 저장 하는 경우
                        toSave = productMappingchanged;
                        type = "productMapping";
                    }
                    else
                    {//저장 불가 => 에러
                        this.ShowMessage(MessageBoxButtons.OK, "저장 중 오류가 발생 하였습니다.");
                        return;
                    }

                    MessageWorker messageWorker = new MessageWorker("SaveProcessDefinitionMgt");

                    messageWorker.SetBody(new MessageBody()
                    {
                        { "list", toSave },
                        { "type", type}
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
        /// 재조회 함수
        /// </summary>
        private async void SearchMainGrid()
        {
            await OnSearchAsync();
        }

        /// <summary>
        /// grdProductMapping의 변경된 행 갯수에따른 결과 return 함수
        /// </summary>
        /// <returns></returns>
        private bool CheckGrdProductMappingChanged()
        {
            bool canEnable = true;

            int changedCNT = grdProductMapping.GetChangedRows().Rows.Count;

            if (changedCNT > 0)
            {
                canEnable = false;
                ShowMessage("SaveOtherGridFirst");//수정중인 그리드를 먼저 저장 하세요.
            }

            return canEnable;
        }

        /// <summary>
        /// grdProcessDef의 변경된 행 갯수에따른 결과 return 함수
        /// </summary>
        /// <returns></returns>
        private bool CheckGrdgrdProcessDefChanged()
        {
            bool canEnable = true;
  
            int changedCNT = grdProcessDef.GetChangedRows().Rows.Count;
            
            if (changedCNT > 0)
            {
                canEnable = false;
                ShowMessage("SaveOtherGridFirst");//수정중인 그리드를 먼저 저장 하세요.
            }

            return canEnable;
        }

        /// <summary>
        /// grdProcessDef에 바인딩 할 Data 조회함수
        /// </summary>
        /// <param name="row"></param>
        private void SearchProductMappingData()
        {
            DataRow row = grdProcessDef.View.GetFocusedDataRow();

            if (row == null) return;

            if (string.IsNullOrWhiteSpace(Format.GetString(row["PROCESSDEFID"])))
            {
                grdProductMapping.View.ClearDatas();
            }
            else
            { 

                Dictionary<string, object> param = new Dictionary<string, object>()
                {
                    {"PROCESSDEFID",Format.GetString(row["PROCESSDEFID"])},
                    {"PROCESSDEFVERSION",Format.GetString(row["PROCESSDEFVERSION"])}
                };

                DataTable dt = SqlExecuter.Query("SelectProductMappingListByProcessDefInfo", "00001", param);

                grdProductMapping.DataSource = dt;

            }
        }
        #endregion
    }
}