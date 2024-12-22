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
    public class SP_GET_RETAILER_TAR_ACHIEVEcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
                                         
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
        public String MONTH_DATE { get; set; }
       
        [DataMember]
        public Decimal TARGET_AMOUNT { get; set; }

        [DataMember]
        public Decimal ACHIVEMENT_AMOUNT { get; set; }

        [DataMember]
        public Decimal COMMISSION_AMOUNT { get; set; }
      
        [DataMember]
        public Decimal PRODUCT_CATEGORY_ID { get; set; } 

        [DataMember]
        public Decimal PRODUCT_CATE_UNIT { get; set; }

        [DataMember]
        public String PRODUCT_CATEGORY_NAME { get; set; }
                      
        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_TAR_ACHIEVEcls entity = new SP_GET_RETAILER_TAR_ACHIEVEcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_BUDGET_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TARGET_SETUP_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_BUDGET_ID = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[4]);
            
            if (values[5].GetType() != typeof(System.DBNull))
                entity.MONTH_DATE = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.TARGET_AMOUNT = Convert.ToDecimal(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.ACHIVEMENT_AMOUNT = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.COMMISSION_AMOUNT = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.PRODUCT_CATEGORY_ID = Convert.ToDecimal(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.PRODUCT_CATE_UNIT = Convert.ToDecimal(values[10]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
