using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System.Data;
using System.Threading.Tasks;

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 항목관리 > 자재관리
    /// 업  무  설  명  : 기준정보 자재목록 조회
    /// 생    성    자  : jylee
    /// 생    성    일  : 2019-04-06
    /// 수  정  이  력  : 2020-05-06 | scmo | ERP연동에 따른 쿼리 및 컬럼변경
    ///                   2020-05-12 | jylee | 제품과 분리, 컬럼추가
    ///                   2020-07-02 | scmo | 1차 통합테스트후 리뷰반영
    /// </summary>
    public partial class MaterialMgt : SmartConditionBaseForm
    {
        public MaterialMgt()
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
            InitializeList();
			InitializeGridMask();
		}

		/// <summary>
		/// 정규식 적용 - 숫자만 입력
		/// </summary>
		private void InitializeGridMask()
		{
			DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repository = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

			repository = grdList.View.Columns["LOTSIZE"].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemTextEdit;
			repository.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			repository.Mask.EditMask = @"\d*";
			repository.Mask.UseMaskAsDisplayFormat = true;
		}

		/// <summary>
		/// 리스트 그리드를 초기화한다.
		/// </summary>
		private void InitializeList()
        {
            grdList.GridButtonItem = GridButtonItem.Export;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetSortOrder("CONSUMABLEDEFID");
            grdList.View.SetAutoFillColumn("ITEMNAME");

            //품번
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFID", 120).SetIsReadOnly().SetIsHidden();

            //품번
            grdList.View.AddTextBoxColumn("PARTNUMBER", 120).SetValidationIsRequired().SetIsReadOnly()
                .SetLabel("CONSUMABLEDEFID");
            
            //버전(HIDDEN)
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFVERSION", 150).SetIsHidden();
            //품명
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 200).SetIsReadOnly();
            //짧은 품명
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFSHORTNAME", 100);
            //규격
            grdList.View.AddTextBoxColumn("STANDARD", 100).SetIsReadOnly();
            //품목자산분류
            grdList.View.AddTextBoxColumn("ITEMASSETCATEGORY", 60).SetIsReadOnly();
            //단위
            grdList.View.AddTextBoxColumn("UNIT", 60).SetIsReadOnly();
            //대분류
            grdList.View.AddTextBoxColumn("LARGECATEGORY", 80).SetIsHidden();
            //중분류
            grdList.View.AddTextBoxColumn("MEDIUMCATEGORY", 80).SetIsHidden();
            //수입검사
            grdList.View.AddComboBoxColumn("IMPORTINSP", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //SERIAL관리
            grdList.View.AddComboBoxColumn("SERIAL", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
            //추적대상
            grdList.View.AddComboBoxColumn("TRACKING", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
            //LOT SIZE
            grdList.View.AddTextBoxColumn("LOTSIZE", 60).SetTextAlignment(TextAlignment.Right);
			//수입검사 검사 기준 이미지
			grdList.View.AddTextBoxColumn("RECEIVINGINSPSTDFILEID").SetIsHidden();
			InitializePopup_ReceivingInspectionStdImage();
			//출하검사 검사 기준 이미지
			grdList.View.AddTextBoxColumn("SHIPPINGINSPSTDFILEID").SetIsHidden();
			InitializePopup_ShippingInspectionStdImage();
            // 무지시 작업여부
            grdList.View.AddComboBoxColumn("ISNOTORDERRESULT", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")).SetTextAlignment(TextAlignment.Center);
            // 무지시 공정
            grdList.View.AddComboBoxColumn("NOTORDERSEGMENTID", 100, new SqlQuery("GetNotOrderSegmentList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}")
                    , "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
                .SetEmptyItem(string.Empty, string.Empty, true);
            //유효상태
            grdList.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
			//생성자
			grdList.View.AddTextBoxColumn("CREATOR", 80).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//생성시간
			grdList.View.AddTextBoxColumn("CREATEDTIME", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//수정자
			grdList.View.AddTextBoxColumn("MODIFIER", 80).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
			//수정시간
			grdList.View.AddTextBoxColumn("MODIFIEDTIME", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);

			grdList.View.PopulateColumns();
        }
        #endregion

		/// <summary>
		/// 팝업형 컬럼 초기화 - 출하검사 기준 이미지
		/// </summary>
		private void InitializePopup_ShippingInspectionStdImage()
		{
			var image = grdList.View.AddSelectPopupColumn("SHIPPINGFILENAME", 120, new InspectionStdImagePopup())
				.SetPopupCustomParameter(
				(ISmartCustomPopup sender, DataRow currentRow) => //초기화 작업
				{
					InspectionStdImagePopup popup = sender as InspectionStdImagePopup;
					popup._fileId = Format.GetFullTrimString(currentRow["SHIPPINGINSPSTDFILEID"]);
					popup._inspectionType = "OutGoingInsp";
				},
				(ISmartCustomPopup sender, DataRow currentRow) => //결과 리턴 작업
				{
					InspectionStdImagePopup popup = sender as InspectionStdImagePopup;
					currentRow["SHIPPINGINSPSTDFILEID"] = popup.CurrentDataRow["FILEID"];
				})
				.SetClearButtonInvisible(false);
		}

		/// <summary>
		/// 팝업형 컬럼 초기화 - 수입검사 기준 이미지
		/// </summary>
		private void InitializePopup_ReceivingInspectionStdImage()
		{
			var image = grdList.View.AddSelectPopupColumn("RECEIVINGFILENAME", 120, new InspectionStdImagePopup())
				.SetPopupCustomParameter(
				(ISmartCustomPopup sender, DataRow currentRow) => //초기화 작업
				{
					InspectionStdImagePopup popup = sender as InspectionStdImagePopup;
					popup._fileId = Format.GetFullTrimString(currentRow["RECEIVINGINSPSTDFILEID"]);
					popup._inspectionType = "ReceiptInsp";
				},
				(ISmartCustomPopup sender, DataRow currentRow) => //결과 리턴 작업
				{
					InspectionStdImagePopup popup = sender as InspectionStdImagePopup;
					currentRow["RECEIVINGINSPSTDFILEID"] = popup.CurrentDataRow["FILEID"];
				})
				.SetClearButtonInvisible(false);
		}

		#region Event
		private void InitializeEvent()
		{
			grdList.View.CellValueChanged += View_CellValueChanged;
            grdList.View.RowCellStyle += View_RowCellStyle;
		}

        /// <summary>
        /// CELL 값 변경 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if(e == null) return;

			if(e.Column.FieldName.Equals("SHIPPINGFILENAME"))
			{
				if(string.IsNullOrWhiteSpace(Format.GetFullTrimString(e.Value)))
				{
					grdList.View.SetRowCellValue(e.RowHandle, "SHIPPINGINSPSTDFILEID", string.Empty);
				}
			}

			if (e.Column.FieldName.Equals("RECEIVINGFILENAME"))
			{
				if (string.IsNullOrWhiteSpace(Format.GetFullTrimString(e.Value)))
				{
					grdList.View.SetRowCellValue(e.RowHandle, "RECEIVINGINSPSTDFILEID", string.Empty);
				}
			}
		}

        // 입력 가능한 컬럼 배경색 다르게 표시
        private void View_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "SERIAL"
                || e.Column.FieldName == "TRACKING"
                || e.Column.FieldName == "LOTSIZE"
                || e.Column.FieldName == "RECEIVINGFILENAME"
                || e.Column.FieldName == "SHIPPINGFILENAME"
                || e.Column.FieldName == "VALIDSTATE"
                || e.Column.FieldName == "CONSUMABLEDEFSHORTNAME"
                || e.Column.FieldName == "ISNOTORDERRESULT"
                || e.Column.FieldName == "NOTORDERSEGMENTID")
            {
                e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                e.Appearance.ForeColor = System.Drawing.Color.Black;
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

			// string[] mateTypes = { "6", "10", "4" };    //원자재그룹
            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtItem = new DataTable();

            dtItem = await QueryAsync("GetConsumableItem", "00001", values);

            if (dtItem.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdList.DataSource = dtItem;
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
            grdList.View.CheckValidation();

            DataTable changed = grdList.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
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

            ExecuteRule("MappingConsumableInfo", changed);
        }
        #endregion
    }
}
