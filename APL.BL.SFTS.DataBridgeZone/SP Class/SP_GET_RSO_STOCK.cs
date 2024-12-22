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
    public class SP_GET_RSO_STOCK : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public Decimal STOCK_ID { get; set; }

        [DataMember]
        public string TRANSACTION_DATE { get; set; }

        [DataMember]
        public string PRODUCT_NAME { get; set; }

        [DataMember]
        public Decimal PRODUCT_PRICE { get; set; }

        [DataMember]
        public Decimal PRODUCT_QUANTITY { get; set; }

        [DataMember]
        public Decimal RETURN_STATUS { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RSO_STOCK entity = new SP_GET_RSO_STOCK();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.STOCK_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TRANSACTION_DATE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.PRODUCT_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PRODUCT_PRICE = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.PRODUCT_QUANTITY = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.RETURN_STATUS = Convert.ToDecimal(values[5]);
            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
