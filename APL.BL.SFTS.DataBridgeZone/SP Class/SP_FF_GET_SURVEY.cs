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
    public class SP_FF_GET_SURVEY : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String SURVEY_NAME { get; set; }

        [DataMember]
        public String RES_DATE { get; set; }

        [DataMember]
        public String USER_CODE { get; set; }

        [DataMember]
        public String USER_NAME { get; set; }

        [DataMember]
        public String SV_QST { get; set; }

        [DataMember]
        public String SV_ANS { get; set; }



        public object MapToEntity(object[] values)
        {
            SP_FF_GET_SURVEY entity = new SP_FF_GET_SURVEY();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.SURVEY_NAME = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RES_DATE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.USER_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.USER_NAME = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.SV_QST = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.SV_ANS = Convert.ToString(values[5]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
