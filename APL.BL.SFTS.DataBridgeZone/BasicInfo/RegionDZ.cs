using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class RegionDZ
    {
        public RegionDZ() { }


        /// <summary>
        ///  methods is calling to provide all region or particular region info.
        /// </summary>
        /// <param name="regionID">default value is zero</param>
        /// <param name="regionCode">default value  is empty string</param>
        /// <returns>List of Region object</returns>

        public List<SP_GET_REGIONcls> GetAllRegion(Decimal regionID, string regionCode)
        {
            try
            {
                OracleParameter regionID_OP = new OracleParameter();
                regionID_OP.Direction = System.Data.ParameterDirection.Input;
                regionID_OP.OracleDbType = OracleDbType.Decimal;
                regionID_OP.Value = regionID;

                OracleParameter regionCodeOP = new OracleParameter();
                regionCodeOP.Direction = System.Data.ParameterDirection.Input;
                regionCodeOP.OracleDbType = OracleDbType.Varchar2;
                regionCodeOP.Value = regionCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_REGIONcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_REGIONcls>.GetDataBySP(new SP_GET_REGIONcls(), "SP_GET_REGION", 4, resultOutCurSor, regionID_OP, regionCodeOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
