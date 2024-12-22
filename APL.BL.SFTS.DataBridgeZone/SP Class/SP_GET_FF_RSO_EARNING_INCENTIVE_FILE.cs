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
	public class SP_GET_FF_RSO_EARNING_INCENTIVE_FILE : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Decimal ID { get; set; }
		[DataMember]
		public String RSOCODE { get; set; }
		[DataMember]
		public String BASE_YEAR_MONTH { get; set; }		
		[DataMember]
		public String TYPE { get; set; }
		[DataMember]
		public Decimal INCENTIVE { get; set; }
		[DataMember]
		public String REMARKS { get; set; }		
		[DataMember]
		public Decimal UPLOADBY { get; set; }
		[DataMember]
		public Decimal ROW_COUNT { get; set; }
		[DataMember]
		public Decimal TOTAL_SALARY_VALUE { get; set; }

		public object MapToEntity(object[] values)
		{

			SP_GET_FF_RSO_EARNING_INCENTIVE_FILE entity = new SP_GET_FF_RSO_EARNING_INCENTIVE_FILE();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.ID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.RSOCODE = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.BASE_YEAR_MONTH = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.TYPE = Convert.ToString(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.INCENTIVE = Convert.ToDecimal(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.REMARKS = Convert.ToString(values[5]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.ROW_COUNT = Convert.ToDecimal(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.TOTAL_SALARY_VALUE = Convert.ToDecimal(values[8]);




			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}



	}



	[Serializable()]
	[DataContract]
	public class SP_GET_FF_RSO_EARNING_INCENTIVE : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Decimal ID { get; set; }
		[DataMember]
		public String RSOCODE { get; set; }
		[DataMember]
		public String BASE_YEAR_MONTH { get; set; }
		[DataMember]
		public String TYPE { get; set; }
		[DataMember]
		public Decimal INCENTIVE { get; set; }
		[DataMember]
		public String REMARKS { get; set; }
		[DataMember]
		public Decimal UPLOADBY { get; set; }
		[DataMember]
		public Decimal ROW_COUNT { get; set; }
		[DataMember]
		public Decimal TOTAL_SALARY_VALUE { get; set; }

		public object MapToEntity(object[] values)
		{

			SP_GET_FF_RSO_EARNING_INCENTIVE entity = new SP_GET_FF_RSO_EARNING_INCENTIVE();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.ID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.RSOCODE = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.BASE_YEAR_MONTH = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.TYPE = Convert.ToString(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.INCENTIVE = Convert.ToDecimal(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.REMARKS = Convert.ToString(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.UPLOADBY = Convert.ToDecimal(values[6]);


			if (values[7].GetType() != typeof(System.DBNull))
				entity.ROW_COUNT = Convert.ToDecimal(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.TOTAL_SALARY_VALUE = Convert.ToDecimal(values[8]);



			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}



	}
}
