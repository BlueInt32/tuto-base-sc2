using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TutoBase.Core
{
	public class Tuto
	{
		public int Id { get; set; }

		[StringLength(60)]
		public string Title { get; set; }
		public string Description { get; set; }

		public virtual List<Race> Races { get; set; }
		public string RaceShort { get; set; }

		public virtual List<Race> Againsts { get; set; }
		public string AgainstShort { get; set; }

		public virtual List<League> Leagues { get; set; }

		[StringLength(255)]
		public string VideoUrl { get; set; }
		[StringLength(15)]
        public string YoutubeId { get; set; }
		[StringLength(10)]
		public string StartTiming { get; set; }

		public virtual TutoType TutoType { get; set; }

		public virtual Caster Caster { get; set; }

		public virtual VideoProvider VideoProvider { get; set; }

		public DateTime CreationDate { get; set; }

		[XmlElement("CreationDate"), NotMapped]
		public string CreationDateString
		{
			get { return CreationDate.ToString("dd/MM/yyyy HH:mm:ss"); }
			set { CreationDate = DateTime.Parse(value); }
		}

		public string PathToPdf
		{
			get
			{
				return "";
				throw new NotImplementedException();
				//string magicPath = string.Format("~/pdfFiles/{0}.pdf", Id);
				//if (File.Exists(HttpContext.Current.Server.MapPath(magicPath)))
				//{
				//	return magicPath.ContentAbsolute();
				//}
				//else
				//	return null;
			}
		}


		[XmlIgnore]
		public string VideoThumbUrl
		{
			get
			{
				return "";
				switch (VideoProvider.Name)
				{
					case "Youtube":
					return string.Format("http://img.youtube.com/vi/{0}/1.jpg", YoutubeId);
						break;
					case "Dailymotion":
						return VideoUrl.Replace("/video", "/thumbnail/video");
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}


	}
}