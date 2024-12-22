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
    public class SP_GET_USERINFOcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal USERINFO_ID { get; set; }

        [DataMember]
        public String FULLNAME { get; set; }

        [DataMember]
        public String LOGINNAME { get; set; }

        [DataMember]
        public String PASSWORD { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String DEPARTMENT { get; set; }

        [DataMember]
        public char IS_INTERNAL { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_USERINFOcls entity = new SP_GET_USERINFOcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.USERINFO_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.FULLNAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.LOGINNAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.PASSWORD = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.DEPARTMENT = Convert.ToString(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.IS_INTERNAL = Convert.ToChar(values[7]);

            return entity;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
