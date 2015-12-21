<%@ Page Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Company.CandidateNotesForEmploymentProject" Title="Add Notes" Codebehind="CandidateNotesForEmploymentProject.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
    <tr>
        <td class="readonly_bold_text">
            <span>Employment Project : </span><span id="SpnEmploymentProjectName" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td class="readonly_bold_text">
            <span>Current Demand: </span><span id="SpnCurrentDemand" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <span class="readonly_bold_text">Candidate :</span>
        </td>
        <td><span id="SpnCandidateName" runat="server" class="readonly_bold_text"></span>
        </td>
        <td style="padding-left:20px">
            <span class="readonly_bold_text">RID :</span>
        </td>
        <td>
            <span id="SpnCandidateRID" runat="server" class="readonly_bold_text"></span>
            <asp:Label CssClass="labelStyle" runat="server" ID="InterveiwDateT" Text="Interview Dates: " Font-Bold="true"></asp:Label>
            <asp:Label CssClass="labelStyle" runat="server" ID="lbStartDate"></asp:Label>&nbsp;&nbsp;
            <asp:Label CssClass="labelStyle" runat="server" ID="lbEndDate"></asp:Label>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="font-weight:bold">
        <u>Add New Notes</u>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
              <label for="ctl00_ContentPlaceHolder1_TxtInterviewDate">Interview Date:</label>
        </td>
        <td>(dd/mm/yyyy)<br />
            <asp:TextBox ID="TxtInterviewDate" runat="server" date="true" yearlength="4" ></asp:TextBox>
        </td>
        <td style="padding-left:30px">
            <label for="ctl00_ContentPlaceHolder1_TxtInterviewTime"> Time :</label>
        </td>
        <td>(hh:mm)<br />
            <asp:TextBox ID="TxtInterviewTime" runat="server"  time="true"  ></asp:TextBox>
        </td>
        <td style="vertical-align:bottom;">
          <select id="DdlInteviewTime" runat="server" title="">
                <option value="-2">Select</option>
                <option value="AM">AM</option>
                <option value="PM">PM</option>
            </select>
        </td>
    
    </tr>
</table>

<table>
    <tr>
        <td>
             <label for="ctl00_ContentPlaceHolder1_TxtLanguageInterpreterName"> Escort/Sign Language Interpreter Name :</label>
        </td>
        <td>
            <asp:TextBox ID="TxtLanguageInterpreterName" runat="server"></asp:TextBox>
        </td>
        <td style="padding-left:30px">
             <label for="ctl00_ContentPlaceHolder1_TxtInterpreterContactDetails"> Contact Details :</label>
        </td>
        <td>
            <asp:TextBox ID="TxtInterpreterContactDetails" runat="server"></asp:TextBox>
        </td>
    </tr>    
</table>

<table>
    <tr>
        <td style="width:150px">
             <label for="ctl00_ContentPlaceHolder1_TxtDateForPostInterView"> Date For Post Interview follow up with Company:</label>
        </td>
        <td>(dd/mm/yyyy)<br />
            <asp:TextBox ID="TxtDateForPostInterView" runat="server"></asp:TextBox>
        </td>
        <td style="padding-left:30px">
            
             <label for="ctl00_ContentPlaceHolder1_TxtTimeForPostInterView"> Time :</label>
        </td>
        <td> (hh:mm)<br />
            <asp:TextBox ID="TxtTimeForPostInterView" runat="server" ></asp:TextBox>
        </td>
        <td style="vertical-align:bottom;">
          <select id="DdlPostInterviewTime" runat="server" messagetext="From clock time" title="">
                <option value="-2">Select</option>
                <option value="AM">AM</option>
                <option value="PM">PM</option>
            </select>
        </td>
    
    </tr>
</table>




<table>
    <tr>
        <td>
          <label for="ctl00_ContentPlaceHolder1_TxtComments">Comments:</label>
        </td>
        <td>
            <asp:TextBox ID="TxtComments" runat="server" TextMode="MultiLine" Width="400px" Height="60px" class="mandatory" messagetext="Note" />
        </td>
    </tr>
</table>
<table >
    <tr>
        <td style="padding-left:100px">
            <asp:Button ID="BtnSubmit" runat="server" Text="Submit"
            OnClientClick="javascript:return ValidateDateTime();"
             OnClick="BtnSubmit_click" Font-Bold="true"  />
        </td>
        <td style="padding-left:10px">
            <%--<input id="BtnReset" type="reset" value="Clear" />--%>
             <asp:Button ID="BtnResetDetail" runat="server" Text="reset"
             OnClick="BtnResetDetail_click"  />
        </td>
       
        <td style="padding-left:10px">
            <asp:Button runat="server" ID="btnClose" Text="Close" style="margin-left:5px;" OnClick="btnCloseClick" />
        </td>
    </tr>

</table>


<table cellspacing="4" style="margin-top:10px">
    <tr>
        <td>
            <asp:ListView ID="LstCandidateNotes" runat="server" 
               >
                <LayoutTemplate>
                    <table>
                        <tr>
                            <td style="font-weight:bold">
                            <u>Existing Notes for this Employment Project:</u>
                            </td>
                        </tr>
                    </table>
                    <table id="TblCandidateNotes" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                            messagetext="Candidate" style="margin:10px; border-color:#808080; border-width:1px;">
                             <thead>
                                <tr class="grid-header">
                                    <th>Candidate</th>
                                    <th>Date</th>
                                    <th>RID</th>
                                    <th style="width:200px">Notes</th>
                                </tr>
                                </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                            </tbody>                   
                        </table>
                        </LayoutTemplate>
                        
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("candidate_name") %></td>
                                <td><%#Convert.ToDateTime(Eval("notes_date")).ToString("dd/MM/yyyy")%></td>
                                <td><%# Eval("registration_id") %></td>
                                <td>
                                <%# Eval("str_notes")%>
                                    
                                </td>
                            </tr>
                        </ItemTemplate>
                  </asp:ListView>
            </td>
        </tr>
        <tr>
        <td style="vertical-align:middle; text-align:center;">
            <asp:Label CssClass="labelStyle" runat="server" ID="lbError"></asp:Label>
            <asp:HiddenField runat="server" ID="txboxId" />
            <asp:HiddenField runat="server" ID="txtParent" ClientIDMode="Static" />
        </td>
    </tr>

</table>
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="CandidateNotesForEmploymentProject.js" type="text/javascript"></script>
</asp:Content>

