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
    public class SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal NATIONAL_TARGET_SETUP_ID { get; set; }
        [DataMember]
        public Decimal COMMISSION_GROUP_ID { get; set; }
        [DataMember]
        public String COM_GRP_NAME { get; set; }
        [DataMember]
        public Decimal COMMISSION_GROUP_MEM_MAP_ID { get; set; }
        [DataMember]
        public String COM_GRP_MEMBER_NAME { get; set; }
        [DataMember]
        public String SETUP_NAME { get; set; }
        [DataMember]
        public DateTime START_DATE { get; set; }
        [DataMember]
        public DateTime END_DATE { get; set; }
        [DataMember]
        public DateTime MONTH_DATE { get; set; }
        [DataMember]
        public DateTime FREEZE_DATE { get; set; }
        [DataMember]
        public Decimal MARKETING_TARGET { get; set; }

        [DataMember]
        public Decimal INCREASE_PER { get; set; }

        [DataMember]
        public Decimal SALES_TARGET { get; set; }
        [DataMember]
        public Decimal MIN_DECREASE_PER { get; set; }
        [DataMember]
        public Decimal MAX_EXTEND_PER { get; set; }
        [DataMember]
        public Decimal MIN_THRESHOLD_PER { get; set; }
        [DataMember]
        public Decimal MAX_THRESHOLD_PER { get; set; }
        [DataMember]
        public Decimal IS_REUSABLE { get; set; }
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

        [DataMember]
        public Decimal TARGET_UNIT_ID { get; set; }

        [DataMember]
        public Decimal NATIONAL_TARGET_SETUP_DETAIL_ID { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls entity = new SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.NATIONAL_TARGET_SETUP_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.COMMISSION_GROUP_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.COM_GRP_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.COMMISSION_GROUP_MEM_MAP_ID = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.COM_GRP_MEMBER_NAME = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.SETUP_NAME = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.START_DATE = Convert.ToDateTime(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.END_DATE = Convert.ToDateTime(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.MONTH_DATE = Convert.ToDateTime(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.FREEZE_DATE = Convert.ToDateTime(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.MARKETING_TARGET = Convert.ToDecimal(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.INCREASE_PER = Convert.ToDecimal(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.SALES_TARGET = Convert.ToDecimal(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.MIN_DECREASE_PER = Convert.ToDecimal(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.MAX_EXTEND_PER = Convert.ToDecimal(values[14]);

            if (values[15].GetType() != typeof(System.DBNull))
                entity.MIN_THRESHOLD_PER = Convert.ToDecimal(values[15]);

            if (values[16].GetType() != typeof(System.DBNull))
                entity.MAX_THRESHOLD_PER = Convert.ToDecimal(values[16]);

            if (values[17].GetType() != typeof(System.DBNull))
                entity.IS_REUSABLE = Convert.ToDecimal(values[17]);

            if (values[18].GetType() != typeof(System.DBNull))
                entity.CREATE_BY = Convert.ToDecimal(values[18]);

            if (values[19].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToDateTime(values[19]);

            if (values[20].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[20]);

            if (values[21].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[21]);

            if (values[22].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[22]);

            if (values[23].GetType() != typeof(System.DBNull))
                entity.TOTAL_ROW = Convert.ToDecimal(values[23]);

             if (values[24].GetType() != typeof(System.DBNull))
                 entity.TARGET_UNIT_ID = Convert.ToDecimal(values[24]);

            if (values[25].GetType() != typeof(System.DBNull))
                 entity.NATIONAL_TARGET_SETUP_DETAIL_ID = Convert.ToDecimal(values[25]);
            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
