using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_GPS : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public String RETAILER_ADDRESS { get; set; }

        [DataMember]
        public String SERVICE_TYPE { get; set; }

        [DataMember]
        public String PICTURE { get; set; }

        [DataMember]
        public Decimal AVERAGE_SALES { get; set; }

        [DataMember]
        public Decimal LATITUDE_VALUE { get; set; }

        [DataMember]
        public Decimal LONGITUDE_VALUE { get; set; }
      
        [DataMember]
        public String CHECKIN_TIME { get; set; }
        [DataMember]
        public String CHECKOUT_FEEDBACK { get; set; }
        [DataMember]
        public String TOTAL_SALES_AMOUNT { get; set; }
     
 


        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_GPS entity = new SP_GET_RETAILER_GPS();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_ADDRESS = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.SERVICE_TYPE = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.PICTURE = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.AVERAGE_SALES = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.LATITUDE_VALUE = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.LONGITUDE_VALUE = Convert.ToDecimal(values[9]);



            if (values[10] != null)
                entity.CHECKIN_TIME = Convert.ToString(values[10]);
            if (values[11] != null)
                entity.CHECKOUT_FEEDBACK = Convert.ToString(values[11]);
            if (values[12] != null)
                entity.TOTAL_SALES_AMOUNT = Convert.ToString(values[12]);

 
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
