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

namespace Micube.SmartMES.Production
{
    /// <summary>
    /// 프 로 그 램 명  : 생산관리 > 재공조회
    /// 업  무  설  명  : 재공 정보를 조회한다.
    /// 생    성    자  : jylee
    /// 생    성    일  : 2020-04-30
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class WorkInProcess : SmartConditionBaseForm
    {
        public WorkInProcess()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();

            //InitializeEvent();

            InitializeGrid();
        }

        /// <summary>        
        /// 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            grdWip.GridButtonItem = GridButtonItem.Copy ;
            grdWip.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdWip.View.SetSortOrder("PLANT");

            //작업장
            grdWip.View.AddTextBoxColumn("PLANT", 150)
                .SetValidationKeyColumn()
                .SetIsReadOnly();
            //공정
            grdWip.View.AddTextBoxColumn("AREA", 150)
                .SetIsReadOnly();
            //TEAM
            grdWip.View.AddTextBoxColumn("TEAM", 150)
                 .SetIsReadOnly();
            //품번
            grdWip.View.AddTextBoxColumn("ITEMID", 150)
                .SetIsReadOnly();
            //기종
            grdWip.View.AddTextBoxColumn("MODEL", 150)
                .SetIsReadOnly();
            //도번
            grdWip.View.AddTextBoxColumn("DRAWINGNUM", 150)
                .SetIsReadOnly();
            //수량
            grdWip.View.AddTextBoxColumn("QTY", 150)
                 .SetIsReadOnly();

            grdWip.View.PopulateColumns();

        }

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtEquipCode = await QueryAsync("GetWipList", "00001", values);

            if (dtEquipCode.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdWip.DataSource = dtEquipCode;
        }

        #endregion

/*        private void InitializeEvent()
        {
            throw new NotImplementedException();
        }*/
    }
}
