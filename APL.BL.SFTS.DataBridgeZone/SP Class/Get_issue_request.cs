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
    public class Get_issue_request : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public decimal Id { get; set; }
        [DataMember]
        public string ISSUE_DATE { get; set; }
        [DataMember]
        public decimal STAFF_USERID { get; set; }
        [DataMember]
        public decimal RETAILERID { get; set; }
		[DataMember]
		public string RETAILERID_CODE { get; set; }
		[DataMember]
        public decimal CATEGORYID { get; set; }
		[DataMember]
		public string CATEGORY_NAME { get; set; }
		[DataMember]
        public decimal PRODUCTID { get; set; }
		[DataMember]
		public string PRODUCTNAME { get; set; }
		[DataMember]
        public decimal QTY { get; set; }
        [DataMember]
        public DateTime ROWINSERT { get; set; }


        public object MapToEntity(object[] values)
        {
            Get_issue_request entity = new Get_issue_request();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.Id = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.ISSUE_DATE = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.STAFF_USERID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILERID = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILERID_CODE = Convert.ToString(values[4]);

			if (values[5].GetType() != typeof(System.DBNull))
				entity.CATEGORYID = Convert.ToDecimal(values[5]);

			if (values[6].GetType() != typeof(System.DBNull))
				entity.CATEGORY_NAME = Convert.ToString(values[6]);

			if (values[7].GetType() != typeof(System.DBNull))
                entity.PRODUCTID = Convert.ToDecimal(values[7]);

			if (values[8].GetType() != typeof(System.DBNull))
				entity.PRODUCTNAME = Convert.ToString(values[8]);
			if (values[9].GetType() != typeof(System.DBNull))
				entity.QTY = Convert.ToDecimal(values[9]);



			


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
