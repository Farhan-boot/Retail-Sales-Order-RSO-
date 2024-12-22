using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class UserInfoPZ
    {
        public const string _collectionNodePart = "Coll";
        public UserInfoPZ()
        { }

        /// <summary>
        /// Get Server date , time and date time information.
        /// </summary>
        /// <returns></returns>
        public List<SP_GET_SERVER_INFOcls> GetServerInfo()
        {
            try
            {
                return new UserInfoDZ().GetServerInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Server date , time and date time information for web service.
        /// </summary>
        /// <returns>XML Format string</returns>
        public ServiceStringXML GetServerInfoXML()
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_GET_SERVER_INFOcls().GetType().Name;
            try
            {
                List<SP_GET_SERVER_INFOcls> rosColl = new UserInfoDZ().GetServerInfo();
                if (rosColl != null && rosColl.Count == 1)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_SERVER_INFOcls>(rosColl[0]);
                }
                else if (rosColl == null || rosColl.Count == 0)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }
        /// <summary>
        /// This methods is calling to provide particular login user info.
        /// </summary>      
        /// <returns>User info object</returns>
        public List<SP_GET_USERINFOcls> GetLoginUserInfo(string loginName, string loginPassword)
        {
            try
            {
                return new UserInfoDZ().GetLoginUserInfo(loginName, loginPassword);
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
                return new UserInfoDZ().GetUserRoleRightByUserID(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //FOR APP API 
        public List<SP_GET_USER_AUTHENTICATION> GetLogInAuthentication(string loginName, string loginPassword, decimal appId, string DEVICEID, decimal verCode = 0)
        {
            try
            {
                return new UserInfoDZ().GetLogInAuthentication(loginName, loginPassword, appId, DEVICEID, verCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //FOR APP API 
        public List<SP_GET_USER_AUTHENTICATION_INFO> GetLogInAuthenticationv41(string loginName, string loginPassword, decimal appId, string DEVICEID, decimal verCode = 0)
        {
            try
            {
                return new UserInfoDZ().GetLogInAuthenticationv41(loginName, loginPassword, appId, DEVICEID, verCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
