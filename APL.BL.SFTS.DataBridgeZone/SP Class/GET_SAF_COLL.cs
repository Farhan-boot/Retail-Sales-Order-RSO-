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
    public class GET_SAF_COLL : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String SAF_DATE { get; set; }

        [DataMember]
        public Decimal SOLD { get; set; }

        [DataMember]
        public Decimal COLLECTED { get; set; }

        [DataMember]
        public Decimal PENDING { get; set; }

		[DataMember]
		public string MSISDN { get; set; }

		[DataMember]
		public string SIM_NUMBER { get; set; }

		[DataMember]
		public string REJECT_REASON { get; set; }

		public object MapToEntity(object[] values)
        {
            GET_SAF_COLL entity = new GET_SAF_COLL();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.SAF_DATE = Convert.ToString(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.SOLD = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.COLLECTED = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.PENDING = Convert.ToDecimal(values[3]);


			if (values[4].GetType() != typeof(System.DBNull))
				entity.MSISDN = values[4].ToString();

			if (values[5].GetType() != typeof(System.DBNull))
				entity.SIM_NUMBER = values[5].ToString();

			if (values[6].GetType() != typeof(System.DBNull))
				entity.REJECT_REASON = values[6].ToString();

			


			return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
