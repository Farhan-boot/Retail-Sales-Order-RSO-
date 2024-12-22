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
    public class SP_GET_RETAILER_DASHBOARD_INFO : ObjectMakerFromOracleSP.ISpClassEntity
    {       
        [DataMember]
        public Decimal TOTAL_SOLD_LAST_MONTH { get; set; }

        [DataMember]
        public Decimal TOTAL_SOLD_CURRENT_MONTH { get; set; }

        [DataMember]
        public Decimal TOTAL_SAF_PANDING { get; set; }

        [DataMember]
        public String LAST_LIFTING { get; set; }

        [DataMember]
        public Decimal LAST_MONTH_SIM_SOLD { get; set; }

        [DataMember]
        public Decimal CURRENT_MONTH_SIM_SOLD { get; set; }

        [DataMember]
        public Decimal CURRENT_SIM_STOCK { get; set; }

        [DataMember]
        public Decimal LAST_MONTH_ITOPUP { get; set; }

        [DataMember]
        public Decimal CURRENT_MONTH_ITOPUP { get; set; }

        [DataMember]
        public Decimal CURRENT_ITOPUP_BALANCE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_DASHBOARD_INFO entity = new SP_GET_RETAILER_DASHBOARD_INFO();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.TOTAL_SOLD_LAST_MONTH = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TOTAL_SOLD_CURRENT_MONTH = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.TOTAL_SAF_PANDING = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.LAST_LIFTING = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.LAST_MONTH_SIM_SOLD = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.CURRENT_MONTH_SIM_SOLD = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.CURRENT_SIM_STOCK = Convert.ToDecimal(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.LAST_MONTH_ITOPUP = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.CURRENT_MONTH_ITOPUP = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.CURRENT_ITOPUP_BALANCE = Convert.ToDecimal(values[9]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }      
}
