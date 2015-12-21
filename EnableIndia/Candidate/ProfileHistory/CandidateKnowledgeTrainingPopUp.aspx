<%@ Page Language="C#" Title="Recommended Training Programs" AutoEventWireup="true" MasterPageFile="~/Popup.master" Inherits="EnableIndia.Candidate.ProfileHistory.CandidateKnowledgeTrainingPopUp" Codebehind="CandidateKnowledgeTrainingPopUp.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table style="margin-left:10px;margin-top:10px">
        <tr>
            <td valign="top">
                 Training Program
            </td>
            <td>
                 Options<br />
                <asp:ListView ID="LstViewTrainingProgram" runat="server"
                    OnItemDataBound="LstViewTrainingProgram_ItemDataBound">
                     <LayoutTemplate>
                        <table id="TblViewTrainingProgram" cellpadding="0" class="checkedListBox" cellspacing="0" >
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <table  cellpadding="0">
                        <tr>
                            <td id="textField" >
                                <%#Eval("training_program_name")%>
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkTrainingProgramName" runat="server" 
                                    trainingProgramID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("training_program_id"))) %>' 
                                    Checked='<%# Convert.ToBoolean(Eval("is_attached")) %>'/>
                                <label id="LblTrainingProgramName" runat="server" class="skiplink">test</label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                </asp:ListView>
            </td>
        </tr>
    </table>
    <table style="margin-left:110px;margin-top:10px">
        <tr>
            <td>
                
                <asp:Button ID="BtnSubmit" Text="Submit" runat="server" 
                    OnClick="BtnSubmit_click" />
             </td>   
             <td style="padding-left:10px">
                <input id="BtnCancel" type="button" value="Close" onclick="javascript:self.close();return false;" />
            </td>
        </tr>
    </table>
    <script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Common.js" type="text/jscript"></script>
    <script src="CandidateKnowledgeTrainingPopUp.js" type="text/javascript"></script>
</asp:Content>
