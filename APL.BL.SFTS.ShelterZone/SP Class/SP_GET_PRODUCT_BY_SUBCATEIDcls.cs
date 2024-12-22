﻿using System;
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
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    
    
    
    }


}
