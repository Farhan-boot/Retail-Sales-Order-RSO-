using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Vfocus
{
    public class GraphInfoDZ
    {
        public Decimal SaveGraphInfo(decimal graphId, string graphCode, string graphName, string detail, decimal createdBy, decimal lastModifyBy,
            string isDelete, string strMode)
        {
            try
            {
                OracleParameter graphId_OP = new OracleParameter();
                graphId_OP.Direction = System.Data.ParameterDirection.Input;
                graphId_OP.OracleDbType = OracleDbType.Int32;
                graphId_OP.Value = graphId;

                OracleParameter graphCode_OP = new OracleParameter();
                graphCode_OP.Direction = System.Data.ParameterDirection.Input;
                graphCode_OP.OracleDbType = OracleDbType.Varchar2;
                graphCode_OP.Value = graphCode;

                OracleParameter graphName_OP = new OracleParameter();
                graphName_OP.Direction = System.Data.ParameterDirection.Input;
                graphName_OP.OracleDbType = OracleDbType.Varchar2;
                graphName_OP.Value = graphName;

                OracleParameter detail_OP = new OracleParameter();
                detail_OP.Direction = System.Data.ParameterDirection.Input;
                detail_OP.OracleDbType = OracleDbType.Varchar2;
                detail_OP.Value = detail;

                OracleParameter createdBy_OP = new OracleParameter();
                createdBy_OP.Direction = System.Data.ParameterDirection.Input;
                createdBy_OP.OracleDbType = OracleDbType.Decimal;
                createdBy_OP.Value = createdBy;

                OracleParameter lastModifyBy_OP = new OracleParameter();
                lastModifyBy_OP.Direction = System.Data.ParameterDirection.Input;
                lastModifyBy_OP.OracleDbType = OracleDbType.Decimal;
                lastModifyBy_OP.Value = lastModifyBy;

                OracleParameter isDelete_OP = new OracleParameter();
                isDelete_OP.Direction = System.Data.ParameterDirection.Input;
                isDelete_OP.OracleDbType = OracleDbType.Char;
                isDelete_OP.Value = isDelete;

                OracleParameter strMode_OP = new OracleParameter();
                strMode_OP.Direction = System.Data.ParameterDirection.Input;
                strMode_OP.OracleDbType = OracleDbType.Char;
                strMode_OP.Value = strMode;
                              
                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_FF_SAVE_VFOCUS_GRAPH_INFO>.InsertDataBySP("SP_FF_SAVE_VFOCUS_GRAPH_INFO", resultOutID, graphId_OP, graphCode_OP,
                    graphName_OP, detail_OP, createdBy_OP, lastModifyBy_OP, isDelete_OP, strMode_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_FF_SAVE_VFOCUS_GRAPH_INFO> GetAllGraphInfoList(decimal graphId, string graphCode, string graphName)
        {
            try
            {
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter errorCode = new OracleParameter();
				errorCode.Direction = System.Data.ParameterDirection.Output;
				errorCode.OracleDbType = OracleDbType.Decimal;


				OracleParameter graphId_OP = new OracleParameter();
                graphId_OP.Direction = System.Data.ParameterDirection.Input;
                graphId_OP.OracleDbType = OracleDbType.Decimal;
                graphId_OP.Value = graphId;

                OracleParameter graphCode_OP = new OracleParameter();
                graphCode_OP.Direction = System.Data.ParameterDirection.Input;
                graphCode_OP.OracleDbType = OracleDbType.Varchar2;
                graphCode_OP.Value = graphCode;

                OracleParameter graphName_OP = new OracleParameter();
                graphName_OP.Direction = System.Data.ParameterDirection.Input;
                graphName_OP.OracleDbType = OracleDbType.Varchar2;
                graphName_OP.Value = graphName;

                

                return (List<SP_FF_SAVE_VFOCUS_GRAPH_INFO>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_SAVE_VFOCUS_GRAPH_INFO>.GetDataBySP(new SP_FF_SAVE_VFOCUS_GRAPH_INFO(), "GET_VFOCUS_GRAPH_INFO", 6, resultOutCurSor,errorCode, graphId_OP, graphCode_OP, graphName_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



		public Decimal SaveGraphKPI(decimal graphId,  decimal kpiID, Decimal createdBy, string strMode)
		{
			try
			{

				OracleParameter graphId_OP = new OracleParameter();
				graphId_OP.Direction = System.Data.ParameterDirection.Input;
				graphId_OP.OracleDbType = OracleDbType.Int32;
				graphId_OP.Value = graphId;

				OracleParameter kpiID_OP = new OracleParameter();
				kpiID_OP.Direction = System.Data.ParameterDirection.Input;
				kpiID_OP.OracleDbType = OracleDbType.Varchar2;
				kpiID_OP.Value = kpiID;

				OracleParameter createdBy_OP = new OracleParameter();
				createdBy_OP.Direction = System.Data.ParameterDirection.Input;
				createdBy_OP.OracleDbType = OracleDbType.Decimal;
				createdBy_OP.Value = createdBy;


				OracleParameter strMode_OP = new OracleParameter();
				strMode_OP.Direction = System.Data.ParameterDirection.Input;
				strMode_OP.OracleDbType = OracleDbType.Char;
				strMode_OP.Value = strMode;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<VFOCUS_GRAPH_VS_KPI>.InsertDataBySP("SP_FF_SAVE_VFOCUS_GRAPH_VS_KPI", resultOutID, graphId_OP, kpiID_OP, createdBy_OP, strMode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public Decimal SaveKPI_Dashboard(decimal ID, decimal kpiID1, decimal graphId1, decimal kpiID2, decimal graphId2, decimal kpiID3, decimal graphId3, decimal lastmodyBy, string strMode)
		{
			try
			{
				OracleParameter Id_OP = new OracleParameter();
				Id_OP.Direction = System.Data.ParameterDirection.Input;
				Id_OP.OracleDbType = OracleDbType.Decimal;
				Id_OP.Value = ID;
				
				OracleParameter graphId1_OP= new OracleParameter();
				graphId1_OP.Direction = System.Data.ParameterDirection.Input;
				graphId1_OP.OracleDbType = OracleDbType.Decimal;
				graphId1_OP.Value = graphId1;

				OracleParameter kpiID1_OP = new OracleParameter();
				kpiID1_OP.Direction = System.Data.ParameterDirection.Input;
				kpiID1_OP.OracleDbType = OracleDbType.Decimal;
				kpiID1_OP.Value = kpiID1;

				OracleParameter graphId2_OP = new OracleParameter();
				graphId2_OP.Direction = System.Data.ParameterDirection.Input;
				graphId2_OP.OracleDbType = OracleDbType.Decimal;
				graphId2_OP.Value = graphId2;

				OracleParameter kpiID2_OP = new OracleParameter();
				kpiID2_OP.Direction = System.Data.ParameterDirection.Input;
				kpiID2_OP.OracleDbType = OracleDbType.Decimal;
				kpiID2_OP.Value = kpiID2;

				OracleParameter graphId3_OP = new OracleParameter();
				graphId3_OP.Direction = System.Data.ParameterDirection.Input;
				graphId3_OP.OracleDbType = OracleDbType.Decimal;
				graphId3_OP.Value = graphId3;

				OracleParameter kpiID3_OP = new OracleParameter();
				kpiID3_OP.Direction = System.Data.ParameterDirection.Input;
				kpiID3_OP.OracleDbType = OracleDbType.Decimal;
				kpiID3_OP.Value = kpiID3;


				OracleParameter strMode_OP = new OracleParameter();
				strMode_OP.Direction = System.Data.ParameterDirection.Input;
				strMode_OP.OracleDbType = OracleDbType.Char;
				strMode_OP.Value = strMode;

				OracleParameter lastmodyBy_OP = new OracleParameter();
				lastmodyBy_OP.Direction = System.Data.ParameterDirection.Input;
				lastmodyBy_OP.OracleDbType = OracleDbType.Int32;
				lastmodyBy_OP.Value = lastmodyBy;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<VFOCUS_KPI_DASHBOARD>.InsertDataBySP("SAVE_VFOCUS_KPI_DASHBOARD", resultOutID, Id_OP,  graphId1_OP, kpiID1_OP, graphId2_OP, kpiID2_OP, graphId3_OP, kpiID3_OP, lastmodyBy_OP, strMode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<VFOCUS_GRAPH_VS_KPI> GetAllGraphKPIList( decimal graphId, decimal kpiID)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter errorCode = new OracleParameter();
				errorCode.Direction = System.Data.ParameterDirection.Output;
				errorCode.OracleDbType = OracleDbType.Decimal;
								

				OracleParameter graphId_OP = new OracleParameter();
				graphId_OP.Direction = System.Data.ParameterDirection.Input;
				graphId_OP.OracleDbType = OracleDbType.Int32;
				graphId_OP.Value = graphId;

				OracleParameter kpiID_OP = new OracleParameter();
				kpiID_OP.Direction = System.Data.ParameterDirection.Input;
				kpiID_OP.OracleDbType = OracleDbType.Varchar2;
				kpiID_OP.Value = kpiID;

				
				return (List<VFOCUS_GRAPH_VS_KPI>)ObjectMakerFromOracleSP.OracleHelper<VFOCUS_GRAPH_VS_KPI>.GetDataBySP(new VFOCUS_GRAPH_VS_KPI(), "GET_VFOCUS_GRAPH_VS_KPI", 6, resultOutCurSor, errorCode, graphId_OP, kpiID_OP);
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
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter errorCode = new OracleParameter();
				errorCode.Direction = System.Data.ParameterDirection.Output;
				errorCode.OracleDbType = OracleDbType.Decimal;
				/*
				OracleParameter Id_OP = new OracleParameter();
				Id_OP.Direction = System.Data.ParameterDirection.Input;
				Id_OP.OracleDbType = OracleDbType.Int32;
				Id_OP.Value = ID;

				OracleParameter graphId_OP = new OracleParameter();
				graphId_OP.Direction = System.Data.ParameterDirection.Input;
				graphId_OP.OracleDbType = OracleDbType.Decimal;
				graphId_OP.Value = graphId;

				OracleParameter kpiID_OP = new OracleParameter();
				kpiID_OP.Direction = System.Data.ParameterDirection.Input;
				kpiID_OP.OracleDbType = OracleDbType.Decimal;
				kpiID_OP.Value = kpiID;*/
				
				return (List<VFOCUS_KPI_DASHBOARD>)ObjectMakerFromOracleSP.OracleHelper<VFOCUS_KPI_DASHBOARD>.GetDataBySP(new VFOCUS_KPI_DASHBOARD(), "GET_VFOCUS_KPI_DASHBOARD", 16, resultOutCurSor, errorCode);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}





		public List<VFOCUS_KPI_INFO> GetAllKPIItem(decimal ID)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter errorCode = new OracleParameter();
				errorCode.Direction = System.Data.ParameterDirection.Output;
				errorCode.OracleDbType = OracleDbType.Decimal;

				OracleParameter Id_OP = new OracleParameter();
				Id_OP.Direction = System.Data.ParameterDirection.Input;
				Id_OP.OracleDbType = OracleDbType.Int32;
				Id_OP.Value = ID;

				

				return (List<VFOCUS_KPI_INFO>)ObjectMakerFromOracleSP.OracleHelper<VFOCUS_KPI_INFO>.GetDataBySP(new VFOCUS_KPI_INFO(), "GET_VFOCUS_KPI_INFO", 5, resultOutCurSor, errorCode, Id_OP);
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
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter errorCode = new OracleParameter();
				errorCode.Direction = System.Data.ParameterDirection.Output;
				errorCode.OracleDbType = OracleDbType.Decimal;

				OracleParameter Id_OP = new OracleParameter();
				Id_OP.Direction = System.Data.ParameterDirection.Input;
				Id_OP.OracleDbType = OracleDbType.Int32;
				Id_OP.Value = ID;



				return (List<VFOCUS_ASS_UNASS_GRAPH>)ObjectMakerFromOracleSP.OracleHelper<VFOCUS_ASS_UNASS_GRAPH>.GetDataBySP(new VFOCUS_ASS_UNASS_GRAPH(), "GET_ASSIGN_UNASSIGN_GRAPH", 3, resultOutCurSor, errorCode, Id_OP);
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

				OracleParameter denoID_OP = new OracleParameter();
				denoID_OP.Direction = System.Data.ParameterDirection.Input;
				denoID_OP.OracleDbType = OracleDbType.Int32;
				denoID_OP.Value = denoID;

				OracleParameter USERID_OP = new OracleParameter();
				USERID_OP.Direction = System.Data.ParameterDirection.Input;
				USERID_OP.OracleDbType = OracleDbType.Varchar2;
				USERID_OP.Value = lastupdateBy;


				OracleParameter strMode_OP = new OracleParameter();
				strMode_OP.Direction = System.Data.ParameterDirection.Input;
				strMode_OP.OracleDbType = OracleDbType.Char;
				strMode_OP.Value = strMode;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<VFOCUS_GRAPH_VS_KPI>.InsertDataBySP("SP_FF_SAVE_DENO", resultOutID, denoID_OP, USERID_OP, strMode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public List<VFOCUS_DENO> GetDENO(decimal ID)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter errorCode = new OracleParameter();
				errorCode.Direction = System.Data.ParameterDirection.Output;
				errorCode.OracleDbType = OracleDbType.Decimal;

				OracleParameter Id_OP = new OracleParameter();
				Id_OP.Direction = System.Data.ParameterDirection.Input;
				Id_OP.OracleDbType = OracleDbType.Int32;
				Id_OP.Value = ID;
				

				return (List<VFOCUS_DENO>)ObjectMakerFromOracleSP.OracleHelper<VFOCUS_DENO>.GetDataBySP(new VFOCUS_DENO(), "GET_VFOCUS_DENO_INFO", 6, resultOutCurSor, errorCode, Id_OP);
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
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter errorCode = new OracleParameter();
				errorCode.Direction = System.Data.ParameterDirection.Output;
				errorCode.OracleDbType = OracleDbType.Decimal;

				OracleParameter Id_OP = new OracleParameter();
				Id_OP.Direction = System.Data.ParameterDirection.Input;
				Id_OP.OracleDbType = OracleDbType.Int32;
				Id_OP.Value = ID;


				return (List<VFOCUS_DENO>)ObjectMakerFromOracleSP.OracleHelper<VFOCUS_DENO>.GetDataBySP(new VFOCUS_DENO(), "GET_VFOCUS_MAPUNMAPDENO", 6, resultOutCurSor, errorCode, Id_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



	}
}
