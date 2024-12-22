using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class CommissionGroupDZ
    {
        public CommissionGroupDZ(){ }

        #region Save Methods

        /// <summary>
        /// Save or update commission group info.
        /// </summary>
        /// <param name="commissionGroupID"></param>
        /// <param name="name"></param>
        /// <param name="commissionStatusId"></param>
        /// <param name="createBy"></param>
        /// <param name="createDate"></param>
        /// <param name="updateBy"></param>
        /// <param name="updateDate"></param>
        /// <returns>commissionGroupID</returns>
        public Decimal Save(decimal commissionGroupID, string name, decimal commissionStatusId, decimal createBy, DateTime createDate, decimal updateBy, DateTime updateDate)
        {
            try
            {
                OracleParameter commissionInfoID_OP = new OracleParameter();
                commissionInfoID_OP.Direction = System.Data.ParameterDirection.Input;
                commissionInfoID_OP.OracleDbType = OracleDbType.Decimal;
                commissionInfoID_OP.Value = commissionGroupID;

                OracleParameter name_OP = new OracleParameter();
                name_OP.Direction = System.Data.ParameterDirection.Input;
                name_OP.OracleDbType = OracleDbType.Varchar2;
                name_OP.Value = name;

                OracleParameter commissionStatusIdOP = new OracleParameter();
                commissionStatusIdOP.Direction = System.Data.ParameterDirection.Input;
                commissionStatusIdOP.OracleDbType = OracleDbType.Decimal;
                commissionStatusIdOP.Value = commissionStatusId;                

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

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_COMMISSION_GROUPcls>.InsertDataBySP("SP_IU_COMMISSION_GROUP", resultOutID,
                    commissionInfoID_OP, name_OP, commissionStatusIdOP, createBy_OP, createDate_OP, updateBy_OP, updateDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Save Methods

        #region Get Methods

        /// <summary>
        /// Get all commission group by search option.
        /// </summary>
        /// <param name="commissionGroupId"></param>
        /// <param name="name"></param>
        /// <param name="statusId"></param>
        /// <param name="currentPage"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_COMMISSION_GROUPcls> GetAll(decimal commissionGroupId, string name, decimal statusId, decimal currentPage)
        {
            try
            {
                OracleParameter commissionGroupIdOP = new OracleParameter();
                commissionGroupIdOP.Direction = System.Data.ParameterDirection.Input;
                commissionGroupIdOP.OracleDbType = OracleDbType.Decimal;
                commissionGroupIdOP.Value = commissionGroupId;

                OracleParameter name_OP = new OracleParameter();
                name_OP.Direction = System.Data.ParameterDirection.Input;
                name_OP.OracleDbType = OracleDbType.Varchar2;
                name_OP.Value = name;

                OracleParameter statusIdOP = new OracleParameter();
                statusIdOP.Direction = System.Data.ParameterDirection.Input;
                statusIdOP.OracleDbType = OracleDbType.Decimal;
                statusIdOP.Value = statusId;

                OracleParameter currentPage_OP = new OracleParameter();
                currentPage_OP.Direction = System.Data.ParameterDirection.Input;
                currentPage_OP.OracleDbType = OracleDbType.Decimal;
                currentPage_OP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_COMMISSION_GROUPcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_COMMISSION_GROUPcls>.GetDataBySP(new SP_GET_COMMISSION_GROUPcls(), "SP_GET_COMMISSION_GROUP", 9,
                    resultOutCurSor, commissionGroupIdOP, name_OP, statusIdOP, currentPage_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Methods
    }
}
