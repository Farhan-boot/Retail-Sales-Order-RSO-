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
    public class SP_FF_GET_MENU_GROUP_ITEM_LIST : ObjectMakerFromOracleSP.ISpClassEntity
    {
		
		[DataMember]
        public Int32 MENUITEM_ID { get; set; }

        [DataMember]
        public String MENU_NAME { get; set; }

        [DataMember]
        public String MENU_URL { get; set; }

		[DataMember]
		public Int32 GROUP_ID { get; set; }

		public object MapToEntity(object[] values)
        {
            SP_FF_GET_MENU_GROUP_ITEM_LIST entity = new SP_FF_GET_MENU_GROUP_ITEM_LIST();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.MENUITEM_ID = Convert.ToInt32(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.MENU_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.MENU_URL = Convert.ToString(values[2]);

			if (values[3].GetType() != typeof(System.DBNull))
				entity.GROUP_ID = Convert.ToInt32(values[3]);

			return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
