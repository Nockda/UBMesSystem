#region using

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

#endregion

namespace Micube.SmartMES.StandardInfo
{
    public partial class Model : SmartConditionBaseForm
    {
        /// <summary>
        /// 프 로 그 램 명  : 기준정보 > 코드관리 > 기종관리
        /// 업  무  설  명  : 기종조회
        /// 생    성    자  : jylee    
        /// 생    성    일  : 2020-05-04
        /// 수  정  이  력  : 
        /// 
        /// 
        /// </summary>
        public Model()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeGrid();
        }

        /// <summary>        
        /// 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            grdModel.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdModel.View.SetSortOrder("MODELID");
            grdModel.View.SetAutoFillColumn("DESCRIPTION");

            grdModel.View.AddTextBoxColumn("MODELID", 80)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdModel.View.AddTextBoxColumn("MODELNAMEKOR", 150);
            grdModel.View.AddTextBoxColumn("MODELNAMEENG", 150);
            grdModel.View.AddTextBoxColumn("MODELNAMEJPN", 150);
            grdModel.View.AddTextBoxColumn("DESCRIPTION", 200);
            grdModel.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center)
                .SetDefault("Valid")
                .SetValidationIsRequired();
            grdModel.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdModel.View.AddTextBoxColumn("CREATEDTIME", 120)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdModel.View.AddTextBoxColumn("MODIFIER", 80)
                 .SetIsReadOnly()
                 .SetTextAlignment(TextAlignment.Center);
            grdModel.View.AddTextBoxColumn("MODIFIEDTIME", 120)
                 .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                 .SetIsReadOnly()
                 .SetTextAlignment(TextAlignment.Center);

            grdModel.View.PopulateColumns();
        }

        #region 검색
        //// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtInfo = await QueryAsync("GetModelCode", "00001", values);

            if (dtInfo.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdModel.DataSource = dtInfo;
        }
        #endregion

        #region ToolBar
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdModel.GetChangedRows();

            ExecuteRule("SaveModelList", changed);
        }
        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdModel.View.CheckValidation();

            DataTable changed = grdModel.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }
        #endregion

        #region Private Function
        private void User()
        {
            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            grdModel.DataSource = SqlExecuter.Query("SaveModelList", "00001", values);
        }
        #endregion
    }
}
