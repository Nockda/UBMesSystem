#region using
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
    public partial class CheckMeasureNPopup : SmartPopupBaseForm
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

        // 컬럼명
        private const string COLUMN_MEASUREVALUE = "MEASUREVALUE";
        private const string COLUMN_INPUTTYPE = "INPUTTYPE";
        private const string COLUMN_DECIMALPLACE = "DECIMALPLACE";
        private const string COLUMN_SPECTYPE = "SPECTYPE";
        private const string COLUMN_ISSPECFORCE = "ISSPECFORCE";

        // 그리드 셀 에디터
        private RepositoryItemSpinEdit spinEdit = new RepositoryItemSpinEdit();
        private RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
        private RepositoryItemCheckEdit checkEdit = new RepositoryItemCheckEdit();
        private RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
        private Dictionary<string, RepositoryItemLookUpEdit> lookupEdits = new Dictionary<string, RepositoryItemLookUpEdit>();

        // 변수
        private Dictionary<string, object> param;
        private string lotId;
        private string subSegmentId;
        private string specDefIdVersion;

        public CheckMeasureNPopup(Dictionary<string, object> param)
        { 
            InitializeComponent();
            this.param = param;
            InitializeParameter(this.param);
            InitializeComboEditor();
            InitializeGrid();
            lnitializeEvent();
        }

        // 파라미터 초기화
        private void InitializeParameter(Dictionary<string, object> param)
        {
            lotId = param["P_LOTID"].ToString();
            subSegmentId = param["P_SUBPROCESSSEGMENTID"].ToString();
            specDefIdVersion = param["P_SPECDEFIDVERSION"].ToString();

            DataTable dtText = SqlExecuter.Query("GetSpecSubProcessInfoByPopup", "00001", param);
            this.txtSpecName.EditValue = dtText.Rows[0]["SPECDEFNAME"].ToString();
            this.txtSubProcessName.EditValue = dtText.Rows[0]["PROCESSSEGMENTNAME"].ToString();
        }

        // 초기화
        private void InitializeGrid()
        {
            grdResult.GridButtonItem = GridButtonItem.None;
            grdResult.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdResult.View.OptionsView.RowAutoHeight = true;
            grdResult.View.AddTextBoxColumn("PARAMETERNAME", 300).SetIsReadOnly();                  // 검사항목명
            grdResult.View.AddTextBoxColumn("UNIT", 50).SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();                                                                   // 단위
            grdResult.View.AddTextBoxColumn(COLUMN_MEASUREVALUE, 100);                              // 측정값
            grdResult.View.AddTextBoxColumn("LSL", 60).SetIsReadOnly();                             // 측정값 하한
            grdResult.View.AddTextBoxColumn("USL", 60).SetIsReadOnly();                             // 측정값 상한
            grdResult.View.AddTextBoxColumn("ISSPECFORCE", 60)
                .SetIsReadOnly().SetTextAlignment(TextAlignment.Center);                            // 스펙강제 여부
            grdResult.View.AddTextBoxColumn("ISNOTREQUIRED", 60)
                .SetIsReadOnly().SetTextAlignment(TextAlignment.Center);            // 미필수 여부

            // Hidden 컬럼
            grdResult.View.AddTextBoxColumn("PARAMETERID", 150).SetIsHidden();                      // 검사항목 ID
            grdResult.View.PopulateColumns();
            grdResult.GridControl.RepositoryItems.AddRange(new RepositoryItem[] { spinEdit, textEdit, checkEdit, memoEdit });

            checkEdit.ValueChecked = "Y";
            checkEdit.ValueUnchecked = "";
            memoEdit.ReadOnly = true;
        }

        private void LoadResult(Dictionary<string, object> param)
        {
            grdResult.DataSource = SqlExecuter.Query("GetResultBySubProcess", "00001", param);
            if((grdResult.DataSource as DataTable).Rows.Count == 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            foreach (DataRow each in (grdResult.DataSource as DataTable).Rows)
            {
                if (each[COLUMN_INPUTTYPE].ToString() == INPUTTYPE_CHECKBOX)
                {
                    if (each[COLUMN_MEASUREVALUE].ToString() == "Y")
                    {
                        grdResult.View.CheckRow(grdResult.View.GetRowHandle((grdResult.DataSource as DataTable).Rows.IndexOf(each))
                            , COLUMN_MEASUREVALUE, true);
                    }
                    else
                    {
                        grdResult.View.CheckRow(grdResult.View.GetRowHandle((grdResult.DataSource as DataTable).Rows.IndexOf(each))
                            , COLUMN_MEASUREVALUE, false);
                    }
                }
            }
        }

        private void lnitializeEvent()
        {
            this.Load += CheckMeasureNPopup_Load;
            btnSave.Click += btnSave_Click;
            btnClose.Click += btnClose_Click;
            grdResult.View.CustomDrawCell += View_CustomDrawCell;
            grdResult.View.CustomRowCellEdit += View_CustomRowCellEdit;
            grdResult.View.CustomColumnDisplayText += View_CustomColumnDisplayText;
            grdResult.View.CellValueChanged += View_CellValueChanged;
            grdResult.GridControl.ProcessGridKey += GridControl_ProcessGridKey;
            this.FormClosing += CheckMeasureNPopup_FormClosing;
            grdResult.View.RowCellStyle += View_RowCellStyle;
            grdResult.View.RowCellClick += View_RowCellClick;
            grdResult.View.AddingNewRow += View_AddingNewRow;
        }

        private void CheckMeasureNPopup_Load(object sender, EventArgs e)
        {
            LoadResult(this.param);
        }

        private void InitializeComboEditor()
        {
            var codeClassParam = new Dictionary<string, object>()
            {
                { "P_LOTID", this.lotId }
                , { "P_SUBPROCESSSEGMENTID", this.subSegmentId }
            };
            DataTable codeClassList = SqlExecuter.Query("GetInspParameterComboBox", "00001", codeClassParam);

            foreach(DataRow each in codeClassList.Rows)
            {
                string codeClassId = each["CODECLASSID"].ToString();
                var codeParam = new Dictionary<string, object>()
                {
                    { "CODECLASSID", codeClassId }
                    , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
                };
                DataTable codeList = SqlExecuter.Query("GetCodeList", "00001", codeParam);

                var lookUpEdit = new RepositoryItemLookUpEdit();
                lookUpEdit.ValueMember = "CODEID";
                lookUpEdit.DisplayMember = "CODENAME";
                lookUpEdit.ShowHeader = false;
                lookUpEdit.NullText = string.Empty;
                lookUpEdit.DataSource = codeList;
                lookUpEdit.PopulateColumns();
                lookUpEdit.Columns["CODEID"].Visible = false;
                lookUpEdit.Columns["DISPLAYSEQUENCE"].Visible = false;
                this.lookupEdits.Add(codeClassId, lookUpEdit);
            }
        }

        // 저장 버튼
        private void btnSave_Click(object sender, EventArgs e)
        {
            grdResult.View.PostEditor();
            grdResult.View.UpdateCurrentRow();

            DataTable inspValues = grdResult.DataSource as DataTable;
            if (inspValues.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
            MessageWorker messageWorker = new MessageWorker("RegisterSubProcessInspResult");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", lotId }
                , { "subprocesssegmentid", subSegmentId }
                , { "list", inspValues }
                , { "specdefidversion", specDefIdVersion }
            });
            messageWorker.Execute();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        // 닫기 버튼
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        // 측정값 컬럼의 색상변경
        private void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == COLUMN_MEASUREVALUE)
            {
                string inputType = view.GetRowCellValue(e.RowHandle, COLUMN_INPUTTYPE).ToString();
                string specType = view.GetRowCellValue(e.RowHandle, COLUMN_SPECTYPE).ToString();
                decimal min = Format.GetDecimal(view.GetRowCellValue(e.RowHandle, "LSL").ToString());
                decimal max = Format.GetDecimal(view.GetRowCellValue(e.RowHandle, "USL").ToString());

                if (inputType == INPUTTYPE_FLOAT || inputType == INPUTTYPE_INT)
                {
                    decimal val;
                    if (e.CellValue != DBNull.Value && decimal.TryParse(e.CellValue.ToString(), out val)) /// 숫자 파싱 성공
                    {
                        if ((specType == SPECTYPE_BOTH && (min > val || max < val))
                            || (specType == SPECTYPE_UPPER && (max < val))
                            || (specType == SPECTYPE_LOWER && (min > val))) // 스펙 아웃
                        {
                            e.Appearance.ForeColor = System.Drawing.Color.Black;
                            e.Appearance.BackColor = System.Drawing.Color.PaleVioletRed;
                        }
                        else
                        {
                            e.Appearance.ForeColor = System.Drawing.Color.Black;
                            e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                        }
                    }
                    else
                    {
                        e.Appearance.ForeColor = System.Drawing.Color.Black;
                        e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                    }
                }
                else
                {
                    e.Appearance.ForeColor = System.Drawing.Color.Black;
                    e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                }
            }
        }

        // 측정값 컬럼의 에디터를 INPUTTYPE 별로 설정
        private void View_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == COLUMN_MEASUREVALUE)
            {
                switch(view.GetRowCellValue(e.RowHandle, COLUMN_INPUTTYPE).ToString())
                {
                    case INPUTTYPE_STRING:
                        e.RepositoryItem = textEdit;
                        break;
                    case INPUTTYPE_FLOAT:
                        e.RepositoryItem = spinEdit;
                        break;
                    case INPUTTYPE_INT:
                        e.RepositoryItem = spinEdit;
                        break;
                    case INPUTTYPE_COMBOBOX:
                        if (lookupEdits.ContainsKey(view.GetRowCellValue(e.RowHandle, "CODECLASSID").ToString()))
                        {
                            e.RepositoryItem = this.lookupEdits[view.GetRowCellValue(e.RowHandle, "CODECLASSID").ToString()];
                        }
                        break;
                    case INPUTTYPE_CHECKBOX:
                        e.RepositoryItem = checkEdit;
                        break;
                    default:
                        e.RepositoryItem = textEdit;
                        break;
                }
            }
            else if(e.Column.FieldName == "PARAMETERNAME")
            {
                e.RepositoryItem = memoEdit;
            }
        }

        // 측정값 컬럼의 값 표시형식을 INPUTTYPE 별로 설정
        private void View_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == COLUMN_MEASUREVALUE && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                string inputType = view.GetListSourceRowCellValue(e.ListSourceRowIndex, COLUMN_INPUTTYPE).ToString();
                object decimalPlaceObj = view.GetListSourceRowCellValue(e.ListSourceRowIndex, COLUMN_DECIMALPLACE);
                decimal decimalPlace = (decimalPlaceObj == DBNull.Value) ? 0 : (decimal)decimalPlaceObj;
                switch (inputType)
                {
                    case INPUTTYPE_STRING:
                        e.DisplayText = e.Value.ToString();
                        break;
                    case INPUTTYPE_FLOAT:
                        decimal val;
                        if (e.Value != DBNull.Value && decimal.TryParse(e.Value.ToString(), out val))
                        {
                            e.DisplayText = val.ToString(string.Format("N{0}", decimalPlace));
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                        break;
                    case INPUTTYPE_INT:
                        decimal intVal;
                        if (e.Value != DBNull.Value && decimal.TryParse(e.Value.ToString(), out intVal))
                        {
                            e.DisplayText = intVal.ToString("N0");
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                        break;
                }
            }
        }

        // 입력된 값을 형식에 맞게 편집(소수점 자리수 등) 및 상/하한값 적용
        private void View_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            string inputType = view.GetRowCellValue(e.RowHandle, COLUMN_INPUTTYPE).ToString();
            if (e.Column.FieldName == COLUMN_MEASUREVALUE && (inputType == INPUTTYPE_FLOAT || inputType == INPUTTYPE_INT))
            {
                object decimalPlaceObj = view.GetListSourceRowCellValue(e.RowHandle, COLUMN_DECIMALPLACE);
                decimal decimalPlace = (decimalPlaceObj == DBNull.Value) ? 0 : (decimal)decimalPlaceObj;
                string specType = view.GetRowCellValue(e.RowHandle, COLUMN_SPECTYPE).ToString();
                string isSpecForce = view.GetRowCellValue(e.RowHandle, COLUMN_ISSPECFORCE).ToString();

                grdResult.View.CellValueChanged -= View_CellValueChanged;
                decimal val;
                if (e.Value != DBNull.Value && decimal.TryParse(e.Value.ToString(), out val)) /// 숫자 파싱 성공
                {
                    decimal min = Format.GetDecimal(view.GetRowCellValue(e.RowHandle, "LSL").ToString());
                    decimal max = Format.GetDecimal(view.GetRowCellValue(e.RowHandle, "USL").ToString());

                    if((specType == SPECTYPE_BOTH && (min > val || max < val))
                        || (specType == SPECTYPE_UPPER && (max < val))
                        || (specType == SPECTYPE_LOWER && (min > val))) // 스펙 아웃
                    {
                        ShowMessage("MeasureValueIsOutOfSpec");
                        if (isSpecForce == "Y") // 스펙 강제
                        {
                            view.SetRowCellValue(e.RowHandle, COLUMN_MEASUREVALUE, string.Empty);
                        }
                        else
                        {
                            if (inputType == INPUTTYPE_FLOAT)
                            {
                                view.SetRowCellValue(e.RowHandle, COLUMN_MEASUREVALUE, val.ToString(string.Format("N{0}", decimalPlace)));
                            }
                            else
                            {
                                view.SetRowCellValue(e.RowHandle, COLUMN_MEASUREVALUE, val.ToString("N0"));
                            }
                        }
                    }
                    else
                    {
                        if (inputType == INPUTTYPE_FLOAT)
                        {
                            view.SetRowCellValue(e.RowHandle, COLUMN_MEASUREVALUE, val.ToString(string.Format("N{0}", decimalPlace)));
                        }
                        else
                        {
                            view.SetRowCellValue(e.RowHandle, COLUMN_MEASUREVALUE, val.ToString("N0"));
                        }
                    }
                }
                else // 숫자 파싱 실패
                {
                    view.SetRowCellValue(e.RowHandle, COLUMN_MEASUREVALUE, string.Empty);
                }
                grdResult.View.CellValueChanged += View_CellValueChanged;
            }
        }

        // 엔터키 입력 시 다음행으로 이동
        private void GridControl_ProcessGridKey(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (grdResult.GridControl.FocusedView as ColumnView).FocusedRowHandle++;
                e.Handled = true;
            }
        }

        private void CheckMeasureNPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK && grdResult.GetChangedRows().Rows.Count > 0)
            {
                // 정말 종료하시겠습니까? 저장하지 않은 데이터는 사라집니다.
                if (MSGBox.Show(MessageBoxType.Warning, "CloseWithoutSave", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        // 입력구분에 따른 측정값 좌우정렬
        private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName != "MEASUREVALUE")
            {
                return;
            }
            switch (view.GetRowCellValue(e.RowHandle, COLUMN_INPUTTYPE).ToString())
            {
                case INPUTTYPE_STRING:
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                    break;
                case INPUTTYPE_FLOAT:
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                case INPUTTYPE_INT:
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                case INPUTTYPE_COMBOBOX:
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                    break;
            }
        }

        // 포커스 되지 않은 체크박스 한번만 클릭해도 체크상태 변경
        private void View_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName != "MEASUREVALUE")
            {
                return;
            }
            DataRow row = grdResult.View.GetFocusedDataRow();
            if (row == null || row[COLUMN_INPUTTYPE].ToString() != INPUTTYPE_CHECKBOX)
            {
                return;
            }
            if(view.GetRowCellValue(e.RowHandle, COLUMN_MEASUREVALUE).ToString() == "")
            {
                view.SetRowCellValue(e.RowHandle, COLUMN_MEASUREVALUE, "Y");
            }
            else
            {
                view.SetRowCellValue(e.RowHandle, COLUMN_MEASUREVALUE, "");
            }
            e.Handled = true;
        }

        // Ctrl+V 에 의해 신규 행 생성되는 것 방지
        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            args.IsCancel = true;
        }
    }
}