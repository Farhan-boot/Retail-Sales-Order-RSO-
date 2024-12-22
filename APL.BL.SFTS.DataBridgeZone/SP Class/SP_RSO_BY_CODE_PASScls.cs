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
    public class SP_RSO_BY_CODE_PASScls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal RSO_ID { get; set; }
        [DataMember]
        public String RSO_CODE { get; set; }
        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }
        [DataMember]
        public String RSO_NAME { get; set; }
        [DataMember]
        public String RSO_MOBILE { get; set; } //

        [DataMember]
        public String RSO_HANDSET_MOBILE { get; set; }
        //[DataMember]
        //public DateTime MO_ISSUE_DATE { get; set; }
               
        [DataMember]
        public String RSO_PASSWORD { get; set; }

        [DataMember]
        public String RSO_LOGINNAME { get; set; }
           
        [DataMember]
        public DateTime SERVER_DATE { get; set; }
        
        public object MapToEntity(object[] values)
        {
            SP_RSO_BY_CODE_PASScls entity = new SP_RSO_BY_CODE_PASScls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RSO_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RSO_NAME = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RSO_MOBILE = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.RSO_HANDSET_MOBILE = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.RSO_PASSWORD = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.RSO_LOGINNAME = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.SERVER_DATE = Convert.ToDateTime(values[8]);
           
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
