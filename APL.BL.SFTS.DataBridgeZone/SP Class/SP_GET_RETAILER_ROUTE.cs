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
    public class SP_GET_RETAILER_ROUTE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal PLAN_ID { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public String RETAIELR_CODE { get; set; }

        [DataMember]
        public String RETAIELR_NAME { get; set; }

        [DataMember]
        public String RETAIELR_ADDRESS { get; set; }

        [DataMember]
        public String STATUS_ID { get; set; }

        [DataMember]
        public String STATUS_NAME { get; set; }

        [DataMember]
        public String RETAILER_TRNS_MOBILE_NO { get; set; }

        [DataMember]
        public String RETAILER_TOPUP_NUMBER { get; set; }

        [DataMember]
        public String ROUTE_CODE { get; set; }

        [DataMember]
        public String ROUTE_NAME { get; set; }
          
        [DataMember]
        public String SSO { get; set; }
         
        [DataMember]
        public String LSO { get; set; }




        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_ROUTE entity = new SP_GET_RETAILER_ROUTE();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.PLAN_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAIELR_CODE = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAIELR_NAME = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAIELR_ADDRESS = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.STATUS_ID = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.STATUS_NAME = Convert.ToString(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.RETAILER_TRNS_MOBILE_NO = Convert.ToString(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.RETAILER_TOPUP_NUMBER = Convert.ToString(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.ROUTE_CODE = Convert.ToString(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.ROUTE_NAME = Convert.ToString(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.SSO = Convert.ToString(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.LSO = Convert.ToString(values[12]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
