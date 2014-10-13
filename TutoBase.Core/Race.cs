using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TutoBase.Core
{
	//public enum Race
	//{
	//	Terran,
	//	Protoss,
	//	Zerg,
	//	Null
	//}
	[XmlType("Race")]
	public class Race
	{
		public int Id { get; set; }

		[StringLength(30), XmlText]
		public string Name { get; set; }
		[StringLength(1), XmlIgnore]
		public string Token { get; set; }

		[JsonIgnore]
		public virtual ICollection<Tuto> TutosAsPlayerRace { get; set; }
		[JsonIgnore]
		public virtual ICollection<Tuto> TutosAsAgainstRace { get; set; }
	}
}