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
    public class GET_SHOP_CLOSING_STATUS : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ShopId { get; set; }

        [DataMember]
        public String ShopCode { get; set; }

        [DataMember]
        public String ShopName { get; set; }

        [DataMember]
        public String ShopAddress { get; set; }

        [DataMember]
        public String StatusDate { get; set; }

        [DataMember]
        public String StatusDescription { get; set; }

        [DataMember]
        public String ClosingTime { get; set; }


        public object MapToEntity(object[] values)
        {
            GET_SHOP_CLOSING_STATUS entity = new GET_SHOP_CLOSING_STATUS();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ShopCode = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ShopCode = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.ShopName = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.ShopAddress = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.StatusDate = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.StatusDescription = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.ClosingTime = Convert.ToString(values[6]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
