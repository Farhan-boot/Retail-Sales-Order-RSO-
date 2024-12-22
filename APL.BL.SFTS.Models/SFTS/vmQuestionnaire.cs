using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class vmQuestionnaire
    {
        public Decimal QuestionnaireId { get; set; }

        public Decimal VisitEntityType { get; set; }

        public Decimal CenterTypeId { get; set; }

        public Decimal CreatedBy { get; set; }

        public Decimal VisitTypeId { get; set; }

        public bool IsActive { get; set; }      
    }
}
