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
    public class SP_GET_BEST_RSO_PRACTICE : ObjectMakerFromOracleSP.ISpClassEntity
    {       
        [DataMember]
        public Decimal BEST_PRACTICES_RSO_ID { get; set; }

        [DataMember]
        public Decimal RSO_ID { get; set; }

        [DataMember]
        public String RSO_NAME { get; set; }

        //[DataMember]
        //public Decimal MARKET_AREA_ID { get; set; }

        //[DataMember]
        //public String MARKET_AREA_NAME { get; set; }

        [DataMember]
        public Decimal PERIOD_ID { get; set; }

        [DataMember]
        public String PERIOD_NAME { get; set; }

        [DataMember]
        public Decimal YEAR { get; set; }

        [DataMember]
        public Decimal CALCULATION_AREA_ID { get; set; }

        [DataMember]
        public String CALCULATION_AREA_NAME { get; set; }

        [DataMember]
        public String DESCRIPTION { get; set; }

        [DataMember]
        public Decimal REGION_ID { get; set; }

        [DataMember]
        public String REGION_NAME { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_BEST_RSO_PRACTICE entity = new SP_GET_BEST_RSO_PRACTICE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.BEST_PRACTICES_RSO_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSO_NAME = Convert.ToString(values[2]);
            //if (values[3].GetType() != typeof(System.DBNull))
            //    entity.MARKET_AREA_ID = Convert.ToDecimal(values[3]);
            //if (values[4].GetType() != typeof(System.DBNull))
            //    entity.MARKET_AREA_NAME = Convert.ToString(values[4]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PERIOD_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.PERIOD_NAME = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.YEAR = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.CALCULATION_AREA_ID = Convert.ToDecimal(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.CALCULATION_AREA_NAME = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.DESCRIPTION = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.REGION_ID = Convert.ToDecimal(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.REGION_NAME = Convert.ToString(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[11]);
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
