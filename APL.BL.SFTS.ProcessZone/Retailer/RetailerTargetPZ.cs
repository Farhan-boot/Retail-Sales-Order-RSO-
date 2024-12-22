using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.Retailer;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Retailer
{
    public class RetailerTargetPZ
    {
        public RetailerTargetPZ()
        { }

        public List<SP_FF_GET_RETAILER_TARGET> GetRetailerTargets(decimal TargetId, decimal UserId)
        {
            List<SP_FF_GET_RETAILER_TARGET> mainMenuList = new List<SP_FF_GET_RETAILER_TARGET>();
            try
            {
                mainMenuList = new RetailerTargetDZ().GetRetailerTargets(TargetId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return mainMenuList;
        }

        public List<SP_FF_GET_TARGET_PERIOD> GetTargetPeriodList(decimal UserId)
        {
            List<SP_FF_GET_TARGET_PERIOD> mainMenuList = new List<SP_FF_GET_TARGET_PERIOD>();
            try
            {
                mainMenuList = new RetailerTargetDZ().GetTargetPeriodList(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return mainMenuList;
        }
        public List<SP_FF_GET_TARGET_ITEM> GetTargetItemList(decimal UserId)
        {
            List<SP_FF_GET_TARGET_ITEM> mainMenuList = new List<SP_FF_GET_TARGET_ITEM>();
            try
            {
                mainMenuList = new RetailerTargetDZ().GetTargetItemList(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return mainMenuList;
        }
        public Decimal SaveTargetToTemp(List<SP_FF_GET_RETAILER_TARGET> retailerTargetList, decimal UserId)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                decimal IsDeleted = new RetailerTargetDZ().DeleteRetailerTargetTemp();

                if (IsDeleted > 0)
                {
                    foreach (var retailerTarget in retailerTargetList)
                    {
                        IsEventSaved = new RetailerTargetDZ().SaveTargetToTemp(0, retailerTarget, UserId);
                    }
                }


                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public List<SP_FF_GET_RETAILER_TARGET> GetRetailTargetsTemp(decimal UserId)
        {
            List<SP_FF_GET_RETAILER_TARGET> mainMenuList = new List<SP_FF_GET_RETAILER_TARGET>();
            try
            {
                mainMenuList = new RetailerTargetDZ().GetRetailerTargetsTemp(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return mainMenuList;
        }
        public Decimal SaveRetailerTarget(RetailerTarget retailerTarget, decimal UserId)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;

                IsEventSaved = new RetailerTargetDZ().SaveRetailerTarget(retailerTarget, UserId);
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public decimal DeleteInfo(decimal trainingId)
        {
            try
            {
                return new RetailerTargetDZ().DeleteInfo(trainingId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal DeleteRetailerTargetTemp()
        {
            try
            {
                return new RetailerTargetDZ().DeleteRetailerTargetTemp();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
