<%@ Page Language="C#" Culture="en-GB" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="EnableIndia.Test1.Test1" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=9" />
<meta http-equiv="Page-Enter" content="Alpha(opacity=100)"/>
    <title>Test bdp</title>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
    <table>
        <tr>
                 <td valign="middle" align="center">
                     <BDP:BasicDatePicker ID="dtEndDate" runat="server" AutoPostBack="True"    DateFormat="dd-MM-yyyy" Style="width:100px;" />
              </td>
</tr>

    </table>
    <table>
    <tr>
                  <td  valign="middle" align="center">
                  <BDP:BasicDatePicker runat="server" ID="dtStartDate" DateFormat="dd-MM-yyyy"  AutoPostBack="true" Style="width:100px;z-index: 100000;"    ></BDP:BasicDatePicker>
              </td>
 
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
