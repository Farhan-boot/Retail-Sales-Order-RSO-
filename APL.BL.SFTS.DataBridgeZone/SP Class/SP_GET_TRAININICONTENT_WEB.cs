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
    public class SP_GET_TRAININICONTENT_WEB : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public decimal TRAINING_ID { get; set; }
        [DataMember]
        public string CONTENT_NAME { get; set; }
        [DataMember]
        public string TRAINING_NAME { get; set; }
        [DataMember]
        public string UPLOADED_DATE { get; set; }

        [DataMember]
        public string OTHER_LINK { get; set; }
        [DataMember]
        public string UPLOADED_FILE_LINK { get; set; }
        [DataMember]
        public decimal IS_ACTIVE { get; set; }
        [DataMember]
        public string IS_ACTIVE_STR { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_TRAININICONTENT_WEB entity = new SP_GET_TRAININICONTENT_WEB();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.TRAINING_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.CONTENT_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.TRAINING_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.UPLOADED_DATE = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.OTHER_LINK = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.UPLOADED_FILE_LINK = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToDecimal(values[6]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE_STR = Convert.ToDecimal(values[6]) == 1 ? "Active" : "Inactive";

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
