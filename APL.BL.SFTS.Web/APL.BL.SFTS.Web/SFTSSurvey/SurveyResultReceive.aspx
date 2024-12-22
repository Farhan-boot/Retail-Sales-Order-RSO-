<%@ Page Title="" Language="C#" MasterPageFile="~/SFTSSurvey/SurveySFTS.Master" AutoEventWireup="true" CodeBehind="SurveyResultReceive.aspx.cs" Inherits="APL.BL.SFTS.Web.SFTSSurvey.SurveyResultReceive" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">

            <p class="text-success" style="text-align: center; font-size:x-large; color:orange;">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
        </div>
    </div>
    <div class="row">
        <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <p class="text-success" style="text-align: center">
                <asp:Label ID="lblSurveyTitle" runat="server" Font-Size="XX-Large" Font-Bold="true"></asp:Label><br />
            </p>
        </div>
    </div>
    <div class="row">
        <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <p class="text-success" style="text-align: center">
                <asp:Label ID="lblDistributorName" runat="server" Font-Bold="true" ></asp:Label><br />
            </p>
            <p class="text-success" style="text-align: center">
                <asp:Label ID="lblRSOName" runat="server" Font-Bold="true"></asp:Label><br />
            </p>
        </div>
    </div>
    <div>
        <fieldset class="fsStyle-lg" id="QuestionFieldSet" runat="server">
            <legend class="legendStyle-lg">Waiting for your opinion</legend>
            <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1">
                </div>
           <div class="col-lg-11 col-md-11 col-sm-11 col-xs-11">
                <asp:Repeater ID="rptQuestion" runat="server" OnItemDataBound="rptQuestion_rptQuestion">
                    <ItemTemplate>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label ID="Label1" runat="server" Text='<%# (((RepeaterItem)Container).ItemIndex+1).ToString() %>' Visible="True"></asp:Label>  .
                             <asp:Literal ID="ltQuestion" runat="server" Text='<%#Eval("QUESTION") %>'></asp:Literal>
                            <asp:Label ID="lblQuestionID" runat="server" Text='<%#Eval("SURVEY_DETAIL_QID") %>' Visible="false"></asp:Label>
                           <asp:Label ID="lblPoint" runat="server" Text='<%#Eval("POINT") %>' Visible="false"></asp:Label>
                        </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin-left:3%;">
                       <asp:RadioButtonList ID="rdlstQuestion" RepeatDirection="Vertical" runat="server"    >
                            </asp:RadioButtonList>
                       

                     &nbsp; &nbsp;  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="rdlstQuestion" runat="server" ErrorMessage="Select Item !" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                     </div>

                    </ItemTemplate>
                </asp:Repeater>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="pull-right control-group col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <div class="controls" style="text-align: center; text-decoration-color: greenyellow;">
                            <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="btn btn-success pull-right " OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>


</asp:Content>

