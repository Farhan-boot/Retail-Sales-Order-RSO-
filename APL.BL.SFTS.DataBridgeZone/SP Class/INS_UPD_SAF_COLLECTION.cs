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
    public class INS_UPD_SAF_COLLECTION : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public DateTime COL_DATE { get; set; }

        [DataMember]
        public String SIM_NO { get; set; }

        [DataMember]
        public String SAF_NO { get; set; }


        public object MapToEntity(object[] values)
        {
            INS_UPD_SAF_COLLECTION entity = new INS_UPD_SAF_COLLECTION();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.COL_DATE = Convert.ToDateTime(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.SIM_NO = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.SAF_NO = Convert.ToString(values[2]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
