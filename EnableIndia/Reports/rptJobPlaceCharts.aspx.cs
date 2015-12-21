using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI.DataVisualization;
using System.Globalization;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

using Color = System.Drawing.Color;
using Font = System.Drawing.Font;

namespace EiAdmin
{
    public partial class rptJobPlaceCharts : System.Web.UI.Page
    {
        public int intSize;
        string sTotDays;
        string[] saTotDays;
        public DataTable myDt;
        // Maximum of 48 intervals are provided here as safety.
        int[] noDaysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-gb");
        public bool pbFlag;
        string[] xLabels;
        string[] alphaMonhts = {"", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
        public int noIntervals;
        public string countIndex;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.lbStartDate.Text = Request.QueryString["StartDate"];
                this.lbEndDate.Text = Request.QueryString["EndDate"];
                this.lbStartDate.Text = this.lbStartDate.Text.ToString().TrimStart().TrimEnd();
                this.lbEndDate.Text = this.lbEndDate.Text.ToString().TrimStart().TrimEnd();

                this.lbTitle.Text = Request.QueryString["Title"];
                this.lbInterval.Text = Request.QueryString["NoIntervals"];
                noIntervals = Convert.ToInt32(this.lbInterval.Text);
                this.lbTotDays.Text = Request.QueryString["TotDays"] + " Days";
                this.lbNoRecs.Text = Request.QueryString["NoRecs"];
                if (!string.IsNullOrEmpty(Request.QueryString["IntSize"].ToString()))
                {
                    intSize = Convert.ToInt32(Request.QueryString["IntSize"]);
                    this.lbIntSize.Text = intSize.ToString();
                    ViewState["intSize"] = this.lbIntSize.Text;
                }
                sTotDays = Request.QueryString["sTotDays"];
                countIndex = Request.QueryString["countIndex"].ToString();
                ViewState["noIntervals"] = noIntervals;
                ViewState["sTotDays"] = sTotDays;
                fillXlabels();
                FillChart();
                myDt = (DataTable)Session["myDt"];
                ViewState["myDt"] = myDt;
                ViewState["countIndex"] = countIndex;
                pbFlag = false;
            }
            if (Page.IsPostBack)
            {
                if (ViewState["myDt"] != null)
                {
                    myDt = (DataTable)(ViewState["myDt"]);
                }
                if (ViewState["sTotDays"] != null)
                {
                    sTotDays = ViewState["sTotDays"].ToString();
                }
                if (ViewState["intSize"] != null)
                {
                    intSize = Convert.ToInt32(ViewState["intSize"]);
                }
                pbFlag = true;
                if (ViewState["noIntervals"] != null)
                {
                    noIntervals = Convert.ToInt32(ViewState["noIntervals"]);
                }
                if (ViewState["xLabels"] != null)
                {
                    xLabels = (string[])ViewState["xLabels"];
                }
                if (ViewState["countIndex"] != null)
                {
                    countIndex = ViewState["countIndex"].ToString();

                }
            }
        }
        private byte[] FillChart()
        {
            if (pbFlag)
            {
                if (ViewState["xLabels"] != null)
                {
                    xLabels = (string[])ViewState["xLabels"];
                }
            }
            DateTime dt1 = DateTime.Today;
            DateTime dt2 = DateTime.Today;
            try
            {

                dt1 = Convert.ToDateTime(this.lbStartDate.Text, cultureinfo);
                dt2 = Convert.ToDateTime(this.lbEndDate.Text, cultureinfo);
            }
            catch (System.Exception ex)
            {
               Response.Write("</br>Error M: " + ex.Message + ": " + dt1 + ": " + dt2);
            }
            try
            {
                double dnoCandidates = 0;
                int i = 0;
                int j = 0;
                dt2 = dt2.AddDays(15);
                if (string.IsNullOrEmpty(sTotDays)) return (null);
                saTotDays = sTotDays.Split((char)':');
                this.ytdSalesT.Series["ytdSalesSeriesT"].SmartLabelStyle.Enabled = false;
                this.ytdSalesT.ChartAreas[0].AxisX.Title = "Months";
                this.ytdSalesT.ChartAreas[0].AxisY.Title = " Candidate Numbers";
                this.ytdSalesT.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
                this.ytdSalesT.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
                this.ytdSalesT.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.ytdSalesT.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.ytdSalesT.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                this.ytdSalesT.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                this.ytdSalesT.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
                this.ytdSalesT.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.ytdSalesT.ChartAreas[0].AxisX.Interval = 1;
                this.ytdSalesT.BorderSkin.SkinStyle = System.Web.UI.DataVisualization.Charting.BorderSkinStyle.Emboss;
                //for (i = 0; i < saTotDays.GetLength(0); i++)
                for(i = 0;i < noIntervals;i++)
                {
                    if (string.IsNullOrEmpty(saTotDays[i])) continue;
                    dnoCandidates = Convert.ToDouble(saTotDays[i].ToString());
                    // this.ytdSalesT.Series["ytdSalesSeriesT"].Points.AddY(dnoCandidates);
                    //                this.ytdSalesT.ChartAreas[0].AxisX.CustomLabels.Add(Convert.ToDouble((i + 1) - 0.5), Convert.ToDouble((i + 1) + 0.5), dt1.ToString("dd:MM:yy") + "-" + dt2.ToString("dd:MM:yy"), 1, System.Web.UI.DataVisualization.Charting.LabelMarkStyle.None);
                    //weekOfTheDay = GetIso8601WeekOfYear(dt1); // WeeksInYear(dt1);
                    //weekOfTheDay = (weekOfTheDay > 52) ? 1 : weekOfTheDay;
                    // this.ytdSalesT.ChartAreas[0].AxisX.CustomLabels.Add(Convert.ToDouble((i + 1) - 0.5), Convert.ToDouble((i + 1) + 0.5), weekOfTheDay.ToString(), 1, System.Web.UI.DataVisualization.Charting.LabelMarkStyle.None);
                    this.ytdSalesT.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
                    // this.ytdSalesT.Series["ytdSalesSeriesT"].Points.AddXY(weekOfTheDay, dnoCandidates);
                    this.ytdSalesT.Series[0].Points[i].Label = dnoCandidates.ToString();
                    if(!pbFlag)
                    {
                        dt1 = dt1.AddDays(intSize);
                    }
                    else
                    {
                        switch (this.ddIntPeriod.SelectedIndex)
                        {
                            case 1: dt1 = dt1.AddDays(noDaysInMonth[i]);
                                break;
                            case 2:
                                for (j = i; j < (i + 2); j++)
                                {
                                    dt1 = dt1.AddDays(noDaysInMonth[j]);
                                }
                                break;

                            case 3:
                                for (j = i; j < (i + 3); j++)
                                {
                                    dt1 = dt1.AddDays(noDaysInMonth[j]);
                                }
                                break;
                            case 4:
                                for (j = i; j < (i + 6); j++)
                                {
                                    dt1 = dt1.AddDays(noDaysInMonth[j]);
                                }
                                break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                this.lbStatus.Text = "Error Chart: " +  ex.Message + "D1: " + dt1.ToString() + ": " + dt2.ToString();
            }
            var chartImage = new MemoryStream();
            //chart.SaveImage(chartimage, ChartImageFormat.Png);
            this.ytdSalesT.SaveImage(chartImage, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
            return chartImage.GetBuffer();
        }
        public int WeeksInYear(DateTime date)
        {
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);

           // System.Web.UI.WebControls.Calendar cal = CultureInfo.InvariantCulture.Calendar; 
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
        public int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        } 
        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }
        protected void ddIntervalChanged(object sender, EventArgs e)
        {
            if (this.ddIntPeriod.SelectedIndex <= 0)
                return;
            try
            {
                int i = 0;
                int j = 0;
                int k = 0;
                int iMaxCount = 0;
                int iDiff1 = 0;
                int iDiff2 = 0;
                int iTotDays = 0;
                string[] cultureNames = { "en-US", "ru-RU","ja-JP" };
                 sTotDays = "";
                //Response.Write(this.lbStartDate.Text + " : ");
                //Response.Write(this.lbEndDate.Text);
                DateTime stDate = Convert.ToDateTime(this.lbStartDate.Text.Trim(), cultureinfo); // this.dtStartDate.SelectedDate;
                DateTime edDate = Convert.ToDateTime(this.lbEndDate.Text.Trim(), cultureinfo);  // this.dtEndDate.SelectedDate;
                DateTime d1 = Convert.ToDateTime(this.lbStartDate.Text.Trim(), cultureinfo); // this.dtStartDate.SelectedDate;
                DateTime d2 = Convert.ToDateTime(this.lbEndDate.Text.Trim(), cultureinfo); //this.dtEndDate.SelectedDate;
                int iDiff = DateTime.Compare(d1, d2);
                if (iDiff >= 0)
                {
                    //this.lbStatus.Text = "Start date > than end date";
                    return;
                }
                double df = (d2 - d1).TotalDays + 1;
                if (df < 15)
                {
                    //this.lbStatus.Text = "Too less Days to chart";
                    return;
                }
                // ------------------------------------------------
                // Find number of intervals  for chart 
                // ------------------------------------------------
                 int intSize = 0;

                switch (this.ddIntPeriod.SelectedValue)
                {
                    case "M": intSize = 30; iMaxCount = 1; break;
                    case "I": intSize = 60; iMaxCount = 2; break;
                    case "Q": intSize = 90; iMaxCount = 3; break;
                    case "H": intSize = 180; iMaxCount = 6; break;
                }
                ViewState["intSize"] = intSize;
                int sintSize = intSize;
                for (i = 0; ; i++)
                {
                    noIntervals = (int)df / intSize;
                    if (noIntervals < 20) break;
                    intSize += sintSize;
                }
                if (((int)df % intSize) > 0) noIntervals++;
                // ---------------------------------------------------------------
                // Startcounting the number of records under each of the intervals
                // ---------------------------------------------------------------
                sTotDays = "";
                int iMonth = 0;
                int pIntSize = 0;
                int iactIntSize = 0;
                bool bFtran = false;
                bool bLtran = false;
                ViewState["noIntervals"] = noIntervals;
                for(i = 0;i < noIntervals;i++)
                {
                    bFtran = false;
                    bLtran = false;
                    if (i > 0)
                    {
                        iDiff1 = DateTime.Compare(d1, Convert.ToDateTime(this.lbEndDate.Text.Trim(), cultureinfo));
                        if (iDiff1 >= 0)
                        {
                            break;
                        }
                    }
                    iTotDays = 0;
                    iactIntSize = 0;
                    iMonth = (i == 0) ? d1.Month : d2.Month;
                    for (k = 0; k < iMaxCount; k++)
                    {
                        if (i == 0)
                        {
                            if (d1.Day == 1)
                            {
                                iactIntSize += noDaysInMonth[iMonth - 1];
                                bFtran = true;
                            }
                            else
                            {
                                iactIntSize += (noDaysInMonth[iMonth - 1] - d1.Day) + 1;
                                bFtran = true;
                            }
                        }
                        if (i == (noIntervals - 1))
                        {
                            if(d1.Day == noDaysInMonth[iMonth])
                            {
                                iactIntSize += noDaysInMonth[iMonth - 1];
                                bLtran = true;
                            }
                            else
                            {
                                iactIntSize += (Convert.ToDateTime(this.lbEndDate.Text.Trim(), cultureinfo)).Day;
                                bLtran = true;
                            }
                        }
                        if (!bFtran && !bLtran)
                        {
                            iactIntSize += noDaysInMonth[iMonth - 1];
                        }
                        if ((d1.Year % 4) == 0) iactIntSize++;
                        iMonth++;
                        if (iMonth > 12) iMonth = 1;
                    }
                    if(i == 0)
                    {
                        d2 = d1.AddDays(iactIntSize);
                    }
                    else
                    {
                       d1 = d1.AddDays(pIntSize);
                       d2 = d2.AddDays(iactIntSize);
                    }
                    foreach (DataRow dr in myDt.Rows)
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(dr[Convert.ToInt32(countIndex)].ToString())) continue;
                            DateTime sDt = Convert.ToDateTime(dr[Convert.ToInt32(countIndex)]);
                            iDiff1 = DateTime.Compare(sDt, d1);
                            iDiff2 = DateTime.Compare(sDt, d2);
                            if (iDiff1 >= 0 && iDiff2 < 0)
                                iTotDays++;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    sTotDays += iTotDays.ToString() + ":";
                    pIntSize = iactIntSize;
                }
                ViewState["sTotDays"] = sTotDays;
                this.lbIntSize.Text = intSize.ToString();
                this.lbInterval.Text = noIntervals.ToString();
                // Remove last null and 0 value entries.
                saTotDays = sTotDays.Split((char)':');
                sTotDays = "";
                for (i = saTotDays.GetLength(0) - 1; i >= 0; i--)
                {
                    string svalue = saTotDays[i]; 
                    if (string.IsNullOrEmpty(svalue)) continue;
                    if (Convert.ToInt32(svalue) != 0) break;
                }
                for (k = 0; k <= i; k++)
                {
                    sTotDays += saTotDays[k] + ":";
                }
                this.lbInterval.Text = k.ToString();
                noIntervals = k;
                ViewState["noIntervals"] = noIntervals;
                fillXlabels();
                FillChart();
            }
            catch (System.Exception ex)
            {
                this.lbStatus.Text = "Er: " + this.lbEndDate.Text;
            }
        }
        protected void prtButton_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate());
                string fName = "Chart" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString() +
                          DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + ".pdf";
                var pdfFile = Server.MapPath("~/TempImageFiles/" + fName);
                PdfWriter pDoc = PdfWriter.GetInstance(doc, new FileStream(pdfFile, FileMode.Create));
                pDoc.PageEvent = new MyPdfPageEventHelpPageNo();
                doc.Open();
                float[] mwidths = new float[] { 360, 360 };
                PdfPTable pdft = new PdfPTable(2);
                pdft.SetWidths(mwidths);
                PdfPCell leftCell = new PdfPCell();
                PdfPCell rightCell = new PdfPCell();
                rightCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //Dim yourFont As BaseFont = BaseFont.CreateFont( _  Current.Server.MapPath("~/fonts/somefont.TTF"), _  BaseFont.WINANSI, BaseFont.EMBEDDED)
                //Dim mainFont As New Font(yourFont, SOME_FONT_SIZE, Font.NORMAL)
                doc.Add(new Phrase(Environment.NewLine));
                leftCell.Phrase = new Phrase("Candidate - " + this.lbTitle.Text);
                rightCell.Phrase = new Phrase(" ");
                leftCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                rightCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                leftCell.BorderColorTop = new BaseColor(0, 0, 255);
                rightCell.BorderColorTop = new BaseColor(0, 0, 255);
                leftCell.BorderWidthTop = 0.2f;
                rightCell.BorderWidthTop = 0.2f;
                pdft.AddCell(leftCell);
                pdft.AddCell(rightCell);
                leftCell.Border = 0;
                rightCell.Border = 0;
                leftCell.Phrase = new Phrase("Period: " + this.lbStartDate.Text + " to " + this.lbEndDate.Text);
                rightCell.Phrase = new Phrase("No Candidates: " + this.lbNoRecs.Text);
                pdft.AddCell(leftCell);
                pdft.AddCell(rightCell);
                leftCell.Phrase = new Phrase("Number of Days: " + this.lbTotDays.Text.ToString());
                rightCell.Phrase = new Phrase("Doc Date: " + DateTime.Today.ToString("dd/MM/yyyy"));
                leftCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                rightCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                leftCell.BorderColorBottom = new BaseColor(0, 0, 255);
                rightCell.BorderColorBottom = new BaseColor(0, 0, 255);
                leftCell.BorderWidthBottom = 0.2f;
                rightCell.BorderWidthBottom = 0.2f;
                pdft.AddCell(leftCell);
                pdft.AddCell(rightCell);
                doc.Add(pdft);
                doc.Add(new Phrase(Environment.NewLine));
                doc.Add(new Phrase(Environment.NewLine));
                var image = iTextSharp.text.Image.GetInstance(FillChart());   // System.Drawing.Image.GetInstance(Chart());
                image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                image.ScalePercent(75f);
                doc.Add(image);
                doc.Close();
                string sigPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
                string physicalPath = Server.MapPath("~/TempImageFiles");
                string oPdfFile = physicalPath + "\\" + pdfFile;
                string vdocPdf = physicalPath.Replace("\\", "/");
                vdocPdf += "/" + fName;
                HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment; filename=\"" + Path.GetFileName(pdfFile) + "\";");
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.TransmitFile(vdocPdf);
                HttpContext.Current.Response.End();
              //  File.Delete(oPdfFile);

            }
            catch (System.Exception ex)
            {
                Response.Write("Error: " + ex.Message);
                Response.End();
            }

        }
        //public string resolveVirtual(string physicalPath)
        //{
        //   // string url = physicalPath.Substring(Globals..Length).Replace('\\', '/').Insert(0, "~/");
        //   // return (url);
        //}
        private void fillXlabels()
        {
            int i = 0;
            int j = 0;
            int sMonth = 0;
            int eMonth = 0;
            DateTime d1 = Convert.ToDateTime(this.lbStartDate.Text.Trim(), cultureinfo); // this.dtStartDate.SelectedDate;
            DateTime d2 = Convert.ToDateTime(this.lbStartDate.Text.Trim(), cultureinfo); //this.dtEndDate.SelectedDate;
            if (ViewState["noIntervals"] != null)
            {
                noIntervals = Convert.ToInt32(ViewState["noIntervals"]);
            }
            if (!pbFlag)
            {
                xLabels = new string[Convert.ToInt32(this.lbInterval.Text)];
                d2 = d2.AddDays(intSize);
                for (i = 0; i < Convert.ToInt32(this.lbInterval.Text); i++)
                {
                    sMonth = d1.Month;
                    eMonth = d2.Month;
                    xLabels[i] = alphaMonhts[sMonth] + "-" + alphaMonhts[eMonth];
                    d1 = d1.AddDays(intSize);
                    d2 = d2.AddDays(intSize);
                }
            }
            else
            {
                int noDays = 0;
                xLabels = new string[Convert.ToInt32(noIntervals + 1)];
                for (i = 0; i < noIntervals; i++)
                {
                    noDays = 0;
                    switch (this.ddIntPeriod.SelectedIndex)
                    {
                        case 1: 
                            noDays = noDaysInMonth[d1.Month - 1];
                            break;
                        case 2:
                            for (j = i; j < (i + 2); j++)
                            {
                                noDays += noDaysInMonth[j];
                            }
                            break;

                        case 3:
                            for (j = i; j < (i + 3); j++)
                            {
                                noDays += noDaysInMonth[j];
                            }
                            break;
                        case 4:
                            for (j = i; j < (i + 6); j++)
                            {
                                noDays += noDaysInMonth[j];
                            }
                            break;
                    }
                    d2 = d2.AddDays(noDays);
                    sMonth = d1.Month;
                    eMonth = d2.Month;
                    xLabels[i] = alphaMonhts[sMonth] + "-" + alphaMonhts[eMonth];
                    d1 = d1.AddDays(noDays);

                }
            }
            ViewState["xLabels"] = xLabels;

        }
        public class MyPdfPageEventHelpPageNo : iTextSharp.text.pdf.PdfPageEventHelper
        {
            //Create object of PdfContentByte
            PdfContentByte pdfContent;
            protected PdfTemplate total;
            protected BaseFont helv;
            private bool settingFont = false;
            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                total = writer.DirectContent.CreateTemplate(100, 100);
                total.BoundingBox = new iTextSharp.text.Rectangle(-20, -20, 100, 100);
                helv = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
            }

            public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
            {
                base.OnStartPage(writer, document);
                int i = 0;
                PdfPTable ptab = new PdfPTable(1);
                ptab.TotalWidth = 720; // 6.5F;
                ptab.HorizontalAlignment = Element.ALIGN_CENTER;
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                PdfPCell pcellH = new PdfPCell();
                Phrase ph = new Phrase();
                ph.Add(new Chunk("Enable India", boldFont));
                pcellH.Phrase = ph;
                pcellH.HorizontalAlignment = 1;
                pcellH.MinimumHeight = 0.4f;
                pcellH.VerticalAlignment = Element.ALIGN_LEFT;
                pcellH.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                float[] f = new float[] { 720 };
                ptab.SetWidths(f);
                pcellH.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                pcellH.BorderColorBottom = new BaseColor(0, 0, 255);
                pcellH.BorderWidthBottom = 0.3f;

                ptab.AddCell(pcellH);
                ptab.WriteSelectedRows(0, -1, 72, (document.PageSize.Height - 10), writer.DirectContent);
                document.Add(new Phrase(Environment.NewLine));


            }
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);
                PdfPTable tabFot = new PdfPTable(2);
                //  tabFot.TotalWidth = document.PageSize.Width - (document.LeftMargin + document.RightMargin);
                tabFot.TotalWidth = 720;
                float[] f = new float[] { 360, 360 };
                tabFot.SetWidths(f);
                tabFot.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell cell1 = new PdfPCell();
                PdfPCell cell2 = new PdfPCell();
                cell1.Phrase = new Phrase("Status Report");
                cell1.PaddingLeft = 2;
                cell2.Phrase = new Phrase("Page: " + document.PageNumber.ToString());
                cell2.HorizontalAlignment = 2;
                cell1.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                cell2.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                cell2.PaddingRight = 2;
                cell1.BorderColorTop = new BaseColor(0, 0, 255);
                cell2.BorderColorTop = new BaseColor(0, 0, 255);
                cell1.BorderWidthTop = 0.3f;
                cell2.BorderWidthTop = 0.3f;
                tabFot.AddCell(cell1);
                tabFot.AddCell(cell2);

                //                document.Add(tabFot);
                float leftMargin = document.PageSize.Width - 720;
                tabFot.WriteSelectedRows(0, -1, 72, (document.Bottom - 5), writer.DirectContent);

            }

        }

    }
}