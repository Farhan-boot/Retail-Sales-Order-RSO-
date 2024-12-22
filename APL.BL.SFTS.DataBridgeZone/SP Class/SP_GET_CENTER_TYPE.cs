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
    public class SP_GET_CENTER_TYPE : ObjectMakerFromOracleSP.ISpClassEntity
    {     
        [DataMember]
        public Decimal CENTER_TYPE_ID { get; set; }

        [DataMember]
        public String CENTER_TYPE_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_CENTER_TYPE entity = new SP_GET_CENTER_TYPE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.CENTER_TYPE_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CENTER_TYPE_NAME = Convert.ToString(values[1]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}