using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.RSO
{
    public class RSOVisitPlanDZ
    {
        public RSOVisitPlanDZ(){ }

        public List<SP_GET_VISIT_PLAN_SUMMARY> GetVisitPlanSummary(decimal Id,decimal RsoId)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_VISIT_PLAN_SUMMARY>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_VISIT_PLAN_SUMMARY>.GetDataBySP(new SP_GET_VISIT_PLAN_SUMMARY(), "SP_FF_GET_VISIT_PLAN_SUMMARY", 4, resultOutCurSor, Id_OP, RsoId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_HIGHLIGHTS_VISIT> GetHighlightsVisit(decimal Id, decimal RsoId)
        {
            try
            {
                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_HIGHLIGHTS_VISIT>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_HIGHLIGHTS_VISIT>.GetDataBySP(new SP_GET_HIGHLIGHTS_VISIT(), "SP_FF_GET_HIGHLIGHTS_VISIT", 3, resultOutCurSor, RsoId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_HIGHLIGHTS_REQ_STOCK> GetHighlightsReqStock(decimal Id, decimal RsoId)
        {
            try
            {
                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_HIGHLIGHTS_REQ_STOCK>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_HIGHLIGHTS_REQ_STOCK>.GetDataBySP(new SP_GET_HIGHLIGHTS_REQ_STOCK(), "SP_FF_GET_HIGHLIGHTS_REQ_STOCK", 4, resultOutCurSor, RsoId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
        public List<SP_GET_HIGHLIGHTS_CRITICAL_RET> GetHighlightsCriticalRet(decimal Id, decimal RsoId)
        {
            try
            {
                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_HIGHLIGHTS_CRITICAL_RET>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_HIGHLIGHTS_CRITICAL_RET>.GetDataBySP(new SP_GET_HIGHLIGHTS_CRITICAL_RET(), "SP_FF_GET_HIGHLIGHTS_CRIT_RET", 2, resultOutCurSor, RsoId_OP);
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
                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_DASHBOARD_INFO>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_DASHBOARD_INFO>.GetDataBySP(new SP_GET_RETAILER_DASHBOARD_INFO(), "SP_FF_GET_RETAILER_DASHBOARD", 10, resultOutCurSor, RetailerId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<SP_GET_RSO_MTD_VISIT_DATA> GET_RSO_MTD_DATA(decimal Id, decimal RsoId)
		{
			try
			{
				OracleParameter RsoId_OP = new OracleParameter();
				RsoId_OP.Direction = System.Data.ParameterDirection.Input;
				RsoId_OP.OracleDbType = OracleDbType.Decimal;
				RsoId_OP.Value = RsoId;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_RSO_MTD_VISIT_DATA>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_MTD_VISIT_DATA>.GetDataBySP(new SP_GET_RSO_MTD_VISIT_DATA(), "SP_GET_RSO_MTD_DATA", 4, resultOutCurSor, RsoId_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<SP_GET_RSO_MTD_VISIT_DATA> GET_RSO_VISIT_DATA(decimal Id, decimal RsoId)
		{
			try
			{
				OracleParameter RsoId_OP = new OracleParameter();
				RsoId_OP.Direction = System.Data.ParameterDirection.Input;
				RsoId_OP.OracleDbType = OracleDbType.Decimal;
				RsoId_OP.Value = RsoId;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_RSO_MTD_VISIT_DATA>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_MTD_VISIT_DATA>.GetDataBySP(new SP_GET_RSO_MTD_VISIT_DATA(), "SP_GET_RSO_VISIT_DATA", 4, resultOutCurSor, RsoId_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA> getRsoVisitDtlData(decimal Id, decimal RsoId)
		{
			try
			{
				OracleParameter RsoId_OP = new OracleParameter();
				RsoId_OP.Direction = System.Data.ParameterDirection.Input;
				RsoId_OP.OracleDbType = OracleDbType.Decimal;
				RsoId_OP.Value = RsoId;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_VISIT_MTD_DETAILS_DATA>.GetDataBySP(new SP_GET_RSO_VISIT_MTD_DETAILS_DATA(), "SP_GET_RSO_VISIT_DETAILS_DATA", 9, resultOutCurSor, RsoId_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA> getRsoMtdDtlData(decimal Id, decimal RsoId)
		{
			try
			{
				OracleParameter RsoId_OP = new OracleParameter();
				RsoId_OP.Direction = System.Data.ParameterDirection.Input;
				RsoId_OP.OracleDbType = OracleDbType.Decimal;
				RsoId_OP.Value = RsoId;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_VISIT_MTD_DETAILS_DATA>.GetDataBySP(new SP_GET_RSO_VISIT_MTD_DETAILS_DATA(), "SP_GET_RSO_MTD_DETAILS_DATA", 9, resultOutCurSor, RsoId_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
