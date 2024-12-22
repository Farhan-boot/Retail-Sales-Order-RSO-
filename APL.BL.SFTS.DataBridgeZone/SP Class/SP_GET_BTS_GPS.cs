using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_BTS_GPS : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String CODE { get; set; }

        [DataMember]
        public String NAME { get; set; }

        [DataMember]
        public Decimal LATITUDE_VALUE { get; set; }

        [DataMember]
        public Decimal LONGITUDE_VALUE { get; set; }

        [DataMember]
        public String BTS_ADDRESS { get; set; }

        [DataMember]
        public String ON_AIR_DATE { get; set; }

        [DataMember]
        public String SUB_BASE { get; set; }

        [DataMember]
        public Decimal AVERAGE_REVENUE { get; set; }

        [DataMember]
        public String GA { get; set; }

        [DataMember]
        public Decimal RECHARGE { get; set; }

        [DataMember]
        public String TOP_PERFORMING_RETAILER { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_BTS_GPS entity = new SP_GET_BTS_GPS();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.LATITUDE_VALUE = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.LONGITUDE_VALUE = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.BTS_ADDRESS = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.ON_AIR_DATE = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.SUB_BASE = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.AVERAGE_REVENUE = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.GA = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.RECHARGE = Convert.ToDecimal(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.TOP_PERFORMING_RETAILER = Convert.ToString(values[11]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
