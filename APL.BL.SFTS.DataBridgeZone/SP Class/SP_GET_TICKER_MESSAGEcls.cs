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
    public class SP_GET_TICKER_MESSAGEcls : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public Decimal TICKER_MESSAGE_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public String MESSAGE_NOTE { get; set; }

        [DataMember]
        public System.DateTime PREPAREDATE { get; set; }

        [DataMember]
        public System.DateTime DISPLAY_START_DATE { get; set; }

        [DataMember]
        public System.DateTime DISPLAY_END_DATE { get; set; }

        [DataMember]
        public Decimal TOTAL_RECORD { get; set; }

         [DataMember]
        public string DISTRIBUTOR_NAME { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_TICKER_MESSAGEcls entity = new SP_GET_TICKER_MESSAGEcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TICKER_MESSAGE_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.MESSAGE_NOTE = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.PREPAREDATE = Convert.ToDateTime(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.DISPLAY_START_DATE = Convert.ToDateTime(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.DISPLAY_END_DATE = Convert.ToDateTime(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.TOTAL_RECORD = Convert.ToDecimal(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[7]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
