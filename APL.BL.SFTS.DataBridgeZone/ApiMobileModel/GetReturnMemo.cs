﻿using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
   public class GetReturnMemo
    { 
       public List<SP_FF_GET_RETURN_MEMO> data { get; set; }
       public int status_code { get; set; }
    }
}