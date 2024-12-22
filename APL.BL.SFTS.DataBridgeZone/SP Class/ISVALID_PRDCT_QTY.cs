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
    public class ISVALID_PRDCT_QTY : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public int IS_VALID { get; set; }

        public object MapToEntity(object[] values)
        {
            ISVALID_PRDCT_QTY entity = new ISVALID_PRDCT_QTY();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.IS_VALID = Convert.ToInt32(values[0]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
