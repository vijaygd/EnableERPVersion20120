<%@ Page Language="C#" Culture="en-GB" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="EnableIndiaTLReports.Test1.Test1" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test bdp</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
                 <td valign="middle" align="center">
                 <div>
                          <BDP:BasicDatePicker ID="BasicDatePicker1" runat="server" AutoPostBack="True"    DateFormat="dd-MM-yyyy" Style="width:100px;" />
                 </div>
              </td>
</tr>

    </table>
    <table>
    <tr>
                  <td  valign="middle" align="center">
                  <BDP:BasicDatePicker runat="server" ID="dtStartDate" DateFormat="dd/MM/yyyy"  AutoPostBack="true" Style="width:100px;"    ></BDP:BasicDatePicker>
              </td>
 
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
