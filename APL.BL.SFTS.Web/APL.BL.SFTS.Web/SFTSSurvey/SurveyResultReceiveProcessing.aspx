<%@ Page Title="" Language="C#" MasterPageFile="~/SFTSSurvey/SFTS.Master" AutoEventWireup="true" CodeBehind="SurveyResultReceiveProcessing.aspx.cs" Inherits="APL.BL.SFTS.Web.SFTSSurvey.SurveyResultReceiveProcessing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanelSurvey" UpdateMode="Conditional">
        <ContentTemplate>           
                <fieldset class="fsStyle">
                    <legend class="legendStyle">Search</legend>                   
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                            
                                <asp:Label runat="server" ID="lblMessage" />
                            </div>                        
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                Survey:
                            </div>
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                                <asp:DropDownList runat="server" ID="ddlSurveyList" CssClass="form-control" AutoPostBack="true" />
                            </div>
                        </div>
                    </div>
             <br />
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                Distributor :
                            </div>
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                                <asp:DropDownList runat="server" ID="ddlDistributor" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged ="ddlDistributor_SelectedIndexChanged" />
                            </div>
                        </div>
                    </div>
                     <br />
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                RSO :
                            </div>
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                                <asp:DropDownList runat="server" ID="ddlRSO" CssClass="form-control" AutoPostBack="true" />
                            </div>
                        </div>
                    </div>

                    <br />
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
                        <asp:Button ID="btnTotalResult" runat="server" Text="Total result" CssClass="pull-right btn btn-success" OnClick="btnTotalResult_Click" />
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                        <asp:Button ID="btnRSOWise" runat="server" Text="RSO Wise" CssClass=" btn btn-success" OnClick="btnRSOWise_Click" />
                    </div>
                </div>
            </div>
            </fieldset>
              
                <div class="row">
                    <fieldset class="fsStyle">
                        <legend class="legendStyle">Survey result analysis report</legend>
                        <asp:Panel ID="pnSurveyTotalResult" runat="server" Visible="false">
                            <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <asp:Label ID ="lblTotalRSO" runat ="server" Text =""></asp:Label>
                                </div>
                            <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <asp:ListView ID="lvSurveyRequestResult" runat="server" DataKeyNames="SURVEYANALYSIS_ANSID" OnItemDataBound="lvSurveyRequestResult_OnItemDataBound">

                                    <LayoutTemplate>
                                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                                            <tr runat="server" class="gr-header">
                                                <th style="text-align: center" class="col-xs-.50">SL #</th>
                                                <th class="col-xs-5.5">Question</th>
                                                <th class="col-xs-5.5">Answer</th>
                                               <%-- <th class="col-xs-.50">Vote</th>--%>
                                            </tr>
                                            <tbody id="itemPlaceholder" runat="server">
                                            </tbody>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr runat="server">
                                            <td style="text-align: center">
                                                <%# Container.DataItemIndex + 1%>
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltQuestion" runat="server" Text='<%#Eval("QUESTION") %>'></asp:Literal>
                                                <asp:Label ID="lblSAnalysisID" runat="server" Text='<%#Eval("SURVEYANALYSIS_ANSID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblQuestionID" runat="server" Text='<%#Eval("SURVEYDETAIL_QID") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Repeater ID="rptAnswer" runat="server">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rbAnswer" Text='<%#Eval("ANSWER") %>' Enabled="false" runat="server"></asp:RadioButton><br />
                                                        <hr />
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                            <%--<td>
                                                <asp:Repeater ID="rptPoint" runat="server">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAnswerID" runat="server" Text='<%#Eval("SURVEYDETAIL_AID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblPoint" runat="server" Text='<%#Eval("OPTAIN_POINT") %>'></asp:Label><br />
                                                        <hr />
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </td>--%>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>

                                        <tr class="bg-info" runat="server">
                                            <td style="text-align: center">
                                                <%# Container.DataItemIndex + 1%>
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltQuestion" runat="server" Text='<%#Eval("QUESTION") %>'></asp:Literal>
                                                <asp:Label ID="lblSAnalysisID" runat="server" Text='<%#Eval("SURVEYANALYSIS_ANSID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblQuestionID" runat="server" Text='<%#Eval("SURVEYDETAIL_QID") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Repeater ID="rptAnswer" runat="server">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rbAnswer" Text='<%#Eval("ANSWER") %>' Enabled="false" runat="server"></asp:RadioButton><br />
                                                        <hr />
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                           <%-- <td>
                                                <asp:Repeater ID="rptPoint" runat="server">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAnswerID" runat="server" Text='<%#Eval("SURVEYDETAIL_AID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblPoint" runat="server" Text='<%#Eval("OPTAIN_POINT") %>'></asp:Label><br />
                                                        <hr />
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </td>--%>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td>Total result is empty ...
                                            </td>
                                        </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:ListView>

                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnRSOWiseResult" runat="server" Visible="false">
                            <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <asp:GridView ID="grdSurvey" runat="server" AutoGenerateColumns="False" class="table table-bordered table-hover" Style="margin-bottom: 0px;"
                                    AllowSorting="True" OnDataBound="grdSurvey_DataBound" OnSorting="grdSurvey_Sorting">
                                    <AlternatingRowStyle CssClass="bg-info" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SURVEYANALYSIS_ANSID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSurveyListID" runat="server" Text='<%# Bind("SURVEYANALYSIS_ANSID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="RSO Name" DataField="RSO_NAME" />
                                        <asp:BoundField HeaderText="Question" DataField="QUESTION" />
                                        <asp:TemplateField HeaderText="Answer">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSdaAnswer" runat="server" Text='<%# Bind("ANSWER") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Point" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoint" runat="server" Text='<%# Bind("OPTAIN_POINT") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="gr-header" />
                                    <RowStyle CssClass="" />
                                </asp:GridView>
                                <asp:Label ID="lblRsoResult" runat="server" Text=""></asp:Label>
                            </div>
                        </asp:Panel>

                    </fieldset>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
