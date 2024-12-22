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
    public class SP_GET_ROT_WISE_RET_SCHDLcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        /// <summary>
        /// CODE => RETAILER CODE
        /// </summary>
        [DataMember]
        public String RETAILER_CODE { get; set; }

        /// <summary>
        /// NAME => RETAILER NAME
        /// </summary>
        [DataMember]
        public String RETAILER_NAME { get; set; }
       
        [DataMember]
        public Decimal RETAILER_TYPE { get; set; }

        /// <summary>
        /// ADDRESS => RETAILER ADDRESS
        /// </summary>
        [DataMember]
        public String RETAILER_ADDRESS { get; set; }

        /// <summary>
        /// TRANMOBILENO => RETAILER TRANMOBILENO
        /// </summary>
        [DataMember]
        public String RETAILER_TRAN_MOBILE_NO { get; set; }

        /// <summary>
        /// VISITDATE => RETAILER VISITDATE
        /// </summary>
        [DataMember]
        public DateTime RETAILER_VISIT_DATE { get; set; }

         [DataMember]
        public Decimal RETAILER_ROUTEID { get; set; }
      
        public object MapToEntity(object[] values)
        {
            SP_GET_ROT_WISE_RET_SCHDLcls entity = new SP_GET_ROT_WISE_RET_SCHDLcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILER_TYPE = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_ADDRESS = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.RETAILER_TRAN_MOBILE_NO = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.RETAILER_VISIT_DATE = Convert.ToDateTime(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.RETAILER_ROUTEID = Convert.ToDecimal(values[7]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
