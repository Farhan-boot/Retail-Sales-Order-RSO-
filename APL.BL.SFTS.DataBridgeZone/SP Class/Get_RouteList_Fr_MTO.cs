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
    public class Get_RouteList_Fr_MTO : ObjectMakerFromOracleSP.ISpClassEntity
    {
       

        [DataMember]
        public Decimal MTOID  { get; set; }

        [DataMember]
        public Decimal ROUTEID { get; set; }

        [DataMember]
        public String MTOCODE { get; set; }

        [DataMember]
        public String ROUTEOCDE { get; set; }

        [DataMember]
        public DateTime DATE  { get; set; }
        public object MapToEntity(object[] values)
        {
            Get_RouteList_Fr_MTO entity = new Get_RouteList_Fr_MTO();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.MTOID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.ROUTEID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.MTOCODE = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.ROUTEOCDE = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.DATE = Convert.ToDateTime(values[4]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    }
