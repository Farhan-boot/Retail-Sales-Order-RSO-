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
    public class SP_GET_RSO_TAR_ACHIcls : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public DateTime MONTH_DATE { get; set; }

        [DataMember]
        public Decimal PRODUCT_CATEGORY_ID { get; set; }

        [DataMember]
        public Decimal RSO_TARGET_AMOUNT { get; set; }

        [DataMember]
        public Decimal RSO_ACHIVEMENT_AMOUNT { get; set; }

        [DataMember]
        public Decimal RSO_COMMISSION_AMOUNT { get; set; }

        [DataMember]
        public String PRODUCT_CATEGORY_NAME { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_GET_RSO_TAR_ACHIcls entity = new SP_GET_RSO_TAR_ACHIcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.MONTH_DATE = Convert.ToDateTime(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.PRODUCT_CATEGORY_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSO_TARGET_AMOUNT = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RSO_ACHIVEMENT_AMOUNT = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RSO_COMMISSION_AMOUNT = Convert.ToDecimal(values[4]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
