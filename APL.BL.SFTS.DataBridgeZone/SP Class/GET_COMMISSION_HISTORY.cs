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
    public class GET_COMMISSION_HISTORY : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String ITEM_NAME { get; set; }

        [DataMember]
        public Decimal MONTH_01 { get; set; }

        [DataMember]
        public Decimal MONTH_02 { get; set; }

        [DataMember]
        public Decimal MONTH_03 { get; set; }

        [DataMember]
        public Decimal FIRST_MONTH_NO { get; set; }

        [DataMember]
        public Decimal RUNNING_YEAR { get; set; }


        public object MapToEntity(object[] values)
        {
            GET_COMMISSION_HISTORY entity = new GET_COMMISSION_HISTORY();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ITEM_NAME = Convert.ToString(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.MONTH_01 = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.MONTH_02 = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.MONTH_03 = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.FIRST_MONTH_NO = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.RUNNING_YEAR = Convert.ToDecimal(values[5]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
