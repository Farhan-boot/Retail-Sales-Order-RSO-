using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_MENU : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String MENU_NAME { get; set; }

        [DataMember]
        public String MENU_URL { get; set; }

        [DataMember]
        public Decimal PARENT_MENU_ID { get; set; }

        [DataMember]
        public Decimal MENU_TYPE { get; set; }

        [DataMember]
        public String MENU_ICON { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_MENU entity = new SP_GET_MENU();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.MENU_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.MENU_URL = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PARENT_MENU_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.MENU_TYPE = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.MENU_ICON = Convert.ToString(values[5]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
