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
    public class SP_GET_RSO_WISE_ROT_A_RETcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public decimal RETAILER_ID { get; set; }
        [DataMember]
        public String RETAILER_CODE { get; set; }
        [DataMember]
        public decimal DISTRIBUTOR_ID { get; set; }
        [DataMember]
        public String RETAILER_NAME { get; set; }
        [DataMember]
        public String RETAILER_ADDRESS { get; set; } //

        [DataMember]
        public decimal ROUTE_ID { get; set; }

        [DataMember]
        public String ROUTE_NAME { get; set; }

        [DataMember]
        public decimal RETAILER_TYPE { get; set; }

        [DataMember]
        public DateTime RSO_ROT_ASSIGN_DATETIME { get; set; }
             
        public object MapToEntity(object[] values)
        {
            SP_GET_RSO_WISE_ROT_A_RETcls entity = new SP_GET_RSO_WISE_ROT_A_RETcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_ADDRESS = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.ROUTE_ID = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.ROUTE_NAME = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.RETAILER_TYPE = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.RSO_ROT_ASSIGN_DATETIME = Convert.ToDateTime(values[8]);            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
