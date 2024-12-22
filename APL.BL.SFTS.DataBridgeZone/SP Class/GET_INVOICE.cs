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
    public class GET_INVOICE : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public DateTime TRANSCATION_DATE { get; set; }

        [DataMember]
        public Decimal INVOICENO { get; set; }       

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

        [DataMember]
        public Decimal NEW_AMOUNT { get; set; }

        [DataMember]
        public Decimal TOTAL_AMOUNT { get; set; }


        public object MapToEntity(object[] values)
        {
            GET_INVOICE entity = new GET_INVOICE();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TRANSCATION_DATE = Convert.ToDateTime(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.INVOICENO = Convert.ToDecimal(values[1]);

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

            if (values[7] != null && values[7].GetType() != typeof(System.DBNull))
                entity.NEW_AMOUNT = Convert.ToDecimal(values[7]);

            if (values[8] != null && values[8].GetType() != typeof(System.DBNull))
                entity.TOTAL_AMOUNT = Convert.ToDecimal(values[8]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
