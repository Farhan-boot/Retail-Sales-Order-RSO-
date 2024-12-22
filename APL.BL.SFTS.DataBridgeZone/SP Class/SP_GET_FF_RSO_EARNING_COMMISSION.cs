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
	public class SP_GET_FF_RSO_EARNING_COMMISSION_FILE : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Decimal UPLOAD_CODE { get; set; }
		[DataMember]
		public String ROSCODE { get; set; }
		[DataMember]
		public Decimal TARGET { get; set; }
		[DataMember]
		public Decimal ACHIVEMENT { get; set; }
		[DataMember]
		public Decimal INCENTIVE { get; set; }
		[DataMember]
		public String SALAY_YEAR_MONTH { get; set; }
		[DataMember]
		public String CAMP_NAME { get; set; }
		[DataMember]
		public String KPI { get; set; }		
		[DataMember]
		public String BANK_NAME { get; set; }
		[DataMember]
		public String BANK_AC { get; set; }
		[DataMember]
		public String VENDOR { get; set; }
		[DataMember]
		public String STATUS { get; set; }
		[DataMember]
		public Decimal UPLOADBY { get; set; }
		[DataMember]
		public Decimal ROW_COUNT { get; set; }
		[DataMember]
		public Decimal TOTAL_COMMISSION_VALUE { get; set; }

		public object MapToEntity(object[] values)
		{

			SP_GET_FF_RSO_EARNING_COMMISSION_FILE entity = new SP_GET_FF_RSO_EARNING_COMMISSION_FILE();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.UPLOAD_CODE = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.ROSCODE = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.TARGET = Convert.ToDecimal(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.ACHIVEMENT = Convert.ToDecimal(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.INCENTIVE = Convert.ToDecimal(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.SALAY_YEAR_MONTH = Convert.ToString(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.CAMP_NAME = Convert.ToString(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.KPI = Convert.ToString(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.BANK_NAME = Convert.ToString(values[8]);

			if (values[9].GetType() != typeof(System.DBNull))
				entity.BANK_AC = Convert.ToString(values[9]);

			if (values[10].GetType() != typeof(System.DBNull))
				entity.VENDOR = Convert.ToString(values[10]);

			if (values[11].GetType() != typeof(System.DBNull))
				entity.STATUS = Convert.ToString(values[11]);

			if (values[12].GetType() != typeof(System.DBNull))
				entity.UPLOADBY = Convert.ToDecimal(values[12]);

			if (values[13].GetType() != typeof(System.DBNull))
				entity.ROW_COUNT = Convert.ToDecimal(values[13]);

			if (values[14].GetType() != typeof(System.DBNull))
				entity.TOTAL_COMMISSION_VALUE = Convert.ToDecimal(values[14]);

			


			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}


	}



	[Serializable()]
	[DataContract]
	public class SP_GET_FF_RSO_EARNING_COMMISSION : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Decimal UPLOAD_CODE { get; set; }
		[DataMember]
		public String ROSCODE { get; set; }
		[DataMember]
		public Decimal TARGET { get; set; }
		[DataMember]
		public Decimal ACHIVEMENT { get; set; }
		[DataMember]
		public Decimal INCENTIVE { get; set; }
		[DataMember]
		public String SALAY_YEAR_MONTH { get; set; }
		[DataMember]
		public String CAMP_NAME { get; set; }
		[DataMember]
		public String KPI { get; set; }
		[DataMember]
		public String BANK_NAME { get; set; }
		[DataMember]
		public String BANK_AC { get; set; }
		[DataMember]
		public String VENDOR { get; set; }
		[DataMember]
		public String STATUS { get; set; }
		[DataMember]
		public Decimal UPLOADBY { get; set; }
		[DataMember]
		public Decimal ROW_COUNT { get; set; }
		[DataMember]
		public Decimal TOTAL_COMMISSION_VALUE { get; set; }

		public object MapToEntity(object[] values)
		{

			SP_GET_FF_RSO_EARNING_COMMISSION entity = new SP_GET_FF_RSO_EARNING_COMMISSION();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.UPLOAD_CODE = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.ROSCODE = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.TARGET = Convert.ToDecimal(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.ACHIVEMENT = Convert.ToDecimal(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.INCENTIVE = Convert.ToDecimal(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.SALAY_YEAR_MONTH = Convert.ToString(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.CAMP_NAME = Convert.ToString(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.KPI = Convert.ToString(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.BANK_NAME = Convert.ToString(values[8]);

			if (values[9].GetType() != typeof(System.DBNull))
				entity.BANK_AC = Convert.ToString(values[9]);

			if (values[10].GetType() != typeof(System.DBNull))
				entity.VENDOR = Convert.ToString(values[10]);

			if (values[11].GetType() != typeof(System.DBNull))
				entity.STATUS = Convert.ToString(values[11]);

			if (values[12].GetType() != typeof(System.DBNull))
				entity.UPLOADBY = Convert.ToDecimal(values[12]);

			if (values[13].GetType() != typeof(System.DBNull))
				entity.ROW_COUNT = Convert.ToDecimal(values[13]);

			if (values[14].GetType() != typeof(System.DBNull))
				entity.TOTAL_COMMISSION_VALUE = Convert.ToDecimal(values[14]);




			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}


	}
}
