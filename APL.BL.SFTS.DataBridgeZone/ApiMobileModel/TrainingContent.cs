using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class TrainingContent
    {
        public int TrainingId { get; set; }
        public string ContentName { get; set; }
        public string TrainingName { get; set; }
        public string UploadedDate { get; set; }
        public string OtherLink { get; set; }
        public string UploadedFileLink { get; set; }
        public int IsActive { get; set; }
        public int ActionFlag { get; set; }
    }
}
