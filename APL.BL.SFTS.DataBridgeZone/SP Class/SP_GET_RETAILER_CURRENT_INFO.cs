using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_CURRENT_INFO : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String CODE { get; set; }

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
        public String DISTRICT_NAME { get; set; }

        [DataMember]
        public Decimal THANA_ID { get; set; }

        [DataMember]
        public String THANA_NAME { get; set; }

        [DataMember]
        public Decimal LOC_LATITUDE { get; set; }

        [DataMember]
        public Decimal LOC_LONGITUDE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_CURRENT_INFO entity = new SP_GET_RETAILER_CURRENT_INFO();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CODE = Convert.ToString(values[1]);
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
                entity.DISTRICT_NAME = Convert.ToString(values[15]);
            if (values[16].GetType() != typeof(System.DBNull))
                entity.THANA_ID = Convert.ToDecimal(values[16]);
            if (values[17].GetType() != typeof(System.DBNull))
                entity.THANA_NAME = Convert.ToString(values[17]);
            if (values[18].GetType() != typeof(System.DBNull))
                entity.LOC_LATITUDE = Convert.ToDecimal(values[18]);
            if (values[19].GetType() != typeof(System.DBNull))
                entity.LOC_LONGITUDE = Convert.ToDecimal(values[19]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
