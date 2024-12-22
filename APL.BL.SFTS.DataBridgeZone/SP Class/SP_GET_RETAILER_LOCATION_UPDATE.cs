using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_LOCATION_UPDATE : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String PRESENT_RSO_CODE { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_LATITUDE { get; set; }

        [DataMember]
        public String RETAILER_LONGITUDE { get; set; }
        
        [DataMember]
        public String CREATE_DATE { get; set; }

        [DataMember]
        public String CREATE_RSO_CODE { get; set; }

        [DataMember]
        public String UPDATE_DATE { get; set; }

        [DataMember]
        public String UPDATE_RSO_CODE { get; set; }

        [DataMember]
        public String LAST_VERIFIED_BY { get; set; }


        
        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_LOCATION_UPDATE entity = new SP_GET_RETAILER_LOCATION_UPDATE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.PRESENT_RSO_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILER_LATITUDE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_LONGITUDE = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.CREATE_RSO_CODE = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.UPDATE_RSO_CODE = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.LAST_VERIFIED_BY = Convert.ToString(values[9]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
