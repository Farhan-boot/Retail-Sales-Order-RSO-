using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class CommissionGroupMemberMapPZ
    {
        public CommissionGroupMemberMapPZ() { }

        /// <summary>
        /// Save or update commission group member info.
        /// </summary>
        /// <param name="comGrpMemMapId"></param>
        /// <param name="comGrpId"></param>
        /// <param name="memberName"></param>
        /// <param name="execlClnName"></param>
        /// <param name="excelClnNo"></param>
        /// <param name="serialNo"></param>
        /// <param name="createBy"></param>
        /// <param name="createDate"></param>
        /// <returns>ComGrpMemMapId</returns>
        public decimal Save(decimal comGrpMemMapId, decimal comGrpId, string memberName, string execlClnName, decimal excelClnNo, decimal serialNo, decimal createBy, DateTime createDate)
        {
            try
            {
                decimal updateBy = createBy;
                DateTime updateDate = createDate;
                return new CommissionGroupMemberMapDZ().Save(comGrpMemMapId, comGrpId, memberName, execlClnName, excelClnNo, serialNo, createBy, createDate, updateBy, updateDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get single commission group member by search option.
        /// </summary>
        /// <param name="comGrpMemMapId"></param>
        /// <returns>Single related object</returns>
        public SP_GET_COMMISSION_GRP_MEM_MAPcls GetSingleGrpMemMap(decimal comGrpMemMapId)
        {
            try
            {
                List<SP_GET_COMMISSION_GRP_MEM_MAPcls> comGrpMemMap = new CommissionGroupMemberMapDZ().GetAll(comGrpMemMapId, 0, string.Empty, 0);
                if (comGrpMemMap == null || comGrpMemMap.Count == 0)
                {
                    return null;
                }
                else
                {
                    return comGrpMemMap[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all commission group member by search option.
        /// </summary>
        /// <param name="comGrpMemMapId"></param>
        /// <param name="comGrpId"></param>
        /// <param name="memberName"></param>
        /// <param name="currentPage"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_COMMISSION_GRP_MEM_MAPcls> GetAll(decimal comGrpMemMapId, decimal comGrpId, string memberName, decimal currentPage)
        {
            try
            {
                return new CommissionGroupMemberMapDZ().GetAll(comGrpMemMapId, comGrpId, memberName, currentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
