using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.Posm;
using APL.BL.SFTS.DataBridgeZone.POSM;
using APL.BL.SFTS.DataBridgeZone.Sales;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Posm
{
  public  class RsoVisitPlanPZ
    {

        public List<SP_GET_RSO_MTD_VISIT_DATA> getRsoMtdData(decimal id, decimal RsoId)
        {
            try
            {
                return new RsoVisitPlanDZ().getRsoMtdData(id, RsoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_RSO_MTD_VISIT_DATA> getRsoVisitData(decimal id, decimal RsoId)
        {
            try
            {
                return new RsoVisitPlanDZ().getRsoVisitData(id, RsoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA> getRsoVisitDtlData(decimal id, decimal RsoId)
        {
            try
            {
                return new RsoVisitPlanDZ().getRsoVisitDtlData(id, RsoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA> getRsoMtdDtlData(decimal id, decimal RsoId)
        {
            try
            {
                return new RsoVisitPlanDZ().getRsoMtdDtlData(id, RsoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
