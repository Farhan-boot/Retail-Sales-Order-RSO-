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
    public class GET_PRODUCT_TYPE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        public object MapToEntity(object[] values)
        {
            GET_PRODUCT_TYPE entity = new GET_PRODUCT_TYPE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToInt32(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.Name = Convert.ToString(values[1]);
           
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
