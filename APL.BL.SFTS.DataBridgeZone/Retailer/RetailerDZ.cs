
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class RetailerDZ
    {
        public RetailerDZ()
        { }


        public List<SP_GET_RETAILER_CREATE_REQUEST> GetRetailerCreateRequest(decimal RsoId, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Varchar2;
                RsoId_OP.Value = RsoId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_CREATE_REQUEST>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_CREATE_REQUEST>.GetDataBySP(new SP_GET_RETAILER_CREATE_REQUEST(), "SP_FF_GET_NEW_RETAILER_CREATE", 4, resultOutCurSor, RsoId_OP, DateFrom_OP, DateTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_NEW_RETAILER_FOR_APPROVE> GetNewRetailerForApprove(decimal Id, decimal StatusId, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter StatusId_OP = new OracleParameter();
                StatusId_OP.Direction = System.Data.ParameterDirection.Input;
                StatusId_OP.OracleDbType = OracleDbType.Decimal;
                StatusId_OP.Value = StatusId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_NEW_RETAILER_FOR_APPROVE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_NEW_RETAILER_FOR_APPROVE>.GetDataBySP(new SP_GET_NEW_RETAILER_FOR_APPROVE(), "SP_FF_GET_NEW_RET_FOR_APPROVE", 30, resultOutCurSor, Id_OP, StatusId_OP, DateFrom_OP, DateTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_NEW_RETAILER_INFO> GetNewRetailerInfo(decimal Id, decimal StatusId, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter StatusId_OP = new OracleParameter();
                StatusId_OP.Direction = System.Data.ParameterDirection.Input;
                StatusId_OP.OracleDbType = OracleDbType.Decimal;
                StatusId_OP.Value = StatusId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_NEW_RETAILER_INFO>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_NEW_RETAILER_INFO>.GetDataBySP(new SP_GET_NEW_RETAILER_INFO(), "SP_FF_GET_NEW_RET_FOR_APPROVE", 30, resultOutCurSor, Id_OP, StatusId_OP, DateFrom_OP, DateTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_LOC_BY_ROUTE> GetRetailerLocationByRoute(decimal RouteId)
        {
            try
            {
                OracleParameter RouteId_OP = new OracleParameter();
                RouteId_OP.Direction = System.Data.ParameterDirection.Input;
                RouteId_OP.OracleDbType = OracleDbType.Varchar2;
                RouteId_OP.Value = RouteId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_LOC_BY_ROUTE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_LOC_BY_ROUTE>.GetDataBySP(new SP_GET_RETAILER_LOC_BY_ROUTE(), "SP_FF_GET_RET_LOC_BY_ROUTE", 4, resultOutCurSor, RouteId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_GPS_FOR_APPROVE> GetRetailerGPSUpdateForApprove(decimal Id)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_GPS_FOR_APPROVE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_GPS_FOR_APPROVE>.GetDataBySP(new SP_GET_RETAILER_GPS_FOR_APPROVE(), "SP_FF_GET_RET_GPS_FOR_APPROVE", 16, resultOutCurSor, Id_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_RETAILER_GPS> GetRetailerGPS(decimal Id, decimal ZoneId, decimal RouteId, decimal RetailerId)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = ZoneId;

                OracleParameter RouteId_OP = new OracleParameter();
                RouteId_OP.Direction = System.Data.ParameterDirection.Input;
                RouteId_OP.OracleDbType = OracleDbType.Decimal;
                RouteId_OP.Value = RouteId;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

              /*  OracleParameter VisitDate_OP = new OracleParameter();
                VisitDate_OP.Direction = System.Data.ParameterDirection.Input;
                VisitDate_OP.OracleDbType = OracleDbType.Date;
                VisitDate_OP.Value = VisitDate; */

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

               // return (List<SP_GET_RETAILER_GPS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_GPS>.GetDataBySP(new SP_GET_RETAILER_GPS(), "SP_FF_GET_RETAILER_GPS_V2", 13, resultOutCurSor, Id_OP, ZoneId_OP, RouteId_OP, RetailerId_OP, VisitDate_OP);
                return (List<SP_GET_RETAILER_GPS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_GPS>.GetDataBySP(new SP_GET_RETAILER_GPS(), "SP_FF_GET_RETAILER_GPS", 13, resultOutCurSor, Id_OP, ZoneId_OP, RouteId_OP, RetailerId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<SP_GET_RETAILER_GPS> GetRSORetailerGPS(decimal Id, decimal ZoneId, decimal RouteId, decimal RetailerId, DateTime VisitDate)
		{
			try
			{
				OracleParameter Id_OP = new OracleParameter();
				Id_OP.Direction = System.Data.ParameterDirection.Input;
				Id_OP.OracleDbType = OracleDbType.Decimal;
				Id_OP.Value = Id;

				OracleParameter ZoneId_OP = new OracleParameter();
				ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
				ZoneId_OP.OracleDbType = OracleDbType.Decimal;
				ZoneId_OP.Value = ZoneId;

				OracleParameter RouteId_OP = new OracleParameter();
				RouteId_OP.Direction = System.Data.ParameterDirection.Input;
				RouteId_OP.OracleDbType = OracleDbType.Decimal;
				RouteId_OP.Value = RouteId;

				OracleParameter RetailerId_OP = new OracleParameter();
				RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
				RetailerId_OP.OracleDbType = OracleDbType.Decimal;
				RetailerId_OP.Value = RetailerId;

				OracleParameter VisitDate_OP = new OracleParameter();
				VisitDate_OP.Direction = System.Data.ParameterDirection.Input;
				VisitDate_OP.OracleDbType = OracleDbType.Date;
				VisitDate_OP.Value = VisitDate;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_RETAILER_GPS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_GPS>.GetDataBySP(new SP_GET_RETAILER_GPS(), "SP_FF_GET_RETAILER_GPS_V2", 13, resultOutCurSor, Id_OP, ZoneId_OP, RouteId_OP, RetailerId_OP, VisitDate_OP);
				// return (List<SP_GET_RETAILER_GPS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_GPS>.GetDataBySP(new SP_GET_RETAILER_GPS(), "SP_FF_GET_RETAILER_GPS", 13, resultOutCurSor, Id_OP, ZoneId_OP, RouteId_OP, RetailerId_OP, VisitDate_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<SP_GET_FOOTSTEP_EXPORT1> GetFootsepExport(decimal Id, decimal ZoneId, decimal RouteId, decimal RetailerId, DateTime VisitDate)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = ZoneId;

                OracleParameter RouteId_OP = new OracleParameter();
                RouteId_OP.Direction = System.Data.ParameterDirection.Input;
                RouteId_OP.OracleDbType = OracleDbType.Decimal;
                RouteId_OP.Value = RouteId;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

                OracleParameter Flag_OP = new OracleParameter();
                Flag_OP.Direction = System.Data.ParameterDirection.Input;
                Flag_OP.OracleDbType = OracleDbType.Decimal;
                Flag_OP.Value = 0;

                OracleParameter VisitDate_OP = new OracleParameter();
                VisitDate_OP.Direction = System.Data.ParameterDirection.Input;
                VisitDate_OP.OracleDbType = OracleDbType.Date;
                VisitDate_OP.Value = VisitDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_FOOTSTEP_EXPORT1>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FOOTSTEP_EXPORT1>.GetDataBySP(new SP_GET_FOOTSTEP_EXPORT1(), "SP_FF_GET_FOOTSTEP_EXPORTV2", 14, resultOutCurSor, Id_OP, ZoneId_OP, RouteId_OP, RetailerId_OP, Flag_OP, VisitDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_FOOTSTEP_EXPORT2> GetFootsepExport_BTS(decimal Id, decimal ZoneId, decimal RouteId, decimal RetailerId, DateTime VisitDate)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = ZoneId;

                OracleParameter RouteId_OP = new OracleParameter();
                RouteId_OP.Direction = System.Data.ParameterDirection.Input;
                RouteId_OP.OracleDbType = OracleDbType.Decimal;
                RouteId_OP.Value = RouteId;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

                OracleParameter Flag_OP = new OracleParameter();
                Flag_OP.Direction = System.Data.ParameterDirection.Input;
                Flag_OP.OracleDbType = OracleDbType.Decimal;
                Flag_OP.Value = 1;

                OracleParameter VisitDate_OP = new OracleParameter();
                VisitDate_OP.Direction = System.Data.ParameterDirection.Input;
                VisitDate_OP.OracleDbType = OracleDbType.Date;
                VisitDate_OP.Value = VisitDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_FOOTSTEP_EXPORT2>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FOOTSTEP_EXPORT2>.GetDataBySP(new SP_GET_FOOTSTEP_EXPORT2(), "SP_FF_GET_FOOTSTEP_EXPORT", 3, resultOutCurSor, Id_OP, ZoneId_OP, RouteId_OP, RetailerId_OP, Flag_OP, VisitDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_BTS_GPS> GetBTSLocation(decimal Id, decimal ZoneId, decimal RouteId)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = ZoneId;

                OracleParameter RouteId_OP = new OracleParameter();
                RouteId_OP.Direction = System.Data.ParameterDirection.Input;
                RouteId_OP.OracleDbType = OracleDbType.Decimal;
                RouteId_OP.Value = RouteId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_BTS_GPS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_BTS_GPS>.GetDataBySP(new SP_GET_BTS_GPS(), "SP_FF_GET_BTS_GPS_INFO", 12, resultOutCurSor, Id_OP, ZoneId_OP, RouteId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_RETAILER_INFO_UPDATE_FOR_APPROVE> GetRetailerUpdatedInfoForApprove(decimal Id, decimal StatusId, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter StatusId_OP = new OracleParameter();
                StatusId_OP.Direction = System.Data.ParameterDirection.Input;
                StatusId_OP.OracleDbType = OracleDbType.Decimal;
                StatusId_OP.Value = StatusId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_INFO_UPDATE_FOR_APPROVE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_INFO_UPDATE_FOR_APPROVE>.GetDataBySP(new SP_GET_RETAILER_INFO_UPDATE_FOR_APPROVE(), "SP_FF_GET_RET_INFO_FOR_APPROVE", 46, resultOutCurSor, Id_OP, StatusId_OP, DateFrom_OP, DateTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_NEW_RETAILER_FOR_APPROVE> GetRetailerGPSForApprove(decimal Id)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Varchar2;
                Id_OP.Value = Id;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_NEW_RETAILER_FOR_APPROVE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_NEW_RETAILER_FOR_APPROVE>.GetDataBySP(new SP_GET_NEW_RETAILER_FOR_APPROVE(), "SP_FF_GET_NEW_RET_FOR_APPROVE", 28, resultOutCurSor, Id_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TRADE_MATERIAL_ISSUE> GetFOCIssuedMaterial(decimal RetailerId, decimal UserId)
        {
            try
            {
                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Varchar2;
                RetailerId_OP.Value = RetailerId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Varchar2;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TRADE_MATERIAL_ISSUE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TRADE_MATERIAL_ISSUE>.GetDataBySP(new SP_GET_TRADE_MATERIAL_ISSUE(), "SP_FF_GET_TRADE_MATERIAL_ISSUE", 3, resultOutCurSor, RetailerId_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_SALES_STOCK> GetSalesAndStock(decimal RetailerId, decimal UserId)
        {
            try
            {
                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Varchar2;
                RetailerId_OP.Value = RetailerId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Varchar2;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SALES_STOCK>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SALES_STOCK>.GetDataBySP(new SP_GET_SALES_STOCK(), "SP_FF_GET_SALES_STOCK", 3, resultOutCurSor, RetailerId_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateRetailerCreateReq(RetailerCreateRequest rcr)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = rcr.Id;

                OracleParameter CreatedRetailerCode_OP = new OracleParameter();
                CreatedRetailerCode_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedRetailerCode_OP.OracleDbType = OracleDbType.Varchar2;
                CreatedRetailerCode_OP.Value = rcr.CreatedRetailerCode;

                OracleParameter RetailerName_OP = new OracleParameter();
                RetailerName_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerName_OP.OracleDbType = OracleDbType.Varchar2;
                RetailerName_OP.Value = rcr.RetailerName;

                OracleParameter Distributor_OP = new OracleParameter();
                Distributor_OP.Direction = System.Data.ParameterDirection.Input;
                Distributor_OP.OracleDbType = OracleDbType.Decimal;
                Distributor_OP.Value = rcr.Distributor;

                OracleParameter Teritory_OP = new OracleParameter();
                Teritory_OP.Direction = System.Data.ParameterDirection.Input;
                Teritory_OP.OracleDbType = OracleDbType.Decimal;
                Teritory_OP.Value = rcr.Teritory;

                OracleParameter OwnShop_OP = new OracleParameter();
                OwnShop_OP.Direction = System.Data.ParameterDirection.Input;
                OwnShop_OP.OracleDbType = OracleDbType.Varchar2;
                OwnShop_OP.Value = rcr.OwnShop;

                OracleParameter Address_OP = new OracleParameter();
                Address_OP.Direction = System.Data.ParameterDirection.Input;
                Address_OP.OracleDbType = OracleDbType.Varchar2;
                Address_OP.Value = rcr.Address;

                OracleParameter ShopSize_OP = new OracleParameter();
                ShopSize_OP.Direction = System.Data.ParameterDirection.Input;
                ShopSize_OP.OracleDbType = OracleDbType.Decimal;
                ShopSize_OP.Value = rcr.ShopSize;

                OracleParameter OwnerName_OP = new OracleParameter();
                OwnerName_OP.Direction = System.Data.ParameterDirection.Input;
                OwnerName_OP.OracleDbType = OracleDbType.Varchar2;
                OwnerName_OP.Value = rcr.OwnerName;

                OracleParameter ContactPerson_OP = new OracleParameter();
                ContactPerson_OP.Direction = System.Data.ParameterDirection.Input;
                ContactPerson_OP.OracleDbType = OracleDbType.Varchar2;
                ContactPerson_OP.Value = rcr.ContactPerson;

                OracleParameter ContactNo_OP = new OracleParameter();
                ContactNo_OP.Direction = System.Data.ParameterDirection.Input;
                ContactNo_OP.OracleDbType = OracleDbType.Varchar2;
                ContactNo_OP.Value = rcr.ContactNo;

                OracleParameter DistrictId_OP = new OracleParameter();
                DistrictId_OP.Direction = System.Data.ParameterDirection.Input;
                DistrictId_OP.OracleDbType = OracleDbType.Decimal;
                DistrictId_OP.Value = rcr.DistrictId;

                OracleParameter ThanaId_OP = new OracleParameter();
                ThanaId_OP.Direction = System.Data.ParameterDirection.Input;
                ThanaId_OP.OracleDbType = OracleDbType.Decimal;
                ThanaId_OP.Value = rcr.ThanaId;

                OracleParameter RequestStatus_OP = new OracleParameter();
                RequestStatus_OP.Direction = System.Data.ParameterDirection.Input;
                RequestStatus_OP.OracleDbType = OracleDbType.Decimal;
                RequestStatus_OP.Value = rcr.RequestStatus;

                OracleParameter RequesterComment_OP = new OracleParameter();
                RequesterComment_OP.Direction = System.Data.ParameterDirection.Input;
                RequesterComment_OP.OracleDbType = OracleDbType.Varchar2;
                RequesterComment_OP.Value = rcr.RequesterComment;

                OracleParameter ApproversComment_OP = new OracleParameter();
                ApproversComment_OP.Direction = System.Data.ParameterDirection.Input;
                ApproversComment_OP.OracleDbType = OracleDbType.Varchar2;
                ApproversComment_OP.Value = rcr.ApproversComment;

                OracleParameter CreatedRetailerId_OP = new OracleParameter();
                CreatedRetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedRetailerId_OP.OracleDbType = OracleDbType.Varchar2;
                CreatedRetailerId_OP.Value = rcr.CreatedRetailerId;

                OracleParameter RequestedBy_OP = new OracleParameter();
                RequestedBy_OP.Direction = System.Data.ParameterDirection.Input;
                RequestedBy_OP.OracleDbType = OracleDbType.Decimal;
                RequestedBy_OP.Value = rcr.RequestedBy;

                OracleParameter LocLatitude_OP = new OracleParameter();
                LocLatitude_OP.Direction = System.Data.ParameterDirection.Input;
                LocLatitude_OP.OracleDbType = OracleDbType.Decimal;
                LocLatitude_OP.Value = rcr.LocLatitude;

                OracleParameter LocLongitude_OP = new OracleParameter();
                LocLongitude_OP.Direction = System.Data.ParameterDirection.Input;
                LocLongitude_OP.OracleDbType = OracleDbType.Decimal;
                LocLongitude_OP.Value = rcr.LocLongitude;

                OracleParameter OtherOperatorCode1_OP = new OracleParameter();
                OtherOperatorCode1_OP.Direction = System.Data.ParameterDirection.Input;
                OtherOperatorCode1_OP.OracleDbType = OracleDbType.Varchar2;
                OtherOperatorCode1_OP.Value = rcr.OtherOperatorCode1;

                OracleParameter AvgDailyPechrageOp1_OP = new OracleParameter();
                AvgDailyPechrageOp1_OP.Direction = System.Data.ParameterDirection.Input;
                AvgDailyPechrageOp1_OP.OracleDbType = OracleDbType.Decimal;
                AvgDailyPechrageOp1_OP.Value = rcr.AvgDailyPechrageOp1;

                OracleParameter AvgWeeklySimOp1_OP = new OracleParameter();
                AvgWeeklySimOp1_OP.Direction = System.Data.ParameterDirection.Input;
                AvgWeeklySimOp1_OP.OracleDbType = OracleDbType.Decimal;
                AvgWeeklySimOp1_OP.Value = rcr.AvgWeeklySimOp1;

                OracleParameter OtherOperatorCode2_OP = new OracleParameter();
                OtherOperatorCode2_OP.Direction = System.Data.ParameterDirection.Input;
                OtherOperatorCode2_OP.OracleDbType = OracleDbType.Varchar2;
                OtherOperatorCode2_OP.Value = rcr.OtherOperatorCode2;

                OracleParameter AvgDailyPechrageOp2_OP = new OracleParameter();
                AvgDailyPechrageOp2_OP.Direction = System.Data.ParameterDirection.Input;
                AvgDailyPechrageOp2_OP.OracleDbType = OracleDbType.Decimal;
                AvgDailyPechrageOp2_OP.Value = rcr.AvgDailyPechrageOp2;

                OracleParameter AvgWeeklySimOp2_OP = new OracleParameter();
                AvgWeeklySimOp2_OP.Direction = System.Data.ParameterDirection.Input;
                AvgWeeklySimOp2_OP.OracleDbType = OracleDbType.Decimal;
                AvgWeeklySimOp2_OP.Value = rcr.AvgWeeklySimOp2;

                OracleParameter OtherOperatorCode3_OP = new OracleParameter();
                OtherOperatorCode3_OP.Direction = System.Data.ParameterDirection.Input;
                OtherOperatorCode3_OP.OracleDbType = OracleDbType.Varchar2;
                OtherOperatorCode3_OP.Value = rcr.OtherOperatorCode3;

                OracleParameter AvgDailyPechrageOp3_OP = new OracleParameter();
                AvgDailyPechrageOp3_OP.Direction = System.Data.ParameterDirection.Input;
                AvgDailyPechrageOp3_OP.OracleDbType = OracleDbType.Decimal;
                AvgDailyPechrageOp3_OP.Value = rcr.AvgDailyPechrageOp3;

                OracleParameter AvgWeeklySimOp3_OP = new OracleParameter();
                AvgWeeklySimOp3_OP.Direction = System.Data.ParameterDirection.Input;
                AvgWeeklySimOp3_OP.OracleDbType = OracleDbType.Decimal;
                AvgWeeklySimOp3_OP.Value = rcr.AvgWeeklySimOp3;

                OracleParameter OutletPicture01_OP = new OracleParameter();
                OutletPicture01_OP.Direction = System.Data.ParameterDirection.Input;
                OutletPicture01_OP.OracleDbType = OracleDbType.Blob;
                OutletPicture01_OP.Value = rcr.OutletPicture01;

                OracleParameter OutletPicture02_OP = new OracleParameter();
                OutletPicture02_OP.Direction = System.Data.ParameterDirection.Input;
                OutletPicture02_OP.OracleDbType = OracleDbType.Blob;
                OutletPicture02_OP.Value = rcr.OutletPicture02;

                OracleParameter OutletPicture03_OP = new OracleParameter();
                OutletPicture03_OP.Direction = System.Data.ParameterDirection.Input;
                OutletPicture03_OP.OracleDbType = OracleDbType.Blob;
                OutletPicture03_OP.Value = rcr.OutletPicture03;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_UP_RETAILER_CREATE", resultOutID, Id_OP, CreatedRetailerCode_OP, RetailerName_OP, Distributor_OP, Teritory_OP, OwnShop_OP, Address_OP, ShopSize_OP, OwnerName_OP, ContactPerson_OP, ContactNo_OP, DistrictId_OP, ThanaId_OP, RequestStatus_OP, RequesterComment_OP, ApproversComment_OP, CreatedRetailerId_OP, RequestedBy_OP, LocLatitude_OP, LocLongitude_OP, OtherOperatorCode1_OP, AvgDailyPechrageOp1_OP, AvgWeeklySimOp1_OP, OtherOperatorCode2_OP, AvgDailyPechrageOp2_OP, AvgWeeklySimOp2_OP, OtherOperatorCode3_OP, AvgDailyPechrageOp3_OP, AvgWeeklySimOp3_OP, OutletPicture01_OP, OutletPicture02_OP, OutletPicture03_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveRetailerGPSUpdateApprove(decimal RetailerModifyId, decimal ActionType, string ApproverComment)
        {
            try
            {
                OracleParameter RetailerModifyId_OP = new OracleParameter();
                RetailerModifyId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerModifyId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerModifyId_OP.Value = RetailerModifyId;

                OracleParameter ActionType_OP = new OracleParameter();
                ActionType_OP.Direction = System.Data.ParameterDirection.Input;
                ActionType_OP.OracleDbType = OracleDbType.Decimal;
                ActionType_OP.Value = ActionType;

                OracleParameter ApproverComment_OP = new OracleParameter();
                ApproverComment_OP.Direction = System.Data.ParameterDirection.Input;
                ApproverComment_OP.OracleDbType = OracleDbType.Varchar2;
                ApproverComment_OP.Value = ApproverComment;


                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_RET_GPS_UP_REQ_APRVE", resultOutID, RetailerModifyId_OP, ActionType_OP, ApproverComment_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_CURRENT_INFO> GetRetailerCurrentInfo(decimal RetailerId)
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

                return (List<SP_GET_RETAILER_CURRENT_INFO>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_CURRENT_INFO>.GetDataBySP(new SP_GET_RETAILER_CURRENT_INFO(), "SP_FF_GET_RET_CURRENT_INFO", 20, resultOutCurSor, RetailerId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveRetailerCreateApprove(decimal RetailerModifyId, decimal ActionType, string ApproverComment)
        {
            try
            {
                OracleParameter RetailerModifyId_OP = new OracleParameter();
                RetailerModifyId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerModifyId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerModifyId_OP.Value = RetailerModifyId;

                OracleParameter ActionType_OP = new OracleParameter();
                ActionType_OP.Direction = System.Data.ParameterDirection.Input;
                ActionType_OP.OracleDbType = OracleDbType.Decimal;
                ActionType_OP.Value = ActionType;

                OracleParameter ApproverComment_OP = new OracleParameter();
                ApproverComment_OP.Direction = System.Data.ParameterDirection.Input;
                ApproverComment_OP.OracleDbType = OracleDbType.Varchar2;
                ApproverComment_OP.Value = ApproverComment;


                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_RET_CREATE_REQ_APRVE", resultOutID, RetailerModifyId_OP, ActionType_OP, ApproverComment_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SubmitComplainStatus(decimal ComplainId, int? StatusId, string ResolutionDetail, decimal UserId)
        {
            try
            {
                OracleParameter ComplainId_OP = new OracleParameter();
                ComplainId_OP.Direction = System.Data.ParameterDirection.Input;
                ComplainId_OP.OracleDbType = OracleDbType.Decimal;
                ComplainId_OP.Value = ComplainId;

                OracleParameter StatusId_OP = new OracleParameter();
                StatusId_OP.Direction = System.Data.ParameterDirection.Input;
                StatusId_OP.OracleDbType = OracleDbType.Decimal;
                StatusId_OP.Value = StatusId;

                OracleParameter ResolutionDetail_OP = new OracleParameter();
                ResolutionDetail_OP.Direction = System.Data.ParameterDirection.Input;
                ResolutionDetail_OP.OracleDbType = OracleDbType.Varchar2;
                ResolutionDetail_OP.Value = ResolutionDetail;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_UPD_COMPLAIN_STATUS", resultOutID, ComplainId_OP, StatusId_OP, ResolutionDetail_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateRetailerModifyReq(RetailerModifyRequest rmr)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = rmr.Id;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = rmr.RetailerId;

                OracleParameter RetailerCode_OP = new OracleParameter();
                RetailerCode_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerCode_OP.OracleDbType = OracleDbType.Varchar2;
                RetailerCode_OP.Value = rmr.RetailerCode;

                OracleParameter ModifiedName_OP = new OracleParameter();
                ModifiedName_OP.Direction = System.Data.ParameterDirection.Input;
                ModifiedName_OP.OracleDbType = OracleDbType.Varchar2;
                ModifiedName_OP.Value = rmr.ModifiedName;

                OracleParameter ModifiedOwnerName_OP = new OracleParameter();
                ModifiedOwnerName_OP.Direction = System.Data.ParameterDirection.Input;
                ModifiedOwnerName_OP.OracleDbType = OracleDbType.Varchar2;
                ModifiedOwnerName_OP.Value = rmr.ModifiedOwnerName;

                OracleParameter ModifiedContactPerson_OP = new OracleParameter();
                ModifiedContactPerson_OP.Direction = System.Data.ParameterDirection.Input;
                ModifiedContactPerson_OP.OracleDbType = OracleDbType.Varchar2;
                ModifiedContactPerson_OP.Value = rmr.ModifiedContactPerson;

                OracleParameter ModifiedContactNo_OP = new OracleParameter();
                ModifiedContactNo_OP.Direction = System.Data.ParameterDirection.Input;
                ModifiedContactNo_OP.OracleDbType = OracleDbType.Varchar2;
                ModifiedContactNo_OP.Value = rmr.ModifiedContactNo;

                OracleParameter ModifiedAddress_OP = new OracleParameter();
                ModifiedAddress_OP.Direction = System.Data.ParameterDirection.Input;
                ModifiedAddress_OP.OracleDbType = OracleDbType.Varchar2;
                ModifiedAddress_OP.Value = rmr.ModifiedAddress;

                OracleParameter RequestStatus_OP = new OracleParameter();
                RequestStatus_OP.Direction = System.Data.ParameterDirection.Input;
                RequestStatus_OP.OracleDbType = OracleDbType.Decimal;
                RequestStatus_OP.Value = rmr.RequestStatus;

                OracleParameter OutletPicture_OP = new OracleParameter();
                OutletPicture_OP.Direction = System.Data.ParameterDirection.Input;
                OutletPicture_OP.OracleDbType = OracleDbType.Blob;
                OutletPicture_OP.Value = rmr.OutletPicture;

                OracleParameter OutletPicture02_OP = new OracleParameter();
                OutletPicture02_OP.Direction = System.Data.ParameterDirection.Input;
                OutletPicture02_OP.OracleDbType = OracleDbType.Blob;
                OutletPicture02_OP.Value = rmr.OutletPicture02;

                OracleParameter OutletPicture03_OP = new OracleParameter();
                OutletPicture03_OP.Direction = System.Data.ParameterDirection.Input;
                OutletPicture03_OP.OracleDbType = OracleDbType.Blob;
                OutletPicture03_OP.Value = rmr.OutletPicture03;

                OracleParameter ModifiedOwnShop_OP = new OracleParameter();
                ModifiedOwnShop_OP.Direction = System.Data.ParameterDirection.Input;
                ModifiedOwnShop_OP.OracleDbType = OracleDbType.Varchar2;
                ModifiedOwnShop_OP.Value = rmr.ModifiedOwnShop;

                OracleParameter ModifiedShopSize_OP = new OracleParameter();
                ModifiedShopSize_OP.Direction = System.Data.ParameterDirection.Input;
                ModifiedShopSize_OP.OracleDbType = OracleDbType.Decimal;
                ModifiedShopSize_OP.Value = rmr.ModifiedShopSize;

                OracleParameter ModifiedDistrictId_OP = new OracleParameter();
                ModifiedDistrictId_OP.Direction = System.Data.ParameterDirection.Input;
                ModifiedDistrictId_OP.OracleDbType = OracleDbType.Decimal;
                ModifiedDistrictId_OP.Value = rmr.ModifiedDistrictId;

                OracleParameter ModifiedThanaId_OP = new OracleParameter();
                ModifiedThanaId_OP.Direction = System.Data.ParameterDirection.Input;
                ModifiedThanaId_OP.OracleDbType = OracleDbType.Decimal;
                ModifiedThanaId_OP.Value = rmr.ModifiedThanaId;

                OracleParameter RequesterComment_OP = new OracleParameter();
                RequesterComment_OP.Direction = System.Data.ParameterDirection.Input;
                RequesterComment_OP.OracleDbType = OracleDbType.Varchar2;
                RequesterComment_OP.Value = rmr.RequesterComment;

                OracleParameter OtherOperatorCode1_OP = new OracleParameter();
                OtherOperatorCode1_OP.Direction = System.Data.ParameterDirection.Input;
                OtherOperatorCode1_OP.OracleDbType = OracleDbType.Varchar2;
                OtherOperatorCode1_OP.Value = rmr.OtherOperatorCode1;

                OracleParameter AvgDailyPechrageOp1_OP = new OracleParameter();
                AvgDailyPechrageOp1_OP.Direction = System.Data.ParameterDirection.Input;
                AvgDailyPechrageOp1_OP.OracleDbType = OracleDbType.Decimal;
                AvgDailyPechrageOp1_OP.Value = rmr.AvgDailyPechrageOp1;

                OracleParameter AvgWeeklySimOp1_OP = new OracleParameter();
                AvgWeeklySimOp1_OP.Direction = System.Data.ParameterDirection.Input;
                AvgWeeklySimOp1_OP.OracleDbType = OracleDbType.Decimal;
                AvgWeeklySimOp1_OP.Value = rmr.AvgWeeklySimOp1;

                OracleParameter OtherOperatorCode2_OP = new OracleParameter();
                OtherOperatorCode2_OP.Direction = System.Data.ParameterDirection.Input;
                OtherOperatorCode2_OP.OracleDbType = OracleDbType.Varchar2;
                OtherOperatorCode2_OP.Value = rmr.OtherOperatorCode2;

                OracleParameter AvgDailyPechrageOp2_OP = new OracleParameter();
                AvgDailyPechrageOp2_OP.Direction = System.Data.ParameterDirection.Input;
                AvgDailyPechrageOp2_OP.OracleDbType = OracleDbType.Decimal;
                AvgDailyPechrageOp2_OP.Value = rmr.AvgDailyPechrageOp2;

                OracleParameter AvgWeeklySimOp2_OP = new OracleParameter();
                AvgWeeklySimOp2_OP.Direction = System.Data.ParameterDirection.Input;
                AvgWeeklySimOp2_OP.OracleDbType = OracleDbType.Decimal;
                AvgWeeklySimOp2_OP.Value = rmr.AvgWeeklySimOp2;

                OracleParameter OtherOperatorCode3_OP = new OracleParameter();
                OtherOperatorCode3_OP.Direction = System.Data.ParameterDirection.Input;
                OtherOperatorCode3_OP.OracleDbType = OracleDbType.Varchar2;
                OtherOperatorCode3_OP.Value = rmr.OtherOperatorCode3;

                OracleParameter AvgDailyPechrageOp3_OP = new OracleParameter();
                AvgDailyPechrageOp3_OP.Direction = System.Data.ParameterDirection.Input;
                AvgDailyPechrageOp3_OP.OracleDbType = OracleDbType.Decimal;
                AvgDailyPechrageOp3_OP.Value = rmr.AvgDailyPechrageOp3;

                OracleParameter AvgWeeklySimOp3_OP = new OracleParameter();
                AvgWeeklySimOp3_OP.Direction = System.Data.ParameterDirection.Input;
                AvgWeeklySimOp3_OP.OracleDbType = OracleDbType.Decimal;
                AvgWeeklySimOp3_OP.Value = rmr.AvgWeeklySimOp3;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_UP_RET_MODIFY_REQ", resultOutID, Id_OP, RetailerId_OP, RetailerCode_OP, ModifiedName_OP, ModifiedOwnerName_OP, ModifiedContactPerson_OP, ModifiedContactNo_OP, ModifiedAddress_OP, RequestStatus_OP, OutletPicture_OP, OutletPicture02_OP, OutletPicture03_OP, ModifiedOwnShop_OP, ModifiedShopSize_OP, ModifiedDistrictId_OP, ModifiedThanaId_OP, RequesterComment_OP, OtherOperatorCode1_OP, AvgDailyPechrageOp1_OP, AvgWeeklySimOp1_OP, OtherOperatorCode2_OP, AvgDailyPechrageOp2_OP, AvgWeeklySimOp2_OP, OtherOperatorCode3_OP, AvgDailyPechrageOp3_OP, AvgWeeklySimOp3_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveRetailerModifyApprove(decimal RetailerModifyId, decimal ActionType, string ApproverComment)
        {
            try
            {
                OracleParameter RetailerModifyId_OP = new OracleParameter();
                RetailerModifyId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerModifyId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerModifyId_OP.Value = RetailerModifyId;

                OracleParameter ActionType_OP = new OracleParameter();
                ActionType_OP.Direction = System.Data.ParameterDirection.Input;
                ActionType_OP.OracleDbType = OracleDbType.Decimal;
                ActionType_OP.Value = ActionType;

                OracleParameter ApproverComment_OP = new OracleParameter();
                ApproverComment_OP.Direction = System.Data.ParameterDirection.Input;
                ApproverComment_OP.OracleDbType = OracleDbType.Varchar2;
                ApproverComment_OP.Value = ApproverComment;


                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_RET_MODIFY_REQ_APRVE", resultOutID, RetailerModifyId_OP, ActionType_OP, ApproverComment_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_STOCK> GetRetailerStock(SearchParam searchParam)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = searchParam.ZoneId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_STOCK>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_STOCK>.GetDataBySP(new SP_GET_RETAILER_STOCK(), "SP_FF_GET_RETAILER_STOCK", 11, resultOutCurSor, ZoneId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_SALES> GetRetailerSales(SearchParam searchParam)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = searchParam.ZoneId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = searchParam.FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = searchParam.ToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_SALES>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_SALES>.GetDataBySP(new SP_GET_RETAILER_SALES(), "SP_FF_GET_RETAILER_SALES", 14, resultOutCurSor, ZoneId_OP, FromDate_OP, ToDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_LOCATION_UPDATE> GetRetailerLocationUpdate(SearchParam searchParam)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = searchParam.ZoneId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_LOCATION_UPDATE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_LOCATION_UPDATE>.GetDataBySP(new SP_GET_RETAILER_LOCATION_UPDATE(), "SP_FF_GET_RETAILER_LOC_UPDATE", 10, resultOutCurSor, ZoneId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_SAF> GetRetailerSaf(SearchParam searchParam, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = searchParam.ZoneId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_SAF>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_SAF>.GetDataBySP(new SP_GET_RETAILER_SAF(), "SP_FF_GET_RETAILER_SAF", 9, resultOutCurSor, ZoneId_OP, DateFrom_OP, DateTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_SAF> GetIssuedFOCProducts(SearchParam searchParam, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = searchParam.ZoneId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_SAF>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_SAF>.GetDataBySP(new SP_GET_RETAILER_SAF(), "SP_FF_GET_RETAILER_SAF", 9, resultOutCurSor, ZoneId_OP, DateFrom_OP, DateTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_COMMISSION> GetRetailerCommission(SearchParam searchParam, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = searchParam.ZoneId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_COMMISSION>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_COMMISSION>.GetDataBySP(new SP_GET_RETAILER_COMMISSION(), "SP_FF_GET_RETAILER_COMMISSION", 11, resultOutCurSor, ZoneId_OP, DateFrom_OP, DateTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateFOCProductIssue(TradeMaterialIssue tmi)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = tmi.Id;

                OracleParameter ReceiverType_OP = new OracleParameter();
                ReceiverType_OP.Direction = System.Data.ParameterDirection.Input;
                ReceiverType_OP.OracleDbType = OracleDbType.Decimal;
                ReceiverType_OP.Value = tmi.ReceiverType;

                OracleParameter ReceiverId_OP = new OracleParameter();
                ReceiverId_OP.Direction = System.Data.ParameterDirection.Input;
                ReceiverId_OP.OracleDbType = OracleDbType.Decimal;
                ReceiverId_OP.Value = tmi.ReceiverId;

                OracleParameter IssuedByUser_OP = new OracleParameter();
                IssuedByUser_OP.Direction = System.Data.ParameterDirection.Input;
                IssuedByUser_OP.OracleDbType = OracleDbType.Decimal;
                IssuedByUser_OP.Value = tmi.IssuedByUser;

                OracleParameter MaterialId_OP = new OracleParameter();
                MaterialId_OP.Direction = System.Data.ParameterDirection.Input;
                MaterialId_OP.OracleDbType = OracleDbType.Decimal;
                MaterialId_OP.Value = tmi.MaterialId;

                OracleParameter IssueQty_OP = new OracleParameter();
                IssueQty_OP.Direction = System.Data.ParameterDirection.Input;
                IssueQty_OP.OracleDbType = OracleDbType.Decimal;
                IssueQty_OP.Value = tmi.IssueQty;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = tmi.CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_UP_TRADE_MAT_ISSUE", resultOutID, Id_OP, IssuedByUser_OP, ReceiverType_OP, ReceiverId_OP, MaterialId_OP, IssueQty_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveRetailerModifyReqApprove(TradeMaterialIssue tmi)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = tmi.Id;

                OracleParameter ReceiverType_OP = new OracleParameter();
                ReceiverType_OP.Direction = System.Data.ParameterDirection.Input;
                ReceiverType_OP.OracleDbType = OracleDbType.Decimal;
                ReceiverType_OP.Value = tmi.ReceiverType;

                OracleParameter ReceiverId_OP = new OracleParameter();
                ReceiverId_OP.Direction = System.Data.ParameterDirection.Input;
                ReceiverId_OP.OracleDbType = OracleDbType.Decimal;
                ReceiverId_OP.Value = tmi.ReceiverId;

                OracleParameter IssuedByUser_OP = new OracleParameter();
                IssuedByUser_OP.Direction = System.Data.ParameterDirection.Input;
                IssuedByUser_OP.OracleDbType = OracleDbType.Decimal;
                IssuedByUser_OP.Value = tmi.IssuedByUser;

                OracleParameter MaterialId_OP = new OracleParameter();
                MaterialId_OP.Direction = System.Data.ParameterDirection.Input;
                MaterialId_OP.OracleDbType = OracleDbType.Decimal;
                MaterialId_OP.Value = tmi.MaterialId;

                OracleParameter IssueQty_OP = new OracleParameter();
                IssueQty_OP.Direction = System.Data.ParameterDirection.Input;
                IssueQty_OP.OracleDbType = OracleDbType.Decimal;
                IssueQty_OP.Value = tmi.IssueQty;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = tmi.CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_UP_TRADE_MAT_ISSUE", resultOutID, Id_OP, IssuedByUser_OP, ReceiverType_OP ,ReceiverId_OP,  MaterialId_OP, IssueQty_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_SAVE_RESULT_WITH_ERROR_CODE> SaveUpdateMarketUpdate(MarketUpdate mu)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = mu.Id;

                OracleParameter DistributorCode_OP = new OracleParameter();
                DistributorCode_OP.Direction = System.Data.ParameterDirection.Input;
                DistributorCode_OP.OracleDbType = OracleDbType.Varchar2;
                DistributorCode_OP.Value = mu.DistributorCode;

                OracleParameter RetailerCode_OP = new OracleParameter();
                RetailerCode_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerCode_OP.OracleDbType = OracleDbType.Varchar2;
                RetailerCode_OP.Value = mu.RetailerCode;

                OracleParameter EventId_OP = new OracleParameter();
                EventId_OP.Direction = System.Data.ParameterDirection.Input;
                EventId_OP.OracleDbType = OracleDbType.Decimal;
                EventId_OP.Value = mu.EventId;

                OracleParameter EventName_OP = new OracleParameter();
                EventName_OP.Direction = System.Data.ParameterDirection.Input;
                EventName_OP.OracleDbType = OracleDbType.Varchar2;
                EventName_OP.Value = mu.EventName;

                OracleParameter OperatorCode_OP = new OracleParameter();
                OperatorCode_OP.Direction = System.Data.ParameterDirection.Input;
                OperatorCode_OP.OracleDbType = OracleDbType.Varchar2;
                OperatorCode_OP.Value = mu.OperatorCode;

                OracleParameter Note_OP = new OracleParameter();
                Note_OP.Direction = System.Data.ParameterDirection.Input;
                Note_OP.OracleDbType = OracleDbType.NVarchar2;
                Note_OP.Value = mu.Note;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = mu.CreatedBy;

                OracleParameter MarketUpdateTypeId_OP = new OracleParameter();
                MarketUpdateTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                MarketUpdateTypeId_OP.OracleDbType = OracleDbType.Decimal;
                MarketUpdateTypeId_OP.Value = mu.MarketUpdateTypeId;

                OracleParameter Latitude_OP = new OracleParameter();
                Latitude_OP.Direction = System.Data.ParameterDirection.Input;
                Latitude_OP.OracleDbType = OracleDbType.Decimal;
                Latitude_OP.Value = mu.Latitude;

                OracleParameter Longitude_OP = new OracleParameter();
                Longitude_OP.Direction = System.Data.ParameterDirection.Input;
                Longitude_OP.OracleDbType = OracleDbType.Decimal;
                Longitude_OP.Value = mu.Longitude;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SAVE_RESULT_WITH_ERROR_CODE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SAVE_RESULT_WITH_ERROR_CODE>.GetDataBySP(new SP_GET_SAVE_RESULT_WITH_ERROR_CODE(), "SP_FF_IN_UP_MARKET_UPDATE", 2, resultOutCurSor, Id_OP, DistributorCode_OP, RetailerCode_OP, EventId_OP, EventName_OP, OperatorCode_OP, Note_OP, CreatedBy_OP, MarketUpdateTypeId_OP, Latitude_OP, Longitude_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateRetailerCheckout(RetailerCheckout retailerCheckout)
        {
            try
            {
                OracleParameter PlanId_OP = new OracleParameter();
                PlanId_OP.Direction = System.Data.ParameterDirection.Input;
                PlanId_OP.OracleDbType = OracleDbType.Decimal;
                PlanId_OP.Value = retailerCheckout.PlanId;

                OracleParameter FeedbackStatusId_OP = new OracleParameter();
                FeedbackStatusId_OP.Direction = System.Data.ParameterDirection.Input;
                FeedbackStatusId_OP.OracleDbType = OracleDbType.Decimal;
                FeedbackStatusId_OP.Value = retailerCheckout.FeedbackStatusId;

                OracleParameter FeedbackNote_OP = new OracleParameter();
                FeedbackNote_OP.Direction = System.Data.ParameterDirection.Input;
                FeedbackNote_OP.OracleDbType = OracleDbType.NVarchar2;
                FeedbackNote_OP.Value = retailerCheckout.FeedbackNote;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = retailerCheckout.RetailerId;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = retailerCheckout.CreatedBy;

                OracleParameter Latitude_OP = new OracleParameter();
                Latitude_OP.Direction = System.Data.ParameterDirection.Input;
                Latitude_OP.OracleDbType = OracleDbType.Decimal;
                Latitude_OP.Value = retailerCheckout.Latitude;

                OracleParameter Longitude_OP = new OracleParameter();
                Longitude_OP.Direction = System.Data.ParameterDirection.Input;
                Longitude_OP.OracleDbType = OracleDbType.Decimal;
                Longitude_OP.Value = retailerCheckout.Longitude;

                OracleParameter AreaId_OP = new OracleParameter();
                AreaId_OP.Direction = System.Data.ParameterDirection.Input;
                AreaId_OP.OracleDbType = OracleDbType.Decimal;
                AreaId_OP.Value = retailerCheckout.AreaId;

                OracleParameter MemoNo_OP = new OracleParameter();
                MemoNo_OP.Direction = System.Data.ParameterDirection.Input;
                MemoNo_OP.OracleDbType = OracleDbType.Varchar2;
                MemoNo_OP.Value = retailerCheckout.MemoNo;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_RETAILER_CHECKOUT", resultOutID, PlanId_OP, FeedbackStatusId_OP, FeedbackNote_OP, RetailerId_OP, CreatedBy_OP, Latitude_OP, Longitude_OP, AreaId_OP, MemoNo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



		public Decimal SaveUpdateRetailerCheckin(RetailerCheckin RetailerCheckin)
		{
			try
			{
				OracleParameter PlanId_OP = new OracleParameter();
				PlanId_OP.Direction = System.Data.ParameterDirection.Input;
				PlanId_OP.OracleDbType = OracleDbType.Decimal;
				PlanId_OP.Value = RetailerCheckin.PlanId;
				
				OracleParameter RetailerId_OP = new OracleParameter();
				RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
				RetailerId_OP.OracleDbType = OracleDbType.Decimal;
				RetailerId_OP.Value = RetailerCheckin.RetailerId;

				OracleParameter CreatedBy_OP = new OracleParameter();
				CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
				CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
				CreatedBy_OP.Value = RetailerCheckin.CreatedBy;

				OracleParameter Latitude_OP = new OracleParameter();
				Latitude_OP.Direction = System.Data.ParameterDirection.Input;
				Latitude_OP.OracleDbType = OracleDbType.Decimal;
				Latitude_OP.Value = RetailerCheckin.Latitude;

				OracleParameter Longitude_OP = new OracleParameter();
				Longitude_OP.Direction = System.Data.ParameterDirection.Input;
				Longitude_OP.OracleDbType = OracleDbType.Decimal;
				Longitude_OP.Value = RetailerCheckin.Longitude;

				OracleParameter AreaId_OP = new OracleParameter();
				AreaId_OP.Direction = System.Data.ParameterDirection.Input;
				AreaId_OP.OracleDbType = OracleDbType.Decimal;
				AreaId_OP.Value = RetailerCheckin.AreaId;

				

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_RETAILER_CHECKIN", resultOutID, PlanId_OP, RetailerId_OP, CreatedBy_OP, Latitude_OP, Longitude_OP, AreaId_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Decimal SaveUpdateComplain(Complain complain)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = complain.Id;

                OracleParameter TypeId_OP = new OracleParameter();
                TypeId_OP.Direction = System.Data.ParameterDirection.Input;
                TypeId_OP.OracleDbType = OracleDbType.Decimal;
                TypeId_OP.Value = complain.TypeId;

                OracleParameter ComplainFor_OP = new OracleParameter();
                ComplainFor_OP.Direction = System.Data.ParameterDirection.Input;
                ComplainFor_OP.OracleDbType = OracleDbType.Decimal;
                ComplainFor_OP.Value = complain.ComplainFor;

                OracleParameter ComplainForCode_OP = new OracleParameter();
                ComplainForCode_OP.Direction = System.Data.ParameterDirection.Input;
                ComplainForCode_OP.OracleDbType = OracleDbType.Varchar2;
                ComplainForCode_OP.Value = complain.ComplainForCode;

                OracleParameter Description_OP = new OracleParameter();
                Description_OP.Direction = System.Data.ParameterDirection.Input;
                Description_OP.OracleDbType = OracleDbType.NVarchar2;
                Description_OP.Value = complain.Description;

                OracleParameter ResolutionDetail_OP = new OracleParameter();
                ResolutionDetail_OP.Direction = System.Data.ParameterDirection.Input;
                ResolutionDetail_OP.OracleDbType = OracleDbType.NVarchar2;
                ResolutionDetail_OP.Value = complain.ResolutionDetail;

                OracleParameter StatusId_OP = new OracleParameter();
                StatusId_OP.Direction = System.Data.ParameterDirection.Input;
                StatusId_OP.OracleDbType = OracleDbType.Decimal;
                StatusId_OP.Value = complain.StatusId;

                OracleParameter RaisedByUser_OP = new OracleParameter();
                RaisedByUser_OP.Direction = System.Data.ParameterDirection.Input;
                RaisedByUser_OP.OracleDbType = OracleDbType.Decimal;
                RaisedByUser_OP.Value = complain.RaisedByUser;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_UP_COMPLAIN", resultOutID, Id_OP, TypeId_OP,  ComplainFor_OP, ComplainForCode_OP, Description_OP, ResolutionDetail_OP, StatusId_OP,  RaisedByUser_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateProductDelivery(ProductDelivery productDelivery)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = productDelivery.Id;

                OracleParameter ProductId_OP = new OracleParameter();
                ProductId_OP.Direction = System.Data.ParameterDirection.Input;
                ProductId_OP.OracleDbType = OracleDbType.Decimal;
                ProductId_OP.Value = productDelivery.ProductId;

                OracleParameter MemoId_OP = new OracleParameter();
                MemoId_OP.Direction = System.Data.ParameterDirection.Input;
                MemoId_OP.OracleDbType = OracleDbType.Decimal;
                MemoId_OP.Value = productDelivery.MemoId;

                OracleParameter MemoProductId_OP = new OracleParameter();
                MemoProductId_OP.Direction = System.Data.ParameterDirection.Input;
                MemoProductId_OP.OracleDbType = OracleDbType.Decimal;
                MemoProductId_OP.Value = productDelivery.MemoProductId;

                OracleParameter DeliveryQty_OP = new OracleParameter();
                DeliveryQty_OP.Direction = System.Data.ParameterDirection.Input;
                DeliveryQty_OP.OracleDbType = OracleDbType.Decimal;
                DeliveryQty_OP.Value = productDelivery.DeliveryQty;

                OracleParameter RefId_OP = new OracleParameter();
                RefId_OP.Direction = System.Data.ParameterDirection.Input;
                RefId_OP.OracleDbType = OracleDbType.Varchar2;
                RefId_OP.Value = productDelivery.RefId;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = productDelivery.CreatedBy;
          
                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_UP_PRODUCT_DELIVERY", resultOutID, Id_OP, ProductId_OP, MemoId_OP, MemoProductId_OP, DeliveryQty_OP, RefId_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Decimal SavePasswordRecoveryRequest(PasswordRecoveryReqest recoveryRequest)
        {
            try
            {
                OracleParameter LoginName_OP = new OracleParameter();
                LoginName_OP.Direction = System.Data.ParameterDirection.Input;
                LoginName_OP.OracleDbType = OracleDbType.Varchar2;
                LoginName_OP.Value = recoveryRequest.LoginName;
            

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_PASSWORD_RECOVERY_REQ", resultOutID, LoginName_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal GetExistingMemo(APL.BL.SFTS.Models.ApiMobile.Retailer retailer, Decimal RsoId)
        {
            try
            {
                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = retailer.RetailerId;             

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_CHECK_MEMO_EXIST", resultOutID, RsoId_OP, RetailerId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal GetExistingMemoId(decimal memoNo)
        {
            try
            {
                OracleParameter MemoNo_OP = new OracleParameter();
                MemoNo_OP.Direction = System.Data.ParameterDirection.Input;
                MemoNo_OP.OracleDbType = OracleDbType.Decimal;
                MemoNo_OP.Value = memoNo;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_GET_EXISTING_MEMO_ID", resultOutID, MemoNo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateMarketUpdatePicture(MarketUpdatePicture mup)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = mup.Id;

                OracleParameter MarketUpdateId_OP = new OracleParameter();
                MarketUpdateId_OP.Direction = System.Data.ParameterDirection.Input;
                MarketUpdateId_OP.OracleDbType = OracleDbType.Decimal;
                MarketUpdateId_OP.Value = mup.MarketUpdateId;

                OracleParameter PictureSlNo_OP = new OracleParameter();
                PictureSlNo_OP.Direction = System.Data.ParameterDirection.Input;
                PictureSlNo_OP.OracleDbType = OracleDbType.Decimal;
                PictureSlNo_OP.Value = mup.PictureSlNo;


                OracleParameter Picture_OP = new OracleParameter();
                Picture_OP.Direction = System.Data.ParameterDirection.Input;
                Picture_OP.OracleDbType = OracleDbType.Blob;
                Picture_OP.Value = mup.Picture;

               
                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_MARKET_UPDATE_PICTURE", resultOutID, Id_OP, MarketUpdateId_OP, PictureSlNo_OP, Picture_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateComplainPicture(ComplainPicture compainPic)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = compainPic.Id;

                OracleParameter ComplainId_OP = new OracleParameter();
                ComplainId_OP.Direction = System.Data.ParameterDirection.Input;
                ComplainId_OP.OracleDbType = OracleDbType.Decimal;
                ComplainId_OP.Value = compainPic.ComplainId;

                OracleParameter PictureSlNo_OP = new OracleParameter();
                PictureSlNo_OP.Direction = System.Data.ParameterDirection.Input;
                PictureSlNo_OP.OracleDbType = OracleDbType.Decimal;
                PictureSlNo_OP.Value = compainPic.PictureSlNo;


                OracleParameter Picture_OP = new OracleParameter();
                Picture_OP.Direction = System.Data.ParameterDirection.Input;
                Picture_OP.OracleDbType = OracleDbType.Blob;
                Picture_OP.Value = compainPic.Picture;


                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_COMPLAIN_PICTURE", resultOutID, Id_OP, ComplainId_OP, PictureSlNo_OP, Picture_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateSafCollection(SafCollectionLog scl)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = scl.Id;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = scl.UserId;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = scl.RetailerId;

                OracleParameter CollectionDate_OP = new OracleParameter();
                CollectionDate_OP.Direction = System.Data.ParameterDirection.Input;
                CollectionDate_OP.OracleDbType = OracleDbType.Date;
                CollectionDate_OP.Value = scl.CollectionDate;

                OracleParameter SafMsisdn_OP = new OracleParameter();
                SafMsisdn_OP.Direction = System.Data.ParameterDirection.Input;
                SafMsisdn_OP.OracleDbType = OracleDbType.Varchar2;
                SafMsisdn_OP.Value = scl.SafMsisdn;

                OracleParameter SafSimNo_OP = new OracleParameter();
                SafSimNo_OP.Direction = System.Data.ParameterDirection.Input;
                SafSimNo_OP.OracleDbType = OracleDbType.Varchar2;
                SafSimNo_OP.Value = scl.SafSimNo;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_UP_SAF_COLLECTION", resultOutID, Id_OP, UserId_OP, RetailerId_OP, CollectionDate_OP, SafMsisdn_OP, SafSimNo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateBestRetailerPractice(decimal Id, decimal RetailerId,
                                         decimal RetailerMarketAreaId, decimal PeriodId, decimal Year, decimal CalculationAreaId,
                                         String Description, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

                OracleParameter RetailerMarketAreaId_OP = new OracleParameter();
                RetailerMarketAreaId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerMarketAreaId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerMarketAreaId_OP.Value = RetailerMarketAreaId;

                OracleParameter PeriodId_OP = new OracleParameter();
                PeriodId_OP.Direction = System.Data.ParameterDirection.Input;
                PeriodId_OP.OracleDbType = OracleDbType.Decimal;
                PeriodId_OP.Value = PeriodId;

                OracleParameter Year_OP = new OracleParameter();
                Year_OP.Direction = System.Data.ParameterDirection.Input;
                Year_OP.OracleDbType = OracleDbType.Decimal;
                Year_OP.Value = Year;

                OracleParameter CalculationAreaId_OP = new OracleParameter();
                CalculationAreaId_OP.Direction = System.Data.ParameterDirection.Input;
                CalculationAreaId_OP.OracleDbType = OracleDbType.Decimal;
                CalculationAreaId_OP.Value = CalculationAreaId;

                OracleParameter Description_OP = new OracleParameter();
                Description_OP.Direction = System.Data.ParameterDirection.Input;
                Description_OP.OracleDbType = OracleDbType.Varchar2;
                Description_OP.Value = Description;       

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_BEST_RETAILER_PRACTICE>.InsertDataBySP("SP_FF_INS_UP_BEST_PCT_RETAILER", resultOutID, Id_OP, RetailerId_OP, RetailerMarketAreaId_OP, PeriodId_OP, Year_OP, CalculationAreaId_OP, Description_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_BEST_RETAILER_PRACTICE> GetAllBestRetailerPractice(decimal BestPracticesRetailerId, decimal RetailerId)
        {
            try
            {
                OracleParameter BestPracticesRetailerId_OP = new OracleParameter();
                BestPracticesRetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                BestPracticesRetailerId_OP.OracleDbType = OracleDbType.Decimal;
                BestPracticesRetailerId_OP.Value = BestPracticesRetailerId;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_BEST_RETAILER_PRACTICE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_BEST_RETAILER_PRACTICE>.GetDataBySP(new SP_GET_BEST_RETAILER_PRACTICE(), "SP_FF_GET_BEST_RETAILER_PRACT", 13, resultOutCurSor, BestPracticesRetailerId_OP, RetailerId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get all Retailer with route by list of search parameter.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="routeID"></param>
        /// <param name="retailerID"></param>
        /// <returns>List of Retailer object</returns>
        public List<SP_GET_RETAILERcls> GetAllRetailer(Decimal distributorID, Decimal routeID, Decimal retailerID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;


                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILERcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILERcls>.GetDataBySP(new SP_GET_RETAILERcls(), "SP_FF_GET_RETAILER", 11, resultOutCurSor, distributorID_OP, routeID_OP, retailerID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all Retailer with route by list of search parameter. Retailer code is searching by contains operation.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="routeID"></param>
        /// <param name="retailerID"></param>
        /// <returns>List of Retailer object</returns>
        public List<SP_GET_RETAILERcls> GetAllRetailerSer(Decimal distributorID, Decimal routeID, string retailerCode)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter retailerCodeOP = new OracleParameter();
                retailerCodeOP.Direction = System.Data.ParameterDirection.Input;
                retailerCodeOP.OracleDbType = OracleDbType.Varchar2;
                retailerCodeOP.Value = retailerCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILERcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILERcls>.GetDataBySP(new SP_GET_RETAILERcls(), "SP_GET_RETAILER_SER", 11, resultOutCurSor, distributorID_OP, routeID_OP, retailerCodeOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///Get Retailer who RSO Route and Retail Route same.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="retailerCode"></param>
        /// <returns>If found return retailer id</returns>
        public Decimal GetVaildRetailerByRsoIDAndRetailerCode(decimal rsoID, String retailerCode)
        {
            try
            {
                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter retailerCodeOP = new OracleParameter();
                retailerCodeOP.Direction = System.Data.ParameterDirection.Input;
                retailerCodeOP.OracleDbType = OracleDbType.Varchar2;
                retailerCodeOP.Value = retailerCode;


                OracleParameter resultOutRetailerID = new OracleParameter();
                resultOutRetailerID.Direction = System.Data.ParameterDirection.Output;
                resultOutRetailerID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_VAILD_RETAILERcls>.InsertDataBySP("SP_GET_VAILD_RETAILER", resultOutRetailerID, rsoID_OP, retailerCodeOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Retailer by RSO Id and Retailer code . If Retailer and RSO within same Distributor.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="retailerCode"></param>
        /// <returns>Retailer Object</returns>
        public List<SP_GET_RETAIL_RSO_WISECls> GetRetailerByRSOIDAndRetailerCode(Decimal rsoID, string retailerCode)
        {
            try
            {
                OracleParameter rsoIDOP = new OracleParameter();
                rsoIDOP.Direction = System.Data.ParameterDirection.Input;
                rsoIDOP.OracleDbType = OracleDbType.Decimal;
                rsoIDOP.Value = rsoID;

                OracleParameter retailerCodeOP = new OracleParameter();
                retailerCodeOP.Direction = System.Data.ParameterDirection.Input;
                retailerCodeOP.OracleDbType = OracleDbType.Varchar2;
                retailerCodeOP.Value = retailerCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAIL_RSO_WISECls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAIL_RSO_WISECls>.GetDataBySP(new SP_GET_RETAIL_RSO_WISECls(), "SP_GET_RETAILER_RSO_WISE", 10, resultOutCurSor, rsoIDOP, retailerCodeOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///RSO particular visit date wise all retailer info with GPS values.
        /// </summary>
        /// <param name="rsoID">Must valid RSO ID</param>
        /// <param name="visitDate">Must valid RSO visit date</param>
        /// <param name="retailerCode">Optional, default is empty string</param>
        /// <returns>List of Object</returns>
        public List<SP_GET_RET_GPS_RSO_DATE_WISEcls> GetRetailerGPSByRsoAndVisitDateRetCode(Decimal rsoID, string visitDate, string retailerCode)
        {
            try
            {
                OracleParameter rsoIDOP = new OracleParameter();
                rsoIDOP.Direction = System.Data.ParameterDirection.Input;
                rsoIDOP.OracleDbType = OracleDbType.Decimal;
                rsoIDOP.Value = rsoID;

                OracleParameter visitDateOP = new OracleParameter();
                visitDateOP.Direction = System.Data.ParameterDirection.Input;
                visitDateOP.OracleDbType = OracleDbType.Varchar2;
                visitDateOP.Value = visitDate;

                OracleParameter retailerCodeOP = new OracleParameter();
                retailerCodeOP.Direction = System.Data.ParameterDirection.Input;
                retailerCodeOP.OracleDbType = OracleDbType.Varchar2;
                retailerCodeOP.Value = retailerCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RET_GPS_RSO_DATE_WISEcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RET_GPS_RSO_DATE_WISEcls>.GetDataBySP(new SP_GET_RET_GPS_RSO_DATE_WISEcls(), "SP_GET_RET_GPS_RSO_DATE_WISE", 7, resultOutCurSor, rsoIDOP, visitDateOP, retailerCodeOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Retailer by search parameter wise value.
        /// </summary>
        /// <param name="distributorId">Must valid Distributor ID</param>
        /// <param name="retailerCode">Must valid Retailer Code</param>
        /// <returns></returns>
        public List<SP_GET_RETAIL_RSO_WISECls> GetRetailerByDistributorAndRetailerCode(decimal distributorId, string retailerCode)
        {
            try
            {
                OracleParameter distributorIDOP = new OracleParameter();
                distributorIDOP.Direction = System.Data.ParameterDirection.Input;
                distributorIDOP.OracleDbType = OracleDbType.Decimal;
                distributorIDOP.Value = distributorId;

                OracleParameter retailerCodeOP = new OracleParameter();
                retailerCodeOP.Direction = System.Data.ParameterDirection.Input;
                retailerCodeOP.OracleDbType = OracleDbType.Varchar2;
                retailerCodeOP.Value = retailerCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAIL_RSO_WISECls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAIL_RSO_WISECls>.GetDataBySP(new SP_GET_RETAIL_RSO_WISECls(), "SP_GET_RETAILER_BY_ID", 5, resultOutCurSor, distributorIDOP, retailerCodeOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all retailer from OUTLETSCHEDULE of Retailer by particular route and visit date wise value.
        /// </summary>
        /// <param name="routeID">Must valid Route ID </param>
        /// <param name="visitDate">Must valid Visit Date</param>
        /// <param name="distributorID">Must valid Distributor ID</param>
        /// <returns></returns>
        public List<SP_GET_ROT_WISE_RET_SCHDLcls> GetRouteWiseRetailerSchedule(decimal routeID, DateTime visitDate, decimal distributorID)
        {
            try
            {
                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter visitDateDateOP = new OracleParameter();
                visitDateDateOP.Direction = System.Data.ParameterDirection.Input;
                visitDateDateOP.OracleDbType = OracleDbType.Varchar2;
                visitDateDateOP.Value = visitDate.ToString("dd-MMM-yyyy");

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ROT_WISE_RET_SCHDLcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ROT_WISE_RET_SCHDLcls>.GetDataBySP(new SP_GET_ROT_WISE_RET_SCHDLcls(), "SP_GET_ROT_WISE_RET_SCHDL", 8, resultOutCurSor, routeID_OP, visitDateDateOP, distributorID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// For save retail GPS information. Which is called retailer GPS registration.
        /// </summary>
        /// <param name="distribitorID"></param>
        /// <param name="routeID"></param>
        /// <param name="retailerID"></param>
        /// <param name="latitudeValue"></param>
        /// <param name="longitudeValue"></param>
        /// <param name="createDate"></param>
        /// <param name="createBy"></param>
        /// <returns></returns>
        public Decimal SaveRetailerGPSInfo(decimal retailerGPSInfoID, decimal distribitorID, decimal routeID, decimal retailerID, decimal latitudeValue, decimal longitudeValue, DateTime createDate, decimal createBy, decimal isPending, decimal isActive)
        {
            try
            {
                OracleParameter retailerGPSInfoID_OP = new OracleParameter();
                retailerGPSInfoID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerGPSInfoID_OP.OracleDbType = OracleDbType.Decimal;
                retailerGPSInfoID_OP.Value = retailerGPSInfoID;

                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distribitorID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter latitudeValueOP = new OracleParameter();
                latitudeValueOP.Direction = System.Data.ParameterDirection.Input;
                latitudeValueOP.OracleDbType = OracleDbType.Decimal;
                latitudeValueOP.Value = latitudeValue;

                OracleParameter longitudeValueOP = new OracleParameter();
                longitudeValueOP.Direction = System.Data.ParameterDirection.Input;
                longitudeValueOP.OracleDbType = OracleDbType.Decimal;
                longitudeValueOP.Value = longitudeValue;

                //OracleParameter createDateOP = new OracleParameter();
                //createDateOP.Direction = System.Data.ParameterDirection.Input;
                //createDateOP.OracleDbType = OracleDbType.Varchar2;
                //createDateOP.Value = createDate.ToString("dd-MMM-yyyy HH:mm:ss");

                OracleParameter createDateOP = new OracleParameter();
                createDateOP.Direction = System.Data.ParameterDirection.Input;
                createDateOP.OracleDbType = OracleDbType.Date;
                createDateOP.Value = createDate;

                OracleParameter createByOP = new OracleParameter();
                createByOP.Direction = System.Data.ParameterDirection.Input;
                createByOP.OracleDbType = OracleDbType.Decimal;
                createByOP.Value = createBy;

                OracleParameter isPendingOP = new OracleParameter();
                isPendingOP.Direction = System.Data.ParameterDirection.Input;
                isPendingOP.OracleDbType = OracleDbType.Decimal;
                isPendingOP.Value = isPending;

                OracleParameter isActiveOP = new OracleParameter();
                isActiveOP.Direction = System.Data.ParameterDirection.Input;
                isActiveOP.OracleDbType = OracleDbType.Decimal;
                isActiveOP.Value = isActive;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_RETAILER_GPSINFOcls>.InsertDataBySP("SP_INS_RETAILER_GPSINFO", resultOutID, retailerGPSInfoID_OP, distribitorID_OP, routeID_OP, retailerID_OP, latitudeValueOP, longitudeValueOP, createDateOP, createByOP, isPendingOP, isActiveOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// For save and update SC Issue New Retaiter table.
        /// </summary>
        /// <param name="distribitorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="routeID"></param>
        /// <param name="retailerMobile"></param>
        /// <param name="retailerName"></param>
        /// <param name="scSerialStart"></param>
        /// <param name="scSerialEnd"></param>
        /// <param name="sms"></param>
        /// <param name="latitudeValue"></param>
        /// <param name="longitudeValue"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public Decimal SaveScIssueNewRetailer(decimal scIssNewRetID, decimal distribitorID, decimal rsoID, decimal routeID, String retailerMobile, String retailerName, String scSerialStart, String scSerialEnd, String sms, decimal latitudeValue, decimal longitudeValue, Decimal status)
        {
            try
            {
                OracleParameter scIssNewRetID_OP = new OracleParameter();
                scIssNewRetID_OP.Direction = System.Data.ParameterDirection.Input;
                scIssNewRetID_OP.OracleDbType = OracleDbType.Decimal;
                scIssNewRetID_OP.Value = scIssNewRetID;

                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distribitorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter retailerMobileOP = new OracleParameter();
                retailerMobileOP.Direction = System.Data.ParameterDirection.Input;
                retailerMobileOP.OracleDbType = OracleDbType.Varchar2;
                retailerMobileOP.Value = retailerMobile;

                OracleParameter retailerNameOP = new OracleParameter();
                retailerNameOP.Direction = System.Data.ParameterDirection.Input;
                retailerNameOP.OracleDbType = OracleDbType.Varchar2;
                retailerNameOP.Value = retailerName;

                OracleParameter scSerialStartOP = new OracleParameter();
                scSerialStartOP.Direction = System.Data.ParameterDirection.Input;
                scSerialStartOP.OracleDbType = OracleDbType.Varchar2;
                scSerialStartOP.Value = scSerialStart;

                OracleParameter scSerialEndOP = new OracleParameter();
                scSerialEndOP.Direction = System.Data.ParameterDirection.Input;
                scSerialEndOP.OracleDbType = OracleDbType.Varchar2;
                scSerialEndOP.Value = scSerialEnd;

                OracleParameter smsOP = new OracleParameter();
                smsOP.Direction = System.Data.ParameterDirection.Input;
                smsOP.OracleDbType = OracleDbType.Varchar2;
                smsOP.Value = sms;

                OracleParameter latitudeValueOP = new OracleParameter();
                latitudeValueOP.Direction = System.Data.ParameterDirection.Input;
                latitudeValueOP.OracleDbType = OracleDbType.Decimal;
                latitudeValueOP.Value = latitudeValue;

                OracleParameter longitudeValueOP = new OracleParameter();
                longitudeValueOP.Direction = System.Data.ParameterDirection.Input;
                longitudeValueOP.OracleDbType = OracleDbType.Decimal;
                longitudeValueOP.Value = longitudeValue;

                OracleParameter statusOP = new OracleParameter();
                statusOP.Direction = System.Data.ParameterDirection.Input;
                statusOP.OracleDbType = OracleDbType.Decimal;
                statusOP.Value = status;


                OracleParameter updateDateOP = new OracleParameter();
                updateDateOP.Direction = System.Data.ParameterDirection.Input;
                updateDateOP.OracleDbType = OracleDbType.Date;
                updateDateOP.Value = DateTime.Now;

                OracleParameter updateByOP = new OracleParameter();
                updateByOP.Direction = System.Data.ParameterDirection.Input;
                updateByOP.OracleDbType = OracleDbType.Decimal;
                updateByOP.Value = rsoID;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SCISSUENEWRETAILERcls>.InsertDataBySP("SP_INS_UPD_SCISSUENEWRETAILER", resultOutID, scIssNewRetID_OP, distribitorID_OP, rsoID_OP, routeID_OP, retailerMobileOP, retailerNameOP, scSerialStartOP, scSerialEndOP, smsOP, latitudeValueOP, longitudeValueOP, statusOP, updateDateOP, updateByOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all new Retailer request information.
        /// </summary>
        /// <param name="scIssueNewRetailerID"></param>
        /// <param name="distribitorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public List<SP_GET_SCISSUENEWRETAILERcls> GetAllIssueNewRetailerInfo(decimal scIssueNewRetailerID, decimal distribitorID, decimal rsoID, decimal currentPage)
        {
            try
            {
                OracleParameter scIssueNewRetailerID_OP = new OracleParameter();
                scIssueNewRetailerID_OP.Direction = System.Data.ParameterDirection.Input;
                scIssueNewRetailerID_OP.OracleDbType = OracleDbType.Decimal;
                scIssueNewRetailerID_OP.Value = scIssueNewRetailerID;

                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distribitorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter currentPageOP = new OracleParameter();
                currentPageOP.Direction = System.Data.ParameterDirection.Input;
                currentPageOP.OracleDbType = OracleDbType.Decimal;
                currentPageOP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SCISSUENEWRETAILERcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SCISSUENEWRETAILERcls>.GetDataBySP(new SP_GET_SCISSUENEWRETAILERcls(), "SP_GET_SCISSUENEWRETAILER", 20, resultOutCurSor, scIssueNewRetailerID_OP, distribitorID_OP, rsoID_OP, currentPageOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save and Update market information
        /// </summary>
        /// <param name="marketUpdateID"></param>
        /// <param name="distribitorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="retailerID"></param>
        /// <param name="eventNameID"></param>
        /// <param name="operatorID"></param>
        /// <param name="eventNote"></param>
        /// <param name="pictureURL"></param>
        /// <param name="eventDate"></param>
        /// <param name="isDisplay"></param>
        /// <param name="updateBy"></param>
        /// <param name="updateDate"></param>
        /// <returns></returns>
        public Decimal SaveMarketUpdate(decimal marketUpdateID, decimal distribitorID, decimal rsoID, decimal retailerID, decimal eventNameID, decimal operatorID,
            string eventNote, string pictureURL, DateTime eventDate, decimal isDisplay, decimal updateBy, DateTime updateDate, String pictureBase64)
        {
            try
            {
                String spiltBase64strCaption = string.Empty;
                String spiltBase64str = string.Empty;
                if (pictureBase64.Trim() != string.Empty)
                {
                    spiltBase64strCaption = pictureBase64.Trim().Split(',')[0];
                    spiltBase64str = pictureBase64.Trim().Split(',')[1];
                }

                OracleParameter marketupdateID_OP = new OracleParameter();
                marketupdateID_OP.Direction = System.Data.ParameterDirection.Input;
                marketupdateID_OP.OracleDbType = OracleDbType.Decimal;
                marketupdateID_OP.Value = marketUpdateID;

                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distribitorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter eventnameID_OP = new OracleParameter();
                eventnameID_OP.Direction = System.Data.ParameterDirection.Input;
                eventnameID_OP.OracleDbType = OracleDbType.Decimal;
                eventnameID_OP.Value = eventNameID;

                OracleParameter operatorID_OP = new OracleParameter();
                operatorID_OP.Direction = System.Data.ParameterDirection.Input;
                operatorID_OP.OracleDbType = OracleDbType.Decimal;
                operatorID_OP.Value = operatorID;

                OracleParameter eventnote_OP = new OracleParameter();
                eventnote_OP.Direction = System.Data.ParameterDirection.Input;
                eventnote_OP.OracleDbType = OracleDbType.Varchar2;
                eventnote_OP.Value = eventNote;

                OracleParameter pictureURL_OP = new OracleParameter();
                pictureURL_OP.Direction = System.Data.ParameterDirection.Input;
                pictureURL_OP.OracleDbType = OracleDbType.Varchar2;
                pictureURL_OP.Value = spiltBase64strCaption; //pictureURL;

                OracleParameter eventDate_OP = new OracleParameter();
                eventDate_OP.Direction = System.Data.ParameterDirection.Input;
                eventDate_OP.OracleDbType = OracleDbType.Varchar2;
                eventDate_OP.Value = eventDate.ToString("dd-MMM-yyyy");

                OracleParameter isDisplay_OP = new OracleParameter();
                isDisplay_OP.Direction = System.Data.ParameterDirection.Input;
                isDisplay_OP.OracleDbType = OracleDbType.Decimal;
                isDisplay_OP.Value = isDisplay;

                OracleParameter updateBy_OP = new OracleParameter();
                updateBy_OP.Direction = System.Data.ParameterDirection.Input;
                updateBy_OP.OracleDbType = OracleDbType.Decimal;
                updateBy_OP.Value = updateBy;

                OracleParameter updateDate_OP = new OracleParameter();
                updateDate_OP.Direction = System.Data.ParameterDirection.Input;
                updateDate_OP.OracleDbType = OracleDbType.Varchar2;
                updateDate_OP.Value = updateDate.ToString("dd-MMM-yyyy");

                OracleParameter pictureBase64OP = new OracleParameter();
                pictureBase64OP.Direction = System.Data.ParameterDirection.Input;
                pictureBase64OP.OracleDbType = OracleDbType.Blob;
                pictureBase64OP.Value = spiltBase64str.Trim() != string.Empty ? Convert.FromBase64String(spiltBase64str) : null;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_MARKET_UPDATEcls>.InsertDataBySP("SP_INS_UPD_MARKET_UPDATE", resultOutID, marketupdateID_OP,
                    distribitorID_OP, rsoID_OP, retailerID_OP, eventnameID_OP, operatorID_OP, eventnote_OP, pictureURL_OP,
                    eventDate_OP, isDisplay_OP, updateBy_OP, updateDate_OP, pictureBase64OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Return all Market Update Information
        /// </summary>
        /// <param name="operatorNameID"></param>
        /// <param name="eventNameID"></param>
        /// <param name="distribitorID"></param>
        /// <param name="RSOCode"></param>
        /// <param name="retailerCode"></param>
        /// <returns></returns>
        public List<SP_INS_UPD_MARKET_UPDATEcls> GetAllMarketUpdate(decimal operatorNameID, decimal eventNameID, decimal distribitorID, string RSOCode, string retailerCode, string eventFromDate, string eventToDate)
        {
            try
            {
                OracleParameter operatorNameID_OP = new OracleParameter();
                operatorNameID_OP.Direction = System.Data.ParameterDirection.Input;
                operatorNameID_OP.OracleDbType = OracleDbType.Decimal;
                operatorNameID_OP.Value = operatorNameID;

                OracleParameter eventNameID_OP = new OracleParameter();
                eventNameID_OP.Direction = System.Data.ParameterDirection.Input;
                eventNameID_OP.OracleDbType = OracleDbType.Decimal;
                eventNameID_OP.Value = eventNameID;

                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distribitorID;

                OracleParameter RSOCode_OP = new OracleParameter();
                RSOCode_OP.Direction = System.Data.ParameterDirection.Input;
                RSOCode_OP.OracleDbType = OracleDbType.Varchar2;
                RSOCode_OP.Value = RSOCode;

                OracleParameter retailerCode_OP = new OracleParameter();
                retailerCode_OP.Direction = System.Data.ParameterDirection.Input;
                retailerCode_OP.OracleDbType = OracleDbType.Varchar2;
                retailerCode_OP.Value = RSOCode;

                //eventFromDate
                OracleParameter eventFromDate_OP = new OracleParameter();
                eventFromDate_OP.Direction = System.Data.ParameterDirection.Input;
                eventFromDate_OP.OracleDbType = OracleDbType.Varchar2;
                eventFromDate_OP.Value = eventFromDate;

                OracleParameter eventToDate_OP = new OracleParameter();
                eventToDate_OP.Direction = System.Data.ParameterDirection.Input;
                eventToDate_OP.OracleDbType = OracleDbType.Varchar2;
                eventToDate_OP.Value = eventToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_INS_UPD_MARKET_UPDATEcls>)ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_MARKET_UPDATEcls>.GetDataWithBlobBySP(new SP_INS_UPD_MARKET_UPDATEcls(), "SP_GET_MARKET_UPDATE_ROUTE", 15, resultOutCurSor, operatorNameID_OP, eventNameID_OP, distribitorID_OP, RSOCode_OP, retailerCode_OP, eventFromDate_OP, eventToDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Using this methods get all retailer GPS location by parameter wise search GPS location result
        /// </summary>
        /// <param name="distribitorID"></param>
        /// <param name="retailerID"></param>
        /// <param name="routeID"></param>
        /// <returns></returns>
        public List<SP_GET_RETAILER_GPS_LOCcls> GetAllRetailerGPSLocation(decimal distribitorID, decimal routeID, decimal retailerID)
        {
            try
            {
                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distribitorID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter isPendingOP = new OracleParameter();
                isPendingOP.Direction = System.Data.ParameterDirection.Input;
                isPendingOP.OracleDbType = OracleDbType.Decimal;
                isPendingOP.Value = 0;

                OracleParameter isActiveOP = new OracleParameter();
                isActiveOP.Direction = System.Data.ParameterDirection.Input;
                isActiveOP.OracleDbType = OracleDbType.Decimal;
                isActiveOP.Value = 0;

                OracleParameter currentPageOP = new OracleParameter();
                currentPageOP.Direction = System.Data.ParameterDirection.Input;
                currentPageOP.OracleDbType = OracleDbType.Decimal;
                currentPageOP.Value = 0;

                OracleParameter resultOutCursor = new OracleParameter();
                resultOutCursor.Direction = System.Data.ParameterDirection.Output;
                resultOutCursor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_GPS_LOCcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_GPS_LOCcls>.GetDataBySP(new SP_GET_RETAILER_GPS_LOCcls(), "SP_GET_RETAILER_GPS_LOC", 16, resultOutCursor, distribitorID_OP, routeID_OP, retailerID_OP, isPendingOP, isActiveOP, currentPageOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Using this methods get all retailer GPS location by parameter wise search GPS location result and paging by 10 row record
        /// </summary>
        /// <param name="distribitorID"></param>
        /// <param name="retailerID"></param>
        /// <param name="routeID"></param>
        /// <returns></returns>
        public List<SP_GET_RETAILER_GPS_LOCcls> GetAllRetailerGPSLocation(decimal distribitorID, decimal routeID, decimal retailerID, decimal isPending, decimal isActive, decimal currentPageNumber)
        {
            try
            {
                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distribitorID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter isPendingOP = new OracleParameter();
                isPendingOP.Direction = System.Data.ParameterDirection.Input;
                isPendingOP.OracleDbType = OracleDbType.Decimal;
                isPendingOP.Value = isPending;

                OracleParameter isActiveOP = new OracleParameter();
                isActiveOP.Direction = System.Data.ParameterDirection.Input;
                isActiveOP.OracleDbType = OracleDbType.Decimal;
                isActiveOP.Value = isActive;

                OracleParameter currentPageNumberOP = new OracleParameter();
                currentPageNumberOP.Direction = System.Data.ParameterDirection.Input;
                currentPageNumberOP.OracleDbType = OracleDbType.Decimal;
                currentPageNumberOP.Value = currentPageNumber;

                OracleParameter resultOutCursor = new OracleParameter();
                resultOutCursor.Direction = System.Data.ParameterDirection.Output;
                resultOutCursor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_GPS_LOCcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_GPS_LOCcls>.GetDataBySP(new SP_GET_RETAILER_GPS_LOCcls(), "SP_GET_RETAILER_GPS_LOC", 16, resultOutCursor, distribitorID_OP, routeID_OP, retailerID_OP, isPendingOP, isActiveOP, currentPageNumberOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Retailer monthly or date interval wise target , achivement and commission information from RSO_RETAILER_TARGET.
        /// </summary>
        /// <param name="retailerID"></param>
        /// <param name="distributorID"></param>
        /// <param name="prodCategoryID"></param>
        /// <param name="fromMonthDate"></param>
        /// <param name="toMonthDate"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_RETAILER_TAR_ACHIEVEcls> GetRetailerTargetAndAchivement(decimal retailerID, decimal distributorID, decimal prodCategoryID, string fromMonthDate, string toMonthDate)
        {
            try
            {
                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = 0;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter prodCategoryID_OP = new OracleParameter();
                prodCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                prodCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                prodCategoryID_OP.Value = prodCategoryID;

                OracleParameter fromMonthDateOP = new OracleParameter();
                fromMonthDateOP.Direction = System.Data.ParameterDirection.Input;
                fromMonthDateOP.OracleDbType = OracleDbType.Varchar2;
                fromMonthDateOP.Value = fromMonthDate;

                OracleParameter toMonthDateOP = new OracleParameter();
                toMonthDateOP.Direction = System.Data.ParameterDirection.Input;
                toMonthDateOP.OracleDbType = OracleDbType.Varchar2;
                toMonthDateOP.Value = toMonthDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_TAR_ACHIEVEcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_TAR_ACHIEVEcls>.GetDataBySP(new SP_GET_RETAILER_TAR_ACHIEVEcls(), "SP_GET_RETAILER_TAR_ACHIEVE", 14, resultOutCurSor, rsoID_OP, retailerID_OP, distributorID_OP, prodCategoryID_OP, fromMonthDateOP, toMonthDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all Retailer target , achivement and commission information from RSO_RETAILER_TARGET. orderByEnumValue = 1 top ten and orderByEnumValue = 2 bottom ten 
        /// </summary>
        /// <param name="retailerID"></param>
        /// <param name="distributorID"></param>
        /// <param name="prodCategoryID"></param>
        /// <param name="monthDate"></param>
        /// <param name="orderByEnumValue">orderByEnumValue = 1 top ten and orderByEnumValue = 2 bottom ten </param>
        /// <returns></returns>
        public List<SP_GET_RETAILER_TAR_ACHI_T_Bcls> GetRetailerTargetTopBottomTen(decimal retailerID, decimal distributorID, decimal prodCategoryID, string monthDate, decimal orderByEnumValue)
        {
            try
            {
                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = 0;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter prodCategoryID_OP = new OracleParameter();
                prodCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                prodCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                prodCategoryID_OP.Value = prodCategoryID;

                OracleParameter monthDateOP = new OracleParameter();
                monthDateOP.Direction = System.Data.ParameterDirection.Input;
                monthDateOP.OracleDbType = OracleDbType.Varchar2;
                monthDateOP.Value = monthDate;

                OracleParameter orderByOP = new OracleParameter();
                orderByOP.Direction = System.Data.ParameterDirection.Input;
                orderByOP.OracleDbType = OracleDbType.Varchar2;
                orderByOP.Value = orderByEnumValue;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_TAR_ACHI_T_Bcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_TAR_ACHI_T_Bcls>.GetDataBySP(new SP_GET_RETAILER_TAR_ACHI_T_Bcls(), "SP_GET_RETAILER_TAR_ACHI_T_B", 15, resultOutCurSor, rsoID_OP, retailerID_OP, distributorID_OP, prodCategoryID_OP, monthDateOP, orderByOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get particular Retailer channel fill information. Channel fill = total SIM issue to Retailer - total sales SIM activated to system.
        /// </summary>
        /// <param name="retailerID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Single related object</returns>
        public List<RETAILER_CHANNELFILLcls> GetRetailerChannelFileInfo(decimal retailerID, string startDate, string endDate)
        {
            try
            {
                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter startDateOP = new OracleParameter();
                startDateOP.Direction = System.Data.ParameterDirection.Input;
                startDateOP.OracleDbType = OracleDbType.Varchar2;
                startDateOP.Value = startDate;

                OracleParameter endDateOP = new OracleParameter();
                endDateOP.Direction = System.Data.ParameterDirection.Input;
                endDateOP.OracleDbType = OracleDbType.Varchar2;
                endDateOP.Value = endDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<RETAILER_CHANNELFILLcls>)ObjectMakerFromOracleSP.OracleHelper<RETAILER_CHANNELFILLcls>.GetDataBySP(new RETAILER_CHANNELFILLcls(), "SP_GET_RETAILER_CHANNELFIL", 15, resultOutCurSor, retailerID_OP, startDateOP, endDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get particular Retailer last transaction voucher information.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="retailerID"></param>
        /// <param name="productID"></param>
        /// <param name="tranFromDate"></param>
        /// <param name="tranToDate"></param>
        /// <returns>List of related object</returns>
        public List<RETAILER_LAST_LIFTINGcls> GetRetailerLastLiftingInfo(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter productID_OP = new OracleParameter();
                productID_OP.Direction = System.Data.ParameterDirection.Input;
                productID_OP.OracleDbType = OracleDbType.Decimal;
                productID_OP.Value = productID;

                OracleParameter tranFromDateOP = new OracleParameter();
                tranFromDateOP.Direction = System.Data.ParameterDirection.Input;
                tranFromDateOP.OracleDbType = OracleDbType.Varchar2;
                tranFromDateOP.Value = tranFromDate;

                OracleParameter tranToDateOP = new OracleParameter();
                tranToDateOP.Direction = System.Data.ParameterDirection.Input;
                tranToDateOP.OracleDbType = OracleDbType.Varchar2;
                tranToDateOP.Value = tranToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<RETAILER_LAST_LIFTINGcls>)ObjectMakerFromOracleSP.OracleHelper<RETAILER_LAST_LIFTINGcls>.GetDataBySP(new RETAILER_LAST_LIFTINGcls(), "SP_GET_RETAILER_LASTLIFTING", 7, resultOutCurSor, distributorID_OP, retailerID_OP, productID_OP, tranFromDateOP, tranToDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_RETAILER_SIMSTOCK> GetRetailerSimStockDetail(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter productID_OP = new OracleParameter();
                productID_OP.Direction = System.Data.ParameterDirection.Input;
                productID_OP.OracleDbType = OracleDbType.Decimal;
                productID_OP.Value = productID;

                OracleParameter tranFromDateOP = new OracleParameter();
                tranFromDateOP.Direction = System.Data.ParameterDirection.Input;
                tranFromDateOP.OracleDbType = OracleDbType.Varchar2;
                tranFromDateOP.Value = tranFromDate;

                OracleParameter tranToDateOP = new OracleParameter();
                tranToDateOP.Direction = System.Data.ParameterDirection.Input;
                tranToDateOP.OracleDbType = OracleDbType.Varchar2;
                tranToDateOP.Value = tranToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_RETAILER_SIMSTOCK>)ObjectMakerFromOracleSP.OracleHelper<GET_RETAILER_SIMSTOCK>.GetDataBySP(new GET_RETAILER_SIMSTOCK(), "SP_GET_RETAILER_SIMSTOCK", 4, resultOutCurSor, distributorID_OP, retailerID_OP, productID_OP, tranFromDateOP, tranToDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<GET_RETAILER_OFFER> GetRetailerCurrentOffer(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter productID_OP = new OracleParameter();
                productID_OP.Direction = System.Data.ParameterDirection.Input;
                productID_OP.OracleDbType = OracleDbType.Decimal;
                productID_OP.Value = productID;

                OracleParameter tranFromDateOP = new OracleParameter();
                tranFromDateOP.Direction = System.Data.ParameterDirection.Input;
                tranFromDateOP.OracleDbType = OracleDbType.Varchar2;
                tranFromDateOP.Value = tranFromDate;

                OracleParameter tranToDateOP = new OracleParameter();
                tranToDateOP.Direction = System.Data.ParameterDirection.Input;
                tranToDateOP.OracleDbType = OracleDbType.Varchar2;
                tranToDateOP.Value = tranToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_RETAILER_OFFER>)ObjectMakerFromOracleSP.OracleHelper<GET_RETAILER_OFFER>.GetDataBySP(new GET_RETAILER_OFFER(), "SP_GET_RETAILER_CURRENT_OFFER", 3, resultOutCurSor, distributorID_OP, retailerID_OP, productID_OP, tranFromDateOP, tranToDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<GET_RETAILER_OFFER_IMAGE> GetRetailerCurrentOfferImage(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter productID_OP = new OracleParameter();
                productID_OP.Direction = System.Data.ParameterDirection.Input;
                productID_OP.OracleDbType = OracleDbType.Decimal;
                productID_OP.Value = productID;

                OracleParameter tranFromDateOP = new OracleParameter();
                tranFromDateOP.Direction = System.Data.ParameterDirection.Input;
                tranFromDateOP.OracleDbType = OracleDbType.Varchar2;
                tranFromDateOP.Value = tranFromDate;

                OracleParameter tranToDateOP = new OracleParameter();
                tranToDateOP.Direction = System.Data.ParameterDirection.Input;
                tranToDateOP.OracleDbType = OracleDbType.Varchar2;
                tranToDateOP.Value = tranToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_RETAILER_OFFER_IMAGE>)ObjectMakerFromOracleSP.OracleHelper<GET_RETAILER_OFFER_IMAGE>.GetDataBySP(new GET_RETAILER_OFFER_IMAGE(), "SP_GET_RETAILER_OFFER_IMAGE", 1, resultOutCurSor, distributorID_OP, retailerID_OP, productID_OP, tranFromDateOP, tranToDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RETAILER_CURRENT_BALANCE> GetRetailerCurrentBalance(decimal distributorID, decimal retailerID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<RETAILER_CURRENT_BALANCE>)ObjectMakerFromOracleSP.OracleHelper<RETAILER_CURRENT_BALANCE>.GetDataBySP(new RETAILER_CURRENT_BALANCE(), "SP_RETAILER_CURRENT_BALANCE", 2, resultOutCurSor, distributorID_OP, retailerID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal IssueNewBalance(decimal distributorID, decimal retailerID, decimal rsoID, decimal amount, decimal latitude, decimal longtitude)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter amount_OP = new OracleParameter();
                rsoID_OP.Direction = ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = amount;

                OracleParameter latitude_OP = new OracleParameter();
                rsoID_OP.Direction = ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = latitude;

                OracleParameter longtitude_OP = new OracleParameter();
                rsoID_OP.Direction = ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = longtitude;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_INS_UPD_SAF_INFOcls>.InsertDataBySP("SP_INS_UPD_NEW_BALANCE", distributorID_OP, resultOutID, retailerID_OP, rsoID_OP, latitude_OP, longtitude_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_INVOICE> GetInvoice(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter productID_OP = new OracleParameter();
                productID_OP.Direction = System.Data.ParameterDirection.Input;
                productID_OP.OracleDbType = OracleDbType.Decimal;
                productID_OP.Value = productID;

                OracleParameter tranFromDateOP = new OracleParameter();
                tranFromDateOP.Direction = System.Data.ParameterDirection.Input;
                tranFromDateOP.OracleDbType = OracleDbType.Varchar2;
                tranFromDateOP.Value = tranFromDate;

                OracleParameter tranToDateOP = new OracleParameter();
                tranToDateOP.Direction = System.Data.ParameterDirection.Input;
                tranToDateOP.OracleDbType = OracleDbType.Varchar2;
                tranToDateOP.Value = tranToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_INVOICE>)ObjectMakerFromOracleSP.OracleHelper<GET_INVOICE>.GetDataBySP(new GET_INVOICE(), "SP_GET_INVOICE", 9, resultOutCurSor, distributorID_OP, retailerID_OP, productID_OP, tranFromDateOP, tranToDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_BALANCE_STATUS> CheckBalanceStatus(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter productID_OP = new OracleParameter();
                productID_OP.Direction = System.Data.ParameterDirection.Input;
                productID_OP.OracleDbType = OracleDbType.Decimal;
                productID_OP.Value = productID;

                OracleParameter tranFromDateOP = new OracleParameter();
                tranFromDateOP.Direction = System.Data.ParameterDirection.Input;
                tranFromDateOP.OracleDbType = OracleDbType.Varchar2;
                tranFromDateOP.Value = tranFromDate;

                OracleParameter tranToDateOP = new OracleParameter();
                tranToDateOP.Direction = System.Data.ParameterDirection.Input;
                tranToDateOP.OracleDbType = OracleDbType.Varchar2;
                tranToDateOP.Value = tranToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_BALANCE_STATUS>)ObjectMakerFromOracleSP.OracleHelper<GET_BALANCE_STATUS>.GetDataBySP(new GET_BALANCE_STATUS(), "SP_GET_BALANCE_STATUS", 1, resultOutCurSor, distributorID_OP, retailerID_OP, productID_OP, tranFromDateOP, tranToDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<GET_USSD_CALL> UssdCall(decimal distributorID, decimal retailerID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;


                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_USSD_CALL>)ObjectMakerFromOracleSP.OracleHelper<GET_USSD_CALL>.GetDataBySP(new GET_USSD_CALL(), "SP_USSD_CALL", 1, resultOutCurSor, distributorID_OP, retailerID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<GET_STOCK_AND_SALES> StockAndSales(decimal distributorID, decimal retailerID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_STOCK_AND_SALES>)ObjectMakerFromOracleSP.OracleHelper<GET_STOCK_AND_SALES>.GetDataBySP(new GET_STOCK_AND_SALES(), "SP_GET_RETAILER_STOCKANDSALES", 4, resultOutCurSor, distributorID_OP, retailerID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<GET_SAF_COLLECTION> SafCollection(decimal distributorID, decimal retailerID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_SAF_COLLECTION>)ObjectMakerFromOracleSP.OracleHelper<GET_SAF_COLLECTION>.GetDataBySP(new GET_SAF_COLLECTION(), "SP_GET_RETAILER_SAFCOLLECTION", 2, resultOutCurSor, distributorID_OP, retailerID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_COLLECTED_SAF> CollectedSafList(decimal distributorID, decimal retailerID, string fromDate, string toDate, string missdn)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter fromDate_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Varchar2;
                retailerID_OP.Value = fromDate;

                OracleParameter toDate_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Varchar2;
                retailerID_OP.Value = toDate;

                OracleParameter missdn_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Varchar2;
                retailerID_OP.Value = missdn;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_COLLECTED_SAF>)ObjectMakerFromOracleSP.OracleHelper<GET_COLLECTED_SAF>.GetDataBySP(new GET_COLLECTED_SAF(), "SP_GET_COLLECTED_SAF", 3, resultOutCurSor, distributorID_OP, retailerID_OP, fromDate_OP, toDate_OP, missdn_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_SAF_COLL> GetCollectedSaf(APL.BL.SFTS.Models.ApiMobile.Retailer retailer)
        {
            try
            {
                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = retailer.RetailerId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_SAF_COLL>)ObjectMakerFromOracleSP.OracleHelper<GET_SAF_COLL>.GetDataBySP(new GET_SAF_COLL(), "SP_FF_GET_COLLECTED_SAF", 7, resultOutCurSor, RetailerId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_COMMISSION_HISTORY> CommissionHistory(decimal distributorID, decimal retailerID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_COMMISSION_HISTORY>)ObjectMakerFromOracleSP.OracleHelper<GET_COMMISSION_HISTORY>.GetDataBySP(new GET_COMMISSION_HISTORY(), "SP_FF_GET_COMMISSION_HISTORYV2", 6, resultOutCurSor, distributorID_OP, retailerID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public decimal RetailerInfoUpdate(decimal distributorID, decimal retailerID, string retailerName, string ownerName, string contactNo, string mobileNo, string address)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter retailerName_OP = new OracleParameter();
                retailerName_OP.Direction = ParameterDirection.Input;
                retailerName_OP.OracleDbType = OracleDbType.Varchar2;
                retailerName_OP.Value = retailerName;

                OracleParameter ownerName_OP = new OracleParameter();
                ownerName_OP.Direction = ParameterDirection.Input;
                ownerName_OP.OracleDbType = OracleDbType.Varchar2;
                ownerName_OP.Value = ownerName;

                OracleParameter contactNo_OP = new OracleParameter();
                contactNo_OP.Direction = ParameterDirection.Input;
                contactNo_OP.OracleDbType = OracleDbType.Varchar2;
                contactNo_OP.Value = contactNo;

                OracleParameter mobileNo_OP = new OracleParameter();
                mobileNo_OP.Direction = ParameterDirection.Input;
                mobileNo_OP.OracleDbType = OracleDbType.Varchar2;
                mobileNo_OP.Value = mobileNo;

                OracleParameter address_OP = new OracleParameter();
                address_OP.Direction = ParameterDirection.Input;
                address_OP.OracleDbType = OracleDbType.Varchar2;
                address_OP.Value = address;


                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_RETAILER_INFO_UPDATE>.InsertDataBySP("SP_UPD_RETAILER_INFO", resultOutID, distributorID_OP, retailerID_OP, retailerName_OP, ownerName_OP, contactNo_OP, mobileNo_OP, address_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_FOC_PRODUCTS> FocProducts(decimal distributorID, decimal retailerID, decimal productId, string dateFrom, string dateTo, decimal zoneId, decimal teritoryId, decimal rsoId)
        {

            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter productId_OP = new OracleParameter();
                productId_OP.Direction = ParameterDirection.Input;
                productId_OP.OracleDbType = OracleDbType.Decimal;
                productId_OP.Value = productId;

                OracleParameter dateFrom_OP = new OracleParameter();
                dateFrom_OP.Direction = ParameterDirection.Input;
                dateFrom_OP.OracleDbType = OracleDbType.Varchar2;
                dateFrom_OP.Value = dateFrom;

                OracleParameter dateTo_OP = new OracleParameter();
                dateTo_OP.Direction = ParameterDirection.Input;
                dateTo_OP.OracleDbType = OracleDbType.Varchar2;
                dateTo_OP.Value = dateTo;

                OracleParameter zoneId_OP = new OracleParameter();
                zoneId_OP.Direction = ParameterDirection.Input;
                zoneId_OP.OracleDbType = OracleDbType.Decimal;
                zoneId_OP.Value = zoneId;

                OracleParameter teritoryId_OP = new OracleParameter();
                teritoryId_OP.Direction = ParameterDirection.Input;
                teritoryId_OP.OracleDbType = OracleDbType.Decimal;
                teritoryId_OP.Value = teritoryId;

                OracleParameter rsoId_OP = new OracleParameter();
                rsoId_OP.Direction = ParameterDirection.Input;
                rsoId_OP.OracleDbType = OracleDbType.Decimal;
                rsoId_OP.Value = rsoId;


                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_FOC_PRODUCTS>)ObjectMakerFromOracleSP.OracleHelper<GET_FOC_PRODUCTS>.GetDataBySP(new GET_FOC_PRODUCTS(), "SP_GET_FOC_PRODUCTS", 4, resultOutCurSor, distributorID_OP, retailerID_OP, productId_OP, dateFrom_OP, dateTo_OP, zoneId_OP, teritoryId_OP, rsoId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<GET_ROUTE_LIST> RouteList(decimal distributorID, decimal rsoId, string lastLiftingDate)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter rsoId_OP = new OracleParameter();
                rsoId_OP.Direction = System.Data.ParameterDirection.Input;
                rsoId_OP.OracleDbType = OracleDbType.Decimal;
                rsoId_OP.Value = rsoId;

                OracleParameter lastLiftingDate_OP = new OracleParameter();
                lastLiftingDate_OP.Direction = System.Data.ParameterDirection.Input;
                lastLiftingDate_OP.OracleDbType = OracleDbType.Varchar2;
                lastLiftingDate_OP.Value = lastLiftingDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_ROUTE_LIST>)ObjectMakerFromOracleSP.OracleHelper<GET_ROUTE_LIST>.GetDataBySP(new GET_ROUTE_LIST(), "SP_GET_ROUTE_LIST", 4, resultOutCurSor, distributorID_OP, rsoId_OP, lastLiftingDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_NEW_OUTLET_STATUS> NewOutletStatus(decimal distribitorID, decimal rsoID, decimal routeID, string dateFrom, string dateTo)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distribitorID;

                OracleParameter rsoId_OP = new OracleParameter();
                rsoId_OP.Direction = System.Data.ParameterDirection.Input;
                rsoId_OP.OracleDbType = OracleDbType.Decimal;
                rsoId_OP.Value = rsoID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter dateFrom_OP = new OracleParameter();
                dateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                dateFrom_OP.OracleDbType = OracleDbType.Varchar2;
                dateFrom_OP.Value = dateFrom;

                OracleParameter dateTo_OP = new OracleParameter();
                dateTo_OP.Direction = System.Data.ParameterDirection.Input;
                dateTo_OP.OracleDbType = OracleDbType.Varchar2;
                dateTo_OP.Value = dateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_NEW_OUTLET_STATUS>)ObjectMakerFromOracleSP.OracleHelper<GET_NEW_OUTLET_STATUS>.GetDataBySP(new GET_NEW_OUTLET_STATUS(), "SP_GET_NEW_OUTLET_STATUS", 3, resultOutCurSor, distributorID_OP, rsoId_OP, routeID_OP, dateFrom_OP, dateTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_COMMISSION_STRACTURE_IMAGE> CommissionStructureImage(decimal distributorID, decimal retailerID, decimal productID, string tranFromDate, string tranToDate)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter productID_OP = new OracleParameter();
                productID_OP.Direction = System.Data.ParameterDirection.Input;
                productID_OP.OracleDbType = OracleDbType.Decimal;
                productID_OP.Value = productID;

                OracleParameter tranFromDateOP = new OracleParameter();
                tranFromDateOP.Direction = System.Data.ParameterDirection.Input;
                tranFromDateOP.OracleDbType = OracleDbType.Varchar2;
                tranFromDateOP.Value = tranFromDate;

                OracleParameter tranToDateOP = new OracleParameter();
                tranToDateOP.Direction = System.Data.ParameterDirection.Input;
                tranToDateOP.OracleDbType = OracleDbType.Varchar2;
                tranToDateOP.Value = tranToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_COMMISSION_STRACTURE_IMAGE>)ObjectMakerFromOracleSP.OracleHelper<GET_COMMISSION_STRACTURE_IMAGE>.GetDataBySP(new GET_COMMISSION_STRACTURE_IMAGE(), "SP_GET_COMM_STRACTURE_IMAGE", 1, resultOutCurSor, distributorID_OP, retailerID_OP, productID_OP, tranFromDateOP, tranToDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<GET_REGION> GetRegion(decimal ClusterId, decimal UserId, decimal IsRegionLevel)
        {
            try
            {
                OracleParameter ClusterId_OP = new OracleParameter();
                ClusterId_OP.Direction = System.Data.ParameterDirection.Input;
                ClusterId_OP.OracleDbType = OracleDbType.Decimal;
                ClusterId_OP.Value = ClusterId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter IsRegionLevel_OP = new OracleParameter();
                IsRegionLevel_OP.Direction = System.Data.ParameterDirection.Input;
                IsRegionLevel_OP.OracleDbType = OracleDbType.Decimal;
                IsRegionLevel_OP.Value = IsRegionLevel;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_REGION>)ObjectMakerFromOracleSP.OracleHelper<GET_REGION>.GetDataBySP(new GET_REGION(), "SP_FF_GET_REGION", 2, resultOutCurSor, ClusterId_OP, UserId_OP, IsRegionLevel_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_ZONE> GetZones(decimal ZoneId, decimal RegionId, decimal UserId, decimal IsZonalUser)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = ZoneId;

                OracleParameter RegionId_OP = new OracleParameter();
                RegionId_OP.Direction = System.Data.ParameterDirection.Input;
                RegionId_OP.OracleDbType = OracleDbType.Decimal;
                RegionId_OP.Value = RegionId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter IsZonalUser_OP = new OracleParameter();
                IsZonalUser_OP.Direction = System.Data.ParameterDirection.Input;
                IsZonalUser_OP.OracleDbType = OracleDbType.Decimal;
                IsZonalUser_OP.Value = IsZonalUser;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_ZONE>)ObjectMakerFromOracleSP.OracleHelper<GET_ZONE>.GetDataBySP(new GET_ZONE(), "SP_FF_GET_ZONES", 3, resultOutCurSor, ZoneId_OP, RegionId_OP, UserId_OP, IsZonalUser_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_ALL_ZONE> GetAllZones(decimal ZoneId, decimal RegionId, decimal UserId, decimal IsZonalUser)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = ZoneId;

                OracleParameter RegionId_OP = new OracleParameter();
                RegionId_OP.Direction = System.Data.ParameterDirection.Input;
                RegionId_OP.OracleDbType = OracleDbType.Decimal;
                RegionId_OP.Value = RegionId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter IsZonalUser_OP = new OracleParameter();
                IsZonalUser_OP.Direction = System.Data.ParameterDirection.Input;
                IsZonalUser_OP.OracleDbType = OracleDbType.Decimal;
                IsZonalUser_OP.Value = IsZonalUser;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_ALL_ZONE>)ObjectMakerFromOracleSP.OracleHelper<GET_ALL_ZONE>.GetDataBySP(new GET_ALL_ZONE(), "SP_FF_GET_ZONES", 3, resultOutCurSor, ZoneId_OP, RegionId_OP, UserId_OP, IsZonalUser_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_DROPDOWN> GetRoutesByZone(decimal ZoneId)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = ZoneId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_DROPDOWN>)ObjectMakerFromOracleSP.OracleHelper<GET_DROPDOWN>.GetDataBySP(new GET_DROPDOWN(), "SP_FF_GET_ROUTE_BY_ZONE", 3, resultOutCurSor, ZoneId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_ZONE> GetZone(decimal regionID)
        {
            try
            {
                OracleParameter regionID_OP = new OracleParameter();
                regionID_OP.Direction = System.Data.ParameterDirection.Input;
                regionID_OP.OracleDbType = OracleDbType.Decimal;
                regionID_OP.Value = regionID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_ZONE>)ObjectMakerFromOracleSP.OracleHelper<GET_ZONE>.GetDataBySP(new GET_ZONE(), "SP_GET_ZONE", 2, resultOutCurSor, regionID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_TERITORY> GetTeritory(decimal zoneID)
        {
            try
            {
                OracleParameter zoneID_OP = new OracleParameter();
                zoneID_OP.Direction = System.Data.ParameterDirection.Input;
                zoneID_OP.OracleDbType = OracleDbType.Decimal;
                zoneID_OP.Value = zoneID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_TERITORY>)ObjectMakerFromOracleSP.OracleHelper<GET_TERITORY>.GetDataBySP(new GET_TERITORY(), "SP_GET_TERITORY", 2, resultOutCurSor, zoneID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
