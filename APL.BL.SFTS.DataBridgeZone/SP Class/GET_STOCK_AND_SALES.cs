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
    public class GET_STOCK_AND_SALES : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String P_CATEGORY { get; set; }

        [DataMember]
        public Decimal CURRENT_STOCK { get; set; }

        [DataMember]
        public Decimal AVERAGE_SALES { get; set; }

        [DataMember]
        public Decimal STOCK_QUANTITY { get; set; }

        public object MapToEntity(object[] values)
        {
            GET_STOCK_AND_SALES entity = new GET_STOCK_AND_SALES();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.P_CATEGORY = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CURRENT_STOCK = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.AVERAGE_SALES = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.STOCK_QUANTITY = Convert.ToDecimal(values[3]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
