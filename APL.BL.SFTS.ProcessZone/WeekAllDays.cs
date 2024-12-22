using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
   public class WeekInfo
    {
       public WeekInfo()
        {
            DayName = string.Empty;
            DayValue = string.Empty;
            DayDate = string.Empty; 
        }
        public string DayName { get; set; }
        public string DayValue { get; set; }
        public string DayDate { get; set; }        
    }
}
