using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RSO_ATTENDANCE_AND_PATH : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String DATE { get; set; }

        [DataMember]
        public String ROUTE_CODE_NAME { get; set; }

        [DataMember]
        public String RSO_CODE_NAME { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }
        
        [DataMember]
        public String RETAILER_LOCATION { get; set; }

        [DataMember]
        public String SALES_CALL_LOCATION { get; set; }

        [DataMember]
        public String MATCH { get; set; }

        [DataMember]
        public String DEVIATION { get; set; }

        [DataMember]
        public String SALES_CALL_LOGIN_TIME { get; set; }

        [DataMember]
        public String SALES_CALL_LOGOUT_TIME { get; set; }

        [DataMember]
        public String DMS_ENTRY_BY_OPERATOR { get; set; }
        [DataMember]
        public decimal TIME_ELAPSED { get; set; }
        [DataMember]
        public String RSO_CODE { get; set; }
        [DataMember]
        public String SR_NO { get; set; }
        [DataMember]
        public String LAND_MARK { get; set; }
        [DataMember]
        public String RETAILER_LAT_LONG { get; set; }
        [DataMember]
        public String DISTANCE { get; set; }
        [DataMember]
        public String MACHED { get; set; }
        [DataMember]
        public String CHECKOUT_FEEDBACK { get; set; }
        [DataMember]
        public String CLOSE_BTS_CODE { get; set; }
        [DataMember]
        public String TOTAL_SALES_AMOUNT { get; set; }
        [DataMember]
        public String CHECKOUT_REMARKS { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RSO_ATTENDANCE_AND_PATH entity = new SP_GET_RSO_ATTENDANCE_AND_PATH();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DATE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ROUTE_CODE_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSO_CODE_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_LOCATION = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.SALES_CALL_LOCATION = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.MATCH = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.DEVIATION = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.SALES_CALL_LOGIN_TIME = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.SALES_CALL_LOGOUT_TIME = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.TIME_ELAPSED = Convert.ToDecimal(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.SR_NO = Convert.ToString(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.LAND_MARK = Convert.ToString(values[12]);
            if (values[13].GetType() != typeof(System.DBNull))
                entity.RETAILER_LAT_LONG = Convert.ToString(values[13]);
            if (values[14].GetType() != typeof(System.DBNull))
                entity.DISTANCE = Convert.ToString(values[14]);
            if (values[15].GetType() != typeof(System.DBNull))
                entity.CHECKOUT_FEEDBACK = Convert.ToString(values[15]);
            if (values[16].GetType() != typeof(System.DBNull))
                entity.CLOSE_BTS_CODE = Convert.ToString(values[16]);
            if (values[17].GetType() != typeof(System.DBNull))
                entity.TOTAL_SALES_AMOUNT = Convert.ToString(values[17]);
            if (values[18].GetType() != typeof(System.DBNull))
                entity.CHECKOUT_REMARKS = Convert.ToString(values[18]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
