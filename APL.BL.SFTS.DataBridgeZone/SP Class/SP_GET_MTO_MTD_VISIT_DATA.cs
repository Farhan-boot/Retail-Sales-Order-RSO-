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
   public class SP_GET_MTO_MTD_VISIT_DATA: ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public Decimal SSOCOUNT { get; set; }
        [DataMember]
        public Decimal ISSUEDPOSMSSO { get; set; }
        [DataMember]
        public Decimal LSOCOUNT { get; set; }
        [DataMember]
        public Decimal ISSUEDPOSMLSO { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_GET_MTO_MTD_VISIT_DATA entity = new SP_GET_MTO_MTD_VISIT_DATA();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.SSOCOUNT = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ISSUEDPOSMSSO = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.LSOCOUNT = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.ISSUEDPOSMLSO = Convert.ToDecimal(values[3]);


            return entity;
        }

            public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
 