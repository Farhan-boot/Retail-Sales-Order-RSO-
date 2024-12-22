using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_UPLOADED_TARGET : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal UPLOAD_CODE { get; set; }

        [DataMember]
        public string MONTH_CODE { get; set; }

        [DataMember]
        public string TARGET_ITEM_CODE { get; set; }

        [DataMember]
        public Decimal APPLY_TYPE { get; set; }

        [DataMember]
        public string APPLY_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public string DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public string DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public string RETAILER_CODE { get; set; }

        [DataMember]
        public string RETAILER_NAME { get; set; }

        [DataMember]
        public DateTime START_DATE { get; set; }

        [DataMember]
        public DateTime END_DATE { get; set; }

        [DataMember]
        public Decimal MAX_PERCENT { get; set; }

        [DataMember]
        public Decimal MIN_PERCENT { get; set; }

        [DataMember]
        public Decimal ACCURATE_PERCENT { get; set; }

        [DataMember]
        public Decimal TARGET_APPLICABLE { get; set; }

        [DataMember]
        public Decimal BUDGETED_FIGURE { get; set; }

        [DataMember]
        public Decimal IS_APPROVED { get; set; }

        [DataMember]
        public DateTime SUBMITTED_DATE { get; set; }

        [DataMember]
        public Decimal IS_ACTIVE { get; set; }

        [DataMember]
        public decimal CREATE_BY { get; set; }

        [DataMember]
        public DateTime CREATE_DATE { get; set; }

        [DataMember]
        public decimal UPDATE_BY { get; set; }

        [DataMember]
        public DateTime UPDATE_DATE { get; set; }

        [DataMember]
        public Decimal RESULT_COUNT { get; set; }

        public Decimal PRODUCT_CATEGORY_ID { get; set; }

        [DataMember]
        public string PRODUCT_ID_LIST { get; set; }

        [DataMember]
        public Decimal BUDGET_UNIT { get; set; }

        [DataMember]
        public Decimal ROW_NUMBER { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_TARGET_SETUPcls entity = new SP_GET_TARGET_SETUPcls();

            if (values[0].GetType() != typeof(System.DBNull))
            {
                entity.TARGET_SETUP_ID = Convert.ToDecimal(values[0]);
            }
            if (values[1].GetType() != typeof(System.DBNull))
            {
                entity.COMMISSION_ID = Convert.ToDecimal(values[1]);
            }
            if (values[2].GetType() != typeof(System.DBNull))
            {
                entity.COMMISSION_NAME = Convert.ToString(values[2]);
            }
            if (values[3].GetType() != typeof(System.DBNull))
            {
                entity.TYREID = Convert.ToDecimal(values[3]);
            }
            if (values[4].GetType() != typeof(System.DBNull))
            {
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[4]);
            }
            if (values[5].GetType() != typeof(System.DBNull))
            {
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[5]);
            }
            if (values[6].GetType() != typeof(System.DBNull))
            {
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[6]);
            }
            if (values[7].GetType() != typeof(System.DBNull))
            {
                entity.RETAILER_ID = Convert.ToDecimal(values[7]);
            }
            if (values[8].GetType() != typeof(System.DBNull))
            {
                entity.RETAILER_CODE = Convert.ToString(values[8]);
            }
            if (values[9].GetType() != typeof(System.DBNull))
            {
                entity.RETAILER_NAME = Convert.ToString(values[9]);
            }
            if (values[10].GetType() != typeof(System.DBNull))
            {
                entity.START_DATE = Convert.ToDateTime(values[10]);
            }
            if (values[11].GetType() != typeof(System.DBNull))
            {
                entity.END_DATE = Convert.ToDateTime(values[11]);
            }
            if (values[12].GetType() != typeof(System.DBNull))
            {
                entity.MAX_PERCENT = Convert.ToDecimal(values[12]);
            }
            if (values[13].GetType() != typeof(System.DBNull))
            {
                entity.MIN_PERCENT = Convert.ToDecimal(values[13]);
            }
            if (values[14].GetType() != typeof(System.DBNull))
            {
                entity.ACCURATE_PERCENT = Convert.ToDecimal(values[14]);
            }
            if (values[15].GetType() != typeof(System.DBNull))
            {
                entity.TARGET_APPLICABLE = Convert.ToChar(values[15]);
            }
            if (values[16].GetType() != typeof(System.DBNull))
            {
                entity.BUDGETED_FIGURE = Convert.ToDecimal(values[16]);
            }
            if (values[17].GetType() != typeof(System.DBNull))
            {
                entity.IS_APPROVED = Convert.ToDecimal(values[17]);
            }
            if (values[18].GetType() != typeof(System.DBNull))
            {
                entity.SUBMITTED_DATE = Convert.ToDateTime(values[18]);
            }
            if (values[19].GetType() != typeof(System.DBNull))
            {
                entity.IS_ACTIVE = Convert.ToDecimal(values[19]);
            }
            if (values[20].GetType() != typeof(System.DBNull))
            {
                entity.CREATE_BY = Convert.ToDecimal(values[20]);
            }
            if (values[21].GetType() != typeof(System.DBNull))
            {
                entity.CREATE_DATE = Convert.ToDateTime(values[21]);
            }
            if (values[22].GetType() != typeof(System.DBNull))
            {
                entity.UPDATE_BY = Convert.ToDecimal(values[22]);
            }
            if (values[23].GetType() != typeof(System.DBNull))
            {
                entity.UPDATE_DATE = Convert.ToDateTime(values[23]);
            }
            if (values[24].GetType() != typeof(System.DBNull))
            {
                entity.RESULT_COUNT = Convert.ToDecimal(values[24]);
            }

            if (values[25].GetType() != typeof(System.DBNull))
            {
                entity.PRODUCT_CATEGORY_ID = Convert.ToDecimal(values[25]);
            }
            if (values[26].GetType() != typeof(System.DBNull))
            {
                entity.PRODUCT_ID_LIST = Convert.ToString(values[26]);
            }
            if (values[27].GetType() != typeof(System.DBNull))
            {
                entity.BUDGET_UNIT = Convert.ToDecimal(values[27]);
            }
            if (values[28].GetType() != typeof(System.DBNull))
            {
                entity.ROW_NUMBER = Convert.ToDecimal(values[28]);
            }


            return entity;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}