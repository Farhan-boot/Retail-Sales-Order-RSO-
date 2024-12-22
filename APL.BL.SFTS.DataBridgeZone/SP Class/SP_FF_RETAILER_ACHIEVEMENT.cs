using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.SP_Class
{
    [Serializable()]
    [DataContract]
    public class SP_FF_RETAILER_ACHIEVEMENT : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String RETAILER { get; set; }

        [DataMember]
        public String PHONE { get; set; }

        [DataMember]
        public String PRODUCT { get; set; }

        [DataMember]
        public Decimal QTY { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_FF_RETAILER_ACHIEVEMENT entity = new SP_FF_RETAILER_ACHIEVEMENT();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.PHONE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.PRODUCT = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.QTY = Convert.ToDecimal(values[3]);
            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
