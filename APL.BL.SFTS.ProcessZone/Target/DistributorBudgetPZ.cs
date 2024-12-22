using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
   public class DistributorBudgetPZ
    {

       public List<SP_GET_DISTRIBUTOR_BUDGETcls> GetDistributorBudget(decimal distributorBudgetID, decimal targetSetupID, decimal grossBudgetID, decimal distributorID, string monthDate, decimal currentPage, decimal productCategoryID)
        {
            try
            {
                return new DistributorBudgetDZ().GetDistributorBudget(distributorBudgetID, targetSetupID, grossBudgetID, distributorID, monthDate, currentPage, productCategoryID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateDistributorBudget(decimal distributorBudgetID, decimal targetSetupID, decimal grossBudgetID, decimal distributorID, DateTime startDate,
           DateTime endDate, DateTime monthDate, decimal budgetAmount, decimal achievementAmount, decimal commissionAmount, decimal LoginID, decimal productCategoryID, string productIdList, decimal budgetUnit)
        {
            try
            {
                return new DistributorBudgetDZ().SaveUpdateDistributorBudget(distributorBudgetID, targetSetupID, grossBudgetID, distributorID, startDate, endDate,monthDate
                    , budgetAmount, achievementAmount, commissionAmount, LoginID, productCategoryID, productIdList, budgetUnit);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
