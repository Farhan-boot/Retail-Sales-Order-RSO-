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
    public class SP_GET_DISTRIBUTOR_BY_REG_IDcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
         
        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public Decimal TERRITORY_ID { get; set; }

        [DataMember]
        public String TERRITORY_CODE { get; set; }

        [DataMember]
        public String TERRITORY_NAME { get; set; }

        [DataMember]
        public Decimal ZONE_ID { get; set; }

        [DataMember]
        public String ZONE_CODE { get; set; }

        [DataMember]
        public String ZONE_NAME { get; set; }
        
        [DataMember]
        public Decimal REGION_ID { get; set; }

        [DataMember]
        public String REGION_CODE { get; set; }

        [DataMember]
        public String REGION_NAME { get; set; }
        [DataMember]
        public Decimal Id { get; set; }

        [DataMember]
        public string Label { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_GET_DISTRIBUTOR_BY_REG_IDcls entity = new SP_GET_DISTRIBUTOR_BY_REG_IDcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.TERRITORY_ID = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.TERRITORY_CODE = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.TERRITORY_NAME = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.ZONE_ID = Convert.ToDecimal(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.ZONE_CODE = Convert.ToString(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.ZONE_NAME = Convert.ToString(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.REGION_ID = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.REGION_CODE = Convert.ToString(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.REGION_NAME = Convert.ToString(values[11]);

            entity.Id = entity.DISTRIBUTOR_ID;
            entity.Label = entity.DISTRIBUTOR_NAME;

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }                                          
    }                                             
}