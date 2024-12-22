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
    public class SP_INS_UPD_PRODUCT_SALEPRICEcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal TBLPRODUCTSUBCATEGORY_ID { get; set; }

        [DataMember]
        public Decimal UPDATE_BY { get; set; }

        [DataMember]
        public Decimal TBLPRODUCTCATEGORY_ID { get; set; }

        [DataMember]
        public DateTime UPDATE_DATE { get; set; }

        [DataMember]
        public Decimal TBLPRODFAMILY_ID { get; set; }

        [DataMember]
        public Decimal PRODUCT_SALEPRICE_ID { get; set; }

        [DataMember]
        public Decimal CREATE_BY { get; set; }

        [DataMember]
        public string NOTE { get; set; }

        [DataMember]
        public DateTime CREATE_DATE { get; set; }

        [DataMember]
        public Decimal TBLPRODUCTID { get; set; }

        [DataMember]
        public Decimal ISDISPLAY_PRICE { get; set; }

        [DataMember]
        public Decimal SALESPRICE { get; set; }

        [DataMember]
        public string PRODUCTNAME { get; set; }

        [DataMember]
        public string SUBCATEGORYNAME { get; set; }

        [DataMember]
        public string CATEGORYNAME { get; set; }

        [DataMember]
        public string PROFAMILYNAME { get; set; }

        [DataMember]
        public Decimal ROW_NUMBER { get; set; }

        [DataMember]
        public Decimal TOTAL_RECORD { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_INS_UPD_PRODUCT_SALEPRICEcls entity = new SP_INS_UPD_PRODUCT_SALEPRICEcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TBLPRODUCTSUBCATEGORY_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.TBLPRODUCTCATEGORY_ID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.TBLPRODFAMILY_ID = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.PRODUCT_SALEPRICE_ID = Convert.ToDecimal(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.CREATE_BY = Convert.ToDecimal(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.NOTE = Convert.ToString(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToDateTime(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.TBLPRODUCTID = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.ISDISPLAY_PRICE = Convert.ToDecimal(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.SALESPRICE = Convert.ToDecimal(values[11]);


            if (values[12].GetType() != typeof(System.DBNull))
                entity.PRODUCTNAME = Convert.ToString(values[12]);
            if (values[13].GetType() != typeof(System.DBNull))
                entity.SUBCATEGORYNAME = Convert.ToString(values[13]);
            if (values[14].GetType() != typeof(System.DBNull))
                entity.CATEGORYNAME = Convert.ToString(values[14]);
            if (values[15].GetType() != typeof(System.DBNull))
                entity.PROFAMILYNAME = Convert.ToString(values[15]);
            if (values[16].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[16]);
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
