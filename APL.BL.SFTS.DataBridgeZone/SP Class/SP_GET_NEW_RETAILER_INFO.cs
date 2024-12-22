using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_NEW_RETAILER_INFO : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String CREATED_RETAILER_CODE { get; set; }

        [DataMember]
        public String NAME { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }
        
        [DataMember]
        public Decimal TERRITORY_ID { get; set; }

        [DataMember]
        public String TERRITORY_NAME { get; set; }

        [DataMember]
        public String OWNSHOP { get; set; }

        [DataMember]
        public String IS_OWN_SHOP { get; set; }

        [DataMember]
        public String ADDRESS { get; set; }

        [DataMember]
        public Decimal SHOPSIZE { get; set; }

        [DataMember]
        public String OWNERNAME { get; set; }

        [DataMember]
        public String CONTACTPERSON { get; set; }

        [DataMember]
        public String CONTACTNO { get; set; }

        [DataMember]
        public Decimal DISTRICT_ID { get; set; }

        [DataMember]
        public Decimal THANA_ID { get; set; }

        [DataMember]
        public Decimal REQUEST_STATUS { get; set; }

        [DataMember]
        public String REQUESTERS_COMMENTS { get; set; }

        [DataMember]
        public String APPROVERS_COMMENTS { get; set; }

        [DataMember]
        public Decimal CREATED_RETAILER_ID { get; set; }

        [DataMember]
        public Decimal REQUESTED_BY { get; set; }

        [DataMember]
        public String REQUESTED_BY_NAME { get; set; }

        [DataMember]
        public String REQUESTED_AT { get; set; }

        [DataMember]
        public Decimal LOC_LATITUDE { get; set; }

        [DataMember]
        public Decimal LOC_LONGITUDE { get; set; }

        [DataMember]
        public String DISTRICT_NAME { get; set; }

        [DataMember]
        public String THANA_NAME { get; set; }

        [DataMember]
        public String REQUEST_STATUS_NAME { get; set; }

        [DataMember]
        public Decimal ROUTE_ID { get; set; }

        [DataMember]
        public String ROUTE_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_NEW_RETAILER_INFO entity = new SP_GET_NEW_RETAILER_INFO();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CREATED_RETAILER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.TERRITORY_ID = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.TERRITORY_NAME = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.OWNSHOP = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.IS_OWN_SHOP = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.ADDRESS = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.SHOPSIZE = Convert.ToDecimal(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.OWNERNAME = Convert.ToString(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.CONTACTPERSON = Convert.ToString(values[12]);
            if (values[13].GetType() != typeof(System.DBNull))
                entity.CONTACTNO = Convert.ToString(values[13]);
            if (values[14].GetType() != typeof(System.DBNull))
                entity.DISTRICT_ID = Convert.ToDecimal(values[14]);
            if (values[15].GetType() != typeof(System.DBNull))
                entity.THANA_ID = Convert.ToDecimal(values[15]);
            if (values[16].GetType() != typeof(System.DBNull))
                entity.REQUEST_STATUS = Convert.ToDecimal(values[16]);
            if (values[17].GetType() != typeof(System.DBNull))
                entity.REQUESTERS_COMMENTS = Convert.ToString(values[17]);
            if (values[18].GetType() != typeof(System.DBNull))
                entity.APPROVERS_COMMENTS = Convert.ToString(values[18]);
            if (values[19].GetType() != typeof(System.DBNull))
                entity.CREATED_RETAILER_ID = Convert.ToDecimal(values[19]);
            if (values[20].GetType() != typeof(System.DBNull))
                entity.REQUESTED_BY = Convert.ToDecimal(values[20]);
            if (values[21].GetType() != typeof(System.DBNull))
                entity.REQUESTED_BY_NAME = Convert.ToString(values[21]);
            if (values[22].GetType() != typeof(System.DBNull))
                entity.REQUESTED_AT = Convert.ToString(values[22]);
            if (values[23].GetType() != typeof(System.DBNull))
                entity.LOC_LATITUDE = Convert.ToDecimal(values[23]);
            if (values[24].GetType() != typeof(System.DBNull))
                entity.LOC_LONGITUDE = Convert.ToDecimal(values[24]);
            if (values[25].GetType() != typeof(System.DBNull))
                entity.DISTRICT_NAME = Convert.ToString(values[25]);
            if (values[26].GetType() != typeof(System.DBNull))
                entity.THANA_NAME = Convert.ToString(values[26]);
            if (values[27].GetType() != typeof(System.DBNull))
                entity.REQUEST_STATUS_NAME = Convert.ToString(values[27]);
            if (values[28].GetType() != typeof(System.DBNull))
                entity.ROUTE_ID = Convert.ToDecimal(values[28]);
            if (values[29].GetType() != typeof(System.DBNull))
                entity.ROUTE_NAME = Convert.ToString(values[29]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
