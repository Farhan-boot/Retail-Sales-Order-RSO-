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
    public class SP_SIM_TRAN_OPERATIONcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal SIMTRANSACTION_ID { get; set; }

        [DataMember]
        public Decimal ENTRY { get; set; }

        [DataMember]
        public DateTime TRDATE { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR { get; set; }

        [DataMember]
        public Decimal RETAILER { get; set; }

        [DataMember]
        public char POSTED { get; set; }

        [DataMember]
        public String SERIALNO { get; set; }

        [DataMember]
        public Decimal ENTEREDBY { get; set; }

        [DataMember]
        public Decimal SIMTRANSACTION { get; set; }

        [DataMember]
        public String STARTSIMNO { get; set; }        

        [DataMember]
        public String ENDSIMNO { get; set; }

        [DataMember]
        public Decimal PRODUCT { get; set; }

        [DataMember]
        public Decimal QTY { get; set; }

        [DataMember]
        public DateTime ISSUEDATE { get; set; }

        [DataMember]
        public Decimal INVENTORYTYPE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_SIM_TRAN_OPERATIONcls entity = new SP_SIM_TRAN_OPERATIONcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.SIMTRANSACTION_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.ENTRY = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.TRDATE = Convert.ToDateTime(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.POSTED = Convert.ToChar(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.SERIALNO = Convert.ToString(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.ENTEREDBY = Convert.ToDecimal(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.SIMTRANSACTION = Convert.ToDecimal(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.STARTSIMNO = Convert.ToString(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.ENDSIMNO = Convert.ToString(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.PRODUCT = Convert.ToDecimal(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.QTY = Convert.ToDecimal(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.ISSUEDATE = Convert.ToDateTime(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.INVENTORYTYPE = Convert.ToDecimal(values[14]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
