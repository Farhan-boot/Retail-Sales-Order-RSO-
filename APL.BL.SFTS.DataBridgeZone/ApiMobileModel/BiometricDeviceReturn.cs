using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class BiometricDeviceReturn
    {
        public DateTime ReturnDate { get; set; }
        public string DeviceId { get; set; }
        public string Remarks { get; set; }
        public decimal RetailerId { get; set; }
        public decimal RsoId { get; set; }

    }
}
