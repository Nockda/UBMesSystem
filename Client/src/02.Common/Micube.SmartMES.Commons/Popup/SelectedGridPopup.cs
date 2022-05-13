using DevExpress.XtraEditors.Repository;
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

namespace Micube.SmartMES.Commons.Popup
{
    public partial class SelectedGridPopup : SmartPopupBaseForm
    {
        private bool _isMultiResult; // 멀티체크가능 여부
        private string _grdLanguageKey; // 그리드 LanguageKey
        private string _queryID;
        private string _queryVersion;
        private Dictionary<string, object> _parameters; // 컬럼명, 컬럼넓이 
        private List<GridTextAddColumn> _grdColumns;
        
        private bool _isLoadingSearch; // 로드시 자동조회 여부 
        private string _labelName;
        private string _txtBoxName;

        private List<DataRow> _selectedRows;

        public Dictionary<string, object> parameters
        {
            get { return _parameters; }
            private set { _parameters = value; }
        }
        public bool isMultiResult
        {
            get { return _isMultiResult; }
            private set { _isMultiResult = value; }
        }

        public string queryID
        {
            get { return _queryID; }
            private set { _queryID = value; }
        }

        public string queryVersion
        {
            get { return _queryVersion; }
            private set { _queryVersion = value; }
        }

        public string grdLanguageKey
        {
            get { return _grdLanguageKey; }
            private set { _grdLanguageKey = value; }
        }

        public List<GridTextAddColumn> grdColumns
        {
            get { return _grdColumns; }
            private set { _grdColumns = value; }
        }

        public bool isLoadingSearch
        {
            get { return _isLoadingSearch; }
            private set { _isLoadingSearch = value; }
        }

        public List<DataRow> selectedRows
        {
            get { return _selectedRows; }
            private set { _selectedRows = value; }
        }

        public string labelName
        {
            get { return _labelName; }
            private set { _labelName = value; }
        }

        public string txtBoxName
        {
            get { return _txtBoxName; }
            private set { _txtBoxName = value; }
        }

        public SelectedGridPopup(Dictionary<string,object> _parameters
                                , string queryID
                                , string queryVersion
                                , bool isMultiResult
                                , string grdLanguageKey
                                , List<GridTextAddColumn> grdColumns
                                , string labelName
                                , string txtBoxName
                                , bool isLoadingSearch)
        {
            InitializeComponent();
            this.parameters = _parameters;
            this.queryID = queryID;
            this.queryVersion = queryVersion;
            this.isMultiResult = isMultiResult;
            this.grdMain.LanguageKey = this._grdLanguageKey = grdLanguageKey;
            this.grdColumns = grdColumns;
            this.label.LanguageKey =  this.label.Name = this.labelName = labelName;
            this.txtBox.Name = this.txtBox.LanguageKey =  this.txtBoxName = txtBoxName;
            this.isLoadingSearch = isLoadingSearch;

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitializeGrid();
            InitializeEvent();

            if (isLoadingSearch)
            {
                DataSearch();
            }
        }

        private void InitializeEvent()
        {
            this.btnSearch.Click += BtnSearch_Click;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.grdMain.View.KeyUp += View_KeyUp;
        }

        private void View_KeyUp(object sender, KeyEventArgs e)
          {
            if (e.KeyCode == Keys.Space)
            {
                int[] rowsHandle = this.grdMain.View.GetSelectedRows();

                for (int i = 0; i < rowsHandle.Length; i++)
                {
                    //this.grdMain.View.GetDataRow(i).
                }

            }
        }

        private void GrdMain_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DataSearch();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(selectedRows == null)
                selectedRows = new List<DataRow>();
            else
                selectedRows.Clear();

            
            
            foreach (DataRow row in this.grdMain.View.GetCheckedRows().Rows)
            {
                selectedRows.Add(row);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DataSearch()
        {

            if (parameters.ContainsKey(this.label.LanguageKey))
                parameters[this.label.LanguageKey] = this.txtBox.Text;
            else
                parameters.Add(this.label.LanguageKey, this.txtBox.Text);
            
            DataTable dt =  SqlExecuter.Query(queryID, queryVersion, parameters);
            if (dt.Rows.Count < 0)
            {
                ShowMessage("NoSelectData");
            }
            this.grdMain.DataSource = dt;
        }


        private void InitializeGrid()
        {
            this.grdMain.GridButtonItem = GridButtonItem.None;

            grdMain.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdMain.View.CheckMarkSelection.MultiSelectCount = isMultiResult == true ? 0 : 1;
            
            // 텍스트박스 컬럼만 추가..
            foreach (GridTextAddColumn var in this.grdColumns)
            {
                if(string.IsNullOrWhiteSpace(var.colLabel))
                {
                    this.grdMain.View.AddTextBoxColumn(var.colName, var.colWidth)
                        .SetIsReadOnly();
                }
                else
                {
                    this.grdMain.View.AddTextBoxColumn(var.colName, var.colWidth).SetLabel(var.colLabel)
                        .SetIsReadOnly();
                }
            }


            this.grdMain.View.PopulateColumns();
            this.grdMain.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

        }
    }

    public class GridTextAddColumn
    {
        public string colName { get; set; }
        public int colWidth { get; set;}
        public string colLabel { get; set; }


        public GridTextAddColumn(string colName, int colWidth)
        {
            this.colName = colName;
            this.colWidth = colWidth;
        }

        public GridTextAddColumn(string colName, int colWidth, string colLabel)
        {
            this.colName = colName;
            this.colWidth = colWidth;
            this.colLabel = colLabel;
        }

    }
}
