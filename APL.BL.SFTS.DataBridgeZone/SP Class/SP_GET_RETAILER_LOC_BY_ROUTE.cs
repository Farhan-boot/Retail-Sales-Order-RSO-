using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_LOC_BY_ROUTE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public Decimal LOC_LATITUDE { get; set; }

        [DataMember]
        public Decimal LOC_LONGITUDE { get; set; }

     
        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_LOC_BY_ROUTE entity = new SP_GET_RETAILER_LOC_BY_ROUTE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.LOC_LATITUDE = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.LOC_LONGITUDE = Convert.ToDecimal(values[3]);
   
               
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
