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
    public class SP_GET_COMMISSION_STRUCTURE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal COMMISSION_ID { get; set; }

        [DataMember]
        public String COMMISSION_NAME { get; set; }

        [DataMember]
        public String COMMISSION_DETAIL { get; set; }

        [DataMember]
        public String START_DATE { get; set; }

        [DataMember]
        public String END_DATE { get; set; }

        [DataMember]
        public String DISPLAY_DATE_FROM { get; set; }

        [DataMember]
        public String DISPLAY_DATE_TO { get; set; }

        [DataMember]
        public Decimal TARGET_TYPE { get; set; }

        [DataMember]
        public String TARGET_TYPE_NAME { get; set; }

        [DataMember]
        public String IS_TO_ALL { get; set; }

        [DataMember]
        public Decimal STAFF_ROLE_ID { get; set; }

        [DataMember]
        public String STAFF_ROLE { get; set; }

        [DataMember]
        public String IS_ACTIVE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_COMMISSION_STRUCTURE entity = new SP_GET_COMMISSION_STRUCTURE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.COMMISSION_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.COMMISSION_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.COMMISSION_DETAIL = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.START_DATE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.END_DATE = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.DISPLAY_DATE_FROM = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.DISPLAY_DATE_TO = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.TARGET_TYPE = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.TARGET_TYPE_NAME = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.IS_TO_ALL = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.STAFF_ROLE_ID = Convert.ToDecimal(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.STAFF_ROLE = Convert.ToString(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToString(values[12]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }      
}