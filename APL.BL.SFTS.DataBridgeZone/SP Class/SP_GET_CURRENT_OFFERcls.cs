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
    public class SP_GET_CURRENT_OFFERcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        
        [DataMember]
        public Decimal CURRENT_OFFER_ID { get; set; }

        [DataMember]
        public String OFFER_NAME { get; set; }

        [DataMember]
        public String OFFER_DETAIL { get; set; }

        [DataMember]
        public decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public string DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public DateTime PREPAREDATE { get; set; }

        [DataMember]
        public Decimal IS_ACTIVE { get; set; }

        [DataMember]
        public Decimal TOTAL_RECORD { get; set; }

        [DataMember]
        public Decimal ROW_NUMBER { get; set; }

        [DataMember]
        public DateTime DISPLAY_FROMDATE { get; set; }

        [DataMember]
        public DateTime DISPLAY_TODATE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_CURRENT_OFFERcls entity = new SP_GET_CURRENT_OFFERcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.CURRENT_OFFER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.OFFER_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.OFFER_DETAIL = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.PREPAREDATE = Convert.ToDateTime(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToDecimal(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.TOTAL_RECORD = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.DISPLAY_FROMDATE = Convert.ToDateTime(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.DISPLAY_TODATE = Convert.ToDateTime(values[10]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }      
}
