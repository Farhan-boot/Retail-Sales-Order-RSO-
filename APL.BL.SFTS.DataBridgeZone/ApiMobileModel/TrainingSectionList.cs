﻿using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class TrainingSectionList
    {
        public List<SP_FF_TRAINING_SECTION_LIST> data { get; set; }
        public int status_code { get; set; }
    }
}