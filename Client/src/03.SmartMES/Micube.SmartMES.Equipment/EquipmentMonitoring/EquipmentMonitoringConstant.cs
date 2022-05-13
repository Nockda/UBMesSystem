using DevExpress.XtraDiagram;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micube.SmartMES.Equipment
{
	/// <summary>
	/// 설비 ID
	/// </summary>
	public enum MonitoringEquipmentId
	{
		MG17001, //MCT/MYNX-7500
		MG17002, //WT-250Ⅱ 1호기
		MG17003, //WT-250Ⅱ 2호기
		MG17004, //NL2500/1250SY
		MG17005, //NL2500/700
		MG17006, //MT-2000
		MG17007, //WT-300
		MG21001  //초음파자동세정기
	}

	public class ExDiagramImage : DiagramImage
	{
		public ExDiagramImage()
		{ }

		public MonitoringEquipmentId Equipmentid { get; set; }
	}

	public class ExDiagramShape : DiagramShape
	{
		public ExDiagramShape()
		{ }

		public MonitoringEquipmentId Equipmentid { get; set; }
		public string EquipmentName { get; set; }
	}
}
