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
    public class SP_SC_TRAN_OPERATIONcls : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public Decimal SCTRANSACTION_ID { get; set; }

        [DataMember]
        public Decimal TRAN_ENTRY { get; set; }

        [DataMember]
        public DateTime TRAN_DATE { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public char TRAN_POSTED { get; set; }

        [DataMember]
        public String TRAN_SERIALNO { get; set; }

        [DataMember]
        public Decimal TRAN_VERIFIEDBY { get; set; }

        [DataMember]
        public String TRAN_STARTSCNO { get; set; }

        [DataMember]
        public String TRAN_ENDSCNO { get; set; }

        [DataMember]
        public Decimal TRAN_PRODUCT_ID { get; set; }

        [DataMember]
        public Decimal TRAN_QTY { get; set; }

        [DataMember]
        public Decimal TRAN_INVENTORYTYPE { get; set; }
             
        public object MapToEntity(object[] values)
        {
            SP_SC_TRAN_OPERATIONcls entity = new SP_SC_TRAN_OPERATIONcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.SCTRANSACTION_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TRAN_ENTRY = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.TRAN_DATE = Convert.ToDateTime(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.TRAN_POSTED = Convert.ToChar(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.TRAN_SERIALNO = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.TRAN_VERIFIEDBY = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.TRAN_STARTSCNO = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.TRAN_ENDSCNO = Convert.ToString(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.TRAN_PRODUCT_ID = Convert.ToDecimal(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.TRAN_QTY = Convert.ToDecimal(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.TRAN_INVENTORYTYPE = Convert.ToDecimal(values[12]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
