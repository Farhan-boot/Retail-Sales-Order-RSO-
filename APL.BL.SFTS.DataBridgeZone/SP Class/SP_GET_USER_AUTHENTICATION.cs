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
    public class SP_GET_USER_AUTHENTICATION : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal USER_ID { get; set; }

        [DataMember]
        public Decimal STATUS { get; set; }

        [DataMember]
        public Decimal RSO_ID { get; set; }

        [DataMember]
        public String USER_CODE { get; set; }

        [DataMember]
        public String USER_NAME { get; set; }

        [DataMember]
        public String TOP_UP_NUMBER { get; set; }


        [DataMember]
        public decimal IS_DOMAIN_USER { get; set; }

		// New development for APP version maintain
		//Developer:  Al Mamun
		[DataMember]
		public bool ISSUCESS { get; set; }

		[DataMember]
		public decimal APP_ID { get; set; }

		[DataMember]
		public String VERSION_CODE { get; set; }

		[DataMember]
		public String VERSION_NAME { get; set; }

		[DataMember]
		public String APP_NAME { get; set; }

		[DataMember]
		public String APP_LINK { get; set; }

		[DataMember]
		public decimal USER_TYPE { get; set; }

		[DataMember]
		public decimal ERRORID { get; set; }

        [DataMember]
        public bool isMandatory { get; set; }

        [DataMember]
        public bool isUpdateAvailable { get; set; }

        [DataMember]
        public String downloadUrl { get; set; }

        public object MapToEntity(object[] values)
        {
			SP_GET_USER_AUTHENTICATION entity = new SP_GET_USER_AUTHENTICATION();

			if (values[3].GetType() != typeof(System.DBNull) && Convert.ToString(values[3]) != "RSO APP")
			{
				entity.ISSUCESS = true;

				if (values[0].GetType() != typeof(System.DBNull))
					entity.USER_ID = Convert.ToDecimal(values[0]);

				if (values[1].GetType() != typeof(System.DBNull))
					entity.STATUS = Convert.ToDecimal(values[1]);

				if (values[2].GetType() != typeof(System.DBNull))
					entity.RSO_ID = Convert.ToDecimal(values[2]);

				if (values[3].GetType() != typeof(System.DBNull))
					entity.USER_CODE = Convert.ToString(values[3]);

				if (values[4].GetType() != typeof(System.DBNull))
					entity.USER_NAME = Convert.ToString(values[4]);

				if (values[5].GetType() != typeof(System.DBNull))
					entity.TOP_UP_NUMBER = Convert.ToString(values[5]);

				if (values[6].GetType() != typeof(System.DBNull))
					entity.IS_DOMAIN_USER = Convert.ToDecimal(values[6]);

				if (values[7].GetType() != typeof(System.DBNull))
					entity.USER_TYPE = Convert.ToDecimal(values[7]);


                if (values[8].GetType() != typeof(System.DBNull))
                    entity.isUpdateAvailable = Convert.ToBoolean(values[8]);

                if (values[9].GetType() != typeof(System.DBNull))
                    entity.isMandatory = (Convert.ToString(values[9]) == "1") ? true : false;


                if (values[10].GetType() != typeof(System.DBNull))
                    entity.downloadUrl = (Convert.ToString(values[10]).Length < 1) ? "" : Convert.ToString(values[10]);


            }
			else
			{
				entity.ISSUCESS = false;

					if (values[0].GetType() != typeof(System.DBNull))
						entity.APP_ID = Convert.ToDecimal(values[0]);

					if (values[1].GetType() != typeof(System.DBNull))
						entity.VERSION_CODE = Convert.ToString(values[1]);

					if (values[2].GetType() != typeof(System.DBNull))
						entity.VERSION_NAME = Convert.ToString(values[2]);

					if (values[3].GetType() != typeof(System.DBNull))
						entity.APP_NAME = Convert.ToString(values[3]);

					if (values[4].GetType() != typeof(System.DBNull))
						entity.APP_LINK = Convert.ToString(values[4]);

					if (values[5].GetType() != typeof(System.DBNull))
						entity.ERRORID = Convert.ToDecimal(values[5]);


                    if (values[6].GetType() != typeof(System.DBNull))
                        entity.isUpdateAvailable = Convert.ToBoolean(values[6]);

                    if (values[7].GetType() != typeof(System.DBNull))
                        entity.isMandatory = (Convert.ToString(values[7]) == "Y") ? true : false ;


                if (values[8].GetType() != typeof(System.DBNull))
                    entity.downloadUrl = (Convert.ToString(values[8]).Length < 1) ? "" : Convert.ToString(values[8]);


            }
			
            
            return entity;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
