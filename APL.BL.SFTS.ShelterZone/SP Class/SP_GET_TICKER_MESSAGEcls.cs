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
    public class SP_GET_TICKER_MESSAGEcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        
        [DataMember]
        public Decimal TICKER_MESSAGE_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public String MESSAGE_NOTE { get; set; }
              
        public object MapToEntity(object[] values)
        {
            SP_GET_TICKER_MESSAGEcls entity = new SP_GET_TICKER_MESSAGEcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.TICKER_MESSAGE_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.MESSAGE_NOTE = Convert.ToString(values[2]);            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
       
}
