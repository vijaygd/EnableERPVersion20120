<%@ Page Title="View Data Options" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.Registration.ViewDataOptions" Codebehind="ViewDataOptions.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table>
    <tr>
        <td>
            <table style="margin-bottom:10px">
                <tr>
                    <td>
                        <asp:Button ID="BtnPrint" runat="server" Text="Print" 
                            onclick="BtnPrint_Click" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        Disability Sub-Type:
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ListView ID="LstDisabilitySubType" runat="server">
                            <LayoutTemplate>
                                <table id="TblDisabilitySubType"  cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px">
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Disability Type</th>
                                            <th>Disability Sub-Type</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                         <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td id="TdRecordNumber" align="right"></td>
                                    <td align="left"><%#Eval("disability_type") %></td>
                                    <td align="left"><%#Eval("disability_sub_type") %></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px">
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Disability Type</th>
                                            <th>Disability Sub-Type</th>
                                        </tr>
                                    </thead>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
            <table style="margin-top:10px">
                <tr>
                    <td>
                        Educational Qualifications:
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                       <asp:ListView ID="LstEducationalQualifications" runat="server">
                            <LayoutTemplate>
                                <table id="TblEducationalQualifications" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Education</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td id="TdRecordNumber" align="right"></td>
                                    <td align="left"><%#Eval("course_qualification_name") %></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Education</th>
                                        </tr>
                                    </thead>
                                </table>
                            </EmptyDataTemplate>
                       </asp:ListView>
                    </td>
                </tr>
            </table>
            <table style="margin-top:10px">
                <tr>
                    <td>
                        Languages Known: 
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ListView ID="LstLanguagesKnown" runat="server">
                            <LayoutTemplate>
                                <table id="TblLanguagesKnown" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Languages</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                         <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td id="TdRecordNumber" align="right"></td>
                                    <td align="left"><%#Eval("language_name") %></td>
                                </tr>
                            
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Languages</th>
                                        </tr>
                                    </thead>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
            <table style="margin-top:10px">
                <tr>
                    <td>
                        Recommended Training:
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ListView ID="LstRecommendedTrainings" runat="server">
                            <LayoutTemplate>
                                <table id="TblRecommendedTrainings"cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px">
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right" align="right">No.</th>
                                            <th align="left">Training Program</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td id="TdRecordNumber" align="right"></td>
                                    <td align="left"><%#Eval("training_program_name") %></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                 <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Training Program</th>
                                        </tr>
                                    </thead>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>        
            <table style="margin-top:10px">
                <tr>
                    <td>
                        Recommended Job Type:
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ListView ID="LstRecommendedJobType" runat="server">
                            <LayoutTemplate>
                                <table id="TblRecommendedJobType" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px">
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Job Type</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td id="TdRecordNumber" align="right"></td>
                                    <td align="left"><%#Eval("job_name") %></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                              <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                bordercolor="#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Job Type</th>
                                        </tr>
                                    </thead>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
            <table style="margin-top:10px">
                <tr>
                    <td>
                        Recommended Role:
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ListView ID="LstRecommendedRole" runat="server">
                            <LayoutTemplate>
                                <table  id="TblRecommendedRole" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Role</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>    
                                </table>    
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td id="TdRecordNumber" align="right"></td>
                                    <td align="left"><%#Eval("job_role_name")%></td>
                                </tr>
                            
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                  <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Role</th>
                                        </tr>
                                    </thead>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
            <table style="margin-top:10px">
                <tr>
                    <td>
                        Groups Candidate is assigned to:
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ListView ID="LstCandidateGroup" runat="server">
                            <LayoutTemplate>
                                 <table id="TblCandidateGroup" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Candidate Groups</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td id="TdRecordNumber" align="right"></td>
                                    <td align="left"><%#Eval("group_name") %></td>
                                </tr>
                            
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                 <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Candidate Groups</th>
                                        </tr>
                                    </thead>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
            <table style="margin-top:5px">
                <tr>
                    <td>
                        <input type="button" value="Close" onclick="javascript:self.close();" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="ViewDataOptions.js" type="text/javascript"></script>
</asp:Content>

