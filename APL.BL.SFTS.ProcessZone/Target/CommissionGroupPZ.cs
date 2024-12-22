using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class CommissionGroupPZ
    {
        public CommissionGroupPZ()
        { }

        /// <summary>
        ///  or update commission group info.
        /// </summary>
        /// <param name="commissionGroupID"></param>
        /// <param name="name"></param>
        /// <param name="commissionStatusId"></param>
        /// <param name="createBy"></param>
        /// <param name="createDate"></param>
        /// <returns>commissionGroupID</returns>
        public Decimal Save(decimal commissionGroupID, string name, decimal commissionStatusId, decimal createBy, DateTime createDate)
        {
            try
            {
                decimal updateBy = createBy;
                DateTime updateDate = createDate;
                
                return new CommissionGroupDZ().Save(commissionGroupID, name, commissionStatusId, createBy, createDate, updateBy, updateDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all commission group by search option.
        /// </summary>
        /// <param name="commissionGroupId"></param>
        /// <param name="name"></param>
        /// <param name="statusId"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public List<SP_GET_COMMISSION_GROUPcls> GetAll(decimal commissionGroupId, string name, decimal statusId, decimal currentPage)
        {
            try
            {
                return new CommissionGroupDZ().GetAll(commissionGroupId, name, statusId, currentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
