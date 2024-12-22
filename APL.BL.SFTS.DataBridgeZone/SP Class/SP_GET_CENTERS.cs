using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_CENTERS : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public Decimal CENTER_ID { get; set; }

        [DataMember]
        public String CENTER_CODE { get; set; }

        [DataMember]
        public String CENTER_NAME { get; set; }

        [DataMember]
        public String ADDRESS { get; set; }

        [DataMember]
        public Decimal LAT_VALUE { get; set; }

        [DataMember]
        public Decimal LONG_VALUE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_CENTERS entity = new SP_GET_CENTERS();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.CENTER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CENTER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.CENTER_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.ADDRESS = Convert.ToString (values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.LAT_VALUE = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.LONG_VALUE = Convert.ToDecimal(values[5]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
