using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class vmSurveyQuestion
    {
        public decimal AnswerId { get; set; }

        public Decimal SurveyQuestionId { get; set; }

        public Decimal SurveyId { get; set; }

        public String Question { get; set; }

        public String Note { get; set; }

        public decimal QuestionId { get; set; }

        public String Answer { get; set; }
    }
}
