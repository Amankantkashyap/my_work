using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ClassLibrary;

public partial class add_employee_form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            getdata();
        }
    }
    protected void datepicker_Click(object sender, EventArgs e)
    {
        cal.Visible = true;
    }
    protected void afterselect(object sender, EventArgs e)
    {
        String str = this.cal.SelectedDate.ToString("yyyy/MM/dd");
        dobbox.Text = str.Replace("/", "-");

        cal.Visible = false;
    }

    protected void employeerecord_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ClearLabel();
        string strempcode = employeerecord.DataKeys[e.NewEditIndex].Value.ToString();

        String strQuery = "select * from TblEmployeeinfo where Empcode='"+strempcode+"'";
        string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["Assignment_dbConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connetionString);
        SqlCommand cmd = new SqlCommand(strQuery, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Open();
        if (ds.Tables[0].Rows.Count > 0)
        {
            empcodebox.Text = (ds.Tables[0].Rows[0][1]).ToString();
            namebox.Text = (ds.Tables[0].Rows[0][2]).ToString();
            genderselect.SelectedValue = (ds.Tables[0].Rows[0][3]).ToString();
            deptidselect.SelectedValue = (ds.Tables[0].Rows[0][4]).ToString();
            designationselect.SelectedValue = (ds.Tables[0].Rows[0][5]).ToString();
            dobbox.Text = (ds.Tables[0].Rows[0][6]).ToString();
            fnamebox.Text = (ds.Tables[0].Rows[0][7]).ToString();
            mnamebox.Text = (ds.Tables[0].Rows[0][8]).ToString();
            permanentaddbox.Text = (ds.Tables[0].Rows[0][9]).ToString();
            persentaddbox.Text = (ds.Tables[0].Rows[0][10]).ToString();
            martialstatusselect.SelectedValue = (ds.Tables[0].Rows[0][11]).ToString();
            banknamebox.Text = (ds.Tables[0].Rows[0][12]).ToString();
            accnobox.Text = (ds.Tables[0].Rows[0][13]).ToString();
            ifscbox.Text = (ds.Tables[0].Rows[0][14]).ToString();
            panbox.Text = (ds.Tables[0].Rows[0][15]).ToString();
            contactbox.Text = (ds.Tables[0].Rows[0][16]).ToString();
            emailbox.Text = (ds.Tables[0].Rows[0][17]).ToString();

        }
        con.Close();

        empcodebox.Enabled = false;
    }

   

    protected void employeerecord_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        employeerecord.EditIndex = -1;
        empcodebox.Text = "";
        namebox.Text = "";
        deptidselect.SelectedValue = "Select Departement";
        designationselect.SelectedValue = "Select Designation";
        dobbox.Text = "";
        fnamebox.Text = "";
        mnamebox.Text = "";
        permanentaddbox.Text = "";
        persentaddbox.Text = "";
        banknamebox.Text = "";
        accnobox.Text = "";
        ifscbox.Text = "";
        panbox.Text = "";
        contactbox.Text = "";
        emailbox.Text = "";
        getdata();
        ClearLabel();
        empcodebox.Enabled = true;
    }
    protected void employeerecord_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ClearLabel();


        validations reg = new validations();

        reg.EmployeeCode = empcodebox.Text.ToString();
        reg.EmpName = namebox.Text.ToString();
        reg.DeptId = deptidselect.SelectedValue.ToString();
        reg.Designation = designationselect.SelectedValue.ToString();
        reg.DateOfBirth = dobbox.Text.ToString();
        reg.FatherName = fnamebox.Text.ToString();
        reg.Address = permanentaddbox.Text.ToString();
        reg.BankName = banknamebox.Text.ToString();
        reg.AccoountNo = accnobox.Text.ToString();
        reg.IfscCode = ifscbox.Text.ToString();
        reg.PanCard = panbox.Text.ToString();
        reg.mobile = contactbox.Text.ToString();
        reg.email = emailbox.Text.ToString();
        reg.fileupload = FileUpload1.FileName.ToString();

        var context = new ValidationContext(reg, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(reg, context, results, true);

        if (!isValid)
        {
            foreach (var validationResult in results)
            {
                switch (validationResult.ErrorMessage)
                {
                    case "Employee Code is required":
                        lblEmpcodevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Employee Name is required":
                        lblnamevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Departement Id is required":
                        lbldepartvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Designation is required":
                        lbldesigvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "DOB is required":
                        lbldatevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Father Name is required":
                        lblfnamevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Address is required":
                        lbladdvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Bank Name is required":
                        lblbankevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Accoount No is required":
                        lblaccvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "IFSC Code is required":
                        lblifscvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "PAN Card  is required":
                        lblpanvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Mobile is required":
                        lblcontactvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "E-mail is required":
                        lblemailvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter Valid Date of Birth":
                        lbldatevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter Valid Account No.":
                        lblaccvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter valid IFSC code.":
                        lblifscvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter valid PAN Card no.":
                        lblpanvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter 10 digit Mobile No.":
                        lblcontactvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter proper email":
                        lblemailvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please Upload Documents":
                        lblfilevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Only (.doc,.txt.pdf) files are allowed":
                        lblfilevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    default:
                        lbldefault.Text = validationResult.ErrorMessage.ToString();
                        break;
                }

            }

            return;
        }
        if (FileUpload1.PostedFile.ContentLength > 1048576)
        {
            lblfilevalidator.Text = "file size is greated than 1MB";
        }
        else
        {
            try
            {
                DateTime currdate = new DateTime();
                string currentdate = currdate.ToString();
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["Assignment_dbConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connetionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_UpdateEmployeeDetails";
                SqlParameter param;


                param = new SqlParameter("@empcode", empcodebox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@name", namebox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@gender", genderselect.SelectedValue);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@dept", deptidselect.SelectedValue);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@desig", designationselect.SelectedValue);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@dob", dobbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@fname", fnamebox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@mname", mnamebox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@permanentadd", permanentaddbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@persentadd", persentaddbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@martialstatus", martialstatusselect.SelectedValue);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@bankname", banknamebox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@accno", accnobox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@ifsc", ifscbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@pan", panbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@contact", contactbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@email", emailbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();


                empcodebox.Text = "";
                namebox.Text = "";
                deptidselect.SelectedValue = "";
                designationselect.SelectedValue = "";
                dobbox.Text = "";
                fnamebox.Text = "";
                mnamebox.Text = "";
                permanentaddbox.Text = "";
                persentaddbox.Text = "";
                banknamebox.Text = "";
                accnobox.Text = "";
                ifscbox.Text = "";
                panbox.Text = "";
                contactbox.Text = "";
                emailbox.Text = "";
                getdata();
            }
            catch (Exception excp)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('An Exception Occured')", true);
                lbldefault.Text = excp.Message;

            }

        }
    }
    protected void employeerecord_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = employeerecord.Rows[e.RowIndex];
        string e_id = employeerecord.DataKeys[e.RowIndex].Values[0].ToString();
        string query = "update TblEmployeeinfo set Active=0 WHERE Empcode=@empcode";
        string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["Assignment_dbConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connetionString))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@empcode", e_id);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        this.getdata();
    }


    protected void getdata()
    {

        String strQuery = "select * from TblEmployeeinfo where Active=1";
        string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["Assignment_dbConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connetionString);
        SqlCommand cmd = new SqlCommand(strQuery, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            employeerecord.DataSource = ds;
            employeerecord.DataBind();
        }
    }
    protected void submitbtn_Click(object sender, EventArgs e)
    {

        ClearLabel();

        validations reg = new validations();

        reg.EmployeeCode = empcodebox.Text.ToString();
        reg.EmpName = namebox.Text.ToString();
        reg.DeptId = deptidselect.SelectedValue.ToString();
        reg.Designation = designationselect.SelectedValue.ToString();
        reg.DateOfBirth = dobbox.Text.ToString();
        reg.FatherName = fnamebox.Text.ToString();
        reg.Address = permanentaddbox.Text.ToString();
        reg.BankName = banknamebox.Text.ToString();
        reg.AccoountNo = accnobox.Text.ToString();
        reg.IfscCode = ifscbox.Text.ToString();
        reg.PanCard = panbox.Text.ToString();
        reg.mobile = contactbox.Text.ToString();
        reg.email = emailbox.Text.ToString();
        reg.fileupload = FileUpload1.FileName.ToString();

        var context = new ValidationContext(reg, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(reg, context, results, true);

        if (!isValid)
        {
            foreach (var validationResult in results)
            {
                switch (validationResult.ErrorMessage)
                {
                    case "Employee Code is required":
                        lblEmpcodevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Employee Name is required":
                        lblnamevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Departement Id is required":
                        lbldepartvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Designation is required":
                        lbldesigvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "DOB is required":
                        lbldatevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Father Name is required":
                        lblfnamevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Address is required":
                        lbladdvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Bank Name is required":
                        lblbankevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Accoount No is required":
                        lblaccvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "IFSC Code is required":
                        lblifscvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "PAN Card  is required":
                        lblpanvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Mobile is required":
                        lblcontactvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "E-mail is required":
                        lblemailvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter Valid Date of Birth":
                        lbldatevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter Valid Account No.":
                        lblaccvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter valid IFSC code.":
                        lblifscvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter valid PAN Card no.":
                        lblpanvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter 10 digit Mobile No.":
                        lblcontactvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please enter proper email":
                        lblemailvalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Please Upload Documents":
                        lblfilevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    case "Only (.doc,.txt.pdf) files are allowed":
                        lblfilevalidator.Text = validationResult.ErrorMessage.ToString();
                        break;
                    default:
                        lbldefault.Text = validationResult.ErrorMessage.ToString();
                        break;
                }

            }

            return;
        }
        if (IsUnique()!="0000")
        {

        }
        else if (FileUpload1.PostedFile.ContentLength > 1048576)
        {
            lblfilevalidator.Text = "file size is greated than 1MB";
        }
        else
        {
            try
            {
                DateTime currdate = new DateTime();
                string currentdate = currdate.ToString();
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["Assignment_dbConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connetionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_InsertEmployeeDetails";
                SqlParameter param;


                param = new SqlParameter("@empcode", empcodebox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@name", namebox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@gender", genderselect.SelectedValue);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@dept", deptidselect.SelectedValue);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@desig", designationselect.SelectedValue);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@dob", dobbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@fname", fnamebox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@mname", mnamebox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@permanentadd", permanentaddbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@persentadd", persentaddbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@martialstatus", martialstatusselect.SelectedValue);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@bankname", banknamebox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@accno", accnobox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@ifsc", ifscbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@pan", panbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@contact", contactbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = new SqlParameter("@email", emailbox.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);


                FileUpload1.SaveAs(Server.MapPath("images//" + FileUpload1.FileName));

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                empcodebox.Text = "";
                namebox.Text = "";
                deptidselect.SelectedValue = "";
                designationselect.SelectedValue = "";
                dobbox.Text = "";
                fnamebox.Text = "";
                mnamebox.Text = "";
                permanentaddbox.Text = "";
                persentaddbox.Text = "";
                banknamebox.Text = "";
                accnobox.Text = "";
                ifscbox.Text = "";
                panbox.Text = "";
                contactbox.Text = "";
                emailbox.Text = "";

                getdata();
            }
            catch (Exception excp)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('An Exception Occured')", true);
                lbldefault.Text = excp.Message;
            }
        }
    }
    protected void ClearLabel()
    {
        lblEmpcodevalidator.Text = "";
        lblnamevalidator.Text = "";
        lbldepartvalidator.Text = "";
        lbldesigvalidator.Text = "";
        lbldatevalidator.Text = "";
        lblfnamevalidator.Text = "";
        lbladdvalidator.Text = "";
        lblbankevalidator.Text = "";
        lblaccvalidator.Text = "";
        lblifscvalidator.Text = "";
        lblpanvalidator.Text = "";
        lblcontactvalidator.Text = "";
        lblemailvalidator.Text = "";
        lblfilevalidator.Text = "";
        lbldefault.Text = "";

    }
    protected string IsUnique()
    {
        string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["Assignment_dbConnectionString"].ConnectionString;
        string query1 = "select count(*) from TblEmployeeinfo where Empcode= '" + empcodebox.Text + "'";
        string query2 = "select count(*) from TblEmployeeinfo where Email= '" + emailbox.Text + "'";
        string query3 = "select count(*) from TblEmployeeinfo where Acc_no= '" + accnobox.Text + "'";
        string query4 = "select count(*) from TblEmployeeinfo where PAN= '" + panbox.Text + "'";
        string panexist, empcodeexist, emailexist, accexist;
        using (SqlConnection con = new SqlConnection(connetionString))
        {
            con.Open();
            SqlCommand cmd;
             cmd= new SqlCommand(query1, con);
            empcodeexist = cmd.ExecuteScalar().ToString();
            cmd = new SqlCommand(query2, con);
            emailexist = cmd.ExecuteScalar().ToString();
            cmd = new SqlCommand(query3, con);
            accexist = cmd.ExecuteScalar().ToString();
            cmd = new SqlCommand(query4, con);
            panexist = cmd.ExecuteScalar().ToString();
            con.Close();
        }
        if (empcodeexist != "0")
        {
            lblEmpcodevalidator.Text = "Empcode already exists";
        }
        else
        {
            lblEmpcodevalidator.Text = "";
        }

        if (emailexist != "0")
        {
            lblemailvalidator.Text = "Email is already registered";
        }
        else
        {
            lblemailvalidator.Text = "";
        }

        if (accexist != "0")
        {
            lblaccvalidator.Text = "Account no already exists";
        }
        else
        {
            lblaccvalidator.Text = "";
        }

        if (panexist != "0")
        {
            lblpanvalidator.Text = "Pancard already exists";
        }
        else
        {
            lblpanvalidator.Text = "";
        }
        return empcodeexist + emailexist + accexist + panexist;
    }
    
}