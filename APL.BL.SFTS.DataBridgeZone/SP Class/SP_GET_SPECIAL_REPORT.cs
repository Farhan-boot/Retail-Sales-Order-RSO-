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
    public class SP_GET_SPECIAL_REPORT : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public string RSO_CODE { get; set; }

        [DataMember]
        public string SR_NO { get; set; }

        [DataMember]
        public string DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public string RSO_APP_VERSION { get; set; }

        [DataMember]
        public string IMEI { get; set; }

        [DataMember]
        public string UNIQUE_SL { get; set; }

		[DataMember]
		public string REGISTRATION_DATE { get; set; }

		[DataMember]
        public string LAST_LOGIN_DATE_TIME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_SPECIAL_REPORT entity = new SP_GET_SPECIAL_REPORT();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.SR_NO = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RSO_APP_VERSION = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.IMEI = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.UNIQUE_SL = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.LAST_LOGIN_DATE_TIME = Convert.ToString(values[6]);
			if (values[7].GetType() != typeof(System.DBNull))
				entity.REGISTRATION_DATE = Convert.ToString(values[7]);

			return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
