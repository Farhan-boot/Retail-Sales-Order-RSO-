using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class RETAILER_LAST_LIFTINGcls : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public DateTime TRANSCATION_DATE { get; set; }

        [DataMember]
        public Decimal INVOICENO { get; set; }       

        //[DataMember]
        //public Decimal DISTRIBUTOR_ID { get; set; }

        //[DataMember]
        //public Decimal RSOID { get; set; }

        //[DataMember]
        //public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public Decimal PRODUCT_ID { get; set; }

        [DataMember]
        public String PRODUCT_NAME { get; set; }

        [DataMember]
        public Decimal TRANSACTION_AMOUNT { get; set; }

        [DataMember]
        public Decimal UNITPRICE { get; set; }

        [DataMember]
        public Decimal TOTALPRICE { get; set; }

        public object MapToEntity(object[] values)
        {
            RETAILER_LAST_LIFTINGcls entity = new RETAILER_LAST_LIFTINGcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TRANSCATION_DATE = Convert.ToDateTime(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.INVOICENO = Convert.ToDecimal(values[1]);

            //if (values[2].GetType() != typeof(System.DBNull))
            //    entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[2]);
            //if (values[3].GetType() != typeof(System.DBNull))
            //    entity.RSOID = Convert.ToDecimal(values[3]);
            //if (values[4].GetType() != typeof(System.DBNull))
            //    entity.RETAILER_ID = Convert.ToDecimal(values[4]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.PRODUCT_ID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.PRODUCT_NAME = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.TRANSACTION_AMOUNT = Convert.ToDecimal(values[4]);

            if (values[5] != null && values[5].GetType() != typeof(System.DBNull))
                entity.UNITPRICE = Convert.ToDecimal(values[5]);

            if (values[6] != null && values[6].GetType() != typeof(System.DBNull))
                entity.TOTALPRICE = Convert.ToDecimal(values[6]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
