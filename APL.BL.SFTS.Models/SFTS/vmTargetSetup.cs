using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class vmTargetSetup
    {
        public decimal Id { get; set; }
        public String TargetItemCode { get; set; }
        public String MonthCode { get; set; }
        public DateTime SetDate { get; set; }
        public DateTime RevisionUpTo { get; set; }
        public decimal UploadCode { get; set; }
        public int TargetForId { get; set; }
        public int StaffRoleId { get; set; }
        public decimal Version { get; set; }
    }

	public class vmSalaryupload
	{
		public decimal Id { get; set; }		
		public String MonthCode { get; set; }		
		public decimal UploadCode { get; set; }

		public String UPLOAD_BATCHID { get; set; }
		public bool IsInvalidCode { get; set; }
		public string InvalidCode { get; set; }
		public string RowNo { get; set; }
		public string ColumnNo { get; set; }
		public string CampName { get; set; }
	}

}
