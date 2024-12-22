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
	public class SP_GET_MTO_VISIT_DATA : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Decimal STATUS_ID { get; set; }

		[DataMember]
		public String STATUS_NAME { get; set; }

		[DataMember]
		public Decimal TOTAL { get; set; }


		public object MapToEntity(object[] values)
		{
			SP_GET_MTO_VISIT_DATA entity = new SP_GET_MTO_VISIT_DATA();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.STATUS_ID = Convert.ToDecimal(values[0]);
			if (values[1].GetType() != typeof(System.DBNull))
				entity.STATUS_NAME = Convert.ToString(values[1]);
			if (values[2].GetType() != typeof(System.DBNull))
				entity.TOTAL = Convert.ToDecimal(values[2]);

			return entity;
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

	}
}
