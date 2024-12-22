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
	public class SP_GET_FF_RSO_EARNING_SALARY : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Decimal UPLOAD_CODE { get; set; }
		[DataMember]
		public String ROSCODE { get; set; }
		[DataMember]
		public String BANK_NAME { get; set; }
		[DataMember]
		public String BANK_AC { get; set; }
		[DataMember]
		public String DOB { get; set; }
		[DataMember]
		public String JOIN_DATE { get; set; }
		[DataMember]
		public Decimal WORKING_DAY { get; set; }
		[DataMember]
		public String SALAY_YEAR_MONTH { get; set; }
		[DataMember]
		public Decimal TOTAL_SALARY { get; set; }
		[DataMember]
		public String VENDOR { get; set; }
		[DataMember]
		public String STATUS { get; set; }
		[DataMember]
		public Decimal TOTAL_ROW_COUNT { get; set; }
		[DataMember]
		public Decimal TOTAL_SALARY_VALUE { get; set; }


		public object MapToEntity(object[] values)
		{

			SP_GET_FF_RSO_EARNING_SALARY entity = new SP_GET_FF_RSO_EARNING_SALARY();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.UPLOAD_CODE = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.ROSCODE = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.BANK_NAME = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.BANK_AC = Convert.ToString(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.DOB = Convert.ToString(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.JOIN_DATE = Convert.ToString(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.WORKING_DAY = Convert.ToDecimal(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.SALAY_YEAR_MONTH = Convert.ToString(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.TOTAL_SALARY = Convert.ToDecimal(values[8]);

			if (values[9].GetType() != typeof(System.DBNull))
				entity.VENDOR = Convert.ToString(values[9]);

			if (values[10].GetType() != typeof(System.DBNull))
				entity.STATUS = Convert.ToString(values[10]);

			if (values[11].GetType() != typeof(System.DBNull))
				entity.TOTAL_ROW_COUNT = Convert.ToDecimal(values[11]);

			if (values[12].GetType() != typeof(System.DBNull))
				entity.TOTAL_SALARY_VALUE = Convert.ToDecimal(values[12]);
			/*
			if (values[11].GetType() != typeof(System.DBNull))
				entity.UPLOADBY = Convert.ToDecimal(values[11]);
				*/




			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
