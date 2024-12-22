using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone.Training;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;





namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/TrainingContent")]
    public class TrainingContentController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetTrainingContents(object[] data)
        {
            IEnumerable<SP_GET_TRAININICONTENT_WEB> menuGroupList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                menuGroupList = new TrainingContentPZ().GetTrainingContents(objcmnParam.TrainingId, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                menuGroupList
            });
        }
        [HttpPost]
        public HttpResponseMessage SaveUploadAllFile() // Check to work
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            string fileName = "";
            if (hfc.Count > 0)
            {
                for (int i = 0; i < hfc.Count; i++)
                {
                    System.Web.HttpPostedFile hpf = hfc[i];

                    if (hpf != null && hpf.ContentLength > 0)
                    {
                        string exttension = System.IO.Path.GetExtension(hpf.FileName);
                        string directory = HttpContext.Current.Server.MapPath("~/UserFiles/TrainingContent");
                        string fileDir = directory + "/";

                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        if (exttension != "")
                        {
                            fileName = System.IO.Path.GetFileName(hpf.FileName);
                        }
                        else
                        {
                            //fileName = "File" + DateTime.Now.Ticks.ToString();
                        }


                        string filePath = fileDir + fileName;
                        if (!File.Exists(filePath))
                        {
                            hpf.SaveAs(filePath);
                            hpf.InputStream.Dispose();
                        }

                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, fileName);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "");
            }

        }
        [HttpPost]
        public HttpResponseMessage SaveTrainingContent(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                TrainingContent trainingContent = JsonConvert.DeserializeObject<TrainingContent>(data[1].ToString());
                if (trainingContent.TrainingId == 0)
                {
                    trainingContent.ActionFlag = 1;
                }
                else
                {
                    trainingContent.ActionFlag = 2;
                }
                decimal updateResult = new TrainingContentPZ().SaveTrainingContent(trainingContent, objcmnParam.UserId);

                result = updateResult > 0 ? updateResult.ToString() : result;
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                result = "";
            }


            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage DeleteInfo(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                TrainingContent trainingContent = JsonConvert.DeserializeObject<TrainingContent>(data[1].ToString());
   
                if (trainingContent.TrainingId > 0)
                {
                    decimal updateResult = new TrainingContentPZ().DeleteInfo(trainingContent.TrainingId);
                    result = updateResult > 0 ? updateResult.ToString() : result;
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                result = "";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }

}
