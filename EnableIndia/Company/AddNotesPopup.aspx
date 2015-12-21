<%@ Page Title="Manage Open Employment Project - Add Notes" MasterPageFile="~/Popup.master" Language="C#" AutoEventWireup="true" Inherits="EnableIndia.Company.AddNotesPopup" Codebehind="AddNotesPopup.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div tabindex="1"></div>
<table cellpadding="4">
    <tr>
        <td>
            <table>
                <tr>
                    <td class="readonlyText" style="font-weight:bold">
                        Parent Company Name: <span id="SpnParentCompany">TCS</span><br />
                        Company Code: <span id="SpnCompanyCode" runat="server">TCS-BLR-ECITY</span><br />
                        Vacancy Code: <span id="SpnVacancyCode" runat="server">TCS-BLR-ECITY-RECEPTIONIST</span><br />
                        Employment Project Code: <span id="SpnEmploymentProjecTCode" runat="server">12/12/2008 14:08 hrs</span><br />
                        Designation: <span id="SpnDesignation" runat="server">Senior Receptionist</span>
                    </td>
                </tr>
            </table>
            
            <table style="margin-top:10px">
                <tr>
                    <td>
                        <span style="font-weight:bold;text-decoration:underline">Add New Note:</span><br />
                        <span class="message">You can add new Notes by filling any or all of the fields below.</span>
                    </td>
                </tr>    
            </table>
            
            <table style="margin-top:8px">
                <tr>
                    <td class="readonlyText" style="font-weight:bold">
                        Candidate: <span id="SpnCandidateName" runat="server">Shamita Shetty</span>
                    </td>
                    <td style="width:20px">&nbsp;</td>
                    <td class="readonlyText" style="font-weight:bold">
                        RID: <span id="SpnRID" runat="server">A108765</span>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder1_TxtInterviewDate">Interview Date</label>
                        <asp:TextBox ID="TxtInterviewDate" runat="server" Width="150px" />
                    </td>
                    <td style="padding-left:40px">
                        <label for="ctl00_ContentPlaceHolder1_TxtInterviewTime">Time</label>
                        <asp:TextBox ID="TxtInterviewTime" runat="server" Width="150px" />
                    </td>
                    <td class="message" style="width:200px">This will get set as a task in company task management.</td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td><label for="ctl00_ContentPlaceHolder1_TxtInterpreterName">Escort/ Sign Language Interpreter Name</label></td>
                    <td><asp:TextBox ID="TxtInterpreterName" runat="server" Width="300px" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td><label for="ctl00_ContentPlaceHolder1_TxtInterpreterContactDetails">Escort/ Sign Language Interpreter contact details</label></td>
                    <td><asp:TextBox ID="TxtInterpreterContactDetails" runat="server" Width="300px" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:150px"><label for="ctl00_ContentPlaceHolder1_TxtPostInterviewDate">Date for post-interview follow-up with company</label></td>
                    <td><asp:TextBox ID="TxtPostInterviewDate" runat="server" Width="150px" /></td>
                    <td style="padding-left:40px"><label for="ctl00_ContentPlaceHolder1_TxtPostInterviewTime">Time</label></td>
                    <td><asp:TextBox ID="TxtPostInterviewTime" runat="server" Width="150px" /></td>
                    <td class="message" style="width:200px">This will get set as a task in company task management.</td>
                </tr>
            </table>
            
            <table style="margin-top:10px">
                <tr>
                    <td><label for="ctl00_ContentPlaceHolder1_TxtSalary">Salary</label></td>
                    <td><asp:TextBox ID="TxtSalary" runat="server" Width="150px" /></td>
                    <td class="message">This will get updated into Profile.</td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:130px"><label for="ctl00_ContentPlaceHolder1_TxtContractEndDate">If job is on contract, then contract end date</label></td>
                    <td><asp:TextBox ID="TxtContractEndDate" runat="server" Width="150px" /></td>
                    <td class="message">This will get updated into Profile.</td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td valign="top"><label for="ctl00_ContentPlaceHolder1_TxtComments">Comments</label></td>
                    <td><asp:TextBox ID="TxtComments" runat="server" Width="500px" TextMode="MultiLine" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:62px">&nbsp;</td>
                    <td>
                        <input id="BtnClear" type="button" value="Clear" onclick="javascript:ClearAll();" />
                        <asp:Button ID="BtnAddNotes" runat="server" Text="Submit" />
                    </td>
                </tr>
            </table>
            
            <table style="margin-top:30px">
                <tr>
                    <td>
                        <span style="font-weight:bold;text-decoration:underline">Existing Notes for this Employment Project</span>
                        <asp:ListView ID="LstViewNotes" runat="server">
                            <LayoutTemplate>
                                <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" style="margin-top:20px">
                                    <thead>
                                        <tr class="grid-header">
                                            <th class="readonlyText" style="width:90px">Date</th>
                                            <th class="readonlyText">RID</th>
                                            <th class="readonlyText">Candidate</th>
                                            <th class="readonlyText" style="width:400px">Notes</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                    </tbody>    
                                </table>
                            </LayoutTemplate>
                            <EmptyDataTemplate>
                                <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" style="margin-top:20px">
                                    <thead>
                                        <tr class="grid-header">
                                            <th class="readonlyText" style="width:90px">Date</th>
                                            <th class="readonlyText">RID</th>
                                            <th class="readonlyText">Candidate</th>
                                            <th class="readonlyText" style="width:400px">Notes</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>18/10/2008</td>
                                            <th style="font-weight:normal">A109876</th>
                                            <td>Smita Khare</td>
                                            <td>Interview date: 12/12/2008 time 18:30 pm</td>
                                        </tr>
                                        <tr>
                                            <td>17/10/2008</td>
                                            <th style="font-weight:normal">N612561</th>
                                            <td>Rajesh Shetty</td>
                                            <td>Date for post interview follow-up with company: 18/12/2008 time: 16:30 pm</td>
                                        </tr>
                                        <tr>
                                            <td>16/10/2008</td>
                                            <th style="font-weight:normal">A2451426</th>
                                            <td>Amit Sana</td>
                                            <td>is not sure if he will take up offer.</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
            
        </td>
    </tr>
</table>
    <script type="text/javascript">
        $(document).ready(function()
        {
            $("#TxtNotes").focus();
        });
    </script>
</asp:Content>
