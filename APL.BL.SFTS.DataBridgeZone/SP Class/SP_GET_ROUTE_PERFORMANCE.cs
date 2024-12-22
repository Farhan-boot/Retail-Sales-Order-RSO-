using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_ROUTE_PERFORMANCE : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String KPI_CODE { get; set; }

        [DataMember]
        public Decimal POSITION { get; set; }

        [DataMember]
        public Decimal SCOPE { get; set; }

        [DataMember]
        public String MONTH_CODE { get; set; }

        [DataMember]
        public String MTD_CODE { get; set; }

        [DataMember]
        public String PREV_MONTH_CODE { get; set; }

        [DataMember]
        public String ROUTE_CODE { get; set; }

        [DataMember]
        public String ROUTE_NAME { get; set; }

        [DataMember]
        public String CUR_MONTH_ACHIEVEMENT { get; set; }

        [DataMember]
        public String PREV_MONTH_ACHIEVEMENT { get; set; }
      

        public object MapToEntity(object[] values)
        {
            SP_GET_ROUTE_PERFORMANCE entity = new SP_GET_ROUTE_PERFORMANCE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.KPI_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.POSITION = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.SCOPE = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.MONTH_CODE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.MTD_CODE = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.PREV_MONTH_CODE = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.ROUTE_CODE = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.ROUTE_NAME = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.CUR_MONTH_ACHIEVEMENT = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.PREV_MONTH_ACHIEVEMENT = Convert.ToString(values[9]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
