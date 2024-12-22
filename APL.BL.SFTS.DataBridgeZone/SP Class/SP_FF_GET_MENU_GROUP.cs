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
    public class SP_FF_GET_MENU_GROUP : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal GROUP_ID { get; set; }

        [DataMember]
        public String GROUP_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_FF_GET_MENU_GROUP entity = new SP_FF_GET_MENU_GROUP();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.GROUP_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.GROUP_NAME = Convert.ToString(values[1]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
