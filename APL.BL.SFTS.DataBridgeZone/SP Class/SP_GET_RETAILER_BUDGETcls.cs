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
    public class SP_GET_RETAITER_BUDGETcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ROW_NUMBER { get; set; }

        [DataMember]
        public Decimal RETAILER_BUDGET_ID { get; set; }

        [DataMember]
        public Decimal TARGET_SETUP_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_BUDGET_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public System.DateTime START_DATE { get; set; }

        [DataMember]
        public System.DateTime END_DATE { get; set; }

        [DataMember]
        public System.DateTime MONTH_DATE { get; set; }

        [DataMember]
        public Decimal BUDGET_AMOUNT { get; set; }

        [DataMember]
        public Decimal ACHIVEMENT_AMOUNT { get; set; }

        [DataMember]
        public Decimal COMMISSION_AMOUNT { get; set; }

        [DataMember]
        public string DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public string RETAILER_NAME { get; set; }

        [DataMember]
        public Decimal PRODUCT_CATEGORY_ID { get; set; }

        [DataMember]
        public String PRODUCT_ID_LIST { get; set; }

        [DataMember]
        public Decimal BUDGET_UNIT { get; set; }

        [DataMember]
        public Decimal TOTAL_RECORD { get; set; }

        [DataMember]
        public Decimal LoginID { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RETAITER_BUDGETcls entity = new SP_GET_RETAITER_BUDGETcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_BUDGET_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.TARGET_SETUP_ID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_BUDGET_ID = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.START_DATE = Convert.ToDateTime(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.END_DATE = Convert.ToDateTime(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.MONTH_DATE = Convert.ToDateTime(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.BUDGET_AMOUNT = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.ACHIVEMENT_AMOUNT = Convert.ToDecimal(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.COMMISSION_AMOUNT = Convert.ToDecimal(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.PRODUCT_CATEGORY_ID = Convert.ToDecimal(values[14]);

            if (values[15].GetType() != typeof(System.DBNull))
                entity.PRODUCT_ID_LIST = Convert.ToString(values[15]);

            if (values[16].GetType() != typeof(System.DBNull))
                entity.BUDGET_UNIT = Convert.ToDecimal(values[16]);

            if (values[17].GetType() != typeof(System.DBNull))
                entity.TOTAL_RECORD = Convert.ToDecimal(values[17]);

            return entity;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
