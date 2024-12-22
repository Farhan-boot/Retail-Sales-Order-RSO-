using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class ServiceStringXML
    {
        public ServiceStringXML()
        {
            ObjectXML = string.Empty;
            IssueArisePlace = string.Empty;
            OperationMessage = string.Empty;
            StackTrace = string.Empty;
        }
        public String ObjectXML { get; set; }
        public String IssueArisePlace { get; set; }
        public String OperationMessage { get; set; }
        public String StackTrace { get; set; }
    }
}
