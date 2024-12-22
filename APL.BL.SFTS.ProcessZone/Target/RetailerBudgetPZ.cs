using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
   public class RetailerBudgetPZ
    {

       public List<SP_GET_RETAITER_BUDGETcls> GetRetailerBudget(decimal retailerBudgetID, decimal targetSetupID, decimal distributorBudgetID,
           decimal distributorID, decimal retailerID, decimal productCategoryID, string monthDate, decimal currentPage)
        {
            try
            {
                return new RetailerBudgetDZ().GetRetailerBudget(retailerBudgetID, targetSetupID, distributorBudgetID, distributorID, retailerID, 
                    productCategoryID, monthDate, currentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public decimal SaveUpdateRetailerBudget(decimal retailerBudgetID, decimal targetSetupID, decimal distributorBudgetID, decimal distributorID, decimal retailerID, DateTime startDate,
           DateTime endDate, DateTime monthDate, decimal budgetAmount, decimal achievementAmount,
           decimal commissionAmount, decimal LoginID, decimal productCategoryID, string productIdList, decimal budgetUnit)
        {
            try
            {
                return new RetailerBudgetDZ().SaveUpdateRetailerBudget(retailerBudgetID, targetSetupID, distributorBudgetID, 
                    distributorID,retailerID, startDate, endDate, monthDate
                    , budgetAmount, achievementAmount, commissionAmount, LoginID, productCategoryID, productIdList, budgetUnit);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
