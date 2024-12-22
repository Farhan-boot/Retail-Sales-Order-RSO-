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
    public  class CriticalRetailerBalancePZ
    {
        public CriticalRetailerBalancePZ()
        { }

        public List<SP_GET_CRTL_RETAILER_BALANCE> GetCriticalBalances(decimal CriticalBalanceId, decimal UserId)
        {
            List<SP_GET_CRTL_RETAILER_BALANCE> mainMenuList = new List<SP_GET_CRTL_RETAILER_BALANCE>();
            try
            {
                mainMenuList = new CriticalRetailerBalanceDZ().GetCriticalBalances(CriticalBalanceId, UserId);
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
        public SP_GET_DD_RETAILER_INFO GetRetailerDistributorInfo(String retailerCode)
        {
            SP_GET_DD_RETAILER_INFO mainList = new SP_GET_DD_RETAILER_INFO();
            try
            {
                var resultList = new CriticalRetailerBalanceDZ().GetRetailerDistributorInfo(retailerCode);
                if (resultList != null && resultList.Count>0)
                {
                    mainList = resultList.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return mainList;
        }
        public List<SP_GET_CRTBALANCE_TEMP> GetCriticalBalancesTemp(decimal UserId)
        {
            List<SP_GET_CRTBALANCE_TEMP> mainMenuList = new List<SP_GET_CRTBALANCE_TEMP>();
            try
            {
                mainMenuList = new CriticalRetailerBalanceDZ().GetCriticalBalancesTemp(UserId);
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
        public Decimal SaveBalanceToTemp(List<SP_GET_CRTL_RETAILER_BALANCE> retailerBallanceList, decimal UserId)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                decimal  IsDeleted = new CriticalRetailerBalanceDZ().DeleteCriticalBalanceTemp();

                if(IsDeleted>0)
                {
                    foreach (var retailerBallance in retailerBallanceList)
                    {
                        IsEventSaved = new CriticalRetailerBalanceDZ().SaveBalanceToTemp(0, retailerBallance, UserId);
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

        public Decimal SaveCriticalBalance(CriticalBalance criticalBalance, decimal UserId)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;

                IsEventSaved = new CriticalRetailerBalanceDZ().SaveCriticalBalance(criticalBalance, UserId);
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public Decimal DeleteCriticalBalanceTemp()
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;

                IsEventSaved = new CriticalRetailerBalanceDZ().DeleteCriticalBalanceTemp();
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
