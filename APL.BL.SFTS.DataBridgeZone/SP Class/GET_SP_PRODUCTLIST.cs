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
    public class GET_SP_PRODUCTLIST : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public decimal Id { get; set; }
        [DataMember]
        public string ProductName { get; set; }




        public object MapToEntity(object[] values)
        {
            GET_SP_PRODUCTLIST entity = new GET_SP_PRODUCTLIST();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.Id = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ProductName = Convert.ToString(values[1]);



            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
