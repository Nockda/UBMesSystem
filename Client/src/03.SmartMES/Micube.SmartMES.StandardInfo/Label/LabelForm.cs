using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 항목관리 > 라벨 디자인
    /// 업  무  설  명  : 라벨 디자인
    /// 생    성    자  : yshwang
    /// 생    성    일  : 2020-05-19
    /// 수  정  이  력  : 
    /// </summary>
    public partial class LabelForm : SmartConditionBaseForm
    {
        public LabelForm()
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
            InitializeGrid();
            InitializeEvent();
        }

        /// <summary>        
        /// 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            grdList.GridButtonItem = GridButtonItem.Add;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdList.View.OptionsBehavior.EditorShowMode = EditorShowMode.Click; // 더블클릭 이벤트가 자연스럽게 작동하도록 함

            grdList.View.AddTextBoxColumn("LABELID", 260).SetValidationIsRequired().SetValidationKeyColumn();
            grdList.View.AddTextBoxColumn("LABELNAME", 280).SetValidationIsRequired();
            grdList.View.AddComboBoxColumn("LABELTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=LabelType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetValidationIsRequired();
            grdList.View.AddTextBoxColumn("DESCRIPTION", 320);
            grdList.View.AddTextBoxColumn("QUERYID", 160);
            grdList.View.AddTextBoxColumn("QUERYVERSION", 100);
            grdList.View.AddComboBoxColumn("VALIDSTATE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetDefault("Valid")
               .SetValidationIsRequired();
            grdList.View.AddTextBoxColumn("CREATOR", 90).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdList.View.AddTextBoxColumn("CREATEDTIME", 140).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetTextAlignment(TextAlignment.Center).SetIsReadOnly(); 
            grdList.View.AddTextBoxColumn("MODIFIER", 90).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdList.View.AddTextBoxColumn("MODIFIEDTIME", 140).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdList.View.PopulateColumns();
        }

        /// <summary>
        /// 이벤트 등록
        /// </summary>
        private void InitializeEvent()
        {
            // NOTE : 디자이너 실행속도가 느려서 더블클릭 이벤트로 디자이너 실행하지 않도록 수정
            // grdList.View.DoubleClick += View_DoubleClick;
            this.Load += LabelForm_LoadAsync;
        }

        private async void LabelForm_LoadAsync(object sender, EventArgs e)
        {
            await OnSearchAsync();
        }

        /// <summary>
        /// 그리드 행 더블클릭 시 라벨 디자이너 실행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                DataRow row = view.GetDataRow(info.RowHandle);

                string labelId = row["LABELID"].ToString();
                string labelName = row["LABELNAME"].ToString();

                ShowLabelDesigner(labelId, labelName);
            }
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
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtItem = await QueryAsync("GetLabelList", "00001", values);
            grdList.DataSource = dtItem;

            if (dtItem.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }
        }
        #endregion

        #region Tool Bar
        /// <summary>
        /// 툴바의 저장버튼 클릭 이벤트
        /// 변경된 행들을 저장한다.(라벨 디자인 데이터 제외)
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable chagnedRows = grdList.GetChangedRows();
            if (chagnedRows.Rows.Count < 1)
            {
                ShowMessage("NoSaveData");
                return;
            }

            ExecuteRule("SaveLabelForm", chagnedRows);
        }

        /// <summary>
        /// 툴바의 디자인버튼 클릭 이벤트
        /// </summary>
        /// <param name="e"></param>
        protected override void OnToolbarClick(ToolbarClickEventArgs e)
        {
            base.OnToolbarClick(e);
            if(e.Id == "LabelDesign")
            {
                DataRow focusedRow = grdList.View.GetFocusedDataRow();
                if (focusedRow == null)
                {
                    return;
                }
                if(focusedRow.RowState != DataRowState.Unchanged)
                {
                    // 추가/수정/삭제 상태의 라벨은 디자인을 수정할 수 없습니다. 저장 후 다시 시도해주시기 바랍니다.
                    ShowMessage("CantRegisterModifiedLabel");
                    return;
                }
                string labelId = focusedRow["LABELID"].ToString();
                string labelName = focusedRow["LABELNAME"].ToString();

                ShowLabelDesigner(labelId, labelName);
            }
        }
        #endregion

        #region ETC
        /// <summary>
        /// 라벨 디자이너를 실행하여 선택된 라벨의 디자인을 수정하고 DB에 저장한다.
        /// </summary>
        /// <param name="labelId">라벨 ID</param>
        /// <param name="labelName">라벨명</param>
        private void ShowLabelDesigner(string labelId, string labelName)
        {
            byte[] labelData = GetLabelData(labelId);

            LabelForm_Popup popup = new LabelForm_Popup(labelId, labelName, labelData);
            if (popup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageWorker worker = new MessageWorker("SaveLabelData");
                worker.SetBody(new MessageBody()
                    {
                        { "labelid", labelId },
                        { "labeldata", popup.LabelData }
                    });
                worker.Execute();
            }
        }

        /// <summary>
        /// 라벨의 디자인 데이터를 DB에서 가져온다.
        /// </summary>
        /// <param name="labelId">라벨 ID</param>
        /// <returns></returns>
        private byte[] GetLabelData(string labelId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LABELID", labelId);
            DataTable result = SqlExecuter.Query("GetLabelData", "00001", param);
            if(result.Rows.Count == 0 || result.Rows[0]["LABELDATA"] == DBNull.Value 
                || result.Rows[0]["LABELDATA"].ToString().Length == 0)
            {
                return null;
            }
            else
            {
                return Convert.FromBase64String(result.Rows[0]["LABELDATA"].ToString());
            }
        }
        #endregion

        #region Validation
        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdList.View.CheckValidation();
        }
        #endregion
    }
}
