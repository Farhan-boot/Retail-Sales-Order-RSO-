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
    public class SP_FF_TRAINING_SECTION_LIST : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String CONTENT_NAME { get; set; }

        [DataMember]
        public String TRAINING_NAME { get; set; }

        [DataMember]
        public String UPLOADED_DATE { get; set; }

        [DataMember]
        public String OTHER_LINK { get; set; }

        [DataMember]
        public String UPLOADED_FILE_LINK { get; set; }

        [DataMember]
        public Decimal IS_READ { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_FF_TRAINING_SECTION_LIST entity = new SP_FF_TRAINING_SECTION_LIST();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);

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
                entity.IS_READ = Convert.ToDecimal(values[6]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
