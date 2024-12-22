using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class GenerateTokenDZ
    {          
        public Decimal InsertToken(string userName, string token, decimal appId, string version, string deviceID, decimal LAN)
        {
            try
            {
                OracleParameter userNameOP = new OracleParameter();
                userNameOP.Direction = System.Data.ParameterDirection.Input;
                userNameOP.OracleDbType = OracleDbType.Varchar2;
                userNameOP.Value = userName;

                OracleParameter tokenOP = new OracleParameter();
                tokenOP.Direction = System.Data.ParameterDirection.Input;
                tokenOP.OracleDbType = OracleDbType.Varchar2;
                tokenOP.Value = token;

                OracleParameter appIdOP = new OracleParameter();
                appIdOP.Direction = System.Data.ParameterDirection.Input;
                appIdOP.OracleDbType = OracleDbType.Varchar2;
                appIdOP.Value = appId;

                OracleParameter version_OP = new OracleParameter();
                version_OP.Direction = System.Data.ParameterDirection.Input;
                version_OP.OracleDbType = OracleDbType.Varchar2;
                version_OP.Value = version;

				OracleParameter deviceID_OP = new OracleParameter();
				deviceID_OP.Direction = System.Data.ParameterDirection.Input;
				deviceID_OP.OracleDbType = OracleDbType.Varchar2;
				deviceID_OP.Value = deviceID;

				OracleParameter lanOP = new OracleParameter();
				lanOP.Direction = System.Data.ParameterDirection.Input;
				lanOP.OracleDbType = OracleDbType.Decimal;
				lanOP.Value = LAN;

				OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_USER_TOKEN>.InsertDataBySP("SP_FF_INS_TOKENV2", resultOutID, userNameOP, tokenOP, appIdOP, version_OP, deviceID_OP, lanOP);
                //return ObjectMakerFromOracleSP.OracleHelper<GET_USER_TOKEN>.InsertDataBySP("SP_FF_INS_TOKEN", resultOutID, userNameOP, tokenOP, appIdOP, version_OP, deviceID_OP, lanOP);
            }

			catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal TokenExpiration(decimal userId, string token)
        {
            try
            {
                OracleParameter userIdOP = new OracleParameter();
                userIdOP.Direction = System.Data.ParameterDirection.Input;
                userIdOP.OracleDbType = OracleDbType.Decimal;
                userIdOP.Value = userId;

                OracleParameter tokenOP = new OracleParameter();
                tokenOP.Direction = System.Data.ParameterDirection.Input;
                tokenOP.OracleDbType = OracleDbType.Varchar2;
                tokenOP.Value = token;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_USER_TOKEN>.InsertDataBySP("SP_FF_INS_TOKEN_EXPIRATION", resultOutID, userIdOP, tokenOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal WebTokenExpiration(string userName, string token, decimal appId)
        {
            try
            {
                OracleParameter userNameOP = new OracleParameter();
                userNameOP.Direction = System.Data.ParameterDirection.Input;
                userNameOP.OracleDbType = OracleDbType.Varchar2;
                userNameOP.Value = userName;

                OracleParameter tokenOP = new OracleParameter();
                tokenOP.Direction = System.Data.ParameterDirection.Input;
                tokenOP.OracleDbType = OracleDbType.Varchar2;
                tokenOP.Value = token;

                OracleParameter appIdOP = new OracleParameter();
                appIdOP.Direction = System.Data.ParameterDirection.Input;
                appIdOP.OracleDbType = OracleDbType.Decimal;
                appIdOP.Value = appId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_USER_TOKEN>.InsertDataBySP("SP_FF_TOKEN_EXPIRATION", resultOutID, userNameOP, tokenOP, appIdOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Decimal ValidateToken(decimal userId, string token)
        {
            try
            {
                OracleParameter userIdOP = new OracleParameter();
                userIdOP.Direction = System.Data.ParameterDirection.Input;
                userIdOP.OracleDbType = OracleDbType.Decimal;
                userIdOP.Value = userId;

                OracleParameter tokenOP = new OracleParameter();
                tokenOP.Direction = System.Data.ParameterDirection.Input;
                tokenOP.OracleDbType = OracleDbType.Varchar2;
                tokenOP.Value = token;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_USER_TOKEN>.InsertDataBySP("SP_FF_INS_TOKEN_VALIDATE", resultOutID, userIdOP, tokenOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal ValidateWebToken(string userName, string token, decimal? appId)
        {
            try
            {
                OracleParameter userNameOP = new OracleParameter();
                userNameOP.Direction = System.Data.ParameterDirection.Input;
                userNameOP.OracleDbType = OracleDbType.Varchar2;
                userNameOP.Value = userName;

                OracleParameter tokenOP = new OracleParameter();
                tokenOP.Direction = System.Data.ParameterDirection.Input;
                tokenOP.OracleDbType = OracleDbType.Varchar2;
                tokenOP.Value = token;

                OracleParameter appIdOP = new OracleParameter();
                appIdOP.Direction = System.Data.ParameterDirection.Input;
                appIdOP.OracleDbType = OracleDbType.Decimal;
                appIdOP.Value = appId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_USER_TOKEN>.InsertDataBySP("SP_FF_VALIDATE_WEB_TOKEN", resultOutID, userNameOP, tokenOP, appIdOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
