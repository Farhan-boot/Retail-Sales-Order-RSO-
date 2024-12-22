using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class CurrentOfferPZ
    {
        public CurrentOfferPZ()
        {
        }

       
        public const string _collectionNodePart = "Coll";
          
        /// <summary>
        /// Gets all current offer object list or particular current offer object which filter by distributorID.
        /// </summary>
        /// <param name="distributorID">defualt value is zero for all current offer</param>
        /// <returns>List of current offer object for Web Service compatible XML soap data format </returns>
        public ServiceStringXML GetCurrentOfferByDistributorXML(decimal distributorID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_GET_RETAIL_RSO_WISECls().GetType().Name + _collectionNodePart;
            try
            {
                List<SP_GET_CURRENT_OFFERcls> curOfferColl = new CurrentOfferDZ().GetCurrentOfferSearch(0, 0, string.Empty, DateTime.Today.ToString("dd MMM yyyy"), DateTime.Today.ToString("dd MMM yyyy"), -1);  //GetCurrentOfferByDistributor(distributorID);
                List<SP_GET_CURRENT_OFFERcls> curOfferFilterColl = new List<SP_GET_CURRENT_OFFERcls>(); 

                foreach(var curOffer in curOfferColl)
                {
                    if(curOffer.DISTRIBUTOR_ID == 0)
                    {
                        curOfferFilterColl.Add(curOffer);
                    }
                    else if (curOffer.DISTRIBUTOR_ID == distributorID)
                    {
                        curOfferFilterColl.Add(curOffer);
                    }
                }

                if (curOfferFilterColl != null && curOfferFilterColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_CURRENT_OFFERcls>(curOfferFilterColl, _collectionNodePart);
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
        /// Gets all current offer object list or particular current offer object which filter by search parameter.
        /// </summary>       
        /// <returns>List of current offer object</returns>   
        public List<SP_GET_CURRENT_OFFERcls> GetCurrentOfferSearch(decimal currentOffer, decimal distributorID,
            string offerName, string startDate, string endDate, Decimal currentPage)
        {
            try
            {
                return new CurrentOfferDZ().GetCurrentOfferSearch(currentOffer, distributorID, offerName, startDate,
                    endDate, currentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     


  
        /// <summary>
        /// Save or upate current offer if id is zero then save data other update by parameter values.
        /// </summary>      
        /// <returns>if save or update properly return Table ID or zero fail save or update info </returns>
        /// 
        public decimal SaveUpdateCurrentOffer(decimal OfferId, string OfferName,
                                             string OfferDetail, DateTime StartDate, DateTime EndDate,
                                             DateTime DisplayDateFrom, DateTime DisplayDateTo, decimal TargetType,
                                             decimal IsToAll, decimal? StaffRoleId, decimal IsActive, decimal CreatedBy, List<GET_ID> currentOfferRegList, List<GET_ID> currentOfferDistList)
        {
            decimal result = 0;
            try
            {
                result = new CurrentOfferDZ().SaveUpdateCurrentOffer(OfferId, OfferName, OfferDetail, StartDate, EndDate, DisplayDateFrom, DisplayDateTo, TargetType, IsToAll, StaffRoleId, IsActive, CreatedBy);

                result = new CurrentOfferDZ().DeleteExistingCurrentOfferReg(OfferId);
                if (currentOfferRegList.Count > 0)
                {
                    foreach (var currentOfferReg in currentOfferRegList)
                    {
                        new CurrentOfferDZ().SaveUpdateCurrentOfferRegion(OfferId, currentOfferReg.Id);
                    }
                }

                result = new CurrentOfferDZ().DeleteExistingCurrentOfferDist(OfferId);
                if (currentOfferDistList.Count > 0)
                {
                    foreach (var currentOfferDist in currentOfferDistList)
                    {
                        new CurrentOfferDZ().SaveUpdateCurrentOfferDistributor(OfferId, currentOfferDist.Id);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public decimal SaveUpdateCommissionStructure(decimal Id, string OfferName,
                                            string OfferDetail, DateTime StartDate, DateTime EndDate,
                                            DateTime DisplayDateFrom, DateTime DisplayDateTo, decimal TargetType,
                                            decimal IsToAll, decimal StaffRoleId, decimal IsActive, decimal CreatedBy, List<GET_ID> commissionStructureRegList)
        {
            try
            {
                decimal result = 0;
                result=new CurrentOfferDZ().SaveUpdateCommissionStructure(Id, OfferName, OfferDetail, StartDate, EndDate, DisplayDateFrom, DisplayDateTo, TargetType, IsToAll, StaffRoleId, IsActive, CreatedBy);

              
                if(Id==0 && result>0)
                {
                    Id = result;
                }
                result = new CurrentOfferDZ().DeleteExistingCommissionStructureReg(Id);
                if (commissionStructureRegList.Count > 0)
                {
                    foreach (var item in commissionStructureRegList)
                    {
                        new CurrentOfferDZ().SaveUpdateCommissionStructureRegion(Id, item.Id);
                    }
                }
                return Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }


        public decimal DeletePicture(decimal pictureId)
        {
            try
            {
                return new CurrentOfferDZ().DeletePicture(pictureId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal DeleteCommissionPicture(decimal pictureId)
        {
            try
            {
                return new CurrentOfferDZ().DeleteCommissionPicture(pictureId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public decimal SaveUpdateOfferPictures(decimal Id, decimal OfferId, decimal PicSlNo, string PictureName, byte[] Picture, decimal CreatedBy)
        {
            try
            {
                return new CurrentOfferDZ().SaveUpdateOfferPictures(Id, OfferId, PicSlNo, PictureName, Picture, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateCommissionPictures(decimal Id, decimal CommissionId, decimal PicSlNo, string PictureName, byte[] Picture, decimal CreatedBy)
        {
            try
            {
                return new CurrentOfferDZ().SaveUpdateCommissionPictures(Id, CommissionId, PicSlNo, PictureName, Picture, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_ALL_CURRENT_OFFER> GetAllCurrentOffer(decimal CurrentOfferId)
        {
            try
            {
                return new CurrentOfferDZ().GetAllCurrentOffer(CurrentOfferId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_ALL_DISTRIBUTOR> GetCurrentOfferDistributor(decimal CurrentOfferId)
        {
            try
            {
                return new CurrentOfferDZ().GetCurrentOfferDistributor(CurrentOfferId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_ALL_DISTRIBUTOR> GetCurrentOfferRegion(decimal CurrentOfferId)
        {
            try
            {
                return new CurrentOfferDZ().GetCurrentOfferRegion(CurrentOfferId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_ALL_DISTRIBUTOR> GetCommissionStructureRegion(decimal CommissionId)
        {
            try
            {
                return new CurrentOfferDZ().GetCommissionStructureRegion(CommissionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_COMMISSION_STRUCTURE> GetAllCommission(decimal CommissionId)
        {
            try
            {
                return new CurrentOfferDZ().GetAllCommission(CommissionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_CURRENT_OFFER> GetCurrentOffer(decimal StaffUserId)
        {
            try
            {
                return new CurrentOfferDZ().GetCurrentOffer(StaffUserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_CURRENT_OFFER> GetRetailerCurrentOffer(decimal RetailerId)
        {
            try
            {
                return new CurrentOfferDZ().GetRetailerCurrentOffer(RetailerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      

        public List<SP_GET_CURRENT_OFFER> GetRSOCurrentOffer(decimal RSOId)
        {
            try
            {
                return new CurrentOfferDZ().GetRSOCurrentOffer(RSOId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_FEEDBACK_OPTION> GetFeedbackOptions(decimal UserId, decimal LanguageId)
        {
            try
            {
                return new CurrentOfferDZ().GetFeedbackOptions(UserId, LanguageId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_COMPLAIN_TYPE> GetComplainTypes(decimal Id)
        {
            try
            {
                return new CurrentOfferDZ().GetComplainTypes(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_COMMISSION_STRUCTURE> GetCommissionStructureEntityWise(decimal UserId, decimal EntityType)
        {
            try
            {
                return new CurrentOfferDZ().GetCommissionStructureEntityWise(UserId, EntityType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GET_REGION> GetRegions(decimal ClusterId)
        {
            List<GET_REGION> regionList = new List<GET_REGION>();
            try
            {
                regionList = new CurrentOfferDZ().GetRegion(ClusterId);
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
    }
}
