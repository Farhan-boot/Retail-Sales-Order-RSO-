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
    public class SP_GET_RSO_ROT_SCHDLcls :ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public Decimal ROUTE_ID { get; set; }

        /// <summary>
        /// CODE => ROUTE CODE
        /// </summary>
        [DataMember]
        public String ROUTE_CODE { get; set; }

        [DataMember]
        public String ROUTE_NAME { get; set; }

        /// <summary>
        /// DESCRIPTION => ROUTE DESCRIPTION
        /// </summary>
        [DataMember]
        public String ROUTE_DESCRIPTION { get; set; }

        /// <summary>
        /// VISITDATE => ROUTE VISITDATE
        /// </summary>
        [DataMember]
        public DateTime ROUTE_VISITDATE { get; set; }

                                           
        public object MapToEntity(object[] values)
        {
            SP_GET_RSO_ROT_SCHDLcls entity = new SP_GET_RSO_ROT_SCHDLcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ROUTE_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ROUTE_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.ROUTE_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.ROUTE_DESCRIPTION = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.ROUTE_VISITDATE = Convert.ToDateTime(values[4]);            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
