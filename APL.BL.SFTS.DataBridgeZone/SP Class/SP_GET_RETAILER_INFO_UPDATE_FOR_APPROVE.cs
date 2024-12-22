using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_INFO_UPDATE_FOR_APPROVE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String CURRENT_NAME { get; set; }

        [DataMember]
        public String MODIFIED_NAME { get; set; }

        [DataMember]
        public String CURRENT_OWNSHOP { get; set; }

        [DataMember]
        public String CURRENT_IS_OWN_SHOP { get; set; }
        
        [DataMember]
        public String MODIFIED_OWNSHOP { get; set; }

        [DataMember]
        public String MODIFIED_IS_OWN_SHOP { get; set; }

        [DataMember]
        public String CURRENT_ADDRESS { get; set; }

        [DataMember]
        public String MODIFIED_ADDRESS { get; set; }

        [DataMember]
        public String CURRENT_SHOPSIZE { get; set; }

        [DataMember]
        public String MODIFIED_SHOPSIZE { get; set; }

        [DataMember]
        public String CURRENT_OWNERNAME { get; set; }

        [DataMember]
        public String MODIFIED_OWNERNAME { get; set; }

        [DataMember]
        public String CURRENT_CONTACTPERSON { get; set; }

        [DataMember]
        public String MODIFIED_CONTACTPERSON { get; set; }

        [DataMember]
        public String CURRENT_CONTACTNO { get; set; }

        [DataMember]
        public String MODIFIED_CONTACTNO { get; set; }

        [DataMember]
        public Decimal CURRENT_DISTRICT_ID { get; set; }

        [DataMember]
        public String CURRENT_DISTRICT_NAME { get; set; }

        [DataMember]
        public Decimal MODIFIED_DISTRICT_ID { get; set; }

        [DataMember]
        public String MODIFIED_DISTRICT_NAME { get; set; }

        [DataMember]
        public Decimal CURRENT_THANA_ID { get; set; }

        [DataMember]
        public String CURRENT_THANA_NAME { get; set; }

        [DataMember]
        public Decimal MODIFIED_THANA_ID { get; set; }

        [DataMember]
        public String MODIFIED_THANA_NAME { get; set; }

        [DataMember]
        public Decimal REQUEST_STATUS { get; set; }

        [DataMember]
        public String REQUEST_STATUS_NAME { get; set; }

        [DataMember]
        public String REQUESTERS_COMMENTS { get; set; }

        [DataMember]
        public String APPROVERS_COMMENTS { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public byte[] OUTLET_PICTURE { get; set; }

        [DataMember]
        public String OTHER_OPERATOR_CODE_1 { get; set; }

        [DataMember]
        public Decimal AVG_DAILY_RECHRAGE_OP_1 { get; set; }

        [DataMember]
        public Decimal AVG_WEEKLY_SIM_OP_1 { get; set; }

        [DataMember]
        public String OTHER_OPERATOR_CODE_2 { get; set; }

        [DataMember]
        public Decimal AVG_DAILY_RECHRAGE_OP_2 { get; set; }

        [DataMember]
        public Decimal AVG_WEEKLY_SIM_OP_2 { get; set; }

        [DataMember]
        public String OTHER_OPERATOR_CODE_3 { get; set; }

        [DataMember]
        public Decimal AVG_DAILY_RECHRAGE_OP_3 { get; set; }

        [DataMember]
        public Decimal AVG_WEEKLY_SIM_OP_3 { get; set; }

        [DataMember]
        public String TRADE_MATERIALS { get; set; }

        [DataMember]
        public Decimal MOB_DEVICE_TYPE_ID { get; set; }

        [DataMember]
        public String MOB_DEVICE_SIM_NO { get; set; }

        [DataMember]
        public String SCANNER_TYPE_ID { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }



        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_INFO_UPDATE_FOR_APPROVE entity = new SP_GET_RETAILER_INFO_UPDATE_FOR_APPROVE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CURRENT_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.MODIFIED_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.CURRENT_OWNSHOP = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.CURRENT_IS_OWN_SHOP = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.MODIFIED_OWNSHOP = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.MODIFIED_IS_OWN_SHOP = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.CURRENT_ADDRESS = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.MODIFIED_ADDRESS = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.CURRENT_SHOPSIZE = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.MODIFIED_SHOPSIZE = Convert.ToString(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.CURRENT_OWNERNAME = Convert.ToString(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.MODIFIED_OWNERNAME = Convert.ToString(values[12]);
            if (values[13].GetType() != typeof(System.DBNull))
                entity.CURRENT_CONTACTPERSON = Convert.ToString(values[13]);
            if (values[14].GetType() != typeof(System.DBNull))
                entity.MODIFIED_CONTACTPERSON = Convert.ToString(values[14]);
            if (values[15].GetType() != typeof(System.DBNull))
                entity.CURRENT_CONTACTNO = Convert.ToString(values[15]);
            if (values[16].GetType() != typeof(System.DBNull))
                entity.MODIFIED_CONTACTNO = Convert.ToString(values[16]);
            if (values[17].GetType() != typeof(System.DBNull))
                entity.CURRENT_DISTRICT_ID = Convert.ToDecimal(values[17]);
            if (values[18].GetType() != typeof(System.DBNull))
                entity.CURRENT_DISTRICT_NAME = Convert.ToString(values[18]);
            if (values[19].GetType() != typeof(System.DBNull))
                entity.MODIFIED_DISTRICT_ID = Convert.ToDecimal(values[19]);
            if (values[20].GetType() != typeof(System.DBNull))
                entity.MODIFIED_DISTRICT_NAME = Convert.ToString(values[20]);
            if (values[21].GetType() != typeof(System.DBNull))
                entity.CURRENT_THANA_ID = Convert.ToDecimal(values[21]);
            if (values[22].GetType() != typeof(System.DBNull))
                entity.CURRENT_THANA_NAME = Convert.ToString(values[22]);
            if (values[23].GetType() != typeof(System.DBNull))
                entity.MODIFIED_THANA_ID = Convert.ToDecimal(values[23]);
            if (values[24].GetType() != typeof(System.DBNull))
                entity.MODIFIED_THANA_NAME = Convert.ToString(values[24]);
            if (values[25].GetType() != typeof(System.DBNull))
                entity.REQUEST_STATUS = Convert.ToDecimal(values[25]);
            if (values[26].GetType() != typeof(System.DBNull))
                entity.REQUEST_STATUS_NAME = Convert.ToString(values[26]);
            if (values[27].GetType() != typeof(System.DBNull))
                entity.REQUESTERS_COMMENTS = Convert.ToString(values[27]);
            if (values[28].GetType() != typeof(System.DBNull))
                entity.APPROVERS_COMMENTS = Convert.ToString(values[28]);
            if (values[29].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[29]);
            if (values[30].GetType() != typeof(System.DBNull))
                entity.OUTLET_PICTURE = (byte[])(values[30]);
            if (values[31].GetType() != typeof(System.DBNull))
                entity.OTHER_OPERATOR_CODE_1 = Convert.ToString(values[31]);
            if (values[32].GetType() != typeof(System.DBNull))
                entity.AVG_DAILY_RECHRAGE_OP_1 = Convert.ToDecimal(values[32]);
            if (values[33].GetType() != typeof(System.DBNull))
                entity.AVG_WEEKLY_SIM_OP_1 = Convert.ToDecimal(values[33]);
            if (values[34].GetType() != typeof(System.DBNull))
                entity.OTHER_OPERATOR_CODE_2 = Convert.ToString(values[34]);
            if (values[35].GetType() != typeof(System.DBNull))
                entity.AVG_DAILY_RECHRAGE_OP_2 = Convert.ToDecimal(values[35]);
            if (values[36].GetType() != typeof(System.DBNull))
                entity.AVG_WEEKLY_SIM_OP_2 = Convert.ToDecimal(values[36]);
            if (values[37].GetType() != typeof(System.DBNull))
                entity.OTHER_OPERATOR_CODE_3 = Convert.ToString(values[37]);
            if (values[38].GetType() != typeof(System.DBNull))
                entity.AVG_DAILY_RECHRAGE_OP_3 = Convert.ToDecimal(values[38]);
            if (values[39].GetType() != typeof(System.DBNull))
                entity.AVG_WEEKLY_SIM_OP_3 = Convert.ToDecimal(values[39]);
            if (values[40].GetType() != typeof(System.DBNull))
                entity.TRADE_MATERIALS = Convert.ToString(values[40]);
            if (values[41].GetType() != typeof(System.DBNull))
                entity.MOB_DEVICE_TYPE_ID = Convert.ToDecimal(values[41]);
            if (values[42].GetType() != typeof(System.DBNull))
                entity.MOB_DEVICE_SIM_NO = Convert.ToString(values[42]);
            if (values[43].GetType() != typeof(System.DBNull))
                entity.SCANNER_TYPE_ID = Convert.ToString(values[43]);
            if (values[44].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[44]);
            if (values[45].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[45]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
