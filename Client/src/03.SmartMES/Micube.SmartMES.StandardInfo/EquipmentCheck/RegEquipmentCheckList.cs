
#region using

using DevExpress.XtraEditors.Senders;
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
using DevExpress.XtraGrid.Views.Grid;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 설비관리 > 점검항목등록
    /// 업  무  설  명  : 관리화면
    /// 생    성    자  : 배선용    
    /// 생    성    일  : 2020-05-15
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class RegEquipmentCheckList : SmartConditionBaseForm
    {
		ConditionItemComboBox _codeClassColumn = null;

		public RegEquipmentCheckList()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeList();
            InitializeEvent();
        }

        private void InitializeList()
        {
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            //점검항목ID
            grdList.View.AddTextBoxColumn("MAINTITEMID", 100).SetTextAlignment(TextAlignment.Left).SetLabel("CHCKITEMID").SetValidationIsRequired();

            //점검항목명
            grdList.View.AddLanguageColumn("MAINTITEMNAME", 150).SetTextAlignment(TextAlignment.Left).SetLabel("CHECKITEMNAME");
			
			grdList.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                   .SetTextAlignment(TextAlignment.Center)
                   .SetDefault("Valid")
                   .SetValidationIsRequired();
            grdList.View.AddTextBoxColumn("CREATOR", 80)
                   .SetIsReadOnly()
                   .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CREATEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIER", 80)
                    .SetIsReadOnly()
                    .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);

            grdList.View.PopulateColumns();
        }
        private void InitializeEvent()
        {
            grdList.View.ShowingEditor += View_ShowingEditor;
        }


        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();

            DataTable dtGrid = await QueryAsync("SelectEquipmentCheckItem", "00001", values);

            if (dtGrid.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdList.DataSource = dtGrid;
        }
        private void View_ShowingEditor(object sender, CancelEventArgs e)
        {
            DataRow dr = grdList.View.GetFocusedDataRow();
            DataRowState state = dr.RowState;

            GridView view = sender as GridView;

            if (state.ToString().Equals("Unchanged") && view.FocusedColumn.FieldName.Equals("MAINTITEMID"))
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdList.GetChangedRows();

            ExecuteRule("SaveEquipmentCheckItem", changed);
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdList.View.CheckValidation();

            DataTable changed = grdList.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion


    }
}
