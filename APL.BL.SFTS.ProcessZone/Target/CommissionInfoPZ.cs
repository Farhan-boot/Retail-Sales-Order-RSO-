using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class CommissionInfoPZ
    {
        public CommissionInfoPZ()
        { }

        public Decimal SaveCommissionInfo(decimal commissionInfoID, decimal applicableID, string name, decimal amount, decimal commissonPercent,
            decimal createBy, DateTime createDate, decimal updateBy, DateTime updateDate)
        {
            try
            {
                return new CommissionInfoDZ().SaveCommissionInfo(commissionInfoID, applicableID, name, amount, commissonPercent, createBy, createDate, updateBy, updateDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_INS_UPD_COMMISSION_INFOcls> GetCommissionInfo(decimal applicableID, string name, decimal currentPage)
        {
            try
            {
                return new CommissionInfoDZ().GetAllCommissionInfo(applicableID, name, currentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
