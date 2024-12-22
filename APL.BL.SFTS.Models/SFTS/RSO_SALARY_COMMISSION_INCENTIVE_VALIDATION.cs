using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
	public class RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION
	{
		public bool IsInvalidCode { get; set; }
		public string InvalidCode { get; set; }
		public string RowNo { get; set; }
		public string ColumnNo { get; set; }
		public string SalayName { get; set; }
	}
}
