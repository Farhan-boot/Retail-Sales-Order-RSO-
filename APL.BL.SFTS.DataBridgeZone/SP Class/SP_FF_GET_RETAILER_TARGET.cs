using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.SP_Class
{
    [Serializable()]
    [DataContract]
    public class SP_FF_GET_RETAILER_TARGET : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public decimal TARGET_ID { get; set; }
        [DataMember]
        public decimal ITEM_ID { get; set; }
        [DataMember]
        public string ITEM_NAME { get; set; }
        [DataMember]
        public decimal PERIOD_ID { get; set; }
        [DataMember]
        public string PERIOD_NAME { get; set; }
        [DataMember]
        public string STAFF_CODE { get; set; }
        [DataMember]
        public string STAFF_TYPE { get; set; }
        [DataMember]
        public decimal TARGET { get; set; }
        [DataMember]
        public string SET_DATE { get; set; }
        [DataMember]
        public string UP_TO { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_FF_GET_RETAILER_TARGET entity = new SP_FF_GET_RETAILER_TARGET();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TARGET_ID = Convert.ToDecimal(values[0]); 

            if (values[1].GetType() != typeof(System.DBNull))
                entity.ITEM_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.ITEM_NAME = Convert.ToString(values[2]); 

            if (values[3].GetType() != typeof(System.DBNull))
                entity.PERIOD_ID = Convert.ToDecimal(values[3]); 

            if (values[4].GetType() != typeof(System.DBNull))
                entity.PERIOD_NAME = Convert.ToString(values[4]); 

            if (values[5].GetType() != typeof(System.DBNull))
                entity.STAFF_CODE = Convert.ToString(values[5]); 

            if (values[6].GetType() != typeof(System.DBNull))
                entity.STAFF_TYPE = Convert.ToString(values[6]); 

            if (values[7].GetType() != typeof(System.DBNull))
                entity.TARGET = Convert.ToDecimal(values[7]); 

            if (values[8].GetType() != typeof(System.DBNull))
                entity.SET_DATE = Convert.ToString(values[8]); 

            if (values[9].GetType() != typeof(System.DBNull))
                entity.UP_TO = Convert.ToString(values[9]); 
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
