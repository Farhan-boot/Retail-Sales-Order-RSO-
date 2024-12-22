using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class GetMenu
    {
       public SP_GET_MENU mainMenu { get; set; }
       public List<SP_GET_MENU> subMenuList { get; set; }
    }
}
