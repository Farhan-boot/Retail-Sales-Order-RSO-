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
    public class SP_GET_HIGHLIGHTS_REQ_STOCK : ObjectMakerFromOracleSP.ISpClassEntity
    {       
        [DataMember]
        public String ITEM_NAME { get; set; }

        [DataMember]
        public Decimal TOTAL { get; set; }

        [DataMember]
        public Decimal ACHIEVEMENTQTY { get; set; }

        [DataMember]
        public Decimal STOCKQTY { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_HIGHLIGHTS_REQ_STOCK entity = new SP_GET_HIGHLIGHTS_REQ_STOCK();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ITEM_NAME = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TOTAL = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.ACHIEVEMENTQTY = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.STOCKQTY = Convert.ToDecimal(values[3]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }      
}
