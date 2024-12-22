using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class NationalTargetDistributionPZ
    {
        public NationalTargetDistributionPZ()
        { }

        /// <summary>
        /// Save national target distribution which prepare from excel file. It is descript Region target or Distributor target or RSO target or Retailer target value for particular national target setup wise value. Also check each target node is valide.
        /// </summary>
        /// <param name="natTarDistribution"></param>
        /// <param name="natTarDistributionDetailColl"></param>
        /// <param name="processingMsg"></param>
        /// <returns>NatTarDistributionID</returns>
        public Decimal Save(SP_GET_NAT_TAR_DISTRIBUTIONcls natTarDistribution, List<SP_GET_NAT_TAR_DISTRIBUTION_WCcls> natTarDistributionDetailColl , ref string processingMsg)
        {
            try
            {
                //decimal updateBy = createBy;
                //DateTime updateDate = createDate;
                List<SP_GET_REGIONcls> regionAllColl = new RegionDZ().GetAllRegion(0, string.Empty);
                List<SP_GET_DISTRIBUTORcls>  distributorAllColl = new DistributorDZ().GetAllDistributor(0, 0);
                decimal rowCounter=0;
                foreach (SP_GET_NAT_TAR_DISTRIBUTION_WCcls item in natTarDistributionDetailColl)
                {
                    rowCounter++;

                    SP_GET_REGIONcls region = regionAllColl.Find(reg => reg.REGION_CODE.Trim().Equals(item.REGION_CODE.Trim()));
                    if (region != null)
                    {
                        item.REGION_ID = region.REGION_ID;
                    }
                    else
                    {
                        processingMsg = "Fail to Save! Excel Row no : " + rowCounter.ToString() + ". Invalide Region Code --> " + item.REGION_CODE.Trim() + ". Which is not found in DMS.";
                        break;
                    }

                    SP_GET_DISTRIBUTORcls distributor = distributorAllColl.Find(dis => dis.DISTRIBUTOR_CODE.Trim().Equals(item.DISTRIBUTOR_CODE.Trim()));
                    if (distributor != null)
                    {
                        item.DISTRIBUTOR_ID = distributor.DISTRIBUTOR_ID;
                    }
                    else
                    {
                        processingMsg = "Fail to Save! Excel Row no : " + rowCounter.ToString() + ". Invalide Distributor Code --> " + item.DISTRIBUTOR_CODE.Trim() + ". Which is not found in DMS.";
                        break;
                    }
                }
                if (processingMsg.Trim()!= string.Empty)
                {
                    return 0;
                }
                return new NationalTargetDistributionDZ().Save(natTarDistribution, natTarDistributionDetailColl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all national target distribution by search option.
        /// </summary>
        /// <param name="channelID"></param>
        /// <param name="targetAmtTypeID"></param>
        /// <param name="natTarDescription"></param>
        /// <param name="comGroID"></param>
        /// <param name="monthDate"></param>
        /// <param name="regionID"></param>
        /// <param name="distributorID"></param>
        /// <param name="nationalTargetSetupID"></param>
        /// <param name="currentPageNo"></param>
        /// <returns></returns>
        public List<SP_GET_NAT_TAR_DISTRIBUTIONcls> GetParentAll(decimal channelID, decimal targetAmtTypeID, String natTarDescription, decimal comGroID, DateTime monthDate, decimal regionID, decimal distributorID, decimal nationalTargetSetupID, decimal currentPageNo)
        {
            try
            {
                return new NationalTargetDistributionDZ().GetParentAll(channelID, targetAmtTypeID, natTarDescription, comGroID, monthDate, regionID, distributorID, nationalTargetSetupID, currentPageNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all national target distribution detail (child) by search option.
        /// </summary>
        /// <param name="natTarDistributionID"></param>
        /// <param name="natTarDistributionDetailID"></param>
        /// <param name="channelID"></param>
        /// <param name="targetAmtTypeID"></param>
        /// <param name="natTarSetupID"></param>
        /// <param name="comGroID"></param>
        /// <param name="monthDate"></param>
        /// <param name="regionID"></param>
        /// <param name="distributorID"></param>
        /// <returns></returns>
        public List<SP_GET_NAT_TAR_DISTRIBUTION_WCcls> GetParentChildAll(decimal natTarDistributionID, decimal natTarDistributionDetailID, decimal channelID, decimal targetAmtTypeID, decimal natTarSetupID, decimal comGroID, DateTime monthDate, decimal regionID, decimal distributorID)
        {
            try
            {
                return new NationalTargetDistributionDZ().GetParentChildAll( natTarDistributionID,  natTarDistributionDetailID, channelID, targetAmtTypeID, natTarSetupID, comGroID, monthDate, regionID, distributorID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
