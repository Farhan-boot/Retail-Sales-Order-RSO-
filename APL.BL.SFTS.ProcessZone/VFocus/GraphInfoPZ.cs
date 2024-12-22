using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.Vfocus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.VFocus
{
    public class GraphInfoPZ
    {

        public Decimal SaveGraphInfo(decimal graphId, string graphCode, string graphName, string detail, decimal createdBy, decimal lastModifyBy,
            string isDelete, string strMode)
        {
            //decimal errorCode = 0;
            //errorCode = surveyDetailQID > 0 ? surveyDetailQID : 0;

            try
            {
                return new GraphInfoDZ().SaveGraphInfo(graphId,graphCode,graphName,detail,createdBy,lastModifyBy,isDelete,strMode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_FF_SAVE_VFOCUS_GRAPH_INFO> GetAllGraphInfoList(decimal graphId, string graphName, string graphCode)
        {
            try
            {
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode);
			}
            catch (Exception ex)
            {
                throw ex;
            }
        }




		public Decimal SaveGraphKPI(decimal graphId,  decimal KPIID, decimal createdBy,  string strMode)
		{
			try
			{
				return new GraphInfoDZ().SaveGraphKPI(graphId, KPIID, createdBy, strMode);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<VFOCUS_GRAPH_VS_KPI> GetAllGraphKPIList(decimal graphId, decimal KPIID)
		{
			try
			{
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new GraphInfoDZ().GetAllGraphKPIList(graphId, KPIID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public Decimal SaveKPI_Dashboard(decimal ID, decimal kpiID1, decimal graphId1, decimal kpiID2, decimal graphId2, decimal kpiID3, decimal graphId3,  decimal lastmodyBy, string strMode)
		{
			try
			{
				return new GraphInfoDZ().SaveKPI_Dashboard(ID, kpiID1, graphId1, kpiID2, graphId2, kpiID3, graphId3,  lastmodyBy, strMode);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<VFOCUS_KPI_DASHBOARD> GetAllKPIDashboardList(decimal ID, decimal graphId, decimal kpiID)
		{
			try
			{
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new GraphInfoDZ().GetAllKPIDashboardList(ID, graphId, kpiID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<VFOCUS_KPI_INFO> GetAllKPIList(decimal ID)
		{
			try
			{
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new GraphInfoDZ().GetAllKPIItem(ID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<VFOCUS_ASS_UNASS_GRAPH> GetAllAssignUnAssignGraph(decimal ID)
		{
			try
			{
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new GraphInfoDZ().GetAllAssignUnAssignGraph(ID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public Decimal SaveDENO(decimal denoID, decimal lastupdateBy, string strMode)
		{
			try
			{
				return new GraphInfoDZ().SaveDENO(denoID, lastupdateBy, strMode);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<VFOCUS_DENO> GetDENOALL(decimal ID)
		{
			try
			{
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new GraphInfoDZ().GetDENO(ID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<VFOCUS_DENO> MAPUNMAP_DENO(decimal ID)
		{
			try
			{
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new GraphInfoDZ().MAPUNMAP_DENO(ID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



	}
}
