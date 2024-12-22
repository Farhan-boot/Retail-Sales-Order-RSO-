using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.Vfocus;
using APL.BL.SFTS.Models.VFOCUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.VFocus
{
	public class B2C_UPLOAD_FILEPZ
	{

		public List<GET_B2CSCAPPTARGETPROCESS> GET_B2CSCAPPTARGETPROCESS()
		{
			try
			{
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().GET_B2CSCAPPTARGETPROCESS();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<ISVALID_DD_CODE> ISVALID_DD_CODE_SALES(string UserCode)
		{
			try
			{
				return new B2C_UPLOAD_FILEDZ().ISVALID_DD_CODE_SALES(UserCode);
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
				return new B2C_UPLOAD_FILEDZ().SAVE_SALESTARGET_UPLOAD_TEMP(TARGET_DATE, REGION, DD_CODE, DD_NAME, RP_SIM, RP_EV, GA,  DS_EV,  DS_SC,  TOTAL_DS,  RECH_SC,  RECH_EV,  TOTAL_RECH, STRMODE);
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
				return new B2C_UPLOAD_FILEDZ().SAVE_B2CSCAPPTARGETPROCESS();
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
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().GET_VFOCUS_DENO_TARGET_TEMP(RSO_ID, DENO_ID);
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
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().GET_VFOCUS_DENO_TARGET(RSO_ID, DENO_ID);
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
				return new B2C_UPLOAD_FILEDZ().SAVE_VFOCUS_DENO_TARGET_TEMP(RSO_ID, DENO_ID, TARGET_COUNT, DENO_AMOUNT, DATE1, DATE2, UPLOADBY, STRMODE);
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
				return new B2C_UPLOAD_FILEDZ().SAVE_VFOCUS_DENO_TARGET(STRMODE);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<SP_FF_GET_FILE_UPLOAD_INFO> SP_FF_GET_FILE_UPLOAD_INFO(decimal uploadID, Decimal CATID, Decimal FORMATID)
		{
			try
			{
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().SP_FF_GET_FILE_UPLOAD_INFO(uploadID, CATID,  FORMATID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public decimal SaveUpdateOfferPictures(decimal ID, Decimal FILEID, Decimal FILEID_SL_NO, byte[] Picture, Decimal UPLOADBY)
		{
			try
			{
				return new B2C_UPLOAD_FILEDZ().SP_FF_INS_UPD_VFOUS_FILE_LIST(ID, FILEID, FILEID_SL_NO,  Picture, UPLOADBY);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<GET_VFOCUS_FILES> SP_FF_GET_VFOUS_FILE_LIST(decimal fileID, decimal uploadID, decimal PictureSlNo)
		{
			try
			{
				return new B2C_UPLOAD_FILEDZ().SP_FF_GET_VFOUS_FILE_LIST(fileID, uploadID, PictureSlNo);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public Decimal SP_FF_SAVE_FILE_UPLOAD(decimal fileID, string FILE_NAME, string FILE_INFO, Decimal FILE_CATEGORY, Decimal FILE_FORMAT, string LINK, string ISACTIVE, Decimal UPLOADBY, string STRMODE)
		{
			try
			{
				return new B2C_UPLOAD_FILEDZ().SP_FF_SAVE_FILE_UPLOAD(fileID, FILE_NAME, FILE_INFO, FILE_CATEGORY, FILE_FORMAT, LINK, ISACTIVE, UPLOADBY, STRMODE);
				
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
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().SP_FF_GET_CAMP_DATA_TEMP(uploadCode);
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
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().SP_FF_GET_CAMP_DATA( ID,  DD_CODE,  UPLOAD_BATCHID);
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
				return new B2C_UPLOAD_FILEDZ().SP_FF_SAVE_CAMP_DATA_TEMP(ID, DD_CODE, CAMP_NAME, TARGET, ACIEVEMENNTS, UPLOADBY, ISACTIVE, UPLOAD_BATCHID, STRMODE);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public Decimal SP_FF_SAVE_CAMP_DATA(decimal ID, string UPLOAD_BATCHID, string STRMODE)
		{
			try
			{
				return new B2C_UPLOAD_FILEDZ().SP_FF_SAVE_CAMP_DATA(ID, UPLOAD_BATCHID, STRMODE);
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
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().GET_VFOCUS_FILE_CATEGORY(ID);
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
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().GET_VFOCUS_FILE_FORMAT(ID);
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
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().ISVALID_CAMP_DATA(Code, Name);
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
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().ISVALID_CAMP_DATA_DENO(RSO_ID, DENO_ID, DATE1, DATE2);
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
				// return new GraphInfoDZ().GetAllGraphInfoList(graphId, graphName, graphCode).OrderBy(sur => sur.GRAPH_ID).ToList();
				return new B2C_UPLOAD_FILEDZ().GET_VFOCUS_BTS_KPI_USER(USERID, UPLOADID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



	}
}
