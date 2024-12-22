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
    public class GET_BALANCE_STATUS : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public Decimal BALANCE_STATUS { get; set; }


        public object MapToEntity(object[] values)
        {
            GET_BALANCE_STATUS entity = new GET_BALANCE_STATUS();


            if (values[0] != null && values[0].GetType() != typeof(System.DBNull))
                entity.BALANCE_STATUS = Convert.ToDecimal(values[0]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
