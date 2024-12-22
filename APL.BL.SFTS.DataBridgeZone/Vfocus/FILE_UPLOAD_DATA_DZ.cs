using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace APL.BL.SFTS.DataBridgeZone.Vfocus
{
	public class B2C_UPLOAD_FILEDZ
	{
		public B2C_UPLOAD_FILEDZ()
		{

		}


		public List<GET_B2CSCAPPTARGETPROCESS> GET_B2CSCAPPTARGETPROCESS()
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return (List<GET_B2CSCAPPTARGETPROCESS>)ObjectMakerFromOracleSP.OracleHelper<GET_B2CSCAPPTARGETPROCESS>.GetDataBySP(new GET_B2CSCAPPTARGETPROCESS(), "GET_SALESTARGET_UPLOAD_TEMP", 13, resultOutCurSor, resultOutID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public Decimal SAVE_SALESTARGET_UPLOAD_TEMP(DateTime TARGET_DATE, string REGION, string DD_CODE, string DD_NAME, Decimal RP_SIM, Decimal RP_EV, decimal GA, Decimal DS_EV, decimal DS_SC, decimal TOTAL_DS, Decimal RECH_SC, decimal RECH_EV, Decimal TOTAL_RECH, string STRMODE)
		{
			try
			{

				OracleParameter TARGET_DATE_OP = new OracleParameter();
				TARGET_DATE_OP.Direction = System.Data.ParameterDirection.Input;
				TARGET_DATE_OP.OracleDbType = OracleDbType.Date;
				TARGET_DATE_OP.Value = TARGET_DATE;

				OracleParameter REGION_OP = new OracleParameter();
				REGION_OP.Direction = System.Data.ParameterDirection.Input;
				REGION_OP.OracleDbType = OracleDbType.Varchar2;
				REGION_OP.Value = REGION;

				OracleParameter DD_CODE_OP = new OracleParameter();
				DD_CODE_OP.Direction = System.Data.ParameterDirection.Input;
				DD_CODE_OP.OracleDbType = OracleDbType.Varchar2;
				DD_CODE_OP.Value = DD_CODE;

				OracleParameter DD_NAME_OP = new OracleParameter();
				DD_NAME_OP.Direction = System.Data.ParameterDirection.Input;
				DD_NAME_OP.OracleDbType = OracleDbType.Varchar2;
				DD_NAME_OP.Value = DD_NAME;

				OracleParameter RP_SIM_OP = new OracleParameter();
				RP_SIM_OP.Direction = System.Data.ParameterDirection.Input;
				RP_SIM_OP.OracleDbType = OracleDbType.Decimal;
				RP_SIM_OP.Value = RP_SIM;

				OracleParameter RP_EV_OP = new OracleParameter();
				RP_EV_OP.Direction = System.Data.ParameterDirection.Input;
				RP_EV_OP.OracleDbType = OracleDbType.Decimal;
				RP_EV_OP.Value = RP_EV;


				OracleParameter GA_OP = new OracleParameter();
				GA_OP.Direction = System.Data.ParameterDirection.Input;
				GA_OP.OracleDbType = OracleDbType.Decimal;
				GA_OP.Value = GA;
				

				OracleParameter DS_EV_OP = new OracleParameter();
				DS_EV_OP.Direction = System.Data.ParameterDirection.Input;
				DS_EV_OP.OracleDbType = OracleDbType.Decimal;
				DS_EV_OP.Value = DS_EV;
				

				OracleParameter DS_SC_OP = new OracleParameter();
				DS_SC_OP.Direction = System.Data.ParameterDirection.Input;
				DS_SC_OP.OracleDbType = OracleDbType.Decimal;
				DS_SC_OP.Value = DS_SC;
				

				OracleParameter TOTAL_DS_OP = new OracleParameter();
				TOTAL_DS_OP.Direction = System.Data.ParameterDirection.Input;
				TOTAL_DS_OP.OracleDbType = OracleDbType.Decimal;
				TOTAL_DS_OP.Value = TOTAL_DS;

				
				OracleParameter RECH_SC_OP = new OracleParameter();
				RECH_SC_OP.Direction = System.Data.ParameterDirection.Input;
				RECH_SC_OP.OracleDbType = OracleDbType.Decimal;
				RECH_SC_OP.Value = RECH_SC;

				OracleParameter RECH_EV_OP = new OracleParameter();
				RECH_EV_OP.Direction = System.Data.ParameterDirection.Input;
				RECH_EV_OP.OracleDbType = OracleDbType.Decimal;
				RECH_EV_OP.Value = RECH_EV;
								
				OracleParameter TOTAL_RECH_OP = new OracleParameter();
				TOTAL_RECH_OP.Direction = System.Data.ParameterDirection.Input;
				TOTAL_RECH_OP.OracleDbType = OracleDbType.Decimal;
				TOTAL_RECH_OP.Value = TOTAL_RECH;
							

				OracleParameter STRMODE_OP = new OracleParameter();
				STRMODE_OP.Direction = System.Data.ParameterDirection.Input;
				STRMODE_OP.OracleDbType = OracleDbType.Varchar2;
				STRMODE_OP.Value = STRMODE;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;



				return ObjectMakerFromOracleSP.OracleHelper<ISVALID_UPLOAD>.InsertDataBySP("SAVE_SALESTARGET_UPLOAD_TEMP", resultOutID, TARGET_DATE_OP, REGION_OP, DD_CODE_OP, DD_NAME_OP, RP_SIM_OP, RP_EV_OP, GA_OP, DS_EV_OP, DS_SC_OP, TOTAL_DS_OP, RECH_SC_OP, RECH_EV_OP, TOTAL_RECH_OP, STRMODE_OP);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public Decimal SAVE_B2CSCAPPTARGETPROCESS()
		{
			try
			{
				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<ISVALID_UPLOAD>.InsertDataBySP("SAVE_B2CSCAPPTARGETPROCESS", resultOutID);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<GET_VFOCUS_DENO_TARGET> GET_VFOCUS_DENO_TARGET_TEMP(string RSO_ID, string DENO_ID)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				OracleParameter RSO_ID_OP = new OracleParameter();
				RSO_ID_OP.Direction = System.Data.ParameterDirection.Input;
				RSO_ID_OP.OracleDbType = OracleDbType.Varchar2;
				RSO_ID_OP.Value = RSO_ID;

				OracleParameter DENO_ID_OP = new OracleParameter();
				DENO_ID_OP.Direction = System.Data.ParameterDirection.Input;
				DENO_ID_OP.OracleDbType = OracleDbType.Varchar2;
				DENO_ID_OP.Value = DENO_ID;

				return (List<GET_VFOCUS_DENO_TARGET>)ObjectMakerFromOracleSP.OracleHelper<GET_VFOCUS_DENO_TARGET>.GetDataBySP(new GET_VFOCUS_DENO_TARGET(), "GET_VFOCUS_DENO_TARGET_TEMP", 8, resultOutCurSor, resultOutID, RSO_ID_OP, DENO_ID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<GET_VFOCUS_DENO_TARGET> GET_VFOCUS_DENO_TARGET(string RSO_ID, string DENO_ID)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				OracleParameter RSO_ID_OP = new OracleParameter();
				RSO_ID_OP.Direction = System.Data.ParameterDirection.Input;
				RSO_ID_OP.OracleDbType = OracleDbType.Varchar2;
				RSO_ID_OP.Value = RSO_ID;

				OracleParameter DENO_ID_OP = new OracleParameter();
				DENO_ID_OP.Direction = System.Data.ParameterDirection.Input;
				DENO_ID_OP.OracleDbType = OracleDbType.Varchar2;
				DENO_ID_OP.Value = DENO_ID;

				return (List<GET_VFOCUS_DENO_TARGET>)ObjectMakerFromOracleSP.OracleHelper<GET_VFOCUS_DENO_TARGET>.GetDataBySP(new GET_VFOCUS_DENO_TARGET(), "GET_VFOCUS_DENO_TARGET", 8, resultOutCurSor, resultOutID, RSO_ID_OP, DENO_ID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public Decimal SAVE_VFOCUS_DENO_TARGET_TEMP(string RSO_ID, string DENO_ID, Decimal TARGET_COUNT, Decimal DENO_AMOUNT, string DATE1, string DATE2, Decimal UPLOADBY, string STRMODE)
		{
			try
			{

				OracleParameter RSO_ID_OP = new OracleParameter();
				RSO_ID_OP.Direction = System.Data.ParameterDirection.Input;
				RSO_ID_OP.OracleDbType = OracleDbType.Varchar2;
				RSO_ID_OP.Value = RSO_ID;

				OracleParameter DENO_ID_OP = new OracleParameter();
				DENO_ID_OP.Direction = System.Data.ParameterDirection.Input;
				DENO_ID_OP.OracleDbType = OracleDbType.Varchar2;
				DENO_ID_OP.Value = DENO_ID;

				//OracleParameter TARGET_DATE_OP = new OracleParameter();
				//TARGET_DATE_OP.Direction = System.Data.ParameterDirection.Input;
				//TARGET_DATE_OP.OracleDbType = OracleDbType.Decimal;
				//TARGET_DATE_OP.Value = TARGET_COUNT;


				OracleParameter TARGET_COUNT_OP = new OracleParameter();
				TARGET_COUNT_OP.Direction = System.Data.ParameterDirection.Input;
				TARGET_COUNT_OP.OracleDbType = OracleDbType.Decimal;
				TARGET_COUNT_OP.Value = TARGET_COUNT;

				OracleParameter DENO_AMOUNT_OP = new OracleParameter();
				DENO_AMOUNT_OP.Direction = System.Data.ParameterDirection.Input;
				DENO_AMOUNT_OP.OracleDbType = OracleDbType.Decimal;
				DENO_AMOUNT_OP.Value = DENO_AMOUNT;


				OracleParameter DATE1_OP = new OracleParameter();
				DATE1_OP.Direction = System.Data.ParameterDirection.Input;
				DATE1_OP.OracleDbType = OracleDbType.Varchar2;
				DATE1_OP.Value = DATE1;


				OracleParameter DATE2_OP = new OracleParameter();
				DATE2_OP.Direction = System.Data.ParameterDirection.Input;
				DATE2_OP.OracleDbType = OracleDbType.Varchar2;
				DATE2_OP.Value = DATE2;


				OracleParameter UPLOADBY_OP = new OracleParameter();
				UPLOADBY_OP.Direction = System.Data.ParameterDirection.Input;
				UPLOADBY_OP.OracleDbType = OracleDbType.Decimal;
				UPLOADBY_OP.Value = UPLOADBY;

				OracleParameter STRMODE_OP = new OracleParameter();
				STRMODE_OP.Direction = System.Data.ParameterDirection.Input;
				STRMODE_OP.OracleDbType = OracleDbType.Varchar2;
				STRMODE_OP.Value = STRMODE;


				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<ISVALID_UPLOAD>.InsertDataBySP("SAVE_VFOCUS_DENO_TARGET_TEMP", resultOutID, RSO_ID_OP, DENO_ID_OP, TARGET_COUNT_OP, DENO_AMOUNT_OP, DATE1_OP, DATE2_OP, UPLOADBY_OP, STRMODE_OP);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public Decimal SAVE_VFOCUS_DENO_TARGET(string STRMODE)
		{
			try
			{
				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;


				OracleParameter resultOutMESS = new OracleParameter();
				resultOutMESS.Direction = System.Data.ParameterDirection.Output;
				resultOutMESS.OracleDbType = OracleDbType.Varchar2;

				OracleParameter STRMODE_OP = new OracleParameter();
				STRMODE_OP.Direction = System.Data.ParameterDirection.Input;
				STRMODE_OP.OracleDbType = OracleDbType.Varchar2;
				STRMODE_OP.Value = STRMODE;

				return ObjectMakerFromOracleSP.OracleHelper<ISVALID_UPLOAD>.InsertDataBySP("SAVE_VFOCUS_DENO_TARGET", resultOutID,  STRMODE_OP);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<SP_FF_GET_FILE_UPLOAD_INFO> SP_FF_GET_FILE_UPLOAD_INFO(decimal uploadID,  Decimal CATID, Decimal FORMATID)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;


				OracleParameter uploadID_OP = new OracleParameter();
				uploadID_OP.Direction = System.Data.ParameterDirection.Input;
				uploadID_OP.OracleDbType = OracleDbType.Varchar2;
				uploadID_OP.Value = uploadID;

				OracleParameter CATID_OP = new OracleParameter();
				CATID_OP.Direction = System.Data.ParameterDirection.Input;
				CATID_OP.OracleDbType = OracleDbType.Varchar2;
				CATID_OP.Value = CATID;

				OracleParameter FORMATID_OP = new OracleParameter();
				FORMATID_OP.Direction = System.Data.ParameterDirection.Input;
				FORMATID_OP.OracleDbType = OracleDbType.Varchar2;
				FORMATID_OP.Value = FORMATID;



				return (List<SP_FF_GET_FILE_UPLOAD_INFO>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_FILE_UPLOAD_INFO>.GetDataBySP(new SP_FF_GET_FILE_UPLOAD_INFO(), "SP_FF_GET_FILE_UPLOAD_INFO", 12, resultOutCurSor, resultOutID, uploadID_OP, CATID_OP, FORMATID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public Decimal SP_FF_SAVE_FILE_UPLOAD(decimal ID, string FILE_NAME, string FILE_INFO, Decimal FILE_CATEGORY, Decimal FILE_FORMAT, string LINK,  string ISACTIVE, Decimal UPLOADBY, string STRMODE)
		{
			try
			{

				OracleParameter ID_OP = new OracleParameter();
				ID_OP.Direction = System.Data.ParameterDirection.Input;
				ID_OP.OracleDbType = OracleDbType.Decimal;
				ID_OP.Value = ID;

				OracleParameter FILE_NAME_OP = new OracleParameter();
				FILE_NAME_OP.Direction = System.Data.ParameterDirection.Input;
				FILE_NAME_OP.OracleDbType = OracleDbType.Varchar2;
				FILE_NAME_OP.Value = FILE_NAME;

				OracleParameter FILE_INFO_OP = new OracleParameter();
				FILE_INFO_OP.Direction = System.Data.ParameterDirection.Input;
				FILE_INFO_OP.OracleDbType = OracleDbType.Varchar2;
				FILE_INFO_OP.Value = FILE_INFO;


				OracleParameter FILE_CATEGORY_OP = new OracleParameter();
				FILE_CATEGORY_OP.Direction = System.Data.ParameterDirection.Input;
				FILE_CATEGORY_OP.OracleDbType = OracleDbType.Decimal;
				FILE_CATEGORY_OP.Value = FILE_CATEGORY;

				OracleParameter FILE_FORMAT_OP = new OracleParameter();
				FILE_FORMAT_OP.Direction = System.Data.ParameterDirection.Input;
				FILE_FORMAT_OP.OracleDbType = OracleDbType.Decimal;
				FILE_FORMAT_OP.Value = FILE_FORMAT;

				OracleParameter LINK_OP = new OracleParameter();
				LINK_OP.Direction = System.Data.ParameterDirection.Input;
				LINK_OP.OracleDbType = OracleDbType.Varchar2;
				LINK_OP.Value = LINK;


				OracleParameter ISACTIVE_OP = new OracleParameter();
				ISACTIVE_OP.Direction = System.Data.ParameterDirection.Input;
				ISACTIVE_OP.OracleDbType = OracleDbType.Varchar2;
				ISACTIVE_OP.Value = ISACTIVE;


				OracleParameter UPLOADBY_OP = new OracleParameter();
				UPLOADBY_OP.Direction = System.Data.ParameterDirection.Input;
				UPLOADBY_OP.OracleDbType = OracleDbType.Decimal;
				UPLOADBY_OP.Value = UPLOADBY;


				

				OracleParameter STRMODE_OP = new OracleParameter();
				STRMODE_OP.Direction = System.Data.ParameterDirection.Input;
				STRMODE_OP.OracleDbType = OracleDbType.Varchar2;
				STRMODE_OP.Value = STRMODE;


				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<ISVALID_UPLOAD>.InsertDataBySP("SP_FF_SAVE_FILE_UPLOAD", resultOutID, ID_OP, FILE_NAME_OP, FILE_INFO_OP, FILE_CATEGORY_OP, FILE_FORMAT_OP, LINK_OP, ISACTIVE_OP, UPLOADBY_OP, STRMODE_OP);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public Decimal SP_FF_INS_UPD_VFOUS_FILE_LIST(decimal ID, Decimal FILEID, Decimal FILEID_SL_NO, byte[] Picture, Decimal UPLOADBY)
		{
			try
			{

				OracleParameter ID_OP = new OracleParameter();
				ID_OP.Direction = System.Data.ParameterDirection.Input;
				ID_OP.OracleDbType = OracleDbType.Decimal;
				ID_OP.Value = ID;

				OracleParameter FILEID_OP = new OracleParameter();
				FILEID_OP.Direction = System.Data.ParameterDirection.Input;
				FILEID_OP.OracleDbType = OracleDbType.Decimal;
				FILEID_OP.Value = FILEID;

				OracleParameter FILEID_SL_OP = new OracleParameter();
				FILEID_SL_OP.Direction = System.Data.ParameterDirection.Input;
				FILEID_SL_OP.OracleDbType = OracleDbType.Decimal;
				FILEID_SL_OP.Value = FILEID_SL_NO;


				OracleParameter Picture_OP = new OracleParameter();
				Picture_OP.Direction = System.Data.ParameterDirection.Input;
				Picture_OP.OracleDbType = OracleDbType.Blob;
				Picture_OP.Value = Picture;


				OracleParameter UPLOADBY_OP = new OracleParameter();
				UPLOADBY_OP.Direction = System.Data.ParameterDirection.Input;
				UPLOADBY_OP.OracleDbType = OracleDbType.Decimal;
				UPLOADBY_OP.Value = UPLOADBY;
							

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<ISVALID_UPLOAD>.InsertDataBySP("SP_FF_INS_UPD_VFOUS_FILE_LIST", resultOutID, ID_OP, FILEID_OP, FILEID_SL_OP, Picture_OP, UPLOADBY_OP);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<GET_VFOCUS_FILES> SP_FF_GET_VFOUS_FILE_LIST(decimal ID, decimal UPLOADID, decimal PictureSlNo)
		{
			try
			{
				

				OracleParameter ID_OP = new OracleParameter();
				ID_OP.Direction = System.Data.ParameterDirection.Input;
				ID_OP.OracleDbType = OracleDbType.Decimal;
				ID_OP.Value = ID;

				OracleParameter uploadID_OP = new OracleParameter();
				uploadID_OP.Direction = System.Data.ParameterDirection.Input;
				uploadID_OP.OracleDbType = OracleDbType.Decimal;
				uploadID_OP.Value = UPLOADID;

				OracleParameter PictureSlNo_OP = new OracleParameter();
				PictureSlNo_OP.Direction = System.Data.ParameterDirection.Input;
				PictureSlNo_OP.OracleDbType = OracleDbType.Decimal;
				PictureSlNo_OP.Value = PictureSlNo;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<GET_VFOCUS_FILES>)ObjectMakerFromOracleSP.OracleHelper<GET_VFOCUS_FILES>.GetDataBySP(new GET_VFOCUS_FILES(), "GET_VFOCUS_FILES", 2, resultOutCurSor, ID_OP, uploadID_OP, PictureSlNo_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<SP_FF_GET_CAMP_DATA> SP_FF_GET_CAMP_DATA_TEMP(decimal uploadCode)
		{
			try
			{
				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_FF_GET_CAMP_DATA>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_CAMP_DATA>.GetDataBySP(new SP_FF_GET_CAMP_DATA(), "SP_FF_GET_CAMP_DATA_TEMP", 11, resultOutCurSor, resultOutID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<SP_FF_GET_CAMP_DATA> SP_FF_GET_CAMP_DATA(decimal ID, string DD_CODE, string UPLOAD_BATCHID)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;
				
				/*OracleParameter ID_OP = new OracleParameter();
				ID_OP.Direction = System.Data.ParameterDirection.Input;
				ID_OP.OracleDbType = OracleDbType.Decimal;
				ID_OP.Value = ID;

				OracleParameter DD_CODE_OP = new OracleParameter();
				DD_CODE_OP.Direction = System.Data.ParameterDirection.Input;
				DD_CODE_OP.OracleDbType = OracleDbType.Varchar2;
				DD_CODE_OP.Value = DD_CODE;


				OracleParameter UPLOAD_BATCHID_OP = new OracleParameter();
				UPLOAD_BATCHID_OP.Direction = System.Data.ParameterDirection.Input;
				UPLOAD_BATCHID_OP.OracleDbType = OracleDbType.Date;
				UPLOAD_BATCHID_OP.Value = UPLOAD_BATCHID; */

				return (List<SP_FF_GET_CAMP_DATA>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_CAMP_DATA>.GetDataBySP(new SP_FF_GET_CAMP_DATA(), "SP_FF_GET_CAMP_DATA", 11, resultOutCurSor, resultOutID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public Decimal SP_FF_SAVE_CAMP_DATA_TEMP(decimal ID, string DD_CODE, string CAMP_NAME, Decimal TARGET, Decimal ACIEVEMENNTS, Decimal UPLOADBY, string ISACTIVE, string UPLOAD_BATCHID, string STRMODE)
		{
			try
			{

				OracleParameter ID_OP = new OracleParameter();
				ID_OP.Direction = System.Data.ParameterDirection.Input;
				ID_OP.OracleDbType = OracleDbType.Decimal;
				ID_OP.Value = ID;


				OracleParameter DD_CODE_OP = new OracleParameter();
				DD_CODE_OP.Direction = System.Data.ParameterDirection.Input;
				DD_CODE_OP.OracleDbType = OracleDbType.Varchar2;
				DD_CODE_OP.Value = DD_CODE;

				OracleParameter CAMP_NAME_OP = new OracleParameter();
				CAMP_NAME_OP.Direction = System.Data.ParameterDirection.Input;
				CAMP_NAME_OP.OracleDbType = OracleDbType.Varchar2;
				CAMP_NAME_OP.Value = CAMP_NAME;


				OracleParameter TARGET_OP = new OracleParameter();
				TARGET_OP.Direction = System.Data.ParameterDirection.Input;
				TARGET_OP.OracleDbType = OracleDbType.Decimal;
				TARGET_OP.Value = TARGET;

				OracleParameter ACIEVEMENNTS_OP = new OracleParameter();
				ACIEVEMENNTS_OP.Direction = System.Data.ParameterDirection.Input;
				ACIEVEMENNTS_OP.OracleDbType = OracleDbType.Decimal;
				ACIEVEMENNTS_OP.Value = ACIEVEMENNTS;

				OracleParameter UPLOADBY_OP = new OracleParameter();
				UPLOADBY_OP.Direction = System.Data.ParameterDirection.Input;
				UPLOADBY_OP.OracleDbType = OracleDbType.Decimal;
				UPLOADBY_OP.Value = UPLOADBY;


				OracleParameter ISACTIVE_OP = new OracleParameter();
				ISACTIVE_OP.Direction = System.Data.ParameterDirection.Input;
				ISACTIVE_OP.OracleDbType = OracleDbType.Varchar2;
				ISACTIVE_OP.Value = ISACTIVE;


				OracleParameter UPLOAD_BATCHID_OP = new OracleParameter();
				UPLOAD_BATCHID_OP.Direction = System.Data.ParameterDirection.Input;
				UPLOAD_BATCHID_OP.OracleDbType = OracleDbType.Varchar2;
				UPLOAD_BATCHID_OP.Value = UPLOAD_BATCHID;




				OracleParameter STRMODE_OP = new OracleParameter();
				STRMODE_OP.Direction = System.Data.ParameterDirection.Input;
				STRMODE_OP.OracleDbType = OracleDbType.Varchar2;
				STRMODE_OP.Value = STRMODE;


				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<ISVALID_UPLOAD>.InsertDataBySP("SP_FF_SAVE_CAMP_DATA_TEMP", resultOutID, ID_OP, DD_CODE_OP, CAMP_NAME_OP, TARGET_OP, ACIEVEMENNTS_OP, UPLOADBY_OP, ISACTIVE_OP, UPLOAD_BATCHID_OP, STRMODE_OP);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public Decimal SP_FF_SAVE_CAMP_DATA(decimal id, string uploadCode, string STRMODE)
		{
			try
			{
				OracleParameter id_OP = new OracleParameter();
				id_OP.Direction = System.Data.ParameterDirection.Input;
				id_OP.OracleDbType = OracleDbType.Decimal;
				id_OP.Value = id;

				OracleParameter uploadCode_OP = new OracleParameter();
				uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
				uploadCode_OP.OracleDbType = OracleDbType.Decimal;
				uploadCode_OP.Value = uploadCode;

				OracleParameter STRMODE_OP = new OracleParameter();
				STRMODE_OP.Direction = System.Data.ParameterDirection.Input;
				STRMODE_OP.OracleDbType = OracleDbType.Varchar2;
				STRMODE_OP.Value = STRMODE;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_CAMP_DATA>.InsertDataBySP("SP_FF_SAVE_CAMP_DATA", resultOutID, id_OP, uploadCode_OP, STRMODE_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<GET_VFOCUS_FILE_CATEGORY> GET_VFOCUS_FILE_CATEGORY(decimal ID)
		{
			try
			{

				OracleParameter ID_OP = new OracleParameter();
				ID_OP.Direction = System.Data.ParameterDirection.Input;
				ID_OP.OracleDbType = OracleDbType.Varchar2;
				ID_OP.Value = ID;

				OracleParameter errorCode = new OracleParameter();
				errorCode.Direction = System.Data.ParameterDirection.Output;
				errorCode.OracleDbType = OracleDbType.Decimal;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<GET_VFOCUS_FILE_CATEGORY>)ObjectMakerFromOracleSP.OracleHelper<GET_VFOCUS_FILE_CATEGORY>.GetDataBySP(new GET_VFOCUS_FILE_CATEGORY(), "GET_VFOCUS_FILE_CATEGORY", 2, resultOutCurSor, errorCode, ID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<GET_VFOCUS_FILE_FORMAT> GET_VFOCUS_FILE_FORMAT(decimal ID)
		{
			try
			{

				OracleParameter ID_OP = new OracleParameter();
				ID_OP.Direction = System.Data.ParameterDirection.Input;
				ID_OP.OracleDbType = OracleDbType.Varchar2;
				ID_OP.Value = ID;

				OracleParameter errorCode = new OracleParameter();
				errorCode.Direction = System.Data.ParameterDirection.Output;
				errorCode.OracleDbType = OracleDbType.Decimal;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<GET_VFOCUS_FILE_FORMAT>)ObjectMakerFromOracleSP.OracleHelper<GET_VFOCUS_FILE_FORMAT>.GetDataBySP(new GET_VFOCUS_FILE_FORMAT(), "GET_VFOCUS_FILE_FORMAT", 2, resultOutCurSor, errorCode, ID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<ISVALID_CAMP_DATA> ISVALID_CAMP_DATA(string Code, string Name)
		{
			try
			{


				OracleParameter SalaryForCode_OP = new OracleParameter();
				SalaryForCode_OP.Direction = System.Data.ParameterDirection.Input;
				SalaryForCode_OP.OracleDbType = OracleDbType.Varchar2;
				SalaryForCode_OP.Value = Code;

				OracleParameter SALAY_YEAR_MONTH_OP = new OracleParameter();
				SALAY_YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				SALAY_YEAR_MONTH_OP.OracleDbType = OracleDbType.Varchar2;
				SALAY_YEAR_MONTH_OP.Value = Name;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<ISVALID_CAMP_DATA>)ObjectMakerFromOracleSP.OracleHelper<ISVALID_CAMP_DATA>.GetDataBySP(new ISVALID_CAMP_DATA(), "SP_ISVALID_CAMP_DATA", 1, resultOutCurSor, SalaryForCode_OP, SALAY_YEAR_MONTH_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<ISVALID_DENO_TARGET> ISVALID_CAMP_DATA_DENO(string RSO_ID, string DENO_ID, string DATE1, string DATE2)
		{
			try
			{


				OracleParameter RSO_ID_OP = new OracleParameter();
				RSO_ID_OP.Direction = System.Data.ParameterDirection.Input;
				RSO_ID_OP.OracleDbType = OracleDbType.Varchar2;
				RSO_ID_OP.Value = RSO_ID;

				OracleParameter DENO_ID_OP = new OracleParameter();
				DENO_ID_OP.Direction = System.Data.ParameterDirection.Input;
				DENO_ID_OP.OracleDbType = OracleDbType.Varchar2;
				DENO_ID_OP.Value = DENO_ID;

				OracleParameter DATE1_OP = new OracleParameter();
				DATE1_OP.Direction = System.Data.ParameterDirection.Input;
				DATE1_OP.OracleDbType = OracleDbType.Varchar2;
				DATE1_OP.Value = DATE1;

				OracleParameter DATE2_OP = new OracleParameter();
				DATE2_OP.Direction = System.Data.ParameterDirection.Input;
				DATE2_OP.OracleDbType = OracleDbType.Varchar2;
				DATE2_OP.Value = DATE2;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<ISVALID_DENO_TARGET>)ObjectMakerFromOracleSP.OracleHelper<ISVALID_DENO_TARGET>.GetDataBySP(new ISVALID_DENO_TARGET(), "SP_ISVALID_DENO_TARGET", 1, resultOutCurSor, RSO_ID_OP, DENO_ID_OP, DATE1_OP, DATE2_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public List<VFOCUS_API_CALL> GET_VFOCUS_BTS_KPI_USER(decimal USERID, decimal UPLOADID)
		{
			try
			{


				OracleParameter USERID_OP = new OracleParameter();
				USERID_OP.Direction = System.Data.ParameterDirection.Input;
				USERID_OP.OracleDbType = OracleDbType.Decimal;
				USERID_OP.Value = USERID;

				OracleParameter UPLOADID_OP = new OracleParameter();
				UPLOADID_OP.Direction = System.Data.ParameterDirection.Input;
				UPLOADID_OP.OracleDbType = OracleDbType.Decimal;
				UPLOADID_OP.Value = UPLOADID;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;
							

				return (List<VFOCUS_API_CALL>)ObjectMakerFromOracleSP.OracleHelper<VFOCUS_API_CALL>.GetDataBySP(new VFOCUS_API_CALL(), "GET_VFOCUS_BTS_KPI_USER", 6, resultOutCurSor, resultOutID, USERID_OP, UPLOADID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public List<ISVALID_DD_CODE> ISVALID_DD_CODE_SALES(string Code)
		{
			try
			{


				OracleParameter DDCODE_OP = new OracleParameter();
				DDCODE_OP.Direction = System.Data.ParameterDirection.Input;
				DDCODE_OP.OracleDbType = OracleDbType.Varchar2;
				DDCODE_OP.Value = Code;

				
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<ISVALID_DD_CODE>)ObjectMakerFromOracleSP.OracleHelper<ISVALID_DD_CODE>.GetDataBySP(new ISVALID_DD_CODE(), "ISVALID_DD_CODE_SALES", 1, resultOutCurSor, DDCODE_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}












	}
}
