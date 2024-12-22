using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_VISIT_PLAN : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal PLAN_ID { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }    
                   
        [DataMember]
        public String RETAILER_CODE { get; set; }  
           
        [DataMember]
        public String RETAILER_NAME { get; set; } 
             
        [DataMember]
        public String ADDRESS{ get; set; }

        [DataMember]
        public Decimal STATUS_ID { get; set; }

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

        [DataMember]
        public String RETAILER_TYPE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_VISIT_PLAN entity = new SP_GET_RETAILER_VISIT_PLAN();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.PLAN_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.ADDRESS = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.STATUS_ID = Convert.ToDecimal(values[5]);
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
            if (values[13].GetType() != typeof(System.DBNull))
                entity.RETAILER_TYPE = Convert.ToString(values[13]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
