using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{   
    public class GenerateTokenPZ
    {
         public GenerateTokenPZ() { }


         public decimal InsertToken(string userName, string token, decimal appId, string version, string deviceID, decimal LAN)
         {
            Decimal result = 0;
            try
             {
                result = new GenerateTokenDZ().InsertToken(userName, token, appId, version, deviceID, LAN);             
             }
             catch (Exception ex)
             {
                throw ex;
             }

             return result;
         }

        public decimal TokenExpiration(decimal userId, string token)
        {
            Decimal result = 0;
            try
            {
                result = new GenerateTokenDZ().TokenExpiration(userId, token);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public decimal WebTokenExpiration(string userName, string token)
        {
            Decimal result = 0;
            Decimal appId = 1122;
            try
            {
                result = new GenerateTokenDZ().WebTokenExpiration(userName, token, appId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public decimal ValidateToken(long userId, string token)
        {
            Decimal result = 0;
            try
            {
                result = new GenerateTokenDZ().ValidateToken(userId, token);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public bool ValidateWebToken(string token, string userAgent)
        {
            bool result = false;
            decimal validationResult = 0;
            decimal? appId = null;
            string userName = null;
            string authorizedToken = null;

            try
            {
                string[] parts = token.Split(new char[] { ':' });
                if (parts.Length == 3)
                {
                    appId = Convert.ToDecimal(parts[0]);
                    userName = parts[1];
                    authorizedToken = parts[2];
                };

                validationResult = new GenerateTokenDZ().ValidateWebToken(userName, authorizedToken, appId);
                result = validationResult == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    }
}
