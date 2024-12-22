using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_SHOP_STOCK : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public Decimal ProductId { get; set; }

        [DataMember]
        public String ProductName { get; set; }

        [DataMember]
        public Decimal CurrentStock { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_SHOP_STOCK entity = new SP_GET_SHOP_STOCK();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ProductId = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ProductName = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.CurrentStock = Convert.ToDecimal(values[2]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
