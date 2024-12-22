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
    public class SP_GET_VISIT_FEEDBACK_STATUS : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String STATUS_DESCRIPTION { get; set; }

		[DataMember]
		public String STATUS_DESCRIPTION_BAN { get; set; }


		public object MapToEntity(object[] values)
        {
            SP_GET_VISIT_FEEDBACK_STATUS entity = new SP_GET_VISIT_FEEDBACK_STATUS();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.STATUS_DESCRIPTION = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.STATUS_DESCRIPTION_BAN = Convert.ToString(values[2]);


			return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
