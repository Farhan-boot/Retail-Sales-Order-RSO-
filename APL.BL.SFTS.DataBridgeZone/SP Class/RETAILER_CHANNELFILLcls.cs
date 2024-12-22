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
    public class RETAILER_CHANNELFILLcls : ObjectMakerFromOracleSP.ISpClassEntity
    {       
        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public DateTime MONTH_DATE { get; set; }

        [DataMember]
        public Decimal PRODUCT_ISSUE { get; set; }

        [DataMember]
        public Decimal PRODUCT_TOTAL_SALE { get; set; }

        /// <summary>
        /// Remain sim or which are not sale.
        /// </summary>
        [DataMember]
        public Decimal PRODUCT_CHANNELFILL { get; set; }
              
        [DataMember]
        public String PRODUCT_CATEGORY_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            RETAILER_CHANNELFILLcls entity = new RETAILER_CHANNELFILLcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.MONTH_DATE = Convert.ToDateTime(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PRODUCT_ISSUE = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.PRODUCT_TOTAL_SALE = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.PRODUCT_CHANNELFILL = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.PRODUCT_CATEGORY_NAME = Convert.ToString(values[6]);           

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
