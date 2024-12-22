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
    public class SP_GET_MENUITEM_WEB : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ITEM_ID { get; set; }

        [DataMember]
        public String MENU_NAME { get; set; }
        [DataMember]
        public String MENU_URL { get; set; }

        [DataMember]
        public String MENU_FOR_NAME { get; set; }

        [DataMember]
        public Decimal MENU_FOR { get; set; }
        [DataMember]
        public Decimal IS_ACTIVE { get; set; }

        [DataMember]
        public string IS_ACTIVE_STR { get; set; }
        [DataMember]
        public bool Selected { get; set; }

        [DataMember]
        public Decimal PARENT_ID { get; set; }

        [DataMember]
        public Decimal IS_HEADER { get; set; }
        [DataMember]
        public string IS_HEADER_STR { get; set; }
        
        [DataMember]
        public string PARENT_NAME { get; set; }

        [DataMember]
        public string MENU_NAME_BAN { get; set; }
        [DataMember]
        public decimal SRL_NO { get; set; }

        [DataMember]
        public string IS_PARENT_STR { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_MENUITEM_WEB entity = new SP_GET_MENUITEM_WEB();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ITEM_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.MENU_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.MENU_URL = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.MENU_FOR_NAME = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.MENU_FOR = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToDecimal(values[5]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE_STR = Convert.ToDecimal(values[5]) == 1 ? "Yes" : "No";

            if (values[6].GetType() != typeof(System.DBNull))
                entity.Selected = Convert.ToBoolean(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.PARENT_ID = Convert.ToDecimal(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.IS_HEADER = Convert.ToDecimal(values[8]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.IS_HEADER_STR = Convert.ToDecimal(values[8]) == 1 ? "Header" : Convert.ToDecimal(values[8]) == 2 ? "Group" : Convert.ToDecimal(values[8]) == 3 ? "Footer" : "";

            if (values[9].GetType() != typeof(System.DBNull))
                entity.PARENT_NAME = Convert.ToString(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.MENU_NAME_BAN = Convert.ToString(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.SRL_NO = Convert.ToDecimal(values[11]);

            entity.IS_PARENT_STR = Convert.ToString(values[9]) == "" ? "Parent" : "Child";
    
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
