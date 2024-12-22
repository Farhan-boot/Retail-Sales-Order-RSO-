using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_STOCK : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String DATE { get; set; }
        
        [DataMember]
        public String SIM_CHANNEL_FILL_PREPAID { get; set; }

        [DataMember]
        public String SIM_CHANNEL_FILL_POSTPAID { get; set; }

        [DataMember]
        public String SIM_CHANNEL_FILL_SWAP { get; set; }

        [DataMember]
        public String SIM_CHANNEL_FILL_DUPLICATE_DIAL { get; set; }

        [DataMember]
        public String DEVICE_STOCK { get; set; }

        [DataMember]
        public String ITOPUP_BALANCE { get; set; }

        [DataMember]
        public String SC_NON_CONSUMED { get; set; }

        
        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_STOCK entity = new SP_GET_RETAILER_STOCK();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DATE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.SIM_CHANNEL_FILL_PREPAID = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.SIM_CHANNEL_FILL_POSTPAID = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.SIM_CHANNEL_FILL_SWAP = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.SIM_CHANNEL_FILL_DUPLICATE_DIAL = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.DEVICE_STOCK = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.ITOPUP_BALANCE = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.SC_NON_CONSUMED = Convert.ToString(values[10]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
