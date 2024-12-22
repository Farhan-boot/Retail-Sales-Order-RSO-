using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.SP_Class
{
	[Serializable()]
	[DataContract]
	public class SP_GET_ADHOC_REPORT : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Decimal ID { get; set; }

		[DataMember]
		public String REPORTNAME { get; set; }

		[DataMember]
		public Decimal REPORTTYPE { get; set; }

		[DataMember]
		public String ISMONTHEND { get; set; }

		[DataMember]
		public String UPLOADDATE { get; set; }


		public object MapToEntity(object[] values)
		{
			SP_GET_ADHOC_REPORT entity = new SP_GET_ADHOC_REPORT();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.ID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.REPORTNAME = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.REPORTTYPE = Convert.ToDecimal(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.ISMONTHEND = Convert.ToString(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.UPLOADDATE = Convert.ToString(values[4]);			


			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}


	}

	[Serializable()]
	[DataContract]
	public class SP_GET_ADHOC_REPORT_DETAILS : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public Decimal REPORT_DETAILSID { get; set; }
		[DataMember]
		public String COLUMN1 { get; set; }
		[DataMember]
		public String COLUMN2 { get; set; }
		[DataMember]
		public String COLUMN3 { get; set; }
		[DataMember]
		public String COLUMN4 { get; set; }
		[DataMember]
		public String COLUMN5 { get; set; }
		[DataMember]
		public String COLUMN6 { get; set; }
		[DataMember]
		public String ISHEADER { get; set; }

		


		public object MapToEntity(object[] values)
		{
			SP_GET_ADHOC_REPORT_DETAILS entity = new SP_GET_ADHOC_REPORT_DETAILS();

			
			if (values[0].GetType() != typeof(System.DBNull))
				entity.REPORT_DETAILSID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.COLUMN1 = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.COLUMN2 = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.COLUMN3 = Convert.ToString(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.COLUMN4 = Convert.ToString(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.COLUMN5 = Convert.ToString(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.COLUMN6 = Convert.ToString(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.ISHEADER = Convert.ToString(values[7]);


			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}

	}

}
