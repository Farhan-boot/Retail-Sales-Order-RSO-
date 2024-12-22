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
    public class SP_CHECK_DEVICE : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public Decimal STATUS { get; set; }

        [DataMember]
        public String USERCODE { get; set; }



        public object MapToEntity(object[] values)
        {
            SP_CHECK_DEVICE entity = new SP_CHECK_DEVICE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.STATUS = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.USERCODE = Convert.ToString(values[1]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
