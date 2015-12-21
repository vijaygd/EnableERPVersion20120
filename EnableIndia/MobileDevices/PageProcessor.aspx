<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="PageProcessor.aspx.cs" Inherits="EnableIndia.MobileDevices.PageProcessor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style  type="text/css">
    .container {
          background: transparent;
          position: absolute;
          top : 30%;
          left : 0px;
          width: 100%;
          overflow: visible;
          visibility: visible;
          display: block;
          text-align:center;
        }

        .announce {
          margin:0px auto;
          position  :relative;
          top : -15px;
          height : 300px;
          visibility: visible;
          width:60%;
        }
    </style>
    <script src="../Scripts/jquery-2.1.4.min.js"></script>

        <script type="text/javascript">
            $(window).load(function () {
                // run code
                BeginPageLoad();
            });
            $(window).unload(function () {
                EndPageLoad();
            });
        var iLoopCounter = 1;
        var iMaxLoop = 30;
        var iIntervalId;
        function BeginPageLoad()
        {
            animateGif();
            location.href = "<%=Ppw%>";
            iIntervalId = window.setInterval('iLoopCounter=UpDateProgressMeter(iLoopCounter, iMaxLoop)', 1200);
        }
        function UpDateProgressMeter(iCurrentLoopCounter, iMaximumLoops)
        {
            iCurrentLoopCounter = iCurrentLoopCounter + 1;
            if(iCurrentLoopCounter <= iMaximumLoops){
                return (iCurrentLoopCounter);
            }
            else {
                iCurrentLoopCounter = 1;
                return(iCurrentLoopCounter);
            }  
        }
        function EndPageLoad()
        {
            window.clearInterval(iIntervalId);
        }
        function animateGif() {
            var isIE = (navigator.userAgent.indexOf("MSIE") != -1);
            if (!isIE) {
                isIE = (navigator.userAgent.indexOf("Trident") != -1);
            }
            var pb = document.getElementById("progressBar");
            if (isIE) {
                pb.innerHTML = '<img src="../Image/pleasewait.gif" width="30" height ="30"/>';
            }
            pb.style.display = '';
        }
    </script>
    <div class="container">
    <div class="announce">
    <table style="width:100%;  text-align:center; vertical-align:middle; border:2px; border-collapse:separate; border-spacing:0px; border-width:0px; text-align:center;">
    <tr>
        <td style="vertical-align:middle; text-align:center;border-bottom: 2px solid blue; border-top: 2px solid blue; text-align:center;">
            <asp:Label runat="server" ID="lbEut" Text="Enable India" Font-Bold="true" Font-Size="26" ForeColor="#d32232" Font-Names="Consolas"></asp:Label>
        </td>
    </tr>
       <tr>
          <td style="text-align:center; vertical-align:middle; text-align:center;">
              <p style="text-align:center; font-family:Consolas; font-size:17px;">
               <asp:Literal runat="server" ID="lbAdvertisement" Text="Generating All Registered Candidates information" ></asp:Literal>
              </p>
         </td>
    </tr>
    <tr >
        <td  style="font:arial; font-size:medium; text-align:center; vertical-align:middle;">
          <div id="progressBar" style="vertical-align: middle; display: none;">
            <asp:Image runat="server" ID="imgBlockUI" ImageAlign="AbsMiddle" ImageUrl="~/Image/pleasewait.gif" />
         </div>
        </td>
    </tr>
    <tr>
    <td style="font-size:medium; font-style:normal; vertical-align:middle; text-align:center;border-bottom: 2px solid blue;">
        <asp:Label runat="server" ID="lbPlWait" Text="Please wait Loading the Page" Font-Bold="true" Font-Size="14" ForeColor="DarkBlue" Font-Names="Verdana"></asp:Label>
    </td>
    </tr> 
    </table>   
  </div>

    </div>

</asp:Content>
