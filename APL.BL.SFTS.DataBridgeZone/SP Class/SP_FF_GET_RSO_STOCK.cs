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
    public class SP_FF_GET_RSO_STOCK : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String TDATE { get; set; }

        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String PRODUCT_NAME { get; set; }

        [DataMember]
        public String PRODUCT_QTY { get; set; }

        [DataMember]
        public String SALES_QTY { get; set; }

        [DataMember]
        public String BALANCE { get; set; }

        

        public object MapToEntity(object[] values)
        {
            SP_FF_GET_RSO_STOCK entity = new SP_FF_GET_RSO_STOCK();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.TDATE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.PRODUCT_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PRODUCT_QTY = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.SALES_QTY = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.BALANCE = Convert.ToString(values[5]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
