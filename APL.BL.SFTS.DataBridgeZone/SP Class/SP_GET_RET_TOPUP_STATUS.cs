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
    public class SP_GET_RET_TOPUP_STATUS : ObjectMakerFromOracleSP.ISpClassEntity
    {
       
        [DataMember]
        public String OPENING_BALANCE_DATE { get; set; }
   
        [DataMember]
        public Decimal BALANCE_AMOUNT { get; set; }
         
        [DataMember]
        public Decimal AVG_SALES_AMOUNT { get; set; }
         
        
        public object MapToEntity(object[] values)
        {
            SP_GET_RET_TOPUP_STATUS entity = new SP_GET_RET_TOPUP_STATUS();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.OPENING_BALANCE_DATE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.BALANCE_AMOUNT = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.AVG_SALES_AMOUNT = Convert.ToDecimal(values[2]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
