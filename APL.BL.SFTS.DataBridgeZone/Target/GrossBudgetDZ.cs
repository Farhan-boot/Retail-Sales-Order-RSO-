
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class GrossBudgetDZ
    {
        public Decimal SaveUpdateGrossBudget(decimal grossBudgetID, DateTime monthDate, DateTime monthStartDate, DateTime monthEndDate,
             decimal budgetAmount, string note, decimal IsApproved, decimal LoginID, decimal productCategoryID, string productIdList, decimal budgetUnit)
        {
            try
            {
                OracleParameter grossBudgetID_OP = new OracleParameter();
                grossBudgetID_OP.Direction = System.Data.ParameterDirection.Input;
                grossBudgetID_OP.OracleDbType = OracleDbType.Decimal;
                grossBudgetID_OP.Value = grossBudgetID;

                OracleParameter monthDate_OP = new OracleParameter();
                monthDate_OP.Direction = System.Data.ParameterDirection.Input;
                monthDate_OP.OracleDbType = OracleDbType.Date;
                monthDate_OP.Value = monthDate;

                OracleParameter monthStartDate_OP = new OracleParameter();
                monthStartDate_OP.Direction = System.Data.ParameterDirection.Input;
                monthStartDate_OP.OracleDbType = OracleDbType.Date;
                monthStartDate_OP.Value = monthStartDate;

                OracleParameter monthEndDate_OP = new OracleParameter();
                monthEndDate_OP.Direction = System.Data.ParameterDirection.Input;
                monthEndDate_OP.OracleDbType = OracleDbType.Date;
                monthEndDate_OP.Value = monthEndDate;

                OracleParameter budgetAmount_OP = new OracleParameter();
                budgetAmount_OP.Direction = System.Data.ParameterDirection.Input;
                budgetAmount_OP.OracleDbType = OracleDbType.Decimal;
                budgetAmount_OP.Value = budgetAmount;

                OracleParameter note_OP = new OracleParameter();
                note_OP.Direction = System.Data.ParameterDirection.Input;
                note_OP.OracleDbType = OracleDbType.Varchar2;
                note_OP.Value = note;

                OracleParameter isApproved_OP = new OracleParameter();
                isApproved_OP.Direction = System.Data.ParameterDirection.Input;
                isApproved_OP.OracleDbType = OracleDbType.Decimal;
                isApproved_OP.Value = IsApproved;

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

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_GROSS_BUDGETcls>.InsertDataBySP("SP_INS_UP_GROSS_BUDGET", resultOutID, monthEndDate_OP, monthDate_OP, monthStartDate_OP, grossBudgetID_OP, LoginID_OP,
                                                                                                     note_OP, budgetAmount_OP, isApproved_OP, productCategoryID_OP, productIdList_OP, budgetUnit_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_GROSS_BUDGETcls> GetGrossBudget(decimal grossBudgetID, string monthYear,decimal productCategoryID, string monthStartDate, string monthEndDate, Decimal currentPage)
        {
            try
            {
                OracleParameter grossBudgetID_OP = new OracleParameter();
                grossBudgetID_OP.Direction = System.Data.ParameterDirection.Input;
                grossBudgetID_OP.OracleDbType = OracleDbType.Decimal;
                grossBudgetID_OP.Value = grossBudgetID;

                OracleParameter monthYear_OP = new OracleParameter();
                monthYear_OP.Direction = System.Data.ParameterDirection.Input;
                monthYear_OP.OracleDbType = OracleDbType.Varchar2;
                monthYear_OP.Value = monthYear;

                OracleParameter productCategoryID_OP = new OracleParameter();
                productCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                productCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                productCategoryID_OP.Value = productCategoryID;

                OracleParameter monthStartDate_OP = new OracleParameter();
                monthStartDate_OP.Direction = System.Data.ParameterDirection.Input;
                monthStartDate_OP.OracleDbType = OracleDbType.Varchar2;
                monthStartDate_OP.Value = monthStartDate;

                OracleParameter monthEndDate_OP = new OracleParameter();
                monthEndDate_OP.Direction = System.Data.ParameterDirection.Input;
                monthEndDate_OP.OracleDbType = OracleDbType.Varchar2;
                monthEndDate_OP.Value = monthEndDate;

                OracleParameter currentPage_OP = new OracleParameter();
                currentPage_OP.Direction = System.Data.ParameterDirection.Input;
                currentPage_OP.OracleDbType = OracleDbType.Decimal;
                currentPage_OP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_GROSS_BUDGETcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_GROSS_BUDGETcls>.GetDataBySP(new SP_GET_GROSS_BUDGETcls(), "SP_GET_ALL_GROSS_BUDGET", 12, resultOutCurSor, grossBudgetID_OP, monthYear_OP, productCategoryID_OP, monthStartDate_OP, monthEndDate_OP, currentPage_OP);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
