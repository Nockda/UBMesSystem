#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using DevExpress.Utils;

#endregion

namespace Micube.SmartMES.Quality
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 항목관리 > 수입검사항목
    /// 업  무  설  명  : 수입검사항목을 확인 및 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-04-06
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class IqcInspList : SmartConditionBaseForm
    {
        public IqcInspList()
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
        }

        /// <summary>        
        /// 관리 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeInfo()
        {
            this.smartGroupBox1.GridButtonItem = GridButtonItem.Expand | GridButtonItem.Restore;


            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;

            // 그리드 초기화
            grdInfo.GridButtonItem = GridButtonItem.All;

            grdInfo.View.SetSortOrder("ITEMID");
            grdInfo.View.SetAutoFillColumn("DESCRIPTION");

            CheckListPopup();
            grdInfo.View.AddTextBoxColumn("ITEMNAME", 100)
                .SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("DESCRIPTION", 150);
            grdInfo.View.AddTextBoxColumn("FILESTATE", 50)
                .SetDefault("No")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("FILENAME", 150)
                .SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("FILEDATA", 120)
                .SetIsHidden();
            grdInfo.View.AddButtonColumn("FILESELECT", 50);
            grdInfo.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.PopulateColumns();

        }

        private void CheckListPopup()
        {
            var popupColumn = grdInfo.View.AddSelectPopupColumn("ITEMID", new SqlQuery("GetItem", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTPARENTCODECLASSID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("ITEMID", "ITEMID")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("ITEMNAME")
                .SetValidationKeyColumn()
                .SetValidationIsRequired()
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow classRow = grdInfo.View.GetFocusedDataRow();

                    foreach (DataRow row in selectedRows)
                    {
                        classRow["ITEMNAME"] = row["ITEMNAME"];
                    }
                });

            popupColumn.GridColumns.AddTextBoxColumn("ITEMID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("ITEMNAME", 150);
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdInfo.View.AddingNewRow += View_AddingNewRow;
            grdInfo.View.GridCellButtonClickEvent += View_GridCellButtonClickEvent;
            grdInfo.View.CellValueChanged += View_CellValueChanged;
            grdInfo.View.DoubleClick += View_DoubleClick;

            /*
            grdInfo.View.GridControl.ToolTipController.GetActiveObjectInfo += (s, e) =>
            {
                if (!e.SelectedControl.Equals(grdInfo))
                {
                    var hitInfo = grdInfo.View.CalcHitInfo(e.ControlMousePosition);
                    if (!hitInfo.InRowCell)
                    {
                        return;
                    }

                    if (hitInfo.Column.FieldName != "FILENAME")
                    {
                        return;
                    }

                    DataRow dr = (grdInfo.View.GetRow(hitInfo.RowHandle) as DataRowView).Row;

                    if (dr["FILEDATA"].ToString() == string.Empty && dr["FILENAME"].ToString() == string.Empty)
                    {
                        return;
                    }

                    ToolTipControlInfo toolTipControlInfo = new ToolTipControlInfo(hitInfo.RowHandle, "FILEDATA");
                    SuperToolTip superToolTip = new SuperToolTip();
                    superToolTip.Items.AddTitle(dr["FILENAME"].ToString());
                    superToolTip.Items.Add(new ToolTipItem()
                    {
                        Image = new Bitmap((Bitmap)new ImageConverter().ConvertFrom((byte[])dr["FILEDATA"]), new Size(300, 300))
                    });

                    toolTipControlInfo.SuperTip = superToolTip;
                    e.Info = toolTipControlInfo;
                }
            };
            */
        }

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdInfo.View.GetFocusedDataRow();
        }

        private void View_GridCellButtonClickEvent(SmartBandedGridView sender, GridCellButtonClickEventArgs args)
        {
            if (!args.FieldName.Equals("FILESELECT"))
                return;

            using (OpenFileDialog openfileDialog = new OpenFileDialog())
            {
                openfileDialog.RestoreDirectory = true;
                openfileDialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif";
                //openfileDialog.Filter = "Excel files|*.xlsx;*.xls"
                //                        + "|"
                //                        + "Image files|*.jpg;*.jpeg;*.png;*.gif";


                if (openfileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = openfileDialog.FileName;

                    string fileName = Path.GetFileName(file);
                    byte[] fileBytes = getFileBytes(file);

                    string base64FileData = Convert.ToBase64String(fileBytes);

                    grdInfo.View.SetRowCellValue(grdInfo.View.FocusedRowHandle, "FILEDATA", base64FileData);
                    grdInfo.View.SetRowCellValue(grdInfo.View.FocusedRowHandle, "FILENAME", fileName);
                }
            }
        }

        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("FILEDATA"))
            {
                DataRow row = (sender as SmartBandedGridView).GetFocusedDataRow();
                string fileData = row["FILEDATA"].ToString();

                if(fileData.Length > 0)
                {
                    grdInfo.View.SetFocusedRowCellValue("FILESTATE", "Yes");
                }
            }

        }

        private void View_DoubleClick(object sender, EventArgs e)
        {
            if (grdInfo.View.FocusedRowHandle < 0)
                return;

            DataRow row = (sender as SmartBandedGridView).GetFocusedDataRow();

            if (row["FILEDATA"].ToString() == "")
            {
                ShowMessage("NoSelectData");
                smartPictureEdit1.Image.Dispose();

                return;
            }

            byte[] fileBytes = Convert.FromBase64String(row["FILEDATA"].ToString());

            var imageMemoryStream = new MemoryStream(fileBytes);

            Image imgFromStream = Image.FromStream(imageMemoryStream);

            smartPictureEdit1.Image = imgFromStream;

        }

        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdInfo.GetChangedRows();

            ExecuteRule("SaveIqcInspectionList", changed);
        }
        #endregion

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtEquipCode = await QueryAsync("GetIqcInspectionList", "00001", values);

            if (dtEquipCode.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdInfo.DataSource = dtEquipCode;
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

            DataTable changed = grdInfo.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }
        #endregion

        #region function
        private byte[] getFileBytes(string fileFullPath)
        {
            byte[] bytes;
            using (FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read))
            {
                bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();

                return bytes;
            }
        }
        #endregion
    }
}
