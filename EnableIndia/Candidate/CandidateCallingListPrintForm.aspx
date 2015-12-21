<%@ Page Language="C#" AutoEventWireup="true" Inherits="EnableIndia.Candidate.CandidateCallingListPrintForm" Codebehind="CandidateCallingListPrintForm.aspx.cs" ClientIDMode="Static" %>

<%@ Register Assembly="Stimulsoft.Report.Web, Version=2013.1.1600.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a"
    Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Candidate Calling List Form</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width:100%;height:100%">
        <tr>
            <td>
                <cc1:StiWebViewer ID="StiWebViewer1" runat="server" RenderMode="UseCache" ViewMode="WholeReport"
                    Height="600px" Width="100%" ScrollBarsMode="true" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
