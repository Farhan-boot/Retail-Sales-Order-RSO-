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
    public class SP_GET_PRODUCT_BY_SUBCATEIDcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
       
        [DataMember]
        public Decimal PRODUCT_ID { get; set; }


        [DataMember]
        public String PRODUCT_CODE { get; set; }


        [DataMember]
        public String PRODUCT_NAME { get; set; }

        [DataMember]
        public String DESCRIPTION { get; set; }

        [DataMember]
        public Decimal SIMTYPE { get; set; }

        [DataMember]
        public Decimal SUBCATEGORYID { get; set; }

         [DataMember]
        public String FAM_NAME { get; set; }

         [DataMember]
        public String CATEGORY_NAME { get; set; }

         [DataMember]
         public String SUBCATEGORY_NAME{ get; set; }

        [DataMember]
        public Decimal FACEVALUE { get; set; }

        [DataMember]
        public char SERIALIZEDYN { get; set; }
        
        public object MapToEntity(object[] values)
        {
            SP_GET_PRODUCT_BY_SUBCATEIDcls entity = new SP_GET_PRODUCT_BY_SUBCATEIDcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.PRODUCT_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.PRODUCT_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.PRODUCT_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DESCRIPTION = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.SIMTYPE = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.SUBCATEGORYID = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.FAM_NAME = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.CATEGORY_NAME = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.SUBCATEGORY_NAME = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.FACEVALUE = Convert.ToDecimal(values[9]);
            if ( values[10]!=null && values[10].GetType() != typeof(System.DBNull))
                entity.SERIALIZEDYN = Convert.ToChar(values[10]);
            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
