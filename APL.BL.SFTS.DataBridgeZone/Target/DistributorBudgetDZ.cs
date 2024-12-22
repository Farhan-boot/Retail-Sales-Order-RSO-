using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
   public class DistributorBudgetDZ
    {
       public Decimal SaveUpdateDistributorBudget(decimal distributorBudgetID, decimal targetSetupID, decimal grossBudgetID, decimal distributorID, DateTime startDate,
           DateTime endDate, DateTime monthDate, decimal budgetAmount, decimal achievementAmount, decimal commissionAmount, decimal LoginID, decimal productCategoryID, string productIdList, decimal budgetUnit)
        {
            try
            {
                OracleParameter distributorBudgetID_OP = new OracleParameter();
                distributorBudgetID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorBudgetID_OP.OracleDbType = OracleDbType.Decimal;
                distributorBudgetID_OP.Value = distributorBudgetID;

                OracleParameter targetSetupID_OP = new OracleParameter();
                targetSetupID_OP.Direction = System.Data.ParameterDirection.Input;
                targetSetupID_OP.OracleDbType = OracleDbType.Decimal;
                targetSetupID_OP.Value = targetSetupID;

                OracleParameter grossBudgetID_OP = new OracleParameter();
                grossBudgetID_OP.Direction = System.Data.ParameterDirection.Input;
                grossBudgetID_OP.OracleDbType = OracleDbType.Decimal;
                grossBudgetID_OP.Value = grossBudgetID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter startDate_OP = new OracleParameter();
                startDate_OP.Direction = System.Data.ParameterDirection.Input;
                startDate_OP.OracleDbType = OracleDbType.Date;
                startDate_OP.Value = startDate;

                OracleParameter endDate_OP = new OracleParameter();
                endDate_OP.Direction = System.Data.ParameterDirection.Input;
                endDate_OP.OracleDbType = OracleDbType.Date;
                endDate_OP.Value = endDate;

                OracleParameter monthDate_OP = new OracleParameter();
                monthDate_OP.Direction = System.Data.ParameterDirection.Input;
                monthDate_OP.OracleDbType = OracleDbType.Date;
                monthDate_OP.Value = monthDate;

                OracleParameter budgetAmount_OP = new OracleParameter();
                budgetAmount_OP.Direction = System.Data.ParameterDirection.Input;
                budgetAmount_OP.OracleDbType = OracleDbType.Decimal;
                budgetAmount_OP.Value = budgetAmount;

                OracleParameter achievementAmount_OP = new OracleParameter();
                achievementAmount_OP.Direction = System.Data.ParameterDirection.Input;
                achievementAmount_OP.OracleDbType = OracleDbType.Decimal;
                achievementAmount_OP.Value = achievementAmount;

                OracleParameter commissionAmount_OP = new OracleParameter();
                commissionAmount_OP.Direction = System.Data.ParameterDirection.Input;
                commissionAmount_OP.OracleDbType = OracleDbType.Decimal;
                commissionAmount_OP.Value = commissionAmount;

                OracleParameter LoginID_OP = new OracleParameter();
                LoginID_OP.Direction = System.Data.ParameterDirection.Input;
                LoginID_OP.OracleDbType = OracleDbType.Decimal;
                LoginID_OP.Value = LoginID;

                OracleParameter productCategoryID_OP = new OracleParameter();
                productCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                productCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                productCategoryID_OP.Value = productCategoryID;

                OracleParameter productIdList_OP = new OracleParameter();
                productIdList_OP.Direction = System.Data.ParameterDirection.Input;
                productIdList_OP.OracleDbType = OracleDbType.Varchar2;
                productIdList_OP.Value = productIdList;

                OracleParameter budgetUnit_OP = new OracleParameter();
                budgetUnit_OP.Direction = System.Data.ParameterDirection.Input;
                budgetUnit_OP.OracleDbType = OracleDbType.Decimal;
                budgetUnit_OP.Value = budgetUnit;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR_BUDGETcls>.InsertDataBySP("SP_INS_UP_DISTRIBUTOR_BUDGET", resultOutID, distributorBudgetID_OP, targetSetupID_OP, grossBudgetID_OP, distributorID_OP,
                    startDate_OP, endDate_OP, monthDate_OP, budgetAmount_OP, achievementAmount_OP, commissionAmount_OP, LoginID_OP, productCategoryID_OP, productIdList_OP, budgetUnit_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public List<SP_GET_DISTRIBUTOR_BUDGETcls> GetDistributorBudget(decimal distributorBudgetID, decimal targetSetupID, decimal grossBudgetID, decimal distributorID, string monthDate, Decimal currentPage, decimal productCategoryID)
        {
            try
            {
                OracleParameter distributorBudgetID_OP = new OracleParameter();
                distributorBudgetID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorBudgetID_OP.OracleDbType = OracleDbType.Decimal;
                distributorBudgetID_OP.Value = distributorBudgetID;

                OracleParameter targetSetupID_OP = new OracleParameter();
                targetSetupID_OP.Direction = System.Data.ParameterDirection.Input;
                targetSetupID_OP.OracleDbType = OracleDbType.Decimal;
                targetSetupID_OP.Value = targetSetupID;

                OracleParameter grossBudgetID_OP = new OracleParameter();
                grossBudgetID_OP.Direction = System.Data.ParameterDirection.Input;
                grossBudgetID_OP.OracleDbType = OracleDbType.Decimal;
                grossBudgetID_OP.Value = grossBudgetID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter monthDate_OP = new OracleParameter();
                monthDate_OP.Direction = System.Data.ParameterDirection.Input;
                monthDate_OP.OracleDbType = OracleDbType.Varchar2;
                monthDate_OP.Value = monthDate;

                OracleParameter currentPage_OP = new OracleParameter();
                currentPage_OP.Direction = System.Data.ParameterDirection.Input;
                currentPage_OP.OracleDbType = OracleDbType.Decimal;
                currentPage_OP.Value = currentPage;

                OracleParameter productCategoryID_OP = new OracleParameter();
                productCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                productCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                productCategoryID_OP.Value = productCategoryID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DISTRIBUTOR_BUDGETcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR_BUDGETcls>.GetDataBySP(new SP_GET_DISTRIBUTOR_BUDGETcls(), "SP_GET_ALL_DISTRIBUTOR_BUDGET", 16, resultOutCurSor, distributorBudgetID_OP, targetSetupID_OP, grossBudgetID_OP, distributorID_OP, monthDate_OP, currentPage_OP, productCategoryID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
