using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class vmFeedbackQuestion
    {
        public Decimal FeedbackQuestionId { get; set; }

        public Decimal QuestionnaireId { get; set; }

        public String QuestionText { get; set; }
        
        public Decimal CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public Decimal DisplayOrder { get; set; }
    }
}
