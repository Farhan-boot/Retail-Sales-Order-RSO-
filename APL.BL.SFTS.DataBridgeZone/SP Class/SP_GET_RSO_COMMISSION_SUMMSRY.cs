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
	public   class SP_GET_RSO_COMMISSION_SUMMSRY : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public String VENDOR { get; set; }

		[DataMember]
		public String RSO_CODE { get; set; }

		[DataMember]
		public String COMMISSION_ITEM_NAME { get; set; }

		[DataMember]
		public Decimal AMOUNT { get; set; }

		[DataMember]
		public String MONTH_CODE { get; set; }

		[DataMember]
		public Decimal COMMISSION_MASTERID { get; set; }
		

		public object MapToEntity(object[] values)
		{
			SP_GET_RSO_COMMISSION_SUMMSRY entity = new SP_GET_RSO_COMMISSION_SUMMSRY();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.VENDOR = Convert.ToString(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.RSO_CODE = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.COMMISSION_ITEM_NAME = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.AMOUNT = Convert.ToDecimal(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.MONTH_CODE = Convert.ToString(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.COMMISSION_MASTERID = Convert.ToDecimal(values[5]);



			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}


	}
}
