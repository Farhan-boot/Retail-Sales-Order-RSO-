using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
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
    public class MtoVisitPlanPZ
    {

		public GetHighlightsMTO GetTodayHighlightsMTO(decimal Id)
		{
			try
			{
				List<SP_GET_MTO_VISIT_DATA> GetMTOvisitData = null;
				List<SP_GET_MTO_VISIT_DATA> getMTOMDTvisitData = null;
				
				GetHighlightsMTO GetHighlightsMTO = new GetHighlightsMTO();

				GetMTOvisitData = new MtoVisitPlanDZ().getMtoVisitData(Id, 0);
				GetHighlightsMTO.getMTOvisitData = GetMTOvisitData;

				getMTOMDTvisitData = new MtoVisitPlanDZ().getMtoVisitData(Id, 1);
				GetHighlightsMTO.getMTOMTDvisitData = getMTOMDTvisitData;

				
				return GetHighlightsMTO;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//public List<SP_GET_MTO_MTD_VISIT_DATA> getMtoMtdData(decimal id)
  //      {
  //          try
  //          {
  //              return new MtoVisitPlanDZ().getMtoMtdData(id);
  //          }
  //          catch (Exception ex)
  //          {
  //              throw ex;
  //          }
  //      }
        //public List<SP_GET_MTO_MTD_VISIT_DATA> getMtoVisitData(decimal id)
        //{
        //    try
        //    {
        //        return new MtoVisitPlanDZ().getMtoVisitData(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<SP_GET_MTO_VISIT_MTD_DETAILS_DATA> getMtoVisitDtlData(decimal id)
        {
            try
            {
                return new MtoVisitPlanDZ().getMtoVisitDtlData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_MTO_VISIT_MTD_DETAILS_DATA> getMtoMtdDtlData(decimal id)
        {
            try
            {
                return new MtoVisitPlanDZ().getMtoMtdDtlData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
