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
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 스펙코드관리
    /// 업  무  설  명  : 스펙정의
    /// 생    성    자  : jylee    
    /// 생    성    일  : 2020-04-30
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class SpecCodeMgt : SmartConditionBaseForm
    {
        public SpecCodeMgt()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();

            //InitializeEvent();
            InitializeList();

        }
        /// <summary>
        /// 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeList()
        {
            grdSpec.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdSpec.View.SetSortOrder("SPECID");
            grdSpec.View.SetAutoFillColumn("DESCRIPTION");

            grdSpec.View.AddTextBoxColumn("SPECID", 100)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdSpec.View.AddTextBoxColumn("SPECNAMEKOR",150);
            grdSpec.View.AddTextBoxColumn("SPECNAMEENG", 150);
            grdSpec.View.AddTextBoxColumn("SPECNAMEJPN", 150);
            grdSpec.View.AddTextBoxColumn("DESCRIPTION", 100);
            grdSpec.View.AddTextBoxColumn("CREATOR", 80)
                     .SetIsReadOnly()
                     .SetTextAlignment(TextAlignment.Center);
            grdSpec.View.AddTextBoxColumn("CREATEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);
            grdSpec.View.AddTextBoxColumn("MODIFIER", 80)
                    .SetIsReadOnly()
                    .SetTextAlignment(TextAlignment.Center);
            grdSpec.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);
            grdSpec.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                   .SetTextAlignment(TextAlignment.Center)
                   .SetDefault("Valid")
                   .SetValidationIsRequired();

            grdSpec.View.PopulateColumns();
        }

        #region Event
        private void InitializeEvent()
        {
            throw new NotImplementedException();
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

                    DataTable dtSpec = await QueryAsync("GetSpecCode", "00001", values);

                    if (dtSpec.Rows.Count < 1)
                    {
                        ShowMessage("NoSelectData");
                    }

                    grdSpec.DataSource = dtSpec;
                }

                #endregion

                #region ToolBar
                /// <summary>
                /// 저장 버튼을 클릭하면 호출한다.
                /// </summary>
                protected override void OnToolbarSaveClick()
                {
                    base.OnToolbarSaveClick();

                    DataTable changed = grdSpec.GetChangedRows();

                   ExecuteRule("SaveSpecCode", changed);
                }
                #endregion

                #region 유효성 검사

                /// <summary>
                /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
                /// </summary>
                protected override void OnValidateContent()
                {
                    base.OnValidateContent();
                    grdSpec.View.CheckValidation();

                    DataTable changed = grdSpec.GetChangedRows();//변경된 row

                    if (changed.Rows.Count == 0)
                    {
                        throw MessageException.Create("NoSaveData");
                    }
                }

                #endregion
        
                #region Private Function

                #endregion
    }
}
