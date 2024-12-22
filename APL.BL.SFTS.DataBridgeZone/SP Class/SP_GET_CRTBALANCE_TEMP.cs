using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.SP_Class
{
    [Serializable()]
    [DataContract]
    public class SP_GET_CRTBALANCE_TEMP : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public decimal CRTL_BALANCE_ID { get; set; }

        [DataMember]
        public string RETAILER_CODE { get; set; }

        [DataMember]
        public string DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public string PRODUCT_NAME { get; set; }

        [DataMember]
        public decimal SATURDAY { get; set; }
        [DataMember]
        public decimal SUNDAY { get; set; }
        [DataMember]
        public decimal MONDAY { get; set; }
        [DataMember]
        public decimal TUESDAY { get; set; }
        [DataMember]
        public decimal WEDNESDAY { get; set; }
        [DataMember]
        public decimal THURSDAY { get; set; }
        [DataMember]
        public decimal FRIDAY { get; set; }
        [DataMember]
        public string FROM_DATE { get; set; }
        [DataMember]
        public string TO_DATE { get; set; }

        [DataMember]
        public string RETAILER_NAME { get; set; }

        [DataMember]
        public string DISTRIBUTOR_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_CRTBALANCE_TEMP entity = new SP_GET_CRTBALANCE_TEMP();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.CRTL_BALANCE_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.PRODUCT_NAME = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.SATURDAY = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.SUNDAY = Convert.ToDecimal(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.MONDAY = Convert.ToDecimal(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.TUESDAY = Convert.ToDecimal(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.WEDNESDAY = Convert.ToDecimal(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.THURSDAY = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.FRIDAY = Convert.ToDecimal(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.FROM_DATE = Convert.ToString(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.TO_DATE = Convert.ToString(values[12]);



            if (values[13].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[14]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
