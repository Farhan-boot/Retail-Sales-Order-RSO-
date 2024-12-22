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
    public class SP_GET_SCISSUENEWRETAILERcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String RSO_NAME { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public Decimal SCISSUENEWRETAILER_ID { get; set; }

        [DataMember]
        public Decimal RSOID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public Decimal ROUTE_ID { get; set; }

        [DataMember]
        public String RETAILER_MOBILE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public String SERIALSTART { get; set; }

        [DataMember]
        public String SERIALEND { get; set; }

        [DataMember]
        public String SMS { get; set; }

        [DataMember]
        public Decimal LATITUDE_VALUE { get; set; }

        [DataMember]
        public Decimal LONGITUDE_VALUE { get; set; }

        [DataMember]
        public Decimal STATUS { get; set; }

        [DataMember]
        public DateTime UPDATE_DATE { get; set; }

        [DataMember]
        public Decimal UPDATE_BY { get; set; }

        [DataMember]
        public Decimal ROW_NUMBER { get; set; }

        [DataMember]
        public Decimal TOTAL_RECORD { get; set; }
      
        public object MapToEntity(object[] values)
        {
            SP_GET_SCISSUENEWRETAILERcls entity = new SP_GET_SCISSUENEWRETAILERcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.SCISSUENEWRETAILER_ID = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.RSOID = Convert.ToDecimal(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.ROUTE_ID = Convert.ToDecimal(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.RETAILER_MOBILE = Convert.ToString(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.SERIALSTART = Convert.ToString(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.SERIALEND = Convert.ToString(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.SMS = Convert.ToString(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.LATITUDE_VALUE = Convert.ToDecimal(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.LONGITUDE_VALUE = Convert.ToDecimal(values[14]);

            if (values[15].GetType() != typeof(System.DBNull))
                entity.STATUS = Convert.ToDecimal(values[15]);

            if (values[16].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[16]);

            if (values[17].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[17]);

            if (values[18].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[18]);

            if (values[19].GetType() != typeof(System.DBNull))
                entity.TOTAL_RECORD = Convert.ToDecimal(values[19]);

            return entity;
        }                                                                 
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
