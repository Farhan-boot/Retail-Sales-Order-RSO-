using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{   
    public class GetNewIdPZ
    {
         public GetNewIdPZ() { }


         public decimal GetNewId(string sequenceName)
         {
            Decimal newId = 0;
            try
             {
                newId = new GetNewIdDZ().GetNewId(sequenceName);
             
             }
             catch (Exception ex)
             {
                throw ex;
             }

             return newId;
         }
    }
}
