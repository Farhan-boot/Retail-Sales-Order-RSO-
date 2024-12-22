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
    public class SP_GET_COMMISSION_GROUPcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }
        [DataMember]
        public String NAME { get; set; }
        [DataMember]
        public Decimal COM_STATUS { get; set; }
        [DataMember]
        public Decimal CREATE_BY { get; set; }
        [DataMember]
        public DateTime CREATE_DATE { get; set; }
        [DataMember]
        public Decimal UPDATE_BY { get; set; }
        [DataMember]
        public DateTime UPDATE_DATE { get; set; }
        [DataMember]
        public Decimal ROW_NUMBER { get; set; }
        [DataMember]
        public Decimal TOTAL_ROW { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_COMMISSION_GROUPcls entity = new SP_GET_COMMISSION_GROUPcls();
           
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.COM_STATUS = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.CREATE_BY = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToDateTime(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.TOTAL_ROW = Convert.ToDecimal(values[8]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
