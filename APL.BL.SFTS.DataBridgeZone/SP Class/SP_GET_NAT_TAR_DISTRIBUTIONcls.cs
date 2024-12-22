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
    public class SP_GET_NAT_TAR_DISTRIBUTIONcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal NAT_TAR_DISTRIBUTION_ID { get; set; }
        [DataMember]
        public Decimal CHANNELID { get; set; }
        [DataMember]
        public Decimal TARGET_AMT_TYPE_ID { get; set; }
        [DataMember]
        public String NAT_TAR_SET_NAME { get; set; }
        [DataMember]
        public Decimal COM_GROUP_ID { get; set; }
        [DataMember]
        public String COM_GRP_NAME { get; set; }
        [DataMember]
        public DateTime START_DATE { get; set; }
        [DataMember]
        public DateTime END_DATE { get; set; }
        [DataMember]
        public String DESCRIPTION { get; set; }
        [DataMember]
        public DateTime FREEZE_DATE { get; set; }
        [DataMember]
        public DateTime MONTH_DATE { get; set; }
        [DataMember]
        public Decimal TOTAL_ECL_CLN { get; set; }
        [DataMember]
        public Decimal NAT_TAR_DISTRIBUTION_DET_ID { get; set; }
        [DataMember]
        public Decimal REGION_ID { get; set; }
        [DataMember]
        public String REGION_CODE { get; set; }
        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }
        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }
        [DataMember]
        public Decimal RSO_ID { get; set; }
        [DataMember]
        public Decimal RETAILER_ID { get; set; }
        
        [DataMember]
        public Decimal CREATE_BY { get; set; }
        [DataMember]
        public DateTime CREATE_DATE { get; set; }
        [DataMember]
        public Decimal UPDATE_BY { get; set; }
        [DataMember]
        public DateTime UPDATE_DATE { get; set; }

        [DataMember]
        public Decimal NATIONAL_TARGET_SETUPID { get; set; }

        [DataMember]
        public Decimal  ROW_NUMBR{ get; set; }
                  [DataMember]
        public Decimal TOTAL_ROW { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_NAT_TAR_DISTRIBUTIONcls entity = new SP_GET_NAT_TAR_DISTRIBUTIONcls();

            if (values[0] != null && values[0].GetType() != typeof(System.DBNull))
                entity.NAT_TAR_DISTRIBUTION_ID = Convert.ToDecimal(values[0]);
            if (values[1] != null && values[1].GetType() != typeof(System.DBNull))
                entity.CHANNELID = Convert.ToDecimal(values[1]);
            if (values[2] != null && values[2].GetType() != typeof(System.DBNull))
                entity.TARGET_AMT_TYPE_ID = Convert.ToDecimal(values[2]);
            if (values[3] != null && values[3].GetType() != typeof(System.DBNull))
                entity.NAT_TAR_SET_NAME = Convert.ToString(values[3]);
            if (values[4] != null && values[4].GetType() != typeof(System.DBNull))
                entity.COM_GROUP_ID = Convert.ToDecimal(values[4]);
            if (values[5] != null && values[5].GetType() != typeof(System.DBNull))
                entity.COM_GRP_NAME = Convert.ToString(values[5]);
            if (values[6] != null && values[6].GetType() != typeof(System.DBNull))
                entity.START_DATE = Convert.ToDateTime(values[6]);
            if (values[7] != null && values[7].GetType() != typeof(System.DBNull))
                entity.END_DATE = Convert.ToDateTime(values[7]);
            if (values[8] != null && values[8].GetType() != typeof(System.DBNull))
                entity.DESCRIPTION = Convert.ToString(values[8]);
            if (values[9] != null && values[9].GetType() != typeof(System.DBNull))
                entity.FREEZE_DATE = Convert.ToDateTime(values[9]);
            if (values[10] != null && values[10].GetType() != typeof(System.DBNull))
                entity.MONTH_DATE = Convert.ToDateTime(values[10]);
            if (values[11] != null && values[11].GetType() != typeof(System.DBNull))
                entity.TOTAL_ECL_CLN = Convert.ToDecimal(values[11]);
            if (values[12] != null && values[12].GetType() != typeof(System.DBNull))
                entity.NAT_TAR_DISTRIBUTION_DET_ID = Convert.ToDecimal(values[12]);
            if (values[13] != null && values[13].GetType() != typeof(System.DBNull))
                entity.REGION_ID = Convert.ToDecimal(values[13]);
            if (values[14] != null && values[14].GetType() != typeof(System.DBNull))
                entity.REGION_CODE = Convert.ToString(values[14]);
            if (values[15] != null && values[15].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[15]);
            if (values[16] != null && values[16].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[16]);
            if (values[17] != null && values[17].GetType() != typeof(System.DBNull))
                entity.RSO_ID = Convert.ToDecimal(values[17]);
            if (values[18] != null && values[18].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[18]);

            if (values[19] != null && values[19].GetType() != typeof(System.DBNull))
                entity.NATIONAL_TARGET_SETUPID = Convert.ToDecimal(values[19]);
            if (values[20] != null && values[20].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBR = Convert.ToDecimal(values[20]);
            if (values[21] != null && values[21].GetType() != typeof(System.DBNull))
                entity.TOTAL_ROW = Convert.ToDecimal(values[21]);

            if (values[22] != null && values[22].GetType() != typeof(System.DBNull))
                entity.CREATE_BY = Convert.ToDecimal(values[22]);
            if (values[23] != null && values[23].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToDateTime(values[23]);
            if (values[24] != null && values[24].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[24]);
            if (values[25] != null && values[25].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[25]);
           
            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
