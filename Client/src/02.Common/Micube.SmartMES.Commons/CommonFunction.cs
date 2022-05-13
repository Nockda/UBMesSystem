#region using

using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Micube.Framework.SmartControls.Validations;
using DevExpress.XtraPrinting.Drawing;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Collections;

#endregion

namespace Micube.SmartMES.Commons
{
    /// <summary>
    /// MES 시스템에서 공통으로 사용하는 함수를 관리하는 클래스
    /// </summary>
    public static class CommonFunction
    {
        private static string _DbLinkName;

        private static short printCopies = 1;

        #region ◆ 공통 함수 ::: 

        public static string DbLinkName
        {
            get
            {
               return _DbLinkName;
            }
            set
            {
                _DbLinkName = value;
            }
        }

        #region - ValidationProduct :: 동일 품목코드, 품목버전 체크 |
        /// <summary>
        /// 동일 품목코드, 품목버전 체크
        /// </summary>
        /// <param name="currentGridRow"></param>
        /// <param name="popupSelections"></param>
        /// <returns></returns>
        private static ValidationResultCommon ValidationProduct(DataRow currentGridRow, IEnumerable<DataRow> popupSelections)
        {
            ValidationResultCommon result = new ValidationResultCommon();

            int productDefId = popupSelections.AsEnumerable().Select(r => Format.GetString(r["PRODUCTDEFID"])).Distinct().Count();
            if (productDefId > 1)
            {
                Language.LanguageMessageItem item = Language.GetMessage("MixSelectProductDefID");
                result.IsSucced = false;
                result.FailMessage = item.Message;
                result.Caption = item.Title;
            }

            int productDefVer = popupSelections.AsEnumerable().Select(r => Format.GetString(r["PRODUCTDEFVERSION"])).Distinct().Count();
            if (productDefId == 1 && productDefVer > 1)
            {
                Language.LanguageMessageItem item = Language.GetMessage("MixSelectProductDefVersion");
                result.IsSucced = false;
                result.FailMessage = item.Message;
                result.Caption = item.Title;
            }

            return result;
        }
        #endregion

        #region - setLabelLaungage :: 다국어 명 적용 |
        /// <summary>
        /// 다국어 명 적용
        /// </summary>
        /// <param name="band"></param>
        private static void setLabelLaungage(object band, string strGroupHeader = "GroupHeader1")
        {
            if (band is DetailReportBand)
            {
                DetailReportBand detailReport = band as DetailReportBand;
                Band groupHeader = detailReport.Bands[strGroupHeader];

                foreach (XRControl control in groupHeader.Controls)
                {
                    if (control is DevExpress.XtraReports.UI.XRLabel)
                    {
                        if (!string.IsNullOrEmpty(control.Tag.ToString()))
                        {
                            if (control.Name.Substring(0, 3).Equals("lbl"))
                            {
                                string bindText = Language.Get(control.Tag.ToString());
                                Font ft = BestSizeEstimator.GetFontToFitBounds(control as XRLabel, bindText);
                                if (ft.Size < control.Font.Size)
                                {
                                    control.Font = ft;
                                }

                                control.Text = bindText;
                            }
                        }
                    }
                    else if (control is DevExpress.XtraReports.UI.XRTable)
                    {
                        XRTable xt = control as XRTable;

                        foreach (XRTableRow tr in xt.Rows)
                        {
                            for (int i = 0; i < tr.Cells.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(tr.Cells[i].Tag.ToString()))
                                {
                                    tr.Cells[i].Text = Language.Get(tr.Cells[i].Tag.ToString());

                                }

                            }
                        }

                    }
                }

            }

        }
        #endregion

        #region - changeArgString :: SQL Injection 문자열 대체 |
        /// <summary>
        /// SQL Injection 문자열 대체
        /// </summary>
        /// <param name="sArgStr"></param>
        /// <returns></returns>
        public static string changeArgString(string sArgStr)
        {
            sArgStr = sArgStr.Replace("&quot;", "＂");
            sArgStr = sArgStr.Replace("&lt;", "＜");
            sArgStr = sArgStr.Replace("&gt;", "＞");
            sArgStr = sArgStr.Replace("'", "＇");
            sArgStr = sArgStr.Replace("<", "＜");
            sArgStr = sArgStr.Replace(">", "＞");
            sArgStr = sArgStr.Replace("--", "――");
            sArgStr = sArgStr.Replace("&", "＆");
            sArgStr = sArgStr.Replace(";", "；");
            //sArgStr = sArgStr.Replace("*", "＊");
            //sArgStr = sArgStr.Replace("%", "％");
            sArgStr = sArgStr.Replace("+", "＋");
            sArgStr = sArgStr.Replace("=", "＝");
            sArgStr = sArgStr.Replace("\"", "＂");
            sArgStr = sArgStr.Replace("\\", "￦");
            sArgStr = sArgStr.Replace("^", "＾");
            sArgStr = sArgStr.Replace("?", "？");
            sArgStr = sArgStr.Replace("!", "！");
            sArgStr = sArgStr.Replace("@", "＠");
            sArgStr = sArgStr.Replace(",", "，");

            return sArgStr;
        }
        #endregion

        #region - TableDataDivide :: stdCnt부터 interval 간격으로 데이터 나눔 |
        /// <summary>
        /// stdCnt부터 interval 간격으로 데이터 나눔
        /// </summary>
        /// <param name="target"></param>
        /// <param name="standard"></param>
        /// <param name="stdCnt"></param>
        /// <returns></returns>
        private static DataTable TableDataDivide(DataTable target, DataTable input, int stdCnt, int interval)
        {
            for (int i = stdCnt; i < (stdCnt + interval); i++)
            {
                DataRow newRow = input.NewRow();
                newRow.ItemArray = target.Rows[i].ItemArray;
                input.Rows.Add(newRow);
            }

            return input;
        }
        #endregion

        #region - SendEmail :: 검사 결과 등록 후 SendEmail actionType 있을경우 이메일 전송 팝업  |

        /// <summary>
        /// 서버에서 반환받은 값으로 Email popup 보여주는 함수
        /// (isSendEmail == true 일때 호출)
        /// 강유라 2019-12-05 이메일 함수 추가 
        /// </summary>
        /// <param name="contents"></param>
        public static void ShowSendEmailPopup(string title, string contents)
        {
            SendInspectionMailPopup mailPopup = new SendInspectionMailPopup();
            mailPopup.TopMost = true;
            mailPopup.StartPosition = FormStartPosition.CenterParent;
            mailPopup.setTitleAndContents(title, contents);

            mailPopup.ShowDialog();
        }
        #endregion

        public static string generateLikeState(string param)
        {
            string[] paramter = param.Split(',');

            string returnParam = string.Empty;

            foreach (string temp in paramter)
            {
                returnParam = returnParam + string.Format("%{0}%,", temp);
            }

            return returnParam.TrimEnd(',')
                ;
        }

        #region -마이그랏 화면에서 분할 채번할 경우 사용
        public static string CreateNewLotid(string MigLot, string materialClass, string materialSequence)
        {
            //20190510 039 0 1A7 0 038 0
            string date = MigLot.Substring(2, 6);

            string inputseq = MigLot.Substring(9, 3);
            string reinputseq = MigLot.Substring(15, 1);
            string lotseq = MigLot.Substring(16, 3);
            string splitseq = MigLot.Substring(MigLot.Length - 1, 1);
            string plantCode = string.Empty;
            switch (UserInfo.Current.Plant)
            {
                case Constants.IFC:
                    plantCode = "F";
                    break;
                case Constants.IFV:
                    plantCode = "V";
                    break;
                case Constants.CCT:
                    plantCode = "C";
                    break;
                case Constants.YPE:
                    plantCode = "Y";
                    break;
                case Constants.YPEV:
                    plantCode = "P";
                    break;

            }
            reinputseq = (int.Parse(reinputseq) + 1).ToString();
            splitseq = (int.Parse(splitseq) + 1).ToString().PadLeft(3, '0');

            return string.Format("{0}{1}{2}-{3}-{4}-{5}-{6}", date, plantCode, inputseq, reinputseq, materialClass + materialSequence, lotseq, splitseq);
        }
        #endregion

        #region - 컨트롤의 Tag 값에 맞춰 row 데이터 바인드
        public static void BindDataToControlsTag(DataRow r, Control ctl)
        {
            if (r == null) return;

            switch (ctl.GetType().Name)
            {
                case "SmartTextBox":
                    SmartTextBox txt = ctl as SmartTextBox;
                    if (!string.IsNullOrEmpty(Format.GetFullTrimString(txt.Tag)))
                    {
                        if (r.Table.Columns.Contains(Format.GetFullTrimString(txt.Tag)))
                        {
                            txt.EditValue = r[Format.GetFullTrimString(txt.Tag)];
                        }
                    }
                    break;
                case "SmartComboBox":
                    SmartComboBox cbo = ctl as SmartComboBox;
                    if (!string.IsNullOrEmpty(Format.GetFullTrimString(cbo.Tag)))
                    {
                        if (r.Table.Columns.Contains(Format.GetFullTrimString(cbo.Tag)))
                        {
                            cbo.EditValue = r[Format.GetFullTrimString(cbo.Tag)];
                        }
                    }
                    break;
                case "SmartSpinEdit":
                    SmartSpinEdit spin = ctl as SmartSpinEdit;
                    if (!string.IsNullOrEmpty(Format.GetString(spin.Tag)))
                    {
                        if (r.Table.Columns.Contains(Format.GetString(spin.Tag)))
                        {
                            spin.EditValue = r[Format.GetString(spin.Tag)];
                        }
                    }
                    break;
				case "SmartLabel":
					SmartLabel lbl = ctl as SmartLabel;
					if (!string.IsNullOrEmpty(Format.GetString(lbl.Tag)))
					{
						if (r.Table.Columns.Contains(Format.GetString(lbl.Tag)))
						{
							lbl.Text = Format.GetString(r[Format.GetString(lbl.Tag)]);
						}
					}
					break;
                case "SmartMemoEdit":
                    SmartMemoEdit memo = ctl as SmartMemoEdit;
                    if (!string.IsNullOrEmpty(Format.GetString(memo.Tag)))
                    {
                        if (r.Table.Columns.Contains(Format.GetString(memo.Tag)))
                        {
                            memo.Text = Format.GetString(r[Format.GetString(memo.Tag)]);
                        }
                    }
                    break;
                case "SmartDateEdit":
                    SmartDateEdit date = ctl as SmartDateEdit;
                    if (!string.IsNullOrEmpty(Format.GetString(date.Tag)))
                    {
                        if (r.Table.Columns.Contains(Format.GetString(date.Tag)))
                        {
                            date.EditValue = r[Format.GetString(date.Tag)];
                        }
                    }
                    break;
            }

            foreach (Control c in ctl.Controls)
            {
                BindDataToControlsTag(r, c);
            }

            r.AcceptChanges();
        }
		#endregion

		#region - 파일 변환 함수
		/// <summary>
		/// File To byte[]
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static byte[] FileToByteArray(string path)
		{
			byte[] fileBytes = null;
			try
			{
				using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					fileBytes = new byte[fileStream.Length];
					fileStream.Read(fileBytes, 0, fileBytes.Length);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

			return fileBytes;
		}

		/// <summary>
		/// byte[] To File
		/// </summary>
		/// <param name="path"></param>
		/// <param name="buffer"></param>
		/// <returns></returns>
		public static bool ByteArrayToFile(string path, byte[] bytes)
		{
			try
			{
				using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
				{
					fs.Write(bytes, 0, bytes.Length);
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
		}
		#endregion

		#endregion

		#region ◆ 팝업창 및 CodeHelp :::

		#region - AddConditionProductPopup :: 검색조건에 품목 선택 팝업을 추가한다. |
		/// <summary>
		/// 검색조건에 품목 선택 팝업을 추가한다.
		/// </summary>
		/// <param name="id">검색조건 항목에 지정할 ID</param>
		/// <param name="position">검색조건을 추가할 순서</param>
		/// <param name="isMultiSelect">항목 복수 선택 여부</param>
		/// <param name="conditions">화면에서 사용되는 검색조건 컬렉션</param>
		/// <returns></returns>
		public static ConditionCollection AddConditionProductPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions, string displayFieldName = "PRODUCTDEFNAME")
        {
            // SelectPopup 항목 추가
            var conditionProductId = conditions.AddSelectPopup(id, new SqlQuery("GetProductDefinitionList", "10001", $"PLANTID={UserInfo.Current.Plant}"), displayFieldName, "PARTNUMBER")
                .SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(800, 800)
                .SetPopupAutoFillColumns("UNIT")
                .SetLabel("PRODUCTDEFID")
                .SetPosition(position);

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionProductId.SetPopupResultCount(0);
            else
                conditionProductId.SetPopupResultCount(1);

            // 팝업에서 사용되는 검색조건 (품목코드/명)
            conditionProductId.Conditions.AddTextBox("TXTPRODUCTDEFNAME");
            //제품 구분 추가 2019.08.14 배선용, 노석안 대리 요청
            conditionProductId.Conditions.AddComboBox("P_PRODUCTDEFTYPE", new SqlQuery("GetCodeList", "00001", $"CODECLASSID=ProductDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CODENAME", "CODEID")
                .SetEmptyItem()
                .SetLabel("PRODUCTDEFTYPE");

            // 팝업 그리드에서 보여줄 컬럼 정의
            // 품목코드
            conditionProductId.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 150).SetIsHidden();
            // 품목명
            conditionProductId.GridColumns.AddTextBoxColumn("PARTNUMBER", 150).SetLabel("PRODUCTDEFID");
            conditionProductId.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200);
            // 품목버전
            // 품목유형구분
            conditionProductId.GridColumns.AddComboBoxColumn("PRODUCTDEFTYPE", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ProductDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
            // 단위
            conditionProductId.GridColumns.AddComboBoxColumn("UNIT", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=Unit", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));

            return conditions;
        }
        #endregion

        #region - AddConditionAllItemPopup :: 검색조건에 모든 품목 선택 팝업을 추가한다. |
        /// <summary>
        /// 검색조건에 품목 선택 팝업을 추가한다.
        /// </summary>
        /// <param name="id">검색조건 항목에 지정할 ID</param>
        /// <param name="position">검색조건을 추가할 순서</param>
        /// <param name="isMultiSelect">항목 복수 선택 여부</param>
        /// <param name="conditions">화면에서 사용되는 검색조건 컬렉션</param>
        /// <returns></returns>
        public static ConditionCollection AddConditionAllItemPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions, string displayFieldName = "PRODUCTDEFNAME")
        {
            // SelectPopup 항목 추가
            var conditionProductId = conditions.AddSelectPopup(id, new SqlQuery("GetAllItemDefinitionList", "00001", $"PLANTID={UserInfo.Current.Plant}"), displayFieldName, "PRODUCTDEFID")
                .SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(800, 800)
                .SetPopupAutoFillColumns("UNIT")
                .SetLabel("PRODUCTDEFID")
                .SetPosition(position);

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionProductId.SetPopupResultCount(0);
            else
                conditionProductId.SetPopupResultCount(1);

            // 팝업에서 사용되는 검색조건 (품목코드/명)
            conditionProductId.Conditions.AddTextBox("TXTPRODUCTDEFNAME");
            //제품 구분 추가 2019.08.14 배선용, 노석안 대리 요청
            conditionProductId.Conditions.AddComboBox("P_PRODUCTDEFTYPE", new SqlQuery("GetCodeList", "00001", $"CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CODENAME", "CODEID")
                //.SetDefault("Product")
                // 품목 구분 유형에 전체조회 추가 2021.08.26 주시은
                .SetEmptyItem()
                .SetLabel("PRODUCTDEFTYPE");

            // 팝업 그리드에서 보여줄 컬럼 정의
            // 품목코드
            conditionProductId.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 150);
            // 품목명
            conditionProductId.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200);
            // 품목버전
            // 품목유형구분
            conditionProductId.GridColumns.AddComboBoxColumn("PRODUCTDEFTYPE", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
            // 단위
            conditionProductId.GridColumns.AddComboBoxColumn("UNIT", 90, new SqlQuery("GetUnitList", "00001"));

            return conditions;
        }
        #endregion

        #region - ConditionReworkRouting :: ReworkRouting 검색 팝업 |
        /// <summary>
        /// ReworkRouting 검색 팝업
        /// </summary>
        /// <param name="isMultiSelect"></param>
        /// <param name="lotid"></param>
        /// <returns></returns>
        public static ConditionItemSelectPopup ConditionReworkRouting(bool isMultiSelect, string lotid)
        {
            // SelectPopup 항목 추가
            ConditionItemSelectPopup options = new ConditionItemSelectPopup();

            options.SetPopupLayoutForm(800, 1000, FormBorderStyle.Sizable);
            options.SetPopupLayout("REWORKROUTING", PopupButtonStyles.Ok_Cancel, true, true);
            options.Id = "REWORK";
            options.SearchQuery = new SqlQuery("SelectReworkRouting", "10001", $"PLANTID={UserInfo.Current.Plant}", $"P_LOTID={lotid}", $"LANGUAGETYPE={UserInfo.Current.LanguageType}");
            options.IsMultiGrid = isMultiSelect;
            options.DisplayFieldName = "REWORKNAME";
            options.ValueFieldName = "REWORKNUMBER";
            options.LanguageKey = "REWORKPROCESSID";

            options.Conditions.AddComboBox("PROCESSCLASS", new SqlQuery("GetTypeList", "10001", $"CODECLASSID=ProcessClassType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CODENAME", "CODEID")
                                        .SetDefault("Process");

            options.GridColumns.AddTextBoxColumn("APPLICATIONTYPE", 70);
            options.GridColumns.AddTextBoxColumn("REWORKTYPE", 70);
            options.GridColumns.AddTextBoxColumn("TOPPROCESSSEGMENTID", 70);
            options.GridColumns.AddTextBoxColumn("REWORKNUMBER", 100);
            options.GridColumns.AddTextBoxColumn("REWORKVERSION", 50);
            options.GridColumns.AddTextBoxColumn("REWORKNAME", 100);

            return options;
        }
        #endregion

        #region - AddConditionProductDistinctPopup :: 검색조건에 품목 선택 팝업을 추가한다 |
        /// <summary>
        /// 검색조건에 품목 선택 팝업을 추가한다.
        /// </summary>
        /// <param name="id">검색조건 항목에 지정할 ID</param>
        /// <param name="position">검색조건을 추가할 순서</param>
        /// <param name="isMultiSelect">항목 복수 선택 여부</param>
        /// <param name="conditions">화면에서 사용되는 검색조건 컬렉션</param>
        /// <returns></returns>
        public static ConditionCollection AddConditionProductDistinctPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions)
        {
            // SelectPopup 항목 추가
            var conditionProductId = conditions.AddSelectPopup(id, new SqlQuery("GetProductDefinitionList", "10003", $"PLANTID={UserInfo.Current.Plant}"), "PRODUCTDEFNAME", "PRODUCTDEFID")
                .SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(800, 800)
                .SetPopupAutoFillColumns("UNIT")
                .SetLabel("PRODUCTDEFID")
                .SetPosition(position);

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionProductId.SetPopupResultCount(0);
            else
                conditionProductId.SetPopupResultCount(1);

            // 팝업에서 사용되는 검색조건 (품목코드/명)
            conditionProductId.Conditions.AddTextBox("TXTPRODUCTDEFNAME");
            //제품 구분 추가 2019.08.14 배선용, 노석안 대리 요청
            conditionProductId.Conditions.AddComboBox("PRODUCTDIVISION", new SqlQuery("GetTypeList", "10001", $"CODECLASSID=ProductDivision2", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CODENAME", "CODEID")
                                        .SetDefault("Product");

            // 팝업 그리드에서 보여줄 컬럼 정의
            // 품목코드
            conditionProductId.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 150);
            // 품목명
            conditionProductId.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200);
            // 품목유형구분
            conditionProductId.GridColumns.AddComboBoxColumn("PRODUCTDEFTYPE", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ProductDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
            // 생산구분
            conditionProductId.GridColumns.AddComboBoxColumn("PRODUCTIONTYPE", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ProductionType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
            // 단위
            conditionProductId.GridColumns.AddComboBoxColumn("UNIT", 90, new SqlQuery("GetUomDefinitionList", "10001", "UOMCLASSID=Segment"), "UOMDEFNAME", "UOMDEFID");



            return conditions;
        }
        #endregion

        #region - AddConditionAreaPopup :: 작업장 조회 팝업 |
        /// <summary>
        /// 작업장 조회 팝업
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position"></param>
        /// <param name="isMultiSelect"></param>
        /// <param name="conditions"></param>
        /// <param name="IsRequired"></param>
        /// <returns></returns>
        public static ConditionCollection AddConditionAreaPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions, bool IsRequired = false)
        {
            // SelectPopup 항목 추가
            var conditionAreaId = conditions.AddSelectPopup(id, new SqlQuery("GetAreaList", "10003", $"ENTERPRISEID={UserInfo.Current.Enterprise}", $"PLANTID={UserInfo.Current.Plant}", "AREATYPE=Area", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "AREANAME", "AREAID")
                .SetPopupLayout("SELECTAREAID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(800, 800)
                .SetLabel("AREAID")
                .SetPosition(position);

            conditionAreaId.IsRequired = IsRequired;
            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionAreaId.SetPopupResultCount(0);
            else
                conditionAreaId.SetPopupResultCount(1);


            conditionAreaId.Conditions.AddTextBox("TXTAREA");

            conditionAreaId.GridColumns.AddTextBoxColumn("AREAID", 150);
            conditionAreaId.GridColumns.AddTextBoxColumn("AREANAME", 200);


            return conditions;
        }
        #endregion

        #region - AddConditionProcessSegmentPopup :: 팝업형 조회조건 - 공정 |
        /// <summary>
        /// 팝업형 조회조건 - 공정
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position"></param>
        /// <param name="isMultiSelect"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static ConditionCollection AddConditionProcessSegmentPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions)
        {
            var processSegmentIdPopup = conditions.AddSelectPopup(id, new SqlQuery("GetProcessSegmentList", "10002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", "PROCESSSEGMENTCLASSTYPE=MiddleProcessSegmentClass"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
                .SetPopupLayout(Language.Get("SELECTPROCESSSEGMENTID"), PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupLayoutForm(800, 800)
                .SetPopupAutoFillColumns("PROCESSSEGMENTNAME")
                .SetLabel("PROCESSSEGMENT")
                .SetPosition(position);

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                processSegmentIdPopup.SetPopupResultCount(0);
            else
                processSegmentIdPopup.SetPopupResultCount(1);

            processSegmentIdPopup.Conditions.AddComboBox("PROCESSSEGMENTCLASSID_MIDDLE", new SqlQuery("GetProcessSegmentClassByType", "10001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", "PROCESSSEGMENTCLASSTYPE=MiddleProcessSegmentClass"), "PROCESSSEGMENTCLASSNAME", "PROCESSSEGMENTCLASSID")
                .SetLabel("MIDDLEPROCESSSEGMENT")
                .SetEmptyItem();
            processSegmentIdPopup.Conditions.AddTextBox("PROCESSSEGMENT");


            processSegmentIdPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTCLASSNAME_TOP", 150)
                .SetLabel("LARGEPROCESSSEGMENT");
            processSegmentIdPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTCLASSNAME_MIDDLE", 150)
                .SetLabel("MIDDLEPROCESSSEGMENT");
            processSegmentIdPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150);
            processSegmentIdPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);

            return conditions;
        }
        #endregion

        #region - AddConditionProcessSegmentPopup :: 팝업형 조회조건 - 공정 |
        /// <summary>
        /// 팝업형 조회조건 - 공정
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position"></param>
        /// <param name="strLabelName"></param>
        /// <param name="isMultiSelect"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static ConditionCollection AddConditionProcessSegmentPopup(string id, double position, string strLabelName, bool isMultiSelect, ConditionCollection conditions)
        {
            var processSegmentIdPopup = conditions.AddSelectPopup(id, new SqlQuery("GetProcessSegmentList", "10002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", "PROCESSSEGMENTCLASSTYPE=MiddleProcessSegmentClass"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
                .SetPopupLayout(Language.Get("SELECTPROCESSSEGMENTID"), PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupLayoutForm(800, 800)
                .SetPopupAutoFillColumns("PROCESSSEGMENTNAME")
                .SetLabel(strLabelName)
                .SetPosition(position);

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                processSegmentIdPopup.SetPopupResultCount(0);
            else
                processSegmentIdPopup.SetPopupResultCount(1);

            processSegmentIdPopup.Conditions.AddComboBox("PROCESSSEGMENTCLASSID_MIDDLE", new SqlQuery("GetProcessSegmentClassByType", "10001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", "PROCESSSEGMENTCLASSTYPE=MiddleProcessSegmentClass"), "PROCESSSEGMENTCLASSNAME", "PROCESSSEGMENTCLASSID")
                .SetLabel("MIDDLEPROCESSSEGMENT")
                .SetEmptyItem();
            processSegmentIdPopup.Conditions.AddTextBox("PROCESSSEGMENT");


            processSegmentIdPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTCLASSNAME_TOP", 150)
                .SetLabel("LARGEPROCESSSEGMENT");
            processSegmentIdPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTCLASSNAME_MIDDLE", 150)
                .SetLabel("MIDDLEPROCESSSEGMENT");
            processSegmentIdPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150);
            processSegmentIdPopup.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);

            return conditions;
        }
        #endregion

        #region - AddConditionBriefLotPopup :: 검색조건에 Lot No 선택 팝업을 추가 |
        /// <summary>
        /// 검색조건에 Lot No 선택 팝업을 추가한다.
        /// </summary>
        /// <param name="id">검색조건 항목에 지정할 ID</param>
        /// <param name="position">검색조건을 추가할 순서</param>
        /// <param name="isMultiSelect">항목 복수 선택 여부</param>
        /// <param name="conditions">화면에서 사용되는 검색조건 컬렉션</param>
        /// <param name="processSegmentType">공정 구분</param>
        /// <returns></returns>
        public static ConditionCollection AddConditionBriefLotPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions, bool isValidation = false)
        {
            // SelectPopup 항목 추가
            var conditionLotId = conditions.AddSelectPopup(id, new SqlQuery("GetSelectBriefLotListPopup", "10001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "LOTID", "LOTID")
                .SetPopupLayout("SELECTLOTNO", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(1200, 800)
                .SetLabel("LOTID")
                .SetPosition(position)
                .SetSearchTextControlId("TXTLOTID");

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionLotId.SetPopupResultCount(0);
            else
                conditionLotId.SetPopupResultCount(1);

            //validation
            if (isValidation)
                conditionLotId.SetPopupValidationCustom(ValidationProduct);


            // 팝업에서 사용되는 검색조건
            var conditionProductdef = conditionLotId.Conditions.AddSelectPopup("TXTPRODUCTDEFNAME2", new SqlQuery("GetProductionOrderIdListOfLotInput", "10001", $"PLANTID={UserInfo.Current.Plant}", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PRODUCTDEFNAME", "PRODUCTDEFID")
                .SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(600, 800)
                .SetLabel("PRODUCTDEF")
                .SetPopupResultCount(1)
                .SetPopupAutoFillColumns("PRODUCTDEFNAME");

            conditionProductdef.Conditions.AddTextBox("TXTPRODUCTDEFNAME2");

            conditionProductdef.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 150);
            conditionProductdef.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200);

            // 품목코드/명
            conditionLotId.Conditions.AddTextBox("TXTPRODUCTDEFIDNAME")
                .SetLabel("TXTPRODUCTDEFNAME");
            // Lot No
            conditionLotId.Conditions.AddTextBox("TXTLOTID")
                .SetLabel("LOTID");


            var conditionProcessSegment = conditionLotId.Conditions.AddSelectPopup("TXTPROCESSSEGMENT", new SqlQuery("GetProcessSegmentList", "10001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
                .SetPopupLayout("SELECTPROCESSSEGMENT", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(600, 800)
                .SetLabel("PROCESSSEGMENT")
                .SetPopupResultCount(1)
                .SetPopupAutoFillColumns("PROCESSSEGMENTNAME");

            conditionProcessSegment.Conditions.AddTextBox("PROCESSSEGMENT");

            conditionProcessSegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150);
            conditionProcessSegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);

            //사이트
            conditionLotId.GridColumns.AddTextBoxColumn("PLANTID", 60);
            // Lot No
            conditionLotId.GridColumns.AddTextBoxColumn("LOTID", 200);
            // 양산구분
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTIONTYPE", 60);
            //품목코드
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 100);
            //품목리비전
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTREVISION", 50);
            //품목명
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 150);
            //공정명
            conditionLotId.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 100);
            //공정수순
            conditionLotId.GridColumns.AddTextBoxColumn("USERSEQUENCE", 60);
            //roll/sheet
            conditionLotId.GridColumns.AddTextBoxColumn("RTRSHT", 60);
            //공정진행상태
            conditionLotId.GridColumns.AddTextBoxColumn("PROCESSSTATE", 70);
            //PCS
            conditionLotId.GridColumns.AddTextBoxColumn("PCS", 50);
            //PNL
            conditionLotId.GridColumns.AddTextBoxColumn("PNL", 50);
            return conditions;
        }
        #endregion

        #region - AddConditionLotPopup :: 검색조건에 Lot No 선택 팝업을 추가한다. |
        /// <summary>
        /// 검색조건에 Lot No 선택 팝업을 추가한다.
        /// </summary>
        /// <param name="id">검색조건 항목에 지정할 ID</param>
        /// <param name="position">검색조건을 추가할 순서</param>
        /// <param name="isMultiSelect">항목 복수 선택 여부</param>
        /// <param name="conditions">화면에서 사용되는 검색조건 컬렉션</param>
        /// <param name="processSegmentType">공정 구분</param>
        /// <returns></returns>
        public static ConditionCollection AddConditionLotPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions, string processSegmentType = "", bool isValidation = false)
        {
            // SelectPopup 항목 추가
            var conditionLotId = conditions.AddSelectPopup(id, new SqlQuery("GetLotIdList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"PROCESSSEGMENTTYPE={processSegmentType}"), "LOTID", "LOTID")
                .SetPopupLayout("SELECTLOTNO", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(800, 800)
                .SetLabel("LOTID")
                .SetPosition(position)
                .SetSearchTextControlId("TXTLOTID").
				SetPopupAutoFillColumns("PRODUCTDEFNAME");

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionLotId.SetPopupResultCount(0);
            else
                conditionLotId.SetPopupResultCount(1);

            //validation
            if (isValidation)
                conditionLotId.SetPopupValidationCustom(ValidationProduct);


            // 팝업에서 사용되는 검색조건
            var conditionProductdef = conditionLotId.Conditions.AddSelectPopup("TXTPRODUCTDEFNAME2", new SqlQuery("GetProductDefinitionList", "10001", $"PLANTID={UserInfo.Current.Plant}", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PRODUCTDEFNAME", "PRODUCTDEFID")
                .SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(600, 800)
                .SetLabel("PRODUCTDEFID")
                .SetPopupResultCount(1)
                .SetPopupAutoFillColumns("PRODUCTDEFNAME");

            conditionProductdef.Conditions.AddTextBox("TXTPRODUCTDEFNAME");

            conditionProductdef.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 150);
            conditionProductdef.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200);

            // 품목코드/명
            conditionLotId.Conditions.AddTextBox("TXTPRODUCTDEFIDNAME").SetLabel("TXTPRODUCTDEFNAME");
            // Lot No
            conditionLotId.Conditions.AddTextBox("TXTLOTID").SetLabel("LOTID");

            // 고객사
            //conditionLotId.Conditions.AddComboBox("CBOCUSTOMER", new SqlQuery("GetCustomerList", "10001", $"ENTERPRISEID={UserInfo.Current.Enterprise}", $"PLANTID={UserInfo.Current.Plant}"), "CUSTOMERNAME", "CUSTOMERID")
            //    .SetLabel("CUSTOMER")
            //    .SetEmptyItem()
            //    .SetResultCount(0);

            // 사업부
            //conditionLotId.Conditions.AddComboBox("CBOFACTORY", new SqlQuery("GetFactoryList", "10001", $"ENTERPRISEID={UserInfo.Current.Enterprise}", $"PLANTID={UserInfo.Current.Plant}"), "FACTORYNAME", "FACTORYID")
            //    .SetLabel("BUSINESS")
            //    .SetResultCount(1);
            // 작업장
            //conditionLotId.Conditions.AddComboBox("CBOWORKPLACE", new SqlQuery("GetAreaList", "10003", $"ENTERPRISEID={UserInfo.Current.Enterprise}", $"PLANTID={UserInfo.Current.Plant}"), "AREANAME", "AREAID")
            //    .SetLabel("WORKPLACE")
            //    .SetResultCount(0)
            //    .SetRelationIds("CBOFACTORY");
            // 공정

            var conditionProcessSegment = conditionLotId.Conditions.AddSelectPopup("TXTPROCESSSEGMENT", new SqlQuery("GetProcessSegmentList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
                .SetPopupLayout("SELECTPROCESSSEGMENT", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(600, 800)
                .SetLabel("PROCESSSEGMENT")
                .SetPopupResultCount(1)
                .SetPopupAutoFillColumns("PROCESSSEGMENTNAME");

            conditionProcessSegment.Conditions.AddTextBox("P_PROCESSSEGMENTTXT").SetLabel("PROCESSSEGMENT");

            conditionProcessSegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150);
            conditionProcessSegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);
            // 상태구분
            //conditionLotId.Conditions.AddComboBox("CBOLOTSTATE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=LotState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
            //    .SetLabel("LOTSTATE")
            //    .SetResultCount(1);
            /*
             * 
             * 
             * 
             * 
             * 검색조건 AddComboBox 시 에러발생 (개체참조 에러)
             * 
             * 
             * 
            // 양산구분
            conditionLotId.Conditions.AddComboBox("CBOPRODUCTIONTYPE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=ProductionType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("PRODUCTIONTYPE")
                .SetEmptyItem()
                .SetResultCount(0);
            // RTR/SHT
            conditionLotId.Conditions.AddComboBox("CBORTRSHT", new SqlQuery("GetCodeList", "00001", "CODECLASSID=RTRSHT", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("RTRSHT")
                .SetEmptyItem()
                .SetResultCount(1);
            */
            // 작업구분
            //conditionLotId.Conditions.AddComboBox("CBOWORKTYPE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=WorkType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
            //    .SetLabel("WORKTYPE")
            //    .SetResultCount(1);
            // 대공정
            //conditionLotId.Conditions.AddComboBox("CBOTOPPROCESS", new SqlQuery("GetProcessSegmentClassByType", "10001", "PROCESSSEGMENTCLASSTYPE=TopProcessSegmentClass"), "PROCESSSEGMENTCLASSNAME", "PROCESSSEGMENTCLASSID")
            //    .SetLabel("TOPPROCESSSEGMENTCLASS")
            //    .SetEmptyItem()
            //    .SetResultCount(1);
            //// 중공정
            //conditionLotId.Conditions.AddComboBox("CBOMIDDLEPROCESS", new SqlQuery("GetProcessSegmentClassByType", "10001", "PROCESSSEGMENTCLASSTYPE=MiddleProcessSegmentClass"), "PROCESSSEGMENTCLASSNAME", "PROCESSSEGMENTCLASSID")
            //    .SetLabel("MIDDLEPROCESSSEGMENTCLASS")
            //    .SetEmptyItem()
            //    .SetResultCount(1);

            // 팝업 그리드에서 보여줄 컬럼 정의
            // Lot No
            conditionLotId.GridColumns.AddTextBoxColumn("LOTID", 90);
            // 양산구분
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFTYPE", 70);
            // 품목코드
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 100);
            // 품목버전
            //conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFVERSION", 80);
            // 품목명
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 150);
			// 공정
			conditionLotId.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 100);
			// 수량
			conditionLotId.GridColumns.AddSpinEditColumn("QTY", 60).SetTextAlignment(Framework.SmartControls.TextAlignment.Right);

			/*
            // 라우팅
            conditionLotId.GridColumns.AddComboBoxColumn("PROCESSDEFID", 100, new SqlQuery("GetProcessDefinition", "1"), "PROCESSDEFNAME", "PROCESSDEFID");
            // 공정
            conditionLotId.GridColumns.AddComboBoxColumn("PROCESSSEGMENTID", 100, new SqlQuery("GetProcessSegmentList", "10001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID");
            // 순서
            conditionLotId.GridColumns.AddTextBoxColumn("USERSEQUENCE", 70);
            // Site
            conditionLotId.GridColumns.AddComboBoxColumn("PLANTID", 90, new SqlQuery("GetPlantList", "10002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"ENTERPRISEID={UserInfo.Current.Enterprise}"), "PLANTNAME", "PLANTID");
            // 작업장
            conditionLotId.GridColumns.AddComboBoxColumn("AREAID", 90, new SqlQuery("GetAreaList", "10003", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "AREANAME", "AREAID");
            // Roll/Sheet
            conditionLotId.GridColumns.AddComboBoxColumn("RTRSHT", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=RTRSHT", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
            // 단위
            conditionLotId.GridColumns.AddComboBoxColumn("UNIT", 90, new SqlQuery("GetUomDefinitionList", "10001", "UOMCLASSID=Segment"), "UOMDEFNAME", "UOMDEFID");
            // 수량
            conditionLotId.GridColumns.AddSpinEditColumn("QTY", 90);
            // PCS 수량
            conditionLotId.GridColumns.AddSpinEditColumn("PCSQTY", 90);
            // PNL 수량
            conditionLotId.GridColumns.AddSpinEditColumn("PANELQTY", 90);
            // M2 수량
            conditionLotId.GridColumns.AddSpinEditColumn("M2QTY", 90);
            // 납기계획일
            conditionLotId.GridColumns.AddDateEditColumn("PLANENDTIME", 100)
                .SetDisplayFormat("yyyy-MM-dd");
            // 기한
            conditionLotId.GridColumns.AddSpinEditColumn("LEFTDATE", 70);
            // 인수 Step PCS 수량
            conditionLotId.GridColumns.AddSpinEditColumn("RECEIVEPCSQTY", 90);
            // 인수 Step PNL 수량
            conditionLotId.GridColumns.AddSpinEditColumn("RECEIVEPANELQTY", 90);
            // 시작 Step PCS 수량
            conditionLotId.GridColumns.AddSpinEditColumn("WORKSTARTPCSQTY", 90);
            // 시작 Step PNL 수량
            conditionLotId.GridColumns.AddSpinEditColumn("WORKSTARTPANELQTY", 90);
            // 완료 Step PCS 수량
            conditionLotId.GridColumns.AddSpinEditColumn("WORKENDPCSQTY", 90);
            // 완료 Step PNL 수량
            conditionLotId.GridColumns.AddSpinEditColumn("WORKENDPANELQTY", 90);
            // 인계 Step PCS 수량
            conditionLotId.GridColumns.AddSpinEditColumn("SENDPCSQTY", 90);
            // 인계 Step PNL 수량
            conditionLotId.GridColumns.AddSpinEditColumn("SENDPANELQTY", 90);
            // 공정 Lead Time
            conditionLotId.GridColumns.AddTextBoxColumn("LEADTIME", 90);
			*/


			return conditions;
        }
        #endregion

        #region  - AddConditionLotHistPopup :: 검색조건에 Lot No 선택 팝업을 추가한다. |
        /// <summary>
        /// 검색조건에 Lot No 선택 팝업을 추가한다.
        /// </summary>
        /// <param name="id">검색조건 항목에 지정할 ID</param>
        /// <param name="position">검색조건을 추가할 순서</param>
        /// <param name="isMultiSelect">항목 복수 선택 여부</param>
        /// <param name="conditions">화면에서 사용되는 검색조건 컬렉션</param>
        /// <param name="processSegmentType">공정 구분</param>
        /// <returns></returns>
        public static ConditionCollection AddConditionLotHistPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions, string processSegmentType = "", bool isValidation = false)
        {
            // SelectPopup 항목 추가
            var conditionLotId = conditions.AddSelectPopup(id, new SqlQuery("GetLotIdList", "10002", $"PROCESSSEGMENTTYPE={processSegmentType}"), "LOTID", "LOTID")
                .SetPopupLayout("SELECTLOTNO", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(1200, 800)
                .SetLabel("LOTID")
                .SetPosition(position)
                .SetSearchTextControlId("TXTLOTID");

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionLotId.SetPopupResultCount(0);
            else
                conditionLotId.SetPopupResultCount(1);

            //validation
            if (isValidation)
                conditionLotId.SetPopupValidationCustom(ValidationProduct);


            // 팝업에서 사용되는 검색조건
            var conditionProductdef = conditionLotId.Conditions.AddSelectPopup("TXTPRODUCTDEFNAME2", new SqlQuery("GetProductionOrderIdListOfLotInput", "10001", $"PLANTID={UserInfo.Current.Plant}", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PRODUCTDEFNAME", "PRODUCTDEFID")
                .SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(600, 800)
                .SetLabel("PRODUCTDEF")
                .SetPopupResultCount(1)
                .SetPopupAutoFillColumns("PRODUCTDEFNAME");

            conditionProductdef.Conditions.AddTextBox("TXTPRODUCTDEFNAME2");

            conditionProductdef.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 150);
            conditionProductdef.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200);

            // 품목코드/명
            conditionLotId.Conditions.AddTextBox("TXTPRODUCTDEFIDNAME")
                .SetLabel("TXTPRODUCTDEFNAME");
            // Lot No
            conditionLotId.Conditions.AddTextBox("TXTLOTID")
                .SetLabel("LOTID");

            // 고객사
            //conditionLotId.Conditions.AddComboBox("CBOCUSTOMER", new SqlQuery("GetCustomerList", "10001", $"ENTERPRISEID={UserInfo.Current.Enterprise}", $"PLANTID={UserInfo.Current.Plant}"), "CUSTOMERNAME", "CUSTOMERID")
            //    .SetLabel("CUSTOMER")
            //    .SetEmptyItem()
            //    .SetResultCount(0);

            // 사업부
            //conditionLotId.Conditions.AddComboBox("CBOFACTORY", new SqlQuery("GetFactoryList", "10001", $"ENTERPRISEID={UserInfo.Current.Enterprise}", $"PLANTID={UserInfo.Current.Plant}"), "FACTORYNAME", "FACTORYID")
            //    .SetLabel("BUSINESS")
            //    .SetResultCount(1);
            // 작업장
            //conditionLotId.Conditions.AddComboBox("CBOWORKPLACE", new SqlQuery("GetAreaList", "10003", $"ENTERPRISEID={UserInfo.Current.Enterprise}", $"PLANTID={UserInfo.Current.Plant}"), "AREANAME", "AREAID")
            //    .SetLabel("WORKPLACE")
            //    .SetResultCount(0)
            //    .SetRelationIds("CBOFACTORY");
            // 공정

            var conditionProcessSegment = conditionLotId.Conditions.AddSelectPopup("TXTPROCESSSEGMENT", new SqlQuery("GetProcessSegmentList", "10001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
                .SetPopupLayout("SELECTPROCESSSEGMENT", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(600, 800)
                .SetLabel("PROCESSSEGMENT")
                .SetPopupResultCount(1)
                .SetPopupAutoFillColumns("PROCESSSEGMENTNAME");

            conditionProcessSegment.Conditions.AddTextBox("PROCESSSEGMENT");

            conditionProcessSegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150);
            conditionProcessSegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);
            // 상태구분
            //conditionLotId.Conditions.AddComboBox("CBOLOTSTATE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=LotState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
            //    .SetLabel("LOTSTATE")
            //    .SetResultCount(1);
            /*
             * 
             * 
             * 
             * 
             * 검색조건 AddComboBox 시 에러발생 (개체참조 에러)
             * 
             * 
             * 
            // 양산구분
            conditionLotId.Conditions.AddComboBox("CBOPRODUCTIONTYPE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=ProductionType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("PRODUCTIONTYPE")
                .SetEmptyItem()
                .SetResultCount(0);
            // RTR/SHT
            conditionLotId.Conditions.AddComboBox("CBORTRSHT", new SqlQuery("GetCodeList", "00001", "CODECLASSID=RTRSHT", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("RTRSHT")
                .SetEmptyItem()
                .SetResultCount(1);
            */
            // 작업구분
            //conditionLotId.Conditions.AddComboBox("CBOWORKTYPE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=WorkType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
            //    .SetLabel("WORKTYPE")
            //    .SetResultCount(1);
            // 대공정
            //conditionLotId.Conditions.AddComboBox("CBOTOPPROCESS", new SqlQuery("GetProcessSegmentClassByType", "10001", "PROCESSSEGMENTCLASSTYPE=TopProcessSegmentClass"), "PROCESSSEGMENTCLASSNAME", "PROCESSSEGMENTCLASSID")
            //    .SetLabel("TOPPROCESSSEGMENTCLASS")
            //    .SetEmptyItem()
            //    .SetResultCount(1);
            //// 중공정
            //conditionLotId.Conditions.AddComboBox("CBOMIDDLEPROCESS", new SqlQuery("GetProcessSegmentClassByType", "10001", "PROCESSSEGMENTCLASSTYPE=MiddleProcessSegmentClass"), "PROCESSSEGMENTCLASSNAME", "PROCESSSEGMENTCLASSID")
            //    .SetLabel("MIDDLEPROCESSSEGMENTCLASS")
            //    .SetEmptyItem()
            //    .SetResultCount(1);

            // 팝업 그리드에서 보여줄 컬럼 정의
            // Lot No
            conditionLotId.GridColumns.AddTextBoxColumn("LOTID", 170);
            // 양산구분
            conditionLotId.GridColumns.AddComboBoxColumn("LOTTYPE", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ProductionType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("PRODUCTIONTYPE");
            // 품목코드
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 150);
            // 품목버전
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFVERSION", 80);
            // 품목명
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200);
            // 라우팅
            conditionLotId.GridColumns.AddComboBoxColumn("PROCESSDEFID", 100, new SqlQuery("GetProcessDefinition", "1"), "PROCESSDEFNAME", "PROCESSDEFID");
            // 공정
            conditionLotId.GridColumns.AddComboBoxColumn("PROCESSSEGMENTID", 100, new SqlQuery("GetProcessSegmentList", "10001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID");
            // 순서
            conditionLotId.GridColumns.AddTextBoxColumn("USERSEQUENCE", 70);
            // Site
            conditionLotId.GridColumns.AddComboBoxColumn("PLANTID", 90, new SqlQuery("GetPlantList", "10002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"ENTERPRISEID={UserInfo.Current.Enterprise}"), "PLANTNAME", "PLANTID");
            // 작업장
            conditionLotId.GridColumns.AddComboBoxColumn("AREAID", 90, new SqlQuery("GetAreaList", "10003", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "AREANAME", "AREAID");
            // Roll/Sheet
            conditionLotId.GridColumns.AddComboBoxColumn("RTRSHT", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=RTRSHT", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
            // 단위
            conditionLotId.GridColumns.AddComboBoxColumn("UNIT", 90, new SqlQuery("GetUomDefinitionList", "10001", "UOMCLASSID=Segment"), "UOMDEFNAME", "UOMDEFID");
            // 수량
            conditionLotId.GridColumns.AddSpinEditColumn("QTY", 90);
            // PCS 수량
            conditionLotId.GridColumns.AddSpinEditColumn("PCSQTY", 90);
            // PNL 수량
            conditionLotId.GridColumns.AddSpinEditColumn("PANELQTY", 90);
            // M2 수량
            conditionLotId.GridColumns.AddSpinEditColumn("M2QTY", 90);
            // 납기계획일
            conditionLotId.GridColumns.AddDateEditColumn("PLANENDTIME", 100)
                .SetDisplayFormat("yyyy-MM-dd");
            // 기한
            conditionLotId.GridColumns.AddSpinEditColumn("LEFTDATE", 70);
            // 인수 Step PCS 수량
            conditionLotId.GridColumns.AddSpinEditColumn("RECEIVEPCSQTY", 90);
            // 인수 Step PNL 수량
            conditionLotId.GridColumns.AddSpinEditColumn("RECEIVEPANELQTY", 90);
            // 시작 Step PCS 수량
            conditionLotId.GridColumns.AddSpinEditColumn("WORKSTARTPCSQTY", 90);
            // 시작 Step PNL 수량
            conditionLotId.GridColumns.AddSpinEditColumn("WORKSTARTPANELQTY", 90);
            // 완료 Step PCS 수량
            conditionLotId.GridColumns.AddSpinEditColumn("WORKENDPCSQTY", 90);
            // 완료 Step PNL 수량
            conditionLotId.GridColumns.AddSpinEditColumn("WORKENDPANELQTY", 90);
            // 인계 Step PCS 수량
            conditionLotId.GridColumns.AddSpinEditColumn("SENDPCSQTY", 90);
            // 인계 Step PNL 수량
            conditionLotId.GridColumns.AddSpinEditColumn("SENDPANELQTY", 90);
            // 공정 Lead Time
            conditionLotId.GridColumns.AddTextBoxColumn("LEADTIME", 90);



            return conditions;
        }
        #endregion

        #region - AddConditionSampleLotPopup :: 검색조건에 Sample / Test Lot No 선택 팝업을 추가 |
        /// <summary>
        /// 검색조건에 Lot No 선택 팝업을 추가한다.
        /// </summary>
        /// <param name="id">검색조건 항목에 지정할 ID</param>
        /// <param name="position">검색조건을 추가할 순서</param>
        /// <param name="isMultiSelect">항목 복수 선택 여부</param>
        /// <param name="conditions">화면에서 사용되는 검색조건 컬렉션</param>
        /// <param name="processSegmentType">공정 구분</param>
        /// <returns></returns>
        public static ConditionCollection AddConditionSampleLotPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions, bool isValidation = false)
        {
            // SelectPopup 항목 추가
            var conditionLotId = conditions.AddSelectPopup(id, new SqlQuery("GetSelectSampleLotListPopup", "10001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "LOTID", "LOTID")
                .SetPopupLayout("SELECTLOTNO", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(1200, 800)
                .SetLabel("LOTID")
                .SetPosition(position)
                .SetSearchTextControlId("TXTLOTID");

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionLotId.SetPopupResultCount(0);
            else
                conditionLotId.SetPopupResultCount(1);

            //validation
            if (isValidation)
                conditionLotId.SetPopupValidationCustom(ValidationProduct);


            // 팝업에서 사용되는 검색조건
            var conditionProductdef = conditionLotId.Conditions.AddSelectPopup("TXTPRODUCTDEFNAME2"
                , new SqlQuery("GetProductionOrderIdListOfLotInput", "10001", $"PLANTID={UserInfo.Current.Plant}", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", "PRODUCTIONTYPE=Sample"), "PRODUCTDEFNAME", "PRODUCTDEFID")
                .SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(600, 800)
                .SetLabel("PRODUCTDEF")
                .SetPopupResultCount(1)
                .SetPopupAutoFillColumns("PRODUCTDEFNAME");

            conditionProductdef.Conditions.AddTextBox("TXTPRODUCTDEFNAME2");

            conditionProductdef.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 150);
            conditionProductdef.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200);

            // 품목코드/명
            conditionLotId.Conditions.AddTextBox("TXTPRODUCTDEFIDNAME")
                .SetLabel("TXTPRODUCTDEFNAME");
            // Lot No
            conditionLotId.Conditions.AddTextBox("TXTLOTID")
                .SetLabel("LOTID");


            var conditionProcessSegment = conditionLotId.Conditions.AddSelectPopup("TXTPROCESSSEGMENT", new SqlQuery("GetProcessSegmentList", "10001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PROCESSSEGMENTNAME", "PROCESSSEGMENTID")
                .SetPopupLayout("SELECTPROCESSSEGMENT", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(600, 800)
                .SetLabel("PROCESSSEGMENT")
                .SetPopupResultCount(1)
                .SetPopupAutoFillColumns("PROCESSSEGMENTNAME");

            conditionProcessSegment.Conditions.AddTextBox("PROCESSSEGMENT");

            conditionProcessSegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTID", 150);
            conditionProcessSegment.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 200);

            //사이트
            conditionLotId.GridColumns.AddTextBoxColumn("PLANTID", 60);
            // Lot No
            conditionLotId.GridColumns.AddTextBoxColumn("LOTID", 200);
            // 양산구분
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTIONTYPE", 60);
            //품목코드
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 100);
            //품목리비전
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTREVISION", 50);
            //품목명
            conditionLotId.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 150);
            //공정명
            conditionLotId.GridColumns.AddTextBoxColumn("PROCESSSEGMENTNAME", 100);
            //공정수순
            conditionLotId.GridColumns.AddTextBoxColumn("USERSEQUENCE", 60);
            //roll/sheet
            conditionLotId.GridColumns.AddTextBoxColumn("RTRSHT", 60);
            //공정진행상태
            conditionLotId.GridColumns.AddTextBoxColumn("PROCESSSTATE", 70);
            //PCS
            conditionLotId.GridColumns.AddTextBoxColumn("PCS", 50);
            //PNL
            conditionLotId.GridColumns.AddTextBoxColumn("PNL", 50);
            return conditions;
        }
        #endregion

        #region - AddConditionCustomerPopup :: 거래처 조회 팝업 |
        /// <summary>
        /// 작업장 조회 팝업
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position"></param>
        /// <param name="isMultiSelect"></param>
        /// <param name="conditions"></param>
        /// <param name="IsRequired"></param>
        /// <returns></returns>
        public static ConditionCollection AddConditionCustomerPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions, bool IsRequired = false)
        {

            // SelectPopup 항목 추가
            var conditionCustomerId = conditions.AddSelectPopup(id, new SqlProcedure("USP_ERPIF_GETCOMPANY", $"p_LANGUAGETYPE={UserInfo.Current.LanguageType}", "p_companyType=*"), "COMPANYNAME", "COMPANYID")
                .SetPopupLayout("COMPANYID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupLayoutForm(800, 800)
                .SetLabel("COMPANYID")
                .SetPosition(position);

            conditionCustomerId.IsRequired = IsRequired;
            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionCustomerId.SetPopupResultCount(0);
            else
                conditionCustomerId.SetPopupResultCount(1);


            //conditionCustomerId.Conditions.AddTextBox("TXTCUSTOMERID");
            conditionCustomerId.Conditions.AddComboBox("P_COMPANYTYPE", new SqlQuery("GetCodeList", "00001", $"CODECLASSID=COMPANYTYPE", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CODENAME", "CODEID")
                .SetDefault("*")
                .SetLabel("COMPANYTYPE");

            conditionCustomerId.GridColumns.AddTextBoxColumn("COMPANYID", 150);
            conditionCustomerId.GridColumns.AddTextBoxColumn("COMPANYNAME", 200);


            return conditions;
        }
        #endregion
        #endregion

        #region ◆ 포장 라벨 :::: 

        #region - printPackingLabel :: 포장 라벨 출력 |
        /// <summary>
        /// 포장 라벨 출력
        /// </summary>
        /// <param name="lotid"></param>
        public static void printPackingLabel(string lotid)
        {
            Dictionary<string, object> commentParam = new Dictionary<string, object>();
            commentParam.Add("ENTERPRISEID", UserInfo.Current.Enterprise);
            commentParam.Add("PLANTID", UserInfo.Current.Plant);
            commentParam.Add("LOTID", lotid);

            DataTable dt = SqlExecuter.Query("SelectLabelList", "10001", commentParam);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] labelData = dt.Rows[i]["LABELDATA"] as byte[];
                XtraReport report = new XtraReport();
                using (MemoryStream ms = new MemoryStream(labelData))
                {

                    ms.Write(labelData, 0, labelData.Length);

                    report = XtraReport.FromStream(ms);

                    DataRow dr = dt.Rows[i];

                    report = getLabelDataMappingReport(report, dr, lotid);

                    ImageExportOptions imageOptions = report.ExportOptions.Image;
                    imageOptions.Format = ImageFormat.Bmp;

                    report.ExportToImage(SystemCommonClass.ImageTempPath, imageOptions);

                    int w, h;
                    Bitmap b = new Bitmap(SystemCommonClass.ImageTempPath);
                    w = b.Width; h = b.Height;

                    string ZPLImageDataString = Micube.SmartMES.Commons.ZPLPrint.GetZPLIIImage(b, 20, 20); //ZPLUtil. SendImageToPrinter(1,1,b);
                    StringBuilder ZPLCommand = new StringBuilder();

                    ZPLCommand.AppendLine("^XA");
                    ZPLCommand.AppendLine(ZPLImageDataString);
                    ZPLCommand.AppendLine("^XZ");

                    Commons.ZPLPrint.SendStringToPrinter(ZPLCommand.ToString());
                    b.Dispose();

                    FileInfo fileDel = new FileInfo(SystemCommonClass.ImageTempPath);

                    if (fileDel.Exists) //삭제할 파일이 있는지
                    {
                        fileDel.Delete(); //없어도 에러안남
                    }

                }

            }
        }
        #endregion

        #region - PrintBoxLabel :: 포장 라벨 출력 (BoxNo) |
        /// <summary>
        /// 포장 라벨 출력 (BoxNo)
        /// </summary>
        /// <param name="boxno"></param>
        public static void PrintBoxLabel(string boxno)
        {
            Dictionary<string, object> commentParam = new Dictionary<string, object>();
            commentParam.Add("ENTERPRISEID", UserInfo.Current.Enterprise);
            commentParam.Add("PLANTID", UserInfo.Current.Plant);
            commentParam.Add("BOXNO", boxno);

            DataTable dt = SqlExecuter.Query("SelectLabelList", "10002", commentParam);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] labelData = dt.Rows[i]["LABELDATA"] as byte[];
                XtraReport report = new XtraReport();
                using (MemoryStream ms = new MemoryStream(labelData))
                {

                    ms.Write(labelData, 0, labelData.Length);

                    report = XtraReport.FromStream(ms);

                    DataRow dr = dt.Rows[i];

                    report = GetLabelDataMappingReport(report, dr, boxno);

                    ImageExportOptions imageOptions = report.ExportOptions.Image;
                    imageOptions.Format = ImageFormat.Bmp;

                    report.ExportToImage(SystemCommonClass.ImageTempPath, imageOptions);

                    int w, h;
                    Bitmap b = new Bitmap(SystemCommonClass.ImageTempPath);
                    w = b.Width; h = b.Height;

                    string ZPLImageDataString = Micube.SmartMES.Commons.ZPLPrint.GetZPLIIImage(b, 20, 20); //ZPLUtil. SendImageToPrinter(1,1,b);
                    StringBuilder ZPLCommand = new StringBuilder();

                    ZPLCommand.AppendLine("^XA");
                    ZPLCommand.AppendLine(ZPLImageDataString);
                    ZPLCommand.AppendLine("^XZ");

                    Commons.ZPLPrint.SendStringToPrinter(ZPLCommand.ToString());
                    b.Dispose();

                    FileInfo fileDel = new FileInfo(SystemCommonClass.ImageTempPath);

                    if (fileDel.Exists) //삭제할 파일이 있는지
                    {
                        fileDel.Delete(); //없어도 에러안남
                    }

                }

            }
        }
        #endregion

        #region - PrintLabel :: 라벨 Print (ZPL) |
        /// <summary>
        /// 라벨 Print (ZPL)
        /// </summary>
        /// <param name="report"></param>
        public static void PrintLabel(XtraReport report)
        {

            ImageExportOptions imageOptions = report.ExportOptions.Image;
            imageOptions.Format = ImageFormat.Bmp;

            report.ExportToImage(SystemCommonClass.ImageTempPath, imageOptions);

            int w, h;
            Bitmap b = new Bitmap(SystemCommonClass.ImageTempPath);
            w = b.Width; h = b.Height;

            string ZPLImageDataString = Micube.SmartMES.Commons.ZPLPrint.GetZPLIIImage(b, 20, 20); //ZPLUtil. SendImageToPrinter(1,1,b);
            StringBuilder ZPLCommand = new StringBuilder();

            ZPLCommand.AppendLine("^XA");
            ZPLCommand.AppendLine(ZPLImageDataString);
            ZPLCommand.AppendLine("^XZ");

            Commons.ZPLPrint.SendStringToPrinter(ZPLCommand.ToString());
            b.Dispose();

            FileInfo fileDel = new FileInfo(SystemCommonClass.ImageTempPath);

            if (fileDel.Exists) //삭제할 파일이 있는지
            {
                fileDel.Delete(); //없어도 에러안남
            }

        }
        #endregion

        #region - GetPackingLabel :: 라벨 매핑 정보 조회하여 서식 Return (LotId) |
        /// <summary>
        /// 라벨 매핑 정보 조회하여 서식 Return (LotId)
        /// </summary>
        /// <param name="lotid"></param>
        /// <returns></returns>
        public static List<XtraReport> GetPackingLabel(string lotid)
        {
            Dictionary<string, object> commentParam = new Dictionary<string, object>();
            commentParam.Add("ENTERPRISEID", UserInfo.Current.Enterprise);
            commentParam.Add("PLANTID", UserInfo.Current.Plant);
            commentParam.Add("LOTID", lotid);

            DataTable dt = SqlExecuter.Query("SelectLabelList", "10001", commentParam);
            List<XtraReport> viewList = new List<XtraReport>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] labelData = dt.Rows[i]["LABELDATA"] as byte[];
                XtraReport report = new XtraReport();

                using (MemoryStream ms = new MemoryStream(labelData))
                {

                    ms.Write(labelData, 0, labelData.Length);

                    report = XtraReport.FromStream(ms);
                    report.Tag = dt.Rows[i]["LABELDEFNAME"].ToString();

                    DataRow dr = dt.Rows[i];

                    viewList.Add(getLabelDataMappingReport(report, dr, lotid));

                }

            }
            return viewList;
        }
        #endregion

        #region - GetBoxLabel :: 라벨 매핑정보 조회하여 서식 Return (BoxNo) |
        /// <summary>
        /// 라벨 매핑정보 조회하여 서식 Return (BoxNo)
        /// </summary>
        /// <param name="boxno"></param>
        /// <returns></returns>
        public static List<XtraReport> GetBoxLabel(string boxno)
        {
            Dictionary<string, object> commentParam = new Dictionary<string, object>();
            commentParam.Add("ENTERPRISEID", UserInfo.Current.Enterprise);
            commentParam.Add("PLANTID", UserInfo.Current.Plant);
            commentParam.Add("P_LABELTYPE", "Box");
            commentParam.Add("BOXNO", boxno);

            DataTable dt = SqlExecuter.Query("SelectLabelList", "10002", commentParam);
            List<XtraReport> viewList = new List<XtraReport>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] labelData = dt.Rows[i]["LABELDATA"] as byte[];
                XtraReport report = new XtraReport();

                using (MemoryStream ms = new MemoryStream(labelData))
                {

                    ms.Write(labelData, 0, labelData.Length);

                    report = XtraReport.FromStream(ms);
                    report.Tag = dt.Rows[i]["LABELDEFNAME"].ToString();

                    DataRow dr = dt.Rows[i];

                    viewList.Add(GetLabelDataMappingReport(report, dr, boxno));

                }

            }
            return viewList;
        }
        #endregion

        #region - GetBoxLabelType :: 라벨 유형별 매핑정보 조회하여 서식 Return (BoxNo) |
        /// <summary>
        /// 라벨 유형별 매핑정보 조회하여 서식 Return (BoxNo)
        /// </summary>
        /// <param name="boxno">BoxNo</param>
        /// <param name="labelType">라벨 유형</param>
        /// <returns></returns>
        public static List<XtraReport> GetBoxLabelType(string boxno, string labelType)
        {
            Dictionary<string, object> commentParam = new Dictionary<string, object>();
            commentParam.Add("ENTERPRISEID", UserInfo.Current.Enterprise);
            commentParam.Add("PLANTID", UserInfo.Current.Plant);
            commentParam.Add("P_LABELTYPE", labelType);
            commentParam.Add("BOXNO", boxno);

            DataTable dt = SqlExecuter.Query("SelectLabelList", "10002", commentParam);
            List<XtraReport> viewList = new List<XtraReport>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] labelData = dt.Rows[i]["LABELDATA"] as byte[];
                XtraReport report = new XtraReport();

                using (MemoryStream ms = new MemoryStream(labelData))
                {

                    ms.Write(labelData, 0, labelData.Length);

                    report = XtraReport.FromStream(ms);
                    report.Tag = dt.Rows[i]["LABELDEFNAME"].ToString();

                    DataRow dr = dt.Rows[i];

                    viewList.Add(GetLabelDataMappingReport(report, dr, boxno));

                }

            }
            return viewList;
        }
        #endregion

        #region - GetBoxLabelCase :: Case Label 매핑정보 조회하여 서식 Return (BoxNo) |
        /// <summary>
        /// 라벨 유형별 매핑정보 조회하여 서식 Return (BoxNo)
        /// </summary>
        /// <param name="boxno">BoxNo</param>
        /// <param name="labelType">라벨 유형</param>
        /// <returns></returns>
        public static List<XtraReport> GetBoxLabelCase(string boxno, string CaseNo)
        {
            Dictionary<string, object> commentParam = new Dictionary<string, object>();
            commentParam.Add("ENTERPRISEID", UserInfo.Current.Enterprise);
            commentParam.Add("PLANTID", UserInfo.Current.Plant);
            commentParam.Add("BOXNO", boxno);
            commentParam.Add("P_CASENO", CaseNo);

            DataTable dt = SqlExecuter.Query("SelectLabelCase", "10001", commentParam);
            List<XtraReport> viewList = new List<XtraReport>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] labelData = dt.Rows[i]["LABELDATA"] as byte[];
                XtraReport report = new XtraReport();

                using (MemoryStream ms = new MemoryStream(labelData))
                {

                    ms.Write(labelData, 0, labelData.Length);

                    report = XtraReport.FromStream(ms);
                    report.Tag = dt.Rows[i]["LABELDEFNAME"].ToString();

                    DataRow dr = dt.Rows[i];

                    viewList.Add(GetLabelDataMappingReport(report, dr, boxno));

                }

            }
            return viewList;
        }
        #endregion

        #region - GetBoxLabelXOUTOuter :: X-OUT 외부 Label 매핑정보 조회하여 서식 Return (BoxNo) |
        /// <summary>
        /// X-OUT 외부 Label 매핑정보 조회하여 서식 Return (BoxNo)
        /// </summary>
        /// <param name="boxno">BoxNo</param>
        /// <returns></returns>
        public static List<XtraReport> GetBoxLabelXOUTOuter(string boxno)
        {
            Dictionary<string, object> commentParam = new Dictionary<string, object>();
            commentParam.Add("ENTERPRISEID", UserInfo.Current.Enterprise);
            commentParam.Add("PLANTID", UserInfo.Current.Plant);
            commentParam.Add("BOXNO", boxno);

            DataTable dt = SqlExecuter.Query("SelectLabelXOutOuter", "10001", commentParam);
            List<XtraReport> viewList = new List<XtraReport>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] labelData = dt.Rows[i]["LABELDATA"] as byte[];
                XtraReport report = new XtraReport();

                using (MemoryStream ms = new MemoryStream(labelData))
                {

                    ms.Write(labelData, 0, labelData.Length);

                    report = XtraReport.FromStream(ms);
                    report.Tag = dt.Rows[i]["LABELDEFNAME"].ToString();

                    DataRow dr = dt.Rows[i];

                    viewList.Add(GetLabelDataMappingReport(report, dr, boxno));

                }

            }
            return viewList;
        }
        #endregion

        #region - GetBoxLabelXOUTInner :: X-OUT 내부 Label 매핑정보 조회하여 서식 Return (BoxNo) |
        /// <summary>
        /// X-OUT 내부 Label 매핑정보 조회하여 서식 Return (BoxNo)
        /// </summary>
        /// <param name="boxno">BoxNo</param>
        /// <param name="serialno">SerialNo</param>
        /// <returns></returns>
        public static List<XtraReport> GetBoxLabelXOUTInner(string boxno, string serialno)
        {
            Dictionary<string, object> commentParam = new Dictionary<string, object>();
            commentParam.Add("ENTERPRISEID", UserInfo.Current.Enterprise);
            commentParam.Add("PLANTID", UserInfo.Current.Plant);
            commentParam.Add("BOXNO", boxno);
            commentParam.Add("SERIALNO", serialno);

            DataTable dt = SqlExecuter.Query("SelectLabelXOutInner", "10001", commentParam);
            List<XtraReport> viewList = new List<XtraReport>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] labelData = dt.Rows[i]["LABELDATA"] as byte[];
                XtraReport report = new XtraReport();

                using (MemoryStream ms = new MemoryStream(labelData))
                {

                    ms.Write(labelData, 0, labelData.Length);

                    report = XtraReport.FromStream(ms);
                    report.Tag = dt.Rows[i]["LABELDEFNAME"].ToString();

                    DataRow dr = dt.Rows[i];

                    viewList.Add(GetLabelDataMappingReport(report, dr, boxno));

                }

            }
            return viewList;
        }
        #endregion

        #region - getLabelDataMappingReport :: 라벨 서식 적용 및 Tab별 출력 |
        /// <summary>
        /// 라벨 서식 적용 및 Tab별 출력
        /// </summary>
        /// <param name="report"></param>
        /// <param name="dr"></param>
        /// <param name="lotid"></param>
        /// <returns></returns>
        private static XtraReport getLabelDataMappingReport(XtraReport report, DataRow dr, string lotid)
        {

            string queryID = dr["QUERYID"].ToString();
            string quertVersion = dr["QUERYVERSION"].ToString();

            Dictionary<string, object> commentParam = new Dictionary<string, object>();
            commentParam.Add("ENTERPRISEID", UserInfo.Current.Enterprise);
            commentParam.Add("PLANTID", UserInfo.Current.Plant);
            commentParam.Add("LOTID", lotid);
            //         commentParam.Add("P_TYPE", "TEST");

            if (!string.IsNullOrEmpty(queryID))
            {
                DataTable dt = SqlExecuter.Query(queryID, quertVersion, commentParam);

                Band detailBand = report.Bands.GetBandByType(typeof(DetailBand));

                //detailBand.Controls

                foreach (XRControl control in detailBand.Controls)
                {
                    if (control is DevExpress.XtraReports.UI.XRLabel)
                    {
                        if (!string.IsNullOrEmpty(control.Tag.ToString()))
                        {
                            if (dt.Columns.IndexOf(control.Tag.ToString()) > -1)
                            {
                                control.Text = dt.Rows[0][control.Tag.ToString()].ToString();
                            }
                            // control.Text = dr[""].ToString()
                        }


                    }
                    else if (control is DevExpress.XtraReports.UI.XRBarCode)
                    {
                        if (!string.IsNullOrEmpty(control.Tag.ToString()))
                        {
                            if (dt.Columns.IndexOf(control.Tag.ToString()) > -1)
                            {
                                control.Text = dt.Rows[0][control.Tag.ToString()].ToString();
                            }
                            // control.Text = dr[""].ToString()
                        }

                    }
                    else if (control is DevExpress.XtraReports.UI.XRTable)
                    {
                        XRTable xt = control as XRTable;

                        foreach (XRTableRow tr in xt.Rows)
                        {
                            for (int i = 0; i < tr.Cells.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(tr.Cells[i].Tag.ToString()))
                                {
                                    if (dt.Columns.IndexOf(tr.Cells[i].Tag.ToString()) > -1)
                                    {
                                        tr.Cells[i].Text = dt.Rows[0][tr.Cells[i].Tag.ToString()].ToString();
                                    }


                                }

                            }
                        }

                    }

                }
            }

            return report;
        }
        #endregion

        #region - GetLabelDataMappingReport :: 라벨 서식 적용 및 Tab별 출력 (BoxNo) |
        /// <summary>
        /// BOXNO를 통해 QUERY ID 실행
        /// </summary>
        /// <param name="report"></param>
        /// <param name="dr"></param>
        /// <param name="boxno"></param>
        /// <returns></returns>
        private static XtraReport GetLabelDataMappingReport(XtraReport report, DataRow dr, string boxno)
        {

            string queryID = dr["QUERYID"].ToString();
            string quertVersion = dr["QUERYVERSION"].ToString();

            Dictionary<string, object> commentParam = new Dictionary<string, object>();
            commentParam.Add("ENTERPRISEID", UserInfo.Current.Enterprise);
            commentParam.Add("PLANTID", UserInfo.Current.Plant);
            commentParam.Add("BOXNO", boxno);
            //         commentParam.Add("P_TYPE", "TEST");

            if (!string.IsNullOrEmpty(queryID))
            {
                DataTable dt = SqlExecuter.Query(queryID, quertVersion, commentParam);

                Band detailBand = report.Bands.GetBandByType(typeof(DetailBand));

                //detailBand.Controls

                foreach (XRControl control in detailBand.Controls)
                {
                    if (control is DevExpress.XtraReports.UI.XRLabel)
                    {
                        if (!string.IsNullOrEmpty(control.Tag.ToString()))
                        {
                            if (dt.Columns.IndexOf(control.Tag.ToString()) > -1)
                            {
                                control.Text = dt.Rows[0][control.Tag.ToString()].ToString();
                            }
                            // control.Text = dr[""].ToString()
                        }


                    }
                    else if (control is DevExpress.XtraReports.UI.XRBarCode)
                    {
                        if (!string.IsNullOrEmpty(control.Tag.ToString()))
                        {
                            if (dt.Columns.IndexOf(control.Tag.ToString()) > -1)
                            {
                                control.Text = dt.Rows[0][control.Tag.ToString()].ToString();
                            }
                            // control.Text = dr[""].ToString()
                        }

                    }
                    else if (control is DevExpress.XtraReports.UI.XRTable)
                    {
                        XRTable xt = control as XRTable;

                        foreach (XRTableRow tr in xt.Rows)
                        {
                            for (int i = 0; i < tr.Cells.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(tr.Cells[i].Tag.ToString()))
                                {
                                    if (dt.Columns.IndexOf(tr.Cells[i].Tag.ToString()) > -1)
                                    {
                                        tr.Cells[i].Text = dt.Rows[0][tr.Cells[i].Tag.ToString()].ToString();
                                    }


                                }

                            }
                        }

                    }

                }
            }

            return report;
        }
        #endregion

        #endregion

        #region ◆ 공정 관련 공통 ::: 

        #region - GetLotRoutingList :: 
        /// <summary>
        /// GetLotRoutingList
        /// </summary>
        /// <param name="type"></param>
        /// <param name="lotid"></param>
        /// <returns></returns>
        private static DataTable GetLotRoutingList(LotCardType type, string lotid)
        {
            DataTable dt = new DataTable();

            if (type == LotCardType.Normal)
            {
                dt = SqlExecuter.Query("SelectProcessResultAndRoutingForLotCard_Normal", "10001", new Dictionary<string, object>() { { "LOTID", lotid }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });
            }
            else if (type == LotCardType.Split)
            {
                string[] LotList = lotid.Split(',');

                for (int i = 0; i < LotList.Length; i++)
                {
                    string tmpLot = LotList[i];

                    DataTable lot = SqlExecuter.Query("SelectProcessResultAndRoutingForLotCard_Split", "10001", new Dictionary<string, object>() { { "LOTID", tmpLot }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });

                    dt.Merge(lot);
                }
            }
            else if (type == LotCardType.Rework)
            {
                dt = SqlExecuter.Query("SelectProcessResultAndRoutingForLotCard_Rework", "10001", new Dictionary<string, object>() { { "LOTID", lotid }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });
            }
            return dt;
        }
        #endregion

        #region - setReportRoutingListRework :: Rework Routing 조회 |
        /// <summary>
        /// Rework Routing 조회
        /// </summary>
        /// <param name="lotId"></param>
        /// <param name="printProcessRowPerPage"></param>
        /// <param name="dtProcess"></param>
        /// <returns></returns>
        private static DataTable setReportRoutingListRework(string lotId, int printProcessRowPerPage, DataTable dtProcess)
        {

            DataTable dtProcessList = new DataTable();
            dtProcessList.Columns.Add("LOTID", typeof(string));
            dtProcessList.Columns.Add("SEQUENCE", typeof(string));
            dtProcessList.Columns.Add("CHANGESTATE", typeof(string));
            dtProcessList.Columns.Add("PROCESSNAME", typeof(string));
            dtProcessList.Columns.Add("AREA", typeof(string));
            dtProcessList.Columns.Add("REMARK", typeof(string));
            dtProcessList.Columns.Add("DATE", typeof(string));
            dtProcessList.Columns.Add("PROCESSQTY", typeof(string));
            dtProcessList.Columns.Add("WORKPLACEWORKER", typeof(string));

            List<string> lotList = lotId.Split(',').ToList();
            lotList.ForEach(id =>
            {
                DataTable tempTable = dtProcess.Select("LOTID = '" + id + "'").CopyToDataTable().Rows.Cast<DataRow>().CopyToDataTable();

                int totalProcessCount = tempTable.Rows.Count;
                int pageCount = (totalProcessCount / (printProcessRowPerPage * 2)) + ((totalProcessCount % (printProcessRowPerPage * 2) == 0) ? 0 : 1);

                int rowNumber = 0;

                DataTable tempResult = dtProcessList.Clone();

                for (int i = 0; i < pageCount; i++)
                {
                    for (int j = 0; j < printProcessRowPerPage; j++)
                    {


                        if (rowNumber > totalProcessCount - 1) break;

                        DataRow processRow = tempTable.Rows[rowNumber];

                        DataRow newRow = tempResult.NewRow();

                        newRow["LOTID"] = processRow["LOTID"];
                        newRow["SEQUENCE"] = processRow["SEQUENCE"];
                        newRow["CHANGESTATE"] = processRow["CHANGESTATE"];
                        newRow["PROCESSNAME"] = processRow["PROCESSNAME"];
                        newRow["AREA"] = processRow["AREA"];
                        newRow["REMARK"] = processRow["REMARK"];
                        newRow["DATE"] = processRow["DATE"];
                        newRow["PROCESSQTY"] = processRow["PROCESSQTY"];
                        newRow["WORKPLACEWORKER"] = processRow["WORKPLACEWORKER"];

                        tempResult.Rows.Add(newRow);

                        rowNumber++;
                    }
                }

                dtProcessList.Merge(tempResult);
            });

            return dtProcessList;
        }
        #endregion

        #region - setReportRoutingListNormal :: Rework Routing Lot Card 출력 데이터 조회 |
        /// <summary>
        /// Rework Routing Lot Card 출력 데이터 조회
        /// </summary>
        /// <param name="lotId"></param>
        /// <param name="printProcessRowPerPage"></param>
        /// <param name="dtProcess"></param>
        /// <returns></returns>
        private static DataTable setReportRoutingListNormal(string lotId, int printProcessRowPerPage, DataTable dtProcess)
        {

            DataTable dtProcessList = new DataTable();
            dtProcessList.Columns.Add("LOTID", typeof(string));
            dtProcessList.Columns.Add("SEQUENCE1", typeof(string));
            dtProcessList.Columns.Add("CHANGESTATE1", typeof(string));
            dtProcessList.Columns.Add("PROCESSNAME1", typeof(string));
            dtProcessList.Columns.Add("PROCESSINGDATE1", typeof(string));
            dtProcessList.Columns.Add("PROCESSQTY1", typeof(string));
            dtProcessList.Columns.Add("WORKPLACEWORKER1", typeof(string));
            dtProcessList.Columns.Add("SEQUENCE2", typeof(string));
            dtProcessList.Columns.Add("CHANGESTATE2", typeof(string));
            dtProcessList.Columns.Add("PROCESSNAME2", typeof(string));
            dtProcessList.Columns.Add("PROCESSINGDATE2", typeof(string));
            dtProcessList.Columns.Add("PROCESSQTY2", typeof(string));
            dtProcessList.Columns.Add("WORKPLACEWORKER2", typeof(string));

            List<string> lotList = lotId.Split(',').ToList();
            lotList.ForEach(id =>
            {
                DataTable tempTable = dtProcess.Select("LOTID = '" + id + "'").CopyToDataTable().Rows.Cast<DataRow>().OrderBy(row => row["SEQUENCE"]).CopyToDataTable();

                int totalProcessCount = tempTable.Rows.Count;
                int pageCount = (totalProcessCount / (printProcessRowPerPage * 2)) + ((totalProcessCount % (printProcessRowPerPage * 2) == 0) ? 0 : 1);

                int rowNumber = 0;

                DataTable tempResult = dtProcessList.Clone();

                for (int i = 0; i < pageCount; i++)
                {
                    for (int j = 0; j < printProcessRowPerPage; j++)
                    {
                        rowNumber = (i * printProcessRowPerPage * 2) + j;

                        if (rowNumber >= totalProcessCount)
                            break;

                        DataRow processRow = tempTable.Rows[rowNumber];

                        DataRow newRow = tempResult.NewRow();

                        newRow["LOTID"] = processRow["LOTID"];
                        newRow["SEQUENCE1"] = processRow["USERSEQUENCE"];
                        newRow["CHANGESTATE1"] = processRow["DIVISION"];
                        newRow["PROCESSNAME1"] = processRow["PROCESSSEGMENTNAME"];
                        newRow["PROCESSINGDATE1"] = processRow["SENDTIME"];
                        newRow["PROCESSQTY1"] = processRow["SENDQTY"];
                        newRow["WORKPLACEWORKER1"] = processRow["SENDUSER"];


                        tempResult.Rows.Add(newRow);
                    }

                    for (int j = 0; j < printProcessRowPerPage; j++)
                    {
                        rowNumber = (i * printProcessRowPerPage * 2) + (j + printProcessRowPerPage);

                        if (rowNumber >= totalProcessCount)
                            break;

                        DataRow processRow = tempTable.Rows[rowNumber];

                        DataRow newRow = tempResult.Rows[rowNumber - (printProcessRowPerPage * (i + 1))];

                        newRow["LOTID"] = processRow["LOTID"];
                        newRow["SEQUENCE2"] = processRow["USERSEQUENCE"];
                        newRow["CHANGESTATE2"] = processRow["DIVISION"];
                        newRow["PROCESSNAME2"] = processRow["PROCESSSEGMENTNAME"];
                        newRow["PROCESSINGDATE2"] = processRow["SENDTIME"];
                        newRow["PROCESSQTY2"] = processRow["SENDQTY"];
                        newRow["WORKPLACEWORKER2"] = processRow["SENDUSER"];
                    }
                }

                dtProcessList.Merge(tempResult);
            });

            return dtProcessList;
        }
        #endregion

        #region - PrintLotCard :: Lot Card를 출력 한다. (lotId, Printtype, printProcessRowPerPage)  |
        /// <summary>
        /// Lot Card를 출력 한다.
        /// </summary>
        /// <param name="lotId">출력 할 Lot Id (복수 가능, ','(콤마)로 구분)</param>
        /// <param name="LotCardType">Report File Stream</param>
        /// <param name="printProcessRowPerPage">페이지 당 보여줄 공정 줄 수</param>
        public static void PrintLotCard(string lotId, LotCardType Printtype, int printProcessRowPerPage = 25)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("LOTID", lotId);

            DataSet dsReport = new DataSet();

            DataTable dtQueryResult = SqlExecuter.Query("SelectLotInfoOnPrintLotCard", "10001", param);
            DataTable dtLotInfo = dtQueryResult.Clone();

            dtQueryResult.Rows.Cast<DataRow>().ForEach(lotRow =>
            {
                DataRow newRow = dtLotInfo.NewRow();
                newRow.ItemArray = lotRow.ItemArray.Clone() as object[];

                dtLotInfo.Rows.Add(newRow);
            });


            dtLotInfo.AcceptChanges();

            dsReport.Tables.Add(dtLotInfo);

            //DataTable dtProcess = SqlExecuter.Query("SelectProcessResultAndRoutingForLotCard_Normal", "10001", new Dictionary<string, object>() { { "LOTID", lotId }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });
            DataTable dtProcess = GetLotRoutingList(Printtype, lotId);

            DataTable dtProcessList = new DataTable();
            if (Printtype == LotCardType.Rework)
                dtProcessList = setReportRoutingListRework(lotId, printProcessRowPerPage, dtProcess);
            else
                dtProcessList = setReportRoutingListNormal(lotId, printProcessRowPerPage, dtProcess);
            /*
            dtProcessList.Columns.Add("LOTID", typeof(string));
            dtProcessList.Columns.Add("SEQUENCE1", typeof(string));
            dtProcessList.Columns.Add("CHANGESTATE1", typeof(string));
            dtProcessList.Columns.Add("PROCESSNAME1", typeof(string));
            dtProcessList.Columns.Add("PROCESSINGDATE1", typeof(string));
            dtProcessList.Columns.Add("PROCESSQTY1", typeof(string));
            dtProcessList.Columns.Add("WORKPLACEWORKER1", typeof(string));
            dtProcessList.Columns.Add("SEQUENCE2", typeof(string));
            dtProcessList.Columns.Add("CHANGESTATE2", typeof(string));
            dtProcessList.Columns.Add("PROCESSNAME2", typeof(string));
            dtProcessList.Columns.Add("PROCESSINGDATE2", typeof(string));
            dtProcessList.Columns.Add("PROCESSQTY2", typeof(string));
            dtProcessList.Columns.Add("WORKPLACEWORKER2", typeof(string));

            List<string> lotList = lotId.Split(',').ToList();
            lotList.ForEach(id =>
            {
                DataTable tempTable = dtProcess.Select("LOTID = '" + id + "'").CopyToDataTable().Rows.Cast<DataRow>().OrderBy(row => row["SEQUENCE"]).CopyToDataTable();

                int totalProcessCount = tempTable.Rows.Count;
                int pageCount = (totalProcessCount / (printProcessRowPerPage * 2)) + ((totalProcessCount % (printProcessRowPerPage * 2) == 0) ? 0 : 1);

                int rowNumber = 0;

                DataTable tempResult = dtProcessList.Clone();

                for (int i = 0; i < pageCount; i++)
                {
                    for (int j = 0; j < printProcessRowPerPage; j++)
                    {
                        rowNumber = (i * printProcessRowPerPage * 2) + j;

                        if (rowNumber >= totalProcessCount)
                            break;

                        DataRow processRow = tempTable.Rows[rowNumber];

                        DataRow newRow = tempResult.NewRow();

                        newRow["LOTID"] = processRow["LOTID"];
                        newRow["SEQUENCE1"] = processRow["USERSEQUENCE"];
                        newRow["CHANGESTATE1"] = processRow["DIVISION"];
                        newRow["PROCESSNAME1"] = processRow["PROCESSSEGMENTNAME"];
                        newRow["PROCESSINGDATE1"] = processRow["SENDTIME"];
                        newRow["PROCESSQTY1"] = processRow["SENDQTY"];
                        newRow["WORKPLACEWORKER1"] = processRow["SENDUSER"];


                        tempResult.Rows.Add(newRow);
                    }

                    for (int j = 0; j < printProcessRowPerPage; j++)
                    {
                        rowNumber = (i * printProcessRowPerPage * 2) + (j + printProcessRowPerPage);

                        if (rowNumber >= totalProcessCount)
                            break;

                        DataRow processRow = tempTable.Rows[rowNumber];

                        DataRow newRow = tempResult.Rows[rowNumber - (printProcessRowPerPage * (i + 1))];

                        newRow["LOTID"] = processRow["LOTID"];
                        newRow["SEQUENCE2"] = processRow["USERSEQUENCE"];
                        newRow["CHANGESTATE2"] = processRow["DIVISION"];
                        newRow["PROCESSNAME2"] = processRow["PROCESSSEGMENTNAME"];
                        newRow["PROCESSINGDATE2"] = processRow["SENDTIME"];
                        newRow["PROCESSQTY2"] = processRow["SENDQTY"];
                        newRow["WORKPLACEWORKER2"] = processRow["SENDUSER"];
                    }
                }

                dtProcessList.Merge(tempResult);
            });
            */

            dtProcessList.AcceptChanges();

            dsReport.Tables.Add(dtProcessList);

            DataRelation relation = new DataRelation("RelationLotId", dtLotInfo.Columns["LOTID"], dtProcessList.Columns["LOTID"]);

            dsReport.Relations.Add(relation);

            Assembly assembly = Assembly.GetAssembly(Type.GetType("Micube.SmartMES.Commons.CommonFunction"));

            string path = string.Empty;
            switch (Printtype)
            {
                case LotCardType.Normal:
                case LotCardType.Merge:
                case LotCardType.Split:
                case LotCardType.RCChange:
                    path = Constants.NormaLotCardPath;
                    break;
                case LotCardType.Rework:
                    path = Constants.ReworkLotCardPath;
                    break;

            }

            Stream stream = assembly.GetManifestResourceStream(path);

            XtraReport report = XtraReport.FromStream(stream);
            report.DataSource = dsReport;
            report.DataMember = "Table1";

            if (Printtype.Equals(LotCardType.Rework))
            {
                Watermark textWatermark = new Watermark();
                Font ft = new Font("HYGothic-Medium", 100, FontStyle.Bold);
                textWatermark.Text = Language.Get("REWORK");
                textWatermark.TextDirection = DirectionMode.ForwardDiagonal;
                textWatermark.Font = ft;
                textWatermark.ForeColor = Color.DodgerBlue;
                textWatermark.TextTransparency = 150;
                textWatermark.ShowBehind = false;
                report.Watermark.CopyFrom(textWatermark);
            }
            Band band = report.Bands["Detail"];
            //SetReportControlDataBinding(band.Controls, dsReport.Tables[0]);


            DetailReportBand detailReport = report.Bands["DetailReport"] as DetailReportBand;
            detailReport.DataSource = dsReport;
            detailReport.DataMember = "RelationLotId";

            Band groupHeader = detailReport.Bands["GroupHeader1"];
            SetReportControlDataBinding(groupHeader.Controls, dsReport, "");

            XRControl picLogo = groupHeader.FindControl("picLogo", true);

            if (picLogo != null && picLogo is XRPictureBox picBox)
            {
                if (UserInfo.Current.Enterprise == "INTERFLEX")
                    picBox.Image = Properties.Resources.Logo_Interflex;
                else if (UserInfo.Current.Enterprise == "YOUNGPOONG")
                    picBox.Image = Properties.Resources.Logo_Youngpoong;
            }

            Band detailBand = detailReport.Bands["Detail1"];
            setLabelLaungage(detailReport);
            SetReportControlDataBinding(detailBand.Controls, dsReport, "RelationLotId");


            //report.Print();
            report.ShowPreviewDialog();
        }
        #endregion

        #region - PrintLotCard :: Lot Card를 출력 한다. (lotId, Stream, printProcessRowPerPage) |
        /// <summary>
        /// Lot Card를 출력 한다.
        /// </summary>
        /// <param name="lotId">출력 할 Lot Id (복수 가능, ','(콤마)로 구분)</param>
        /// <param name="stream">Report File Stream</param>
        /// <param name="printProcessRowPerPage">페이지 당 보여줄 공정 줄 수</param>
        public static void PrintLotCard(string lotId, Stream stream, int printProcessRowPerPage = 25)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("LOTID", lotId);

            DataSet dsReport = new DataSet();

            DataTable dtQueryResult = SqlExecuter.Query("SelectLotInfoOnPrintLotCard", "10001", param);
            DataTable dtLotInfo = dtQueryResult.Clone();

            dtQueryResult.Rows.Cast<DataRow>().ForEach(lotRow =>
            {
                DataRow newRow = dtLotInfo.NewRow();
                newRow.ItemArray = lotRow.ItemArray.Clone() as object[];

                dtLotInfo.Rows.Add(newRow);
            });


            dtLotInfo.AcceptChanges();

            dsReport.Tables.Add(dtLotInfo);

            DataTable dtProcess = SqlExecuter.Query("SelectProcessResultAndRoutingForLotCard_Normal", "10001", new Dictionary<string, object>() { { "LOTID", lotId }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });

            DataTable dtProcessList = new DataTable();
            dtProcessList.Columns.Add("LOTID", typeof(string));
            dtProcessList.Columns.Add("SEQUENCE1", typeof(string));
            dtProcessList.Columns.Add("CHANGESTATE1", typeof(string));
            dtProcessList.Columns.Add("PROCESSNAME1", typeof(string));
            dtProcessList.Columns.Add("PROCESSINGDATE1", typeof(string));
            dtProcessList.Columns.Add("PROCESSQTY1", typeof(string));
            dtProcessList.Columns.Add("WORKPLACEWORKER1", typeof(string));
            dtProcessList.Columns.Add("SEQUENCE2", typeof(string));
            dtProcessList.Columns.Add("CHANGESTATE2", typeof(string));
            dtProcessList.Columns.Add("PROCESSNAME2", typeof(string));
            dtProcessList.Columns.Add("PROCESSINGDATE2", typeof(string));
            dtProcessList.Columns.Add("PROCESSQTY2", typeof(string));
            dtProcessList.Columns.Add("WORKPLACEWORKER2", typeof(string));

            List<string> lotList = lotId.Split(',').ToList();
            lotList.ForEach(id =>
            {
                DataTable tempTable = dtProcess.Select("LOTID = '" + id + "'").CopyToDataTable().Rows.Cast<DataRow>().OrderBy(row => row["SEQUENCE"]).CopyToDataTable();

                int totalProcessCount = tempTable.Rows.Count;
                int pageCount = (totalProcessCount / (printProcessRowPerPage * 2)) + ((totalProcessCount % (printProcessRowPerPage * 2) == 0) ? 0 : 1);

                int rowNumber = 0;

                DataTable tempResult = dtProcessList.Clone();

                for (int i = 0; i < pageCount; i++)
                {
                    for (int j = 0; j < printProcessRowPerPage; j++)
                    {
                        rowNumber = (i * printProcessRowPerPage * 2) + j;

                        if (rowNumber >= totalProcessCount)
                            break;

                        DataRow processRow = tempTable.Rows[rowNumber];

                        DataRow newRow = tempResult.NewRow();

                        newRow["LOTID"] = processRow["LOTID"];
                        newRow["SEQUENCE1"] = processRow["USERSEQUENCE"];
                        newRow["CHANGESTATE1"] = processRow["DIVISION"];
                        newRow["PROCESSNAME1"] = processRow["PROCESSSEGMENTNAME"];
                        newRow["PROCESSINGDATE1"] = processRow["SENDTIME"];
                        newRow["PROCESSQTY1"] = processRow["SENDQTY"];
                        newRow["WORKPLACEWORKER1"] = processRow["SENDUSER"];


                        tempResult.Rows.Add(newRow);
                    }

                    for (int j = 0; j < printProcessRowPerPage; j++)
                    {
                        rowNumber = (i * printProcessRowPerPage * 2) + (j + printProcessRowPerPage);

                        if (rowNumber >= totalProcessCount)
                            break;

                        DataRow processRow = tempTable.Rows[rowNumber];

                        DataRow newRow = tempResult.Rows[rowNumber - (printProcessRowPerPage * (i + 1))];

                        newRow["LOTID"] = processRow["LOTID"];
                        newRow["SEQUENCE2"] = processRow["USERSEQUENCE"];
                        newRow["CHANGESTATE2"] = processRow["DIVISION"];
                        newRow["PROCESSNAME2"] = processRow["PROCESSSEGMENTNAME"];
                        newRow["PROCESSINGDATE2"] = processRow["SENDTIME"];
                        newRow["PROCESSQTY2"] = processRow["SENDQTY"];
                        newRow["WORKPLACEWORKER2"] = processRow["SENDUSER"];
                    }
                }

                dtProcessList.Merge(tempResult);
            });


            dtProcessList.AcceptChanges();

            dsReport.Tables.Add(dtProcessList);

            DataRelation relation = new DataRelation("RelationLotId", dtLotInfo.Columns["LOTID"], dtProcessList.Columns["LOTID"]);

            dsReport.Relations.Add(relation);

            //string fileName = "";

            //switch (type)
            //{
            //    case LotCardType.ProductionSample:
            //        fileName = "Lot Card_Production.repx";
            //        break;
            //    case LotCardType.Split:
            //        break;
            //    default:
            //        break;
            //}

            //XtraReport report = XtraReport.FromFile(Path.Combine(Application.StartupPath, "Reports", fileName));
            XtraReport report = XtraReport.FromStream(stream);
            report.DataSource = dsReport;
            report.DataMember = "Table1";

            Band band = report.Bands["Detail"];
            //SetReportControlDataBinding(band.Controls, dsReport.Tables[0]);


            DetailReportBand detailReport = report.Bands["DetailReport"] as DetailReportBand;
            detailReport.DataSource = dsReport;
            detailReport.DataMember = "RelationLotId";

            Band groupHeader = detailReport.Bands["GroupHeader1"];
            SetReportControlDataBinding(groupHeader.Controls, dsReport, "");

            XRControl picLogo = groupHeader.FindControl("picLogo", true);

            if (picLogo != null && picLogo is XRPictureBox picBox)
            {
                if (UserInfo.Current.Enterprise == "INTERFLEX")
                    picBox.Image = Properties.Resources.Logo_Interflex;
                else if (UserInfo.Current.Enterprise == "YOUNGPOONG")
                    picBox.Image = Properties.Resources.Logo_Youngpoong;
            }

            Band detailBand = detailReport.Bands["Detail1"];
            setLabelLaungage(detailReport);
            SetReportControlDataBinding(detailBand.Controls, dsReport, "RelationLotId");


            //report.Print();
            report.ShowPreviewDialog();
        }
        #endregion

        #region  - SetReportControlDataBinding :: Report 파일의 컨트롤 중 Tag(FieldName) 값이 있는 컨트롤에 DataBinding(Text)를 추가한다. |
        /// <summary>
        /// Report 파일의 컨트롤 중 Tag(FieldName) 값이 있는 컨트롤에 DataBinding(Text)를 추가한다.
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="dataSource"></param>
        private static void SetReportControlDataBinding(XRControlCollection controls, DataSet dataSource, string relationId)
        {
            if (controls.Count > 0)
            {
                foreach (XRControl control in controls)
                {
                    if (!string.IsNullOrWhiteSpace(control.Tag.ToString()) && !control.Name.Substring(0, 3).Equals("lbl"))
                    {
                        string fieldName = "";

                        if (!string.IsNullOrWhiteSpace(relationId))
                            fieldName = string.Join(".", relationId, control.Tag.ToString());
                        else
                            fieldName = control.Tag.ToString();

                        control.DataBindings.Add("Text", dataSource, fieldName);
                    }

                    SetReportControlDataBinding(control.Controls, dataSource, relationId);
                }
            }
        }
        #endregion

        #region - CheckLotProcessStateByStepType :: Lot 정보의 StepType과 ProcessState에 따라 4-Step 화면에서 처리 가능 여부를 판단한다. |
        /// <summary>
        /// Lot 정보의 StepType과 ProcessState에 따라 4-Step 화면에서 처리 가능 여부를 판단한다.
        /// </summary>
        /// <param name="processType">현재 화면의 작업 구분</param>
        /// <param name="processState">해당 Lot의 Process State</param>
        /// <param name="stepType">Lot의 현재 공정의 Step Type</param>
        /// <returns>해당 Lot 정보가 현재 화면에서 작업 처리가 가능한지 여부</returns>
        public static bool CheckLotProcessStateByStepType(ProcessType processType, string processState, string stepType)
        {
            string processStateByCurrentStep = GetProcessStateByProcessType(processType);
            string[] stepList = stepType.Split(',');

            if (string.IsNullOrWhiteSpace(processStateByCurrentStep))
                return false;

            if (stepList.Length < 1 || !stepList.Contains(processStateByCurrentStep))
                return false;

            switch (processType)
            {
                case ProcessType.LotAccept:
                    if (processState.Equals(Constants.WaitForReceive))
                        return true;
                    else
                        return false;
                case ProcessType.StartWork:
                    if ((processState.Equals(Constants.Wait) && stepList.Contains(Constants.WaitForReceive))
                        || (processState.Equals(Constants.WaitForReceive) && !stepList.Contains(Constants.WaitForReceive)))
                        return true;
                    else
                        return false;
                case ProcessType.WorkCompletion:
                    if ((processState.Equals(Constants.Run) && stepList.Contains(Constants.Wait))
                        || (processState.Equals(Constants.Wait) && !stepList.Contains(Constants.Wait) && stepList.Contains(Constants.WaitForReceive))
                        || (processState.Equals(Constants.WaitForReceive) && !stepList.Contains(Constants.Wait) && !stepList.Contains(Constants.WaitForReceive)))
                        return true;
                    else
                        return false;
                case ProcessType.TransitRegist:
                    if ((processState.Equals(Constants.WaitForSend) && stepList.Contains(Constants.Run))
                        || (processState.Equals(Constants.Run) && !stepList.Contains(Constants.Run) && stepList.Contains(Constants.Wait))
                        || (processState.Equals(Constants.Wait) && !stepList.Contains(Constants.Run) && !stepList.Contains(Constants.Wait) && stepList.Contains(Constants.WaitForReceive))
                        || (processState.Equals(Constants.WaitForReceive) && !stepList.Contains(Constants.Run) && !stepList.Contains(Constants.Wait) && !stepList.Contains(Constants.WaitForReceive)))
                        return true;
                    else
                        return false;
                default:
                    return false;
            }
        }
        #endregion

        #region  - GetProcessStateByProcessType :: 화면의 작업 구분에 따라 해당 화면에서 사용되는 Process State 정보를 반환한다. |
        /// <summary>
        /// 화면의 작업 구분에 따라 해당 화면에서 사용되는 Process State 정보를 반환한다.
        /// </summary>
        /// <param name="processType">현재 화면의 작업 구분</param>
        /// <returns>작업 구분에 따라 Lot이 가져야하는 Process State 문자열</returns>
        private static string GetProcessStateByProcessType(ProcessType processType)
        {
            switch (processType)
            {
                case ProcessType.LotAccept:
                    return Constants.WaitForReceive;
                case ProcessType.StartWork:
                    return Constants.Wait;
                case ProcessType.WorkCompletion:
                    return Constants.Run;
                case ProcessType.TransitRegist:
                    return Constants.WaitForSend;
                default:
                    return "";
            }
        }
        #endregion

        #region - CheckRCLot :: Lot의 RC 여부에 따라 Lot Card Revision을 비교하고 Revision이 다른 경우 Revision Lot Card를 출력하도록 메시지를 보여준다. |
        /// <summary>
        /// Lot의 RC 여부에 따라 Lot Card Revision을 비교하고 Revision이 다른 경우 Revision Lot Card를 출력하도록 메시지를 보여준다.
        /// </summary>
        /// <param name="lotInfo">공정 4-Step 화면에서 조회한 Lot 정보</param>
        /// <returns></returns>
        public static bool CheckRCLot(DataTable lotInfo)
        {
            DataRow row = lotInfo.Rows.Cast<DataRow>().FirstOrDefault();

            string isPrintLotCard = row["ISPRINTLOTCARD"].ToString();
            string isPrintRcLotCard = row["ISPRINTRCLOTCARD"].ToString();

            if (isPrintLotCard == "N" && isPrintRcLotCard == "Y")
            {
                string lotId = row["LOTID"].ToString();
                string productDefId = row["PRODUCTDEFID"].ToString();
                string productDefVersion = row["PRODUCTDEFVERSION"].ToString();

                string productRevision = productDefId + productDefVersion;

                ProductRevisionInputPopup popup = new ProductRevisionInputPopup();
                popup._LotId = lotId;
                popup._ProductRevision = productRevision;
                popup.ShowDialog();

                //if (productRevision != popup._ProductRevision)
                //{
                //    // Scan 한 Lot Card는 이전 Revision의 Lot Card 입니다. 신규 Revision Lot Card 출력 후 Scan 하시기 바랍니다.
                //    //MSGBox.Show(MessageBoxType.Warning, "NotEqualLotCardRevision");
                //    // Scan 한 Lot Card는 이전 Revision의 Lot Card 입니다. 신규 Revision Lot Card를 출력하시겠습니까?
                //    if (MSGBox.Show(MessageBoxType.Question, "NotEqualLotCardRevisionPrint", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    {
                //        PrintLotCard(row["LOTID"].ToString(), LotCardType.RCChange);
                //    }

                //    return false;
                //}


                //MessageWorker worker = new MessageWorker("SavePrintLotCard");
                //worker.SetBody(new MessageBody()
                //{
                //    { "LotId", row["LOTID"].ToString() }
                //});

                //worker.Execute();

                return true;
            }


            return true;
        }
        #endregion

        #region - PrintRequestConsumableRelease :: 자재불출요청 - 전표 출력 |
        /// <summary>
        /// 자재불출요청 - 전표 출력
        /// </summary>
        /// <param name="requestNo"></param>
        public static void PrintRequestConsumableRelease(string requestNo, Stream stream)
        {
            DataTable dtHeaderInfo2 = SqlExecuter.Query("SelectPrintChitHeaderInfo", "10001", new Dictionary<string, object>() { { "REQUESTNO", requestNo }, { "LANGUAGETYPE", UserInfo.Current.LanguageType }, { "PLANTID", UserInfo.Current.Plant } });
            DataTable dtTableInfo2 = SqlExecuter.Query("SelectPrintChitDetailTable", "10001", new Dictionary<string, object>() { { "REQUESTNO", requestNo }, { "PLANTID", UserInfo.Current.Plant } });


            XtraReport[] reports = null;
            XtraReport printReport = new XtraReport();
            DataTable[] tableInfoByPage = null;

            int cnt = dtTableInfo2.Rows.Count;
            int rest = cnt % 9;
            int val = cnt / 9;

            reports = val.Equals(0) ? new XtraReport[1] : (rest.Equals(0) ? new XtraReport[val] : new XtraReport[val + 1]);
            tableInfoByPage = val.Equals(0) ? new DataTable[1] : (rest.Equals(0) ? new DataTable[val] : new DataTable[val + 1]);
            int virtualVal = val.Equals(0) ? 1 : (rest.Equals(0) ? val : val + 1);

            for (int i = 0; i < virtualVal; i++)
            {
                reports[i] = XtraReport.FromStream(stream);
                tableInfoByPage[i] = dtTableInfo2.Clone();

                if ((i < val) || (virtualVal.Equals(1) && rest.Equals(0)))
                {
                    tableInfoByPage[i] = TableDataDivide(dtTableInfo2, tableInfoByPage[i], i * 9, 9);
                }
                else if (!val.Equals(virtualVal))
                {
                    tableInfoByPage[i] = TableDataDivide(dtTableInfo2, tableInfoByPage[i], i * 9, rest);
                }

                //빈 row 채우기
                if (rest > 0 && (i + 1) == virtualVal)
                {
                    for (int k = 0; k < (9 - rest); k++)
                    {
                        DataRow newRow = tableInfoByPage[i].NewRow();
                        newRow["REQUESTNO"] = requestNo;

                        tableInfoByPage[i].Rows.Add(newRow);
                    }
                }

                DataTable headerInfoByPage = dtHeaderInfo2.Copy();

                DataSet dsReport = new DataSet();
                headerInfoByPage.TableName = "HeaderInfo";
                tableInfoByPage[i].TableName = "TableInfo";
                dsReport.Tables.Add(headerInfoByPage);
                dsReport.Tables.Add(tableInfoByPage[i]);

                DataRelation relation = new DataRelation("RelationRequestNo", headerInfoByPage.Columns["REQUESTNO"], tableInfoByPage[i].Columns["REQUESTNO"]);
                dsReport.Relations.Add(relation);

                printReport.Pages.Add(SetReortPageData(reports[i], dsReport, "RelationRequestNo").FirstOrDefault());

            }


            printReport.ShowPreviewDialog();
        }
        #endregion

        #region - SetReortPageData :: 자재불출요청 page별 데이터 바인드 |
        /// <summary>
        /// 자재불출요청 page별 데이터 바인드
        /// </summary>
        /// <param name="report"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static PageList SetReortPageData(XtraReport report, DataSet ds, string relationNo)
        {
            report.DataSource = ds;
            report.DataMember = "HeaderInfo";

            //회수용			
            DetailReportBand detailReport = report.Bands["DetailReport"] as DetailReportBand;
            detailReport.DataSource = ds;
            detailReport.DataMember = relationNo;

            Band groupHeader = detailReport.Bands["GroupHeader1"];
            SetReportControlDataBinding(groupHeader.Controls, ds, "");

            Band detailBand = detailReport.Bands["Detail1"];
            SetReportControlDataBinding(detailBand.Controls, ds, relationNo);

            setLabelLaungage(detailReport, "GroupHeader1");

            //불출용
            DetailReportBand detailReport1 = report.Bands["DetailReport1"] as DetailReportBand;
            detailReport1.DataSource = ds;
            detailReport1.DataMember = relationNo;

            Band groupHeader1 = detailReport1.Bands["GroupHeader2"];
            SetReportControlDataBinding(groupHeader1.Controls, ds, "");

            Band detailBand1 = detailReport1.Bands["Detail2"];
            SetReportControlDataBinding(detailBand1.Controls, ds, relationNo);

            setLabelLaungage(detailReport1, "GroupHeader2");

            report.CreateDocument();

            return report.Pages;
        }
        #endregion

        #region - PrintBoxPacking :: 포장 인계 - 전표 출력 |
        /// <summary>
        /// 포장 인계 - 전표 출력
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="transitInfo"></param>
        public static void PrintBoxPacking(Stream stream, DataTable transitInfo)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("BOXNO", Format.GetString(transitInfo.Rows[0]["BOXNO"]));
            //param.Add("LOTID", Format.GetString(transitInfo.Rows[0]["LOTID"]));
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtDoc = SqlExecuter.Query("GetBoxPackingDocumentNo", "10001", param);
            DataTable dtDocumentInfo = dtDoc.Clone();

            DataRow row = dtDocumentInfo.NewRow();
            row["DOCUMENTNO"] = dtDoc.Rows[0]["DOCUMENTNO"];
            row["PRODUCTDEFID"] = dtDoc.Rows[0]["PRODUCTDEFID"];
            row["PRODUCTDEFNAME"] = dtDoc.Rows[0]["PRODUCTDEFNAME"];
            row["UNIT"] = dtDoc.Rows[0]["UNIT"];
            row["SENDTIME"] = dtDoc.Rows[0]["SENDTIME"];
            row["AREAID"] = dtDoc.Rows[0]["AREAID"];
            row["AREANAME"] = dtDoc.Rows[0]["AREANAME"];
            row["NOWDATE"] = dtDoc.Rows[0]["NOWDATE"];
            dtDocumentInfo.Rows.Add(row);


            dtDocumentInfo.Columns.Add("TOTALSENDQTY", typeof(decimal));//인계수량
            dtDocumentInfo.Columns.Add("TOTALPAGE", typeof(decimal));//총 페이지
            dtDocumentInfo.Columns.Add("CURRENTPAGE", typeof(decimal));//현재 페이지
            decimal qty = transitInfo.AsEnumerable().Sum(x => Format.GetDecimal(x["PCSQTY"]));
            dtDocumentInfo.Rows[0]["TOTALSENDQTY"] = qty;


            XtraReport[] reports = null;
            XtraReport printReport = new XtraReport();
            DataTable[] tableInfoByPage = null;

            int cnt = transitInfo.Rows.Count;
            int rest = cnt % 9;
            int val = cnt / 9;

            reports = val.Equals(0) ? new XtraReport[1] : (rest.Equals(0) ? new XtraReport[val] : new XtraReport[val + 1]);
            tableInfoByPage = val.Equals(0) ? new DataTable[1] : (rest.Equals(0) ? new DataTable[val] : new DataTable[val + 1]);
            int virtualVal = val.Equals(0) ? 1 : (rest.Equals(0) ? val : val + 1);

            for (int i = 0; i < virtualVal; i++)
            {
                //페이지 정보
                dtDocumentInfo.Rows[0]["TOTALPAGE"] = virtualVal;
                dtDocumentInfo.Rows[0]["CURRENTPAGE"] = i + 1;

                reports[i] = XtraReport.FromStream(stream);
                tableInfoByPage[i] = transitInfo.Clone();

                if ((i < val) || (virtualVal.Equals(1) && rest.Equals(0)))
                {
                    tableInfoByPage[i] = TableDataDivide(transitInfo, tableInfoByPage[i], i * 9, 9);
                }
                else if (!val.Equals(virtualVal))
                {
                    tableInfoByPage[i] = TableDataDivide(transitInfo, tableInfoByPage[i], i * 9, rest);
                }


                //빈 row 채우기
                if (rest > 0 && (i + 1) == virtualVal)
                {
                    for (int k = 0; k < (9 - rest); k++)
                    {
                        DataRow newRow = tableInfoByPage[i].NewRow();
                        newRow["DOCUMENTNO"] = dtDocumentInfo.Rows.Cast<DataRow>().FirstOrDefault()["DOCUMENTNO"];

                        tableInfoByPage[i].Rows.Add(newRow);
                    }
                }

                DataTable headerInfoByPage = dtDocumentInfo.Copy();

                DataSet dsReport = new DataSet();
                headerInfoByPage.TableName = "HeaderInfo";
                tableInfoByPage[i].TableName = "TableInfo";
                dsReport.Tables.Add(headerInfoByPage);
                dsReport.Tables.Add(tableInfoByPage[i]);

                DataRelation relation = new DataRelation("RelationDocumentNo", headerInfoByPage.Columns["DOCUMENTNO"], tableInfoByPage[i].Columns["DOCUMENTNO"]);
                dsReport.Relations.Add(relation);

                printReport.Pages.Add(SetReortPageData(reports[i], dsReport, "RelationDocumentNo").FirstOrDefault());
            }

            printReport.ShowPreviewDialog();
        }
        #endregion

        #region - PrintWipPhysicalCountList :: 재공실사관리 - 재공실사표 출력 |
        /// <summary>
        /// 재공실사관리 - 재공실사표 출력
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="dt"></param>
        public static void PrintWipPhysicalCountList(Stream stream, DataTable dt)
        {
            //각 작업장 별 실사 LIST 출력
            var query = from dataRow in dt.AsEnumerable()
                        orderby dataRow["AREAID"]
                        select new
                        {
                            AREAID = dataRow["AREAID"],
                            AREANAME = dataRow["AREANAME"],
                            PRODUCTDEFID = dataRow["PRODUCTDEFID"],
                            PRODUCTDEFNAME = dataRow["PRODUCTDEFNAME"],
                            LOTID = dataRow["LOTID"],
                            PROCESSSEGMENTNAME = dataRow["PROCESSSEGMENTNAME"],
                            PANELQTY = dataRow["PANELQTY"],
                            QTY = dataRow["QTY"],
                            EAQTY = dataRow["EAQTY"]
                        };

            //디테일 TOTAL 정보
            DataTable detailInfo = new DataTable();
            detailInfo.Columns.Add("SEQ", typeof(int));
            detailInfo.Columns.Add("AREAID", typeof(string));
            detailInfo.Columns.Add("AREANAME", typeof(string));
            detailInfo.Columns.Add("PRODUCTDEFID", typeof(string));
            detailInfo.Columns.Add("PRODUCTDEFNAME", typeof(string));
            detailInfo.Columns.Add("LOTID", typeof(string));
            detailInfo.Columns.Add("PROCESSSEGMENTNAME", typeof(string));
            detailInfo.Columns.Add("PANELQTY", typeof(decimal));
            detailInfo.Columns.Add("QTY", typeof(decimal));
            detailInfo.Columns.Add("EAQTY", typeof(decimal));

            var dl = query.ToList();
            string prevArea = string.Empty;
            int cnt = 0;
            for (int i = 0; i < dl.Count; i++)
            {
                if (!prevArea.Equals(dl[i].AREAID.ToString()))
                {
                    prevArea = dl[i].AREAID.ToString();
                    cnt = 1;
                }

                detailInfo.Rows.Add(cnt, dl[i].AREAID.ToString(), dl[i].AREANAME.ToString(), dl[i].PRODUCTDEFID.ToString(), dl[i].PRODUCTDEFNAME.ToString(), dl[i].LOTID.ToString(),
                    dl[i].PROCESSSEGMENTNAME.ToString(), Format.GetDecimal(dl[i].PANELQTY, 0), Format.GetDecimal(dl[i].QTY, 0), Format.GetDecimal(dl[i].EAQTY, 0));

                cnt++;
            }

            List<string> areaList = detailInfo.AsEnumerable().Select(r => Format.GetString(r["AREAID"])).Distinct().ToList();
            for (int i = 0; i < areaList.Count; i++)
            {
                var wipListByArea = from dataRow in detailInfo.AsEnumerable()
                                    where dataRow["AREAID"].ToString() == areaList[i].ToString()
                                    select dataRow;

                //작업장별 디테일 정보
                DataTable dtDetail = wipListByArea.Cast<DataRow>().CopyToDataTable();

                //헤더 정보
                DataTable dtHeader = new DataTable();
                dtHeader.Columns.Add("AREAID", typeof(string));
                dtHeader.Columns.Add("AREANAME", typeof(string));

                DataRow row = dtHeader.NewRow();
                row["AREAID"] = dtDetail.Rows[0]["AREAID"].ToString();
                row["AREANAME"] = dtDetail.Rows[0]["AREANAME"].ToString();
                dtHeader.Rows.Add(row);

                DataSet dsReport = new DataSet();
                dtHeader.TableName = "HeaderInfo";
                dtDetail.TableName = "TableInfo";
                dsReport.Tables.Add(dtHeader);
                dsReport.Tables.Add(dtDetail);

                DataRelation relation = new DataRelation("RelationAreaId", dtHeader.Columns["AREAID"], dtDetail.Columns["AREAID"]);
                dsReport.Relations.Add(relation);

                XtraReport report = XtraReport.FromStream(stream);
                report.DataSource = dsReport;
                report.DataMember = "HeaderInfo";

                DetailReportBand detailReport = report.Bands["DetailReport"] as DetailReportBand;
                detailReport.DataSource = dsReport;
                detailReport.DataMember = "RelationAreaId";

                Band groupHeader = detailReport.Bands["GroupHeader1"];
                SetReportControlDataBinding(groupHeader.Controls, dsReport, "");

                Band detailBand = detailReport.Bands["Detail1"];
                setLabelLaungage(detailReport);
                SetReportControlDataBinding(detailBand.Controls, dsReport, "RelationAreaId");

                setLabelLaungage(detailReport, "GroupHeader1");

                //report.Print();
                report.ShowPreviewDialog();
            }

        }
        #endregion

        #endregion

        #region ◆ Grid Event |

        #region - SetGridDoubleClickCheck :: Grid Row Double Click 시 Grid Check 설정 |
        /// <summary>
        /// Grid Row Double Click 시 Grid Check 설정
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="sender"></param>
        public static void SetGridDoubleClickCheck(Micube.Framework.SmartControls.SmartBandedGrid grd, object sender)
        {
            // 더블클릭 시 체크박스 체크
            Micube.Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView view = (Micube.Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView)sender;

            if (grd.View.IsRowChecked(view.FocusedRowHandle))
                grd.View.CheckRow(view.FocusedRowHandle, false);
            else
                grd.View.CheckRow(view.FocusedRowHandle, true);
        }
        #endregion

        #region - SetGridRowStyle :: Grid Row Stype 설정 |
        /// <summary>
        /// Grid Row Stype 설정
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="e"></param>
        public static void SetGridRowStyle(Micube.Framework.SmartControls.SmartBandedGrid grd, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            int rowIndex = grd.View.FocusedRowHandle;

            if (rowIndex == e.RowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(254, 254, 16);
                e.HighPriority = true;
            }
        }
        #endregion

        #region  - SetGridColumnData :: Grid Column의 데이터 세팅 |
        /// <summary>
        /// Grid Column의 데이터 세팅
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="dr"></param>
        public static void SetGridColumnData(SmartBandedGrid grd, DataRow dr)
        {
            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn dc in grd.View.Columns)
            {
                if (dr.GetObject(dc.FieldName) == null) continue;

                string data = dr[dc.FieldName].ToString();

                if (dr.Table.Columns[dc.FieldName].DataType.Name.Equals("Decimal"))
                    grd.View.SetFocusedRowCellValue(dc.FieldName, Convert.ToDecimal(dr[dc.FieldName].ToString()));
                else
                    grd.View.SetFocusedRowCellValue(dc.FieldName, dr[dc.FieldName].ToString());
            }
        }
        #endregion

        #endregion

        #region YJKIM 
        public static Dictionary<string, object> ConvertParameter(Dictionary<string, object> target)
        {
            Dictionary<string, object> convertData = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> item in target)
            {
                if (item.Value != null)
                    convertData[item.Key] = changeArgStringSQL(item.Value.ToString());
                else
                    convertData[item.Key] = null;
            }

            return convertData;
        }
        #region - changeArgString :: SQL Injection 문자열 대체 |
        /// <summary>
        /// SQL Injection 문자열 대체
        /// </summary>
        /// <param name="sArgStr"></param>
        /// <returns></returns>
        public static string changeArgStringSQL(string sArgStr)
        {
            sArgStr = sArgStr.Replace("'", "''");

            return sArgStr;
        }
        #endregion
        #endregion

        #region ◆ ULVAC 라벨 :::
        /// <summary>
        /// LOT 라벨을 발행한다. 라벨타입은 품목코드에 맵핑된다.
        /// </summary>
        /// <param name="lotId">LOT ID</param>
        public static void PrintLotLabel(string lotId, short copy = 1)
        {
            CommonFunction.printCopies = copy;
            var param = new Dictionary<string, object>()
            {
                { "LOTID", lotId }
                , { "LABELTYPE", "Lot" }
                , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };

            DataTable labelQuery = SqlExecuter.Query("GetLotLabelQuery", "00001", param);
            if (labelQuery.Rows.Count == 0)
            {
                // 라벨 발행정보를 찾을 수 없습니다. 라벨-품목 맵핑을 확인해주세요.
                throw MessageException.Create("MappedLabelNotExists");
            }
            foreach (DataRow eachLabel in labelQuery.Rows)
            {
                if (!string.IsNullOrEmpty(eachLabel["QUERYID"].ToString()))
                {
                    DataTable lot = SqlExecuter.Query(eachLabel["QUERYID"].ToString()
                        , eachLabel["QUERYVERSION"].ToString(), param);
                    if (lot.Rows.Count == 0)
                    {
                        // LOT을 찾을 수 없습니다. {0}
                        throw MessageException.Create("LotIsNotExists", string.Format("LotId={0}", lotId));
                    }
                    XtraReport report = GetLabelReport(eachLabel["LABELID"].ToString());
                    report.ShowPrintMarginsWarning = false;
                    MapDataRowToXtraReport(lot.Rows[0], report);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.PrintingSystem.StartPrint += (s, e) =>
                    {
                        e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
                    };
                    printTool.Print();
                }
                else
                {
                    XtraReport report = GetLabelReport(eachLabel["LABELID"].ToString());
                    report.ShowPrintMarginsWarning = false;
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.PrintingSystem.StartPrint += (s, e) =>
                    {
                        e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
                    };
                    printTool.Print();
                }
            }
        }

        public static void PrintProductLabel(string lotId, short copy = 1)
        {
            CommonFunction.printCopies = copy;
            var param = new Dictionary<string, object>()
            {
                { "LOTID", lotId }
                , { "LABELTYPE", "Product" }
                , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };

            DataTable labelQuery = SqlExecuter.Query("GetLotLabelQuery", "00001", param);
            if (labelQuery.Rows.Count == 0)
            {
                // 라벨 발행정보를 찾을 수 없습니다. 라벨-품목 맵핑을 확인해주세요.
                throw MessageException.Create("MappedLabelNotExists");
            }
            foreach (DataRow eachLabel in labelQuery.Rows)
            {
                if (!string.IsNullOrEmpty(eachLabel["QUERYID"].ToString()))
                {
                    DataTable lot = SqlExecuter.Query(eachLabel["QUERYID"].ToString()
                        , eachLabel["QUERYVERSION"].ToString(), param);
                    if (lot.Rows.Count == 0)
                    {
                        // LOT을 찾을 수 없습니다. {0}
                        throw MessageException.Create("LotIsNotExists", string.Format("LotId={0}", lotId));
                    }
                    XtraReport report = GetLabelReport(eachLabel["LABELID"].ToString());
                    report.ShowPrintMarginsWarning = false;
                    MapDataRowToXtraReport(lot.Rows[0], report);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.PrintingSystem.StartPrint += (s, e) =>
                    {
                        e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
                    };
                    printTool.Print();
                }
                else
                {
                    XtraReport report = GetLabelReport(eachLabel["LABELID"].ToString());
                    report.ShowPrintMarginsWarning = false;
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.PrintingSystem.StartPrint += (s, e) =>
                    {
                        e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
                    };
                    printTool.Print();
                }
            }
        }

        public static void PrintShippingLabel(string lotId, short copy = 1)
        {
            CommonFunction.printCopies = copy;
            var param = new Dictionary<string, object>()
            {
                { "LOTID", lotId }
                , { "LABELTYPE", "Package" }
                , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };

            DataTable labelQuery = SqlExecuter.Query("GetLotLabelQuery", "00001", param);
            if (labelQuery.Rows.Count == 0)
            {
                // 라벨 발행정보를 찾을 수 없습니다. 라벨-품목 맵핑을 확인해주세요.
                throw MessageException.Create("MappedLabelNotExists");
            }
            foreach (DataRow eachLabel in labelQuery.Rows)
            {
                if (!string.IsNullOrEmpty(eachLabel["QUERYID"].ToString()))
                {
                    DataTable lot = SqlExecuter.Query(eachLabel["QUERYID"].ToString()
                        , eachLabel["QUERYVERSION"].ToString(), param);
                    if (lot.Rows.Count == 0)
                    {
                        // LOT을 찾을 수 없습니다. {0}
                        throw MessageException.Create("LotIsNotExists", string.Format("LotId={0}", lotId));
                    }
                    XtraReport report = GetLabelReport(eachLabel["LABELID"].ToString());
                    report.ShowPrintMarginsWarning = false;
                    MapDataRowToXtraReport(lot.Rows[0], report);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.PrintingSystem.StartPrint += (s, e) =>
                    {
                        e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
                    };
                    printTool.Print();
                }
                else
                {
                    XtraReport report = GetLabelReport(eachLabel["LABELID"].ToString());
                    report.ShowPrintMarginsWarning = false;
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.PrintingSystem.StartPrint += (s, e) =>
                    {
                        e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
                    };
                    printTool.Print();
                }
            }
        }

        /// <summary>
        /// 자재 현품표 발행
        /// </summary>
        /// <param name="consumableLotId">자재 LOT ID</param>
        public static void PrintMaterialLabel(string consumableLotId, short copy = 1)
        {
            CommonFunction.printCopies = copy;
            string MATERIAL_LABEL = "L-0007";   // 현품표 라벨
            var param = new Dictionary<string, object>()
            {
                { "LABELID", MATERIAL_LABEL },
                { "CONSUMABLELOTID", consumableLotId },
                { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };

            DataTable labelQuery = SqlExecuter.Query("GetLabelQuery", "00001", param);
            if (labelQuery.Rows.Count == 0)
            {
                // 등록되지 않은 라벨입니다. {0}
                throw MessageException.Create("LabelNotExists", string.Format("LabelId={0}", MATERIAL_LABEL));
            }
            DataTable consumableLot = SqlExecuter.Query(labelQuery.Rows[0]["QUERYID"].ToString()
                , labelQuery.Rows[0]["QUERYVERSION"].ToString(), param);
            if (consumableLot.Rows.Count == 0)
            {
                // 시스템에 등록되지 않은 자재입니다. {0}
                throw MessageException.Create("ConsumableLotNotFound", string.Format("ConsumableLotId={0}", consumableLotId));
            }
            XtraReport report = GetLabelReport(MATERIAL_LABEL);
            report.ShowPrintMarginsWarning = false;
            MapDataRowToXtraReport(consumableLot.Rows[0], report);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.PrintingSystem.StartPrint += (s, e) =>
            {
                e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
            };
            printTool.Print();
        }

        /// <summary>
        /// 창고 CELL 라벨 발행
        /// </summary>
        /// <param name="cellId">CELL ID</param>
        public static void PrintCellLabel(string cellId, short copy = 1)
        {
            CommonFunction.printCopies = copy;
            string CELL_LABEL = "L-0005";   // 창고 CELL 라벨
            var param = new Dictionary<string, object>()
            {
                { "LABELID", CELL_LABEL },
                { "CELLID", cellId },
                { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };

            DataTable labelQuery = SqlExecuter.Query("GetLabelQuery", "00001", param);
            if (labelQuery.Rows.Count == 0)
            {
                // 등록되지 않은 라벨입니다. {0}
                throw MessageException.Create("LabelNotExists", string.Format("LabelId={0}", CELL_LABEL));
            }
            DataTable cell = SqlExecuter.Query(labelQuery.Rows[0]["QUERYID"].ToString()
                , labelQuery.Rows[0]["QUERYVERSION"].ToString(), param);
            if (cell.Rows.Count == 0)
            {
                // 시스템에 등록되지 않은 CELL입니다. {0}
                throw MessageException.Create("CellNotFound", string.Format("CellId={0}", cellId));
            }
            XtraReport report = GetLabelReport(CELL_LABEL);
            report.ShowPrintMarginsWarning = false;
            MapDataRowToXtraReport(cell.Rows[0], report);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.PrintingSystem.StartPrint += (s, e) =>
            {
                e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
            };
            printTool.Print();
        }

        /// <summary>
        /// 간반 라벨 발행
        /// </summary>
        /// <param name="cellId">CELL ID</param>
        public static void PrintKanbanLabel(string cellId, short copy = 1)
        {
            CommonFunction.printCopies = copy;
            string KANBAN_LABEL = "L-0008";   // 창고 CELL 라벨
            var param = new Dictionary<string, object>()
            {
                { "LABELID", KANBAN_LABEL },
                { "CELLID", cellId },
                { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };

            DataTable labelQuery = SqlExecuter.Query("GetLabelQuery", "00001", param);
            if (labelQuery.Rows.Count == 0)
            {
                // 등록되지 않은 라벨입니다. {0}
                throw MessageException.Create("LabelNotExists", string.Format("LabelId={0}", KANBAN_LABEL));
            }
            DataTable cell = SqlExecuter.Query(labelQuery.Rows[0]["QUERYID"].ToString()
                , labelQuery.Rows[0]["QUERYVERSION"].ToString(), param);
            if (cell.Rows.Count == 0)
            {
                // 시스템에 등록되지 않은 CELL입니다. {0}
                throw MessageException.Create("CellNotFound", string.Format("CellId={0}", cellId));
            }
            XtraReport report = GetLabelReport(KANBAN_LABEL);
            report.ShowPrintMarginsWarning = false;
            MapDataRowToXtraReport(cell.Rows[0], report);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.PrintingSystem.StartPrint += (s, e) =>
            {
                e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
            };
            printTool.Print();
        }

        /// <summary>
        /// 수리 라벨 발행
        /// </summary>
        /// <param name="lotId">LOT ID</param>
        public static void PrintRepairLabel(string lotId, short copy = 1)
        {
            CommonFunction.printCopies = copy;
            string REPAIR_LABEL = "L-0003";   // 수리 라벨
            var param = new Dictionary<string, object>()
            {
                { "LABELID", REPAIR_LABEL },
                { "LOTID", lotId },
                { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };

            DataTable labelQuery = SqlExecuter.Query("GetLabelQuery", "00001", param);
            if (labelQuery.Rows.Count == 0)
            {
                // 등록되지 않은 라벨입니다. {0}
                throw MessageException.Create("LabelNotExists", string.Format("LabelId={0}", REPAIR_LABEL));
            }
            DataTable lot = SqlExecuter.Query(labelQuery.Rows[0]["QUERYID"].ToString()
                , labelQuery.Rows[0]["QUERYVERSION"].ToString(), param);
            if (lot.Rows.Count == 0)
            {
                // LOT을 찾을 수 없습니다. {0}
                throw MessageException.Create("LotIsNotExists", string.Format("LotId={0}", lotId));
            }
            XtraReport report = GetLabelReport(REPAIR_LABEL);
            report.ShowPrintMarginsWarning = false;
            MapDataRowToXtraReport(lot.Rows[0], report);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.PrintingSystem.StartPrint += (s, e) =>
            {
                e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
            };
            printTool.Print();
        }

        /// <summary>
        /// 무지시 공정 완료 자재라벨 발행
        /// </summary>
        /// <param name="lotId">LOT ID</param>
        public static void PrintNonOrderWorkMaterialLabel(string lotId, short copy = 1)
        {
            CommonFunction.printCopies = copy;
            string NONORDER_LABEL = "L-0001";   // 무지시 공정 완료 자재 라벨
            var param = new Dictionary<string, object>()
            {
                { "LABELID", NONORDER_LABEL },
                { "LOTID", lotId },
                { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };

            DataTable labelQuery = SqlExecuter.Query("GetLabelQuery", "00001", param);
            if (labelQuery.Rows.Count == 0)
            {
                // 등록되지 않은 라벨입니다. {0}
                throw MessageException.Create("LabelNotExists", string.Format("LabelId={0}", NONORDER_LABEL));
            }
            DataTable lot = SqlExecuter.Query(labelQuery.Rows[0]["QUERYID"].ToString()
                , labelQuery.Rows[0]["QUERYVERSION"].ToString(), param);
            if (lot.Rows.Count == 0)
            {
                // LOT을 찾을 수 없습니다. {0}
                throw MessageException.Create("LotIsNotExists", string.Format("LotId={0}", lotId));
            }
            XtraReport report = GetLabelReport(NONORDER_LABEL);
            report.ShowPrintMarginsWarning = false;
            MapDataRowToXtraReport(lot.Rows[0], report);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.PrintingSystem.StartPrint += (s, e) =>
            {
                e.PrintDocument.PrinterSettings.Copies = CommonFunction.printCopies;
            };
            printTool.Print();
        }

        /// <summary>
        /// DB에서 라벨 디자인 데이터를 가져와 XtraReport 객체로 반환한다.
        /// </summary>
        /// <param name="labelId">라벨 ID</param>
        /// <returns>라벨 디자인 데이터. DB에서 해당 라벨을 찾지 못하면 null 반환</returns>
        private static XtraReport GetLabelReport(string labelId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LABELID", labelId);
            DataTable result = SqlExecuter.Query("GetLabelData", "00001", param);
            if (result.Rows.Count == 0 || result.Rows[0]["LABELDATA"] == DBNull.Value
                || result.Rows[0]["LABELDATA"].ToString().Length == 0)
            {
                return null;
            }
            else
            {
                byte[] labelData = Convert.FromBase64String(result.Rows[0]["LABELDATA"].ToString());
                using (MemoryStream stream = new MemoryStream(labelData))
                {
                    return XtraReport.FromStream(stream, true);
                }
            }
        }

        /// <summary>
        /// DataRow의 값을 각 컬럼명에 대응하는 Tag를 가진 콘트롤에 맵핑시킨다. (DetailBand에 속한 콘트롤들)
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="report"></param>
        private static void MapDataRowToXtraReport(DataRow dataRow, XtraReport report)
        {
            Band detailBand = report.Bands.GetBandByType(typeof(DetailBand));
            DoMapDataRowToXtraReport(dataRow, report, detailBand.Controls);
        }

        private static void DoMapDataRowToXtraReport(DataRow dataRow, XtraReport report, XRControlCollection controls)
        {
            foreach (XRControl control in controls)
            {
                if (control is DevExpress.XtraReports.UI.XRLabel || control is DevExpress.XtraReports.UI.XRBarCode)
                {
                    string tag = control.Tag.ToString();
                    // Tag 값이 없는 Control 제외, Tag 값이 DataRow 의 컬럼에 없으면 제외
                    if (string.IsNullOrEmpty(tag) || !dataRow.Table.Columns.Contains(tag))
                    {
                        continue;
                    }
                    control.Text = dataRow[tag].ToString();
                }
                else if (control is DevExpress.XtraReports.UI.XRTable)
                {
                    XRTable table = control as XRTable;
                    foreach (XRTableRow tableRow in table.Rows)
                    {
                        for (int i = 0; i < tableRow.Cells.Count; i++)
                        {
                            string tag = tableRow.Cells[i].Tag.ToString();
                            // Tag 값이 없는 Control 제외, Tag 값이 DataRow 의 컬럼에 없으면 제외
                            if (string.IsNullOrEmpty(tag) || !dataRow.Table.Columns.Contains(tag))
                            {
                                continue;
                            }
                            tableRow.Cells[i].Text = dataRow[tag].ToString();
                        }
                    }
                }
                else if (control is DevExpress.XtraReports.UI.XRPanel)
                {
                    DoMapDataRowToXtraReport(dataRow, report, control.Controls);
                }
            }
        }
        #endregion

        #region 그리드 
        public static void FocusAndSelect(this SmartBandedGridView view, string fieldId, object value)
        {
            int rowHandle = view.GetRowHandleByValue(fieldId, value);
            view.FocusedRowHandle = rowHandle;
            view.ClearSelection();
            view.SelectRow(rowHandle);
        }
        #endregion

        #region 엑셀 실행
        /// <summary>
        /// 2020-06-30 배선용
        /// 엑셀에 데이터를 반인딩하여 출력해준다.
        /// </summary>
        /// <param name="fiilePath"></param>
        /// <param name="dt"></param>
        public static void ExuteExcelBindingData(string fiilePath, DataTable dt)
        {
            Assembly assembly = Assembly.GetAssembly(Type.GetType("Micube.SmartMES.Commons.CommonFunction"));

            Stream stream = assembly.GetManifestResourceStream(fiilePath);

          //  FileStream file = new FileStream(@"D:\ULVAC\Source\Client\src\02.Common\Micube.SmartMES.Commons\Report\QEP-Q-02-02_Defect.xlsx", FileMode.Open, FileAccess.Read);

            XSSFWorkbook workbook = new XSSFWorkbook(stream);

            stream.Close();

            XSSFSheet sheet = (XSSFSheet)workbook.GetSheetAt(0);

            IEnumerator rows = sheet.GetRowEnumerator();
            while (rows.MoveNext())
            {
                IRow irow = (IRow)rows.Current;
                for (int i = 0; i < irow.Count(); i++)
                {
                    ICell cell = irow.Cells[i];
                    string value = ConertStringCellValue(cell);

                    if (string.IsNullOrEmpty(value)) continue;

                    if (value.Substring(0, 1).Equals("@"))
                    {
                        string CompareValue = value.TrimStart('@');
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (CompareValue.Equals(dt.Columns[j].ColumnName))
                            {
                                cell.SetCellValue(Format.GetTrimString(dt.Rows[0][dt.Columns[j].ColumnName]));
                            }
                        }
                    }
                }
            }
            string saveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Constants.QualityDocTempFileName;
            FileStream file1 = new FileStream(saveFilePath, FileMode.Create);    
            workbook.Write(file1, false);
            file1.Close();

            System.Diagnostics.Process.Start(saveFilePath);

        }
        private static string ConertStringCellValue(ICell cell)
        {
            object value = null;

            switch (cell.CellType)
            {
                case CellType.Unknown:
                    break;
                case CellType.Numeric:
                    if (cell.CellStyle.GetDataFormatString() == "m/d/yy")
                    {
                        value = cell.DateCellValue;
                    }
                    else
                    {
                        value = cell.NumericCellValue;
                    }
                    break;
                case CellType.String:
                    value = cell.StringCellValue;
                    break;
                case CellType.Formula:
                    break;
                case CellType.Blank:
                    break;
                case CellType.Boolean:
                    break;
                case CellType.Error:
                    break;

            }

            if (value != null)
                return value.ToString();
            else return string.Empty;

        }
        #endregion

        #region Lot 취소 팝업 호출

        public static void LotCancelPopup(string Lotid)
        {
            LotCancelPopUp popup = new LotCancelPopUp();

            popup.StartPosition = FormStartPosition.CenterParent;
            popup.Lotid = Lotid;
            popup.ShowDialog();

        }

        #endregion
    }
}
