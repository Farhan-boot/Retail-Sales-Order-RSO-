using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace APL.BL.SFTS.ProcessZone.Topup
{

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

        public BALANCE_CHECK()
        { }

        public BALANCE_CHECK BALANCE_CHECK2(string _xml)
        {
            BALANCE_CHECK cv = new BALANCE_CHECK();

            using (var xmlStream = new StringReader(_xml))
            {
                var serializer = new XmlSerializer(typeof(BALANCE_CHECK));
                return (BALANCE_CHECK)serializer.Deserialize(XmlReader.Create(xmlStream));
            }
        }


    }

    public static class TopupHelper
    {

        // Read XML data CONTINUE
        private static string GetRequestContentAsString()
        {
            using (var receiveStream = HttpContext.Current.Request.InputStream)
            {
                using (var readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    return readStream.ReadToEnd();
                }
            }
        }

        public static BALANCE_CHECK Submit_EV_Check_Balance(string xml)
        {
            BALANCE_CHECK en = null;
            try
            {
                string he = @"LOGIN=ccd&PASSWORD=f26fc9e6286e58b7f86beeac45c6ac81&REQUEST_GATEWAY_CODE=GW006&REQUEST_GATEWAY_TYPE=EXTGW&SERVICE_PORT=190&SOURCE_TYPE=EXTGW";
                string url = ConfigurationManager.AppSettings.Get("BalanceCheckRequestUrl");  // "http://10.10.80.9:7890/csms/C2SReceiver";  

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                IWebProxy iproxy = WebRequest.GetSystemWebProxy();
                iproxy.Credentials = CredentialCache.DefaultCredentials;
                request.Proxy = iproxy;
                request.PreAuthenticate = true;


                request.Method = "POST";
                //using GET - 
                request.Headers.Add("Authorization", he);
                request.ContentType = "text/xml";

                var encoder = new UTF8Encoding();
                var data = encoder.GetBytes(xml);
                request.ContentLength = data.Length;

                request.ContentLength = data.Length;
                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
                string responseText;


                using (var response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();

                        //responseText = responseText.Replace("\"", "'"); 
                        // responseText = responseText.Replace("<?xml version='1.0'?>", "");
                        //responseText = responseText.Replace("COMMAND", "");
                        BALANCE_CHECK bl = new BALANCE_CHECK();
                        en = bl.BALANCE_CHECK2(responseText);

                    }
                }


            }
            catch (WebException exception)
            {
                string responseText;
                using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                    //en.MESSAGE = exception.Message.ToString();
                }
            }


            return en;
        }

        /*
        public static clsTopupExecutionResonse Submit_EV_Transfer_Balance(string xml)
        {
            clsTopupExecutionResonse en = null;

            try
            {
                string he = @"LOGIN=ccd&PASSWORD=f26fc9e6286e58b7f86beeac45c6ac81&REQUEST_GATEWAY_CODE=GW006&REQUEST_GATEWAY_TYPE=EXTGW&SERVICE_PORT=190&SOURCE_TYPE=EXTGW";
                string url = ConfigurationManager.AppSettings.Get("BalanceTransferRequestUrl"); // "http://10.10.80.9:7890/csms/C2SReceiver";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                IWebProxy iproxy = WebRequest.GetSystemWebProxy();
                iproxy.Credentials = CredentialCache.DefaultCredentials;
                request.Proxy = iproxy;
                request.PreAuthenticate = true;


                request.Method = "POST";
                //using GET - 
                request.Headers.Add("Authorization", he);
                request.ContentType = "text/xml";

                var encoder = new UTF8Encoding();
                var data = encoder.GetBytes(xml);
                request.ContentLength = data.Length;
                request.Timeout = 10;
                request.ContentLength = data.Length;
                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
                string responseText;


                using (var response = request.GetResponse())
                {

                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();

                        //responseText = responseText.Replace("\"", "'");
                        //responseText = responseText.Replace("<?xml version='1.0'?><!DOCTYPE COMMAND PUBLIC '-//Ocam//DTD XML Command 1.0//EN' 'xml/command.dtd'>", "");
                        en = new clsTopupExecutionResonse(responseText);

                    }
                }


            }
            catch (WebException exception)
            {

                string responseText;
                // en.HttpResponseStatus = "Error";
                using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                    en.Message = exception.Message.ToString();
                }
            }


            return en;
        }

    */

        public static string GenerateXMLForTransfer(string RSO_msisdn, string retailer_msisdn, string pin, Int16 amount, string EXTREFNUM)
        {
            string xml = "";

            xml = string.Format(@"<?xml version=""1.0""?>
                            <COMMAND>
                            <TYPE>EXC2CTRFREQ</TYPE>
                            <DATE>{0}</DATE>
                            <EXTNWCODE>BD</EXTNWCODE>
                            <MSISDN1>{1}</MSISDN1>
                            <PIN>{2}</PIN>
                            <LOGINID></LOGINID>
                            <PASSWORD></PASSWORD>
                            <EXTCODE>TRSDE897</EXTCODE>
                            <EXTREFNUM>{3}</EXTREFNUM>
                            <MSISDN2>{4}</MSISDN2>
                            <EXTCODE2></EXTCODE2>
                            <LOGINID2></LOGINID2>
                            <PRODUCTS>
                            <PRODUCTCODE>101</PRODUCTCODE>
                            <QTY>{5}</QTY>
                            </PRODUCTS>
                            <LANGUAGE1>0</LANGUAGE1>
                            </COMMAND>", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), RSO_msisdn, pin, EXTREFNUM, retailer_msisdn, amount);

            return xml;
        }



        public static string GenerateXML(string type, string Rmsisdn, string Cmsisdn, string pin, decimal amount, string EXTREFNUM)
        {
            string xml = "";
            if (type != "EXRCSTATREQ") // #WebTopUp transaction enquiry
            {
                xml = string.Format(@"<?xml version=""1.0""?>
                    <COMMAND>
                    <TYPE>{0}</TYPE>
                    <DATE>{1}</DATE>
                    <EXTNWCODE>BD</EXTNWCODE>
                    <MSISDN>{2}</MSISDN>
                    <PIN>{3}</PIN>
                    <LOGINID></LOGINID>
                    <PASSWORD></PASSWORD>
                    <EXTCODE></EXTCODE>
                    <EXTREFNUM>{4}</EXTREFNUM>
                    <MSISDN2>{5}</MSISDN2>
                    <AMOUNT>{6}</AMOUNT>
                    <LANGUAGE1>0</LANGUAGE1>
                    <LANGUAGE2>1</LANGUAGE2>
                    <SELECTOR>1</SELECTOR>
                    </COMMAND>", type, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), Rmsisdn, pin, EXTREFNUM, Cmsisdn, amount);

            }

            return xml;
        }

        /*
        public static string GenerateXmlString(clsTopupExecutionResonse dataString)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(clsTopupExecutionResonse));
            //var subReq = new RESPONSE();
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
        */

        public static string GenerateXmlString2(BALANCE_CHECK dataString)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(BALANCE_CHECK));
            //var subReq = new RESPONSE();
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



}
