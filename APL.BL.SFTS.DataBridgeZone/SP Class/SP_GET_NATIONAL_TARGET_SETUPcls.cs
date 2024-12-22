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
    public class SP_GET_NATIONAL_TARGET_SETUPcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal NATIONAL_TARGET_SETUP_ID { get; set; }
        [DataMember]
        public Decimal COMMISSION_GROUP_ID { get; set; }
        [DataMember]
        public String COM_GRP_NAME { get; set; }
        
        [DataMember]
        public String SETUP_NAME { get; set; }
        [DataMember]
        public DateTime START_DATE { get; set; }
        [DataMember]
        public DateTime END_DATE { get; set; }
        [DataMember]
        public DateTime MONTH_DATE { get; set; }
        [DataMember]
        public DateTime FREEZE_DATE { get; set; }
       
        [DataMember]
        public Decimal IS_REUSABLE { get; set; }
        [DataMember]
        public Decimal CREATE_BY { get; set; }
        [DataMember]
        public DateTime CREATE_DATE { get; set; }
        [DataMember]
        public Decimal UPDATE_BY { get; set; }
        [DataMember]
        public DateTime UPDATE_DATE { get; set; }
        [DataMember]
        public Decimal ROW_NUMBER { get; set; }

        [DataMember]
        public Decimal TOTAL_ROW { get; set; }
     

        public object MapToEntity(object[] values)
        {
            SP_GET_NATIONAL_TARGET_SETUPcls entity = new SP_GET_NATIONAL_TARGET_SETUPcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.NATIONAL_TARGET_SETUP_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.COMMISSION_GROUP_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.COM_GRP_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.SETUP_NAME = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.START_DATE = Convert.ToDateTime(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.END_DATE = Convert.ToDateTime(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.MONTH_DATE = Convert.ToDateTime(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.FREEZE_DATE = Convert.ToDateTime(values[7]);           

            if (values[8].GetType() != typeof(System.DBNull))
                entity.IS_REUSABLE = Convert.ToDecimal(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.CREATE_BY = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToDateTime(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.TOTAL_ROW = Convert.ToDecimal(values[14]);
           
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
