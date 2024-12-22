using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.VFOCUS
{
	public class Camp_data_upload
	{
		public bool IsInvalidCode { get; set; }
		public string InvalidCode { get; set; }
		public string RowNo { get; set; }
		public string ColumnNo { get; set; }
		public string CampName { get; set; }
	}

	public class vmVFOCUS_UPLOAD
	{
		public decimal Id { get; set; }
		public String UPLOAD_BATCHID { get; set; }
		public String UploadCode { get; set; }

		public bool IsInvalidCode { get; set; }
		public string InvalidCode { get; set; }
		public string RowNo { get; set; }
		public string ColumnNo { get; set; }
		public string CampName { get; set; }

	}

	


}
