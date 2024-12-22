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
	public class SP_GET_FF_RSO_EARNING : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Decimal ID { get; set; }
		[DataMember]
		public Decimal WORKING_DAY { get; set; }
		[DataMember]
		public Decimal FIXED_SALARY { get; set; }
		[DataMember]
		public String VARIABLE_COMMISSION { get; set; }
		[DataMember]
		public Decimal INCENTIVE { get; set; }
		[DataMember]
		public Decimal ADDITIONAL_INCENTIVE { get; set; }
		[DataMember]
		public Decimal OTHERS { get; set; }
		[DataMember]
		public Decimal TOTAL_EARNING { get; set; }
		[DataMember]
		public String BANK_NAME { get; set; }
		[DataMember]
		public String BANK_AC { get; set; }
		[DataMember]
		public String VENDOR { get; set; }
		[DataMember]
		public String RSO_CODE { get; set; }
		[DataMember]
		public String MONTH_CODE { get; set; }




		public object MapToEntity(object[] values)
		{
			SP_GET_FF_RSO_EARNING entity = new SP_GET_FF_RSO_EARNING();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.ID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.WORKING_DAY = Convert.ToDecimal(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.FIXED_SALARY = Convert.ToDecimal(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.VARIABLE_COMMISSION = Convert.ToString(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.INCENTIVE = Convert.ToDecimal(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.ADDITIONAL_INCENTIVE = Convert.ToDecimal(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.OTHERS = Convert.ToDecimal(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.TOTAL_EARNING = Convert.ToDecimal(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.BANK_NAME = Convert.ToString(values[8]);

			if (values[9].GetType() != typeof(System.DBNull))
				entity.BANK_AC = Convert.ToString(values[9]);

			if (values[10].GetType() != typeof(System.DBNull))
				entity.VENDOR = Convert.ToString(values[10]);

			if (values[11].GetType() != typeof(System.DBNull))
				entity.RSO_CODE = Convert.ToString(values[11]);

			if (values[12].GetType() != typeof(System.DBNull))
				entity.MONTH_CODE = Convert.ToString(values[12]);



			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}

	}
}
