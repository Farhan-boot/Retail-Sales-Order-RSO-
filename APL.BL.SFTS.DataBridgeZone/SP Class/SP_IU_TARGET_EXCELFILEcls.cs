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
    public class SP_IU_TARGET_EXCELFILEcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public DateTime UPLOAD_DATE { get; set; }

        [DataMember]
        public String FILE_LOCATION { get; set; }

        [DataMember]
        public Decimal TARGET_AMOUNT { get; set; }

        [DataMember]
        public DateTime TO_DATE { get; set; }

        [DataMember]
        public Decimal UPDATE_BY { get; set; }

        [DataMember]
        public DateTime UPDATE_DATE { get; set; }

        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public Decimal CREATE_BY { get; set; }

        [DataMember]
        public Decimal AMOUNT_TYPEID { get; set; }

        [DataMember]
        public Decimal PRODUCT_FAMILYID { get; set; }

        [DataMember]
        public DateTime CREATE_DATE { get; set; }

        [DataMember]
        public DateTime DOWNLOAD_DATE { get; set; }

        [DataMember]
        public Decimal ISACTIVE { get; set; }

        [DataMember]
        public DateTime FROM_DATE { get; set; }

        [DataMember]
        public Decimal CHANNELID { get; set; }

         [DataMember]
        public Decimal COMMISSIONID{ get; set; } 
        
       [DataMember]
         public String FILE_NAME { get; set; } 

        public object MapToEntity(object[] values)
        {
            SP_IU_TARGET_EXCELFILEcls entity = new SP_IU_TARGET_EXCELFILEcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.UPLOAD_DATE = Convert.ToDateTime(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.FILE_LOCATION = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.TARGET_AMOUNT = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.TO_DATE = Convert.ToDateTime(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.CREATE_BY = Convert.ToDecimal(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.AMOUNT_TYPEID = Convert.ToDecimal(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.PRODUCT_FAMILYID = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToDateTime(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.DOWNLOAD_DATE = Convert.ToDateTime(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.ISACTIVE = Convert.ToDecimal(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.FROM_DATE = Convert.ToDateTime(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.CHANNELID = Convert.ToDecimal(values[14]);

            if (values[15].GetType() != typeof(System.DBNull))
                entity.COMMISSIONID = Convert.ToDecimal(values[15]);

            if (values[16].GetType() != typeof(System.DBNull))
                entity.FILE_NAME = Convert.ToString(values[16]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
