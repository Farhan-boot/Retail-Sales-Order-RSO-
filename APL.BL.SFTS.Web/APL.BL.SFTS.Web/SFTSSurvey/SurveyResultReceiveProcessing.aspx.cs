using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ProcessZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APL.BL.SFTS.Web.SFTSSurvey
{
    public partial class SurveyResultReceiveProcessing : System.Web.UI.Page
    {
        int _currentSurveyPage = 0;
        decimal _surveyListID = 0;
        decimal _distributorID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillNewSurveyList(0, 0);
                PopulateDistributor();
                PopulateRSO();
                //loadSurveyResultDeatils(surveyListID, 0, rsoID);
            }
        }

        private void loadSurveyResultDeatils(decimal surveyListID, decimal distributorID, decimal rsoID)
        {
            try
            {
                lblRsoResult.Text = string.Empty;
                List<SP_GET_SURVEYANSWER_LISTcls> surAnswerList = new SurveyPZ().GetAllSurveyAnswerList(surveyListID, 0);

                var surveyAnalysis = new SurveyPZ().GetSurveyAnalysisAns(surveyListID, distributorID, rsoID, "");

                List<SP_GET_SURVEYANALYSYS_ANScls> surveyAnalysisDisplay = new List<SP_GET_SURVEYANALYSYS_ANScls>();


                if (surveyAnalysis != null && surveyAnalysis.Count > 0)
                {
                    //lblTotalRSO.Text
                    foreach (var surAnalysis in surveyAnalysis)
                    {
                        foreach (var SurAns in surAnswerList)
                        {
                            if (surAnalysis.SURVEYLIST_ID == surveyListID && SurAns.SURVEY_DETAIL_QID == surAnalysis.SURVEYDETAIL_QID && SurAns.SURVEY_DETAIL_AID == surAnalysis.SURVEYDETAIL_AID)
                            {
                                bool isDulicate = surveyAnalysisDisplay.Exists(surDis => surDis.SURVEYLIST_ID == surveyListID && surDis.SURVEYDETAIL_QID == surAnalysis.SURVEYDETAIL_QID);
                                if (!isDulicate)
                                {
                                    surAnalysis.OPTAIN_POINT = 0;
                                    surveyAnalysisDisplay.Add(surAnalysis);
                                }
                            }
                        }
                    }

                    Session["surveyAnalysis"] = surveyAnalysis;
                    Session["surveyAnalysisDisplay"] = surveyAnalysisDisplay;
                    lvSurveyRequestResult.DataSource = surveyAnalysisDisplay;
                    lvSurveyRequestResult.DataBind();

                    grdSurvey.DataSource = surveyAnalysis;
                    grdSurvey.DataBind();

                }
                else
                {
                    Session["surveyAnalysis"] = null;
                    Session["surveyAnalysisDisplay"] = null;
                    lvSurveyRequestResult.DataSource = string.Empty.ToList();
                    lvSurveyRequestResult.DataBind();

                    grdSurvey.DataSource = string.Empty.ToList();
                    grdSurvey.DataBind();
                    lblRsoResult.Text = " RSO wise result not found ";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void PopulateDistributor()
        {
            try
            {
                var items = new DistributorPZ().GetAllDistributor(0);
                ddlDistributor.DataSource = items;
                ddlDistributor.DataTextField = "DISTRIBUTOR_NAME_CODE";
                ddlDistributor.DataValueField = "DISTRIBUTOR_ID";
                ddlDistributor.DataBind();
                ddlDistributor.Items.Insert(0, new ListItem("-Select Distributor-", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PopulateRSO()
        {
            try
            {
                var distributor = Convert.ToDecimal(ddlDistributor.SelectedValue);
                if (distributor > 0)
                {
                    var items = new RsoPZ().GetAllRso(distributor, 0);
                    ddlRSO.DataSource = items;
                    ddlRSO.DataTextField = "RSO_NAME_CODE";
                    ddlRSO.DataValueField = "RSO_ID";
                    ddlRSO.DataBind();
                    ddlRSO.Items.Insert(0, new ListItem("-Select RSO-", "0"));
                }
                else
                {
                    ddlRSO.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillNewSurveyList(decimal distributorID, decimal routeID)
        {
            try
            {
                ddlSurveyList.Items.Clear();
                ListItem li = new ListItem("...Select survey...", "0");
                ddlSurveyList.Items.Add(li);

                List<SP_GET_SURVEYLISTcls> surveys = new List<SP_GET_SURVEYLISTcls>();
                surveys = new SurveyPZ().GetAllSurveyList(0, distributorID, routeID);
                if (surveys != null && surveys.Count() > 0)
                {
                    foreach (SP_GET_SURVEYLISTcls survey in surveys)
                    {
                        ListItem item = new ListItem(survey.TITLE.ToString(), survey.SURVEYLIST_ID.ToString());
                        ddlSurveyList.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateRSO();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnTotalResult_Click(object sender, EventArgs e)
        {
            try
            {
                _surveyListID = Convert.ToDecimal(ddlSurveyList.SelectedValue);
                _distributorID = Convert.ToDecimal(ddlDistributor.SelectedValue);
                if (_surveyListID > 0)
                {
                    loadSurveyResultDeatils(_surveyListID, _distributorID, 0);
                    pnSurveyTotalResult.Visible = true;
                    pnRSOWiseResult.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnRSOWise_Click(object sender, EventArgs e)
        {
            try
            {
                decimal surveyListID = Convert.ToDecimal(ddlSurveyList.SelectedValue);
                decimal distributorID = Convert.ToDecimal(ddlDistributor.SelectedValue);
                decimal rsoID = 0;
                if (surveyListID == 0)
                {
                    return;
                }
                if (ddlRSO.SelectedIndex > 0)
                {
                    rsoID = Convert.ToDecimal(ddlRSO.SelectedValue);
                }
                var surveyAnalysis = new SurveyPZ().GetSurveyAnalysisAns(surveyListID, distributorID, rsoID, "");

                Session["surveyAnalysis"] = surveyAnalysis;

                grdSurvey.DataSource = surveyAnalysis;
                grdSurvey.DataBind();

                pnSurveyTotalResult.Visible = false;
                pnRSOWiseResult.Visible = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvSurveyRequestResult_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {

                    Repeater rptAnswer = (Repeater)e.Item.FindControl("rptAnswer");
                    //Repeater rptPoint = (Repeater)e.Item.FindControl("rptPoint"); 
                    Label lblQuestion = (Label)e.Item.FindControl("lblQuestionID");

                    decimal questionId = Convert.ToDecimal(lblQuestion.Text);
                    decimal answerId = 0;

                    var surveyAnalysis = (List<SP_GET_SURVEYANALYSYS_ANScls>)Session["surveyAnalysis"];
                    var surveyAnalysisDisplay = (List<SP_GET_SURVEYANALYSYS_ANScls>)Session["surveyAnalysisDisplay"];

                    if (surveyAnalysisDisplay != null && surveyAnalysisDisplay.Count() > 0)
                    {
                        if (questionId > 0)
                        {
                            var answers = new SurveyPZ().GetAllSurveyAnswerList(questionId);
                            foreach (var ans in answers)
                            {
                                ans.ANSWER = ans.ANSWER + " ( " + surveyAnalysis.Where(x => x.SURVEYLIST_ID == _surveyListID && x.SURVEYDETAIL_QID == questionId && x.SURVEYDETAIL_AID == ans.SURVEY_DETAIL_AID).Count().ToString() + " ) ";
                            }
                            if (answers != null && answers.Count() > 0)
                            {
                                rptAnswer.DataSource = answers;
                                rptAnswer.DataBind();
                                //rptPoint.DataSource = surveyAnalysisDisplay;
                                //rptPoint.DataBind();

                            }
                            //foreach (RepeaterItem item in rptPoint.Items)
                            //{
                            //    Label lblPoint = (Label)item.FindControl("lblPoint");
                            //    Label lblAnswerId = (Label)item.FindControl("lblAnswerID");
                            //    answerId = Convert.ToDecimal(lblAnswerId.Text);

                            //    lblPoint.Text = surveyAnalysis.Where(x => x.SURVEYLIST_ID == surveyListID && x.SURVEYDETAIL_QID == questionId && x.SURVEYDETAIL_AID == answerId).Count().ToString();
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }



        public void GroupGridColumn(System.Web.UI.WebControls.GridView grd, params string[] parms)
        {
            for (int rowIndex = grd.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                System.Web.UI.WebControls.GridViewRow gvRow = grd.Rows[rowIndex];
                System.Web.UI.WebControls.GridViewRow gvPreviousRow = grd.Rows[rowIndex + 1];
                for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
                {
                    bool flag = false;
                    for (int j = 0; j < parms.Count(); j++)
                    {
                        if (grd.Columns[cellCount].HeaderText == parms[j])
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                    {
                        if (gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text)
                        {
                            if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                            {
                                gvRow.Cells[cellCount].RowSpan = 2;
                            }
                            else
                            {
                                gvRow.Cells[cellCount].RowSpan =
                                    gvPreviousRow.Cells[cellCount].RowSpan + 1;
                            }
                            gvPreviousRow.Cells[cellCount].Visible = false;
                        }
                    }
                }
            }
        }

        protected void grdSurvey_DataBound(object sender, EventArgs e)
        {
            GroupGridColumn(grdSurvey, "RSO Name", "Question");
        }

        protected void grdSurvey_Sorting(object sender, GridViewSortEventArgs e)
        {

        }


        protected void lvSurveyRequestResult_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            _currentSurveyPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

    }
}