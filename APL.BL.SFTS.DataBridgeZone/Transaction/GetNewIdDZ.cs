using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class GetNewIdDZ
    {          
        public Decimal GetNewId(string sequenceName)
        {
            try
            {
                OracleParameter sequenceNameOP = new OracleParameter();
                sequenceNameOP.Direction = System.Data.ParameterDirection.Input;
                sequenceNameOP.OracleDbType = OracleDbType.Varchar2;
                sequenceNameOP.Value = sequenceName;
             
                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_NEW_ID>.InsertDataBySP("SP_FF_GET_NEW_ID", resultOutID, sequenceNameOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
