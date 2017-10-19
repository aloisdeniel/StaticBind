﻿using System.Xml.Serialization;
using System.Linq;

namespace StaticBind.Build
{
	[XmlRoot("Bind")]
	public class Bind
	{
		[XmlAttribute("From")]
		public string From { get; set; }

		[XmlAttribute("To")]
		public string To { get; set; }

		[XmlAttribute("Converter")]
		public string Converter { get; set; }

		[XmlAttribute("When")]
		public string When { get; set; }

		[XmlIgnore]
		public bool HasEvent => !string.IsNullOrEmpty(this.When);

		[XmlIgnore]
		public string WhenEventHandler
		{
			get
			{
				if (!HasEvent)
					return null;
				
				var splits = this.When?.Split(':');

				if (splits.Length == 1)
					return "EventHandler";

				return splits.First();
			}
		}

		[XmlIgnore]
		public string WhenEventName
		{
			get
			{
				if (!HasEvent)
					return null;

				var splits = this.When?.Split(':');

				if (splits.Length == 1)
					return splits.First();

				return splits.ElementAt(1);
			}
		}
	}
}
