#region using
using DevExpress.XtraEditors.Repository;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.Data;
#endregion

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 실적관리 > 조립실적 등록 > 팝업 > 작업자 등록
    /// 업  무  설  명  : 작업자 팝업을 이용해 등록한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-06
    /// 수  정  이  력  : 2020-06-03 | jylee | LayOut수정, 화면개발
    /// </summary>
    public partial class WorkerRegPopup : SmartPopupBaseForm
    {
        private string lotId;
        private string processsegmentId;
        private string subProcesssegmentId;
        private string subProcesssegmentName;
        private string areaId;
        private string equipmentId;
        private string chargeUserId;
        private string specDefIdVersion;

        // 상수
        private const string BUTTONSTATE_LEFT = "Left";
        private const string BUTTONSTATE_RIGHT = "Right";

        public WorkerRegPopup(Dictionary<string, object> param)
        {
            InitializeComponent();
            InitializeParameter(param);
            InitializeGrid();
            InitializeEvent();
            ucDataLeftRightBtn.SourceGrid = this.grdUser;
            ucDataLeftRightBtn.TargetGrid = this.grdWorker;
        }

        private void InitializeParameter(Dictionary<string, object> param)
        {
            this.lotId = param["P_LOT"].ToString();
            this.subProcesssegmentId = param["P_SUBPROCESSID"].ToString();
            this.subProcesssegmentName = param["P_SUBPROCESSNAME"].ToString();
            this.txtSubProcessName.EditValue = subProcesssegmentName;
            this.processsegmentId = param["P_PROCESSSEGMENTID"].ToString();
            this.areaId = param["P_AREAID"].ToString();
            this.specDefIdVersion = param["P_SPECDEFIDVERSION"].ToString();
        }

        #region 컨텐츠 영역 초기화
        private void InitializeGrid()
        {
            InitialzeEquipmentGrid();
            InitializeUserGrid();
            InitializeWorkerGrid();
        }

        private void InitialzeEquipmentGrid()
        {
            grdEquipment.View.OptionsSelection.MultiSelect = false;
            grdEquipment.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdEquipment.View.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            grdEquipment.View.CheckMarkSelection.ShowCheckBoxHeader = false;
            grdEquipment.GridButtonItem = GridButtonItem.None;
            grdEquipment.View.SetIsReadOnly();
            grdEquipment.View.SetSortOrder("EQUIPMENTID");
            grdEquipment.View.AddTextBoxColumn("EQUIPMENTID", 120);
            grdEquipment.View.AddTextBoxColumn("EQUIPMENTNAME", 200);
            grdEquipment.View.AddTextBoxColumn("EQUIPMENTCLASSNAME", 130);
            grdEquipment.View.AddTextBoxColumn("LOCATIONID", 130);
            grdEquipment.View.PopulateColumns();
        }

        /// <summary>        
        /// 전체작업자 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeUserGrid()
        {
            grdUser.GridButtonItem = GridButtonItem.None;
            grdUser.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdUser.View.SetIsReadOnly();
            grdUser.View.AddTextBoxColumn("USERID", 100);
            grdUser.View.AddTextBoxColumn("USERNAME", 100);
            grdUser.View.AddCheckBoxColumn("ISCHARGE").SetIsHidden();
            grdUser.View.PopulateColumns();
            RepositoryItemCheckEdit checkEdit = grdUser.View.Columns["ISCHARGE"].ColumnEdit as RepositoryItemCheckEdit;
            checkEdit.ValueChecked = "Y";
            checkEdit.ValueUnchecked = "N";
        }

        /// <summary>        
        /// 투입작업자 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeWorkerGrid()
        {
            grdWorker.GridButtonItem = GridButtonItem.None;
            grdWorker.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdWorker.View.SetSortOrder("USERID");
            grdWorker.View.AddTextBoxColumn("USERID", 100).SetIsReadOnly();
            grdWorker.View.AddTextBoxColumn("USERNAME", 80).SetIsReadOnly();
            grdWorker.View.AddCheckBoxColumn("ISCHARGE", 50);
            grdWorker.View.PopulateColumns();
            RepositoryItemCheckEdit checkEdit = grdWorker.View.Columns["ISCHARGE"].ColumnEdit as RepositoryItemCheckEdit;
            checkEdit.ValueChecked = "Y";
            checkEdit.ValueUnchecked = "N";
        }
        #endregion

        #region Event
        private void InitializeEvent()
        {
            this.Load += WorkerRegPopup_Load;
            btnSave.Click += BtnSave_Click;
            btnClose.Click += btnClose_Click;
            grdEquipment.View.CheckStateChanged += GrdEquipment_CheckStateChanged;
            grdWorker.View.CellValueChanged += GrdWorker_CellValueChanged;
            ucDataLeftRightBtn.buttonClick += UcDataLeftRightBtn_buttonClick;
            grdUser.View.RowCellClick += GrdUser_RowCellClick;
            grdWorker.View.RowCellClick += GrdWorker_RowCellClick;
        }

        private void GrdWorker_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            // 작업자 클릭 시 사용자로 이동
            if (e.Column.FieldName == "_INTERNAL_CHECKMARK_SELECTION_" || e.Column.FieldName == "ISCHARGE")
            {
                return;
            }
            DataTable users = grdUser.DataSource as DataTable;
            DataRow newRow = users.NewRow();
            foreach (DataColumn col in users.Columns)
            {
                newRow[col.ColumnName] = grdWorker.View.GetRowCellValue(e.RowHandle, col.ColumnName);
            }
            newRow["ISCHARGE"] = "N";
            users.Rows.Add(newRow);
            grdWorker.View.RemoveRow(e.RowHandle);

            if ((grdWorker.DataSource as DataTable).Rows.Count == 1)
            {
                grdWorker.View.CellValueChanged -= GrdWorker_CellValueChanged;
                (grdWorker.DataSource as DataTable).Rows[0]["ISCHARGE"] = "Y";
                grdWorker.View.CellValueChanged += GrdWorker_CellValueChanged;
            }
        }

        // 사용자 클릭 시 작업자로 이동
        private void GrdUser_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(e.Column.FieldName == "_INTERNAL_CHECKMARK_SELECTION_")
            {
                return;
            }
            DataTable workers = grdWorker.DataSource as DataTable;
            DataRow newRow = workers.NewRow();
            foreach(DataColumn col in workers.Columns)
            {
                newRow[col.ColumnName] = grdUser.View.GetRowCellValue(e.RowHandle, col.ColumnName);
            }
            workers.Rows.Add(newRow);
            grdUser.View.RemoveRow(e.RowHandle);

            if (workers.Rows.Count == 1)
            {
                grdWorker.View.CellValueChanged -= GrdWorker_CellValueChanged;
                workers.Rows[0]["ISCHARGE"] = "Y";
                grdWorker.View.CellValueChanged += GrdWorker_CellValueChanged;
            }
        }

        private void WorkerRegPopup_Load(object sender, EventArgs e)
        {
            LoadEquipmentGrid();
            LoadUserGrid();
        }

        // 설비정보 조회
        private void LoadEquipmentGrid()
        {
            var param = new Dictionary<string, object>()
            {
                { "AREAID", areaId }
                , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };
            grdEquipment.DataSource = SqlExecuter.Query("GetAssyEquipmentList", "00001", param);
        }

        // 사용자정보 조회
        private void LoadUserGrid()
        {
            var param = new Dictionary<string, object>()
            {
                { "P_PROCESSSEGMENTID", processsegmentId }
                , { "P_SUBPROCESSSEGMENTID", subProcesssegmentId }
                , { "P_AREAID", areaId }
            };
            grdUser.DataSource = SqlExecuter.Query("ProceeResultUserList", "00001", param);
        }

        // 저장버튼 클릭
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 설비 ID
            DataTable equipment = this.grdEquipment.View.GetCheckedRows();
            if (equipment.Rows.Count > 0)
            {
                equipmentId = equipment.Rows[0]["EQUIPMENTID"].ToString();
            }
            else
            {
                equipmentId = null;
            }

            // 작업자 목록 및 대표작업자
            DataTable worker = this.grdWorker.GetChangedRows();
            var workerList = new List<string>();
            foreach (DataRow each in worker.Rows)
            {
                workerList.Add(each["USERID"].ToString());
                if (each["ISCHARGE"].ToString() == "Y")
                {
                    chargeUserId = each["USERID"].ToString();
                }
            }

            MessageWorker messageWorker = new MessageWorker("SubTrackInAssy");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", lotId }
                , { "subprocesssegmentid", subProcesssegmentId }
                , { "userids", string.Join(",", workerList.ToArray()) }
                , { "chargeuserid", chargeUserId }
                , { "equipmentid", equipmentId }
                , { "specdefidversion", specDefIdVersion }
            });
            messageWorker.Execute();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        // 닫기버튼 클릭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        // 설비 그리드 한 ROW만 체크가능
        private void GrdEquipment_CheckStateChanged(object sender, EventArgs e)
        {
            bool check = grdEquipment.View.IsRowChecked(grdEquipment.View.FocusedRowHandle);
            grdEquipment.View.CheckStateChanged -= GrdEquipment_CheckStateChanged;
            grdEquipment.View.CheckedAll(false);
            grdEquipment.View.CheckRow(grdEquipment.View.FocusedRowHandle, check);
            grdEquipment.View.CheckStateChanged += GrdEquipment_CheckStateChanged;
        }

        private void GrdWorker_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName == "ISCHARGE")
            {
                grdWorker.View.CellValueChanged -= GrdWorker_CellValueChanged;
                grdWorker.View.UncheckedAll("ISCHARGE");
                grdWorker.View.SetRowCellValue(e.RowHandle, "ISCHARGE", "Y");
                grdWorker.View.CellValueChanged += GrdWorker_CellValueChanged;
            }
        }

        // 작업자가 한명일 경우 대표작업자로 자동 체크
        private void UcDataLeftRightBtn_buttonClick(object sender, EventArgs e)
        {
            if (ucDataLeftRightBtn.ButtonState == BUTTONSTATE_RIGHT)
            {
                DataTable users = grdUser.View.GetCheckedRows();
                DataTable workers = grdWorker.DataSource as DataTable;
                if(users.Rows.Count + workers.Rows.Count == 1)
                {
                    if(workers.Rows.Count == 1)
                    {
                        grdWorker.View.SetRowCellValue(grdWorker.View.GetRowHandleByValue("USERID", workers.Rows[0]["USERID"].ToString()), "ISCHARGE", "Y");
                    }
                    else
                    {
                        grdUser.View.SetRowCellValue(grdUser.View.GetRowHandleByValue("USERID", users.Rows[0]["USERID"].ToString()), "ISCHARGE", "Y");
                    }
                }
            }
            else
            {
                DataTable workers = grdWorker.DataSource as DataTable;
                DataTable remove = grdWorker.View.GetCheckedRows();
                if(workers.Rows.Count - remove.Rows.Count == 1)
                {
                    DataTable charge = SelectNotExists(workers, remove);
                    grdWorker.View.SetRowCellValue(grdWorker.View.GetRowHandleByValue("USERID", charge.Rows[0]["USERID"].ToString()), "ISCHARGE", "Y");
                }
            }
        }

        // table 에서 notExists를 제외한 row들을 반환
        private DataTable SelectNotExists(DataTable table, DataTable notExists)
        {
            DataTable result = table.Clone();
            foreach(DataRow row in table.Rows)
            {
                foreach(DataRow notExistsRow in notExists.Rows)
                {
                    if(row["USERID"].ToString() != notExistsRow["USERID"].ToString())
                    {
                        result.ImportRow(row);
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
