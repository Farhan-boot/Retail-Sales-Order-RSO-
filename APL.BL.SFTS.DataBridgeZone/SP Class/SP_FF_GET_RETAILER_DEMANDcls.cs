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
	public class SP_FF_GET_RETAILER_DEMAND : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public String D_DATE { get; set; }

		[DataMember]
		public String RETAILER_CODE { get; set; }

		[DataMember]
		public String ITOPUP_NUMBER { get; set; }

		[DataMember]
		public String PRODUCT_CODE { get; set; }

		[DataMember]
		public String QTY { get; set; }




		public object MapToEntity(object[] values)
		{
			SP_FF_GET_RETAILER_DEMAND entity = new SP_FF_GET_RETAILER_DEMAND();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.D_DATE = Convert.ToString(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.RETAILER_CODE = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.ITOPUP_NUMBER = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.PRODUCT_CODE = Convert.ToString(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.QTY = Convert.ToString(values[4]);



			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
