
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
    /// 프 로 그 램 명  : 기준정보 > 항목관리 > 검사항목등록
    /// 업  무  설  명  : 관리화면
    /// 생    성    자  : 배선용    
    /// 생    성    일  : 2020-05-15
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class RegInspItem : SmartConditionBaseForm
    {
		ConditionItemComboBox _codeClassColumn = null;

		public RegInspItem()
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
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;

            //검사항목
            grdList.View.AddTextBoxColumn("PARAMETERID", 100).SetIsReadOnly().SetTextAlignment(TextAlignment.Left).SetLabel("INSPITEMID");

            //검사항목명
            grdList.View.AddLanguageColumn("PARAMETERNAME", 150).SetTextAlignment(TextAlignment.Left).SetLabel("INSPITEMNAME");
			//항목 타입
			grdList.View.AddComboBoxColumn("PARAMETERTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ParameterType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
			//단위
			grdList.View.AddComboBoxColumn("UNIT", 100, new SqlQuery("GetUnitList", "00001"));
            //입력방식
            grdList.View.AddComboBoxColumn("INPUTTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=InspItemInputType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));

            //소수점
            grdList.View.AddSpinEditColumn("DECIMALPLACE", 80).SetTextAlignment(TextAlignment.Right);
			//코드클래스
			_codeClassColumn = grdList.View.AddComboBoxColumn("CODECLASSID", 80, new SqlQuery("GetInputParameter", "00001", "PARENTCODECLASSID=InputParameter", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CODECLASSNAME", "CODECLASSID").SetLabel("CODECLASS");

            //미필수여부
            grdList.View.AddComboBoxColumn("ISNOTREQUIRED", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);

            grdList.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                   .SetTextAlignment(TextAlignment.Center)
                   .SetDefault("Valid")
                   .SetValidationIsRequired();
            grdList.View.AddTextBoxColumn("CREATOR", 80)
                   .SetIsReadOnly()
                   .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CREATEDTIME", 140)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIER", 80)
                    .SetIsReadOnly()
                    .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIEDTIME", 140)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);

            grdList.View.PopulateColumns();
        }
        private void InitializeEvent()
        {
            grdList.View.ShowingEditor += View_ShowingEditor;
			grdList.View.CellValueChanged += View_CellValueChanged;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if(e == null) return;

			if (_codeClassColumn == null) return;

			//입력항목 값이 콤보박스면 코드클래스 필수컬럼 지정
			if (e.Column.FieldName.Equals("INPUTTYPE") 
			&& e.Value.Equals("ComboBox"))
			{
				_codeClassColumn.IsRequired = true;
			}
			else
			{
				_codeClassColumn.IsRequired = false;
			}
		}

		private void View_ShowingEditor(object sender, CancelEventArgs e)
        {
            DataRow dr = grdList.View.GetFocusedDataRow();
            DataRowState state = dr.RowState;

            GridView view = sender as GridView;

            if (state.ToString().Equals("Unchanged") && view.FocusedColumn.FieldName.Equals("ITEMID"))
            {
                e.Cancel = true;
            }
        }

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();

            DataTable dtGrid = await QueryAsync("SelectInspItemList", "00001", values);

            if (dtGrid.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdList.DataSource = dtGrid;
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

            ExecuteRule("SaveInspItem", changed);
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
