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
    //SP_GET_NAT_TAR_DISTRIBUTION_WCcls -> last part WC means With Child
    public class SP_GET_NAT_TAR_DISTRIBUTION_WCcls : ObjectMakerFromOracleSP.ISpClassEntity
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
        public String RSO_CODE { get; set; }
        [DataMember]
        public Decimal RETAILER_ID { get; set; }
        [DataMember]
        public String RETAILER_CODE { get; set; }
        [DataMember]
        public String XLS_CLN_05 { get; set; }
        [DataMember]
        public String XLS_CLN_06 { get; set; }
        [DataMember]
        public String XLS_CLN_07 { get; set; }
        [DataMember]
        public String XLS_CLN_08 { get; set; }
        [DataMember]
        public String XLS_CLN_09 { get; set; }
        [DataMember]
        public String XLS_CLN_10 { get; set; }
        [DataMember]
        public String XLS_CLN_11 { get; set; }
        [DataMember]
        public String XLS_CLN_12 { get; set; }
        [DataMember]
        public String XLS_CLN_13 { get; set; }
        [DataMember]
        public String XLS_CLN_14 { get; set; }
        [DataMember]
        public String XLS_CLN_15 { get; set; }
        [DataMember]
        public String XLS_CLN_16 { get; set; }
        [DataMember]
        public String XLS_CLN_17 { get; set; }
        [DataMember]
        public String XLS_CLN_18 { get; set; }
        [DataMember]
        public String XLS_CLN_19 { get; set; }
        [DataMember]
        public String XLS_CLN_20 { get; set; }
        [DataMember]
        public String XLS_CLN_21 { get; set; }
        [DataMember]
        public String XLS_CLN_22 { get; set; }
        [DataMember]
        public String XLS_CLN_23 { get; set; }
        [DataMember]
        public String XLS_CLN_24 { get; set; }
        [DataMember]
        public String XLS_CLN_25 { get; set; }
        [DataMember]
        public Decimal CREATE_BY { get; set; }
        [DataMember]
        public DateTime CREATE_DATE { get; set; }
        [DataMember]
        public Decimal UPDATE_BY { get; set; }
        [DataMember]
        public DateTime UPDATE_DATE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_NAT_TAR_DISTRIBUTION_WCcls entity = new SP_GET_NAT_TAR_DISTRIBUTION_WCcls();           

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
                entity.XLS_CLN_05 = Convert.ToString(values[19]);

            if (values[20] != null && values[20].GetType() != typeof(System.DBNull))
                entity.XLS_CLN_06 = Convert.ToString(values[20]);

            if (values[21] != null && values[21].GetType() != typeof(System.DBNull))
                entity.XLS_CLN_07 = Convert.ToString(values[21]);

            if (values[22] != null && values[22].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_08 = Convert.ToString(values[22]);

            if (values[23] != null && values[23].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_09 = Convert.ToString(values[23]);

            if (values[24] != null && values[24].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_10 = Convert.ToString(values[24]);

            if (values[25] != null && values[25].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_11 = Convert.ToString(values[25]);

            if (values[26] != null && values[26].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_12 = Convert.ToString(values[26]);

            if (values[27] != null && values[27].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_13 = Convert.ToString(values[27]);

            if (values[28] != null && values[28].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_14 = Convert.ToString(values[28]);

            if (values[29] != null && values[29].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_15 = Convert.ToString(values[29]);

            if (values[30] != null && values[30].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_16 = Convert.ToString(values[30]);

            if (values[31] != null && values[31].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_17 = Convert.ToString(values[31]);

            if (values[32] != null && values[32].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_18 = Convert.ToString(values[32]);

            if (values[33] != null && values[33].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_19 = Convert.ToString(values[33]);

            if (values[34] != null && values[34].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_20 = Convert.ToString(values[34]);

            if (values[35] != null && values[35].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_21 = Convert.ToString(values[35]);

            if (values[36] != null && values[36].GetType() != typeof(System.DBNull)) 
               entity.XLS_CLN_22 = Convert.ToString(values[36]);

            if (values[37] != null && values[37].GetType() != typeof(System.DBNull))
               entity.XLS_CLN_23 = Convert.ToString(values[37]);

            if (values[38] != null && values[38].GetType() != typeof(System.DBNull))
               entity.XLS_CLN_24 = Convert.ToString(values[38]);

            if (values[39] != null && values[39].GetType() != typeof(System.DBNull))
               entity.XLS_CLN_25 = Convert.ToString(values[39]);

            if (values[40] != null && values[40].GetType() != typeof(System.DBNull))
                entity.CREATE_BY = Convert.ToDecimal(values[40]);

            if (values[41] != null && values[41].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToDateTime(values[41]);

            if (values[42] != null && values[42].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[42]);
            if (values[43] != null && values[43].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[43]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
