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
    public class SP_GET_RETAIL_RSO_WISECls :ObjectMakerFromOracleSP.ISpClassEntity
    {
        /// <summary>
        /// ID => Retail ID
        /// </summary>
        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        /// <summary>
        /// CODE => Retail CODE
        /// </summary>
        [DataMember]
        public String RETAIL_CODE { get; set; }

        /// <summary>
        /// NAME => Retail NAME
        /// </summary>
        [DataMember]
        public String RETAIL_NAME { get; set; }

        /// <summary>
        /// DISTRIBUTOR => DISTRIBUTOR ID
        /// </summary>
        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }
      
        [DataMember]
        public Decimal RETAILER_ROUTE_ID { get; set; }

        /// <summary>
        /// LAST_LIFTING_DATE => LAST LIFTING DATE
        /// </summary>
        [DataMember]
        public DateTime LAST_LIFTING_DATE { get; set; }

        [DataMember]
        public Decimal SAF_PENDING { get; set; }

        [DataMember]
        public Decimal SIM_STOCK { get; set; }

        [DataMember]
        public Decimal TOPUP { get; set; }

        [DataMember]
        public String CURRENT_OFFER { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RETAIL_RSO_WISECls entity = new SP_GET_RETAIL_RSO_WISECls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAIL_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAIL_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[3]);   
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_ROUTE_ID = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.LAST_LIFTING_DATE = Convert.ToDateTime(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.SAF_PENDING = Convert.ToDecimal(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.SIM_STOCK = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.TOPUP = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.CURRENT_OFFER = Convert.ToString(values[9]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
