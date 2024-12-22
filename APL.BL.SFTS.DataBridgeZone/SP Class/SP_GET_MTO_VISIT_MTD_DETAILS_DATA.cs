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
   public class SP_GET_MTO_VISIT_MTD_DETAILS_DATA : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; } 

        [DataMember]
        public String RETAILER_ADDRESS { get; set; }

        [DataMember]
        public String TRANMOBILENO { get; set; }

        [DataMember]
        public String RETAILER_TRNS_MOBILE_NO { get; set; }

        [DataMember]
        public String RETAILER_TOPUP_NUMBER { get; set; }

        [DataMember]
        public String SSO { get; set; }

        [DataMember]
        public String LSO { get; set; }

        [DataMember]
        public DateTime VISITED_DATE { get; set; }

        [DataMember]
        public String VISIT_TIME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_MTO_VISIT_MTD_DETAILS_DATA entity = new SP_GET_MTO_VISIT_MTD_DETAILS_DATA();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILER_ADDRESS = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.TRANMOBILENO = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.RETAILER_TRNS_MOBILE_NO = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.RETAILER_TOPUP_NUMBER = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.SSO = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.LSO = Convert.ToString(values[8]);
            /*if (values[9].GetType() != typeof(System.DBNull))
                entity.VISITED_DATE = Convert.ToDateTime(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.VISIT_TIME = Convert.ToString(values[10]); */


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
