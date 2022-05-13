#region using
using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Micube.SmartMES.Commons;
#endregion

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 공정등록 > 조립
    /// 업  무  설  명  : 공정관리 - 조립
    /// 생    성    자  : jylee
    /// 생    성    일  : 2019-06-01
    /// 수  정  이  력  : 2021-05-14 scmo 자재거래처필드 추가
    /// </summary>
    public partial class AssemblyResult : SmartConditionBaseForm
    {
        // 상수
        private const string TOOLBAR_INPUTMATERIAL = "InputMaterial";   // 자재투입
        private const string TOOLBAR_PROCESSRESULT = "ProcessResult";   // 공정실적
        private const string TOOLBAR_CHECKRESULT = "CheckResult";       // 검사실적
        private const string TOOLBAR_RESULTSAVE = "ResultSave";         // 실적저장
        private const string TOOLBAR_TERMINATELOT = "TerminateLot";     // LOT폐기
        private const string PRINT_PRODUCT_LABEL = "PrintProductLabel"; // 제품라벨

        // 변수
        private decimal lotCreatedQty;
        private string specDefIdVersion;

        #region 컨텐츠 초기화
        public AssemblyResult()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeGrid();
            InitializeEvent();
        }

        // 그리드 초기화
        private void InitializeGrid()
        {
            InitializeSubSegmentGrid();
            InitializeResultGrid();
            InitializeMaterialGrid();
        }

        // 세부공정 리스트 그리드
        private void InitializeSubSegmentGrid()
        {
            grdSubSegment.GridButtonItem = GridButtonItem.None;
            grdSubSegment.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdSubSegment.View.AddTextBoxColumn("SUBPROCESSSEGMENTNAME", 150)
                .SetIsReadOnly();                                               // 세부공정명
            grdSubSegment.View.AddTextBoxColumn("WORKER", 100)
                .SetTextAlignment(TextAlignment.Center).SetIsReadOnly();        // 작업자
            grdSubSegment.View.AddTextBoxColumn("TRACKINTIME", 140)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();                                               // 시작일시
            grdSubSegment.View.AddTextBoxColumn("TRACKOUTTIME", 140)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();                                               // 종료일시
            grdSubSegment.View.AddSpinEditColumn("WORKTIME", 80)
                .SetDisplayFormat("N2");                                        // 작업시간
            grdSubSegment.View.AddTextBoxColumn("EQUIPMENTNAME", 220)
                .SetIsReadOnly();                                               // 설비명
            grdSubSegment.View.AddTextBoxColumn("DESCRIPTION", 250);            // 비고

            // Hidden 컬럼
            grdSubSegment.View.AddTextBoxColumn("LOTID").SetIsHidden();               // LOTID
            grdSubSegment.View.AddTextBoxColumn("SUBPROCESSSEGMENTID").SetIsHidden(); // 세부공정 ID
            grdSubSegment.View.AddTextBoxColumn("SEQ").SetIsHidden();                 // 순서
            grdSubSegment.View.AddTextBoxColumn("SPECDEFID").SetIsHidden();           // 스펙 ID
            grdSubSegment.View.AddTextBoxColumn("PROCESSSEGMENTID").SetIsHidden();    // 공정 ID
            grdSubSegment.View.AddTextBoxColumn("ISFINISHED").SetIsHidden();          // 세부공정 실적 확정여부
            grdSubSegment.View.AddTextBoxColumn("AREAID").SetIsHidden();              // 작업장 ID
            grdSubSegment.View.PopulateColumns();
        }

        // 세부공정별 검사실적 그리드
        private void InitializeResultGrid()
        {
            grdResult.GridButtonItem = GridButtonItem.None;
            grdResult.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdResult.View.SetIsReadOnly();
            grdResult.View.AddTextBoxColumn("PARAMETERNAME", 250);  // 검사항목
            grdResult.View.AddTextBoxColumn("UNIT", 50)
                .SetTextAlignment(TextAlignment.Center);            // 단위
            grdResult.View.AddTextBoxColumn("MEASUREVALUE", 100);   // 측정값
            grdResult.View.AddTextBoxColumn("LSL", 70);             // 스펙 MIN
            grdResult.View.AddTextBoxColumn("USL", 70);             // 스펙 MAX
            grdResult.View.AddTextBoxColumn("ISMEASURE", 70)
                .SetTextAlignment(TextAlignment.Center);            // 검사실적 여부
            grdResult.View.AddTextBoxColumn("ISSPECFORCE", 70)
                .SetTextAlignment(TextAlignment.Center);            // 스펙강제 여부
            grdResult.View.AddTextBoxColumn("ISNOTREQUIRED", 70)
                .SetTextAlignment(TextAlignment.Center);            // 미필수 여부
            grdResult.View.PopulateColumns();
        }

        // 투입자재 리스트
        private void InitializeMaterialGrid()
        {
            grdMaterial.GridButtonItem = GridButtonItem.None;
            grdMaterial.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdMaterial.View.SetIsReadOnly();
            grdMaterial.View.AddTextBoxColumn("CONSUMABLEDEFID", 130).SetIsHidden();   // 자재ID
            grdMaterial.View.AddTextBoxColumn("PARTNUMBER", 130);                      // 자재ID
            grdMaterial.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 230);               // 자재명
            grdMaterial.View.AddTextBoxColumn("MATERIALLOTID", 130);                   // 자재LOT
            grdMaterial.View.AddTextBoxColumn("SERIALNO", 100);                        // SERIAL 번호
            grdMaterial.View.AddTextBoxColumn("GOODQTY", 50);                          // 양품
            grdMaterial.View.AddTextBoxColumn("BADQTY", 50);                           // 불량품
            grdMaterial.View.AddTextBoxColumn("DESCRIPTION", 100).SetLabel("COMMENT"); //특이사항
            grdMaterial.View.AddTextBoxColumn("CUSTOMERNAME", 120).SetLabel("VENDOR");            //자재거래처명
            grdMaterial.View.PopulateColumns();
        }
        #endregion

        #region 검색
        //// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();
            var values = Conditions.GetValues();
            DataTable dtWorkorder = await QueryAsync("GetProcessWorkorderInfoByLotId", "00001", values);
            if (dtWorkorder.Rows.Count > 0)
            {
                specDefIdVersion = dtWorkorder.Rows[0]["SPECDEFIDVERSION"].ToString();
                grdResult.View.ClearDatas();
                LoadWorkorder(dtWorkorder);
                LoadSubSegment();
                LoadMaterial();                
            }
            else
            {
                ShowMessage("NoSelectData");
            }
        }

        // 작업지시 정보 표시
        private void LoadWorkorder(DataTable dt)
        {
            this.txtWorkOrdrId.EditValue = dt.Rows[0]["WORKORDERID"].ToString();
            this.txtProductName.EditValue = dt.Rows[0]["PRODUCTDEFNAME"].ToString();
            this.txtModel.EditValue = dt.Rows[0]["MODEL"].ToString();
            this.txtWorkOrderDate.EditValue = ((DateTime)dt.Rows[0]["WORKORDERDATE"]).ToString("yyyy-MM-dd");
            this.txtOrderQty.EditValue = ((decimal)dt.Rows[0]["ORDERQTY"]).ToString("N0");
            this.txtLot.EditValue = dt.Rows[0]["LOTID"].ToString();
            this.txtQty.EditValue = ((decimal)dt.Rows[0]["QTY"]).ToString("N0");
            this.txtPlanEndTime.EditValue = ((DateTime)dt.Rows[0]["PLANENDTIME"]).ToString("yyyy-MM-dd");
           // this.txtProductDefId.EditValue = dt.Rows[0]["PRODUCTDEFID"].ToString();
            this.txtProductDefId.EditValue = dt.Rows[0]["PARTNUMBER"].ToString();
            this.txtItemStandard.EditValue = dt.Rows[0]["ITEMSTANDARD"].ToString();
            this.txtFinished.EditValue = dt.Rows[0]["ISFINISHED"].ToString();
            this.txtSpecDefId.EditValue = $"{dt.Rows[0]["SPECDEFID"].ToString()} ({dt.Rows[0]["SPECDEFIDVERSION"].ToString()})";
            this.lotCreatedQty = (decimal)dt.Rows[0]["CREATEDQTY"];
        }

        private void ClearWorkorder()
        {
            this.txtWorkOrdrId.EditValue = string.Empty;
            this.txtProductName.EditValue = string.Empty;
            this.txtModel.EditValue = string.Empty;
            this.txtWorkOrderDate.EditValue = string.Empty;
            this.txtOrderQty.EditValue = string.Empty;
            this.txtLot.EditValue = string.Empty;
            this.txtQty.EditValue = string.Empty;
            this.txtPlanEndTime.EditValue = string.Empty;
            this.txtProductDefId.EditValue = string.Empty;
            this.txtItemStandard.EditValue = string.Empty;
            this.txtFinished.EditValue = string.Empty;
            this.txtSpecDefId.EditValue = string.Empty;
            this.lotCreatedQty = 0;
        }

        // 세부공정 목록 조회
        private void LoadSubSegment()
        {
            var param = new Dictionary<string, object>()
            {
                { "P_LOTID", txtLot.EditValue.ToString() }
                , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
                , { "P_SPECDEFIDVERSION" , specDefIdVersion }
            };
            grdSubSegment.DataSource = SqlExecuter.Query("GetSubProcessInfoByLotId", "00001", param);
        }

        // 투입 자재 정보 조회
        private void LoadMaterial()
        {
            var param = new Dictionary<string, object>()
            {
                { "P_LOTID", txtLot.EditValue.ToString() }
                , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
                , { "DBLINKNAME", CommonFunction.DbLinkName}
            };
            if (txtFinished.Text == "N")
            {
                grdMaterial.DataSource = SqlExecuter.Query("GetMachiningInsertMaterialInfo", "00003", param);
            }
            else
            {
                grdMaterial.DataSource = SqlExecuter.Query("GetMachiningInsertMaterialInfo", "00002", param);
            }
        }
        #endregion

        #region ToolBar
        /// <summary>
        /// 자재투입을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;
            switch (btn.Name.ToString())
            {
                case TOOLBAR_INPUTMATERIAL: // 자재투입
                    // TODO : LOT 조회없이 버튼 누르면 LOT을 먼저 선택해 달라고 메세지 팝업
                    new InsertMaterialPopup(txtLot.EditValue.ToString(), txtWorkOrdrId.EditValue.ToString(), false).ShowDialog(this);
                    LoadMaterial();
                    break;
                case TOOLBAR_PROCESSRESULT: // 공정실적
                    ShowProcessResultPopup();
                    break;
                case TOOLBAR_CHECKRESULT:   // 검사실적
                    ShowCheckResultPopup();
                    break;
                case TOOLBAR_RESULTSAVE:    // 실적저장
                    if (IsMaterialNotEnough(txtLot.Text.Trim()))
                    {
                        // 자재가 부족합니다. 계속 진행하시겠습니까?
                        if (MSGBox.Show(MessageBoxType.Question, "MaterialIsNotEnough", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                    // 완료보고를 하시겠습니까?
                    if (MSGBox.Show(MessageBoxType.Question, "DoYouWantToFinishLot", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                    MessageWorker messageWorker = new MessageWorker("DispatchAssy");
                    messageWorker.SetBody(new MessageBody()
                    {
                        { "lotid", txtLot.Text.Trim() }
                    });
                    var saveResult = messageWorker.Execute<DataTable>();
                    DataTable resultData = saveResult.GetResultSet();

                    // 화면 클리어
                    ClearWorkorder();
                    grdSubSegment.View.ClearDatas();
                    grdResult.View.ClearDatas();
                    grdMaterial.View.ClearDatas();

                    ShowMessage("ResponseCompletion");

                    foreach (DataRow each in resultData.Rows)
                    {
                        CommonFunction.PrintLotLabel(each["LOTID"].ToString());
                    }
                    break;
                case TOOLBAR_TERMINATELOT:
                    // LOT을 폐기 하시겠습니까?
                    if (MSGBox.Show(MessageBoxType.Question, "DoYouWantToTerminateLot", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                    MessageWorker terminateWorker = new MessageWorker("TerminateLotOfCanceledWorkorder");
                    terminateWorker.SetBody(new MessageBody()
                    {
                        { "lotid", txtLot.Text.Trim() }
                    });
                    terminateWorker.Execute();

                    MessageWorker CancleLotWorker = new MessageWorker("CancelCreateLot");
                    CancleLotWorker.SetBody(new MessageBody()
                    {
                        { "EnterpriseId", UserInfo.Current.Enterprise },
                        { "PlantId", UserInfo.Current.Plant },
                        { "UserId", UserInfo.Current.Id },
                        { "Comment", "AssemblyResult Lot Terminate" },
                        { "LotId", txtLot.Text.Trim() }
                    });
                    CancleLotWorker.Execute();

                    // 화면 클리어
                    ClearWorkorder();
                    grdSubSegment.View.ClearDatas();
                    grdResult.View.ClearDatas();
                    grdMaterial.View.ClearDatas();

                    ShowMessage("ResponseCompletion");
                    break;
                case PRINT_PRODUCT_LABEL:
                    if (txtFinished.Text == "Y")
                    {
                        CommonFunction.PrintProductLabel(txtLot.Text);
                    }
                    else if(txtFinished.Text == "N")
                    {
                        // 완료상태 Lot No.가 아닙니다.
                        throw MessageException.Create("NotFinishedLotNo");
                    }
                    break;
            }
        }

        // 공정실적 팝업
        private void ShowProcessResultPopup()
        {
            DataRow segRow = grdSubSegment.View.GetFocusedDataRow();
            if (segRow == null || txtFinished.Text == "Y"
                || segRow["TRACKINTIME"] == DBNull.Value || string.IsNullOrEmpty(segRow["TRACKINTIME"].ToString()))
            {
                return;
            }
            var param = new Dictionary<string, object>()
            {
                { "P_PROCESSSEGMENTID", segRow["PROCESSSEGMENTID"].ToString() }
                , { "P_SUBPROCESSSEGMENTID", segRow["SUBPROCESSSEGMENTID"].ToString() }
                , { "P_SUBPROCESSSEGMENTNAME", segRow["SUBPROCESSSEGMENTNAME"].ToString() }
                , { "P_SPECID", segRow["SPECDEFID"].ToString() }
                , { "P_LOTID", segRow["LOTID"].ToString() }
                , { "P_LOTQTY", this.txtQty.EditValue.ToString() }
                , { "P_LOTCREATEDQTY", this.lotCreatedQty }
                , { "P_PRODUCTNAME", this.txtProductName.EditValue.ToString() }
                , { "P_MODELNAME", this.txtModel.EditValue.ToString() }
                , { "P_LANGUAGETYPE", UserInfo.Current.LanguageType }
                , { "P_ISMEASURE", "N" }
                , { "P_SPECDEFIDVERSION" , specDefIdVersion } 
            };
            DialogResult result = new CheckMeasureNPopup(param).ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadResult();
            }
        }

        // 검사실적 팝업
        private void ShowCheckResultPopup()
        {
            DataRow segRow = grdSubSegment.View.GetFocusedDataRow();
            if (segRow == null || txtFinished.Text == "Y"
                || segRow["TRACKINTIME"] == DBNull.Value || string.IsNullOrEmpty(segRow["TRACKINTIME"].ToString()))
            {
                return;
            }
            var param = new Dictionary<string, object>()
            {
                { "P_PROCESSSEGMENTID", segRow["PROCESSSEGMENTID"].ToString() }
                , { "P_SUBPROCESSSEGMENTID", segRow["SUBPROCESSSEGMENTID"].ToString() }
                , { "P_SUBPROCESSSEGMENTNAME", segRow["SUBPROCESSSEGMENTNAME"].ToString() }
                , { "P_SPECID", segRow["SPECDEFID"].ToString() }
                , { "P_LOTID", segRow["LOTID"].ToString() }
                , { "P_LOTQTY", this.txtQty.EditValue.ToString() }
                , { "P_LOTCREATEDQTY", this.lotCreatedQty }
                , { "P_PRODUCTNAME", this.txtProductName.EditValue.ToString() }
                , { "P_MODELNAME", this.txtModel.EditValue.ToString() }
                , { "P_LANGUAGETYPE", UserInfo.Current.LanguageType }
                , { "P_ISFINISHED", segRow["ISFINISHED"].ToString() }
                , { "P_SPECDEFIDVERSION" , specDefIdVersion }
            };
            DialogResult result = new CheckMeasureYPopup(param).ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadResult();
            }
        }

        // BOM 수량만큼 자재투입을 했는지 확인
        private bool IsMaterialNotEnough(string lotId)
        {
            return IsTrackingMaterialNotEnough(lotId) || IsUnTrackingMaterialNotEnough(lotId);
        }

        private bool IsTrackingMaterialNotEnough(string lotId)
        {
            var param = new Dictionary<string, object>()
            {
                { "LOTID", lotId }
            };
            DataTable dt = SqlExecuter.Query("GetIsMaterialEnough", "00001", param);
            return int.Parse(dt.Rows[0]["NOTENOUGH"].ToString()) > 0;
        }

        private bool IsUnTrackingMaterialNotEnough(string lotId)
        {
            var param = new Dictionary<string, object>()
            {
                { "LOTID", lotId }
            };
            DataTable dt = SqlExecuter.Query("GetIsUnTrackingMaterialEnough", "00001", param);
            return int.Parse(dt.Rows[0]["NOTENOUGH"].ToString()) > 0;
        }
        #endregion

        #region Event
        private void InitializeEvent()
        {
            btnWorkStart.Click += btnWorkStart_Click;
            btnWorkEnd.Click += btnWorkEnd_Click;
            grdSubSegment.View.FocusedRowChanged += GrdSubSegment_FocusedRowChange;
            grdResult.View.RowCellStyle += GrdResult_RowCellStyle;

            //공통코드 내 SystemOption 작업종료시간수동입력여부에 따라 화면구성 달라짐. ('21.05.07 scmo)
            DataTable dt = new SqlQuery("GetManualInputYn", "00001", $"CODECLASSID=SystemOption", $"CODEID=WorkTimeManualInput").Execute();
            if (dt.Rows[0]["YNVALUE"].ToString() == "N")
            {
                grdSubSegment.View.SetIsReadOnly(true);
            }
            else
            {
                grdSubSegment.View.CustomDrawCell += GrdSubSegment_CustomDrawCell;
                grdSubSegment.View.ShowingEditor += GrdSubSegment_ShowingEditor;
            }
        }

        // 작업시작 버튼
        private void btnWorkStart_Click(object sender, EventArgs e)
        {
            WorkStart();
        }

        // 작업시작
        private void WorkStart()
        {
            DataRow row = this.grdSubSegment.View.GetFocusedDataRow();
            if (row == null)
            {
                // 선택된 세부공정이 없습니다.
                throw MessageException.Create("SubProcessNotSelect");
            }
            if (row["TRACKINTIME"] != DBNull.Value && !string.IsNullOrEmpty(row["TRACKINTIME"].ToString()))
            {
                // 이미 작업이 시작된 세부공정입니다.
                throw MessageException.Create("SubProcessResultAlreadyStarted");
            }
            var param = new Dictionary<string, object>()
            {
                { "P_LOT", row["LOTID"].ToString() }
                , { "P_PROCESSSEGMENTID", row["PROCESSSEGMENTID"].ToString() }
                , { "P_SUBPROCESSID", row["SUBPROCESSSEGMENTID"].ToString() }
                , { "P_SUBPROCESSNAME", row["SUBPROCESSSEGMENTNAME"].ToString() }
                , { "P_AREAID", row["AREAID"].ToString() }
                , { "P_SPECDEFIDVERSION", specDefIdVersion }
            };
            DialogResult result = new WorkerRegPopup(param).ShowDialog();
            if(result == DialogResult.OK)
            {
                string subSegmentId = row["SUBPROCESSSEGMENTID"].ToString();
                LoadSubSegment();
                grdSubSegment.View.FocusAndSelect("SUBPROCESSSEGMENTID", subSegmentId);
            }
        }

        // 작업종료 버튼
        private void btnWorkEnd_Click(object sender, EventArgs e)
        {
            grdSubSegment.View.PostEditor();
            grdSubSegment.View.UpdateCurrentRow();
            DataRow subSegRow = this.grdSubSegment.View.GetFocusedDataRow();
            if (subSegRow == null)
            {
                // 선택된 세부공정이 없습니다.
                throw MessageException.Create("SubProcessNotSelect");
            }
            // 작업종료
            string subSegmentId = subSegRow["SUBPROCESSSEGMENTID"].ToString();
            MessageWorker trackOutWorker = new MessageWorker("SubTrackOutAssy");
            trackOutWorker.SetBody(new MessageBody()
            {
                { "lotid", subSegRow["LOTID"].ToString() }
                , { "subprocesssegmentid", subSegmentId }
                , { "worktime", subSegRow["WORKTIME"] }
                , { "comment", subSegRow["DESCRIPTION"] }
            });
            trackOutWorker.Execute();
            // 작업지시정보 재조회
            var values = Conditions.GetValues();
            DataTable dtWorkorder = SqlExecuter.Query("GetProcessWorkorderInfoByLotId", "00001", values);
            if (dtWorkorder.Rows.Count > 0)
            {
                LoadWorkorder(dtWorkorder);
            }
            LoadSubSegment();   // 세부공정 재조회
            grdSubSegment.View.FocusAndSelect("SUBPROCESSSEGMENTID", subSegmentId);

            // 다음 세부공정 작업시작
            string nextSubSegmentId = NextSubSegmentId(subSegmentId);
            // 다음 세부공정을 바로 진행하시겠습니까?
            if (nextSubSegmentId != null
                && MSGBox.Show(MessageBoxType.Question, "StartNextSubProcess", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                grdSubSegment.View.FocusAndSelect("SUBPROCESSSEGMENTID", nextSubSegmentId);
                WorkStart();
            }
        }

        // 다음 세부공정
        private string NextSubSegmentId(string subSegmentId)
        {
            bool found = false;
            DataTable dt = grdSubSegment.DataSource as DataTable;
            foreach(DataRow each in dt.Rows)
            {
                if(found)
                {
                    if (each["TRACKINTIME"] != DBNull.Value)
                    {
                        continue;
                    }
                    else
                    {
                        return each["SUBPROCESSSEGMENTID"].ToString();
                    }
                }
                else  if(each["SUBPROCESSSEGMENTID"].ToString() == subSegmentId)
                {
                    found = true;
                }
            }
            return null;
        }

        // 세부공정 포커스 행 변경 시 검사실적 재조회
        private void GrdSubSegment_FocusedRowChange(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadResult();
        }

        // 검사실적 조회
        private void LoadResult()
        {
            DataRow row = this.grdSubSegment.View.GetFocusedDataRow();
            if (row != null)
            {
                var param = new Dictionary<string, object>()
                {
                    { "P_SUBPROCESSSEGMENTID", row["SUBPROCESSSEGMENTID"].ToString() }
                    , { "P_LOTID", txtLot.Text }
                    , { "P_LOTCREATEDQTY", this.lotCreatedQty }
                    , { "P_LANGUAGETYPE", UserInfo.Current.LanguageType }
                    , { "P_SPECDEFIDVERSION", specDefIdVersion }
                };
                grdResult.DataSource = SqlExecuter.Query("GetResultBySubProcess", "00001", param);
            }
            else
            {
                grdResult.View.ClearDatas();
            }
        }

        // 세부공정 그리드 값 입력 가능한 셀 다른색상으로 표시
        private void GrdSubSegment_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if((e.Column.FieldName == "WORKTIME" || e.Column.FieldName == "DESCRIPTION")
                && grdSubSegment.View.GetRowCellValue(e.RowHandle, "ISFINISHED").ToString() != "Y")
            {
                e.Appearance.ForeColor = System.Drawing.Color.Black;
                e.Appearance.BackColor = System.Drawing.Color.LightYellow;
            }
        }

        // 세부공정 그리드 작업확정된 행의 값 수정 방지
        private void GrdSubSegment_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataRow row = grdSubSegment.View.GetFocusedDataRow();
            if(row != null && row["ISFINISHED"].ToString() == "Y")
            {
                e.Cancel = true;
            }
        }

        // 검사실적 그리드 입력타입 별 정렬(STRING : 좌측정렬, FLOAT : 우측정렬)
        private void GrdResult_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "MEASUREVALUE")
            {
                if (view.GetRowCellValue(e.RowHandle, "ISMEASURE").ToString() == "Y")
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                else
                {
                    switch (view.GetRowCellValue(e.RowHandle, "INPUTTYPE").ToString())
                    {
                        case "STRING":
                            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                            break;
                        case "FLOAT":
                            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            break;
                        case "INT":
                            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            break;
                        case "ComboBox":
                            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                            break;
                        case "CheckBox":
                            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
