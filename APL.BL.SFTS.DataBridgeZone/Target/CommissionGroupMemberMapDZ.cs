using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class CommissionGroupMemberMapDZ
    {
        public CommissionGroupMemberMapDZ(){}

        #region Save Methods

        /// <summary>
        /// Save or update commission group member info.
        /// </summary>
        /// <param name="comGrpMemMapId"></param>
        /// <param name="comGrpId"></param>
        /// <param name="memberName"></param>
        /// <param name="execlClnName"></param>
        /// <param name="excelClnNo"></param>
        /// <param name="serialNo"></param>
        /// <param name="createBy"></param>
        /// <param name="createDate"></param>
        /// <param name="updateBy"></param>
        /// <param name="updateDate"></param>
        /// <returns>ComGrpMemMapId</returns>
        public decimal Save(decimal comGrpMemMapId, decimal comGrpId, string memberName, string execlClnName, decimal excelClnNo, decimal serialNo, decimal createBy, DateTime createDate, decimal updateBy, DateTime updateDate)
        {
            try
            {
                OracleParameter comGrpMemMapIdOP = new OracleParameter();
                comGrpMemMapIdOP.Direction = System.Data.ParameterDirection.Input;
                comGrpMemMapIdOP.OracleDbType = OracleDbType.Decimal;
                comGrpMemMapIdOP.Value = comGrpMemMapId;

                OracleParameter comGrpIdOP = new OracleParameter();
                comGrpIdOP.Direction = System.Data.ParameterDirection.Input;
                comGrpIdOP.OracleDbType = OracleDbType.Decimal;
                comGrpIdOP.Value = comGrpId;

                OracleParameter memberNameOP = new OracleParameter();
                memberNameOP.Direction = System.Data.ParameterDirection.Input;
                memberNameOP.OracleDbType = OracleDbType.Varchar2;
                memberNameOP.Value = memberName;

                OracleParameter execlClnNameOP = new OracleParameter();
                execlClnNameOP.Direction = System.Data.ParameterDirection.Input;
                execlClnNameOP.OracleDbType = OracleDbType.Varchar2;
                execlClnNameOP.Value = execlClnName;

                OracleParameter excelClnNoOP = new OracleParameter();
                excelClnNoOP.Direction = System.Data.ParameterDirection.Input;
                excelClnNoOP.OracleDbType = OracleDbType.Decimal;
                excelClnNoOP.Value = excelClnNo;

                OracleParameter serialNoOP = new OracleParameter();
                serialNoOP.Direction = System.Data.ParameterDirection.Input;
                serialNoOP.OracleDbType = OracleDbType.Decimal;
                serialNoOP.Value = serialNo;

                OracleParameter createByOP = new OracleParameter();
                createByOP.Direction = System.Data.ParameterDirection.Input;
                createByOP.OracleDbType = OracleDbType.Decimal;
                createByOP.Value = createBy;

                OracleParameter createDateOP = new OracleParameter();
                createDateOP.Direction = System.Data.ParameterDirection.Input;
                createDateOP.OracleDbType = OracleDbType.Varchar2;
                createDateOP.Value = createDate.ToString("dd-MMM-yyyy");

                OracleParameter updateByOP = new OracleParameter();
                updateByOP.Direction = System.Data.ParameterDirection.Input;
                updateByOP.OracleDbType = OracleDbType.Decimal;
                updateByOP.Value = updateBy;

                OracleParameter updateDateOP = new OracleParameter();
                updateDateOP.Direction = System.Data.ParameterDirection.Input;
                updateDateOP.OracleDbType = OracleDbType.Varchar2;
                updateDateOP.Value = updateDate.ToString("dd-MMM-yyyy");

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_COMMISSION_GRP_MEM_MAPcls>.InsertDataBySP("SP_IU_COMMISSION_GRP_MEM_MAP", resultOutID,
                    comGrpMemMapIdOP, comGrpIdOP, memberNameOP, execlClnNameOP, excelClnNoOP, serialNoOP, createByOP, createDateOP, updateByOP, updateDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Save Methods

        #region Get Methods

        /// <summary>
        /// Get all commission group member by search option.
        /// </summary>
        /// <param name="comGrpMemMapId"></param>
        /// <param name="comGrpId"></param>
        /// <param name="memberName"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public List<SP_GET_COMMISSION_GRP_MEM_MAPcls> GetAll(decimal comGrpMemMapId, decimal comGrpId, string memberName, decimal currentPage)
        {
            try
            {
                OracleParameter comGrpMemMapIdOP = new OracleParameter();
                comGrpMemMapIdOP.Direction = System.Data.ParameterDirection.Input;
                comGrpMemMapIdOP.OracleDbType = OracleDbType.Decimal;
                comGrpMemMapIdOP.Value = comGrpMemMapId;

                OracleParameter comGrpIdOP = new OracleParameter();
                comGrpIdOP.Direction = System.Data.ParameterDirection.Input;
                comGrpIdOP.OracleDbType = OracleDbType.Decimal;
                comGrpIdOP.Value = comGrpId;

                OracleParameter memberNameOP = new OracleParameter();
                memberNameOP.Direction = System.Data.ParameterDirection.Input;
                memberNameOP.OracleDbType = OracleDbType.Varchar2;
                memberNameOP.Value = memberName;

                OracleParameter currentPageOP = new OracleParameter();
                currentPageOP.Direction = System.Data.ParameterDirection.Input;
                currentPageOP.OracleDbType = OracleDbType.Decimal;
                currentPageOP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_COMMISSION_GRP_MEM_MAPcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_COMMISSION_GRP_MEM_MAPcls>.GetDataBySP(new SP_GET_COMMISSION_GRP_MEM_MAPcls(), "SP_GET_COMMISSION_GRP_MEM_MAP", 13,
                    resultOutCurSor, comGrpMemMapIdOP, comGrpIdOP, memberNameOP, currentPageOP);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        #endregion Get Methods
    }
}
