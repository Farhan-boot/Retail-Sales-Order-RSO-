using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
	public class RetailerCheckin
	{
		public decimal PlanId { get; set; }
		public decimal RetailerId { get; set; }
		public decimal CreatedBy { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public decimal AreaId { get; set; }
	}
}
