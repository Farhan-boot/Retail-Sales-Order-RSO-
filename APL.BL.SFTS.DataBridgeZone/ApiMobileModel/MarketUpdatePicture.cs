using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class MarketUpdatePicture
    {
        public decimal Id { get; set; }
        public decimal MarketUpdateId { get; set; }
        public decimal PictureSlNo { get; set; }
        public byte[] Picture { get; set; }
    }
}
