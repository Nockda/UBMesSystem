#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;

#endregion

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 실적관리 > 조립실적 등록 > 팝업 > 자재투입실적 등록
    /// 업  무  설  명  : 자재투입실적을 팝업을 이용해 등록한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-06
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class InputMaterialPopup : SmartPopupBaseForm
    {
        public InputMaterialPopup()
        {
            InitializeComponent();

            InitializeBom();
            InitializeInputMaterial();
        }

        #region 컨텐츠 영역 초기화

        /// <summary>        
        /// BOM 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeBom()
        {
            // 그리드 초기화
            grdBom.GridButtonItem = GridButtonItem.Refresh;

            grdBom.View.SetIsReadOnly();

            grdBom.View.SetSortOrder("자재명");
            grdBom.View.SetAutoFillColumn("자재명");

            grdBom.View.AddTextBoxColumn("자재명", 150);
            grdBom.View.AddTextBoxColumn("구분", 100);
            grdBom.View.AddTextBoxColumn("수량", 100);
            grdBom.View.AddTextBoxColumn("투입", 100);
            grdBom.View.PopulateColumns();
        }

        /// <summary>        
        /// 투입자재 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeInputMaterial()
        {
            // 그리드 초기화
            grdInputMaterial.GridButtonItem = GridButtonItem.Refresh;

            grdInputMaterial.View.SetIsReadOnly();

            grdInputMaterial.View.SetSortOrder("자재코드(명)");
            grdInputMaterial.View.SetAutoFillColumn("특이사항");

            grdInputMaterial.View.AddTextBoxColumn("자재코드(명)", 150);
            grdInputMaterial.View.AddTextBoxColumn("자재LOT", 150);
            grdInputMaterial.View.AddTextBoxColumn("양품", 50);
            grdInputMaterial.View.AddTextBoxColumn("불량", 50);
            grdInputMaterial.View.AddTextBoxColumn("특이사항", 200);
            grdInputMaterial.View.PopulateColumns();
        }

        #endregion
    }
}
