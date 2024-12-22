using Oracle.ManagedDataAccess.Types;
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
    public class SP_INS_UPD_MARKET_UPDATEcls : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public Decimal MARKET_UPDATE_ID { get; set; }

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
        public Decimal ROUTE_ID { get; set; }

        [DataMember]
        public Decimal UPDATE_BY { get; set; }

        [DataMember]
        public DateTime UPDATE_DATE { get; set; }

        [DataMember]
        public string EVENTNAME { get; set; }

        [DataMember]
        public string OPERATOR_NAME { get; set; }

        [DataMember]
        public decimal SERIAL_NO { get; set; }

        [DataMember]
        public String PICTURE_BASE64 { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_INS_UPD_MARKET_UPDATEcls entity = new SP_INS_UPD_MARKET_UPDATEcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.MARKET_UPDATE_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTORID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSOID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILERID = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.EVENT_NAMEID = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.OPERATORID = Convert.ToDecimal(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.EVENT_NOTE = Convert.ToString(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.PICTURE_URL = Convert.ToString(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.EVENT_DATE = Convert.ToDateTime(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.IS_DISPLAY = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.ROUTE_ID = Convert.ToDecimal(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.EVENTNAME = Convert.ToString(values[13]);

            if (values[14] != null && values[14].GetType() != typeof(System.DBNull))
                entity.PICTURE_BASE64 = Convert.ToString(values[14]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
