using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public enum ProductCategoryEnum
    {
        iTOPUP = 1,
        SIM = 2,
        Device = 3
    }


    public enum MonthListEnam
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }


    public class RetailerPZ
    {

        public RetailerPZ()
        {

        }

        public const string _collectionNodePart = "Coll";


        public List<SP_GET_RETAILER_CREATE_REQUEST> GetRetailerCreateRequest(decimal RsoId, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                return new RetailerDZ().GetRetailerCreateRequest(RsoId, DateFrom, DateTo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_CURRENT_INFO> GetRetailerCurrentInfo(decimal RetailerId)
        {
            try
            {
                return new RetailerDZ().GetRetailerCurrentInfo(RetailerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_NEW_RETAILER_FOR_APPROVE> GetNewRetailerForApprove(decimal Id, decimal StatusId, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                return new RetailerDZ().GetNewRetailerForApprove(Id, StatusId, DateFrom, DateTo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_NEW_RETAILER_INFO> GetNewRetailerInfo(decimal Id, decimal StatusId, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                return new RetailerDZ().GetNewRetailerInfo(Id, StatusId, DateFrom, DateTo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_RETAILER_LOC_BY_ROUTE> GetRetailerLocationByRoute(decimal RouteId)
        {
            try
            {
                return new RetailerDZ().GetRetailerLocationByRoute(RouteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_GPS_FOR_APPROVE> GetRetailerGPSUpdateForApprove(decimal Id)
        {
            try
            {
                return new RetailerDZ().GetRetailerGPSUpdateForApprove(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_GPS> GetRetailerGPS(decimal Id, decimal ZoneId, decimal RouteId, decimal RetailerId)
        {
            try
            {
                return new RetailerDZ().GetRetailerGPS(Id, ZoneId, RouteId, RetailerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public List<SP_GET_RETAILER_GPS> GetRSORetailerGPS(decimal Id, decimal ZoneId, decimal RouteId, decimal RetailerId, DateTime VisitDate)
		{
			try
			{
				return new RetailerDZ().GetRSORetailerGPS(Id, ZoneId, RouteId, RetailerId, VisitDate);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<SP_GET_FOOTSTEP_EXPORT1> GetFootsepExport(decimal Id, decimal ZoneId, decimal RouteId, decimal RetailerId, DateTime VisitDate)
        {
            try
            {
                return new RetailerDZ().GetFootsepExport(Id, ZoneId, RouteId, RetailerId,VisitDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_FOOTSTEP_EXPORT2> GetFootsepExport_BTS(decimal Id, decimal ZoneId, decimal RouteId, decimal RetailerId, DateTime VisitDate)
        {
            try
            {
                return new RetailerDZ().GetFootsepExport_BTS(Id, ZoneId, RouteId, RetailerId, VisitDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_BTS_GPS> GetBTSLocation(decimal Id, decimal ZoneId, decimal RouteId)
        {
            try
            {
                return new RetailerDZ().GetBTSLocation(Id, ZoneId, RouteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_RETAILER_INFO_UPDATE_FOR_APPROVE> GetRetailerUpdatedInfoForApprove(decimal Id, decimal StatusId, DateTime? FromDate, DateTime? ToDate)
        {
            try
            {
                return new RetailerDZ().GetRetailerUpdatedInfoForApprove(Id, StatusId, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_TRADE_MATERIAL_ISSUE> GetFOCIssuedMaterial(decimal RetailerId, decimal UserId)
        {
            try
            {
                return new RetailerDZ().GetFOCIssuedMaterial(RetailerId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_SALES_STOCK> GetSalesAndStock(decimal RetailerId, decimal UserId)
        {
            try
            {
                return new RetailerDZ().GetSalesAndStock(RetailerId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public decimal SaveUpdateRetailerCreateReq(RetailerCreateRequest retailerCreateReq)
        {
            try
            {
                return new RetailerDZ().SaveUpdateRetailerCreateReq(retailerCreateReq);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateRetailerModifyReq(RetailerModifyRequest retailerModifyReq)
        {
            try
            {
                return new RetailerDZ().SaveUpdateRetailerModifyReq(retailerModifyReq);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public decimal SaveRetailerModifyReqApprove(decimal RetailerModifyId, decimal ActionType, string ApproverComment)
        {
            try
            {
                return new RetailerDZ().SaveRetailerCreateApprove(RetailerModifyId, ActionType, ApproverComment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SubmitComplainStatus(decimal ComplainId, int? StatusId, string ResolutionDetail, decimal UserId)
        {
            try
            {
                return new RetailerDZ().SubmitComplainStatus(ComplainId, StatusId, ResolutionDetail, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveRetailerGPSUpdateReqApprove(decimal RetailerModifyId, decimal ActionType, string ApproverComment)
        {
            try
            {
                return new RetailerDZ().SaveRetailerGPSUpdateApprove(RetailerModifyId, ActionType, ApproverComment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveRetailerInfoModifyReqApprove(decimal RetailerModifyId, decimal ActionType, string ApproverComment)
        {
            try
            {
                return new RetailerDZ().SaveRetailerModifyApprove(RetailerModifyId, ActionType, ApproverComment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_STOCK> GetRetailerStock(SearchParam searchParam)
        {
            List<SP_GET_RETAILER_STOCK> retailerStock = new List<SP_GET_RETAILER_STOCK>();
            try
            {
                retailerStock = new RetailerDZ().GetRetailerStock(searchParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retailerStock;
        }

        public List<SP_GET_RETAILER_SALES> GetRetailerSales(SearchParam searchParam)
        {
            List<SP_GET_RETAILER_SALES> retailerSales = new List<SP_GET_RETAILER_SALES>();
            try
            {
                retailerSales = new RetailerDZ().GetRetailerSales(searchParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retailerSales;
        }

        public List<SP_GET_RETAILER_COMMISSION> GetRetailerCommission(SearchParam searchParam, DateTime? FromDate, DateTime? ToDate)
        {
            List<SP_GET_RETAILER_COMMISSION> retailerCommission = new List<SP_GET_RETAILER_COMMISSION>();
            try
            {
                retailerCommission = new RetailerDZ().GetRetailerCommission(searchParam, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retailerCommission;
        }

        public List<SP_GET_RETAILER_SAF> GetRetailerSaf(SearchParam searchParam, DateTime? FromDate, DateTime? ToDate)
        {
            List<SP_GET_RETAILER_SAF> retailerSaf = new List<SP_GET_RETAILER_SAF>();
            try
            {
                retailerSaf = new RetailerDZ().GetRetailerSaf(searchParam, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retailerSaf;
        }

        public List<SP_GET_RETAILER_SAF> GetIssuedFOCProducts(SearchParam searchParam, DateTime? FromDate, DateTime? ToDate)
        {
            List<SP_GET_RETAILER_SAF> retailerSaf = new List<SP_GET_RETAILER_SAF>();
            try
            {
                retailerSaf = new RetailerDZ().GetIssuedFOCProducts(searchParam, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retailerSaf;
        }


        public List<SP_GET_RETAILER_LOCATION_UPDATE> GetRetailerLocationUpdate(SearchParam searchParam)
        {
            List<SP_GET_RETAILER_LOCATION_UPDATE> retailerStock = new List<SP_GET_RETAILER_LOCATION_UPDATE>();
            try
            {
                retailerStock = new RetailerDZ().GetRetailerLocationUpdate(searchParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retailerStock;
        }

        public decimal SaveUpdateFOCProductIssue(TradeMaterialIssue tmIssue)
        {
            try
            {
                return new RetailerDZ().SaveUpdateFOCProductIssue(tmIssue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_SAF_COLL> GetCollectedSaf(APL.BL.SFTS.Models.ApiMobile.Retailer retailer)
        {
            try
            {
                return new RetailerDZ().GetCollectedSaf(retailer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_COMMISSION_HISTORY> GetCommissionHistory(decimal DistributorId, decimal RetailerId)
        {
            try
            {
                return new RetailerDZ().CommissionHistory(DistributorId, RetailerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetExistingMemo(APL.BL.SFTS.Models.ApiMobile.Retailer retailer, Decimal RsoId)
        {
            try
            {
                return new RetailerDZ().GetExistingMemo(retailer, RsoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetExistingMemoId(decimal memoNo)
        {
            try
            {
                return new RetailerDZ().GetExistingMemoId(memoNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_SAVE_RESULT_WITH_ERROR_CODE> SaveUpdateMarketUpdate(MarketUpdate marketUpdate)
        {
            try
            {
                return new RetailerDZ().SaveUpdateMarketUpdate(marketUpdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateRetailerCheckout(RetailerCheckout retailerCheckout)
        {
            try
            {
                return new RetailerDZ().SaveUpdateRetailerCheckout(retailerCheckout);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public decimal SaveUpdateRetailerChecin(RetailerCheckin RetailerCheckin)
		{
			try
			{
				return new RetailerDZ().SaveUpdateRetailerCheckin(RetailerCheckin);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public decimal SaveUpdateComplain(Complain complain)
        {
            try
            {
                return new RetailerDZ().SaveUpdateComplain(complain);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateProductDelivery(ProductDelivery productDelivery)
        {
            try
            {
                return new RetailerDZ().SaveUpdateProductDelivery(productDelivery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public decimal SavePasswordRecoveryRequest(PasswordRecoveryReqest recoveryRequest)
        {
            try
            {
                return new RetailerDZ().SavePasswordRecoveryRequest(recoveryRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateMarketUpdatePicture(MarketUpdatePicture marketUpdatePic)
        {
            try
            {
                return new RetailerDZ().SaveUpdateMarketUpdatePicture(marketUpdatePic);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateComplainPicture(ComplainPicture complainPic)
        {
            try
            {
                return new RetailerDZ().SaveUpdateComplainPicture(complainPic);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateSafCollection(SafCollectionLog safCollection)
        {
            try
            {
                return new RetailerDZ().SaveUpdateSafCollection(safCollection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // <summary>
        /// Get all Retailer with route by list of search parameter.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="routeID"></param>
        /// <param name="retailerID"></param>
        /// <returns>List of Retailer object</returns>
        public List<SP_GET_RETAILERcls> GetAllRetailer(Decimal distributorID, Decimal retailerID)
        {
            try
            {
                return new RetailerDZ().GetAllRetailer(distributorID, 0, retailerID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public decimal SaveUpdateRetailerBestPractice(decimal BestPracticesRetailerId, decimal RetailerId,
                                         decimal RetailerMarketAreaId, decimal PeriodId, decimal Year, decimal CalculationAreaId,
                                         String Description, decimal CreatedBy)
        {
            try
            {
                return new RetailerDZ().SaveUpdateBestRetailerPractice(BestPracticesRetailerId, RetailerId, RetailerMarketAreaId, PeriodId, Year, CalculationAreaId, Description, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_BEST_RETAILER_PRACTICE> GetAllBestRetailerPractice(decimal BestPracticesRetailerId, decimal RetailerId)
        {
            try
            {
                return new RetailerDZ().GetAllBestRetailerPractice(BestPracticesRetailerId, RetailerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_CALCULATION_AREA> GetCalculationArea(Decimal CalculationAreaId)
        {
            List<SP_GET_CALCULATION_AREA> areaList = new List<SP_GET_CALCULATION_AREA>();
            try
            {
                areaList = new List<SP_GET_CALCULATION_AREA>()
                {
                    new SP_GET_CALCULATION_AREA() {AREA_ID = 1, AREA_NAME = "NATIONAL" },
                    new SP_GET_CALCULATION_AREA() {AREA_ID = 2, AREA_NAME = "REGIONAL" },
                    new SP_GET_CALCULATION_AREA() {AREA_ID = 3, AREA_NAME = "DISTRIBUTOR" },
                };

                return areaList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all Retailer with route by list of search parameter.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="routeID"></param>
        /// <param name="retailerID"></param>
        /// <returns>List of Retailer object</returns>
        public List<SP_GET_RETAILERcls> GetAllRetailer(Decimal distributorID, Decimal routeID, Decimal retailerID)
        {
            try
            {
                return new RetailerDZ().GetAllRetailer(distributorID, routeID, retailerID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all Retailer with route by list of search parameter. Retailer code is searching by contains operation.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="routeID"></param>
        /// <param name="retailerID"></param>
        /// <returns>List of Retailer object</returns>
        public List<SP_GET_RETAILERcls> GetAllRetailerSer(Decimal distributorID, Decimal routeID, string retailerCode)
        {
            try
            {
                return new RetailerDZ().GetAllRetailerSer(distributorID, routeID, retailerCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Retailer by RSO Id and Retailer code . If Retailer and RSO within same Distributor.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="retailerCode"></param>
        /// <returns>Retailer Object</returns>
        public List<SP_GET_RETAIL_RSO_WISECls> GetRetailerByRSOIDAndRetailerCode(Int64 rsoID, string retailerCode)
        {
            try
            {
                return new RetailerDZ().GetRetailerByRSOIDAndRetailerCode(rsoID, retailerCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///RSO particular visit date wise all retailer info with GPS values.
        /// </summary>
        /// <param name="rsoID">Must valid RSO ID</param>
        /// <param name="visitDate">Must valid RSO visit date</param>
        /// <param name="retailerCode">Optional, default is empty string</param>
        /// <returns>List of Object</returns>
        public List<SP_GET_RET_GPS_RSO_DATE_WISEcls> GetRetailerGPSByRsoAndAssingDateRetCode(Decimal rsoID, string assignDate, string retailerCode)
        {
            try
            {
                return new RetailerDZ().GetRetailerGPSByRsoAndVisitDateRetCode(rsoID, assignDate, retailerCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all retailer from OUTLETSCHEDULE of Retailer by particular route and visit date wise value.
        /// </summary>
        /// <param name="routeID">Must valid Route ID </param>
        /// <param name="visitDate">Must valid Visit Date</param>
        /// <param name="distributorID">Must valid Distributor ID</param>
        /// <returns></returns>
        public List<SP_GET_ROT_WISE_RET_SCHDLcls> GetRetailerByRSOIDAndRetailerCode(decimal routeID, DateTime visitDate, decimal distributorID)
        {
            try
            {
                return new RetailerDZ().GetRouteWiseRetailerSchedule(routeID, visitDate, distributorID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Retailer by RSO Id and Retailer code . If Retailer and RSO within same Distributor.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="retailerCode"></param>
        ///<returns>Retailer object for Web Service compatible XML soap data format.</returns>
        public ServiceStringXML GetRetailerByRSOIDAndRetailerCodeXML(Decimal rsoID, string retailerCode)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_GET_RETAIL_RSO_WISECls().GetType().Name;
            try
            {
                List<SP_GET_RETAIL_RSO_WISECls> retailerColl = new RetailerDZ().GetRetailerByRSOIDAndRetailerCode(rsoID, retailerCode);
                if (retailerColl != null && retailerColl.Count == 1)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_RETAIL_RSO_WISECls>(retailerColl[0]);
                }
                else if (retailerColl == null)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.InvalideRetailCode);
                }
                else if (retailerColl.Count > 1)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DuplicateRetailCode);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }


        /// <summary>
        /// Get Retailer by RSO Id and Retailer code . If Retailer and RSO within same Distributor. Save or update  RSO attendance history visiting each Retail.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="retailerCode"></param>
        /// <param name="latitudeValue"></param>
        /// <param name="longitudeValue"></param>
        /// <param name="handsetNo"></param>
        /// <returns>Retailer object for Web Service compatible XML soap data format.</returns>
        public ServiceStringXML GetRetailerByRSOIDAndRetailerCodeXML(Decimal rsoID, string retailerCode, Decimal latitudeValue, Decimal longitudeValue, String handsetNo)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_GET_RETAIL_RSO_WISECls().GetType().Name;
            try
            {
                RetailerDZ retailerDZ = new RetailerDZ();
                RSOAttendanceDZ rsoAttDZ = new RSOAttendanceDZ();
                List<SP_GET_RETAIL_RSO_WISECls> retailerColl = retailerDZ.GetRetailerByRSOIDAndRetailerCode(rsoID, retailerCode);
                if (retailerColl != null && retailerColl.Count >= 1)
                {
                    List<RSO_GPS_ATTENDANCEcls> rsoColl = rsoAttDZ.GetAllRsoGPSAttendanceDaily(0, retailerColl[0].DISTRIBUTOR_ID, rsoID, DateTime.Now, 0);
                    RSO_GPS_ATTENDANCEcls rsoGpsAtt = new RSO_GPS_ATTENDANCEcls();
                    rsoGpsAtt.RSO_ID = rsoID;
                    rsoGpsAtt.MOBILE_NO = handsetNo;
                    rsoGpsAtt.RETAILER_ID = retailerColl[0].RETAILER_ID;
                    rsoGpsAtt.DISTRIBUTOR_ID = retailerColl[0].DISTRIBUTOR_ID;
                    rsoGpsAtt.LATITUDE_VALUE = latitudeValue;
                    rsoGpsAtt.LONGITUDE_VALUE = longitudeValue;
                    rsoGpsAtt.HANDSET_NO = handsetNo;
                    rsoGpsAtt.ATTEND_DATE_TIME = DateTime.Now;
                    rsoGpsAtt.ROUTE_ID = retailerColl[0].RETAILER_ROUTE_ID;

                    if (rsoColl != null && rsoColl.Count > 0)
                    {
                        rsoGpsAtt.RSO_GPS_ATTENDANCE_ID = rsoColl[0].RSO_GPS_ATTENDANCE_ID;
                    }
                    else
                    {
                        rsoGpsAtt.RSO_GPS_ATTENDANCE_ID = 0;
                    }
                    //rsoAttDZ.SaveUpdateRSO_GPSAttendance(rsoGpsAtt.RSO_GPS_ATTENDANCE_ID, rsoGpsAtt.HANDSET_NO, rsoGpsAtt.DISTRIBUTOR_ID, rsoGpsAtt.MOBILE_NO, DateTime.Now, rsoGpsAtt.RSO_ID, rsoGpsAtt.ROUTE_ID, rsoGpsAtt.ATTEND_DATE_TIME,
                    //    rsoGpsAtt.LATITUDE_VALUE, rsoGpsAtt.LONGITUDE_VALUE, rsoGpsAtt.RETAILER_ID);

                    retailerColl[0].RETAIL_NAME = retailerColl[0].RETAIL_NAME.Replace("&", "and");
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_RETAIL_RSO_WISECls>(retailerColl[0]);
                }
                else if (retailerColl == null || retailerColl.Count == 0)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.InvalideRetailCode);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        /// <summary>
        /// Get all retailer from OUTLETSCHEDULE of Retailer by particular route and visit date wise value.
        /// </summary>
        /// <param name="routeID">Must valid Route ID </param>
        /// <param name="visitDate">Must valid Visit Date</param>
        /// <param name="distributorID">Must valid Distributor ID</param>
        /// <returns>Retailers object for Web Service compatible XML soap data format.</returns>
        public ServiceStringXML GetRouteWiseRetailerScheduleXML(decimal routeID, DateTime visitDate, decimal distributorID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_GET_ROT_WISE_RET_SCHDLcls().GetType().Name + _collectionNodePart;
            try
            {
                List<SP_GET_ROT_WISE_RET_SCHDLcls> retailerColl = new RetailerDZ().GetRouteWiseRetailerSchedule(routeID, visitDate, distributorID);
                if (retailerColl != null && retailerColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_ROT_WISE_RET_SCHDLcls>(retailerColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        /// <summary>
        /// For update retail GPS information from web panel. Which is called retailer GPS approve operation.
        /// </summary>
        /// <param name="inRretailerGPSID"></param>
        /// <param name="retailerID"></param>
        /// <param name="isPending"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public decimal SaveRetailerGPSInfo(decimal inRretailerGPSID, decimal retailerID, decimal isPending, decimal isActive)
        {
            Decimal retailerGPSInfoID = 0;
            string objectItemName = new SP_INS_RETAILER_GPSINFOcls().GetType().Name;
            try
            {
                List<SP_GET_RETAILER_GPS_LOCcls> retailerColl = new RetailerDZ().GetAllRetailerGPSLocation(0, 0, retailerID);
                foreach (SP_GET_RETAILER_GPS_LOCcls item in retailerColl)
                {
                    new RetailerDZ().SaveRetailerGPSInfo(item.RETAILER_GPSINFO_ID, 0, 0, 0, 0, 0, DateTime.Now, 0, (int)EnumCollection.PendingApproveEnum.Approve, (int)EnumCollection.ActiveInactiveEnum.Inactive);
                }

                retailerGPSInfoID = new RetailerDZ().SaveRetailerGPSInfo(inRretailerGPSID, 0, 0, 0, 0, 0, DateTime.Now, 0, isPending, isActive);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return retailerGPSInfoID;
        }

        /// <summary>
        /// For save retail GPS information. Which is called retailer GPS registration or update location.
        /// </summary>
        /// <param name="inRretailerGPSID"></param>
        /// <param name="distribitorID"></param>
        /// <param name="routeID"></param>
        /// <param name="retailerID"></param>
        /// <param name="latitudeValue"></param>
        /// <param name="longitudeValue"></param>
        /// <param name="createDate"></param>
        /// <param name="createBy"></param>
        /// <param name="isPending"></param>
        /// <param name="isActive"></param>
        /// <returns>Retailer GPS object for Web Service compatible XML soap data format.</returns>
        public ServiceStringXML SaveRetailerGPSInfoXML(decimal inRretailerGPSID, decimal distribitorID, decimal routeID, decimal retailerID, decimal latitudeValue, decimal longitudeValue, DateTime createDate, decimal createBy, decimal isPending, decimal isActive)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_INS_RETAILER_GPSINFOcls().GetType().Name;

            try
            {
                bool checkPendingRequest = false;
                List<SP_GET_RETAILER_GPS_LOCcls> retailerColl = new RetailerDZ().GetAllRetailerGPSLocation(distribitorID, routeID, retailerID);
                if (retailerColl == null || retailerColl.Count == 0)
                {
                    checkPendingRequest = false;
                }
                else
                {
                    foreach (SP_GET_RETAILER_GPS_LOCcls item in retailerColl)
                    {
                        if (item.Is_Pending == 0)
                        {
                            checkPendingRequest = true;
                            break;
                        }
                    }
                }
                if (checkPendingRequest)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.RequestGPSPending);
                }
                else
                {
                    if (latitudeValue <= 0 || longitudeValue <= 0)
                    {
                        objectXML = MessageReplyXML.Confirmation(objectItemName, true, "GPS location is not found.");
                    }
                    else
                    {
                        Decimal retailerGPSInfoID = new RetailerDZ().SaveRetailerGPSInfo(inRretailerGPSID, distribitorID, routeID, retailerID, latitudeValue, longitudeValue, createDate, createBy, isPending, isActive);
                        if (retailerGPSInfoID != 0)
                        {
                            objectXML = MessageReplyXML.Confirmation(objectItemName, true, MessageGodown.SaveNotification);
                        }
                        else
                        {
                            objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.FailSaveNotification);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        /// <summary>
        /// For save and update SC Issue New Retaiter table.
        /// </summary>
        /// <param name="scIssNewRetID"></param>
        /// <param name="distribitorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="routeID"></param>
        /// <param name="retailerMobile"></param>
        /// <param name="retailerName"></param>
        /// <param name="scSerialStart"></param>
        /// <param name="scSerialEnd"></param>
        /// <param name="sms"></param>
        /// <param name="latitudeValue"></param>
        /// <param name="longitudeValue"></param>
        /// <param name="status"></param>
        /// <returns>Sc Issue New Retailer GPS object for Web Service compatible XML soap data format.</returns>
        public ServiceStringXML SaveScIssueNewRetailer(decimal scIssNewRetID, decimal distribitorID, decimal rsoID, decimal routeID, String retailerMobile, String retailerName, String scSerialStart, String scSerialEnd, String sms, decimal latitudeValue, decimal longitudeValue, decimal status)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_INS_UPD_SCISSUENEWRETAILERcls().GetType().Name;

            try
            {
                Decimal scIssueNewRetailerID = new RetailerDZ().SaveScIssueNewRetailer(scIssNewRetID, distribitorID, rsoID, routeID, retailerMobile, retailerName, scSerialStart, scSerialEnd, sms, latitudeValue, longitudeValue, status);
                if (scIssueNewRetailerID != 0)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, true, MessageGodown.SaveNotification);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.FailSaveNotification);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        /// <summary>
        /// Get all new Retailer request information.
        /// </summary>
        /// <param name="scIssueNewRetailerID"></param>
        /// <param name="distribitorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public List<SP_GET_SCISSUENEWRETAILERcls> GetAllIssueNewRetailerInfo(decimal scIssueNewRetailerID, decimal distribitorID, decimal rsoID, decimal currentPage)
        {
            try
            {
                return new RetailerDZ().GetAllIssueNewRetailerInfo(scIssueNewRetailerID, distribitorID, rsoID, currentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save Market Update information from web service.
        /// </summary>
        /// <param name="distribitorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="retailerID"></param>
        /// <param name="eventNameID"></param>
        /// <param name="operatorID"></param>
        /// <param name="eventNote"></param>
        /// <param name="picLocation"></param>
        /// <param name="eventDate"></param>
        /// <param name="picture64String"></param>
        /// <returns>Market Update for Web Service compatible XML soap data format.</returns>
        public ServiceStringXML SaveMarketUpdateXML(decimal distribitorID, decimal rsoID, decimal retailerID, decimal eventNameID, decimal operatorID,
            string eventNote, String picLocation, DateTime eventDate, String picture64String)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();

            String objectXML = string.Empty;
            string objectItemName = new SP_INS_UPD_MARKET_UPDATEcls().GetType().Name;

            try
            {
                int isDisplay = (int)EnumCollection.ActiveInactiveEnum.Active; // 1 for true
                Decimal marketUpdateID = new RetailerDZ().SaveMarketUpdate(0, distribitorID, rsoID, retailerID, eventNameID, operatorID,
                       eventNote, picLocation, eventDate, isDisplay, 0, DateTime.Now, picture64String);

                if (marketUpdateID != 0)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, true, MessageGodown.SaveNotification);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.FailSaveNotification);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        /// <summary>
        /// Edit Market Update information.
        /// </summary>
        /// <param name="marketUpdateID"></param>
        /// <param name="updateBy"></param>
        /// <returns></returns>
        public decimal EditMarketUpdate(decimal marketUpdateID, decimal updateBy)
        {
            decimal editMarketUpdateID = 0;

            try
            {
                int isDisplay = (int)EnumCollection.ActiveInactiveEnum.Inactive; // 0 for false -> not display

                decimal distribitorID = 0, rsoID = 0, retailerID = 0, eventNameID = 0, operatorID = 0;
                string eventNote = string.Empty, picLocation = string.Empty;
                DateTime eventDate = DateTime.Now, updateDate = DateTime.Now;

                editMarketUpdateID = new RetailerDZ().SaveMarketUpdate(marketUpdateID, distribitorID, rsoID, retailerID, eventNameID, operatorID,
                            eventNote, picLocation, eventDate, isDisplay, updateBy, updateDate, string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return editMarketUpdateID;
        }

        /// <summary>
        /// Get all Market Update information.
        /// </summary>
        /// <param name="operatorNameID"></param>
        /// <param name="eventNameID"></param>
        /// <param name="distribitorID"></param>
        /// <param name="RSOCode"></param>
        /// <param name="retailerCode"></param>
        /// <param name="eventFromDate"></param>
        /// <param name="eventToDate"></param>
        /// <returns>List of related object</returns>
        public List<SP_INS_UPD_MARKET_UPDATEcls> GetAllMarketUpdateCode(decimal operatorNameID, decimal eventNameID, decimal distribitorID, string RSOCode, string retailerCode, string eventFromDate, string eventToDate)
        {
            try
            {
                List<SP_INS_UPD_MARKET_UPDATEcls> marketColl = new RetailerDZ().GetAllMarketUpdate(operatorNameID, eventNameID, distribitorID, RSOCode, retailerCode, eventFromDate, eventToDate);

                if (marketColl != null)
                {
                    foreach (var item in marketColl)
                    {
                        item.PICTURE_BASE64 = item.PICTURE_URL + ',' + item.PICTURE_BASE64;
                        item.OPERATOR_NAME = ((EnumCollection.OperationNameEnum)item.OPERATORID).ToString();
                    }
                }
                return marketColl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Retailer monthly or date interval wise target , achivement and commission information.
        /// </summary>
        /// <param name="retailerID"></param>
        /// <param name="distributorID"></param>
        /// <param name="prodCategoryID"></param>
        /// <param name="fromMonthDate"></param>
        /// <param name="toMonthDate"></param>
        /// <returns>Retailer Target Achivement object for Web Service compatible XML soap data format.</returns>
        public ServiceStringXML GetRetailerTargetAndAchivement(decimal retailerID, decimal distributorID, decimal prodCategoryID, string fromMonthDate, string toMonthDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_GET_RETAILER_TAR_ACHIEVEcls().GetType().Name + _collectionNodePart;
            try
            {
                List<SP_GET_RETAILER_TAR_ACHIEVEcls> retailerColl = new RetailerDZ().GetRetailerTargetAndAchivement(retailerID, distributorID, prodCategoryID, fromMonthDate, toMonthDate);
                if (retailerColl != null && retailerColl.Count > 0)
                {
                    foreach (var item in retailerColl)
                    {
                        item.PRODUCT_CATEGORY_NAME = ((ProductCategoryEnum)item.PRODUCT_CATEGORY_ID).ToString();
                    }
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_RETAILER_TAR_ACHIEVEcls>(retailerColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }


        /// <summary>
        /// Using this methods get all retailer GPS location by parameter wise search GPS location result and paging by 10 row record
        /// </summary>
        /// <param name="distribitorID"></param>
        /// <param name="routeID"></param>
        /// <param name="retailerID"></param>
        /// <param name="isPending">'-1' -> not check pending or approved</param>
        /// <param name="isActive">'-1' -> not check active or incative</param>
        /// <param name="currentPageNumber"></param>
        /// <returns></returns>
        public List<SP_GET_RETAILER_GPS_LOCcls> GetAllRetailerGPSLocation(decimal distribitorID, decimal routeID, decimal retailerID, decimal isPending, decimal isActive, decimal currentPageNumber)
        {
            try
            {
                return new RetailerDZ().GetAllRetailerGPSLocation(distribitorID, routeID, retailerID, isPending, isActive, currentPageNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all Retailer target , achivement and commission information from RSO_RETAILER_TARGET. orderByEnumValue = 1 top ten and orderByEnumValue = 2 bottom ten 
        /// </summary>
        /// <param name="retailerID"></param>
        /// <param name="distributorID"></param>
        /// <param name="prodCategoryID"></param>
        /// <param name="monthDate"></param>
        /// <param name="orderByEnumValue">orderByEnumValue = 1 top ten and orderByEnumValue = 2 bottom ten </param>
        /// <returns>RETAILER_TOP_BOTTOMcls object for Web Service compatible XML soap data format.</returns>
        public ServiceStringXML GetRetailerTargetTopBottomTen(decimal retailerID, decimal distributorID, decimal prodCategoryID, string monthDate, decimal orderByEnumValue)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new RETAILER_TOP_BOTTOMcls().GetType().Name + _collectionNodePart;
            try
            {
                List<RETAILER_TOP_BOTTOMcls> retTopBottomColl = new List<RETAILER_TOP_BOTTOMcls>();
                List<SP_GET_RETAILER_TAR_ACHI_T_Bcls> retailerColl = new RetailerDZ().GetRetailerTargetTopBottomTen(retailerID, distributorID, prodCategoryID, monthDate, orderByEnumValue);
                if (retailerColl != null && retailerColl.Count > 0)
                {
                    foreach (var item in retailerColl)
                    {
                        if (item.PRODUCT_CATEGORY_ID == (int)ProductCategoryEnum.iTOPUP)
                        {
                            RETAILER_TOP_BOTTOMcls retTopBottom = new RETAILER_TOP_BOTTOMcls();
                            retTopBottom.RETAILER_ID = item.RETAILER_ID;
                            retTopBottom.RETAILER_NAME = item.NAME;
                            retTopBottom.RETAILER_CODE = item.CODE;
                            retTopBottom.RETAILER_NAME_CODE = item.RETAILER_NAME_CODE;
                            retTopBottom.RETAILER_ADDRESS = item.ADDRESS;
                            retTopBottom.MONTH_DATE = item.MONTH_DATE;
                            retTopBottom.RATIO_PERCENT = (item.ACHIVEMENT_AMOUNT / item.TARGET_AMOUNT) * 100;
                            retTopBottomColl.Add(retTopBottom);
                        }
                    }
                    if (orderByEnumValue == 1)
                    {
                        if (retTopBottomColl != null && retTopBottomColl.Count > 10)
                        {
                            objectXML = ConversionXML.ConvertObjectToXML<RETAILER_TOP_BOTTOMcls>(retTopBottomColl.OrderBy(ret => ret.RATIO_PERCENT).Take(10).ToList(), _collectionNodePart);
                        }
                        else
                        {
                            objectXML = ConversionXML.ConvertObjectToXML<RETAILER_TOP_BOTTOMcls>(retTopBottomColl.OrderBy(ret => ret.RATIO_PERCENT).ToList(), _collectionNodePart);
                        }
                    }
                    else
                    {
                        if (retTopBottomColl != null && retTopBottomColl.Count > 10)
                        {
                            objectXML = ConversionXML.ConvertObjectToXML<RETAILER_TOP_BOTTOMcls>(retTopBottomColl.OrderByDescending(ret => ret.RATIO_PERCENT).Take(10).ToList(), _collectionNodePart);
                        }
                        else
                        {
                            objectXML = ConversionXML.ConvertObjectToXML<RETAILER_TOP_BOTTOMcls>(retTopBottomColl.OrderByDescending(ret => ret.RATIO_PERCENT).ToList(), _collectionNodePart);
                        }
                    }
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        /// <summary>
        /// Get particular Retailer last transaction voucher information.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="retailerID"></param>
        /// <param name="productID"></param>
        /// <param name="tranFromDate"></param>
        /// <param name="tranToDate"></param>
        /// <returns></returns>
        public ServiceStringXML GetRetailerLastLifting(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new RETAILER_LAST_LIFTINGcls().GetType().Name + _collectionNodePart;
            try
            {
                List<RETAILER_LAST_LIFTINGcls> lastLiftingColl = new List<RETAILER_LAST_LIFTINGcls>();

                lastLiftingColl = new RetailerDZ().GetRetailerLastLiftingInfo(distributorID, retailerID, productID, tranFromDate, tranToDate);
                if (lastLiftingColl != null && lastLiftingColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<RETAILER_LAST_LIFTINGcls>(lastLiftingColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML GetRetailerSimStockDetail(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_RETAILER_SIMSTOCK().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_RETAILER_SIMSTOCK> simStockColl = new List<GET_RETAILER_SIMSTOCK>();

                simStockColl = new RetailerDZ().GetRetailerSimStockDetail(distributorID, retailerID, productID, tranFromDate, tranToDate);
                if (simStockColl != null && simStockColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_RETAILER_SIMSTOCK>(simStockColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }


        public ServiceStringXML GetRetailerCurrentOffer(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_RETAILER_OFFER().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_RETAILER_OFFER> simStockColl = new List<GET_RETAILER_OFFER>();

                simStockColl = new RetailerDZ().GetRetailerCurrentOffer(distributorID, retailerID, productID, tranFromDate, tranToDate);
                if (simStockColl != null && simStockColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_RETAILER_OFFER>(simStockColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }



        public ServiceStringXML GetRetailerCurrentOfferImage(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_RETAILER_OFFER_IMAGE().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_RETAILER_OFFER_IMAGE> simStockColl = new List<GET_RETAILER_OFFER_IMAGE>();

                simStockColl = new RetailerDZ().GetRetailerCurrentOfferImage(distributorID, retailerID, productID, tranFromDate, tranToDate);
                if (simStockColl != null && simStockColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_RETAILER_OFFER_IMAGE>(simStockColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML GetRetailerCurrentBalance(decimal distributorID, decimal retailerID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new RETAILER_CURRENT_BALANCE().GetType().Name + _collectionNodePart;
            try
            {
                List<RETAILER_CURRENT_BALANCE> currentBalalnceList = new List<RETAILER_CURRENT_BALANCE>();

                currentBalalnceList = new RetailerDZ().GetRetailerCurrentBalance(distributorID, retailerID);
                RETAILER_CURRENT_BALANCE currentBalalnce = currentBalalnceList[0];

                if (currentBalalnce != null)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<RETAILER_CURRENT_BALANCE>(currentBalalnce);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }


        /// <summary>
        /// Get particular Retailer channel fill information. Channel fill = total SIM issue to Retailer - total sales SIM activated to system.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="retailerID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public ServiceStringXML GetRetailerChannelfill(decimal distributorID, decimal retailerID, string startDate, string endDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new RETAILER_CHANNELFILLcls().GetType().Name + _collectionNodePart;
            try
            {
                List<RETAILER_CHANNELFILLcls> channelfillColl = new RetailerDZ().GetRetailerChannelFileInfo(retailerID, startDate, endDate);
                if (channelfillColl != null && channelfillColl.Count > 0)
                {
                    channelfillColl[0].DISTRIBUTOR_ID = distributorID;
                    objectXML = ConversionXML.ConvertObjectToXML<RETAILER_CHANNELFILLcls>(channelfillColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        /// <summary>
        /// Get Retailer by search parameter wise value.
        /// </summary>
        /// <param name="distributorId"></param>
        /// <param name="retailerCode"></param>
        /// <returns></returns>
        public List<SP_GET_RETAIL_RSO_WISECls> GetRetailerByDistributorAndRetailerCode(decimal distributorId, string retailerCode)
        {
            try
            {
                return new RetailerDZ().GetRetailerByDistributorAndRetailerCode(distributorId, retailerCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ServiceStringXML IssueNewBalance(decimal distributorID, decimal retailerID, decimal rsoID, decimal amount, decimal latitude, decimal longtitude)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_GET_INS_UPD_SAF_INFOcls().GetType().Name;
            try
            {
                //needed to test duplicate sim no 
                // List<SP_GET_INS_UPD_SAF_INFOcls> safInfoColl = new SAFInfoDZ().GetSAFInfoSingle(retailerID, rsoID);
                //if (safInfoColl == null || safInfoColl.Count == 0)
                //{
                Decimal BalanceId = new RetailerDZ().IssueNewBalance(distributorID, retailerID, rsoID, amount, latitude, longtitude);

                if (BalanceId != 0)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, true, MessageGodown.SaveNotification);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.FailSaveNotification);
                }
                //}
                //else
                //{
                //    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DuplicateSimNo);
                //}
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML GetInvoice(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_INVOICE().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_INVOICE> lastLiftingColl = new List<GET_INVOICE>();

                lastLiftingColl = new RetailerDZ().GetInvoice(distributorID, retailerID, productID, tranFromDate, tranToDate);
                if (lastLiftingColl != null && lastLiftingColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_INVOICE>(lastLiftingColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML CheckBalanceStatus(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_BALANCE_STATUS().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_BALANCE_STATUS> balanceStatusColl = new List<GET_BALANCE_STATUS>();

                balanceStatusColl = new RetailerDZ().CheckBalanceStatus(distributorID, retailerID, productID, tranFromDate, tranToDate);
                GET_BALANCE_STATUS balanceStatus = balanceStatusColl[0];
                if (balanceStatusColl != null && balanceStatusColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_BALANCE_STATUS>(balanceStatus);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML UssdCall(decimal distributorID, decimal retailerID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_USSD_CALL().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_USSD_CALL> balanceStatusColl = new List<GET_USSD_CALL>();

                balanceStatusColl = new RetailerDZ().UssdCall(distributorID, retailerID);
                GET_USSD_CALL balanceStatus = balanceStatusColl[0];
                if (balanceStatusColl != null && balanceStatusColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_USSD_CALL>(balanceStatus);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML StockAndSales(decimal distributorID, decimal retailerID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_RETAILER_OFFER().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_STOCK_AND_SALES> simStockColl = new List<GET_STOCK_AND_SALES>();

                simStockColl = new RetailerDZ().StockAndSales(distributorID, retailerID);
                if (simStockColl != null && simStockColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_STOCK_AND_SALES>(simStockColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML SafCollection(decimal distributorID, decimal retailerID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_RETAILER_OFFER().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_SAF_COLLECTION> simStockColl = new List<GET_SAF_COLLECTION>();

                simStockColl = new RetailerDZ().SafCollection(distributorID, retailerID);
                if (simStockColl != null && simStockColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_SAF_COLLECTION>(simStockColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }


        public ServiceStringXML CollectedSafList(decimal distributorID, decimal retailerID, string fromDate, string toDate, string missdn)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_COLLECTED_SAF().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_COLLECTED_SAF> collectedSaf = new List<GET_COLLECTED_SAF>();

                collectedSaf = new RetailerDZ().CollectedSafList(distributorID, retailerID, fromDate, toDate, missdn);
                if (collectedSaf != null && collectedSaf.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_COLLECTED_SAF>(collectedSaf, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }



        public ServiceStringXML CommissionHistory(decimal distributorID, decimal retailerID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_COMMISSION_HISTORY().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_COMMISSION_HISTORY> collectedSaf = new List<GET_COMMISSION_HISTORY>();

                collectedSaf = new RetailerDZ().CommissionHistory(distributorID, retailerID);
                if (collectedSaf != null && collectedSaf.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_COMMISSION_HISTORY>(collectedSaf, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }


        public ServiceStringXML RetailerInfoUpdate(decimal distributorID, decimal retailerID, string retailerName, string ownerName, string contactNo, string mobileNo, string address)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_RETAILER_INFO_UPDATE().GetType().Name;
            try
            {
                Decimal DistributorID = new RetailerDZ().RetailerInfoUpdate(distributorID, retailerID, retailerName, ownerName, contactNo, mobileNo, address);

                if (DistributorID != 0)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, true, MessageGodown.SaveNotification);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.FailSaveNotification);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML FocProducts(decimal distributorID, decimal retailerID, decimal productId, string dateFrom, string dateTo, decimal zoneId, decimal teritoryId, decimal rsoId)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_FOC_PRODUCTS().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_FOC_PRODUCTS> focProducts = new List<GET_FOC_PRODUCTS>();

                focProducts = new RetailerDZ().FocProducts(distributorID, retailerID, productId, dateFrom, dateTo, zoneId, teritoryId, rsoId);
                if (focProducts != null && focProducts.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_FOC_PRODUCTS>(focProducts, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;


        }

        public ServiceStringXML RouteList(decimal distributorID, decimal rsoId, string lastLiftingDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_ROUTE_LIST().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_ROUTE_LIST> routList = new List<GET_ROUTE_LIST>();

                routList = new RetailerDZ().RouteList(distributorID, rsoId, lastLiftingDate);
                if (routList != null && routList.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_ROUTE_LIST>(routList, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML NewOutletStatus(decimal distribitorID, decimal rsoID, decimal routeID, string dateFrom, string dateTo)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_NEW_OUTLET_STATUS().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_NEW_OUTLET_STATUS> newOutletStatus = new List<GET_NEW_OUTLET_STATUS>();

                newOutletStatus = new RetailerDZ().NewOutletStatus(distribitorID, rsoID, routeID, dateFrom, dateTo);
                if (newOutletStatus != null && newOutletStatus.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_NEW_OUTLET_STATUS>(newOutletStatus, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML CommissionStructureImage(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_COMMISSION_STRACTURE_IMAGE().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_COMMISSION_STRACTURE_IMAGE> simStockColl = new List<GET_COMMISSION_STRACTURE_IMAGE>();

                simStockColl = new RetailerDZ().CommissionStructureImage(distributorID, retailerID, productID, tranFromDate, tranToDate);
                if (simStockColl != null && simStockColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_COMMISSION_STRACTURE_IMAGE>(simStockColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }


        public ServiceStringXML GetRegion()
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_REGION().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_REGION> regionColl = new List<GET_REGION>();

                regionColl = new RetailerDZ().GetRegion(0, 0, 0);
                if (regionColl != null && regionColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_REGION>(regionColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }


        public List<GET_REGION> GetRegions(decimal ClusterId, decimal UserId, decimal IsRegionLevel)
        {
            List<GET_REGION> regionList = new List<GET_REGION>();
            try
            {
                regionList = new RetailerDZ().GetRegion(ClusterId, UserId, IsRegionLevel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return regionList;
        }

        public List<GET_ZONE> GetZones(decimal ZoneId, decimal RegionId, decimal UserId, decimal IsZonalUser)
        {
            List<GET_ZONE> zoneList = new List<GET_ZONE>();
            try
            {
                zoneList = new RetailerDZ().GetZones(ZoneId, RegionId, UserId, IsZonalUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return zoneList;
        }

        public List<GET_ALL_ZONE> GetAllZones(decimal ZoneId, decimal RegionId, decimal UserId, decimal IsZonalUser)
        {
            List<GET_ALL_ZONE> zoneList = new List<GET_ALL_ZONE>();
            try
            {
                zoneList = new RetailerDZ().GetAllZones(ZoneId, RegionId, UserId, IsZonalUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return zoneList;
        }

        public List<GET_DROPDOWN> GetRoutesByZone(decimal ZoneId)
        {
            List<GET_DROPDOWN> routeList = new List<GET_DROPDOWN>();
            try
            {
                routeList = new RetailerDZ().GetRoutesByZone(ZoneId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return routeList;
        }



        public List<SP_GET_RETAILERcls> GetRetailers(Decimal DistributorId, Decimal RouteId, Decimal RetailerId)
        {
            List<SP_GET_RETAILERcls> regionList = new List<SP_GET_RETAILERcls>();
            try
            {
                regionList = new RetailerDZ().GetAllRetailer(DistributorId, RouteId, RetailerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return regionList;
        }

        public ServiceStringXML GetZone(decimal regionID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_ZONE().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_ZONE> zoneColl = new List<GET_ZONE>();

                zoneColl = new RetailerDZ().GetZone(regionID);
                if (zoneColl != null && zoneColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_ZONE>(zoneColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        public ServiceStringXML GetTeritory(decimal zoneID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new GET_TERITORY().GetType().Name + _collectionNodePart;
            try
            {
                List<GET_TERITORY> teritoryColl = new List<GET_TERITORY>();

                teritoryColl = new RetailerDZ().GetTeritory(zoneID);
                if (teritoryColl != null && teritoryColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<GET_TERITORY>(teritoryColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

    }
}
