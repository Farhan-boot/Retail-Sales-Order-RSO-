using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace APL.BL.SFTS.Models.ApiMobile
{
	[XmlRoot(ElementName = "COMMAND")]
	public class BALANCE_CHECK
	{
		[XmlElement(ElementName = "DATE")]
		public string DATE { get; set; }

		[XmlElement(ElementName = "EXTREFNUM")]
		public string EXTREFNUM { get; set; }

		[XmlElement(ElementName = "RECORD")]
		public RECORD RECORD { get; set; }

		[XmlElement(ElementName = "TXNSTATUS")]
		public string TXNSTATUS { get; set; }

		[XmlElement(ElementName = "TYPE")]
		public string TYPE { get; set; }

		[XmlElement(ElementName = "MESSAGE")]
		public string MESSAGE { get; set; }

		public BALANCE_CHECK()
		{ }

		public BALANCE_CHECK RESPONSE(string _xml)
		{
			BALANCE_CHECK cv = new BALANCE_CHECK();

			using (var xmlStream = new StringReader(_xml))
			{
				var serializer = new XmlSerializer(typeof(BALANCE_CHECK));
				return (BALANCE_CHECK)serializer.Deserialize(XmlReader.Create(xmlStream));
			}
		}

		public string WRITE_XML(BALANCE_CHECK dataString)
		{
			XmlSerializer xsSubmit = new XmlSerializer(typeof(BALANCE_CHECK));
			var xmlString = "";
			using (var sww = new StringWriter())
			{
				using (XmlWriter writer = XmlWriter.Create(sww))
				{
					xsSubmit.Serialize(writer, dataString);
					xmlString = sww.ToString(); // Your XML
				}
			}
			return xmlString;
		}

	}

	[XmlRoot(ElementName = "RECORD")]
	public class RECORD
	{
		[XmlElement(ElementName = "BALANCE")]
		public string BALANCE { get; set; }

		[XmlElement(ElementName = "PRODUCTCODE")]
		public string PRODUCTCODE { get; set; }

		[XmlElement(ElementName = "PRODUCTSHORTNAME")]
		public string PRODUCTSHORTNAME { get; set; }
	}









}