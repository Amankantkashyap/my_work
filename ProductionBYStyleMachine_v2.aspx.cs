using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

public partial class ProductionBYStyleMachine_v2 : System.Web.UI.Page
{
    ArrayList ParameterArrayList = new ArrayList(); //Report parameter list
    ReportDocument ObjReportClientDocument = new ReportDocument(); //Report document
    CrystalReportViewer CrystalReportViewer2 = new CrystalReportViewer();
    ReportFiltersBase ObjReportFilter = new ReportFiltersBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            textbox1.Text = DateTime.Today.AddDays(-6 - (int)DateTime.Today.DayOfWeek).ToString("yyyy-MM-dd"); //LAST WEEK MONDAY DATE
            textbox3.Text = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).ToString("yyyy-MM-dd"); // LAST WEEK SUNDAY DATE

            FillCustomerDropdown();
            FillProducerDropdown();
            FillMachineList();
        }



        if (String.IsNullOrEmpty(textbox7.Text))
        {
            dropdownlist2.Enabled = true;

        }
        else
        {
            dropdownlist2.SelectedValue = "00000000-0000-0000-0000-000000000000";

            dropdownlist2.Enabled = false;

        }
        if (dropdownlist2.SelectedValue == "00000000-0000-0000-0000-000000000000")
        {
            textbox8.Text = "";
            textbox8.Enabled = false;
        }
        else
        {
            textbox8.Enabled = true;
        }
    }

    protected void textbox6_TextChanged(object sender, EventArgs e)
    {
    }

    protected void textbox7_TextChanged(object sender, EventArgs e)
    {

    }

    protected void textbox8_TextChanged(object sender, EventArgs e)
    {
    }

    protected void textbox9_TextChanged(object sender, EventArgs e)
    {

    }

    protected void textbox10_TextChanged(object sender, EventArgs e)
    {

    }


    // ON SUBMIT FUNCTION TO BE PERFORMED

    protected void submitbutton_Click(object sender, EventArgs e)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        if (String.IsNullOrEmpty(textbox1.Text))
        {
            textbox1.Text = DateTime.Today.AddDays(-6 - (int)DateTime.Today.DayOfWeek).ToString("yyyy-MM-dd"); //LAST WEEK MONDAY DATE.
        }
        if (String.IsNullOrEmpty(textbox3.Text))
        {
            textbox3.Text = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).ToString("yyyy-MM-dd"); // LAST WEEK SUNDAY DATE.
        }
        DateTime sdate = DateTime.Parse(textbox1.Text);
        DateTime edate = DateTime.Parse(textbox3.Text);

        DateTime sdt = new DateTime(sdate.Year, sdate.Month, sdate.Day, Int32.Parse(textbox2.Text), Int32.Parse(textbox5.Text), 0); //COMBINED DATE AND TIME.
        DateTime edt = new DateTime(edate.Year, edate.Month, edate.Day, Int32.Parse(textbox4.Text), Int32.Parse(textbox11.Text), 0); //COMBINED DATE AND TIME.


        if (DateTime.Today.Subtract(sdt).TotalMinutes > 0)  //START DATETIME NOT GREATER THAN CURRENT DATE & TIME
        {
            if (edt.Subtract(sdt).TotalMinutes > 0)  //END DATETIME MUST BE SMALLER THAN START DATE & TIME.
            {
                #region Get textbox values and format it

                string startdate = sdt.ToString("MM/dd/yyyy HH:mm:ss");
                string enddate = edt.ToString("MM/dd/yyyy HH:mm:ss");
                string allmach = radiobuttonlist1.SelectedItem.Value.ToString();
                string machlist = "";
                if (allmach == "1")
                {

                    foreach (int i in listbox1.GetSelectedIndices())
                    {
                        machlist += "," + listbox1.Items[i].Value;
                    }
                }
                else
                {
                    machlist = "All";
                }

                string custid = dropdownlist1.SelectedItem.Value;
                string custname = dropdownlist1.SelectedItem.Text;

                string cpp = RadioButtonList2.SelectedItem.Value.ToString();
                string styl = textbox6.Text;
                if (styl == "")
                {
                    styl = "All";
                }
                string mrg = textbox7.Text;
                if (mrg == "")
                {
                    mrg = "All";
                }
                string prudcerid = dropdownlist2.SelectedItem.Value;
                string prudcername = dropdownlist2.SelectedItem.Text;

                int dnr;
                if (textbox8.Text == "")
                {
                    dnr = 0;
                }
                else
                {
                    dnr = Convert.ToInt32(textbox8.Text);
                }

                int maxRdef;
                if (textbox9.Text == "")
                {
                    maxRdef = 0;
                }
                else
                {
                    maxRdef = int.Parse(textbox9.Text);
                }

                float maxAeef;
                if (textbox10.Text == "")
                {
                    maxAeef = 0.000f;

                }
                else
                {
                    maxAeef = float.Parse(textbox10.Text);
                }
                int prtmach = int.Parse(RadioButtonList3.SelectedItem.Value);
                Boolean prodata4 = false;

                #endregion

                string connString = "server=HP-PC;uid=sa;pwd=dba;database=Fairystone_MSCRM";
                string sql = "Sp_ProductionByStyleMachine";


                using (SqlConnection connection = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        #region Sending Parameters to Procedure

                        cmd.Parameters.Add(new SqlParameter("@SDATE", startdate));
                        cmd.Parameters.Add(new SqlParameter("@EDATE", enddate));
                        cmd.Parameters.Add(new SqlParameter("@MACHINELIST", machlist));
                        cmd.Parameters.Add(new SqlParameter("@CUSTOMER", custid));
                        cmd.Parameters.Add(new SqlParameter("@STYLE", styl));
                        cmd.Parameters.Add(new SqlParameter("@MERGE", mrg));
                        cmd.Parameters.Add(new SqlParameter("@PRODUCER", prudcerid));
                        cmd.Parameters.Add(new SqlParameter("@DENIER", dnr));
                        cmd.Parameters.Add(new SqlParameter("@USEProdata4", prodata4));

                        #endregion

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            int i = 0;
                            String[] Arundata = new string[13] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            DataTable KnitRptL = new DataTable(); // Blank Table

                            #region Add Columns in KnitRptL table
                            KnitRptL.Columns.Add("Row_no", typeof(int));
                            KnitRptL.Columns.Add("CUST", typeof(string));
                            KnitRptL.Columns.Add("LOC", typeof(string));
                            KnitRptL.Columns.Add("Style", typeof(string));
                            KnitRptL.Columns.Add("Base_Speed", typeof(int));
                            KnitRptL.Columns.Add("Speed_Std", typeof(int));
                            KnitRptL.Columns.Add("Speed_HI", typeof(int));
                            KnitRptL.Columns.Add("Theo_Racks", typeof(int));
                            KnitRptL.Columns.Add("Std_racks", typeof(int));
                            KnitRptL.Columns.Add("Act_Racks", typeof(int));
                            KnitRptL.Columns.Add("Std_Eff", typeof(int));
                            KnitRptL.Columns.Add("Rack_Wt", typeof(float));
                            KnitRptL.Columns.Add("Run_Sec", typeof(double));
                            KnitRptL.Columns.Add("Down_Sec", typeof(double));
                            KnitRptL.Columns.Add("KNIT_PRICE", typeof(float));
                            KnitRptL.Columns.Add("STOPs", typeof(int));
                            KnitRptL.Columns.Add("DEFECTs", typeof(int));
                            #endregion

                            string prvStyle = string.Empty;
                            string prvLoc = string.Empty;
                            foreach(DataRow row in dt.Rows)
                            //Parallel.ForEach (dt.AsEnumerable(), row =>
                            {
                                //lock (dt) ;
                                #region For loop start
                               
                                RundataProcedure(Arundata, row, ref prvStyle, ref prvLoc);

                                string loc = row["new_loc"].ToString();
                                string Styl = row["new_Style_Str"].ToString();
                                string filter = "LOC = '" + loc + "' and Style = '" + Styl + "'";
                                DataRow[] query = KnitRptL.Select(filter);
                                DataRow kRow = KnitRptL.NewRow();
                                if (query.Length > 0)
                                {
                                    //Calculations goes here
                                    long runsec = (long.Parse(query[0][12].ToString()) + long.Parse(Arundata[4]));
                                    if (runsec > 0)
                                    {
                                        query[0][5] = (((double.Parse(query[0][5].ToString()) * double.Parse(query[0][12].ToString())) + (double.Parse(Arundata[6]) * double.Parse(Arundata[4]))) / runsec);
                                        query[0][6] = Math.Round(((decimal.Parse(query[0][6].ToString()) * decimal.Parse(query[0][12].ToString())) + (decimal.Parse(row["new_speed"].ToString()) * decimal.Parse(Arundata[4]))) / runsec, 0);
                                    }
                                    query[0][7] = long.Parse(query[0][7].ToString()) + long.Parse(Arundata[8]);
                                    query[0][8] = long.Parse(query[0][8].ToString()) + long.Parse(Arundata[7]);
                                    query[0][9] = long.Parse(query[0][9].ToString()) + long.Parse(row["new_AccountRacks"].ToString());
                                    query[0][12] = long.Parse(query[0][12].ToString()) + long.Parse(Arundata[4]);
                                    query[0][13] = long.Parse(query[0][13].ToString()) + long.Parse(Arundata[5]);
                                    query[0][15] = long.Parse(query[0][15].ToString()) + long.Parse(Arundata[0]);
                                    query[0][16] = long.Parse(query[0][16].ToString()) + long.Parse(Arundata[1]);

                                }
                                else
                                {
                                    //Add new row
                                    #region Insert Data In KnitRptL
                                    kRow["Row_no"] = ++i;                                    // index = 0
                                    kRow["CUST"] = row["new_AbbreviatedName"].ToString(); // index = 1
                                    kRow["LOC"] = row["new_loc"].ToString();             // index = 2
                                    kRow["Style"] = row["new_Style_Str"].ToString();       // index = 3
                                    kRow["Base_Speed"] = row["new_base_speed"].ToString();      // index = 4
                                    kRow["Speed_Std"] = Arundata[6];                           // index = 5
                                    kRow["Speed_HI"] = row["new_Speed"].ToString();           // index = 6
                                    kRow["Theo_Racks"] = Arundata[8];                           // index = 7
                                    kRow["Std_racks"] = Arundata[7];                            // index = 8
                                    kRow["Act_Racks"] = row["new_AccountRacks"].ToString();     // index = 9
                                    kRow["Std_Eff"] = row["new_std_eff_crct1"].ToString();   // index = 10
                                    kRow["Rack_Wt"] = row["new_RackWt"].ToString();          // index = 11
                                    kRow["Run_Sec"] = Arundata[4];                              // index = 12
                                    kRow["Down_Sec"] = Arundata[5];                             // index = 13
                                    kRow["KNIT_PRICE"] = row["new_KnitPrice"].ToString();       // index = 14
                                    kRow["STOPs"] = Arundata[0];                           // index = 15
                                    kRow["DEFECTs"] = Arundata[1];                           // index = 16

                                    KnitRptL.Rows.Add(kRow);

                                    #endregion
                                }


                                //end foreach loop
                                #endregion
                            }//);


                            InsertData(KnitRptL, "sp_GenerateReportData", connection);
                        }

                    }
                }
                string strCustAbbv = dropdownlist1.SelectedItem.Text;
                strCustAbbv = strCustAbbv == "ALL CUSTOMERS" ? "" : dropdownlist1.SelectedItem.Text;
                GenerateReport(startdate, enddate, machlist, custname, styl, mrg, prudcername, dnr, maxRdef, maxAeef, prtmach, strCustAbbv);
                
                lblerror.Text = "Query Fired Sucessfully";

            }
            else
            {
                lblerror.Text = "Start date & time must be less than end date & time.";
            }
        }
        else
        {
            lblerror.Text = "Start date & time should not be greater than current date & time.";
        }
        watch.Stop();
        Debug.WriteLine( "Time Taken ->  "+watch.Elapsed.Seconds+"seconds");
    }

    protected void RundataProcedure(string[] Arundata, DataRow row, ref string prvStyle, ref string prvLoc)
    {
        int pSTOPS = 0;
        int pDEFECTS = 1;
        int pRKSTOP = 2;
        int pPRDSEC = 3;
        int pRUNSEC = 4;
        int pDOWNSEC = 5;
        int pSPEEDSTD = 6;
        int pSTDRKS = 7;
        int pTHEORKS = 8;
        int pREV = 9;
        int pTHEOREV = 10;
        int pACTRKS = 11;
        int pMILLRKS = 12;


        if (prvStyle != row["new_Style_Str"].ToString() || prvLoc != row["new_loc"].ToString())
        {
            Arundata[pRKSTOP] = "0";
        }
        prvStyle = row["new_Style_Str"].ToString();
        prvLoc = row["new_loc"].ToString();

        //reset value


        Arundata[pSTOPS] = "0";
        Arundata[pDEFECTS] = "0";
        //Arundata[pRKSTOP] = "0";
        Arundata[pPRDSEC] = "0";
        Arundata[pRUNSEC] = "0";
        Arundata[pDOWNSEC] = "0";
        //Arundata[pSPEEDSTD] = "0";
        Arundata[pSTDRKS] = "0";
        //Arundata[pTHEORKS] = "0";
        //Arundata[pREV] = "0";
        Arundata[pTHEOREV] = "0";
        //Arundata[pACTRKS] = "0";
        Arundata[pMILLRKS] = "0";






        Arundata[pPRDSEC] = (double.Parse(row["new_ProductionEnd"].ToString()) - double.Parse(row["new_ProductionBegining"].ToString())).ToString();
        Arundata[pSPEEDSTD] = (Math.Round(decimal.Parse(row["new_base_speed"].ToString()) * (decimal.Parse(row["new_per_spd_crct1"].ToString()) / 100), 0)).ToString();
        //Debug.WriteLine("speed std" + Arundata[pSPEEDSTD]);
        Arundata[pRKSTOP] = (long.Parse(Arundata[pRKSTOP]) + Convert.ToInt32(row["new_AccountRacks"])).ToString();

        int nLevel = Convert.ToInt32(row["new_Level"]);
        if ((!Boolean.Parse(row["new_Running"].ToString())) && row["new_Cepa"].ToString() != "00")
        {
            if (row["new_Cepa"].ToString() != "??" && row["new_Cepa"].ToString() != "UK")
            {
                // Update count of stops
                Arundata[pSTOPS] = (long.Parse(Arundata[pSTOPS]) + 1).ToString();

                if (long.Parse(Arundata[pRKSTOP]) > 3)
                {
                    if (row["new_Cepa"].ToString() != "52")
                    {
                        // new defect
                        Arundata[pDEFECTS] = (long.Parse(Arundata[pDEFECTS]) + 1).ToString();
                    }
                    Arundata[pRKSTOP] = "0";
                }

            }


            if (nLevel == 8) // no production
            {
            }
            else if (nLevel == 6) // curtailment
            {
            }
            else if (nLevel == 4) // major
            {

            }
            else if (nLevel == 0) // running
            {

                Arundata[pSTDRKS] = (Math.Round((long.Parse(Arundata[pSPEEDSTD]) * (decimal.Parse(row["new_std_eff_crct1"].ToString()) / 100) * decimal.Parse(Arundata[pPRDSEC]) / 28800), 0, MidpointRounding.AwayFromZero)).ToString();
                Arundata[pRUNSEC] = Arundata[pPRDSEC];
                Arundata[pTHEOREV] = (Math.Round(decimal.Parse(row["new_base_speed"].ToString()) * decimal.Parse(Arundata[pPRDSEC]) / 60, 0)).ToString();
                Arundata[pTHEORKS] = (Math.Round(decimal.Parse(row["new_SpeedPosted"].ToString()) * decimal.Parse(Arundata[pPRDSEC]) / 28800, 0, MidpointRounding.AwayFromZero)).ToString();
            }
            else // minor
            {
                Arundata[pRUNSEC] = "0";
                Arundata[pSTDRKS] = (Math.Round((long.Parse(Arundata[pSPEEDSTD]) * (decimal.Parse(row["new_std_eff_crct1"].ToString()) / 100) * decimal.Parse(Arundata[pPRDSEC]) / 28800), 0, MidpointRounding.AwayFromZero)).ToString();
                Arundata[pDOWNSEC] = Arundata[pPRDSEC];
                Arundata[pTHEOREV] = (Math.Round(decimal.Parse(row["new_base_speed"].ToString()) * decimal.Parse(Arundata[pPRDSEC]) / 60, 0)).ToString();
                Arundata[pTHEORKS] = (Math.Round(decimal.Parse(row["new_SpeedPosted"].ToString()) * decimal.Parse(Arundata[pPRDSEC]) / 28800, 0, MidpointRounding.AwayFromZero)).ToString();
            }

        }

        else //else block end's of running=1 or cepa <>'00'
        { }
        Arundata[pSTDRKS] = (Math.Round((long.Parse(Arundata[pSPEEDSTD]) * (decimal.Parse(row["new_std_eff_crct1"].ToString()) / 100) * decimal.Parse(Arundata[pPRDSEC]) / 28800), 0, MidpointRounding.AwayFromZero)).ToString();
        Arundata[pRUNSEC] = Arundata[pPRDSEC];
        Arundata[pTHEOREV] = (Math.Round(decimal.Parse(row["new_base_speed"].ToString()) * decimal.Parse(Arundata[pPRDSEC]) / 60)).ToString();
        Arundata[pTHEORKS] = (Math.Round(decimal.Parse(row["new_SpeedPosted"].ToString()) * decimal.Parse(Arundata[pPRDSEC]) / 28800, 0, MidpointRounding.AwayFromZero)).ToString();


        if (!(Boolean.Parse(row["new_Running"].ToString())) && row["new_Cepa"].ToString() != "00" && nLevel != 0)  // To make correct run seconds;
        {
            Arundata[pRUNSEC] = "0";

        }

        if (nLevel == 8 || nLevel == 6 || nLevel == 4) // To make correct run Theo racks;
        {
            Arundata[pTHEORKS] = "0";
            Arundata[pTHEOREV] = "0";
            Arundata[pSTDRKS] = "0";
        }


        if (nLevel != 8) // No Production (Weekend/Holiday)
        {

            Arundata[pMILLRKS] = (Math.Round(decimal.Parse(row["new_base_speed"].ToString()) * decimal.Parse(Arundata[pPRDSEC]) / 28800, 0)).ToString();
        }
        //Debug.WriteLine("std raks"+Arundata[pSTDRKS]);

    }

    protected void InsertData(DataTable KnitRptL, string sql, SqlConnection connection)
    {
        using (SqlCommand cmd1 = new SqlCommand(sql, connection))
        {
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@KnitRptL", KnitRptL));
            connection.Open();
            cmd1.ExecuteNonQuery();
            connection.Close();
        }
    }

    protected void GenerateReport(string startdate, string enddate, string machlist, string cust, string styl, string mrg, string prudcer, int dnr, int maxrack, float maxeff, int mach, string strCustAbbv)
    {
        //to do 
        ReportBase objReportBase = new ReportBase();
        string sRptFolder = string.Empty;
        string sRptName = string.Empty;

        sRptName = "KnitrptL_Report.rpt";  // Report Name
        sRptFolder = Server.MapPath("~/Reports");     //Report folder name

        ObjReportClientDocument = objReportBase.PFSubReportConnectionMainParameter(sRptName, ParameterArrayList, sRptFolder);

        ObjReportClientDocument.SetParameterValue("@Sdate", startdate);
        ObjReportClientDocument.SetParameterValue("@Edate", enddate);
        ObjReportClientDocument.SetParameterValue("@AllMachines", machlist);
        ObjReportClientDocument.SetParameterValue("@Customers", cust);
        ObjReportClientDocument.SetParameterValue("@Style", styl);
        ObjReportClientDocument.SetParameterValue("@Merge", mrg);
        ObjReportClientDocument.SetParameterValue("@Producer", prudcer);
        ObjReportClientDocument.SetParameterValue("@Denier", dnr);
        ObjReportClientDocument.SetParameterValue("@Max_Racks", maxrack);
        ObjReportClientDocument.SetParameterValue("@Max_Eff", maxeff);
        ObjReportClientDocument.SetParameterValue("@Mach", mach);
        ViewCystalReport2(strCustAbbv); 
    }
    private void ViewCystalReport2(string strcustabb)
    {
        string FileName = "ProductionByStyleMachineReport_" + DateTime.Now.Ticks.ToString() + ".pdf";
        CrystalReportViewer2.ReportSource = ObjReportClientDocument;
        ObjReportClientDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Server.MapPath("~/Reports/Reports Previews/" + FileName));

        if (Request.QueryString["UID"] != null)
        {

            string nUserID = Request.QueryString["UID"];
            Exception exObj;
            string strUdrivePath = ObjReportFilter.getuDrivePath(out exObj, nUserID);

            string strModPath = strUdrivePath.Substring(3);
            string strEmailPath = System.Configuration.ConfigurationManager.AppSettings["EmailAttchPath"];


            //strModPath = @"\\10.10.20.15\c$\FairyStoneUsers\" + strModPath + strcustabb;

            if (strcustabb == "") { strModPath = strEmailPath + strModPath + "OTHER"; }
            else { strModPath = strEmailPath + strModPath + strcustabb; }


            if (!Directory.Exists(strModPath)) { Directory.CreateDirectory(strModPath); }

            string strPdfName = "";

            using (PhyInventoryDataContext db = new PhyInventoryDataContext())
            {
                strPdfName = (from c in db.new_reportsBases
                              where c.new_Rptname == "KnitRptL"
                              select c.new_Pdfname).FirstOrDefault();
            }
            if (strPdfName == null) { strPdfName = "KnitRptL"; }

            string strFullPath = strModPath + "\\" + strPdfName + ".pdf";

            FileInfo info = new FileInfo(strFullPath);
            bool check = ObjReportFilter.IsFileLocked(info);

            if (!check || !File.Exists(strFullPath))
            {
                File.Copy(Server.MapPath("~/Reports/Reports Previews/" + FileName), strFullPath, true);
            }
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertBox", "alert('Your Message');", true);

        }

        Response.ContentType = "Application/pdf";
        Response.TransmitFile("Reports/Reports Previews/" + FileName);

    }
    protected void dropdownlist2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void textbox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void FillCustomerDropdown()
    {
        string query = @"select '[ ALL CUSTOMERS ]' as name, '00000000-0000-0000-0000-000000000000' as AccountId 
                            union 
                            select (new_AbbreviatedName) as name,AccountId   from AccountBase order by name";

        using (SqlConnection conn = new SqlConnection("server=HP-PC;uid=sa;pwd=dba;database=Fairystone_MSCRM"))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader src = cmd.ExecuteReader();

                dropdownlist1.DataTextField = "name";
                dropdownlist1.DataValueField = "AccountId";
                dropdownlist1.DataSource = src;
                dropdownlist1.DataBind();

            }
        }
    }
    protected void FillProducerDropdown()
    {
        string query = @"select '[ ALL PRODUCERS ]' as name, '00000000-0000-0000-0000-000000000000' as AccountId 
                            union 
                            select (new_AbbreviatedName) as name,AccountId   from AccountBase order by name";

        using (SqlConnection conn = new SqlConnection("server=HP-PC;uid=sa;pwd=dba;database=Fairystone_MSCRM"))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader src = cmd.ExecuteReader();

                dropdownlist2.DataTextField = "name";
                dropdownlist2.DataValueField = "AccountId";
                dropdownlist2.DataSource = src;
                dropdownlist2.DataBind();

            }
        }
    }

    protected void FillMachineList()
    {
        string query = @"SELECT  Loc.new_Loc,Loc.new_Loc + '   |   '+Mach.new_Mach_Set as Loc_and_Match FROM new_MachBase Mach
            right JOIN new_Location1Base loc ON Loc.new_mach = Mach.new_mach_num 
            where Loc.new_Loc is not null 
            ORDER BY Loc.new_Loc";

        using (SqlConnection conn = new SqlConnection("server=HP-PC;uid=sa;pwd=dba;database=Fairystone_MSCRM"))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader src = cmd.ExecuteReader();

                listbox1.DataTextField = "Loc_and_Match";
                listbox1.DataValueField = "new_Loc";
                listbox1.DataSource = src;
                listbox1.DataBind();

            }
        }
    }

    protected void radiobuttonlist1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radiobuttonlist1.SelectedValue == "1")
        {
            label16.Visible = true;
            listbox1.Visible = true;
        }
        else
        {
            label16.Visible = false;
            listbox1.Visible = false;
            listbox1.ClearSelection();
        }
    }
}