using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RSO_DETAIL : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String RSO_NAME { get; set; }

        [DataMember]
        public String SR_NUMBER { get; set; }

        [DataMember]
        public String RSO_CONTACT { get; set; }
        
        [DataMember]
        public String HANDSET_NUMBER { get; set; }

        [DataMember]
        public String ONBOUND_DATE { get; set; }

        [DataMember]
        public String CREATED_BY { get; set; }

        [DataMember]
        public String ACTIVE_STATUS { get; set; }

        [DataMember]
        public String LAST_MODIFIED_BY { get; set; }

        [DataMember]
        public String LAST_MODIFIED_DATE { get; set; }

        [DataMember]
        public String MODIFIED_FIELDS { get; set; }

        [DataMember]
        public String DEACTIVE_DATE { get; set; }

        [DataMember]
        public String ROUTE_1 { get; set; }

        [DataMember]
        public String ROUTE_2 { get; set; }

        [DataMember]
        public String ROUTE_3 { get; set; }

        [DataMember]
        public String ROUTE_4 { get; set; }

        [DataMember]
        public String ROUTE_5 { get; set; }

        [DataMember]
        public String ROUTE_6 { get; set; }

        [DataMember]
        public String SIM_RETAILER_COUNT { get; set; }

        [DataMember]
        public String TOPUP_RETAILER_COUNT { get; set; }

        [DataMember]
        public String SC_RETAILER_COUNT { get; set; }

        [DataMember]
        public String DEVICE_RETAIELR_COUNT { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RSO_DETAIL entity = new SP_GET_RSO_DETAIL();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.SR_NUMBER = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RSO_CONTACT = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.HANDSET_NUMBER = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.ONBOUND_DATE = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.CREATED_BY = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.ACTIVE_STATUS = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.LAST_MODIFIED_BY = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.LAST_MODIFIED_DATE = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.MODIFIED_FIELDS = Convert.ToString(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.DEACTIVE_DATE = Convert.ToString(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.ROUTE_1 = Convert.ToString(values[12]);
            if (values[13].GetType() != typeof(System.DBNull))
                entity.ROUTE_2 = Convert.ToString(values[13]);
            if (values[14].GetType() != typeof(System.DBNull))
                entity.ROUTE_3 = Convert.ToString(values[14]);
            if (values[15].GetType() != typeof(System.DBNull))
                entity.ROUTE_4 = Convert.ToString(values[15]);
            if (values[16].GetType() != typeof(System.DBNull))
                entity.ROUTE_5 = Convert.ToString(values[16]);
            if (values[17].GetType() != typeof(System.DBNull))
                entity.ROUTE_6 = Convert.ToString(values[17]);
            if (values[18].GetType() != typeof(System.DBNull))
                entity.SIM_RETAILER_COUNT = Convert.ToString(values[18]);
            if (values[19].GetType() != typeof(System.DBNull))
                entity.TOPUP_RETAILER_COUNT = Convert.ToString(values[19]);
            if (values[20].GetType() != typeof(System.DBNull))
                entity.SC_RETAILER_COUNT = Convert.ToString(values[20]);
            if (values[21].GetType() != typeof(System.DBNull))
                entity.DEVICE_RETAIELR_COUNT = Convert.ToString(values[21]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
