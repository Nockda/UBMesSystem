#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;

#endregion

namespace Micube.SmartMES.Equipment
{
    /// <summary>
    /// 프 로 그 램 명  : 설비관리 > 설비점검 > 설비일상점검표
    /// 업  무  설  명  : 설비일상점검표를 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-04-09
    /// 수  정  이  력  : 2020-07-28 | JYLEE | 점검실적 버튼 => 툴바 변경
    /// 
    /// 
    /// </summary>
    public partial class EquipDailyCheck : SmartConditionBaseForm
    {
        #region Local Variables
        private string _currentStatus;
        #endregion


        public EquipDailyCheck()
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

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeInfo();
            InitializeDetail();

            this.lblEquipment.Editor.ReadOnly = true;
            this.lblEquipmentGroup.Editor.ReadOnly = true;

        }

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeInfo()
        {
            grdInfo.GridButtonItem = GridButtonItem.Export;
            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdInfo.View.OptionsCustomization.AllowSort = false;
            grdInfo.View.SetIsReadOnly();
            grdInfo.View.OptionsView.AllowCellMerge = true;

            grdInfo.View.AddTextBoxColumn("EQUIPCHECKID", 80)
                .SetIsHidden()
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdInfo.View.AddComboBoxColumn("CHECKTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentCheckCatecory", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("EQUIPCHECKNAME", 250);
            grdInfo.View.AddComboBoxColumn("CHECKCYCLE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentCheckCycle", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddSpinEditColumn("CHECKCOUNT", 80)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddComboBoxColumn("CHECKWAY", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentCheckWay", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY01", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY02", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY03", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY04", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY05", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY06", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY07", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY08", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY09", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY10", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY11", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY12", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY13", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY14", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY15", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY16", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY17", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY18", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY19", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY20", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY21", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY22", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY23", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY24", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY25", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY26", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY27", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY28", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY29", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY30", 40)
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DAY31", 40)
                .SetTextAlignment(TextAlignment.Center);

            grdInfo.View.PopulateColumns();
        }

        /// <summary>
        /// 상세 그리드 초기화
        /// </summary>
        private void InitializeDetail()
        {
            grdDetail.GridButtonItem = GridButtonItem.Add | GridButtonItem.Delete | GridButtonItem.Export;
            grdDetail.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdDetail.View.SetSortOrder("SEQ");
            grdDetail.View.SetAutoFillColumn("ACTIONDESCRIPTION");

            grdDetail.View.AddTextBoxColumn("SEQ")
                .SetIsHidden();
            grdDetail.View.AddTextBoxColumn("EQUIPMENTID")
                .SetIsHidden();
            grdDetail.View.AddDateEditColumn("OCCURDATE", 100)
                .SetValidationIsRequired()
                .SetValidationKeyColumn()
                .SetDisplayFormat("yyyy-MM-dd")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("OCCURDESCRIPTION", 200);
            grdDetail.View.AddDateEditColumn("ACTIONDATE", 100)
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("ACTIONDESCRIPTION", 200)
                .SetLabel("ACTIONRESULT");
            grdDetail.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("CREATEDTIME", 120)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("MODIFIEDTIME", 120)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdDetail.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            //btnCheck.Click += BtnCheck_Click;
            //btnSave.Click += BtnSave_Click;

            grdInfo.View.CellMerge += View_CellMerge;
            grdInfo.View.RowCellStyle += InfoView_RowCellStyle;

            grdDetail.View.AddingNewRow += DetailView_AddingNewRow;
        }

        #region ToolBar
        /// <summary>
        /// 점검입력 / 저장 클릭
        /// </summary>

        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            base.OnToolbarClick(sender, e);

            SmartButton button = sender as SmartButton;

            switch (button.Name.ToString())
            {
                case "Save":
                    try
                    {
                        this.ShowWaitArea();
                        this.Focus();
                        this.Enabled = false;

                        if (!CheckSearchData())
                        {
                            throw MessageException.Create("HaveToChooseEquip");
                            return;
                        }

                        DataTable changed = grdDetail.GetChangedRows();
                        if (changed.Rows.Count < 1)
                            return;

                        foreach (DataRow row in changed.Rows)
                        {
                            row["EQUIPMENTID"] = Conditions.GetValue("P_EQUIPCODE");
                        }
                        ExecuteRule("SaveEquipCheckDataDetail", changed);
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                    finally
                    {
                        this.CloseWaitArea();
                        this.Enabled = true;
                        OnSearchAsync();
                    }
                    break;
                case "InputCheck":
                    try
                    {
                        this.ShowWaitArea();
                        this.Focus();
                        this.Enabled = false;

                        if (!CheckSearchData())
                        {
                            throw MessageException.Create("HaveToChooseEquip");
                            return;
                        }

                        EquipDailyCheckPopup popup = new EquipDailyCheckPopup();
                        popup.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

                        var values = Conditions.GetValues();
                        string equipCode = values["P_EQUIPCODE"].ToString();
                        popup._equipmentCode = equipCode;

                        popup.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                    finally
                    {
                        this.CloseWaitArea();
                        this.Enabled = true;
                        OnSearchAsync();
                    }
                    break;
            }

        }

        #endregion

       /* private void BtnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnCheck.Focus();
                btnCheck.Enabled = false;

                if(!CheckSearchData())
                {
                    throw MessageException.Create("HaveToChooseEquip");
                    return;
                }

                EquipDailyCheckPopup popup = new EquipDailyCheckPopup();
                popup.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

                var values = Conditions.GetValues();
                string equipCode = values["P_EQUIPCODE"].ToString();
                popup._equipmentCode = equipCode;

                popup.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnCheck.Enabled = true;
                OnSearchAsync();
            }
        }*/

/*        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnSave.Focus();
                btnSave.Enabled = false;

                if (!CheckSearchData())
                {
                    throw MessageException.Create("HaveToChooseEquip");
                    return;
                }

                DataTable changed = grdDetail.GetChangedRows();
                if (changed.Rows.Count < 1)
                    return;

                foreach(DataRow row in changed.Rows)
                {
                    row["EQUIPMENTID"] = Conditions.GetValue("P_EQUIPCODE");
                }
                ExecuteRule("SaveEquipCheckDataDetail", changed);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnSave.Enabled = true;
                OnSearchAsync();
            }
        }*/

        private void View_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == "CHECKTYPE")
            {
                string str1 = view.GetRowCellDisplayText(e.RowHandle1, e.Column);
                string str2 = view.GetRowCellDisplayText(e.RowHandle2, e.Column);
                e.Merge = (str1 == str2);
            }
            else
            {
                e.Merge = false;
            }

            e.Handled = true;
        }

        private void InfoView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if(e.Column.FieldName.Contains("DAY"))
                e.Column.AppearanceCell.Reset();

            string sDay = e.Column.FieldName;

            if(sDay.Substring(0,3) == "DAY")
            {
                sDay = sDay.Substring(3);

                var values = Conditions.GetValues();
                DateTime date = Convert.ToDateTime(values["P_DATETIME"].ToString());
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                int iYear = date.Year;
                int iMonth = date.Month;
                int iDay = Convert.ToInt32(sDay);

                if (iDay <= lastDayOfMonth.Day)
                {
                    DateTime tmpDate = new DateTime(iYear, iMonth, iDay);
                
                    if (tmpDate.DayOfWeek == DayOfWeek.Saturday || tmpDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        e.Column.AppearanceCell.BackColor = Color.FromArgb(30, 255, 0, 0);
                    }
                }
                
            }
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void DetailView_AddingNewRow(SmartBandedGridView sender, AddNewRowArgs args)
        {
            DateTime newDate = DateTime.Now;
            args.NewRow["OCCURDATE"] = newDate;
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

            DateTime date = Convert.ToDateTime(values["P_DATETIME"].ToString());
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);
            values.Add("P_STARTDATE", firstDayOfMonth.ToString("yyyy-MM-dd"));
            values.Add("P_ENDDATE", lastDayOfMonth.ToString("yyyy-MM-dd"));
            
            DataTable dtInfo = await QueryAsync("GetEquipCheckDataList", "00001", values);

            if (dtInfo.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdInfo.DataSource = dtInfo;

            DataTable dtDetail = await QueryAsync("GetEquipCheckDataDetailList", "00001", values);

            grdDetail.DataSource = dtDetail;

            DataTable dtHeader = await QueryAsync("GetEquipCheckDataListheader", "00001", values);

            lblEquipment.Editor.EditValue = dtHeader.Rows[0]["EQUIPMENTNAME"].ToString();
            lblEquipmentGroup.Editor.EditValue = dtHeader.Rows[0]["EQUIPMENTGROUPNAME"].ToString();
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            SmartDateEdit dateEdit = Conditions.GetControl<SmartDateEdit>("P_DATETIME");
            dateEdit.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            dateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateEdit.Properties.Mask.EditMask = "yyyy-MM";
            dateEdit.EditValue = DateTime.Now;

            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").DataSource = null;
            Conditions.GetControl<SmartComboBox>("P_AREACODE").EditValueChanged += AreaCode_EditValueChanged;
            Conditions.GetControl<SmartComboBox>("p_equipCode").DataSource = null;
            Conditions.GetControl<SmartComboBox>("P_equipmentGroup").EditValueChanged += EquipmentGroup_EditValueChanged;
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            grdInfo.View.CheckValidation();

            DataTable changed = grdDetail.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function
        private void AreaCode_EditValueChanged(object sender, EventArgs e)
        {
            SqlQuery condition = new SqlQuery("GetEquipmentClassList", "00003", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_AREACODE={Conditions.GetControl<SmartComboBox>("P_AREACODE").EditValue}");
            DataTable conditionTable = condition.Execute();
            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").ValueMember = "EQUIPMENTCLASSID";
            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").DisplayMember = "EQUIPMENTCLASSNAME";
            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").DataSource = conditionTable;
            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").EditValue = null;
            Conditions.GetControl<SmartComboBox>("p_equipCode").EditValue = null;

            SqlQuery condition2 = new SqlQuery("GetComboEquipment", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_AREACODE={Conditions.GetControl<SmartComboBox>("P_AREACODE").EditValue}", $"P_ISDAILYCHECK=Y");
            DataTable conditionTable2 = condition2.Execute();
            Conditions.GetControl<SmartComboBox>("p_equipCode").ValueMember = "CODEID";
            Conditions.GetControl<SmartComboBox>("p_equipCode").DisplayMember = "CODENAME";
            Conditions.GetControl<SmartComboBox>("p_equipCode").DataSource = conditionTable2;
            Conditions.GetControl<SmartComboBox>("p_equipCode").EditValue = null;
        }

        private void EquipmentGroup_EditValueChanged(object sender, EventArgs e)
        {
            SqlQuery condition = new SqlQuery("GetComboEquipment", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_AREACODE={Conditions.GetControl<SmartComboBox>("P_AREACODE").EditValue}", $"P_EQUIPMENTGROUP={Conditions.GetControl<SmartComboBox>("p_equipmentGroup").EditValue}", $"P_ISDAILYCHECK=Y");
            DataTable conditionTable = condition.Execute();
            Conditions.GetControl<SmartComboBox>("p_equipCode").ValueMember = "CODEID";
            Conditions.GetControl<SmartComboBox>("p_equipCode").DisplayMember = "CODENAME";
            Conditions.GetControl<SmartComboBox>("p_equipCode").DataSource = conditionTable;
            Conditions.GetControl<SmartComboBox>("p_equipCode").EditValue = null;
        }

        private bool CheckSearchData()
        {
            bool rValue = true;

            var values = Conditions.GetValues();
            if (values["P_EQUIPCODE"] == null || values["P_EQUIPCODE"].ToString().Length == 0)
                rValue = false;

            return rValue;
        }




        #endregion
    }
}
