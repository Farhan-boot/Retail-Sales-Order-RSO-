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
    public  class SP_GET_ATTENDANCE_SUMMARY1 : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String ATT_DATE { get; set; }

        [DataMember]
        public String RSO_CODE { get; set; }
        [DataMember]
        public String RSO_NAME { get; set; }
        [DataMember]
        public String SR_NO { get; set; }

        [DataMember]
        public String TOTAL_DIST_COVERED { get; set; }

        [DataMember]
        public decimal TOTAL_TIME { get; set; }



        public object MapToEntity(object[] values)
        {
            SP_GET_ATTENDANCE_SUMMARY1 entity = new SP_GET_ATTENDANCE_SUMMARY1();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ATT_DATE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSO_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.SR_NO = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.TOTAL_DIST_COVERED = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.TOTAL_TIME = Convert.ToDecimal(values[5]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
