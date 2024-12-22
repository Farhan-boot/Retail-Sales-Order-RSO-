using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class CommissionInfoDZ
    {
        public CommissionInfoDZ()
        { }

        #region Save Methods
        public Decimal SaveCommissionInfo(decimal commissionInfoID, decimal applicableID, string name, decimal amount, decimal commissonPercent, 
            decimal createBy, DateTime createDate, decimal updateBy, DateTime updateDate)
        {
            try
            {
                OracleParameter commissionInfoID_OP = new OracleParameter();
                commissionInfoID_OP.Direction = System.Data.ParameterDirection.Input;
                commissionInfoID_OP.OracleDbType = OracleDbType.Decimal;
                commissionInfoID_OP.Value = commissionInfoID;

                OracleParameter applicableID_OP = new OracleParameter();
                applicableID_OP.Direction = System.Data.ParameterDirection.Input;
                applicableID_OP.OracleDbType = OracleDbType.Decimal;
                applicableID_OP.Value = applicableID;


                OracleParameter name_OP = new OracleParameter();
                name_OP.Direction = System.Data.ParameterDirection.Input;
                name_OP.OracleDbType = OracleDbType.Varchar2;
                name_OP.Value = name;

                OracleParameter amount_OP = new OracleParameter();
                amount_OP.Direction = System.Data.ParameterDirection.Input;
                amount_OP.OracleDbType = OracleDbType.Decimal;
                amount_OP.Value = amount;



                OracleParameter commissonPercent_OP = new OracleParameter();
                commissonPercent_OP.Direction = System.Data.ParameterDirection.Input;
                commissonPercent_OP.OracleDbType = OracleDbType.Decimal;
                commissonPercent_OP.Value = commissonPercent;

                OracleParameter createBy_OP = new OracleParameter();
                createBy_OP.Direction = System.Data.ParameterDirection.Input;
                createBy_OP.OracleDbType = OracleDbType.Decimal;
                createBy_OP.Value = createBy;

                OracleParameter createDate_OP = new OracleParameter();
                createDate_OP.Direction = System.Data.ParameterDirection.Input;
                createDate_OP.OracleDbType = OracleDbType.Varchar2;
                createDate_OP.Value = createDate.ToString("dd-MMM-yyyy");

                OracleParameter updateBy_OP = new OracleParameter();
                updateBy_OP.Direction = System.Data.ParameterDirection.Input;
                updateBy_OP.OracleDbType = OracleDbType.Decimal;
                updateBy_OP.Value = updateBy;

                OracleParameter updateDate_OP = new OracleParameter();
                updateDate_OP.Direction = System.Data.ParameterDirection.Input;
                updateDate_OP.OracleDbType = OracleDbType.Varchar2;
                updateDate_OP.Value = updateDate.ToString("dd-MMM-yyyy");


                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_COMMISSION_INFOcls>.InsertDataBySP("SP_INS_UPD_COMMISSION_INFO", resultOutID,
                    commissionInfoID_OP, applicableID_OP, name_OP, amount_OP, commissonPercent_OP, createBy_OP, createDate_OP, updateBy_OP, updateDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Methods
        public List<SP_INS_UPD_COMMISSION_INFOcls> GetAllCommissionInfo(decimal applicableID, string name, decimal currentPage)
        {
            try
            {
                OracleParameter applicableID_OP = new OracleParameter();
                applicableID_OP.Direction = System.Data.ParameterDirection.Input;
                applicableID_OP.OracleDbType = OracleDbType.Decimal;
                applicableID_OP.Value = applicableID;

                OracleParameter name_OP = new OracleParameter();
                name_OP.Direction = System.Data.ParameterDirection.Input;
                name_OP.OracleDbType = OracleDbType.Varchar2;
                name_OP.Value = name;

                OracleParameter currentPage_OP = new OracleParameter();
                currentPage_OP.Direction = System.Data.ParameterDirection.Input;
                currentPage_OP.OracleDbType = OracleDbType.Decimal;
                currentPage_OP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_INS_UPD_COMMISSION_INFOcls>)ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_COMMISSION_INFOcls>.GetDataBySP(new SP_INS_UPD_COMMISSION_INFOcls(), "SP_GET_COMMISSION_INFO", 10,
                    resultOutCurSor, applicableID_OP, name_OP, currentPage_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
