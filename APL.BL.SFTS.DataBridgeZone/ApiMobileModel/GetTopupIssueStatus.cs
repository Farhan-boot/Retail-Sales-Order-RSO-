using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace APL.BL.SFTS.Models.ApiMobile
{ 
   public class GetTopupIssueStatus
    {
       public decimal issueStatus { get; set; }
       public string statusMsgEng { get; set; }
       public string statusMsgBan { get; set; }
    }
}
