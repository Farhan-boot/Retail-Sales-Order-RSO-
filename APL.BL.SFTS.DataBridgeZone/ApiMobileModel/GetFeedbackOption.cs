﻿using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
   public class GetFeedbackOption
    {
       public List<SP_GET_FEEDBACK_OPTION> data { get; set; }
       public int status_code { get; set; }
    }
}