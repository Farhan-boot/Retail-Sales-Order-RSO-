using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace APL.BL.SFTS.DataBridgeZone
{
	public class RsoSalaryDZ
	{
		public RsoSalaryDZ()
		{

		}


		public List<SP_GET_FF_RSO_EARNING_SALARY> GetRsoSalary(decimal typeId, decimal periodID)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter typeId_OP = new OracleParameter();
				typeId_OP.Direction = System.Data.ParameterDirection.Input;
				typeId_OP.OracleDbType = OracleDbType.Decimal;
				typeId_OP.Value = typeId;

				OracleParameter periodID_OP = new OracleParameter();
				periodID_OP.Direction = System.Data.ParameterDirection.Input;
				periodID_OP.OracleDbType = OracleDbType.Decimal;
				periodID_OP.Value = periodID;

				return (List<SP_GET_FF_RSO_EARNING_SALARY>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_SALARY>.GetDataBySP(new SP_GET_FF_RSO_EARNING_SALARY(), "SP_GET_FF_RSO_EARNING_SALAY", 14, resultOutCurSor, typeId_OP, periodID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<ISVALID_SALARY_FOR> GetIsValidSalaryFor(string SalaryForCode, string SALAY_YEAR_MONTH)
		{
			try
			{


				OracleParameter SalaryForCode_OP = new OracleParameter();
				SalaryForCode_OP.Direction = System.Data.ParameterDirection.Input;
				SalaryForCode_OP.OracleDbType = OracleDbType.Varchar2;
				SalaryForCode_OP.Value = SalaryForCode;

				OracleParameter SALAY_YEAR_MONTH_OP = new OracleParameter();
				SALAY_YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				SALAY_YEAR_MONTH_OP.OracleDbType = OracleDbType.Varchar2;
				SALAY_YEAR_MONTH_OP.Value = SALAY_YEAR_MONTH;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<ISVALID_SALARY_FOR>)ObjectMakerFromOracleSP.OracleHelper<ISVALID_SALARY_FOR>.GetDataBySP(new ISVALID_SALARY_FOR(), "SP_ISVALID_SALARY_FOR", 1, resultOutCurSor, SalaryForCode_OP, SALAY_YEAR_MONTH_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public Decimal UploadRSOSalary(decimal uploadCode, string ROSCODE, string BANK_NAME, string BANK_AC, string DOB, string JOIN_DATE, decimal WORKING_DAY, string SALAY_YEAR_MONTH, decimal TOTAL_SALARY, string VENDOR, string STATUS, decimal UPLOADBY)
		{
			try
			{

				OracleParameter uploadCode_OP = new OracleParameter();
				uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
				uploadCode_OP.OracleDbType = OracleDbType.Decimal;
				uploadCode_OP.Value = uploadCode;

				OracleParameter ROSCODE_OP = new OracleParameter();
				ROSCODE_OP.Direction = System.Data.ParameterDirection.Input;
				ROSCODE_OP.OracleDbType = OracleDbType.Varchar2;
				ROSCODE_OP.Value = ROSCODE;

				OracleParameter BANK_NAME_OP = new OracleParameter();
				BANK_NAME_OP.Direction = System.Data.ParameterDirection.Input;
				BANK_NAME_OP.OracleDbType = OracleDbType.Varchar2;
				BANK_NAME_OP.Value = BANK_NAME;

				OracleParameter BANK_AC_OP = new OracleParameter();
				BANK_AC_OP.Direction = System.Data.ParameterDirection.Input;
				BANK_AC_OP.OracleDbType = OracleDbType.Varchar2;
				BANK_AC_OP.Value = BANK_AC;

				OracleParameter DOB_OP = new OracleParameter();
				DOB_OP.Direction = System.Data.ParameterDirection.Input;
				DOB_OP.OracleDbType = OracleDbType.Varchar2;
				DOB_OP.Value = DOB;

				OracleParameter JOIN_DATE_OP = new OracleParameter();
				JOIN_DATE_OP.Direction = System.Data.ParameterDirection.Input;
				JOIN_DATE_OP.OracleDbType = OracleDbType.Varchar2;
				JOIN_DATE_OP.Value = JOIN_DATE;

				OracleParameter WORKING_DAY_OP = new OracleParameter();
				WORKING_DAY_OP.Direction = System.Data.ParameterDirection.Input;
				WORKING_DAY_OP.OracleDbType = OracleDbType.Decimal;
				WORKING_DAY_OP.Value = WORKING_DAY;

				OracleParameter SALAY_YEAR_MONTH_OP = new OracleParameter();
				SALAY_YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				SALAY_YEAR_MONTH_OP.OracleDbType = OracleDbType.Varchar2;
				SALAY_YEAR_MONTH_OP.Value = SALAY_YEAR_MONTH;

				OracleParameter TOTAL_SALARY_OP = new OracleParameter();
				TOTAL_SALARY_OP.Direction = System.Data.ParameterDirection.Input;
				TOTAL_SALARY_OP.OracleDbType = OracleDbType.Decimal;
				TOTAL_SALARY_OP.Value = TOTAL_SALARY;

				OracleParameter VENDOR_OP = new OracleParameter();
				VENDOR_OP.Direction = System.Data.ParameterDirection.Input;
				VENDOR_OP.OracleDbType = OracleDbType.Varchar2;
				VENDOR_OP.Value = VENDOR;

				OracleParameter STATUS_OP = new OracleParameter();
				STATUS_OP.Direction = System.Data.ParameterDirection.Input;
				STATUS_OP.OracleDbType = OracleDbType.Varchar2;
				STATUS_OP.Value = STATUS;

				OracleParameter UPLOADBY_OP = new OracleParameter();
				UPLOADBY_OP.Direction = System.Data.ParameterDirection.Input;
				UPLOADBY_OP.OracleDbType = OracleDbType.Decimal;
				UPLOADBY_OP.Value = UPLOADBY;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<SP_GET_TERGAT_FOR_DIST>.InsertDataBySP("SP_FF_INS_SALARY_TEMP", resultOutID, uploadCode_OP, ROSCODE_OP, BANK_NAME_OP, BANK_AC_OP, DOB_OP, JOIN_DATE_OP, WORKING_DAY_OP, SALAY_YEAR_MONTH_OP, TOTAL_SALARY_OP, VENDOR_OP, STATUS_OP, UPLOADBY_OP);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<SP_GET_FF_RSO_EARNING_SALAY_FILE> GetUploadedSalaryFileDataFile(Decimal uploadCode)
		{
			try
			{
				OracleParameter uploadCode_OP = new OracleParameter();
				uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
				uploadCode_OP.OracleDbType = OracleDbType.Decimal;
				uploadCode_OP.Value = uploadCode;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_FF_RSO_EARNING_SALAY_FILE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_SALAY_FILE>.GetDataBySP(new SP_GET_FF_RSO_EARNING_SALAY_FILE(), "SP_FF_GET_SALARY_TEMP", 19, resultOutCurSor, uploadCode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public Decimal SaveUpdateSalary(decimal uploadCode)
		{
			try
			{
				OracleParameter uploadCode_OP = new OracleParameter();
				uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
				uploadCode_OP.OracleDbType = OracleDbType.Decimal;
				uploadCode_OP.Value = uploadCode;



				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_SALAY_FILE>.InsertDataBySP("SP_FF_INS_UPD_RSO_SALARY", resultOutID, uploadCode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<SP_GET_FF_RSO_EARNING_SALAY_FILE> GetSalaryData(Decimal TYPE, Decimal YEAR_MONTH)
		{
			try
			{
				OracleParameter TYPE_OP = new OracleParameter();
				TYPE_OP.Direction = System.Data.ParameterDirection.Input;
				TYPE_OP.OracleDbType = OracleDbType.Decimal;
				TYPE_OP.Value = TYPE;



				OracleParameter YEAR_MONTH_OP = new OracleParameter();
				YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				YEAR_MONTH_OP.OracleDbType = OracleDbType.Decimal;
				YEAR_MONTH_OP.Value = YEAR_MONTH;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_FF_RSO_EARNING_SALAY_FILE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_SALAY_FILE>.GetDataBySP(new SP_GET_FF_RSO_EARNING_SALAY_FILE(), "SP_GET_FF_RSO_EARNING_SALAY", 14, resultOutCurSor, TYPE_OP, YEAR_MONTH_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




	}





	public class RsoIncentiveDZ
	{
		public RsoIncentiveDZ()
		{

		}

		#region RSO Earning incentive
		public Decimal SaveUpdateIncentive(decimal uploadCode)
		{
			try
			{
				OracleParameter uploadCode_OP = new OracleParameter();
				uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
				uploadCode_OP.OracleDbType = OracleDbType.Decimal;
				uploadCode_OP.Value = uploadCode;



				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE>.InsertDataBySP("SP_FF_INS_UPD_RSO_INCENTIVE", resultOutID, uploadCode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<SP_GET_FF_RSO_EARNING_INCENTIVE> GetRsoiNCENTIVE(Decimal TYPE, Decimal YEAR_MONTH)
		{
			try
			{
				OracleParameter TYPE_OP = new OracleParameter();
				TYPE_OP.Direction = System.Data.ParameterDirection.Input;
				TYPE_OP.OracleDbType = OracleDbType.Decimal;
				TYPE_OP.Value = TYPE;



				OracleParameter YEAR_MONTH_OP = new OracleParameter();
				YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				YEAR_MONTH_OP.OracleDbType = OracleDbType.Decimal;
				YEAR_MONTH_OP.Value = YEAR_MONTH;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_FF_RSO_EARNING_INCENTIVE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_INCENTIVE>.GetDataBySP(new SP_GET_FF_RSO_EARNING_INCENTIVE(), "SP_GET_RSO_EARNING_INCENTIVE", 13, resultOutCurSor, TYPE_OP, YEAR_MONTH_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE> GetRsoiNCENTIVE_export(Decimal TYPE, Decimal YEAR_MONTH)
		{
			try
			{
				OracleParameter TYPE_OP = new OracleParameter();
				TYPE_OP.Direction = System.Data.ParameterDirection.Input;
				TYPE_OP.OracleDbType = OracleDbType.Decimal;
				TYPE_OP.Value = TYPE;



				OracleParameter YEAR_MONTH_OP = new OracleParameter();
				YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				YEAR_MONTH_OP.OracleDbType = OracleDbType.Decimal;
				YEAR_MONTH_OP.Value = YEAR_MONTH;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE>.GetDataBySP(new SP_GET_FF_RSO_EARNING_INCENTIVE_FILE(), "SP_GET_RSO_EARNING_INCENTIVE", 13, resultOutCurSor, TYPE_OP, YEAR_MONTH_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public Decimal UploadRSOIncentive(decimal uploadCode, string ROSCODE,  string SALAY_YEAR_MONTH, string TYPE, decimal INCENTIVE, string REMARKS, decimal UPLOADBY)
		{
			try
			{

				OracleParameter uploadCode_OP = new OracleParameter();
				uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
				uploadCode_OP.OracleDbType = OracleDbType.Decimal;
				uploadCode_OP.Value = uploadCode;

				OracleParameter ROSCODE_OP = new OracleParameter();
				ROSCODE_OP.Direction = System.Data.ParameterDirection.Input;
				ROSCODE_OP.OracleDbType = OracleDbType.Varchar2;
				ROSCODE_OP.Value = ROSCODE;

				
				OracleParameter SALAY_YEAR_MONTH_OP = new OracleParameter();
				SALAY_YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				SALAY_YEAR_MONTH_OP.OracleDbType = OracleDbType.Varchar2;
				SALAY_YEAR_MONTH_OP.Value = SALAY_YEAR_MONTH;

				OracleParameter TYPE_OP = new OracleParameter();
				TYPE_OP.Direction = System.Data.ParameterDirection.Input;
				TYPE_OP.OracleDbType = OracleDbType.Varchar2;
				TYPE_OP.Value = TYPE;

				OracleParameter INCENTIVE_OP = new OracleParameter();
				INCENTIVE_OP.Direction = System.Data.ParameterDirection.Input;
				INCENTIVE_OP.OracleDbType = OracleDbType.Decimal;
				INCENTIVE_OP.Value = INCENTIVE;
				
				OracleParameter REMARKS_OP = new OracleParameter();
				REMARKS_OP.Direction = System.Data.ParameterDirection.Input;
				REMARKS_OP.OracleDbType = OracleDbType.Varchar2;
				REMARKS_OP.Value = REMARKS;

				OracleParameter UPLOADBY_OP = new OracleParameter();
				UPLOADBY_OP.Direction = System.Data.ParameterDirection.Input;
				UPLOADBY_OP.OracleDbType = OracleDbType.Decimal;
				UPLOADBY_OP.Value = UPLOADBY;

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_INCENTIVE>.InsertDataBySP("SP_FF_INS_INCENTIVE_TEMP", resultOutID, uploadCode_OP, ROSCODE_OP, SALAY_YEAR_MONTH_OP, TYPE_OP, INCENTIVE_OP, REMARKS_OP, UPLOADBY_OP);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE> GetUploadedSalaryFileDataFile(Decimal uploadCode)
		{
			try
			{
				OracleParameter uploadCode_OP = new OracleParameter();
				uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
				uploadCode_OP.OracleDbType = OracleDbType.Decimal;
				uploadCode_OP.Value = uploadCode;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE>.GetDataBySP(new SP_GET_FF_RSO_EARNING_INCENTIVE_FILE(), "SP_FF_GET_INCENTIVE_TEMP", 19, resultOutCurSor, uploadCode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<ISVALID_SALARY_FOR> GetIsValidIncentiveFor(string SalaryForCode, string SALAY_YEAR_MONTH)
		{
			try
			{


				OracleParameter SalaryForCode_OP = new OracleParameter();
				SalaryForCode_OP.Direction = System.Data.ParameterDirection.Input;
				SalaryForCode_OP.OracleDbType = OracleDbType.Varchar2;
				SalaryForCode_OP.Value = SalaryForCode;

				OracleParameter SALAY_YEAR_MONTH_OP = new OracleParameter();
				SALAY_YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				SALAY_YEAR_MONTH_OP.OracleDbType = OracleDbType.Varchar2;
				SALAY_YEAR_MONTH_OP.Value = SALAY_YEAR_MONTH;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<ISVALID_SALARY_FOR>)ObjectMakerFromOracleSP.OracleHelper<ISVALID_SALARY_FOR>.GetDataBySP(new ISVALID_SALARY_FOR(), "SP_ISVALID_INCENTIVE_FOR", 1, resultOutCurSor, SalaryForCode_OP, SALAY_YEAR_MONTH_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion
	}



	public class RsoCommissionDZ
	{
		public RsoCommissionDZ()
		{

		}

		#region RSO Earning incentive
		public Decimal SaveUpdateCommission(decimal uploadCode)
		{
			try
			{
				OracleParameter uploadCode_OP = new OracleParameter();
				uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
				uploadCode_OP.OracleDbType = OracleDbType.Decimal;
				uploadCode_OP.Value = uploadCode;
				

				OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_COMMISSION_FILE>.InsertDataBySP("SP_FF_INS_UPD_RSO_COMMISSION", resultOutID, uploadCode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


	
		public List<SP_GET_FF_RSO_EARNING_COMMISSION> GetRsoCOMMISSION(Decimal TYPE, Decimal YEAR_MONTH)
		{
			try
			{
				OracleParameter TYPE_OP = new OracleParameter();
				TYPE_OP.Direction = System.Data.ParameterDirection.Input;
				TYPE_OP.OracleDbType = OracleDbType.Decimal;
				TYPE_OP.Value = TYPE;



				OracleParameter YEAR_MONTH_OP = new OracleParameter();
				YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				YEAR_MONTH_OP.OracleDbType = OracleDbType.Decimal;
				YEAR_MONTH_OP.Value = YEAR_MONTH;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_FF_RSO_EARNING_COMMISSION>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_COMMISSION>.GetDataBySP(new SP_GET_FF_RSO_EARNING_COMMISSION(), "SP_GET_RSO_EARNING_COMMISSION", 15, resultOutCurSor, TYPE_OP, YEAR_MONTH_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	
	public List<SP_GET_FF_RSO_EARNING_COMMISSION_FILE> GetRsoCOMMISSION_export(Decimal TYPE, Decimal YEAR_MONTH)
	{
		try
		{
			OracleParameter TYPE_OP = new OracleParameter();
			TYPE_OP.Direction = System.Data.ParameterDirection.Input;
			TYPE_OP.OracleDbType = OracleDbType.Decimal;
			TYPE_OP.Value = TYPE;



			OracleParameter YEAR_MONTH_OP = new OracleParameter();
			YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
			YEAR_MONTH_OP.OracleDbType = OracleDbType.Decimal;
			YEAR_MONTH_OP.Value = YEAR_MONTH;

			OracleParameter resultOutCurSor = new OracleParameter();
			resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
			resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

			return (List<SP_GET_FF_RSO_EARNING_COMMISSION_FILE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_COMMISSION_FILE>.GetDataBySP(new SP_GET_FF_RSO_EARNING_COMMISSION_FILE(), "SP_GET_RSO_EARNING_COMMISSION", 15, resultOutCurSor, TYPE_OP, YEAR_MONTH_OP);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

		
		public Decimal UploadRSOCommission(decimal uploadCode, string ROSCODE, decimal TARGET, decimal ACHIEVEMENT, decimal INCENTIVE, string CAMPING_YEAR_MONTH, string CAMPING_NAME, string KPI, string BANK_NAME, string BANK_AC, string VENDOR, string STATUS, decimal UPLOADBY)
		{
			try
			{

				OracleParameter uploadCode_OP = new OracleParameter();
				uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
				uploadCode_OP.OracleDbType = OracleDbType.Decimal;
				uploadCode_OP.Value = uploadCode;

				OracleParameter ROSCODE_OP = new OracleParameter();
				ROSCODE_OP.Direction = System.Data.ParameterDirection.Input;
				ROSCODE_OP.OracleDbType = OracleDbType.Varchar2;
				ROSCODE_OP.Value = ROSCODE;

				OracleParameter TARGET_OP = new OracleParameter();
				TARGET_OP.Direction = System.Data.ParameterDirection.Input;
				TARGET_OP.OracleDbType = OracleDbType.Decimal;
				TARGET_OP.Value = TARGET;

				OracleParameter ACHIEVEMENT_OP = new OracleParameter();
				ACHIEVEMENT_OP.Direction = System.Data.ParameterDirection.Input;
				ACHIEVEMENT_OP.OracleDbType = OracleDbType.Decimal;
				ACHIEVEMENT_OP.Value = ACHIEVEMENT; 

				 OracleParameter INCENTIVE_OP = new OracleParameter();
				INCENTIVE_OP.Direction = System.Data.ParameterDirection.Input;
				INCENTIVE_OP.OracleDbType = OracleDbType.Decimal;
				INCENTIVE_OP.Value = INCENTIVE;

				OracleParameter SALAY_YEAR_MONTH_OP = new OracleParameter();
				SALAY_YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				SALAY_YEAR_MONTH_OP.OracleDbType = OracleDbType.Varchar2;
				SALAY_YEAR_MONTH_OP.Value = CAMPING_YEAR_MONTH;

				OracleParameter CAMPING_NAME_OP = new OracleParameter();
				CAMPING_NAME_OP.Direction = System.Data.ParameterDirection.Input;
				CAMPING_NAME_OP.OracleDbType = OracleDbType.Varchar2;
				CAMPING_NAME_OP.Value = CAMPING_NAME;
				

				OracleParameter KPI_OP = new OracleParameter();
				KPI_OP.Direction = System.Data.ParameterDirection.Input;
				KPI_OP.OracleDbType = OracleDbType.Varchar2;
				KPI_OP.Value = KPI;

				OracleParameter BANK_NAME_OP = new OracleParameter();
				BANK_NAME_OP.Direction = System.Data.ParameterDirection.Input;
				BANK_NAME_OP.OracleDbType = OracleDbType.Varchar2;
				BANK_NAME_OP.Value = BANK_NAME;

				OracleParameter BANK_AC_OP = new OracleParameter();
				BANK_AC_OP.Direction = System.Data.ParameterDirection.Input;
				BANK_AC_OP.OracleDbType = OracleDbType.Varchar2;
				BANK_AC_OP.Value = BANK_AC;

				OracleParameter VENDOR_OP = new OracleParameter();
				VENDOR_OP.Direction = System.Data.ParameterDirection.Input;
				VENDOR_OP.OracleDbType = OracleDbType.Varchar2;
				VENDOR_OP.Value = VENDOR;

				OracleParameter STATUS_OP = new OracleParameter();
				STATUS_OP.Direction = System.Data.ParameterDirection.Input;
				STATUS_OP.OracleDbType = OracleDbType.Varchar2;
				STATUS_OP.Value = STATUS;

				OracleParameter UPLOADBY_OP = new OracleParameter();
				UPLOADBY_OP.Direction = System.Data.ParameterDirection.Input;
				UPLOADBY_OP.OracleDbType = OracleDbType.Decimal;
				UPLOADBY_OP.Value = UPLOADBY;
							

				 OracleParameter resultOutID = new OracleParameter();
				resultOutID.Direction = System.Data.ParameterDirection.Output;
				resultOutID.OracleDbType = OracleDbType.Decimal;

				return ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_COMMISSION>.InsertDataBySP("SP_FF_INS_RSO_COMMISSION_TEMP", resultOutID, uploadCode_OP, ROSCODE_OP, TARGET_OP, ACHIEVEMENT_OP, INCENTIVE_OP, SALAY_YEAR_MONTH_OP, CAMPING_NAME_OP, KPI_OP, BANK_NAME_OP, BANK_AC_OP
					, VENDOR_OP, STATUS_OP, UPLOADBY_OP);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


	
		
		public List<SP_GET_FF_RSO_EARNING_COMMISSION_FILE> GetUploadedCommissionFileDataFile(Decimal uploadCode)
		{
			try
			{
				OracleParameter uploadCode_OP = new OracleParameter();
				uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
				uploadCode_OP.OracleDbType = OracleDbType.Decimal;
				uploadCode_OP.Value = uploadCode;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_FF_RSO_EARNING_COMMISSION_FILE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING_COMMISSION_FILE>.GetDataBySP(new SP_GET_FF_RSO_EARNING_COMMISSION_FILE(), "SP_FF_GET_RSO_COMMISSION_TEMP", 15, resultOutCurSor, uploadCode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<ISVALID_SALARY_FOR> GetIsValidCommissionFOR(string SalaryForCode, string SALAY_YEAR_MONTH)
		{
			try
			{


				OracleParameter SalaryForCode_OP = new OracleParameter();
				SalaryForCode_OP.Direction = System.Data.ParameterDirection.Input;
				SalaryForCode_OP.OracleDbType = OracleDbType.Varchar2;
				SalaryForCode_OP.Value = SalaryForCode;

				OracleParameter SALAY_YEAR_MONTH_OP = new OracleParameter();
				SALAY_YEAR_MONTH_OP.Direction = System.Data.ParameterDirection.Input;
				SALAY_YEAR_MONTH_OP.OracleDbType = OracleDbType.Varchar2;
				SALAY_YEAR_MONTH_OP.Value = SALAY_YEAR_MONTH;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<ISVALID_SALARY_FOR>)ObjectMakerFromOracleSP.OracleHelper<ISVALID_SALARY_FOR>.GetDataBySP(new ISVALID_SALARY_FOR(), "SP_ISVALID_COMMISSION_FOR", 1, resultOutCurSor, SalaryForCode_OP, SALAY_YEAR_MONTH_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion
	}



}
