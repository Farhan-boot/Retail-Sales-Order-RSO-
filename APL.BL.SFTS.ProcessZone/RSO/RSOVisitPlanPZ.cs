using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.RSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.RSO
{
    public class RSOVisitPlanPZ
    {
        public RSOVisitPlanPZ() { }

        public List<SP_GET_VISIT_PLAN_SUMMARY> GetVisitPlanSummary(decimal Id, decimal RsoIId)
        {
            try
            {
                return new RSOVisitPlanDZ().GetVisitPlanSummary(Id, RsoIId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetHighlights GetTodayHighlights(decimal Id, decimal RsoIId)
        {
            try
			{
				List<SP_GET_HIGHLIGHTS_VISIT> getHighlightsVisit = null;
				List<SP_GET_HIGHLIGHTS_REQ_STOCK> getHighlightsReqStock = null;
				List<SP_GET_HIGHLIGHTS_CRITICAL_RET> getHighlightsCriticalRet = null;
				GetHighlights getHighlights = new GetHighlights();

				getHighlightsVisit = new RSOVisitPlanDZ().GetHighlightsVisit(Id, RsoIId); ;
				getHighlightsReqStock = new RSOVisitPlanDZ().GetHighlightsReqStock(Id, RsoIId);
				getHighlightsCriticalRet = new RSOVisitPlanDZ().GetHighlightsCriticalRet(Id, RsoIId);

				getHighlights.getHighlightVisit = getHighlightsVisit;
				getHighlights.getHighlightReqStock = getHighlightsReqStock;
				getHighlights.getHighlightCriticalRet = getHighlightsCriticalRet;


				return getHighlights;
			}
			catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_RETAILER_DASHBOARD_INFO> GetRetailerDashboardInfo(decimal RetailerId)
        {
            try
            {
                return new RSOVisitPlanDZ().GetRetailerDashboardInfo(RetailerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
