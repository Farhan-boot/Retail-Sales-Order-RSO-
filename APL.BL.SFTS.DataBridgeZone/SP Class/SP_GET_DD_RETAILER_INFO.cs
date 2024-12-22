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
    public  class SP_GET_DD_RETAILER_INFO : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public decimal RETAILER_ID { get; set; }

        [DataMember]
        public string RETAILER_CODE { get; set; }
        [DataMember]
        public string RETAILER_NAME { get; set; }
        [DataMember]
        public decimal DISTRIBUTOR_ID { get; set; }
        [DataMember]
        public string DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public string DISTRIBUTOR_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_DD_RETAILER_INFO entity = new SP_GET_DD_RETAILER_INFO();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[2]);


            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[4]);

          
            if (values[5].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[5]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
