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
    public class SP_APP_PASSWORD_CHANGE : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public Decimal STATUS { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_APP_PASSWORD_CHANGE entity = new SP_APP_PASSWORD_CHANGE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.STATUS = Convert.ToDecimal(values[0]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
