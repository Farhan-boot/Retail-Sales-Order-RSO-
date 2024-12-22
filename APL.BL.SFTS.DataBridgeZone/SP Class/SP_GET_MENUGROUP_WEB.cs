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
    public class SP_GET_MENUGROUP_WEB : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal GROUP_ID { get; set; }

        [DataMember]
        public String GROUP_NAME { get; set; }

        [DataMember]
        public String GROUP_FOR_NAME { get; set; }

        [DataMember]
        public Decimal GROUP_FOR { get; set; }
        [DataMember]
        public Decimal IS_ACTIVE { get; set; }

        [DataMember]
        public string IS_ACTIVE_STR { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_MENUGROUP_WEB entity = new SP_GET_MENUGROUP_WEB();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.GROUP_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.GROUP_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.GROUP_FOR_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.GROUP_FOR = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToDecimal(values[4]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE_STR = Convert.ToDecimal(values[4])==1?"Active":"Inactive";


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
