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
    public class SP_GET_INS_UPD_SAF_INFOcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal SAF_ID { get; set; }

        [DataMember]
        public DateTime SAF_RECEIVEDATE { get; set; }

        [DataMember]
        public String SAF_SIMNO { get; set; }

        [DataMember]
        public String SAF_SAFFROMNO { get; set; }

        [DataMember]
        public Decimal SAF_RETAILERID { get; set; }

        [DataMember]
        public Decimal SAF_RSOID { get; set; }

        [DataMember]
        public DateTime SAF_UPDATEDATE { get; set; }

        [DataMember]
        public String SAF_UPDATEBY { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_INS_UPD_SAF_INFOcls entity = new SP_GET_INS_UPD_SAF_INFOcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.SAF_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.SAF_RECEIVEDATE = Convert.ToDateTime(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.SAF_SIMNO = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.SAF_SAFFROMNO = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.SAF_RETAILERID = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.SAF_RSOID = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.SAF_UPDATEDATE = Convert.ToDateTime(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.SAF_UPDATEBY = Convert.ToString(values[7]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
