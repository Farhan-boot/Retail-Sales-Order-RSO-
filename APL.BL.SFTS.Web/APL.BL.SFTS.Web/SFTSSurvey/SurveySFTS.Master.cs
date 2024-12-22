using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APL.BL.SFTS.Web.SFTSSurvey
{
    public partial class SurveySFTS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MenuItem menuItem94 = new MenuItem();
                menuItem94.Value = "4";
                menuItem94.Text = "Client Survey";
                menuItem94.NavigateUrl = "/SFTSSurvey/SurveyResultReceive.aspx";
                Menu1.Items.Add(menuItem94);
            }
        }


        private void PopulateMenu()
        {
            #region  Basic Setup
            MenuItem menuItem10 = new MenuItem();
            menuItem10.Value = "1";
            menuItem10.Text = "Setup";
            menuItem10.NavigateUrl = "";

            MenuItem menuItem11 = new MenuItem();
            menuItem11.Value = "2";
            menuItem11.Text = "Event";
            menuItem11.NavigateUrl = "~/ForSFTS/EventInfoWF.aspx";

            MenuItem menuItem12 = new MenuItem();
            menuItem12.Value = "2";
            menuItem12.Text = "Commission";
            menuItem12.NavigateUrl = "~/ForSFTS/CommissionInfoWF.aspx";

            menuItem10.ChildItems.Add(menuItem11);
            menuItem10.ChildItems.Add(menuItem12);

            Menu1.Items.Add(menuItem10);

            #endregion  Basic Setup

            MenuItem menuItem20 = new MenuItem();
            menuItem20.Value = "2";
            menuItem20.Text = "Ticker Message";
            menuItem20.NavigateUrl = "~/ForSFTS/TickerMessageWF.aspx";
            Menu1.Items.Add(menuItem20);


            MenuItem menuItem30 = new MenuItem();
            menuItem30.Value = "2";
            menuItem30.Text = "Current Offer";
            menuItem30.NavigateUrl = "~/ForSFTS/CurrentOfferWF.aspx";

            Menu1.Items.Add(menuItem30);

            #region  Retailer

            MenuItem menuItem40 = new MenuItem();
            menuItem40.Value = "2";
            menuItem40.Text = "Retailer";
            menuItem40.NavigateUrl = "";

            MenuItem menuItem41 = new MenuItem();
            menuItem41.Value = "2";
            menuItem41.Text = "Retailer GPS";
            menuItem41.NavigateUrl = "~/ForSFTS/RetailerGPSLocWF.aspx";

            MenuItem menuItem42 = new MenuItem();
            menuItem42.Value = "2";
            menuItem42.Text = "New Retailer Info";
            menuItem42.NavigateUrl = "~/ForSFTS/IssueNewRetailerInfoWF.aspx";

            menuItem40.ChildItems.Add(menuItem41);
            menuItem40.ChildItems.Add(menuItem42);
            Menu1.Items.Add(menuItem40);

            #endregion  Retailer

            MenuItem menuItem50 = new MenuItem();
            menuItem50.Value = "2";
            menuItem50.Text = "Market Update Gallery";
            menuItem50.NavigateUrl = "~/ForSFTS/MarketUpdateGalleryWF.aspx";
            Menu1.Items.Add(menuItem50);

            MenuItem menuItem60 = new MenuItem();
            menuItem60.Value = "2";
            menuItem60.Text = "Target";
            menuItem60.NavigateUrl = "";

            MenuItem menuItem61 = new MenuItem();
            menuItem61.Value = "2";
            menuItem61.Text = "Target Setup";
            menuItem61.NavigateUrl = "~/ForSFTS/TargetSetupWP.aspx";
            menuItem60.ChildItems.Add(menuItem61); //

            MenuItem menuItem62 = new MenuItem();
            menuItem62.Value = "2";
            menuItem62.Text = "Gross Budget";
            menuItem62.NavigateUrl = "~/ForSFTS/GrossBudget.aspx";
            menuItem60.ChildItems.Add(menuItem62); //

            MenuItem menuItem63 = new MenuItem();
            menuItem63.Value = "2";
            menuItem63.Text = "Distributor Target";
            menuItem63.NavigateUrl = "~/ForSFTS/DistributorBudgetWF.aspx";
            menuItem60.ChildItems.Add(menuItem63);

            MenuItem menuItem64 = new MenuItem();
            menuItem64.Value = "2";
            menuItem64.Text = "Retailer Target";
            menuItem64.NavigateUrl = "~/ForSFTS/RetailerBudgetWF.aspx";
            menuItem60.ChildItems.Add(menuItem64);

            Menu1.Items.Add(menuItem60);

            MenuItem menuItem71 = new MenuItem();
            menuItem71.Value = "2";
            menuItem71.Text = "Notification";
            menuItem71.NavigateUrl = "~/ForSFTS/RSO_InboxWF.aspx";

            Menu1.Items.Add(menuItem71);

            MenuItem menuItem81 = new MenuItem();
            menuItem81.Value = "2";
            menuItem81.Text = "RSO Monitoring";
            menuItem81.NavigateUrl = "~/ForSFTS/RsoMonitoringWF.aspx";

            Menu1.Items.Add(menuItem81);

            #region  Servey

            MenuItem menuItem90 = new MenuItem();
            menuItem90.Value = "1";
            menuItem90.Text = "Servey";
            menuItem90.NavigateUrl = ""; //

            MenuItem menuItem91 = new MenuItem();
            menuItem91.Value = "2";
            menuItem91.Text = "New Survey";
            menuItem91.NavigateUrl = "~/ForSFTS/SurveyTitleWF.aspx";

            MenuItem menuItem92 = new MenuItem();
            menuItem92.Value = "2";
            menuItem92.Text = "Survey Q&A";
            menuItem92.NavigateUrl = "~/ForSFTS/SurveyWithQuestionAndAnswerWF.aspx";

            MenuItem menuItem93 = new MenuItem();
            menuItem93.Value = "3";
            menuItem93.Text = "Servey List";
            menuItem93.NavigateUrl = "~/ForSFTS/SurveyListWF.aspx";

            MenuItem menuItem94 = new MenuItem();
            menuItem94.Value = "4";
            menuItem94.Text = "Client Survey";
            menuItem94.NavigateUrl = "/SFTSSurvey/SurveyResultReceive.aspx";

            MenuItem menuItem95 = new MenuItem();
            menuItem95.Value = "5";
            menuItem95.Text = "Result Receive Processing";
            menuItem95.NavigateUrl = "~/ForSFTS/SurveyResultReceiveProcessingWF.aspx"; //~/ForSFTS/SurveyResultReceiveProcessingWF.aspx">Result Receive Processing

            menuItem90.ChildItems.Add(menuItem91);
            menuItem90.ChildItems.Add(menuItem92);
            menuItem90.ChildItems.Add(menuItem93);
            menuItem90.ChildItems.Add(menuItem94);
            menuItem90.ChildItems.Add(menuItem95);

            Menu1.Items.Add(menuItem90);

            #endregion  Servey

        }
    }
}