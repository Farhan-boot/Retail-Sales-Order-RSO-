using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class FeedbackQuestionAnswer
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public int Rating { get; set; }
        public string Obserbation { get; set; }
        public string ActionPoint { get; set; }
    }
}
