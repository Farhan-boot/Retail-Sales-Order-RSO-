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
    public class GET_RETAILER_SIMSTOCK : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String PRODUCT_CODE { get; set; }

        [DataMember]
        public String PRODUCT_CATEGORY { get; set; }

        [DataMember]
        public Decimal CURRENT_STOCK { get; set; }

        [DataMember]
        public Decimal AVERAGE_SALE { get; set; }
       

        public object MapToEntity(object[] values)
        {
            GET_RETAILER_SIMSTOCK entity = new GET_RETAILER_SIMSTOCK();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.PRODUCT_CODE = Convert.ToString(values[0]);
            if (values[0].GetType() != typeof(System.DBNull))
                entity.PRODUCT_CATEGORY = Convert.ToString(values[1]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CURRENT_STOCK = Convert.ToDecimal(values[2]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.AVERAGE_SALE = Convert.ToDecimal(values[3]);
          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
