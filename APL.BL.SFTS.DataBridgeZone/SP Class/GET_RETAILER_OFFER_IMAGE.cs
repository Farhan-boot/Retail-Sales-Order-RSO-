﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.SP_Class
{
    [Serializable()]
    [DataContract]
    public class GET_RETAILER_OFFER_IMAGE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public byte[] IMAGE { get; set; }
     

        public object MapToEntity(object[] values)
        {
            GET_RETAILER_OFFER_IMAGE entity = new GET_RETAILER_OFFER_IMAGE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.IMAGE = (byte[])values[0];
                  
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}