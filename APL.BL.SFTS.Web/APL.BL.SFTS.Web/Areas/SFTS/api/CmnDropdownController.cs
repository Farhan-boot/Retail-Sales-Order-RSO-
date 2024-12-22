using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.ProcessZone.Target;
using APL.BL.SFTS.Web.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/CmnDropdown")]
    public class CmnDropdownController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetDistributors(object[] data)
        {
            IEnumerable<SP_GET_DISTRIBUTOR_BY_REG_IDcls> objListDistributor = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                objListDistributor = new DistributorPZ().GetDistributor(objcmnParam.RegionId, 0, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListDistributor
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRoutes(object[] data)
        {
            IEnumerable<SP_GET_ROUTEcls> objListRoute = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                objListRoute = new RoutePZ().GetAllRoute(objcmnParam.DistributorID, objcmnParam.RouteID);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListRoute
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetSurvey(object[] data)
        {
            IEnumerable<SP_GET_SURVEYLISTcls> objListSurvey = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                objListSurvey = new SurveyPZ().GetAllSurveyList(0, 0, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListSurvey
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetSurveyQuestion(object[] data)
        {
            IEnumerable<SP_GET_SURVEYQUESTION_LISTcls> objListQuestion = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListQuestion = new SurveyPZ().GetAllSurveyQuestionList(objcmnParam.SurveyId, 0, "");
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListQuestion
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetTargetItem(object[] data)
        {
            IEnumerable<SP_GET_TARGET_ITEM> objListTargetItem = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListTargetItem = new TargetSetupPZ().GetAllTargetItem(objcmnParam.TargetItemId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListTargetItem
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetTargetPeriod(object[] data)
        {
            IEnumerable<SP_GET_TARGET_PERIOD> objListTargetPeriod = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListTargetPeriod = new TargetSetupPZ().GetAllTargetPeriod(objcmnParam.TargetPeriodId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListTargetPeriod
            });
        }


        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetMonths(object[] data)
        {
            IEnumerable<SP_GET_MONTH> objListMonth = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListMonth = new TargetSetupPZ().GetMonths(objcmnParam.MonthId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListMonth
            });
        }


        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetVisitTypes(object[] data)
        {
            IEnumerable<SP_GET_VISIT_TYPE> objListVisitType = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objcmnParam.VisitTypeId = 0;
                objListVisitType = new TargetSetupPZ().GetAllVisitType(objcmnParam.VisitTypeId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListVisitType
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetCenterTypes(object[] data)
        {
            IEnumerable<SP_GET_CENTER_TYPE> objListCenterType = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objcmnParam.CenterTypeId = 0;
                objListCenterType = new TargetSetupPZ().GetCenterTypes(objcmnParam.CenterTypeId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListCenterType
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRoles(object[] data)
        {
            IEnumerable<SP_GET_ROLES> objListRole = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objcmnParam.RoleId = 0;
                objListRole = new TargetSetupPZ().GetRoles(objcmnParam.RoleId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListRole
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetChannelType(object[] data)
        {
            IEnumerable<SP_GET_CHANNEL_TYPE> objListChennelType = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objcmnParam.ChannelTypeId = 0;
                objListChennelType = new TargetSetupPZ().GetChannelType(objcmnParam.ChannelTypeId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListChennelType
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetTargetItemEntityTypes(object[] data)
        {
            IEnumerable<SP_GET_ENTITY_TYPE> objTargetEntityType = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objcmnParam.EntityTypeId = 0;
                objTargetEntityType = new TargetItemPZ().GetEntityTypes(objcmnParam.EntityTypeId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objTargetEntityType
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRegions(object[] data)
        {
            IEnumerable<GET_REGION> objListRegion = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListRegion = new RetailerPZ().GetRegions(0, objcmnParam.loggeduser, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListRegion
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRetailers(object[] data)
        {
            IEnumerable<SP_GET_RETAILERcls> objListRetailer = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListRetailer = new RetailerPZ().GetRetailers(objcmnParam.DistributorID, objcmnParam.RouteID, objcmnParam.RetailerId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListRetailer
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRSO(object[] data)
        {
            IEnumerable<SP_GET_RSOcls> objListRso = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListRso = new RsoPZ().GetAllRso(objcmnParam.DistributorID, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListRso
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRSOFromZone(object[] data)
        {
            IEnumerable<SP_GET_RSOcls> objListRso = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListRso = new RsoPZ().GetRsoFromZone(objcmnParam.DistributorID, 0, objcmnParam.ZoneId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListRso
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetThanas(object[] data)
        {
            IEnumerable<SP_GET_CHANNEL_TYPE> objListChennelType = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objcmnParam.ChannelTypeId = 0;
                objListChennelType = new TargetSetupPZ().GetChannelType(objcmnParam.ChannelTypeId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListChennelType
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetCalculationAreas(object[] data)
        {
            IEnumerable<SP_GET_CALCULATION_AREA> objListCalculationArea = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListCalculationArea = new RetailerPZ().GetCalculationArea(0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListCalculationArea
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetZones(object[] data)
        {
            IEnumerable<GET_ZONE> objListZone = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListZone = new RetailerPZ().GetZones(objcmnParam.ZoneId, objcmnParam.RegionId, objcmnParam.loggeduser, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListZone
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRoutesByZone(object[] data)
        {
            IEnumerable<GET_DROPDOWN> objListRoute = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListRoute = new RetailerPZ().GetRoutesByZone(objcmnParam.ZoneId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListRoute
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetAmbm(object[] data)
        {
            IEnumerable<GET_DROPDOWN> objListAmbm = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListAmbm = new VisitPlanPZ().GetAmbm(objcmnParam.Id, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListAmbm
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetAllDistributors(object[] data)
        {
            IEnumerable<SP_GET_ALL_DISTRIBUTOR> objListDistributor = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                objListDistributor = new DistributorPZ().GetDistributorForMultiselect(0, objcmnParam.RegionId);


            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListDistributor
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetComplainTypes(object[] data)
        {
            IEnumerable<SP_GET_COMPLAIN_TYPE> listComplainType = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                listComplainType = new CurrentOfferPZ().GetComplainTypes(0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                listComplainType
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetComplainStatus(object[] data)
        {
            IEnumerable<GET_DROPDOWN> listComplainStatus = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                listComplainStatus = new VisitPlanPZ().GetComplainStatus(objcmnParam.ComplainTypeId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                listComplainStatus
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetUsers(object[] data)
        {
            IEnumerable<GET_DROPDOWN> objListUser = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListUser = new VisitPlanPZ().GetUsers();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListUser
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetAllZones(object[] data)
        {
            IEnumerable<GET_ALL_ZONE> objListZone = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListZone = new RetailerPZ().GetAllZones(objcmnParam.ZoneId, objcmnParam.RegionId, objcmnParam.loggeduser, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListZone
            });
        }


		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetNotificationTypes(object[] data)
		{
			IEnumerable<SP_FF_GET_NOTIFICATION_TYPE> objListCenterType = null;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				objcmnParam.CenterTypeId = 0;
				objListCenterType = new TargetSetupPZ().GetNotificationTypes(objcmnParam.CenterTypeId);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				objListCenterType
			});
		}


		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetTargetPeriodEarning(object[] data)
		{
			IEnumerable<SP_GET_TARGET_PERIOD> objListTargetPeriod = null;
			try
			{
				RSOEarningParameters objcmnParam = JsonConvert.DeserializeObject<RSOEarningParameters>(data[0].ToString());
				objListTargetPeriod = new TargetSetupPZ().GetTargetPeriodEarning(objcmnParam.periodtypeID);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				objListTargetPeriod
			});
		}


	}
}
