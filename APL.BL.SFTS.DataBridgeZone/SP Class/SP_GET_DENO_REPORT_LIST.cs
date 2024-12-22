using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.SP_Class
{
    //SELECT '' DENO_REPORT_DATE, '' DENO, '' DENO_REPORT_C2C, '' DENO_REPORT_C2S FROM FF_DENO_REPORT;
    [Serializable()]
    [DataContract]
    public class SP_GET_DENO_REPORT_LIST : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String DENO_REPORT_DATE { get; set; }

		[DataMember]
		public String DENO_TYPE { get; set; }

		[DataMember]
        public Int32 DENO { get; set; }
		        
        [DataMember]
        public Int32 DENO_REPORT_C2S { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_DENO_REPORT_LIST entity = new SP_GET_DENO_REPORT_LIST();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DENO_REPORT_DATE = Convert.ToString(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.DENO_TYPE = Convert.ToString(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
                entity.DENO = Convert.ToInt32(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.DENO_REPORT_C2S = Convert.ToInt32(values[3]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
