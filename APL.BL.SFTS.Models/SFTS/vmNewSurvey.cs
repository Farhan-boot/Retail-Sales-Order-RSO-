using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class vmNewSurvey
    {
        public Decimal SurveyId { get; set; }

        public decimal DistributorId { get; set; }

        public string RouteId { get; set; }

        public String SurveyTitle { get; set; }

        public String Description { get; set; }

        public decimal StatusId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

		public decimal SURVEY_FOR { get; set; }

	}
}
