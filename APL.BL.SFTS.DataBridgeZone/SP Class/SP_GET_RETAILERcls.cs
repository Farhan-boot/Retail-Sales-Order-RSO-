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
    public class SP_GET_RETAILERcls : ObjectMakerFromOracleSP.ISpClassEntity
    { 
        [DataMember]
        public Decimal RETAILER_ID { get; set; } 
       
        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public String RETAILER_NAME_CODE { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public Decimal RETAILERTYPE { get; set; }
        
        [DataMember]
        public char ENABLED { get; set; }
        
        [DataMember]
        public char SIMSELLER { get; set; }

        [DataMember]
        public char SCARDSELLER { get; set; }

        [DataMember]
        public char ITOPUPSELLER { get; set; }
        
        [DataMember]
        public Decimal ROUTE_ID { get; set; }

        //       SCARDSELLER ITOPUPSELLER
        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILERcls entity = new SP_GET_RETAILERcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME_CODE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.RETAILERTYPE = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.ENABLED = Convert.ToChar(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.SIMSELLER = Convert.ToChar(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.SCARDSELLER = Convert.ToChar(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.ITOPUPSELLER = Convert.ToChar(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.ROUTE_ID = Convert.ToDecimal(values[10]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
