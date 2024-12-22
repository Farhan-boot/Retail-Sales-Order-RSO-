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
    public class SP_GET_RSOPOINT_WEB : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public string DATE_STR { get; set; }

        [DataMember]
        public decimal POINT_USERID { get; set; }

        [DataMember]
        public String REGION { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String SR_NO { get; set; }

        [DataMember]
        public string TOTAL_POINTS { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RSOPOINT_WEB entity = new SP_GET_RSOPOINT_WEB();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DATE_STR = Convert.ToString(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.POINT_USERID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.REGION = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.SR_NO = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.TOTAL_POINTS = Convert.ToString(values[6]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
