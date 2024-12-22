using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace APITEST.Models
{
	[XmlRoot(ElementName = "COMMAND")]
	public class ItopupTransfer
	{
		[XmlElement("TYPE")]
		public string TYPE { get; set; }
		[XmlElement("DATE")]
		public string DATE { get; set; }
		[XmlElement("EXTNWCODE")]
		public string EXTNWCODE { get; set; }
		[XmlElement("MSISDN1")]
		public string MSISDN1 { get; set; }
		[XmlElement("PIN")]
		public string PIN { get; set; }
		[XmlElement("LOGINID")]
		public string LOGINID { get; set; }
		[XmlElement("PASSWORD")]
		public string PASSWORD { get; set; }
		[XmlElement("EXTCODE")]
		public string EXTCODE { get; set; }
		[XmlElement("EXTREFNUM")]
		public string EXTREFNUM { get; set; }
		[XmlElement("MSISDN2")]
		public string MSISDN2 { get; set; }
		[XmlElement("EXTCODE2")]
		public string EXTCODE2 { get; set; }
		[XmlElement("LOGINID2")]
		public string LOGINID2 { get; set; }
		[XmlElement(ElementName = "PRODUCTS")]
		public PRODUCT PRODUCTS { get; set; }
		[XmlElement("LANGUAGE1")]
		public string LANGUAGE1 { get; set; }

		[XmlElement(ElementName = "TXNSTATUS")]
		public string TXNSTATUS { get; set; }
		[XmlElement(ElementName = "TXNID")]
		public string TXNID { get; set; }
		[XmlElement(ElementName = "MESSAGE")]
		public string MESSAGE { get; set; }

		public ItopupTransfer()
		{ }

		public ItopupTransfer RESPONSE(string _xml)
		{
			ItopupTransfer cv = new ItopupTransfer();

			using (var xmlStream = new StringReader(_xml))
			{
				var serializer = new XmlSerializer(typeof(ItopupTransfer));
				return (ItopupTransfer)serializer.Deserialize(XmlReader.Create(xmlStream));
			}
		}


		public string WRITE_XML(ItopupTransfer dataString)
		{
			XmlSerializer xsSubmit = new XmlSerializer(typeof(ItopupTransfer));
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

	[XmlRoot(ElementName = "PRODUCT")]
	public class PRODUCT
	{
		[XmlElement(ElementName = "PRODUCTCODE")]
		public string PRODUCTCODE { get; set; }

		[XmlElement(ElementName = "QTY")]
		public string QTY { get; set; }

	}
}