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
    public class GET_PRODUCTS : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CODE { get; set; }
        [DataMember]
        public string NAME { get; set; }
        [DataMember]
        public decimal PRICE { get; set; }
        public object MapToEntity(object[] values)
        {
            GET_PRODUCTS entity = new GET_PRODUCTS();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToInt32(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PRICE = Convert.ToDecimal(values[3]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
