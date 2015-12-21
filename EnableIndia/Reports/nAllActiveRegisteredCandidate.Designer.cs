namespace EnableIndia.Reports
{
    partial class nAllActiveRegisteredCandidate
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.i1DataTextBox = new Telerik.Reporting.TextBox();
            this.phone_numbersDataTextBox = new Telerik.Reporting.TextBox();
            this.email_addressDataTextBox = new Telerik.Reporting.TextBox();
            this.ngo_nameDataTextBox = new Telerik.Reporting.TextBox();
            this.unemployed_daysDataTextBox = new Telerik.Reporting.TextBox();
            this.unemployed_since_daysDataTextBox = new Telerik.Reporting.TextBox();
            this.recommended_job_typesDataTextBox = new Telerik.Reporting.TextBox();
            this.recommended_job_rolesDataTextBox = new Telerik.Reporting.TextBox();
            this.designationDataTextBox = new Telerik.Reporting.TextBox();
            this.company_nameDataTextBox = new Telerik.Reporting.TextBox();
            this.date_of_joinDataTextBox = new Telerik.Reporting.TextBox();
            this.contract_expiry_dateDataTextBox = new Telerik.Reporting.TextBox();
            this.registration_date1DataTextBox = new Telerik.Reporting.TextBox();
            this.salaryDataTextBox = new Telerik.Reporting.TextBox();
            this.registration_idDataTextBox = new Telerik.Reporting.TextBox();
            this.candidate_idDataTextBox = new Telerik.Reporting.TextBox();
            this.registration_dateDataTextBox = new Telerik.Reporting.TextBox();
            this.role_nameDataTextBox = new Telerik.Reporting.TextBox();
            this.educational_qualificationDataTextBox = new Telerik.Reporting.TextBox();
            this.disability_typeDataTextBox = new Telerik.Reporting.TextBox();
            this.date_of_birthDataTextBox = new Telerik.Reporting.TextBox();
            this.candidate_nameDataTextBox = new Telerik.Reporting.TextBox();
            this.designation_expiry_dateDataTextBox = new Telerik.Reporting.TextBox();
            this.labelsGroupFooter = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeader = new Telerik.Reporting.GroupHeaderSection();
            this.registration_idCaptionTextBox = new Telerik.Reporting.TextBox();
            this.candidate_idCaptionTextBox = new Telerik.Reporting.TextBox();
            this.registration_dateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.designation_expiry_dateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.candidate_nameCaptionTextBox = new Telerik.Reporting.TextBox();
            this.date_of_birthCaptionTextBox = new Telerik.Reporting.TextBox();
            this.disability_typeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.educational_qualificationCaptionTextBox = new Telerik.Reporting.TextBox();
            this.i1CaptionTextBox = new Telerik.Reporting.TextBox();
            this.phone_numbersCaptionTextBox = new Telerik.Reporting.TextBox();
            this.email_addressCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ngo_nameCaptionTextBox = new Telerik.Reporting.TextBox();
            this.unemployed_daysCaptionTextBox = new Telerik.Reporting.TextBox();
            this.recommended_job_typesCaptionTextBox = new Telerik.Reporting.TextBox();
            this.role_nameCaptionTextBox = new Telerik.Reporting.TextBox();
            this.company_nameCaptionTextBox = new Telerik.Reporting.TextBox();
            this.contract_expiry_dateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.salaryCaptionTextBox = new Telerik.Reporting.TextBox();
            this.registration_date1CaptionTextBox = new Telerik.Reporting.TextBox();
            this.date_of_joinCaptionTextBox = new Telerik.Reporting.TextBox();
            this.designationCaptionTextBox = new Telerik.Reporting.TextBox();
            this.recommended_job_rolesCaptionTextBox = new Telerik.Reporting.TextBox();
            this.unemployed_since_daysCaptionTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "EnableIndiaConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@para_qualification_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_is_profiled", System.Data.DbType.String, "All"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_employment_status", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_assignment", System.Data.DbType.String, "All"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_state_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_city_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_age_group", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_ngo_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_disability_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_disability_sub_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_search_for", System.Data.DbType.String, null),
            new Telerik.Reporting.SqlDataSourceParameter("@para_search_in", System.Data.DbType.String, "registration_id"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_current_date", System.Data.DbType.Date, "2014/04/08"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_recommended_job_type_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_recommended_job_role_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_missing_data_in_profile", System.Data.DbType.String, "All"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_group_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_langauge_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_gender", System.Data.DbType.String, "All"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_company_id", System.Data.DbType.Int32, "-1"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_registration_from_date", System.Data.DbType.Date, "1900/01/01"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_registration_to_date", System.Data.DbType.Date, "5000/01/01"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_date_of_birth", System.Data.DbType.Date, "1900/01/01"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_employment_start_from_date", System.Data.DbType.Date, "1900/01/01"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_employment_start_to_date", System.Data.DbType.Date, "5000/01/01"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_employment_end_from_date", System.Data.DbType.Date, "1900/01/01"),
            new Telerik.Reporting.SqlDataSourceParameter("@para_employment_end_to_date", System.Data.DbType.Date, "5000/01/01"),
            new Telerik.Reporting.SqlDataSourceParameter("@salary_from", System.Data.DbType.Decimal, "0000"),
            new Telerik.Reporting.SqlDataSourceParameter("@salary_to", System.Data.DbType.Decimal, "100000")});
            this.sqlDataSource1.SelectCommand = "enable_india.rpt_all_active_registered_candidates";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportNameTextBox});
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4333333969116211D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.reportNameTextBox.Style.Font.Bold = true;
            this.reportNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "All Active Candidates";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2083332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(23.737539291381836D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2083332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // detail
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("= RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "1"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.detail.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.31666666269302368D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.i1DataTextBox,
            this.phone_numbersDataTextBox,
            this.email_addressDataTextBox,
            this.ngo_nameDataTextBox,
            this.unemployed_daysDataTextBox,
            this.unemployed_since_daysDataTextBox,
            this.recommended_job_typesDataTextBox,
            this.recommended_job_rolesDataTextBox,
            this.designationDataTextBox,
            this.company_nameDataTextBox,
            this.date_of_joinDataTextBox,
            this.contract_expiry_dateDataTextBox,
            this.registration_date1DataTextBox,
            this.salaryDataTextBox,
            this.registration_idDataTextBox,
            this.candidate_idDataTextBox,
            this.registration_dateDataTextBox,
            this.role_nameDataTextBox,
            this.educational_qualificationDataTextBox,
            this.disability_typeDataTextBox,
            this.date_of_birthDataTextBox,
            this.candidate_nameDataTextBox,
            this.designation_expiry_dateDataTextBox});
            this.detail.Name = "detail";
            // 
            // i1DataTextBox
            // 
            this.i1DataTextBox.CanGrow = true;
            this.i1DataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.58988094329834D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.i1DataTextBox.Name = "i1DataTextBox";
            this.i1DataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1029927730560303D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.i1DataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.i1DataTextBox.StyleName = "Data";
            this.i1DataTextBox.Value = "=Fields.i1";
            // 
            // phone_numbersDataTextBox
            // 
            this.phone_numbersDataTextBox.CanGrow = true;
            this.phone_numbersDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.6929931640625D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.phone_numbersDataTextBox.Name = "phone_numbersDataTextBox";
            this.phone_numbersDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4581745862960815D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.phone_numbersDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.phone_numbersDataTextBox.StyleName = "Data";
            this.phone_numbersDataTextBox.Value = "=Fields.phone_numbers";
            // 
            // email_addressDataTextBox
            // 
            this.email_addressDataTextBox.CanGrow = true;
            this.email_addressDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(12.151247024536133D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.email_addressDataTextBox.Name = "email_addressDataTextBox";
            this.email_addressDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.email_addressDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.email_addressDataTextBox.StyleName = "Data";
            this.email_addressDataTextBox.Value = "=Fields.email_address";
            // 
            // ngo_nameDataTextBox
            // 
            this.ngo_nameDataTextBox.CanGrow = true;
            this.ngo_nameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(13.392992973327637D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.ngo_nameDataTextBox.Name = "ngo_nameDataTextBox";
            this.ngo_nameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0070068836212158D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.ngo_nameDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ngo_nameDataTextBox.StyleName = "Data";
            this.ngo_nameDataTextBox.Value = "=Fields.ngo_name";
            // 
            // unemployed_daysDataTextBox
            // 
            this.unemployed_daysDataTextBox.CanGrow = true;
            this.unemployed_daysDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(14.400079727172852D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.unemployed_daysDataTextBox.Name = "unemployed_daysDataTextBox";
            this.unemployed_daysDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.044921875D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.unemployed_daysDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.unemployed_daysDataTextBox.StyleName = "Data";
            this.unemployed_daysDataTextBox.Value = "=Fields.unemployed_days";
            // 
            // unemployed_since_daysDataTextBox
            // 
            this.unemployed_since_daysDataTextBox.CanGrow = true;
            this.unemployed_since_daysDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(15.445080757141113D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.unemployed_since_daysDataTextBox.Name = "unemployed_since_daysDataTextBox";
            this.unemployed_since_daysDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80700480937957764D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.unemployed_since_daysDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.unemployed_since_daysDataTextBox.StyleName = "Data";
            this.unemployed_since_daysDataTextBox.Value = "=Fields.unemployed_since_days";
            // 
            // recommended_job_typesDataTextBox
            // 
            this.recommended_job_typesDataTextBox.CanGrow = true;
            this.recommended_job_typesDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(16.252162933349609D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.recommended_job_typesDataTextBox.Name = "recommended_job_typesDataTextBox";
            this.recommended_job_typesDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4998453855514526D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.recommended_job_typesDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.recommended_job_typesDataTextBox.StyleName = "Data";
            this.recommended_job_typesDataTextBox.Value = "=Fields.recommended_job_types";
            // 
            // recommended_job_rolesDataTextBox
            // 
            this.recommended_job_rolesDataTextBox.CanGrow = true;
            this.recommended_job_rolesDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(17.752084732055664D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.recommended_job_rolesDataTextBox.Name = "recommended_job_rolesDataTextBox";
            this.recommended_job_rolesDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4082560539245606D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.recommended_job_rolesDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.recommended_job_rolesDataTextBox.StyleName = "Data";
            this.recommended_job_rolesDataTextBox.Value = "=Fields.recommended_job_roles";
            // 
            // designationDataTextBox
            // 
            this.designationDataTextBox.CanGrow = true;
            this.designationDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(20.400077819824219D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.designationDataTextBox.Name = "designationDataTextBox";
            this.designationDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2998453378677368D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.designationDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.designationDataTextBox.StyleName = "Data";
            this.designationDataTextBox.Value = "=Fields.designation";
            // 
            // company_nameDataTextBox
            // 
            this.company_nameDataTextBox.CanGrow = true;
            this.company_nameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(21.700000762939453D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.company_nameDataTextBox.Name = "company_nameDataTextBox";
            this.company_nameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5145833492279053D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.company_nameDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.company_nameDataTextBox.StyleName = "Data";
            this.company_nameDataTextBox.Value = "=Fields.company_name";
            // 
            // date_of_joinDataTextBox
            // 
            this.date_of_joinDataTextBox.CanGrow = true;
            this.date_of_joinDataTextBox.Format = "{0:d}";
            this.date_of_joinDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(23.21466064453125D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.date_of_joinDataTextBox.Name = "date_of_joinDataTextBox";
            this.date_of_joinDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.85401207208633423D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.date_of_joinDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.date_of_joinDataTextBox.StyleName = "Data";
            this.date_of_joinDataTextBox.Value = "=Fields.date_of_join";
            // 
            // contract_expiry_dateDataTextBox
            // 
            this.contract_expiry_dateDataTextBox.CanGrow = true;
            this.contract_expiry_dateDataTextBox.Format = "{0:d}";
            this.contract_expiry_dateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(24.068750381469727D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.contract_expiry_dateDataTextBox.Name = "contract_expiry_dateDataTextBox";
            this.contract_expiry_dateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.03125D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.contract_expiry_dateDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.contract_expiry_dateDataTextBox.StyleName = "Data";
            this.contract_expiry_dateDataTextBox.Value = "=Fields.contract_expiry_date";
            // 
            // registration_date1DataTextBox
            // 
            this.registration_date1DataTextBox.CanGrow = true;
            this.registration_date1DataTextBox.Format = "{0:d}";
            this.registration_date1DataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(25.100076675415039D), Telerik.Reporting.Drawing.Unit.Inch(0.0083333337679505348D));
            this.registration_date1DataTextBox.Name = "registration_date1DataTextBox";
            this.registration_date1DataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99984538555145264D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.registration_date1DataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.registration_date1DataTextBox.StyleName = "Data";
            this.registration_date1DataTextBox.Value = "=Fields.registration_date1";
            // 
            // salaryDataTextBox
            // 
            this.salaryDataTextBox.CanGrow = true;
            this.salaryDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(26.100000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.salaryDataTextBox.Name = "salaryDataTextBox";
            this.salaryDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.89996135234832764D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.salaryDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.salaryDataTextBox.StyleName = "Data";
            this.salaryDataTextBox.Value = "=Fields.salary";
            // 
            // registration_idDataTextBox
            // 
            this.registration_idDataTextBox.CanGrow = true;
            this.registration_idDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.registration_idDataTextBox.Name = "registration_idDataTextBox";
            this.registration_idDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.73974102735519409D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.registration_idDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.registration_idDataTextBox.StyleName = "Data";
            this.registration_idDataTextBox.Value = "=Fields.registration_id";
            // 
            // candidate_idDataTextBox
            // 
            this.candidate_idDataTextBox.CanGrow = true;
            this.candidate_idDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.75648653507232666D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.candidate_idDataTextBox.Name = "candidate_idDataTextBox";
            this.candidate_idDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.75D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.candidate_idDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.candidate_idDataTextBox.StyleName = "Data";
            this.candidate_idDataTextBox.Value = "=Fields.candidate_id";
            // 
            // registration_dateDataTextBox
            // 
            this.registration_dateDataTextBox.CanGrow = true;
            this.registration_dateDataTextBox.Format = "{0:d}";
            this.registration_dateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.5065653324127197D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.registration_dateDataTextBox.Name = "registration_dateDataTextBox";
            this.registration_dateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0830966234207153D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.registration_dateDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.registration_dateDataTextBox.StyleName = "Data";
            this.registration_dateDataTextBox.Value = "=Fields.registration_date";
            // 
            // role_nameDataTextBox
            // 
            this.role_nameDataTextBox.CanGrow = true;
            this.role_nameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(19.160419464111328D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.role_nameDataTextBox.Name = "role_nameDataTextBox";
            this.role_nameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2395813465118408D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.role_nameDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.role_nameDataTextBox.StyleName = "Data";
            this.role_nameDataTextBox.Value = "=Fields.role_name";
            // 
            // educational_qualificationDataTextBox
            // 
            this.educational_qualificationDataTextBox.CanGrow = true;
            this.educational_qualificationDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.1712923049926758D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.educational_qualificationDataTextBox.Name = "educational_qualificationDataTextBox";
            this.educational_qualificationDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4185099601745606D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.educational_qualificationDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.educational_qualificationDataTextBox.StyleName = "Data";
            this.educational_qualificationDataTextBox.Value = "=Fields.educational_qualification";
            // 
            // disability_typeDataTextBox
            // 
            this.disability_typeDataTextBox.CanGrow = true;
            this.disability_typeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6712908744812012D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.disability_typeDataTextBox.Name = "disability_typeDataTextBox";
            this.disability_typeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4999216794967651D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.disability_typeDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.disability_typeDataTextBox.StyleName = "Data";
            this.disability_typeDataTextBox.Value = "=Fields.disability_type";
            // 
            // date_of_birthDataTextBox
            // 
            this.date_of_birthDataTextBox.CanGrow = true;
            this.date_of_birthDataTextBox.Format = "{0:d}";
            this.date_of_birthDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7435002326965332D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.date_of_birthDataTextBox.Name = "date_of_birthDataTextBox";
            this.date_of_birthDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.92771250009536743D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.date_of_birthDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.date_of_birthDataTextBox.StyleName = "Data";
            this.date_of_birthDataTextBox.Value = "=Fields.date_of_birth";
            // 
            // candidate_nameDataTextBox
            // 
            this.candidate_nameDataTextBox.CanGrow = true;
            this.candidate_nameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.candidate_nameDataTextBox.Name = "candidate_nameDataTextBox";
            this.candidate_nameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9932767152786255D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.candidate_nameDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.candidate_nameDataTextBox.StyleName = "Data";
            this.candidate_nameDataTextBox.Value = "=Fields.candidate_name";
            // 
            // designation_expiry_dateDataTextBox
            // 
            this.designation_expiry_dateDataTextBox.CanGrow = true;
            this.designation_expiry_dateDataTextBox.Format = "{0:d}";
            this.designation_expiry_dateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5897407531738281D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.designation_expiry_dateDataTextBox.Name = "designation_expiry_dateDataTextBox";
            this.designation_expiry_dateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0433560609817505D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.designation_expiry_dateDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.designation_expiry_dateDataTextBox.StyleName = "Data";
            this.designation_expiry_dateDataTextBox.Value = "=Fields.designation_expiry_date";
            // 
            // labelsGroupFooter
            // 
            this.labelsGroupFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D);
            this.labelsGroupFooter.Name = "labelsGroupFooter";
            this.labelsGroupFooter.Style.Visible = false;
            // 
            // labelsGroupHeader
            // 
            this.labelsGroupHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D);
            this.labelsGroupHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.registration_idCaptionTextBox,
            this.candidate_idCaptionTextBox,
            this.registration_dateCaptionTextBox,
            this.designation_expiry_dateCaptionTextBox,
            this.candidate_nameCaptionTextBox,
            this.date_of_birthCaptionTextBox,
            this.disability_typeCaptionTextBox,
            this.educational_qualificationCaptionTextBox,
            this.i1CaptionTextBox,
            this.phone_numbersCaptionTextBox,
            this.email_addressCaptionTextBox,
            this.ngo_nameCaptionTextBox,
            this.unemployed_daysCaptionTextBox,
            this.recommended_job_typesCaptionTextBox,
            this.role_nameCaptionTextBox,
            this.company_nameCaptionTextBox,
            this.contract_expiry_dateCaptionTextBox,
            this.salaryCaptionTextBox,
            this.registration_date1CaptionTextBox,
            this.date_of_joinCaptionTextBox,
            this.designationCaptionTextBox,
            this.recommended_job_rolesCaptionTextBox,
            this.unemployed_since_daysCaptionTextBox});
            this.labelsGroupHeader.Name = "labelsGroupHeader";
            this.labelsGroupHeader.PrintOnEveryPage = true;
            this.labelsGroupHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // registration_idCaptionTextBox
            // 
            this.registration_idCaptionTextBox.CanGrow = true;
            this.registration_idCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.registration_idCaptionTextBox.Name = "registration_idCaptionTextBox";
            this.registration_idCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.75D), Telerik.Reporting.Drawing.Unit.Inch(0.44999998807907104D));
            this.registration_idCaptionTextBox.Style.Font.Bold = true;
            this.registration_idCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.registration_idCaptionTextBox.StyleName = "Caption";
            this.registration_idCaptionTextBox.Value = "Registration ID (RID)\r\n";
            // 
            // candidate_idCaptionTextBox
            // 
            this.candidate_idCaptionTextBox.CanGrow = true;
            this.candidate_idCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.76674550771713257D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.candidate_idCaptionTextBox.Name = "candidate_idCaptionTextBox";
            this.candidate_idCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.75D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.candidate_idCaptionTextBox.Style.Font.Bold = true;
            this.candidate_idCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.candidate_idCaptionTextBox.StyleName = "Caption";
            this.candidate_idCaptionTextBox.Value = "Candidate Id";
            // 
            // registration_dateCaptionTextBox
            // 
            this.registration_dateCaptionTextBox.CanGrow = true;
            this.registration_dateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.5168243646621704D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.registration_dateCaptionTextBox.Name = "registration_dateCaptionTextBox";
            this.registration_dateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0728375911712647D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.registration_dateCaptionTextBox.Style.Font.Bold = true;
            this.registration_dateCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.registration_dateCaptionTextBox.StyleName = "Caption";
            this.registration_dateCaptionTextBox.Value = "Registration Date";
            // 
            // designation_expiry_dateCaptionTextBox
            // 
            this.designation_expiry_dateCaptionTextBox.CanGrow = true;
            this.designation_expiry_dateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.designation_expiry_dateCaptionTextBox.Name = "designation_expiry_dateCaptionTextBox";
            this.designation_expiry_dateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0330967903137207D), Telerik.Reporting.Drawing.Unit.Inch(0.46662724018096924D));
            this.designation_expiry_dateCaptionTextBox.Style.Font.Bold = true;
            this.designation_expiry_dateCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.designation_expiry_dateCaptionTextBox.StyleName = "Caption";
            this.designation_expiry_dateCaptionTextBox.Value = "Desgignation Exp Date";
            // 
            // candidate_nameCaptionTextBox
            // 
            this.candidate_nameCaptionTextBox.CanGrow = true;
            this.candidate_nameCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.candidate_nameCaptionTextBox.Name = "candidate_nameCaptionTextBox";
            this.candidate_nameCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9932771921157837D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.candidate_nameCaptionTextBox.Style.Font.Bold = true;
            this.candidate_nameCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.candidate_nameCaptionTextBox.StyleName = "Caption";
            this.candidate_nameCaptionTextBox.Value = "Name of Candidate\r\n";
            // 
            // date_of_birthCaptionTextBox
            // 
            this.date_of_birthCaptionTextBox.CanGrow = true;
            this.date_of_birthCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7435002326965332D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.date_of_birthCaptionTextBox.Name = "date_of_birthCaptionTextBox";
            this.date_of_birthCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.92771250009536743D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.date_of_birthCaptionTextBox.Style.Font.Bold = true;
            this.date_of_birthCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.date_of_birthCaptionTextBox.StyleName = "Caption";
            this.date_of_birthCaptionTextBox.Value = "Date of Birth";
            // 
            // disability_typeCaptionTextBox
            // 
            this.disability_typeCaptionTextBox.CanGrow = true;
            this.disability_typeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6712908744812012D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.disability_typeCaptionTextBox.Name = "disability_typeCaptionTextBox";
            this.disability_typeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4999216794967651D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.disability_typeCaptionTextBox.Style.Font.Bold = true;
            this.disability_typeCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.disability_typeCaptionTextBox.StyleName = "Caption";
            this.disability_typeCaptionTextBox.Value = "Disability Type\t\r\n";
            // 
            // educational_qualificationCaptionTextBox
            // 
            this.educational_qualificationCaptionTextBox.CanGrow = true;
            this.educational_qualificationCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.1712923049926758D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.educational_qualificationCaptionTextBox.Name = "educational_qualificationCaptionTextBox";
            this.educational_qualificationCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4185099601745606D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.educational_qualificationCaptionTextBox.Style.Font.Bold = true;
            this.educational_qualificationCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.educational_qualificationCaptionTextBox.StyleName = "Caption";
            this.educational_qualificationCaptionTextBox.Value = "Educational Qualifications\t\r\n";
            // 
            // i1CaptionTextBox
            // 
            this.i1CaptionTextBox.CanGrow = true;
            this.i1CaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.58988094329834D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.i1CaptionTextBox.Name = "i1CaptionTextBox";
            this.i1CaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1030324697494507D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.i1CaptionTextBox.Style.Font.Bold = true;
            this.i1CaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.i1CaptionTextBox.StyleName = "Caption";
            this.i1CaptionTextBox.Value = "Secondary Phone Number";
            // 
            // phone_numbersCaptionTextBox
            // 
            this.phone_numbersCaptionTextBox.CanGrow = true;
            this.phone_numbersCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.6929931640625D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.phone_numbersCaptionTextBox.Name = "phone_numbersCaptionTextBox";
            this.phone_numbersCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4581745862960815D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.phone_numbersCaptionTextBox.Style.Font.Bold = true;
            this.phone_numbersCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.phone_numbersCaptionTextBox.StyleName = "Caption";
            this.phone_numbersCaptionTextBox.Value = "Phone Numbers\r\n";
            // 
            // email_addressCaptionTextBox
            // 
            this.email_addressCaptionTextBox.CanGrow = true;
            this.email_addressCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(12.151247024536133D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.email_addressCaptionTextBox.Name = "email_addressCaptionTextBox";
            this.email_addressCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.email_addressCaptionTextBox.Style.Font.Bold = true;
            this.email_addressCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.email_addressCaptionTextBox.StyleName = "Caption";
            this.email_addressCaptionTextBox.Value = "Email Address";
            // 
            // ngo_nameCaptionTextBox
            // 
            this.ngo_nameCaptionTextBox.CanGrow = true;
            this.ngo_nameCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(13.392992973327637D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.ngo_nameCaptionTextBox.Name = "ngo_nameCaptionTextBox";
            this.ngo_nameCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0070068836212158D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.ngo_nameCaptionTextBox.Style.Font.Bold = true;
            this.ngo_nameCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ngo_nameCaptionTextBox.StyleName = "Caption";
            this.ngo_nameCaptionTextBox.Value = "Ngo Name";
            // 
            // unemployed_daysCaptionTextBox
            // 
            this.unemployed_daysCaptionTextBox.CanGrow = true;
            this.unemployed_daysCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(14.400079727172852D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.unemployed_daysCaptionTextBox.Name = "unemployed_daysCaptionTextBox";
            this.unemployed_daysCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.044921875D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.unemployed_daysCaptionTextBox.Style.Font.Bold = true;
            this.unemployed_daysCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.unemployed_daysCaptionTextBox.StyleName = "Caption";
            this.unemployed_daysCaptionTextBox.Value = "Unemployed Days";
            // 
            // recommended_job_typesCaptionTextBox
            // 
            this.recommended_job_typesCaptionTextBox.CanGrow = true;
            this.recommended_job_typesCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(16.252162933349609D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.recommended_job_typesCaptionTextBox.Name = "recommended_job_typesCaptionTextBox";
            this.recommended_job_typesCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4998453855514526D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.recommended_job_typesCaptionTextBox.Style.Font.Bold = true;
            this.recommended_job_typesCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.recommended_job_typesCaptionTextBox.StyleName = "Caption";
            this.recommended_job_typesCaptionTextBox.Value = "Recommended Job Type\r\n";
            // 
            // role_nameCaptionTextBox
            // 
            this.role_nameCaptionTextBox.CanGrow = true;
            this.role_nameCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(19.160419464111328D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.role_nameCaptionTextBox.Name = "role_nameCaptionTextBox";
            this.role_nameCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2395813465118408D), Telerik.Reporting.Drawing.Unit.Inch(0.46662724018096924D));
            this.role_nameCaptionTextBox.Style.Font.Bold = true;
            this.role_nameCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.role_nameCaptionTextBox.StyleName = "Caption";
            this.role_nameCaptionTextBox.Value = "Role";
            // 
            // company_nameCaptionTextBox
            // 
            this.company_nameCaptionTextBox.CanGrow = true;
            this.company_nameCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(21.700000762939453D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.company_nameCaptionTextBox.Name = "company_nameCaptionTextBox";
            this.company_nameCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5145833492279053D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.company_nameCaptionTextBox.Style.Font.Bold = true;
            this.company_nameCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.company_nameCaptionTextBox.StyleName = "Caption";
            this.company_nameCaptionTextBox.Value = "Company Name";
            // 
            // contract_expiry_dateCaptionTextBox
            // 
            this.contract_expiry_dateCaptionTextBox.CanGrow = true;
            this.contract_expiry_dateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(24.068750381469727D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.contract_expiry_dateCaptionTextBox.Name = "contract_expiry_dateCaptionTextBox";
            this.contract_expiry_dateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.03125D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.contract_expiry_dateCaptionTextBox.Style.Font.Bold = true;
            this.contract_expiry_dateCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.contract_expiry_dateCaptionTextBox.StyleName = "Caption";
            this.contract_expiry_dateCaptionTextBox.Value = "Contract Expiry Date\r\n";
            // 
            // salaryCaptionTextBox
            // 
            this.salaryCaptionTextBox.CanGrow = true;
            this.salaryCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(26.100000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.salaryCaptionTextBox.Name = "salaryCaptionTextBox";
            this.salaryCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.89996135234832764D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.salaryCaptionTextBox.Style.Font.Bold = true;
            this.salaryCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.salaryCaptionTextBox.StyleName = "Caption";
            this.salaryCaptionTextBox.Value = "Salary";
            // 
            // registration_date1CaptionTextBox
            // 
            this.registration_date1CaptionTextBox.CanGrow = true;
            this.registration_date1CaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(25.100076675415039D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.registration_date1CaptionTextBox.Name = "registration_date1CaptionTextBox";
            this.registration_date1CaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99984538555145264D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.registration_date1CaptionTextBox.Style.Font.Bold = true;
            this.registration_date1CaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.registration_date1CaptionTextBox.StyleName = "Caption";
            this.registration_date1CaptionTextBox.Value = "Registration Date\r\n";
            // 
            // date_of_joinCaptionTextBox
            // 
            this.date_of_joinCaptionTextBox.CanGrow = true;
            this.date_of_joinCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(23.21466064453125D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.date_of_joinCaptionTextBox.Name = "date_of_joinCaptionTextBox";
            this.date_of_joinCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.85401207208633423D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.date_of_joinCaptionTextBox.Style.Font.Bold = true;
            this.date_of_joinCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.date_of_joinCaptionTextBox.StyleName = "Caption";
            this.date_of_joinCaptionTextBox.Value = "Date of Join";
            // 
            // designationCaptionTextBox
            // 
            this.designationCaptionTextBox.CanGrow = true;
            this.designationCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(20.400077819824219D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.designationCaptionTextBox.Name = "designationCaptionTextBox";
            this.designationCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2998453378677368D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.designationCaptionTextBox.Style.Font.Bold = true;
            this.designationCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.designationCaptionTextBox.StyleName = "Caption";
            this.designationCaptionTextBox.Value = "Designation";
            // 
            // recommended_job_rolesCaptionTextBox
            // 
            this.recommended_job_rolesCaptionTextBox.CanGrow = true;
            this.recommended_job_rolesCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(17.752084732055664D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.recommended_job_rolesCaptionTextBox.Name = "recommended_job_rolesCaptionTextBox";
            this.recommended_job_rolesCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4082560539245606D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.recommended_job_rolesCaptionTextBox.Style.Font.Bold = true;
            this.recommended_job_rolesCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.recommended_job_rolesCaptionTextBox.StyleName = "Caption";
            this.recommended_job_rolesCaptionTextBox.Value = "Recommended job Roles";
            // 
            // unemployed_since_daysCaptionTextBox
            // 
            this.unemployed_since_daysCaptionTextBox.CanGrow = true;
            this.unemployed_since_daysCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(15.445080757141113D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.unemployed_since_daysCaptionTextBox.Name = "unemployed_since_daysCaptionTextBox";
            this.unemployed_since_daysCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80700278282165527D), Telerik.Reporting.Drawing.Unit.Inch(0.46666666865348816D));
            this.unemployed_since_daysCaptionTextBox.Style.Font.Bold = true;
            this.unemployed_since_daysCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.unemployed_since_daysCaptionTextBox.StyleName = "Caption";
            this.unemployed_since_daysCaptionTextBox.Value = "Unemployed since(days)\r\n";
            // 
            // nAllActiveRegisteredCandidate
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.labelsGroupFooter;
            group1.GroupHeader = this.labelsGroupHeader;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeader,
            this.labelsGroupFooter,
            this.pageHeader,
            this.pageFooter,
            this.detail});
            this.Name = "nAllActiveRegisteredCandidate";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.Black;
            styleRule1.Style.Font.Bold = true;
            styleRule1.Style.Font.Italic = false;
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule1.Style.Font.Strikeout = false;
            styleRule1.Style.Font.Underline = false;
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(27D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox candidate_idDataTextBox;
        private Telerik.Reporting.TextBox registration_dateDataTextBox;
        private Telerik.Reporting.TextBox designation_expiry_dateDataTextBox;
        private Telerik.Reporting.TextBox candidate_nameDataTextBox;
        private Telerik.Reporting.TextBox date_of_birthDataTextBox;
        private Telerik.Reporting.TextBox disability_typeDataTextBox;
        private Telerik.Reporting.TextBox educational_qualificationDataTextBox;
        private Telerik.Reporting.TextBox i1DataTextBox;
        private Telerik.Reporting.TextBox phone_numbersDataTextBox;
        private Telerik.Reporting.TextBox email_addressDataTextBox;
        private Telerik.Reporting.TextBox ngo_nameDataTextBox;
        private Telerik.Reporting.TextBox unemployed_daysDataTextBox;
        private Telerik.Reporting.TextBox unemployed_since_daysDataTextBox;
        private Telerik.Reporting.TextBox recommended_job_typesDataTextBox;
        private Telerik.Reporting.TextBox recommended_job_rolesDataTextBox;
        private Telerik.Reporting.TextBox role_nameDataTextBox;
        private Telerik.Reporting.TextBox designationDataTextBox;
        private Telerik.Reporting.TextBox company_nameDataTextBox;
        private Telerik.Reporting.TextBox date_of_joinDataTextBox;
        private Telerik.Reporting.TextBox contract_expiry_dateDataTextBox;
        private Telerik.Reporting.TextBox registration_date1DataTextBox;
        private Telerik.Reporting.TextBox salaryDataTextBox;
        private Telerik.Reporting.TextBox registration_idDataTextBox;
        private Telerik.Reporting.Group labelsGroup;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooter;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeader;
        private Telerik.Reporting.TextBox registration_idCaptionTextBox;
        private Telerik.Reporting.TextBox candidate_idCaptionTextBox;
        private Telerik.Reporting.TextBox registration_dateCaptionTextBox;
        private Telerik.Reporting.TextBox designation_expiry_dateCaptionTextBox;
        private Telerik.Reporting.TextBox candidate_nameCaptionTextBox;
        private Telerik.Reporting.TextBox date_of_birthCaptionTextBox;
        private Telerik.Reporting.TextBox disability_typeCaptionTextBox;
        private Telerik.Reporting.TextBox educational_qualificationCaptionTextBox;
        private Telerik.Reporting.TextBox i1CaptionTextBox;
        private Telerik.Reporting.TextBox phone_numbersCaptionTextBox;
        private Telerik.Reporting.TextBox email_addressCaptionTextBox;
        private Telerik.Reporting.TextBox ngo_nameCaptionTextBox;
        private Telerik.Reporting.TextBox unemployed_daysCaptionTextBox;
        private Telerik.Reporting.TextBox recommended_job_typesCaptionTextBox;
        private Telerik.Reporting.TextBox role_nameCaptionTextBox;
        private Telerik.Reporting.TextBox company_nameCaptionTextBox;
        private Telerik.Reporting.TextBox contract_expiry_dateCaptionTextBox;
        private Telerik.Reporting.TextBox salaryCaptionTextBox;
        private Telerik.Reporting.TextBox registration_date1CaptionTextBox;
        private Telerik.Reporting.TextBox date_of_joinCaptionTextBox;
        private Telerik.Reporting.TextBox designationCaptionTextBox;
        private Telerik.Reporting.TextBox recommended_job_rolesCaptionTextBox;
        private Telerik.Reporting.TextBox unemployed_since_daysCaptionTextBox;

    }
}