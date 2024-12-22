using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace APL.BL.SFTS.DataBridgeZone
{
	public class ApplicationLogDZ
	{
		public ApplicationLogDZ()
		{

		}

		public Decimal INSERT_APPLICATION_ACCESSLOG(decimal USERID, string APPLICATION_NAME, string MODULE_NAME, string ACTIVITY_NAME, string CHANGED_VALUE, string USER_IP, string ACTIONTYPE)
		{
			try
			{

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;
				
				OracleParameter USERID_OP = new OracleParameter();
				USERID_OP.Direction = System.Data.ParameterDirection.Input;
				USERID_OP.OracleDbType = OracleDbType.Decimal;
				USERID_OP.Value = USERID;

				OracleParameter APPLICATION_NAME_OP = new OracleParameter();
				APPLICATION_NAME_OP.Direction = System.Data.ParameterDirection.Input;
				APPLICATION_NAME_OP.OracleDbType = OracleDbType.Varchar2;
				APPLICATION_NAME_OP.Value = APPLICATION_NAME;

				OracleParameter MODULE_NAME_OP = new OracleParameter();
				MODULE_NAME_OP.Direction = System.Data.ParameterDirection.Input;
				MODULE_NAME_OP.OracleDbType = OracleDbType.Varchar2;
				MODULE_NAME_OP.Value = MODULE_NAME;

				OracleParameter ACTIVITY_NAME_OP = new OracleParameter();
				ACTIVITY_NAME_OP.Direction = System.Data.ParameterDirection.Input;
				ACTIVITY_NAME_OP.OracleDbType = OracleDbType.Varchar2;
				ACTIVITY_NAME_OP.Value = ACTIVITY_NAME;

				OracleParameter CHANGED_VALUE_OP = new OracleParameter();
				CHANGED_VALUE_OP.Direction = System.Data.ParameterDirection.Input;
				CHANGED_VALUE_OP.OracleDbType = OracleDbType.Varchar2;
				CHANGED_VALUE_OP.Value = CHANGED_VALUE;

				OracleParameter USER_IP_OP = new OracleParameter();
				USER_IP_OP.Direction = System.Data.ParameterDirection.Input;
				USER_IP_OP.OracleDbType = OracleDbType.Varchar2;
				USER_IP_OP.Value = USER_IP;

				OracleParameter ACTIONTYPE_OP = new OracleParameter();
				ACTIONTYPE_OP.Direction = System.Data.ParameterDirection.Input;
				ACTIONTYPE_OP.OracleDbType = OracleDbType.Varchar2;
				ACTIONTYPE_OP.Value = ACTIONTYPE;

				return ObjectMakerFromOracleSP.OracleHelper<ISVALID_UPLOAD>.InsertDataBySP("INSERT_APPLICATION_ACCESSLOG", resultOutID, USERID_OP, APPLICATION_NAME_OP, MODULE_NAME_OP, ACTIVITY_NAME_OP, CHANGED_VALUE_OP, USER_IP_OP, ACTIONTYPE_OP);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


	}
}
