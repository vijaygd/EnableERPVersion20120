<%@ Page Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.CandidatesList" Title="List Of Candidates" Codebehind="CandidatesList.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td><h1>Candidate Section</h1></td>
    </tr>
</table>    
<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
    <tr>
        <td>Profile and History</td>
    </tr>
 </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="skiplink">
            <h1><span id="skipToTop" class="skiplink">Content Heading</span></h1>
        </td>
    </tr>
</table>
<span class="skiplink">Instruction text</span><br />
<span class="message">Search for active candidates:</span>
<table cellpadding="4">
    <tr>
        <td>
            <table>
                <tr>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlEmploymentStatus">Show List For</label></td>
                    <td>
                        <asp:DropDownList ID="DdlEmploymentStatus" runat="server">
                            <asp:ListItem Value="0">Unemployed Candidates</asp:ListItem>
                            <asp:ListItem Value="1">Employed Candidates</asp:ListItem>
                            <asp:ListItem Value="-1">All Candidates</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:75px"><label for="ctl00_ContentPlaceHolder2_TxtSearchFor">Search</label></td>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="TxtSearchFor" runat="server" />
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_DdlSearchIn">&nbsp;&nbsp;in</label></td>
                                <td>
                                    <asp:DropDownList ID="DdlSearchIn" runat="server">
                                        <asp:ListItem Value="RID">R I D</asp:ListItem>
                                        <asp:ListItem Value="candidate_name">Name</asp:ListItem>
                                        <asp:ListItem Value="ngo_name">NGO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <table style="margin-left:75px">
                <tr>
                    <td></td>
                    <td><asp:Button ID="BtnSearch" runat="server" Text="Go" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<span class="message">
    <span class="skiplink">Instruction text</span><br />
    OR Click <u>here</u> to view all active candidates.<br /><br />
    OR click <a href="CandidateListTableMoreInfo.htm">more</a>....
</span>
<table cellpadding="4">
    <tr>
        <td>
            <asp:ListView ID="LstViewCandidates" runat="server">
                <LayoutTemplate>
                    <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" style="border-color:#808080; border: 1px solid blue;" 
                                summary="Click on Candidate Name to view Candidate Profile. Click on Candidate R I D to view Candidate History.
                                 To be Profiled candidates: Candidates whose Recommended Job Type or Recommended Role are blank
                                 are candidates who have not been profiled as yet.
                                 Candidate name in capitals indicates 'unemployed candidate'.
                                 If candidate is a priority candidate, then a * appears before candidate name.">
                        <thead class="grid-header">
                            <tr>
                                <td>Candidate Name</td>
                                <td>
                                    Registration ID<br />
                                    (R I D)
                                </td>
                                <td>
                                    Disability<br />
                                    Type
                                </td>
                                <td>Gender</td>
                                <td>Educational<br />Qualifications</td>
                                <td style="width:100px">Address</td>
                                <td>Phone</td>
                                <td>NGO</td>
                                <td>Recommended<br />Job Type</td>
                                <td>Recommended<br />Role</td>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td scope="row" valign="top"><asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Eval("candidate_name") %>' /></td>
                        <td valign="top">
                            <asp:LinkButton ID="LnkBtnRegistrationID" runat="server" Text='<%#Eval("registration_id") %>' />
                        </td>
                        <td valign="top"><%#Eval("disability_type") %></td>
                        <td valign="top"><%#Eval("gender") %></td>
                        <td valign="top"><%#Eval("educational_qualifications") %></td>
                        <td valign="top" style="width:100px"><%#Eval("address") %></td>
                        <td valign="top"><%#Eval("phone_number") %></td>
                        <td valign="top"><%#Eval("ngo_name") %></td>
                        <td valign="top"><%#Eval("recommended_job_type") %></td>
                        <td valign="top"><%#Eval("recommended_role") %></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" bordercolor="#808080" border="1px"
                        summary="Click on Candidate Name to view Candidate Profile. Click on Candidate R I D to view Candidate History.
                                 To be Profiled candidates: Candidates whose Recommended Job Type or Recommended Role are blank
                                 are candidates who have not been profiled as yet.
                                 Candidate name in capitals indicates 'unemployed candidate'.
                                 If candidate is a priority candidate, then a * appears before candidate name.">
                        <thead class="grid-header">
                            <tr>
                                <td style="width:250px">Candidate Name</td>
                                 <td>
                                    Registration ID 
                                    (R I D)
                                </td>
                                <td>
                                    Disability
                                    Type
                                </td>
                                <td>Gender</td>
                                <td>Educational Qualifications</td>
                                <td>Address</td>
                                <td>Phone</td>
                                <td>NGO</td>
                                <td>Recommended<br />Job Type</td>
                                <td>Recommended<br />Role</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td valign="top" style="width:250px" scope="row">
                                    <asp:LinkButton ID="LnkBtnCandidateName" runat="server" Text="Suresh Rao" />
                                </td>
                                <td valign="top">
                                    <asp:LinkButton ID="LnkBtnResistrationID" runat="server" Text="N 1 2 3 4 5" />
                                </td>
                                <td valign="top">V I</td>
                                <td valign="top">M</td>
                                <td valign="top">SSC,HSC,BSc.</td>
                                <td valign="top" style="width:100px">201A, Andheri Kurla Road, Bombay-65</td>
                                <td valign="top">0 8 0-5 2 1 6 6 2 5 1 3</td>
                                <td valign="top">Mobility India</td>
                                <td valign="top">J1</td>
                                <td valign="top">R1</td>
                            </tr>
                            <tr>
                                <td valign="top" style="width:250px" scope="row">
                                    * <asp:LinkButton ID="LinkButton2" runat="server" Text="DAMINI MANISH SETH" />
                                </td>
                                <td valign="top">
                                    <asp:LinkButton ID="LnkBtnRegistrationID2" runat="server" Text="A 1 2 3 4 5" />
                                </td>
                                <td valign="top">H I</td>
                                <td valign="top">F</td>
                                <td valign="top">SSC,HSc,BSc,MBA</td>
                                <td valign="top" style="width:100px">B122, Orchards, Nehru nagar, Delhi-78</td>
                                <td valign="top">0 8 0-5 4 1 2 3 5 4 2 1 2</td>
                                <td valign="top">Enable India</td>
                                <td valign="top"><span class="skiplink">not applicable</span></td>
                                <td valign="top"><span class="skiplink">not applicable</span></td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>
</asp:Content>

