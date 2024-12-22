using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APL.BL.SFTS.DataBridgeZone;

namespace APL.BL.SFTS.ProcessZone
{
	public class RsoSalaryPZ
	{
		public RsoSalaryPZ()
		{
		}


		public List<SP_GET_FF_RSO_EARNING_SALARY> GetRsoSalary(decimal typeId, decimal periodID)
		{
			try
			{
				return new RsoSalaryDZ().GetRsoSalary(typeId, periodID);
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
				return new RsoSalaryDZ().GetIsValidSalaryFor(SalaryForCode, SALAY_YEAR_MONTH);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public decimal UploadRSOSalary(decimal uploadCode, string ROSCODE, string BANK_NAME, string BANK_AC, string DOB, string JOIN_DATE, decimal WORKING_DAY, string SALAY_YEAR_MONTH, decimal TOTAL_SALARY, string VENDOR, string STATUS, decimal UPLOADBY)
		{
			try
			{
				return new RsoSalaryDZ().UploadRSOSalary(uploadCode, ROSCODE, BANK_NAME, BANK_AC, DOB, JOIN_DATE, WORKING_DAY, SALAY_YEAR_MONTH, TOTAL_SALARY, VENDOR, STATUS, UPLOADBY);
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
				return new RsoSalaryDZ().GetUploadedSalaryFileDataFile(uploadCode);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public decimal SaveUpdateSalary(decimal uploadCode)
		{
			try
			{
				return new RsoSalaryDZ().SaveUpdateSalary(uploadCode);
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
				return new RsoSalaryDZ().GetSalaryData(TYPE, YEAR_MONTH);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


	}

	public class RsoIncentivePZ
	{
		public RsoIncentivePZ()
		{
		}


		public List<SP_GET_FF_RSO_EARNING_INCENTIVE> GetRsoiNCENTIVE(Decimal TYPE, Decimal YEAR_MONTH)
		{
			try
			{
				return new RsoIncentiveDZ().GetRsoiNCENTIVE(TYPE, YEAR_MONTH);
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
				return new RsoIncentiveDZ().GetRsoiNCENTIVE_export(TYPE, YEAR_MONTH);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public decimal UploadRSOIncentive(decimal uploadCode, string ROSCODE, string SALAY_YEAR_MONTH, string TYPE, decimal INCENTIVE, string REMARKS, decimal UPLOADBY)
		{
			try
			{
				return new RsoIncentiveDZ().UploadRSOIncentive(uploadCode, ROSCODE, SALAY_YEAR_MONTH, TYPE, INCENTIVE, REMARKS, UPLOADBY);

				//decimal uploadCode, string ROSCODE,  string SALAY_YEAR_MONTH, string TYPE, decimal INCENTIVE, string REMARKS, decimal UPLOADBY
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
				return new RsoIncentiveDZ().GetUploadedSalaryFileDataFile(uploadCode);
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
				return new RsoIncentiveDZ().GetIsValidIncentiveFor(SalaryForCode, SALAY_YEAR_MONTH);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


	}



	public class RsoCommissionPZ
	{
		public RsoCommissionPZ()
		{
		}

		public decimal SaveUpdateSalary(decimal uploadCode)
		{
			try
			{
				return new RsoCommissionDZ().SaveUpdateCommission(uploadCode);
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
				return new RsoCommissionDZ().GetRsoCOMMISSION(TYPE, YEAR_MONTH);
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
				return new RsoCommissionDZ().GetRsoCOMMISSION_export(TYPE, YEAR_MONTH);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	

		public decimal UploadRSOCommission(decimal uploadCode, string ROSCODE, decimal TARGET, decimal ACHIEVEMENT, decimal INCENTIVE, string CAMPING_YEAR_MONTH, string CAMPING_NAME, string KPI, string BANK_NAME, string BANK_AC, string VENDOR, string STATUS, decimal UPLOADBY)
		{
			try
			{
				return new RsoCommissionDZ().UploadRSOCommission( uploadCode,  ROSCODE,  TARGET,  ACHIEVEMENT,  INCENTIVE,  CAMPING_YEAR_MONTH,  CAMPING_NAME,  KPI,  BANK_NAME,  BANK_AC,  VENDOR,  STATUS,  UPLOADBY);

				//decimal uploadCode, string ROSCODE,  string SALAY_YEAR_MONTH, string TYPE, decimal INCENTIVE, string REMARKS, decimal UPLOADBY
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
			return new RsoCommissionDZ().GetUploadedCommissionFileDataFile(uploadCode);
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
				return new RsoCommissionDZ().GetIsValidCommissionFOR(SalaryForCode, SALAY_YEAR_MONTH);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		

	}

}
