using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class SP_INS_UPD_MARKET_UPDATEcls : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public Decimal MARKETUPDATE_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTORID { get; set; }


        [DataMember]
        public Decimal RSOID { get; set; }


        [DataMember]
        public Decimal RETAILERID { get; set; }

        [DataMember]
        public Decimal EVENT_NAMEID { get; set; }


        [DataMember]
        public Decimal OPERATORID { get; set; }

        [DataMember]
        public String EVENT_NOTE { get; set; }

        [DataMember]
        public String PICTURE_URL { get; set; }


        [DataMember]
        public DateTime EVENT_DATE { get; set; }

        [DataMember]
        public Decimal IS_DISPLAY { get; set; }

        [DataMember]
        public Decimal UPDATE_BY { get; set; }

        [DataMember]
        public String UPDATE_DATE { get; set; }

        [DataMember]
        public Decimal MARKET_UPDATE_ID { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_INS_UPD_MARKET_UPDATEcls entity = new SP_INS_UPD_MARKET_UPDATEcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.MARKET_UPDATE_ID = Convert.ToDecimal(values[0]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
