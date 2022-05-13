#region using
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
#endregion

namespace Micube.SmartMES.Process
{
    public partial class CheckMeasureYPopup : SmartPopupBaseForm
    {
        // 입력값 구분
        private const string INPUTTYPE_STRING = "STRING";
        private const string INPUTTYPE_FLOAT = "FLOAT";
        private const string INPUTTYPE_INT = "INT";
        private const string INPUTTYPE_COMBOBOX = "ComboBox";
        private const string INPUTTYPE_CHECKBOX = "CheckBox";

        // 스펙 타입
        private const string SPECTYPE_BOTH = "BOTH";
        private const string SPECTYPE_LOWER = "LOWER";
        private const string SPECTYPE_UPPER = "UPPER";

        // 에디터
        private RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
        private RepositoryItemSpinEdit spinEdit = new RepositoryItemSpinEdit();
        private RepositoryItemCheckEdit checkEdit = new RepositoryItemCheckEdit();
        private Dictionary<string, RepositoryItemLookUpEdit> lookUpEdits = new Dictionary<string, RepositoryItemLookUpEdit>();

        // 변수
        private DataTable inspParameters;   // 검사항목
        private Dictionary<string, object> param;

        private string lotId;
        private string productName;
        private string subSegmentId;
        private string subSegmentName;
        private string modelName;
        private bool isFinished;
        private string specDefIdVersion;

        private string firstColumn;
        private string lastColumn;

        public CheckMeasureYPopup(Dictionary<string, object> param)
        {
            InitializeComponent();
            InitializeEvent();
            this.param = param;
            checkEdit.ValueChecked = "Y";
            checkEdit.ValueUnchecked = "";
            this.isFinished = param["P_ISFINISHED"].ToString() == "Y";
        }

        // 파라미터 초기화
        private void InitializeParameter(Dictionary<string, object> param)
        {
            // 파라미터
            lotId = param["P_LOTID"].ToString();
            productName = param["P_PRODUCTNAME"].ToString();
            subSegmentId = param["P_SUBPROCESSSEGMENTID"].ToString();
            subSegmentName = param["P_SUBPROCESSSEGMENTNAME"].ToString();
            modelName = param["P_MODELNAME"].ToString();
            specDefIdVersion = param["P_SPECDEFIDVERSION"].ToString();

            // 콘트롤
            txtLotNum.EditValue = lotId;               // LOTID
            txtProductName.EditValue = productName;    // 품목명
            txtSubProcess.EditValue = subSegmentName;  // 세부공정명
            txtModel.EditValue = modelName;            // 기종
        }

        // 검사실적 항목정보 조회(검사항목 별 입력구분, 소수점 자리수)
        private void LoadInspParameters(Dictionary<string, object> param)
        {
            var queryParam = new Dictionary<string, object>()
            {
                { "SPECDEFID", param["P_SPECID"].ToString() }
                , { "SUBPROCESSSEGMENTID", subSegmentId }
                , { "SPECDEFIDVERSION", specDefIdVersion }

            };
            this.inspParameters = SqlExecuter.Query("GetSubSegmentParameter", "00001", queryParam);
        }

        // 검사실적 조회 및 그리드 컬럼 초기화
        private void LoadResult(Dictionary<string, object> param)
        {
            // 검사실적 조회
            var queryParam = new Dictionary<string, object>()
            {
                { "LOTID", lotId }
                , { "PROCESSSEGMENTID", param["P_PROCESSSEGMENTID"].ToString() }
                , { "SUBPROCESSSEGMENTID", subSegmentId }
                , { "CREATEDQTY", param["P_LOTCREATEDQTY"].ToString() }
            };
            DataTable result;
            try
            {
                result = SqlExecuter.Query("GetInspectionResultSheet", "00001", queryParam);
            }
            catch // NOTE : 조회 행수가 0이면 예외 발생
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // 그리드 컬럼 초기화
            grdResult.GridButtonItem = GridButtonItem.None;
            grdResult.View.OptionsNavigation.EnterMoveNextColumn = true;

            foreach (DataColumn each in result.Columns)
            {
                if (each.ColumnName == "SEQ")   // No 컬럼
                {
                    grdResult.View.AddTextBoxColumn(each.ColumnName, 40);
                }
                else if (each.ColumnName == "ISDEFECT")  // 불량여부
                {
                    grdResult.View.AddCheckBoxColumn(each.ColumnName, 60);
                }
                else if (each.ColumnName == "ISSCRAP")  // 폐기여부 (값이 Y이면 ISDEFECT=Y 고정)
                {
                    // PASS
                }
                else // 검사항목 컬럼
                {
                    grdResult.View.AddTextBoxColumn(each.ColumnName, 150);
                    DataRow parameter = GetInspParameter(each.ColumnName);
                    if (parameter["INPUTTYPE"].ToString() == INPUTTYPE_COMBOBOX)    // 검사항목의 입력타입이 콤보박스면
                    {
                        AddLookUpEdit(each.ColumnName, parameter["CODECLASSID"].ToString());
                    }
                    if(this.firstColumn == null)
                    {
                        this.firstColumn = each.ColumnName;
                    }
                }
            }
            grdResult.View.PopulateColumns();
            grdResult.DataSource = result;

            grdResult.View.FocusedColumn = grdResult.View.Columns[this.firstColumn];
            grdResult.View.FocusedRowHandle = 1;
            this.lastColumn = result.Columns[result.Columns.Count - 1].ColumnName;
        }

        // LookUpEdit 초기화
        private void AddLookUpEdit(string fieldName, string codeClassId)
        {
            var param = new Dictionary<string, object>()
            {
                { "CODECLASSID", codeClassId }
                , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };
            var lookUpEdit = new RepositoryItemLookUpEdit();
            lookUpEdit.ValueMember = "CODEID";
            lookUpEdit.DisplayMember = "CODENAME";
            lookUpEdit.ShowHeader = false;
            lookUpEdit.NullText = string.Empty;
            lookUpEdit.DataSource = SqlExecuter.Query("GetCodeList", "00001", param);
            lookUpEdit.PopulateColumns();
            lookUpEdit.Columns["CODEID"].Visible = false;
            lookUpEdit.Columns["DISPLAYSEQUENCE"].Visible = false;
            this.lookUpEdits.Add(fieldName, lookUpEdit);
        }

        private string GetInputType(string parameterId)
        {
            return GetInspParameter(parameterId)["INPUTTYPE"].ToString();
        }

        private string GetSpecType(string parameterId)
        {
            return GetInspParameter(parameterId)["SPECTYPE"].ToString();
        }

        private string GetIsSpecForce(string parameterId)
        {
            return GetInspParameter(parameterId)["ISSPECFORCE"].ToString();
        }

        private decimal GetLsl(string parameterId)
        {
            return Format.GetDecimal(GetInspParameter(parameterId)["LSL"].ToString());
        }

        private decimal GetUsl(string parameterId)
        {
            return Format.GetDecimal(GetInspParameter(parameterId)["USL"].ToString());
        }

        private decimal GetDecimalPlace(string parameterId)
        {
            object obj = GetInspParameter(parameterId)["DECIMALPLACE"];
            return (obj == DBNull.Value) ? 0 : (decimal)obj;
        }

        private DataRow GetInspParameter(string parameterId)
        {
            foreach (DataRow each in inspParameters.Rows)
            {
                if (each["PARAMETERID"].ToString() == parameterId)
                {
                    return each;
                }
            }
            return null;
        }

        #region Event
        // 이벤트 초기화
        private void InitializeEvent()
        {
            this.Load += CheckMeasureYPopup_Load;
            btnSave.Click += btnSave_Click;
            btnClose.Click += btnClose_Click;
            grdResult.View.ShowingEditor += View_ShowingEditor;
            grdResult.View.CustomDrawCell += View_CustomDrawCell;
            grdResult.View.CellValueChanged += View_CellValueChanged;
            grdResult.View.RowCellStyle += View_RowCellStyle;
            grdResult.View.CustomRowCellEdit += View_CustomRowCellEdit;
            grdResult.View.ValidatingEditor += View_ValidatingEditor;
            grdResult.View.InvalidValueException += View_InvalidValueException;
            this.FormClosing += CheckMeasureYPopup_FormClosing;
            grdResult.View.RowStyle += View_RowStyle;
            grdResult.View.KeyDown += View_KeyDown;
            grdResult.View.RowCellClick += View_RowCellClick;
            grdResult.View.AddingNewRow += View_AddingNewRow;
        }

        private void CheckMeasureYPopup_Load(object sender, EventArgs e)
        {
            this.ActiveControl = grdResult;
            InitializeParameter(this.param);
            LoadInspParameters(this.param);
            LoadResult(this.param);
        }

        // 저장 버튼
        private void btnSave_Click(Object sender, EventArgs e)
        {
            grdResult.View.PostEditor();
            grdResult.View.UpdateCurrentRow();

            DataTable inspValues = grdResult.DataSource as DataTable;
            if (inspValues.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
            MessageWorker messageWorker = new MessageWorker("RegisterSubProcessInspResultPivot");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid",  lotId }
                , { "subprocesssegmentid", subSegmentId }
                , { "list", inspValues }
                , { "specdefidversion", specDefIdVersion }
            });
            messageWorker.Execute();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        // 닫기 버튼
        private void btnClose_Click(Object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        // No 컬럼, 입력값범위 행, 불량 행 수정금지
        private void View_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataRow row = grdResult.View.GetFocusedDataRow();
            if (row == null)
            {
                return;
            }
            if (row["SEQ"] == DBNull.Value || grdResult.View.FocusedColumn.FieldName == "SEQ"
                || (grdResult.View.FocusedColumn.FieldName != "ISDEFECT" && (bool)row["ISDEFECT"]))
            {
                e.Cancel = true;
            }
        }

        // 입력값범위 행 색상변경 및 스펙 벗어난 셀 배경색상 변경
        private void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.GetRowCellValue(e.RowHandle, "SEQ") == DBNull.Value)
            {
                e.Appearance.BackColor = System.Drawing.Color.Lavender;
                return;
            }
            else if (e.Column.FieldName == "ISSCRAP" || e.Column.FieldName == "ISDEFECT" || e.Column.FieldName == "SEQ")
            {
                return;
            }

            string inputType = GetInputType(e.Column.FieldName);
            string specType = GetSpecType(e.Column.FieldName);
            string isSpecForce = GetIsSpecForce(e.Column.FieldName);

            if (inputType == INPUTTYPE_FLOAT || inputType == INPUTTYPE_INT)
            {
                decimal val;
                if (e.CellValue != DBNull.Value && decimal.TryParse(e.CellValue.ToString(), out val))
                {
                    decimal min = GetLsl(e.Column.FieldName);
                    decimal max = GetUsl(e.Column.FieldName);

                    if ((specType == SPECTYPE_BOTH && (min > val || max < val))
                        || (specType == SPECTYPE_UPPER && (max < val))
                        || (specType == SPECTYPE_LOWER && (min > val))) // 스펙 아웃
                    {
                        e.Appearance.ForeColor = System.Drawing.Color.Black;
                        e.Appearance.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
        }

        // 입력된 값을 형식에 맞게 편집(소수점 자리수 등) 및 상/하한값 적용
        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "ISSCRAP" || e.Column.FieldName == "ISDEFECT")
            {
                (grdResult.DataSource as DataTable).AcceptChanges();
                return;
            }

            string inputType = GetInputType(e.Column.FieldName);
            string specType = GetSpecType(e.Column.FieldName);
            string isSpecForce = GetIsSpecForce(e.Column.FieldName);

            if (inputType == INPUTTYPE_FLOAT || inputType == INPUTTYPE_INT)
            {
                grdResult.View.CellValueChanged -= View_CellValueChanged;
                decimal val;
                if (e.Value != DBNull.Value && decimal.TryParse(e.Value.ToString(), out val))
                {
                    decimal min = GetLsl(e.Column.FieldName);
                    decimal max = GetUsl(e.Column.FieldName);

                    if ((specType == SPECTYPE_BOTH && (min > val || max < val))
                        || (specType == SPECTYPE_UPPER && (max < val))
                        || (specType == SPECTYPE_LOWER && (min > val))) // 스펙 아웃
                    {
                        ShowMessage("MeasureValueIsOutOfSpec");
                        if (isSpecForce == "Y") // 스펙 강제
                        {
                            view.SetRowCellValue(e.RowHandle, e.Column.FieldName, string.Empty);
                        }
                        else
                        {
                            if (inputType == INPUTTYPE_FLOAT)
                            {
                                view.SetRowCellValue(e.RowHandle, e.Column.FieldName, val.ToString(string.Format("N{0}", GetDecimalPlace(e.Column.FieldName))));
                            }
                            else
                            {
                                view.SetRowCellValue(e.RowHandle, e.Column.FieldName, val.ToString("N0"));
                            }
                        }
                    }
                    else
                    {
                        if (inputType == INPUTTYPE_FLOAT)
                        {
                            view.SetRowCellValue(e.RowHandle, e.Column.FieldName, val.ToString(string.Format("N{0}", GetDecimalPlace(e.Column.FieldName))));
                        }
                        else
                        {
                            view.SetRowCellValue(e.RowHandle, e.Column.FieldName, val.ToString("N0"));
                        }
                    }
                }
                else
                {
                    view.SetRowCellValue(e.RowHandle, e.Column.FieldName, string.Empty);
                }
                grdResult.View.CellValueChanged += View_CellValueChanged;
            }
            (grdResult.DataSource as DataTable).AcceptChanges();
        }

        // 측정값 컬럼의 텍스트 정렬을 INPUTTYPE 별로 설정
        private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "ISSCRAP" || e.Column.FieldName == "ISDEFECT")
            {
                return;
            }
            else if (e.Column.FieldName == "SEQ")
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }
            else if (view.GetRowCellValue(e.RowHandle, "SEQ") == DBNull.Value)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            else if (GetInspParameter(e.Column.FieldName)["INPUTTYPE"].ToString() == INPUTTYPE_STRING)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            }
            else if (GetInspParameter(e.Column.FieldName)["INPUTTYPE"].ToString() == INPUTTYPE_FLOAT)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }
            else if (GetInspParameter(e.Column.FieldName)["INPUTTYPE"].ToString() == INPUTTYPE_INT)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }
        }

        // 검사항목 입력구분에 따라 에디터 변경
        private void View_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "SEQ" || grdResult.View.GetRowCellValue(e.RowHandle, "SEQ") == DBNull.Value
                || e.Column.FieldName == "ISSCRAP" || e.Column.FieldName == "ISDEFECT")
            {
                return;
            }

            DataRow parameter = GetInspParameter(e.Column.FieldName);
            switch (parameter["INPUTTYPE"].ToString())
            {
                case INPUTTYPE_STRING:
                    e.RepositoryItem = textEdit;
                    break;
                case INPUTTYPE_FLOAT:
                    e.RepositoryItem = spinEdit;
                    break;
                case INPUTTYPE_CHECKBOX:
                    e.RepositoryItem = checkEdit;
                    break;
                case INPUTTYPE_COMBOBOX:
                    e.RepositoryItem = lookUpEdits[e.Column.FieldName];
                    break;
            }
        }

        private void CheckMeasureYPopup_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                // 정말 종료하시겠습니까? 저장하지 않은 데이터는 사라집니다.
                if (MSGBox.Show(MessageBoxType.Warning, "CloseWithoutSave", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        // 이전 세부공정에서 불량처리된 SEQ의 불량체크 해제 방지
        private void View_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            if (column.FieldName != "ISDEFECT")
            {
                return;
            }
            if ((bool)view.GetRowCellValue(view.FocusedRowHandle, "ISSCRAP") || this.isFinished)
            {
                e.Valid = false;
            }
        }

        // 이전 세부공정에서 불량처리된 SEQ의 불량체크 해제 방지
        private void View_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (view == null)
            {
                return;
            }
            e.ExceptionMode = ExceptionMode.Ignore;
            view.HideEditor();
        }

        // 불량체크 상태별 색상변경
        private void View_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (!view.IsValidRowHandle(e.RowHandle) || view.GetRowCellValue(e.RowHandle, "SEQ") == DBNull.Value)
            {
                return;
            }
            if((bool)view.GetRowCellValue(e.RowHandle, "ISSCRAP"))
            {
                e.Appearance.BackColor = System.Drawing.Color.Orange;
                e.HighPriority = true;
            }
            else if ((bool)view.GetRowCellValue(e.RowHandle, "ISDEFECT"))
            {
                e.Appearance.BackColor = System.Drawing.Color.LightCoral;
                e.HighPriority = true;
            }
        }

        // 마지막 컬럼에서 엔터 입력 시 다음행의 첫번째 검사항목으로 포커스 이동
        private void View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (grdResult.View.FocusedColumn.FieldName == lastColumn
                    && grdResult.View.FocusedRowHandle < grdResult.View.RowCount - 1)
                {
                    grdResult.View.FocusedColumn = grdResult.View.Columns[this.firstColumn];
                    grdResult.View.FocusedRowHandle++;
                }
            }
        }

        // 포커스 되지 않은 체크박스 한번만 클릭해도 체크상태 변경
        private void View_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "ISSCRAP" || e.Column.FieldName == "ISDEFECT")
            {
                return;
            }
            else if (view.GetRowCellValue(e.RowHandle, "SEQ") == DBNull.Value)
            {
                return;
            }
            DataRow parameter = GetInspParameter(e.Column.FieldName);
            if (parameter["INPUTTYPE"].ToString() == INPUTTYPE_CHECKBOX)
            {
                DataRow row = grdResult.View.GetFocusedDataRow();
                if (view.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString() == "")
                {
                    view.SetRowCellValue(e.RowHandle, e.Column.FieldName, "Y");
                }
                else
                {
                    view.SetRowCellValue(e.RowHandle, e.Column.FieldName, "");
                }
                e.Handled = true;
            }
        }

        // Ctrl+V 에 의해 신규 행 생성되는 것 방지
        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            args.IsCancel = true;
        }
        #endregion
    }
}
