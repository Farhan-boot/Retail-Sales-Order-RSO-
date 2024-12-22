using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
	public class NotificationDZ
	{
		public NotificationDZ() { }

		/// <summary>
		/// Save or upate current offer if id is zero then save data other update by parameter values.
		/// </summary>      
		/// <returns>if save or update properly return Table ID or zero fail save or update info </returns>
		public Decimal SaveUpdateNotification(decimal Id, decimal _TYPE, string StartDate, string EndDate,
											 string _TITLE, string _DISCRIPTION,string _ISACTIVE, decimal _CREATE_BY, decimal _MODIFY_BY
											,byte[] _IMG, string _FILE,  string _STRMODE )
		{
			try
			{
				OracleParameter Id_OP = new OracleParameter();
				Id_OP.Direction = System.Data.ParameterDirection.Input;
				Id_OP.OracleDbType = OracleDbType.Decimal;
				Id_OP.Value = Id;

				OracleParameter TYPE_OP = new OracleParameter();
				TYPE_OP.Direction = System.Data.ParameterDirection.Input;
				TYPE_OP.OracleDbType = OracleDbType.Decimal;
				TYPE_OP.Value = _TYPE;

				OracleParameter StartDate_OP = new OracleParameter();
				StartDate_OP.Direction = System.Data.ParameterDirection.Input;
				StartDate_OP.OracleDbType = OracleDbType.Date;
				StartDate_OP.Value = StartDate;

				OracleParameter EndDate_OP = new OracleParameter();
				EndDate_OP.Direction = System.Data.ParameterDirection.Input;
				EndDate_OP.OracleDbType = OracleDbType.Date;
				EndDate_OP.Value = EndDate;

				OracleParameter TITLE_OP = new OracleParameter();
				TITLE_OP.Direction = System.Data.ParameterDirection.Input;
				TITLE_OP.OracleDbType = OracleDbType.Varchar2;
				TITLE_OP.Value = _TITLE;

				OracleParameter DISCRIPTION_OP = new OracleParameter();
				DISCRIPTION_OP.Direction = System.Data.ParameterDirection.Input;
				DISCRIPTION_OP.OracleDbType = OracleDbType.Varchar2;
				DISCRIPTION_OP.Value = _DISCRIPTION;

				OracleParameter _ISACTIVE_OP = new OracleParameter();
				_ISACTIVE_OP.Direction = System.Data.ParameterDirection.Input;
				_ISACTIVE_OP.OracleDbType = OracleDbType.Varchar2;
				_ISACTIVE_OP.Value = _ISACTIVE;
				
				OracleParameter CREATEBY_OP = new OracleParameter();
				CREATEBY_OP.Direction = System.Data.ParameterDirection.Input;
				CREATEBY_OP.OracleDbType = OracleDbType.Decimal;
				CREATEBY_OP.Value = _CREATE_BY;

				OracleParameter _MODIFYBY_OP = new OracleParameter();
				_MODIFYBY_OP.Direction = System.Data.ParameterDirection.Input;
				_MODIFYBY_OP.OracleDbType = OracleDbType.Decimal;
				_MODIFYBY_OP.Value = _MODIFY_BY;

				OracleParameter Picture_OP = new OracleParameter();
				Picture_OP.Direction = System.Data.ParameterDirection.Input;
				Picture_OP.OracleDbType = OracleDbType.Blob;
				Picture_OP.Value = _IMG;

				OracleParameter _FILE_OP = new OracleParameter();
				_FILE_OP.Direction = System.Data.ParameterDirection.Input;
				_FILE_OP.OracleDbType = OracleDbType.Varchar2;
				_FILE_OP.Value = _FILE;

				OracleParameter _STRMODE_OP = new OracleParameter();
				_STRMODE_OP.Direction = System.Data.ParameterDirection.Input;
				_STRMODE_OP.OracleDbType = OracleDbType.Varchar2;
				_STRMODE_OP.Value = _STRMODE;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;


				return ObjectMakerFromOracleSP.OracleHelper<SP_GET_NOTIFICATIONS>.InsertDataBySP("SP_FF_INS_UPD_NOTIFICATION", Id_OP, TYPE_OP, StartDate_OP, EndDate_OP, TITLE_OP, DISCRIPTION_OP, _ISACTIVE_OP, CREATEBY_OP, _MODIFYBY_OP, Picture_OP, _FILE_OP, _STRMODE_OP, resultOutID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<SP_GET_NOTIFICATIONS> GetNotification(decimal APPID, decimal UserId, decimal RETAILERID, decimal Id, decimal TYPE, string FROMDATE, string TODATE)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter APPID_OP = new OracleParameter();
				APPID_OP.Direction = System.Data.ParameterDirection.Input;
				APPID_OP.OracleDbType = OracleDbType.Decimal;
				APPID_OP.Value = APPID;

				OracleParameter UserId_OP = new OracleParameter();
				UserId_OP.Direction = System.Data.ParameterDirection.Input;
				UserId_OP.OracleDbType = OracleDbType.Decimal;
				UserId_OP.Value = UserId;

				OracleParameter RETAILERID_OP = new OracleParameter();
				RETAILERID_OP.Direction = System.Data.ParameterDirection.Input;
				RETAILERID_OP.OracleDbType = OracleDbType.Decimal;
				RETAILERID_OP.Value = RETAILERID;

				OracleParameter Id_OP = new OracleParameter();
				Id_OP.Direction = System.Data.ParameterDirection.Input;
				Id_OP.OracleDbType = OracleDbType.Decimal;
				Id_OP.Value = Id;


				OracleParameter TYPE_OP = new OracleParameter();
				TYPE_OP.Direction = System.Data.ParameterDirection.Input;
				TYPE_OP.OracleDbType = OracleDbType.Decimal;
				TYPE_OP.Value = TYPE;


				OracleParameter FROMDATE_OP = new OracleParameter();
				FROMDATE_OP.Direction = System.Data.ParameterDirection.Input;
				FROMDATE_OP.OracleDbType = OracleDbType.Varchar2;
				FROMDATE_OP.Value = FROMDATE;


				OracleParameter TODATE_OP = new OracleParameter();
				TODATE_OP.Direction = System.Data.ParameterDirection.Input;
				TODATE_OP.OracleDbType = OracleDbType.Varchar2;
				TODATE_OP.Value = TODATE;



				return (List<SP_GET_NOTIFICATIONS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_NOTIFICATIONS>.GetDataBySP(new SP_GET_NOTIFICATIONS(), "SP_FF_GET_NOTIFICATION_V2", 10, resultOutCurSor, APPID_OP, UserId_OP, RETAILERID_OP, Id_OP, TYPE_OP, FROMDATE_OP, TODATE_OP);
				//return (List<SP_GET_NOTIFICATIONS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_NOTIFICATIONS>.GetDataBySP(new SP_GET_NOTIFICATIONS(), "SP_FF_GET_NOTIFICATION", 10, resultOutCurSor, APPID_OP, UserId_OP, RETAILERID_OP, Id_OP, TYPE_OP, FROMDATE_OP, TODATE_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<SP_FF_GET_NOTIFICATION_TYPE> GetNotificationTypes(Decimal nottificationTypeId)
		{
			try
			{
				OracleParameter CenterTypeId_OP = new OracleParameter();
				CenterTypeId_OP.Direction = System.Data.ParameterDirection.Input;
				CenterTypeId_OP.OracleDbType = OracleDbType.Decimal;
				CenterTypeId_OP.Value = nottificationTypeId;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_FF_GET_NOTIFICATION_TYPE>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_NOTIFICATION_TYPE>.GetDataBySP(new SP_FF_GET_NOTIFICATION_TYPE(), "SP_FF_GET_NOTIFICATION_TYPE", 2, resultOutCurSor, CenterTypeId_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}






		/// <summary>
		/// Gets all current offer object list or particular current offer object which filter by search parameter.
		/// </summary>       
		/// <returns>List of current offer object</returns>   
		/*	public List<SP_GET_CURRENT_OFFERcls> GetCurrentOfferByDistributor(decimal distributorID)
			{
				try
				{
					OracleParameter distributorID_OP = new OracleParameter();
					distributorID_OP.Direction = System.Data.ParameterDirection.Input;
					distributorID_OP.OracleDbType = OracleDbType.Decimal;
					distributorID_OP.Value = distributorID;

					OracleParameter resultOutCurSor = new OracleParameter();
					resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
					resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

					return (List<SP_GET_CURRENT_OFFERcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFERcls>.GetDataBySP(new SP_GET_CURRENT_OFFERcls(), "SP_GET_CURRENT_OFFER", 3, resultOutCurSor, distributorID_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			/// <summary>
			/// Gets all current offer object list or particular current offer object which filter by search parameter.
			/// </summary>       
			/// <returns>List of current offer object</returns>   
			public List<SP_GET_CURRENT_OFFERcls> GetCurrentOfferSearch(decimal currentOfferID, decimal distributorID,
																		string offerName, string startDate, string endDate, Decimal currentPage)
			{
				try
				{
					OracleParameter currentOffer_OP = new OracleParameter();
					currentOffer_OP.Direction = System.Data.ParameterDirection.Input;
					currentOffer_OP.OracleDbType = OracleDbType.Decimal;
					currentOffer_OP.Value = currentOfferID;

					OracleParameter distributorID_OP = new OracleParameter();
					distributorID_OP.Direction = System.Data.ParameterDirection.Input;
					distributorID_OP.OracleDbType = OracleDbType.Decimal;
					distributorID_OP.Value = distributorID;

					OracleParameter offerName_OP = new OracleParameter();
					offerName_OP.Direction = System.Data.ParameterDirection.Input;
					offerName_OP.OracleDbType = OracleDbType.Varchar2;
					offerName_OP.Value = offerName;

					OracleParameter startDate_OP = new OracleParameter();
					startDate_OP.Direction = System.Data.ParameterDirection.Input;
					startDate_OP.OracleDbType = OracleDbType.Varchar2;
					startDate_OP.Value = startDate;

					OracleParameter endDate_OP = new OracleParameter();
					endDate_OP.Direction = System.Data.ParameterDirection.Input;
					endDate_OP.OracleDbType = OracleDbType.Varchar2;
					endDate_OP.Value = endDate;

					OracleParameter currentPage_OP = new OracleParameter();
					currentPage_OP.Direction = System.Data.ParameterDirection.Input;
					currentPage_OP.OracleDbType = OracleDbType.Decimal;
					currentPage_OP.Value = currentPage;

					OracleParameter resultOutCurSor = new OracleParameter();
					resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
					resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

					return (List<SP_GET_CURRENT_OFFERcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFERcls>.GetDataBySP(new SP_GET_CURRENT_OFFERcls(), "SP_GET_CURRENT_OFFER", 11, resultOutCurSor, currentOffer_OP, distributorID_OP, offerName_OP, startDate_OP, endDate_OP, currentPage_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}



			public Decimal DeleteExistingCurrentOfferDist(decimal CurrentOfferId)
			{
				try
				{
					OracleParameter CurrentOfferId_OP = new OracleParameter();
					CurrentOfferId_OP.Direction = System.Data.ParameterDirection.Input;
					CurrentOfferId_OP.OracleDbType = OracleDbType.Decimal;
					CurrentOfferId_OP.Value = CurrentOfferId;

					OracleParameter resultOutID = new OracleParameter();
					resultOutID.Direction = System.Data.ParameterDirection.Output;
					resultOutID.OracleDbType = OracleDbType.Decimal;

					return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_DELETE_CRNT_OFFER_DIST", resultOutID, CurrentOfferId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public Decimal SaveUpdateCurrentOfferDistributor(decimal CurrentOfferId, decimal DistributorId)
			{
				try
				{
					OracleParameter CurrentOfferId_OP = new OracleParameter();
					CurrentOfferId_OP.Direction = System.Data.ParameterDirection.Input;
					CurrentOfferId_OP.OracleDbType = OracleDbType.Decimal;
					CurrentOfferId_OP.Value = CurrentOfferId;

					OracleParameter DistributorId_OP = new OracleParameter();
					DistributorId_OP.Direction = System.Data.ParameterDirection.Input;
					DistributorId_OP.OracleDbType = OracleDbType.Decimal;
					DistributorId_OP.Value = DistributorId;

					OracleParameter resultOutID = new OracleParameter();
					resultOutID.Direction = System.Data.ParameterDirection.Output;
					resultOutID.OracleDbType = OracleDbType.Decimal;

					return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_UPD_CRNT_OFFER_DIST", resultOutID, CurrentOfferId_OP, DistributorId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}


			public Decimal SaveUpdateCommissionStructure(decimal Id, string OfferName,
											   string OfferDetail, DateTime StartDate, DateTime EndDate,
											   DateTime DisplayDateFrom, DateTime DisplayDateTo, decimal TargetType,
											   decimal IsToAll, decimal StaffRoleId, decimal IsActive, decimal CreatedBy)
			{
				try
				{
					OracleParameter Id_OP = new OracleParameter();
					Id_OP.Direction = System.Data.ParameterDirection.Input;
					Id_OP.OracleDbType = OracleDbType.Decimal;
					Id_OP.Value = Id;

					OracleParameter OfferName_OP = new OracleParameter();
					OfferName_OP.Direction = System.Data.ParameterDirection.Input;
					OfferName_OP.OracleDbType = OracleDbType.Varchar2;
					OfferName_OP.Value = OfferName;

					OracleParameter OfferDetail_OP = new OracleParameter();
					OfferDetail_OP.Direction = System.Data.ParameterDirection.Input;
					OfferDetail_OP.OracleDbType = OracleDbType.Varchar2;
					OfferDetail_OP.Value = OfferDetail;

					OracleParameter StartDate_OP = new OracleParameter();
					StartDate_OP.Direction = System.Data.ParameterDirection.Input;
					StartDate_OP.OracleDbType = OracleDbType.Date;
					StartDate_OP.Value = StartDate;

					OracleParameter EndDate_OP = new OracleParameter();
					EndDate_OP.Direction = System.Data.ParameterDirection.Input;
					EndDate_OP.OracleDbType = OracleDbType.Date;
					EndDate_OP.Value = EndDate;

					OracleParameter DisplayDateFrom_OP = new OracleParameter();
					DisplayDateFrom_OP.Direction = System.Data.ParameterDirection.Input;
					DisplayDateFrom_OP.OracleDbType = OracleDbType.Date;
					DisplayDateFrom_OP.Value = DisplayDateFrom;

					OracleParameter DisplayDateTo_OP = new OracleParameter();
					DisplayDateTo_OP.Direction = System.Data.ParameterDirection.Input;
					DisplayDateTo_OP.OracleDbType = OracleDbType.Date;
					DisplayDateTo_OP.Value = DisplayDateTo;

					OracleParameter TargetType_OP = new OracleParameter();
					TargetType_OP.Direction = System.Data.ParameterDirection.Input;
					TargetType_OP.OracleDbType = OracleDbType.Decimal;
					TargetType_OP.Value = TargetType;

					OracleParameter IsToAll_OP = new OracleParameter();
					IsToAll_OP.Direction = System.Data.ParameterDirection.Input;
					IsToAll_OP.OracleDbType = OracleDbType.Decimal;
					IsToAll_OP.Value = IsToAll;

					OracleParameter StaffRoleId_OP = new OracleParameter();
					StaffRoleId_OP.Direction = System.Data.ParameterDirection.Input;
					StaffRoleId_OP.OracleDbType = OracleDbType.Decimal;
					StaffRoleId_OP.Value = StaffRoleId;

					OracleParameter IsActive_OP = new OracleParameter();
					IsActive_OP.Direction = System.Data.ParameterDirection.Input;
					IsActive_OP.OracleDbType = OracleDbType.Decimal;
					IsActive_OP.Value = IsActive;

					OracleParameter CreatedBy_OP = new OracleParameter();
					CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
					CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
					CreatedBy_OP.Value = CreatedBy;

					OracleParameter resultOutID = new OracleParameter();
					resultOutID.Direction = System.Data.ParameterDirection.Output;
					resultOutID.OracleDbType = OracleDbType.Decimal;

					return ObjectMakerFromOracleSP.OracleHelper<SP_GET_COMMISSION_STRUCTURE>.InsertDataBySP("SP_FF_INS_UPD_COMM_STRUCTURE", resultOutID, Id_OP, OfferName_OP, OfferDetail_OP, StartDate_OP, EndDate_OP, DisplayDateFrom_OP, DisplayDateTo_OP, TargetType_OP, IsToAll_OP, StaffRoleId_OP, IsActive_OP, CreatedBy_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}



			public Decimal DeletePicture(decimal PictureId)
			{
				try
				{
					OracleParameter PictureId_OP = new OracleParameter();
					PictureId_OP.Direction = System.Data.ParameterDirection.Input;
					PictureId_OP.OracleDbType = OracleDbType.Decimal;
					PictureId_OP.Value = PictureId;

					OracleParameter resultOutID = new OracleParameter();
					resultOutID.Direction = System.Data.ParameterDirection.Output;
					resultOutID.OracleDbType = OracleDbType.Decimal;

					return ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFER>.InsertDataBySP("SP_FF_DELETE_OFFER_PICTURES", resultOutID, PictureId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public Decimal DeleteCommissionPicture(decimal PictureId)
			{
				try
				{
					OracleParameter PictureId_OP = new OracleParameter();
					PictureId_OP.Direction = System.Data.ParameterDirection.Input;
					PictureId_OP.OracleDbType = OracleDbType.Decimal;
					PictureId_OP.Value = PictureId;

					OracleParameter resultOutID = new OracleParameter();
					resultOutID.Direction = System.Data.ParameterDirection.Output;
					resultOutID.OracleDbType = OracleDbType.Decimal;

					return ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFER>.InsertDataBySP("SP_FF_DELETE_COMM_PICTURES", resultOutID, PictureId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}



			public Decimal SaveUpdateOfferPictures(decimal Id, decimal OfferId, decimal PicSlNo, string PictureName, byte[] Picture, decimal CreatedBy)
			{
				try
				{
					OracleParameter Id_OP = new OracleParameter();
					Id_OP.Direction = System.Data.ParameterDirection.Input;
					Id_OP.OracleDbType = OracleDbType.Decimal;
					Id_OP.Value = Id;

					OracleParameter OfferId_OP = new OracleParameter();
					OfferId_OP.Direction = System.Data.ParameterDirection.Input;
					OfferId_OP.OracleDbType = OracleDbType.Decimal;
					OfferId_OP.Value = OfferId;

					OracleParameter PicSlNo_OP = new OracleParameter();
					PicSlNo_OP.Direction = System.Data.ParameterDirection.Input;
					PicSlNo_OP.OracleDbType = OracleDbType.Decimal;
					PicSlNo_OP.Value = PicSlNo;

					OracleParameter PictureName_OP = new OracleParameter();
					PictureName_OP.Direction = System.Data.ParameterDirection.Input;
					PictureName_OP.OracleDbType = OracleDbType.Varchar2;
					PictureName_OP.Value = PictureName;

					OracleParameter Picture_OP = new OracleParameter();
					Picture_OP.Direction = System.Data.ParameterDirection.Input;
					Picture_OP.OracleDbType = OracleDbType.Blob;
					Picture_OP.Value = Picture;

					OracleParameter CreatedBy_OP = new OracleParameter();
					CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
					CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
					CreatedBy_OP.Value = CreatedBy;

					OracleParameter resultOutID = new OracleParameter();
					resultOutID.Direction = System.Data.ParameterDirection.Output;
					resultOutID.OracleDbType = OracleDbType.Decimal;

					return ObjectMakerFromOracleSP.OracleHelper<SP_GET_COMMISSION_STRUCTURE>.InsertDataBySP("SP_FF_INS_UPD_OFFER_PICTURES", resultOutID, Id_OP, OfferId_OP, PicSlNo_OP, PictureName_OP, Picture_OP, CreatedBy_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}


			public Decimal SaveUpdateCommissionPictures(decimal Id, decimal CommissionId, decimal PicSlNo, string PictureName, byte[] Picture, decimal CreatedBy)
			{
				try
				{
					OracleParameter Id_OP = new OracleParameter();
					Id_OP.Direction = System.Data.ParameterDirection.Input;
					Id_OP.OracleDbType = OracleDbType.Decimal;
					Id_OP.Value = Id;

					OracleParameter CommissionId_OP = new OracleParameter();
					CommissionId_OP.Direction = System.Data.ParameterDirection.Input;
					CommissionId_OP.OracleDbType = OracleDbType.Decimal;
					CommissionId_OP.Value = CommissionId;

					OracleParameter PicSlNo_OP = new OracleParameter();
					PicSlNo_OP.Direction = System.Data.ParameterDirection.Input;
					PicSlNo_OP.OracleDbType = OracleDbType.Decimal;
					PicSlNo_OP.Value = PicSlNo;

					OracleParameter PictureName_OP = new OracleParameter();
					PictureName_OP.Direction = System.Data.ParameterDirection.Input;
					PictureName_OP.OracleDbType = OracleDbType.Varchar2;
					PictureName_OP.Value = PictureName;

					OracleParameter Picture_OP = new OracleParameter();
					Picture_OP.Direction = System.Data.ParameterDirection.Input;
					Picture_OP.OracleDbType = OracleDbType.Blob;
					Picture_OP.Value = Picture;

					OracleParameter CreatedBy_OP = new OracleParameter();
					CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
					CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
					CreatedBy_OP.Value = CreatedBy;

					OracleParameter resultOutID = new OracleParameter();
					resultOutID.Direction = System.Data.ParameterDirection.Output;
					resultOutID.OracleDbType = OracleDbType.Decimal;

					return ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFER>.InsertDataBySP("SP_FF_INS_UPD_COMM_PICTURES", resultOutID, Id_OP, CommissionId_OP, PicSlNo_OP, PictureName_OP, Picture_OP, CreatedBy_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public List<SP_GET_CURRENT_OFFER> GetCurrentOffer(decimal StaffUserId)
			{
				try
				{
					OracleParameter StaffUserId_OP = new OracleParameter();
					StaffUserId_OP.Direction = System.Data.ParameterDirection.Input;
					StaffUserId_OP.OracleDbType = OracleDbType.Decimal;
					StaffUserId_OP.Value = StaffUserId;

					OracleParameter resultOutCurSor = new OracleParameter();
					resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
					resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

					return (List<SP_GET_CURRENT_OFFER>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFER>.GetDataBySP(new SP_GET_CURRENT_OFFER(), "SP_FF_GET_STAFF_CURRENT_OFFER", 5, resultOutCurSor, StaffUserId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public List<SP_GET_CURRENT_OFFER> GetRetailerCurrentOffer(decimal RetailerId)
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

					return (List<SP_GET_CURRENT_OFFER>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFER>.GetDataBySP(new SP_GET_CURRENT_OFFER(), "SP_FF_GET_RET_CURRENT_OFFER", 5, resultOutCurSor, RetailerId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public List<SP_GET_CURRENT_OFFER> GetRSOCurrentOffer(decimal RSOId)
			{
				try
				{
					OracleParameter RSOId_OP = new OracleParameter();
					RSOId_OP.Direction = System.Data.ParameterDirection.Input;
					RSOId_OP.OracleDbType = OracleDbType.Decimal;
					RSOId_OP.Value = RSOId;

					OracleParameter resultOutCurSor = new OracleParameter();
					resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
					resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

					return (List<SP_GET_CURRENT_OFFER>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFER>.GetDataBySP(new SP_GET_CURRENT_OFFER(), "SP_FF_GET_STAFF_CURRENT_OFFER", 5, resultOutCurSor, RSOId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public List<SP_GET_FEEDBACK_OPTION> GetFeedbackOptions(decimal UserId)
			{
				try
				{
					OracleParameter UserId_OP = new OracleParameter();
					UserId_OP.Direction = System.Data.ParameterDirection.Input;
					UserId_OP.OracleDbType = OracleDbType.Decimal;
					UserId_OP.Value = UserId;

					OracleParameter resultOutCurSor = new OracleParameter();
					resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
					resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

					return (List<SP_GET_FEEDBACK_OPTION>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FEEDBACK_OPTION>.GetDataBySP(new SP_GET_FEEDBACK_OPTION(), "SP_FF_GET_FEEDBACK_OPTIONS", 2, resultOutCurSor, UserId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public List<SP_GET_COMPLAIN_TYPE> GetComplainTypes(decimal Id)
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

					return (List<SP_GET_COMPLAIN_TYPE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_COMPLAIN_TYPE>.GetDataBySP(new SP_GET_COMPLAIN_TYPE(), "SP_FF_GET_COMPLAIN_TYPES", 3, resultOutCurSor, Id_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}


			public List<SP_GET_ALL_CURRENT_OFFER> GetAllCurrentOffer(decimal CurrentOfferId)
			{
				try
				{
					OracleParameter CurrentOfferId_OP = new OracleParameter();
					CurrentOfferId_OP.Direction = System.Data.ParameterDirection.Input;
					CurrentOfferId_OP.OracleDbType = OracleDbType.Decimal;
					CurrentOfferId_OP.Value = CurrentOfferId;

					OracleParameter resultOutCurSor = new OracleParameter();
					resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
					resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

					return (List<SP_GET_ALL_CURRENT_OFFER>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ALL_CURRENT_OFFER>.GetDataBySP(new SP_GET_ALL_CURRENT_OFFER(), "SP_FF_GET_ALL_CURRENT_OFFER", 15, resultOutCurSor, CurrentOfferId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public List<SP_GET_ALL_DISTRIBUTOR> GetCurrentOfferDistributor(decimal CurrentOfferId)
			{
				try
				{
					OracleParameter CurrentOfferId_OP = new OracleParameter();
					CurrentOfferId_OP.Direction = System.Data.ParameterDirection.Input;
					CurrentOfferId_OP.OracleDbType = OracleDbType.Decimal;
					CurrentOfferId_OP.Value = CurrentOfferId;

					OracleParameter resultOutCurSor = new OracleParameter();
					resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
					resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

					return (List<SP_GET_ALL_DISTRIBUTOR>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ALL_DISTRIBUTOR>.GetDataBySP(new SP_GET_ALL_DISTRIBUTOR(), "SP_FF_GET_CURRENT_OFFER_DIST", 4, resultOutCurSor, CurrentOfferId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}


			public List<SP_GET_COMMISSION_STRUCTURE> GetAllCommission(decimal CommissionId)
			{
				try
				{
					OracleParameter CommissionId_OP = new OracleParameter();
					CommissionId_OP.Direction = System.Data.ParameterDirection.Input;
					CommissionId_OP.OracleDbType = OracleDbType.Decimal;
					CommissionId_OP.Value = CommissionId;

					OracleParameter resultOutCurSor = new OracleParameter();
					resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
					resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

					return (List<SP_GET_COMMISSION_STRUCTURE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_COMMISSION_STRUCTURE>.GetDataBySP(new SP_GET_COMMISSION_STRUCTURE(), "SP_FF_GET_ALL_COMMISSION", 15, resultOutCurSor, CommissionId_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public List<SP_GET_COMMISSION_STRUCTURE> GetCommissionStructureEntityWise(decimal UserId, decimal EntityType)
			{
				try
				{
					OracleParameter UserId_OP = new OracleParameter();
					UserId_OP.Direction = System.Data.ParameterDirection.Input;
					UserId_OP.OracleDbType = OracleDbType.Decimal;
					UserId_OP.Value = UserId;

					OracleParameter EntityType_OP = new OracleParameter();
					EntityType_OP.Direction = System.Data.ParameterDirection.Input;
					EntityType_OP.OracleDbType = OracleDbType.Decimal;
					EntityType_OP.Value = EntityType;

					OracleParameter resultOutCurSor = new OracleParameter();
					resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
					resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

					return (List<SP_GET_COMMISSION_STRUCTURE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_COMMISSION_STRUCTURE>.GetDataBySP(new SP_GET_COMMISSION_STRUCTURE(), "SP_FF_GET_COMMISSION_ENTITY", 15, resultOutCurSor, UserId_OP, EntityType_OP);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			} */


	}
}
