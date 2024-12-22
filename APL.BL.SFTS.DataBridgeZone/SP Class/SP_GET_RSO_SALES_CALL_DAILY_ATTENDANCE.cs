using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String DATE { get; set; }

        [DataMember]
        public String ROUTE { get; set; }

        [DataMember]
        public String RSO { get; set; }

        [DataMember]
        public String VISIT_TARGET { get; set; }
        
        [DataMember]
        public String VISITED { get; set; }

        [DataMember]
        public String SUCCESSFUL_SALES_CALL { get; set; }

        [DataMember]
        public String SIM_RETAIELR_TARGET { get; set; }

        [DataMember]
        public String SIM_RETAILER_VISITED { get; set; }

        [DataMember]
        public String SUCCESSFUL_SIM_SALES_CALL { get; set; }

        [DataMember]
        public String SIM_COUNT { get; set; }

        [DataMember]
        public String TOPUP_RETAILER_TARGET { get; set; }

        [DataMember]
        public String TOPUP_RETAILER_VISITED { get; set; }

        [DataMember]
        public String SUCCESSFUL_TOPUP_SALES_CALL { get; set; }

        [DataMember]
        public String TOPUP_AMOUNT { get; set; }

        [DataMember]
        public String SC_RETAILER_TARGET { get; set; }

        [DataMember]
        public String SC_RETAILER_VISITED { get; set; }

        [DataMember]
        public String SUCCESSFUL_SC_SALES_CALL { get; set; }

        [DataMember]
        public String SC_VALUE { get; set; }

        [DataMember]
        public String DEVICE_RETAILER_TARGET { get; set; }

        [DataMember]
        public String DEVICE_RETAILER_VISITED { get; set; }

        [DataMember]
        public String SUCCESSFUL_DEVICE_SALES_CALL { get; set; }

        [DataMember]
        public String DEVICE_COUNT { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE entity = new SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DATE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ROUTE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSO = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.VISIT_TARGET = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.VISITED = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.SUCCESSFUL_SALES_CALL = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.SIM_RETAIELR_TARGET = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.SIM_RETAILER_VISITED = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.SUCCESSFUL_SIM_SALES_CALL = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.SIM_COUNT = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.TOPUP_RETAILER_TARGET = Convert.ToString(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.TOPUP_RETAILER_VISITED = Convert.ToString(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.SUCCESSFUL_TOPUP_SALES_CALL = Convert.ToString(values[12]);
            if (values[13].GetType() != typeof(System.DBNull))
                entity.TOPUP_AMOUNT = Convert.ToString(values[13]);
            if (values[14].GetType() != typeof(System.DBNull))
                entity.SC_RETAILER_TARGET = Convert.ToString(values[14]);
            if (values[15].GetType() != typeof(System.DBNull))
                entity.SC_RETAILER_VISITED = Convert.ToString(values[15]);
            if (values[16].GetType() != typeof(System.DBNull))
                entity.SUCCESSFUL_SC_SALES_CALL = Convert.ToString(values[16]);
            if (values[17].GetType() != typeof(System.DBNull))
                entity.SC_VALUE = Convert.ToString(values[17]);
            if (values[18].GetType() != typeof(System.DBNull))
                entity.DEVICE_RETAILER_TARGET = Convert.ToString(values[18]);
            if (values[19].GetType() != typeof(System.DBNull))
                entity.DEVICE_RETAILER_VISITED = Convert.ToString(values[19]);
            if (values[20].GetType() != typeof(System.DBNull))
                entity.SUCCESSFUL_DEVICE_SALES_CALL = Convert.ToString(values[20]);
            if (values[21].GetType() != typeof(System.DBNull))
                entity.DEVICE_COUNT = Convert.ToString(values[21]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
