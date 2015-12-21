<%@ Page Title="Reports List" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.ReportList" Codebehind="ReportList.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="2" class="pageHeader" >Candidate Section</td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
    <tr>
        <td>Reports > Reports List</td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink">Reports List</span></h1>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/tRptAllRegisteredCandidates.aspx' class="readonlyText">All Active Registered Candidate</a>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/CandidateWiseTrainingEmploymentRelation.aspx' class="readonlyText">Candidate Wise Training And Employment Relation</a>
        </td>
    </tr>
</table>
<%--<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/FlagWiseOpenCandidateTask.aspx' class="readonlyText">Flag Wise Open Candidate Task</a>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/FlagWiseClosedCandidateTask.aspx' class="readonlyText">Flag Wise Closed Candidate Task</a>
        </td>
    </tr>
</table>--%>

<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/CandidateTask.aspx' class="readonlyText">Candidate Task</a>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/EmploymentProofNotGot.aspx' class="readonlyText">Employment Proof not got from Candidate</a>
        </td>
    </tr>
</table>


<%-- <table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/OwnerWiseOpenCandidateTask.aspx' class="readonlyText">Owner Wise Open Candidate Task</a>
        </td>
    </tr>
</table>--%>

<%--<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/OwnerWiseClosedCandidateTask.aspx' class="readonlyText">Owner Wise Closed Candidate Task</a>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/FlagwiseCompanyOpenTask.aspx' class="readonlyText">Flagwise Company Open Task</a>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/OwnerWiseCompanyOpenTask.aspx' class="readonlyText">Ownerwise Company Open Task</a>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/FlagwiseCompanyClosedTask.aspx' class="readonlyText">Flagwise Company Closed Task</a>
        </td>
    </tr>
</table>--%>

<%--<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/OwnerwiseCompanyClosedTask.aspx' class="readonlyText">Ownerwise Company Closed Task</a>
        </td>
    </tr>
</table>
--%>

<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/TrainingPrograms.aspx' class="readonlyText">Training Programs</a>
        </td>
    </tr>
</table>



<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/TrainingProjectReports.aspx' class="readonlyText">Training Projects</a>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/AssignedListPageForClosedTrainingProjects.aspx' class="readonlyText">Assigned List Page for Closed Training Projects</a>
        </td>
    </tr>
</table>


<%--<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/OwnerwiseTrainingWorkDistribution.aspx' class="readonlyText">Ownerwise Training WorkDistribution</a>
        </td>
    </tr>
</table>--%>





<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/ParentCompaniesReport.aspx' class="readonlyText">List Of Parent Companies</a>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/CompanyReport.aspx' class="readonlyText">List Of Companies</a>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/Vacancy.aspx' class="readonlyText">Vacancy</a>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/EmploymentProjectsWithEmploymentStatus.aspx' class="readonlyText">Employment Projects With Employment Status</a>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/AssignedListClosedEmploymentProject.aspx' class="readonlyText">Assigned List Page for Closed Employment Projects</a>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
            <a href='<%= ResolveClientUrl("~")%>ReportSection/CompanyTask.aspx' class="readonlyText">Company Task</a>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="white-space:nowrap">
           <a href='<%= ResolveClientUrl("~")%>ReportSection/RejectionDataForCandidates.aspx' class="readonlyText">Rejection Data For Candidates</a>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
          <a href='<%= ResolveClientUrl("~")%>ReportSection/GotJobN.aspx' class="readonlyText">Got Job</a>
       </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
          <a href='<%= ResolveClientUrl("~")%>ReportSection/GotJobWithPlacements.aspx' class="readonlyText">Got Job with Training Porgrams</a>
       </td>
    </tr>
</table>
<table>
    <tr>
        <td style="white-space:nowrap">
          <a href='<%= ResolveClientUrl("~")%>ReportSection/PlacementsN.aspx' class="readonlyText">Placements</a>
        </td>
    </tr>
    <tr>
        <td style="white-space:nowrap">
          <a href='<%= ResolveClientUrl("~")%>ReportSection/PlacementWithTrainingProgram.aspx' class="readonlyText">Placements with Training Programs</a>
       </td>
    </tr>
    <tr>
       <td style="white-space:nowrap">
          <a href='<%= ResolveClientUrl("~")%>ReportSection/GotJob.aspx' class="readonlyText">New Got Job (Old Type)</a>
       </td>
    </tr>
    <tr>
       <td style="white-space:nowrap">
         <a href='<%= ResolveClientUrl("~")%>ReportSection/Placements.aspx' class="readonlyText">Placements (Old Type)</a>
       </td>

    </tr>
    <tr>
       <td style="white-space:nowrap">
         <a href='<%= ResolveClientUrl("~")%>ReportSection/TrainingandEmployment.aspx' class="readonlyText">Training and Employment Impact</a>
       </td>
    </tr>
    <tr>
       <td style="white-space:nowrap">
         <a href='<%= ResolveClientUrl("~")%>ReportSection/statusFullPage.aspx' target='_blank' class="readonlyText">Complete Status in Graph</a>
       </td>

    </tr>
    <tr>
       <td style="white-space:nowrap">
         <a href='<%= ResolveClientUrl("~")%>ReportSection/SocialEconomicIndicatorReport.aspx' target='_blank' class="readonlyText">Social Economic Indicator</a>
       </td>

    </tr>
</table>

</asp:Content>

