using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_SALES : ObjectMakerFromOracleSP.ISpClassEntity
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
        public String SIM_SALES_PREPAID { get; set; }

        [DataMember]
        public String SIM_SALES_POSTPAID { get; set; }

        [DataMember]
        public String SIM_SALES_SWAP { get; set; }

        [DataMember]
        public String SIM_SALES_DUPLICATE_DIAL { get; set; }

        [DataMember]
        public String DEVICE_SALES { get; set; }

        [DataMember]
        public String ITOPUP_TERRITORY { get; set; }

        [DataMember]
        public String SC_SALES { get; set; }

        [DataMember]
        public String SR_NO { get; set; }

        [DataMember]
        public String SUPERV_NAME { get; set; }

        [DataMember]
        public String TOS { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_SALES entity = new SP_GET_RETAILER_SALES();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DATE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.SIM_SALES_PREPAID = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.SIM_SALES_POSTPAID = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.SIM_SALES_SWAP = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.SIM_SALES_DUPLICATE_DIAL = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.DEVICE_SALES = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.ITOPUP_TERRITORY = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.SC_SALES = Convert.ToString(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.SR_NO = Convert.ToString(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.SUPERV_NAME = Convert.ToString(values[12]);
            if (values[13].GetType() != typeof(System.DBNull))
                entity.TOS = Convert.ToString(values[13]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
