using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class GetFeedbackQuestion
    {
      public long VisitId { get; set; }
      public long RetailerId { get; set; }
      public long QuestionnaireId { get; set; }
      public long QuestionId { get; set; }
    }
}
