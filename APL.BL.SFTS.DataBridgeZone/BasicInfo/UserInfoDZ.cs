
using System;
using System.Linq;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class UserInfoDZ
    {
        public UserInfoDZ()
        { }

        /// <summary>
        /// Get Server date , time and date time information.
        /// </summary>
        /// <returns></returns>
        public List<SP_GET_SERVER_INFOcls> GetServerInfo()
        {
            try
            {               
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SERVER_INFOcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SERVER_INFOcls>.GetDataLoginDBySP(new SP_GET_SERVER_INFOcls(), "SP_GET_SERVER_INFO", 3, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This methods is calling to provide particular login user info.
        /// </summary>      
        /// <returns>User info object</returns>
        public List<SP_GET_USERINFOcls> GetLoginUserInfo(string loginName, string loginPassword)
        {
            try
            {
                OracleParameter loginNameOP = new OracleParameter();
                loginNameOP.Direction = System.Data.ParameterDirection.Input;
                loginNameOP.OracleDbType = OracleDbType.NVarchar2;
                loginNameOP.Value = loginName;

                OracleParameter loginPasswordOP = new OracleParameter();
                loginPasswordOP.Direction = System.Data.ParameterDirection.Input;
                loginPasswordOP.OracleDbType = OracleDbType.NVarchar2;
                loginPasswordOP.Value = loginPassword;
               
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_USERINFOcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_USERINFOcls>.GetDataLoginDBySP(new SP_GET_USERINFOcls(), "SP_GET_USERINFO", 8, resultOutCurSor, loginNameOP, loginPasswordOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_USER_ROLE_RIGHTcls> GetUserRoleRightByUserID(decimal userID)
        {
            try
            {
                OracleParameter userIDOP = new OracleParameter();
                userIDOP.Direction = System.Data.ParameterDirection.Input;
                userIDOP.OracleDbType = OracleDbType.Decimal;
                userIDOP.Value = userID;
             
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_USER_ROLE_RIGHTcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_USER_ROLE_RIGHTcls>.GetDataLoginDBySP(new SP_GET_USER_ROLE_RIGHTcls(), "SP_GET_USER_ROLE_RIGHT", 3, resultOutCurSor, userIDOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // For Mobile App
        public List<SP_GET_USER_AUTHENTICATION> GetLogInAuthentication(string loginName, string loginPassword, decimal appId, string DEVICEID, decimal verCode = 0)
        {
            try
            {
                OracleParameter loginNameOP = new OracleParameter();
                loginNameOP.Direction = System.Data.ParameterDirection.Input;
                loginNameOP.OracleDbType = OracleDbType.NVarchar2;
                loginNameOP.Value = loginName;

                OracleParameter loginPasswordOP = new OracleParameter();
                loginPasswordOP.Direction = System.Data.ParameterDirection.Input;
                loginPasswordOP.OracleDbType = OracleDbType.NVarchar2;
                loginPasswordOP.Value = loginPassword;

                OracleParameter appId_OP = new OracleParameter();
                appId_OP.Direction = System.Data.ParameterDirection.Input;
                appId_OP.OracleDbType = OracleDbType.Decimal;
                appId_OP.Value = appId;

				OracleParameter VERSION_OP = new OracleParameter();
				VERSION_OP.Direction = System.Data.ParameterDirection.Input;
				VERSION_OP.OracleDbType = OracleDbType.Decimal;
				VERSION_OP.Value = verCode;

				OracleParameter DEVICEID_OP = new OracleParameter();
				DEVICEID_OP.Direction = System.Data.ParameterDirection.Input;
				DEVICEID_OP.OracleDbType = OracleDbType.Varchar2;
				DEVICEID_OP.Value = DEVICEID;

				OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_USER_AUTHENTICATION>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_USER_AUTHENTICATION>.GetDataLoginDBySP(new SP_GET_USER_AUTHENTICATION(), "FF_GET_USER_AUTHENTICATIONV2", 12, resultOutCurSor, loginNameOP, loginPasswordOP, appId_OP, VERSION_OP, DEVICEID_OP);
                //return (List<SP_GET_USER_AUTHENTICATION>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_USER_AUTHENTICATION>.GetDataLoginDBySP(new SP_GET_USER_AUTHENTICATION(), "SP_FF_GET_USER_AUTHENTICATION", 8, resultOutCurSor, loginNameOP, loginPasswordOP, appId_OP, VERSION_OP, DEVICEID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // For Mobile App
        public List<SP_GET_USER_AUTHENTICATION_INFO> GetLogInAuthenticationv41(string loginName, string loginPassword, decimal appId, string DEVICEID, decimal verCode = 0)
        {
            try
            {
                OracleParameter loginNameOP = new OracleParameter();
                loginNameOP.Direction = System.Data.ParameterDirection.Input;
                loginNameOP.OracleDbType = OracleDbType.NVarchar2;
                loginNameOP.Value = loginName;

                OracleParameter loginPasswordOP = new OracleParameter();
                loginPasswordOP.Direction = System.Data.ParameterDirection.Input;
                loginPasswordOP.OracleDbType = OracleDbType.NVarchar2;
                loginPasswordOP.Value = loginPassword;

                OracleParameter appId_OP = new OracleParameter();
                appId_OP.Direction = System.Data.ParameterDirection.Input;
                appId_OP.OracleDbType = OracleDbType.Decimal;
                appId_OP.Value = appId;

                OracleParameter VERSION_OP = new OracleParameter();
                VERSION_OP.Direction = System.Data.ParameterDirection.Input;
                VERSION_OP.OracleDbType = OracleDbType.Decimal;
                VERSION_OP.Value = verCode;

                OracleParameter DEVICEID_OP = new OracleParameter();
                DEVICEID_OP.Direction = System.Data.ParameterDirection.Input;
                DEVICEID_OP.OracleDbType = OracleDbType.Varchar2;
                DEVICEID_OP.Value = DEVICEID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_USER_AUTHENTICATION_INFO>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_USER_AUTHENTICATION_INFO>.GetDataLoginDBySP(new SP_GET_USER_AUTHENTICATION_INFO(), "FF_GET_USER_AUTHENTICATIONV2", 18, resultOutCurSor, loginNameOP, loginPasswordOP, appId_OP, VERSION_OP, DEVICEID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
