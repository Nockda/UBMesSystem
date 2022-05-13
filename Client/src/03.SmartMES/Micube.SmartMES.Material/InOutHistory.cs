#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using Micube.SmartMES.Commons;

#endregion

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 자재현황 > 자재 입출고 이력
    /// 업  무  설  명  : 자재 입출고 이력을 조회한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2020-06-17
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class InOutHistory : SmartConditionBaseForm
    {
        public InOutHistory()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();
            InitializeList();
        }

        private void InitializeList()
        {
            grdList.View.OptionsFind.AlwaysVisible = true;
            grdList.GridButtonItem = GridButtonItem.Export;
            //grdList.View.OptionsView.AllowCellMerge = true;
            grdList.View.OptionsCustomization.AllowSort = false;
            grdList.View.OptionsView.EnableAppearanceEvenRow = false;
            grdList.View.OptionsView.EnableAppearanceOddRow = false;

            //grdList.View.SetSortOrder("TRANSACTIONDATE");
            grdList.View.SetIsReadOnly();

            grdList.View.AddDateEditColumn("TRANSACTIONDATE", 80)
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("TRANSACTIONTYPE", 70, new SqlQuery("GetCodeList", "00001", $"CODECLASSID=InOutType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("INOUTGUBUN")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("TRANSACTIONCODE", 90, new SqlQuery("GetCodeList", "00001", $"CODECLASSID=TransactionCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("INOUTTYPE")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFID", 120)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 180);
            grdList.View.AddComboBoxColumn("CONSUMABLETYPE", 80, new SqlQuery("GetCodeList", "00001", $"CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("PRODUCTDEFTYPE")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("OUTWAREHOUSEID", 90, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("FROMWAREHOUSEID")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("INWAREHOUSEID", 90, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("TOWAREHOUSEID")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CONSUMABLELOTID", 90)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddSpinEditColumn("QTY", 50);
            grdList.View.AddComboBoxColumn("UNIT", 50, new SqlQuery("GetCodeList", "00001", "CODECLASSID=Unit", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CELLID", 80)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("REFERENCEKEY", 100)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CUSTOMERID", 80)
                .SetIsHidden()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CUSTOMERNAME", 120);
            grdList.View.AddComboBoxColumn("TEAMID", 80, new SqlQuery("GetTeamList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DESCRIPTION", 100)
                .SetLabel("RECEIVER")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("TRANSACTIONDETAILCODE", 100, new SqlQuery("GetComboForInOutHistory", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"),"TITLE", "FIELD")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("INOUTUSERNAME", 100)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("INOUTTIME", 120)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd hh:mm:ss");

            grdList.View.PopulateColumns();

        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            //grdList.View.CellMerge += View_CellMerge; //고객요청으로 merge해제
            grdList.View.RowStyle += View_RowStyle;
        }

        private void View_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (coloredRows.ContainsKey(e.RowHandle))
                e.Appearance.BackColor = coloredRows[e.RowHandle];
        }

        private void View_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == "TRANSACTIONDATE" || e.Column.FieldName == "TRANSACTIONCODE" || e.Column.FieldName == "CONSUMABLEDEFID" 
                || e.Column.FieldName == "CONSUMABLEDEFNAME" || e.Column.FieldName == "CONSUMABLETYPE" || e.Column.FieldName == "OUTWAREHOUSEID" || e.Column.FieldName == "INWAREHOUSEID")
            {
                string str1 = view.GetRowCellDisplayText(e.RowHandle1, e.Column);
                string str2 = view.GetRowCellDisplayText(e.RowHandle2, e.Column);

                string id1 = view.GetRowCellValue(e.RowHandle1, "CONSUMABLEDEFID").ToString();
                string id2 = view.GetRowCellValue(e.RowHandle2, "CONSUMABLEDEFID").ToString();

                e.Merge = (str1 == str2 && id1 == id2);
            }
            else
            {
                e.Merge = false;
            }

            e.Handled = true;
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
            values.Add("DBLINKNAME", CommonFunction.DbLinkName);

            DataTable dtList = await QueryAsync("GetMaterialInOutHistory","00001", values);

            if (dtList.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }
            grdList.DataSource = dtList;


            CollectColoredRows();
            grdList.View.LayoutChanged();
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

        #region Private Function

        Dictionary<int, Color> coloredRows = new Dictionary<int, Color>();

        /// <summary>
        /// Merge대체 => 같은 품목인 경우 같은 색상이 표시되도록
        /// </summary>
        private void CollectColoredRows()
        {
            coloredRows.Clear();
            if (grdList.View.DataRowCount > 0)
                coloredRows.Add(0, Color.Transparent);
            for (int i = 1; i < grdList.View.DataRowCount; i++)
            {
                int prevRowHandle = i - 1;
                Color prevColor = coloredRows[prevRowHandle];
                object val1 = grdList.View.GetRowCellValue(i, "CONSUMABLEDEFID");
                object val2 = grdList.View.GetRowCellValue(prevRowHandle, "CONSUMABLEDEFID");
                if (object.Equals(val1, val2))
                    coloredRows.Add(i, prevColor);
                else
                    coloredRows.Add(i, prevColor == Color.Transparent ? Color.FromArgb(10,0,0,0) : Color.Transparent);
            }
        }
        #endregion
    }
}
