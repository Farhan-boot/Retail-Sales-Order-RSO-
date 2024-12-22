using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_SHOP_TARGET_ACHIVE : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String TargetItem { get; set; }

        [DataMember]
        public Decimal MonthColumn { get; set; }

        [DataMember]
        public Decimal MonthNo { get; set; }

        [DataMember]
        public String ValueType { get; set; }

        [DataMember]
        public String UnitName { get; set; }

        [DataMember]
        public String MonthName { get; set; }

        [DataMember]
        public Decimal TotalValue { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_SHOP_TARGET_ACHIVE entity = new SP_GET_SHOP_TARGET_ACHIVE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.TargetItem = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.MonthColumn = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.MonthNo = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.ValueType = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.UnitName = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.MonthName = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.TotalValue = Convert.ToDecimal(values[6]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
