<%@ Page Title="Add Notes" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Training.CandidateNotes" Codebehind="CandidateNotes.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <telerik:RadCodeBlock runat="server" ID="rcb1">
       <script language="javascript" type="text/javascript">
           function GetRadWindow() {
               var oWindow = null;
               if (window.radWindow) {
                   oWindow = window.RadWindow;
               }
               else
                   if (window.frameElement.radWindow) {
                       oWindow = window.frameElement.radWindow;
                   }
               return oWindow;;
           }
           function Close(msg) {
               GetRadWindow().Close(msg);
           }
           function refreshParentPage() {
               getRadWindow().BrowserWindow.location.reload();
           }
           function redirectParentPage(url) {
               GetRadWindow().BrowserWindow.document.location.href = url;
           }

      </script>
      </telerik:RadCodeBlock>

<table>
    <tr>
        <td>
            <span class="readonlyText">Training Program Name :</span>
        </td>
        <td><span id="SpnTrainingProgramName" runat="server" class="readonlyText"></span>
        </td>
      
    </tr>
</table>
<table>
    <tr>
         <td>
            <span class="readonlyText">Training Project Name :</span>
        </td>
        <td><span id="SpnTrainingProjectName" runat="server" class="readonlyText"></span>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <span class="readonlyText">Candidate :</span>
        </td>
        <td><span id="SpnCandidateName" runat="server" class="readonlyText"></span>
        </td>
        <td style="padding-left:20px">
            <span class="readonlyText">RID :</span>
        </td>
        <td>
            <span id="SpnCandidateRID" runat="server" class="readonlyText"></span>
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
<%--<table>
    <tr>
        <td class="message">
            You can add new Notes by filling any or all of the fields below.
        </td>
    </tr>
</table>--%>
<table>
    <tr>
        <td>
          <label for="ctl00_ContentPlaceHolder1_TxtNotes">Notes:</label>
        </td>
        <td>
            <asp:TextBox ID="TxtNotes" runat="server" TextMode="MultiLine" Width="400px" Height="60px" class="mandatory" messagetext="Note" />
        </td>
    </tr>
</table>
<table >
    <tr>
        <td style="padding-left:100px">
            <asp:Button ID="BtnSubmit" runat="server" Text="Submit"
            OnClientClick="javascript:return ValidateForm();"
                OnClick="BtnSubmit_click" />
        </td>
        <td style="padding-left:10px">
            <input id="BtnReset" type="reset" value="Clear" />
        </td>
       
        <td style="padding-left:10px">
            <asp:Button runat="server" ID="btnClose" Text="Close" style="margin-left:5px;" OnClick="closeRadWindow" />
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
                            <u>Existing Notes for this Training Project:</u>
                            </td>
                        </tr>
                    </table>
                    <table id="TblCandidateNotes" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                           bordercolor="#808080" border="1px" messagetext="Candidate" style="margin:10px">
                             <thead>
                                <tr class="grid-header">
                                    <th>Candidate</th>
                                    <th>Date</th>
                                    <th>RID</th>
                                    <th>Notes</th>
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
                                <td><%# Eval("notes") %></td>
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
    <script src="../Scripts/Common.js" type="text/javascript"></script>
</asp:Content>

