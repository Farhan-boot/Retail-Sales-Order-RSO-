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
    public partial class SurveyResultReceive : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string token = "";
                    decimal rsoID = 0;
                    decimal surveyListID = 0;

                    foreach (string key in Request.QueryString)
                    {
                        if(key == "token")
                        {
                             token = Request.QueryString[key];
                        }
                        else if(key == "rsoID")
                        {
                             rsoID = Convert.ToDecimal(Request.QueryString[key]);
                        }
                        else if (key == "surveyListID")
                        {
                            surveyListID = Convert.ToDecimal(Request.QueryString[key]);
                        }
                    }


                    if (rsoID != 0)
                    {

                    }
                    else
                    {
                       btnSave.Visible = false;
                       ErrorMessage.Text = "RSO is not found.";
                    }

                    loadSurveyQuestion(surveyListID, rsoID, token);
                    loadSurveyDeatils(surveyListID, 0, rsoID, token);
                }
                catch (Exception ex)
                {
                    lblDistributorName.Text = ex.Message;
                }
            }
        }

        private void loadSurveyQuestion(decimal surveyListID, decimal rsoID, string token)

        {
            try
            {
                var items = new SurveyPZ().GetAllSurveyQuestionList(surveyListID, rsoID, token);
                if (items != null && items.Count() > 0)
                {
                    rptQuestion.DataSource = items;
                    rptQuestion.DataBind();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadSurveyDeatils(decimal surveyListID, decimal distributorID, decimal rsoID, string token)
        {
            try
            {
                var surveyAnalysis = new SurveyPZ().GetSurveyAnalysisAns(surveyListID, distributorID, rsoID, token);
                var questionList = new SurveyPZ().GetAllSurveyQuestionList(surveyListID, rsoID, token);
                var distributorList = new DistributorPZ().GetAllDistributor(distributorID);
                var rsoList = new RsoPZ().GetAllRso(distributorID, rsoID);

                if (surveyAnalysis != null)
                {
                    if (surveyAnalysis.Count > 0)
                    {
                        ErrorMessage.Text = "Already received your opinion";
                        btnSave.Visible = false;
                        rptQuestion.Visible = false;
                        lblRSOName.Visible = false;
                        QuestionFieldSet.Visible = false;
                        lblDistributorName.Visible = false;
                        lblSurveyTitle.Visible = false;
                    }
                    else
                    {
                        btnSave.Visible = true;
                    }
                    if (questionList != null && questionList.Count() > 0)
                    {
                        lblSurveyTitle.Text = surveyListID != 0 ? questionList.FirstOrDefault(x => x.SURVEY_LIST_ID == surveyListID).TITLE : "";
                    }
                    if (distributorList != null && distributorList.Count() > 0)
                    {
                        // lblDistributorName.Text = distributorID != 0 ? distributorList.FirstOrDefault(x => x.DISTRIBUTOR_ID == distributorID).DISTRIBUTOR_NAME : ""; 
                    }
                    if (rsoList != null && rsoList.Count() > 0)
                    {
                        lblRSOName.Text = rsoID != 0 ? rsoList.FirstOrDefault(x => x.RSO_ID == rsoID).RSO_NAME_CODE : "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rptQuestion_rptQuestion(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Label lblQuestion = (Label)e.Item.FindControl("lblQuestionID");
                decimal questionID = Convert.ToDecimal(lblQuestion.Text);

                RadioButtonList rdlstQuestion = (RadioButtonList)e.Item.FindControl("rdlstQuestion");
                rdlstQuestion.Items.Clear();
                var answers = new SurveyPZ().GetAllSurveyAnswerList(questionID);
                if (answers != null && answers.Count() > 0)
                {
                    foreach (SP_GET_SURVEYANSWER_LISTcls answer in answers)
                    {
                        ListItem item = new ListItem(answer.ANSWER.ToString(), answer.SURVEY_DETAIL_AID.ToString());
                        rdlstQuestion.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string token = "";
                decimal rsoID = 0;
                decimal surveyListID = 0;

                foreach (string key in Request.QueryString)
                {
                    if (key == "token")
                    {
                        token = Request.QueryString[key];
                    }
                    else if (key == "rsoID")
                    {
                        rsoID = Convert.ToDecimal(Request.QueryString[key]);
                    }
                    else if (key == "surveyListID")
                    {
                        surveyListID = Convert.ToDecimal(Request.QueryString[key]);
                    }
                }

                List<SP_INS_UPD_SURVEY_ANALYSIS_ANScls> answerList = new List<SP_INS_UPD_SURVEY_ANALYSIS_ANScls>();

                foreach (RepeaterItem item in rptQuestion.Items)
                {
                    SP_INS_UPD_SURVEY_ANALYSIS_ANScls answer = new SP_INS_UPD_SURVEY_ANALYSIS_ANScls();

                    Label lblQuestion = (Label)item.FindControl("lblQuestionID");
                    RadioButtonList rdlstQuestion = (RadioButtonList)item.FindControl("rdlstQuestion");
                    Label lblPoint = (Label)item.FindControl("lblPoint");
                    answer.SURVEYDETAIL_QID = Convert.ToDecimal(lblQuestion.Text);
                    answer.OPTAIN_POINT = Convert.ToDecimal(lblPoint.Text);
                    foreach (ListItem rdItem in rdlstQuestion.Items)
                    {
                        if (rdItem.Selected)
                        {
                            answer.SURVEYDETAIL_AID = Convert.ToDecimal(rdItem.Value);
                        }
                    }

                    answer.SURVEYLIST_ID = 0;
                    answer.DISTRIBUTORID = 0;
                    answer.RSOID = rsoID;
                    answer.ADMIN_REMARK = "";
                    answer.SUBMIT_DATE = DateTime.Now;
                    answerList.Add(answer);
                }

                if (answerList.Count() > 0)
                {
                    foreach (SP_INS_UPD_SURVEY_ANALYSIS_ANScls ans in answerList)
                    {
                        decimal result = new SurveyPZ().SaveSurveyAnalysisAns(0, ans.DISTRIBUTORID, ans.RSOID, ans.SURVEYLIST_ID, ans.SURVEYDETAIL_QID,
                            ans.SURVEYDETAIL_AID, ans.OPTAIN_POINT, ans.SUBMIT_DATE, ans.ADMIN_REMARK);
                    }

                    ErrorMessage.Text = "Your answer is received successfully.";
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //ErrorMessage.Text = ex.Message;
                throw ex;
            }
        }
    }
}