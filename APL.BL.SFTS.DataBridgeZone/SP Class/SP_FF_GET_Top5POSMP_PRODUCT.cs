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
	public class SP_FF_GET_Top5POSMP_PRODUCT : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public decimal PRODUCTID { get; set; }

		[DataMember]
		public string PRODUCTCODE { get; set; }

		[DataMember]
		public decimal CATEGORYID { get; set; }

		[DataMember]
		public string PRODUCT_CATEGORY { get; set; }

		[DataMember]
		public decimal TOTAL { get; set; }


		public object MapToEntity(object[] values)
		{
			SP_FF_GET_Top5POSMP_PRODUCT entity = new SP_FF_GET_Top5POSMP_PRODUCT();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.PRODUCTID = Convert.ToDecimal(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.PRODUCTCODE = values[1].ToString();

			if (values[2].GetType() != typeof(System.DBNull))
				entity.CATEGORYID = Convert.ToDecimal(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.PRODUCT_CATEGORY = Convert.ToString(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.TOTAL = Convert.ToDecimal(values[4]);
			


			return entity;
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}


	}
}
