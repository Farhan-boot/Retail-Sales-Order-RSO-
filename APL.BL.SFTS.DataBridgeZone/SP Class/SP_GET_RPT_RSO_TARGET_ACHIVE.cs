using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RPT_RSO_TARGET_ACHIVE : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String TARGET_ITEM { get; set; }

        [DataMember]
        public String TARGET_PERIOD { get; set; }

        [DataMember]
        public String MONTH_NO { get; set; }

        [DataMember]
        public String TARGET_VALUE { get; set; }

        [DataMember]
        public String ACHIEVED_VALUE { get; set; }

        [DataMember]
        public String PRO_RATED_TARGET { get; set; }

        [DataMember]
        public String CURRENT_RR { get; set; }

        [DataMember]
        public String REQUIRED_RR { get; set; }

        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String RSO_NAME { get; set; }

        [DataMember]
        public String RSO_NAME_CODE { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RPT_RSO_TARGET_ACHIVE entity = new SP_GET_RPT_RSO_TARGET_ACHIVE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TARGET_PERIOD = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.MONTH_NO = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.TARGET_VALUE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.ACHIEVED_VALUE = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.PRO_RATED_TARGET = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.CURRENT_RR = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.REQUIRED_RR = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.RSO_NAME = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.RSO_NAME_CODE = Convert.ToString(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[12]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
