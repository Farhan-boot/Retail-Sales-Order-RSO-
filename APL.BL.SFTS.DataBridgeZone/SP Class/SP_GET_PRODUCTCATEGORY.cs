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
    public class SP_GET_PRODUCTCATEGORY : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public decimal Id { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
      
   


        public object MapToEntity(object[] values)
        {
            SP_GET_PRODUCTCATEGORY entity = new SP_GET_PRODUCTCATEGORY();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.Id = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CategoryName = Convert.ToString(values[1]);
           


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }



}
