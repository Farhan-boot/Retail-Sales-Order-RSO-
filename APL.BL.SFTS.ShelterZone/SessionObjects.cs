using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using CrystalDecisions.CrystalReports.Engine;

namespace APL.BL.SFTS.ShelterZone
{
    public class SessionObjects : System.Web.UI.Page
    {
        //public string ConnectionString { get; set; }

        public string LoginID { get; set; }

        public SessionObjects()
        {
            //Init_ConnectionString();
            //Init_DATAAREAID();
            //Init_LoginID();
        }



        public void Init_Meghna_LoginID(string _LoginID)
        {
            //this.ConnectionString = _ConnectionString;
            //Init_ConnectionString();

            this.Session["USERIID"] = _LoginID;
            Init_LoginID();
        }

        public void Init_Meghna_LoginID()
        {

            Init_LoginID();
        }




        public void Init_LoginID()
        {
            if (Session["USERIID"] != null)
            {
                this.LoginID = (string)Session["USERIID"].ToString();
            }
            else
            {
                this.LoginID = "User";
            }
        }
    }
}
