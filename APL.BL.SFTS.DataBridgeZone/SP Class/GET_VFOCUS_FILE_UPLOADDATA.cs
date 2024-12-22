using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{

	[Serializable()]
	[DataContract]
	public class GET_B2CSCAPPTARGETPROCESS : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public String TARGET_DATE { get; set; }
		[DataMember]
		public String REGION { get; set; }
		[DataMember]
		public String DD_CODE { get; set; }
		[DataMember]
		public String DD_NAME { get; set; }
		[DataMember]
		public Decimal RP_SIM { get; set; }
		[DataMember]
		public Decimal RP_EV { get; set; }
		[DataMember]
		public Decimal GA { get; set; }
		[DataMember]
		public Decimal DS_EV { get; set; }
		[DataMember]
		public Decimal DS_SC { get; set; }
		[DataMember]
		public Decimal TOTAL_DS { get; set; }
		[DataMember]
		public Decimal RECH_SC { get; set; }
		[DataMember]
		public Decimal RECH_EV { get; set; }
		[DataMember]
		public Decimal TOTAL_RECH { get; set; }


		public object MapToEntity(object[] values)
		{
			GET_B2CSCAPPTARGETPROCESS entity = new GET_B2CSCAPPTARGETPROCESS();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.TARGET_DATE = Convert.ToString(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.REGION = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.DD_CODE = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.DD_NAME = Convert.ToString(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.RP_SIM = Convert.ToDecimal(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.RP_EV = Convert.ToDecimal(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.GA = Convert.ToDecimal(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.DS_EV = Convert.ToDecimal(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.DS_SC = Convert.ToDecimal(values[8]);


			if (values[9].GetType() != typeof(System.DBNull))
				entity.TOTAL_DS = Convert.ToDecimal(values[9]);

			
			if (values[10].GetType() != typeof(System.DBNull))
				entity.RECH_SC = Convert.ToDecimal(values[10]);

			if (values[11].GetType() != typeof(System.DBNull))
				entity.RECH_EV = Convert.ToDecimal(values[11]);

			if (values[12].GetType() != typeof(System.DBNull))
				entity.TOTAL_RECH = Convert.ToDecimal(values[12]);
			


			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}



	}




	[Serializable()]
	[DataContract]
	public class ISVALID_UPLOAD : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public String VALID_UPLOAD { get; set; }

		

		public object MapToEntity(object[] values)
		{
			ISVALID_UPLOAD entity = new ISVALID_UPLOAD();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.VALID_UPLOAD = Convert.ToString(values[0]);
			
			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}

	



	[Serializable()]
	[DataContract]
	public class GET_VFOCUS_DENO_TARGET : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public decimal ID { get; set; }		
		[DataMember]
		public String ROSCODE { get; set; }
		[DataMember]
		public String DENO_ID { get; set; }
		[DataMember]
		public Decimal TARGET_COUNT { get; set; }
		[DataMember]
		public Decimal DENO_AMOUNT { get; set; }
		[DataMember]
		public String DATE_START { get; set; }
		[DataMember]
		public String DATE_END { get; set; }
		[DataMember]
		public Decimal ROW_COUNT { get; set; }



		public object MapToEntity(object[] values)
		{
			GET_VFOCUS_DENO_TARGET entity = new GET_VFOCUS_DENO_TARGET();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.ID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.ROSCODE = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.DENO_ID = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.TARGET_COUNT = Convert.ToDecimal(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.DENO_AMOUNT = Convert.ToDecimal(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.DATE_START = Convert.ToString(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.DATE_END = Convert.ToString(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.ROW_COUNT = Convert.ToDecimal(values[7]);


			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}



	}





	[Serializable()]
	[DataContract]
	public class SP_FF_GET_FILE_UPLOAD_INFO : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public decimal ID { get; set; }
		[DataMember]
		public String FILE_NAME { get; set; }
		[DataMember]
		public String FILE_INFO { get; set; }
		[DataMember]
		public decimal FILE_CATEGORY { get; set; }
		[DataMember]
		public String FILE_CATEGORY_NAME { get; set; }
		[DataMember]
		public Decimal FILE_FORMAT { get; set; }
		[DataMember]
		public String FILE_FORMAT_NAME { get; set; }
		[DataMember]
		public String LINK { get; set; }
		[DataMember]
		public String ISACTIVE { get; set; }
		[DataMember]
		public decimal UPLOADBY { get; set; }
		[DataMember]
		public String UPLOADBY_NAME { get; set; }
		[DataMember]
		public string UPLOAD_AT { get; set; }
		

		public object MapToEntity(object[] values)
		{
			SP_FF_GET_FILE_UPLOAD_INFO entity = new SP_FF_GET_FILE_UPLOAD_INFO();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.ID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.FILE_NAME = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.FILE_INFO = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.FILE_CATEGORY = Convert.ToDecimal(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.FILE_CATEGORY_NAME = Convert.ToString(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.FILE_FORMAT = Convert.ToDecimal(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.FILE_FORMAT_NAME = Convert.ToString(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.LINK = Convert.ToString(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.UPLOADBY = Convert.ToDecimal(values[8]);

			if (values[9].GetType() != typeof(System.DBNull))
				entity.UPLOAD_AT = Convert.ToString(values[9]);

			if (values[10].GetType() != typeof(System.DBNull))
				entity.UPLOADBY_NAME = Convert.ToString(values[10]);

			if (values[11].GetType() != typeof(System.DBNull))
				entity.ISACTIVE = Convert.ToString(values[11]);

			
			
			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}

	}




	[Serializable()]
	[DataContract]
	public class GET_VFOCUS_FILES : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public byte[] PICTURE { get; set; }

		[DataMember]
		public Decimal PICTURE_ID { get; set; }


		public object MapToEntity(object[] values)
		{
			GET_VFOCUS_FILES entity = new GET_VFOCUS_FILES();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.PICTURE = (byte[])values[0];

			if (values[1].GetType() != typeof(System.DBNull))
				entity.PICTURE_ID = Convert.ToDecimal(values[1]);

			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}

	}





	[Serializable()]
	[DataContract]
	public class SP_FF_GET_CAMP_DATA : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public decimal ID { get; set; }
		[DataMember]
		public String DD_CODE { get; set; }
		[DataMember]
		public String CAMP_NAME { get; set; }
		[DataMember]
		public decimal TARGET { get; set; }
		[DataMember]
		public decimal ACIEVEMENNTS { get; set; }
		[DataMember]
		public Decimal UPLOADBY { get; set; }
		[DataMember]
		public String ISACTIVE { get; set; }
		[DataMember]
		public String UPLOAD_BATCHID { get; set; }
		[DataMember]
		public Decimal ROW_COUNT { get; set; }
		[DataMember]
		public Decimal UPLOAD_CODE { get; set; }

		[DataMember]
		public String UPLOAD_DATE { get; set; }


		public object MapToEntity(object[] values)
		{
			SP_FF_GET_CAMP_DATA entity = new SP_FF_GET_CAMP_DATA();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.ID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.DD_CODE = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.CAMP_NAME = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.TARGET = Convert.ToDecimal(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.ACIEVEMENNTS = Convert.ToDecimal(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.UPLOADBY = Convert.ToDecimal(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.ISACTIVE = Convert.ToString(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
				entity.UPLOAD_BATCHID = Convert.ToString(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.ROW_COUNT = Convert.ToDecimal(values[8]);

			if (values[9].GetType() != typeof(System.DBNull))
				entity.UPLOAD_CODE = Convert.ToDecimal(values[9]);

			if (values[10].GetType() != typeof(System.DBNull))
				entity.UPLOAD_DATE = Convert.ToString(values[10]);

			
			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}






	[Serializable()]
	[DataContract]
	public class GET_VFOCUS_FILE_CATEGORY : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public decimal ID { get; set; }
		[DataMember]
		public String CATEGORY_NAME { get; set; }
		

		public object MapToEntity(object[] values)
		{
			GET_VFOCUS_FILE_CATEGORY entity = new GET_VFOCUS_FILE_CATEGORY();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.ID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.CATEGORY_NAME = Convert.ToString(values[1]);		


			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}



	[Serializable()]
	[DataContract]
	public class GET_VFOCUS_FILE_FORMAT : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public decimal ID { get; set; }
		[DataMember]
		public String FORMAT_NAME { get; set; }


		public object MapToEntity(object[] values)
		{
			GET_VFOCUS_FILE_FORMAT entity = new GET_VFOCUS_FILE_FORMAT();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.ID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.FORMAT_NAME = Convert.ToString(values[1]);


			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}



	[Serializable()]
	[DataContract]
	public class ISVALID_CAMP_DATA : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public String VALID_DD_CODE { get; set; }
			

		public object MapToEntity(object[] values)
		{
			ISVALID_CAMP_DATA entity = new ISVALID_CAMP_DATA();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.VALID_DD_CODE = Convert.ToString(values[0]);

			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}


	[Serializable()]
	[DataContract]
	public class ISVALID_DD_CODE : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public String VALID_DD_CODE { get; set; }


		public object MapToEntity(object[] values)
		{
			ISVALID_DD_CODE entity = new ISVALID_DD_CODE();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.VALID_DD_CODE = Convert.ToString(values[0]);

			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}



	[Serializable()]
	[DataContract]
	public class ISVALID_DENO_TARGET : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public String VALID_CODE { get; set; }


		public object MapToEntity(object[] values)
		{
			ISVALID_DENO_TARGET entity = new ISVALID_DENO_TARGET();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.VALID_CODE = Convert.ToString(values[0]);

			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}



	[Serializable()]
	[DataContract]
	public class VFOCUS_API_CALL : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public String MSISDN { get; set; }
		[DataMember]
		public String ACCESSKEY { get; set; }
		[DataMember]
		public String FILE_NAME { get; set; }

		[DataMember]
		public String FILE_INFO { get; set; }
		[DataMember]
		public String CATEGORY_NAME { get; set; }
		[DataMember]
		public String FORMAT_NAME { get; set; }




		public object MapToEntity(object[] values)
		{
			int totalC = values.Length;

			VFOCUS_API_CALL entity = new VFOCUS_API_CALL();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.MSISDN = Convert.ToString(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.ACCESSKEY = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.FILE_NAME = Convert.ToString(values[2]);

			
				if (values[3].GetType() != typeof(System.DBNull))
					entity.FILE_INFO = Convert.ToString(values[3]);

				if (values[4].GetType() != typeof(System.DBNull))
					entity.CATEGORY_NAME = Convert.ToString(values[4]);

				if (values[5].GetType() != typeof(System.DBNull))
					entity.FORMAT_NAME = Convert.ToString(values[5]);
			
			


			return entity;

		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}


	


}
