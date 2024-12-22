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
	public class SP_GET_RSO_COMMISSION_DETAILS : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public String CAMPAIGN_NAME { get; set; }

		[DataMember]
		public String KPI { get; set; }

		[DataMember]
		public Decimal TARGET { get; set; }

		[DataMember]
		public Decimal ACHIEVEMENT { get; set; }

		[DataMember]
		public Decimal INCENTIVE { get; set; }

		[DataMember]
		public String STATUS { get; set; }

		[DataMember]
		public String BANK_NAME { get; set; }

		[DataMember]
		public String BANK_AC { get; set; }

		[DataMember]
		public String VENDOR { get; set; }



		public object MapToEntity(object[] values)
		{
			SP_GET_RSO_COMMISSION_DETAILS entity = new SP_GET_RSO_COMMISSION_DETAILS();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.CAMPAIGN_NAME = Convert.ToString(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.KPI = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.TARGET = Convert.ToDecimal(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.ACHIEVEMENT = Convert.ToDecimal(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.INCENTIVE = Convert.ToDecimal(values[4]);


			if (values[5].GetType() != typeof(System.DBNull))
				entity.STATUS = Convert.ToString(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.BANK_NAME = Convert.ToString(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.BANK_AC = Convert.ToString(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.VENDOR = Convert.ToString(values[8]);



			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}

	}
}
