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
    public class SP_GET_GROSS_BUDGETcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal GROSS_BUDGET_ID { get; set; }

        [DataMember]
        public System.DateTime MONTH_DATE { get; set; }

        [DataMember]
        public System.DateTime MON_START_DATE { get; set; }

        [DataMember]
        public System.DateTime MON_END_DATE { get; set; }

        [DataMember]
        public Decimal BUDGET_AMOUNT { get; set; }

        [DataMember]
        public String NOTE { get; set; }

        [DataMember]
        public Decimal IS_APPROVED { get; set; }

        [DataMember]
        public Decimal PRODUCT_CATEGORY_ID { get; set; }

        [DataMember]
        public string PRODUCT_ID_LIST { get; set; }

        [DataMember]
        public Decimal BUDGET_UNIT { get; set; }

        [DataMember]
        public Decimal TOTAL_RECORD { get; set; }

        [DataMember]
        public Decimal LoginID { get; set; }

        [DataMember]
        public Decimal ROW_NUMBER { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_GROSS_BUDGETcls entity = new SP_GET_GROSS_BUDGETcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.GROSS_BUDGET_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.MONTH_DATE = Convert.ToDateTime(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.MON_START_DATE = Convert.ToDateTime(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.MON_END_DATE = Convert.ToDateTime(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.BUDGET_AMOUNT = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.NOTE = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.IS_APPROVED = Convert.ToDecimal(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.PRODUCT_CATEGORY_ID = Convert.ToDecimal(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.PRODUCT_ID_LIST = Convert.ToString(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.BUDGET_UNIT = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.TOTAL_RECORD = Convert.ToDecimal(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[11]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
