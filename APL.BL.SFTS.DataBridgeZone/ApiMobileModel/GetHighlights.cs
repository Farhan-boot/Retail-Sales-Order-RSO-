using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class GetHighlights
    {
        public List<SP_GET_HIGHLIGHTS_VISIT> getHighlightVisit { get; set; }
        public List<SP_GET_HIGHLIGHTS_REQ_STOCK> getHighlightReqStock { get; set; }
        public List<SP_GET_HIGHLIGHTS_CRITICAL_RET> getHighlightCriticalRet { get; set; }
				
		public List<SP_GET_RSO_MTD_VISIT_DATA> getRsoMtdData { get; set; }
		public List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA> getRsoVisitDtlData { get; set; }
		public List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA> getRsoMtdDtlData { get; set; }
	}



	public class GetHighlightsMTO
	{
		
		public List<SP_GET_MTO_VISIT_DATA> getMTOvisitData { get; set; }
		public List<SP_GET_MTO_VISIT_DATA> getMTOMTDvisitData { get; set; }
		
		
	}
}
