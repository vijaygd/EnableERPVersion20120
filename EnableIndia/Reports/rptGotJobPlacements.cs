namespace EnableIndia
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using MySql;
    using MySql.Data;
    using MySql.Web;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Summary description for rptGotJobPlacements.
    /// </summary>
    public partial class rptGotJobPlacements : Telerik.Reporting.Report
    {
        public rptGotJobPlacements()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}