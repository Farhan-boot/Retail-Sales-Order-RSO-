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
    public class SP_GET_ACHIEVE_POINT : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal POINT_ID { get; set; }

        [DataMember]
        public String POINT_NAME { get; set; }

        [DataMember]
        public String POINT_CODE { get; set; }

        [DataMember]
        public decimal POINT_SCORE { get; set; }
        [DataMember]
        public Decimal IS_ACTIVE { get; set; }

        [DataMember]
        public string IS_ACTIVE_STR { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_ACHIEVE_POINT entity = new SP_GET_ACHIEVE_POINT();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.POINT_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.POINT_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.POINT_CODE = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.POINT_SCORE = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToDecimal(values[4]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE_STR = Convert.ToDecimal(values[4]) == 1 ? "Active" : "Inactive";


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
