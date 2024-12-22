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
    public class GET_COMPLAIN_PICTURE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public byte[] PICTURE { get; set; }

        [DataMember]
        public Decimal PICTURE_ID { get; set; }


        public object MapToEntity(object[] values)
        {
            GET_COMPLAIN_PICTURE entity = new GET_COMPLAIN_PICTURE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.PICTURE = (byte[])values[0];

            if (values[1].GetType() != typeof(System.DBNull))
                entity.PICTURE_ID = Convert.ToDecimal(values[1]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
