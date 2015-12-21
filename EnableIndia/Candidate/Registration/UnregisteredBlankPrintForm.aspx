<%@ Page Language="C#"  AutoEventWireup="true" Inherits="EnableIndia.Candidate.Registration.UnregisteredBlankPrintForm" Codebehind="UnregisteredBlankPrintForm.aspx.cs" ClientIDMode="Static" %>

<%@ Register Assembly="Stimulsoft.Report.Web, Version=2013.1.1600.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a"
    Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
     <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="cache-control" content="no-store" />
    <meta http-equiv="cache-control" content="private" />
    <meta http-equiv="cache-control" content="max-age=0, must-revalidate" />
    <meta http-equiv="expires" content="now-1" />
    <meta http-equiv="pragma" content="no-cache" />
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%;height:100%">
        <tr>
            <td>
                <cc1:StiWebViewer ID="StiWebViewer1" runat="server" RenderMode="UseCache" ViewMode="WholeReport"
                    Height="600px" Width="100%" ScrollBarsMode="true" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
