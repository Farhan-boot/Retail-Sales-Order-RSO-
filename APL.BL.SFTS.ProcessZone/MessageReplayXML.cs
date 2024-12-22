using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    
    public class MessageReplyXML
    {
        public static string Confirmation(string spName, bool trueOrFalse, string replayMessage)
        {
            string xmlString = string.Empty;
            xmlString = "<" + spName + "><IsSuccess>" + trueOrFalse.ToString() + "</IsSuccess><Message>" + replayMessage + "</Message></" + spName + ">";
            return xmlString;
        }

        public static string Confirmation(string spName, decimal requestID, string replayMessage)
        {
            string xmlString = string.Empty;
            xmlString = "<" + spName + "><IsSuccess>" + requestID.ToString() + "</IsSuccess><Message>" + replayMessage + "</Message></" + spName + ">";
            return xmlString;
        } 
    }
    public class MessageGodown
    {
        /// <summary>
        /// For new data insert
        /// </summary>
        public const string SaveNotification = "Information is saved successfully.";

        public const string UpdateNotification = "Information is updated successfully.";

        /// <summary>
        /// For new data fail to insert 
        /// </summary>
        public const string FailSaveNotification = "Fail to save information. Please try again";

        /// <summary>
        /// For processing data
        /// </summary>
        public const string SubmittNotification = "Information is submitted successfully.";


        public const string FailTranCheckNotification = "Fail transaction product checking for server busy. Please try again";
        /// <summary>
        /// For fail to process data
        /// </summary>
        public const string FailTranNotification = "Fail transaction information for server busy. Please try again";

        public const string TranNotification = "Transaction is completed successfully.";
        /// <summary>
        /// For fail to process data
        /// </summary>
        public const string FailSubmittNotification = "Fail to submitt information. Please try again";

        public const string DataNotFound = "Information is not available.";

        public const string RequestGPSPending = "Your request is waiting for approve. Please contact to your's higher authority.";

        public const string InvalideRSOCode = "RSO code is not found.";
        public const string DuplicateRSOCode = "Duplicate RSO code.";
        public const string InvalideRetail = "Retailer is not found.";
        public const string InvalideRetailCode = "Retailer code is not found.";
        public const string DuplicateRetailCode = "Duplicate Retail Code.";
        public const string DuplicateSimNo = "Duplicate SIM No, it is already received.";

        public const string NoInternet = "No internet connection available.";
        public const string InvalideUser = "Your user name or password is not valid.";
        public const string InvalideMobile = "Please enter mobile number correctly.";
        public const string InvalidSecurityKey = "You have entered invalid security key.";
        public const string AccountLocked = "Your account has been locked.";
        public const string ServerError = "Service is currently not available. Please try again later.";
        public const string RegisterSubmitted = "Registration request has been submitted.";

        //public const string UserName = "Admin";
        //public const string Password = "Admin";

        public static  string UserName = "Admin";
        public static string Password = "Admin";
        public static char IsInternalUser = 'N';
    }
}
