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
    public class SP_GET_ALL_DISTRIBUTOR : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal Id { get; set; }


        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }


        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public String Label { get; set; }

    

        public object MapToEntity(object[] values)
        {
            SP_GET_ALL_DISTRIBUTOR entity = new SP_GET_ALL_DISTRIBUTOR();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.Id = Convert.ToDecimal(values[0]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.Label = Convert.ToString(values[3]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }                                          
    }                                             
}