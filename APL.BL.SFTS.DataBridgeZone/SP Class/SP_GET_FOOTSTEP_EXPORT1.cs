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
    public class SP_GET_FOOTSTEP_EXPORT1 : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public String RSO_CODE { get; set; }
        [DataMember]
        public String DATE_STR { get; set; }
        [DataMember]
        public String LOGIN_TIME { get; set; }
        [DataMember]
        public String LOGOUT_TIME { get; set; }
        [DataMember]
        public String TIME_ELAPSED { get; set; }
        [DataMember]
        public String LAND_MARK { get; set; }
        [DataMember]
        public String RETAILER_CODE { get; set; }
        [DataMember]
        public String RETAILER_LAT_LONG { get; set; }
        [DataMember]
        public String SALES_LAT_LONG { get; set; }
        [DataMember]
        public String DISTANCE { get; set; }
        [DataMember]
        public String CHECKOUT_FEEDBACK { get; set; }
        [DataMember]
        public String TOTAL_SALES_AMOUNT { get; set; }
        [DataMember]
        public String BTS_CODE { get; set; }
      
        [DataMember]
        public String BTS_ADDRESS { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_FOOTSTEP_EXPORT1 entity = new SP_GET_FOOTSTEP_EXPORT1();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.DATE_STR = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.LOGIN_TIME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.LOGOUT_TIME = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.TIME_ELAPSED = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.LAND_MARK = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.RETAILER_LAT_LONG = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.SALES_LAT_LONG = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.DISTANCE = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.CHECKOUT_FEEDBACK = Convert.ToString(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.TOTAL_SALES_AMOUNT = Convert.ToString(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.BTS_CODE = Convert.ToString(values[12]);
          
            if (values[13].GetType() != typeof(System.DBNull))
                entity.BTS_ADDRESS = Convert.ToString(values[13]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
