using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace TutoBase.Core
{
	//public enum League
	//{
	//	Bronze=1,
	//	Silver=2,
	//	Gold=3,
	//	Platinum=4,
	//	Diamond=5,
	//	Master=6
	//}

	public class League
	{
		public int Id { get; set; }


		[StringLength(30), XmlText]
		public string Name { get; set; }
		[StringLength(1)]
		public string Token { get; set; }

		[JsonIgnore]
		public virtual List<Tuto> Tutos { get; set; }
	}
}