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
    public class GET_CRITICAL_RETAILERS_POPUP : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public string RETAILER_ID { get; set; }
        [DataMember]
        public string RETAILER_CODE { get; set; }
        [DataMember]
        public string RETAILER_NAME { get; set; }
        [DataMember]
        public string PRODUCT_TYPE { get; set; }
        [DataMember]
        public string RETAILER_TYPE { get; set; }
        public object MapToEntity(object[] values)
        {
            GET_CRITICAL_RETAILERS_POPUP entity = new GET_CRITICAL_RETAILERS_POPUP();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PRODUCT_TYPE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_TYPE = Convert.ToString(values[4]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
