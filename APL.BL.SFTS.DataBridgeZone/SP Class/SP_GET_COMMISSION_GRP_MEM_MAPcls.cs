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
    public class SP_GET_COMMISSION_GRP_MEM_MAPcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal COMMISSION_GROUP_MEMBER_MAPID { get; set; }
        [DataMember]
        public Decimal COMMISSION_GROUP_ID { get; set; }
        [DataMember]
        public String COMMISSION_GROUP_NAME { get; set; }
        [DataMember]
        public String MEMBER_NAME { get; set; }
        [DataMember]
        public String EXCEL_COLUMN_NAME { get; set; }
        [DataMember]
        public Decimal EXCEL_COLUMN_NO { get; set; }
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
        
        [DataMember]
        public Decimal SERIAL_NO { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_COMMISSION_GRP_MEM_MAPcls entity = new SP_GET_COMMISSION_GRP_MEM_MAPcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.COMMISSION_GROUP_MEMBER_MAPID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.COMMISSION_GROUP_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.COMMISSION_GROUP_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.MEMBER_NAME = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.EXCEL_COLUMN_NAME = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.EXCEL_COLUMN_NO = Convert.ToDecimal(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.CREATE_BY = Convert.ToDecimal(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToDateTime(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.TOTAL_ROW = Convert.ToDecimal(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.SERIAL_NO = Convert.ToDecimal(values[12]);

            return entity;
        }
         public void Dispose()
         {
             throw new NotImplementedException();
         }
    }
}
