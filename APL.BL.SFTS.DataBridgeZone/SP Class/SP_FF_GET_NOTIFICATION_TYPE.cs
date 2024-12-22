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
	public class SP_FF_GET_NOTIFICATION_TYPE : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Decimal NOTIFICATION_TYPE_ID { get; set; }

		[DataMember]
		public String NOTIFICATION_TYPE_NAME { get; set; }


		public object MapToEntity(object[] values)
		{
			SP_FF_GET_NOTIFICATION_TYPE entity = new SP_FF_GET_NOTIFICATION_TYPE();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.NOTIFICATION_TYPE_ID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.NOTIFICATION_TYPE_NAME = Convert.ToString(values[1]);

			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
