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
	public class SP_GET_NOTIFICATIONS : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Int32 ID { get; set; }

		[DataMember]
		public Int16 TYPE { get; set; }

		[DataMember]
		public String FROM_DATE { get; set; }

		[DataMember]
		public String TO_DATE { get; set; }

		[DataMember]
		public String TITLE { get; set; }

		[DataMember]
		public String DISCRIPTION { get; set; }

		[DataMember]
		public String ISACTIVE { get; set; }

		//[DataMember]
		//public byte[] NOTIFICATION_IMG { get; set; }

		[DataMember]
		public String NOTIFICATION_IMG { get; set; }

		[DataMember]
		public String ISREAD { get; set; }

		[DataMember]
		public string IMAGE_LINK { get; set; }


		public object MapToEntity(object[] values)
		{
			SP_GET_NOTIFICATIONS entity = new SP_GET_NOTIFICATIONS();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.ID = Convert.ToInt16(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.TYPE = Convert.ToInt16(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.FROM_DATE = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.TO_DATE = Convert.ToString(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.TITLE = Convert.ToString(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.DISCRIPTION = Convert.ToString(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.ISACTIVE = Convert.ToString(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.NOTIFICATION_IMG = Convert.ToString(values[7]);


			if (values[8].GetType() != typeof(System.DBNull))
				entity.ISREAD = Convert.ToString(values[8]);

			if (values[9].GetType() != typeof(System.DBNull))
				entity.IMAGE_LINK = Convert.ToString(values[9]);



			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}


	}
}
