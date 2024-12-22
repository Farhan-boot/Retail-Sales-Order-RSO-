using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class GrossBudgetPZ
    {
        public const string _collectionNodePart = "Coll";

        public List<SP_GET_GROSS_BUDGETcls> GetGrossBudget(decimal grossBudgetID, string monthYear, decimal productCategoryID, string monthStartDate, string monthEndDate, Decimal currentPage)
        {
            try
            {
                return new GrossBudgetDZ().GetGrossBudget(grossBudgetID, monthYear,productCategoryID, monthStartDate, monthEndDate, currentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateGrossBudget(decimal grossBudgetID, DateTime monthDate, DateTime monthStartDate, DateTime monthEndDate,
             decimal budgetAmount, string note, decimal isApproved, decimal LoginID, decimal productCategoryID, string productIdList, decimal budgetUnit)
        {
            try
            {
                return new GrossBudgetDZ().SaveUpdateGrossBudget(grossBudgetID, monthDate, monthStartDate, monthEndDate, budgetAmount, note, isApproved, LoginID, productCategoryID, productIdList, budgetUnit);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
