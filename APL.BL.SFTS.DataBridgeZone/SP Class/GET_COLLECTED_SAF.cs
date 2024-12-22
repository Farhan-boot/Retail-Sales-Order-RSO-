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
    public class GET_COLLECTED_SAF : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public DateTime COL_DATE { get; set; }

        [DataMember]
        public String RSO_NAME { get; set; }

        [DataMember]
        public Decimal COL_QTY { get; set; }


        public object MapToEntity(object[] values)
        {
            GET_COLLECTED_SAF entity = new GET_COLLECTED_SAF();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.COL_DATE = Convert.ToDateTime(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.COL_QTY = Convert.ToDecimal(values[2]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}