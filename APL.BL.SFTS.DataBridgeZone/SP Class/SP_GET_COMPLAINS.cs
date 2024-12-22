using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_COMPLAINS : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String DESCRIPTION { get; set; }

        [DataMember]
        public String RESOLUTION_DETAILS { get; set; }

        [DataMember]
        public Decimal TYPE_ID { get; set; }

        [DataMember]
        public Decimal STATUS_ID { get; set; }

        [DataMember]
        public String STATUS_NAME { get; set; }

        [DataMember]
        public String COMPLAIN_DATE { get; set; }

        [DataMember]
        public String COMPLAIN_FOR_CODE { get; set; }

        [DataMember]
        public String COMPLAIN_FOR_NAME { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public Decimal COMPLAIN_FOR { get; set; }

        [DataMember]
        public String COMPLAIN_FOR_TEXT { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_COMPLAINS entity = new SP_GET_COMPLAINS();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.DESCRIPTION = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RESOLUTION_DETAILS = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.TYPE_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.STATUS_ID = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.STATUS_NAME = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.COMPLAIN_DATE = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.COMPLAIN_FOR_CODE = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.COMPLAIN_FOR_NAME = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.COMPLAIN_FOR = Convert.ToDecimal(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.COMPLAIN_FOR_TEXT = Convert.ToString(values[12]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
