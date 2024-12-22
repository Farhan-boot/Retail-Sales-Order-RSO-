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
	public class ISVALID_SALARY_FOR : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public String VALID_SALARY_FOR_CODE { get; set; }

		[DataMember]
		public Int16 SALARY_TYPE { get; set; }

		public object MapToEntity(object[] values)
		{
			ISVALID_SALARY_FOR entity = new ISVALID_SALARY_FOR();
			if (values[0].GetType() != typeof(System.DBNull))
				entity.VALID_SALARY_FOR_CODE = Convert.ToString(values[0]);

			/*if (values[1].GetType() != typeof(System.DBNull))
				entity.SALARY_TYPE = Convert.ToInt16(values[1]); */

			return entity;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
