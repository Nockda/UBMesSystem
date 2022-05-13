#region using

using DevExpress.XtraDiagram;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Equipment.Properties;
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

namespace Micube.SmartMES.Equipment
{
	/// <summary>
	/// 프 로 그 램 명  : 설비관리 > 모니터링 > 설비모니터링
	/// 업  무  설  명  : 설비 실시간 모니터링 화면
	/// 생    성    자  : 정승원
	/// 생    성    일  : 2020-07-01
	/// 수  정  이  력  : 
	/// 
	/// 
	/// </summary>
	public partial class EquipmentMonitoring : SmartConditionBaseForm
	{
		/// <summary>
		/// 상태별 이미지
		/// </summary>
		public Dictionary<string, Bitmap> pairs = new Dictionary<string, Bitmap>();

		#region 생성자
		public EquipmentMonitoring()
		{
			InitializeComponent();
		}

		#endregion

		#region 컨텐츠 영역 초기화

		/// <summary>
		/// 화면의 컨텐츠 영역을 초기화한다.
		/// </summary>
		protected override void InitializeContent()
		{
			base.InitializeContent();

			//MCT/MYNX-7500
			AddXYControls(MonitoringEquipmentId.MG17001, 1011, 346, 1040, 290, 150, 160);
			//WT-250Ⅱ 1호기
			AddXYControls(MonitoringEquipmentId.MG17002, 1015, 155, 1040, 102, 150, 160);
			//WT-250Ⅱ 2호기
			AddXYControls(MonitoringEquipmentId.MG17003, 709, 515, 730, 505, 180, 100);
			//NL2500/1250SY
			AddXYControls(MonitoringEquipmentId.MG17004, 1227, 487, 1240, 440, 160, 160);
			//NL2500/700
			AddXYControls(MonitoringEquipmentId.MG17005, 1227, 307, 1240, 300, 110, 110);
			//MT-2000
			AddXYControls(MonitoringEquipmentId.MG17006, 743, 774, 770, 720, 120, 170);
			//WT-300
			AddXYControls(MonitoringEquipmentId.MG17007, 1015, 510, 1040, 453, 110, 170);
			//초음파자동세정기
			AddXYControls(MonitoringEquipmentId.MG21001, 1050, 824, 1080, 770, 140, 200);

			InitializeControl();
			InitializeEvent();
		}

		/// <summary>        
		/// 초기화
		/// </summary>
		private void InitializeControl()
		{
			//상태별 이미지 값 초기화
			pairs.Add("IDLE", Resources.Idle);
			pairs.Add("RUN", Resources.Run);
			pairs.Add("DOWN", Resources.Down);
			pairs.Add("IDLEDOWN", Resources.IdleDown);
			pairs.Add("RUNDOWN", Resources.RunDown);
			pairs.Add("DEFAULT", Resources.Default);

			diagramControl.OptionsView.ScrollMargin = new Padding(int.MaxValue);
			diagramControl.LookAndFeel.UseDefaultLookAndFeel = false;
			//diagramControl.LookAndFeel.SetSkinMaskColors(Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255, 255, 255, 255));
			diagramControl.LookAndFeel.SetSkinMaskColors(Color.FromArgb(0, 237, 243, 249), Color.FromArgb(0, 237, 243, 249));
			diagramControl.FitToPage();
		}

		/// <summary>
		/// ADD 이미지, 설비 panel 컨트롤
		/// </summary>
		/// <param name="equipmentId">설비ID</param>
		/// <param name="x">경광등 이미지 x좌표</param>
		/// <param name="y">경광등 이미지 y좌표</param>
		/// <param name="px">panel x좌표</param>
		/// <param name="py">panel y좌표</param>
		/// <param name="width">panel 너비</param>
		/// <param name="height">panel 높이</param>
		private void AddXYControls(MonitoringEquipmentId equipmentId, float x, float y, float px, float py, float width, float height)
		{
			//Bitmap bitmap = Resources.Run;
			//int w = bitmap.Width * 100;
			//int h = bitmap.Height * 100;
			//Size resize = new Size(w, h);
			//Bitmap newBitmap = new Bitmap(bitmap, resize);

			ExDiagramImage diagramImage = new ExDiagramImage();
			diagramImage.Equipmentid = equipmentId;
			diagramImage.Position = new DevExpress.Utils.PointFloat(x, y);
			diagramImage.Image = Resources.Default;
			diagramImage.Size = new SizeF(Resources.Run.Width, Resources.Run.Height);
			diagramImage.CanSelect = false;
			diagramImage.CanMove = false;
			diagramImage.CanResize = false;
			diagramImage.CanEdit = false;
			diagramImage.CanCopy = false;
			diagramImage.CanDelete = false;
			diagramImage.CanRotate = false;
			diagramImage.CanSnapToOtherItems = false;
			diagramImage.CanSnapToThisItem = false;
			diagramImage.CanHideSubordinates = false;
			diagramImage.CanAttachConnectorBeginPoint = false;
			diagramImage.CanAttachConnectorEndPoint = false;
			diagramImage.CanChangeParent = false;

			//Console.WriteLine(string.Format("equipmentid : {0} / x : {1} / y : {2}", equipmentId.ToString(), px, py));

			ExDiagramShape diagramItem = new ExDiagramShape();
			diagramItem.Equipmentid = equipmentId;
			diagramItem.Height = height;
			diagramItem.Width = width;
			diagramItem.Position = new DevExpress.Utils.PointFloat(px, py);
			diagramItem.Shape = DevExpress.Diagram.Core.BasicShapes.Rectangle;
			diagramItem.Appearance.BackColor = Color.Transparent;
			diagramItem.Appearance.BorderColor = Color.Transparent;
			diagramItem.CanSelect = false;
			diagramItem.CanMove = false;
			diagramItem.CanResize = false;
			diagramItem.CanEdit = false;
			diagramItem.CanCopy = false;
			diagramItem.CanDelete = false;
			diagramItem.CanChangeParameter = false;
			diagramItem.CanRotate = false;
			diagramItem.CanSnapToOtherItems = false;
			diagramItem.CanSnapToThisItem = false;
			diagramItem.CanHideSubordinates = false;
			diagramItem.CanAttachConnectorBeginPoint = false;
			diagramItem.CanAttachConnectorEndPoint = false;
			diagramItem.CanChangeParent = false;

			diagramControl.Items.Add(diagramImage);
			diagramControl.Items.Add(diagramItem);
		}
		#endregion

		#region Event

		/// <summary>
		/// 화면에서 사용되는 이벤트를 초기화한다.
		/// </summary>
		public void InitializeEvent()
		{
			this.FormClosing += EquipmentMonitoring_FormClosing;
			this.Load += EquipmentMonitoring_Load;
			diagramControl.CustomDrawBackground += SmartDiagramControl1_CustomDrawBackground;
			timer.Tick += Timer_Tick;
            diagramControl.Click += DiagramControl_Click;
            diagramControl.MouseLeave += DiagramControl_MouseLeave;
            diagramControl.MouseMove += DiagramControl_MouseMove;
        }

        private void DiagramControl_MouseMove(object sender, MouseEventArgs e)
        {
            var item = diagramControl.CalcHitItem(((MouseEventArgs)e).Location) as DiagramShape;
            if (item != null)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DiagramControl_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 설비상세팝업 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiagramControl_Click(object sender, EventArgs e)
        {
            var item = diagramControl.CalcHitItem(((MouseEventArgs)e).Location) as DiagramShape;
            if (item != null)
            {
                ExDiagramShape shape = item as ExDiagramShape;
                EquipmentStateDetailPopup popup = new EquipmentStateDetailPopup();
                popup.EquipmentId = shape.Equipmentid.ToString();
                popup.EquipmentName = shape.EquipmentName;
                popup.ShowDialog();
            }
        }

		/// <summary>
		/// On/Off 스위치
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToggleSwitch_Toggled(object sender, EventArgs e)
		{
			timer.Enabled = !timer.Enabled;
		}

		/// <summary>
		/// 화면 닫힐 때 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EquipmentMonitoring_FormClosing(object sender, FormClosingEventArgs e)
		{
			timer.Enabled = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Timer_Tick(object sender, EventArgs e)
		{
			EquipmentStateMonitoring();
		}

		/// <summary>
		/// 상태 모니터링
		/// </summary>
		private void EquipmentStateMonitoring()
		{
			DataTable dt = SqlExecuter.Query("SelectEquipmentState", "00001", new Dictionary<string, object>(){ { "LANGUAGETYPE", UserInfo.Current.LanguageType } });
			if (dt.Rows.Count == 0) return;

			DiagramItemCollection items = diagramControl.Items;
			foreach (DiagramItem item in items)
			{
				if (item is ExDiagramImage)
				{
					ExDiagramImage img = item as ExDiagramImage;

					DataRow row = dt.Select("EQUIPMENTID='" + img.Equipmentid + "'").FirstOrDefault();
					if (row == null) return;

					string colName = row["EQUIPMENTSTATE"].ToString();
					img.Image = pairs[colName];
				}

				if(item is ExDiagramShape)
				{
					ExDiagramShape shape = item as ExDiagramShape;

					DataRow row = dt.Select("EQUIPMENTID='" + shape.Equipmentid + "'").FirstOrDefault();
					if (row == null) return;

					shape.EquipmentName = row["EQUIPMENTNAME"].ToString();
				}
			}
		}

		/// <summary>
		/// 페이지 로드
		/// </summary>^
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EquipmentMonitoring_Load(object sender, EventArgs e)
		{
			timer.Enabled = true;

			SmartComboBox cbo = Conditions.GetControl<SmartComboBox>("P_INTERVAL");
			timer.Interval = Format.GetInteger(cbo.GetDataValue());

			EquipmentStateMonitoring();
		}

		private void SmartDiagramControl1_CustomDrawBackground(object sender, DevExpress.XtraDiagram.CustomDrawBackgroundEventArgs e)
		{
			diagramControl.OptionsView.PageMargin = new Padding(0);
			e.Graphics.DrawImage(Resources.EquipmentMonitoringBackground, e.TotalBounds);
		}
		#endregion

	}
}