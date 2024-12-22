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
    public class SP_GET_RETAILER_GPS_LOCcls : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public Decimal RETAILER_GPSINFO_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public Decimal ROUTE_ID { get; set; }

        [DataMember]
        public String ROUTENAME { get; set; }

        [DataMember]
        public Decimal RET_GPS_LATITUDE_VALUE { get; set; }

        [DataMember]
        public Decimal RET_GPS_LONGITUDE_VALUE { get; set; }

        [DataMember]
        public DateTime RET_GPS_CREATE_DATE { get; set; }

        [DataMember]
        public Decimal Is_Pending { get; set; }

        [DataMember]
        public Decimal Is_Active { get; set; }

        [DataMember]
        public String IsPendingStr { get; set; }

        [DataMember]
        public String IsActiveStr { get; set; }

        [DataMember]
        public Decimal ROW_NUMBER { get; set; }

        [DataMember]
        public Decimal TOTAL_RECORD { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_GPS_LOCcls entity = new SP_GET_RETAILER_GPS_LOCcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_GPSINFO_ID = Convert.ToDecimal(values[0]);
            
            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.ROUTE_ID = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.ROUTENAME = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.RET_GPS_LATITUDE_VALUE = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.RET_GPS_LONGITUDE_VALUE = Convert.ToDecimal(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.RET_GPS_CREATE_DATE = Convert.ToDateTime(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.Is_Pending = Convert.ToDecimal(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.Is_Active = Convert.ToDecimal(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[14]);

            if (values[15].GetType() != typeof(System.DBNull))
                entity.TOTAL_RECORD = Convert.ToDecimal(values[15]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}