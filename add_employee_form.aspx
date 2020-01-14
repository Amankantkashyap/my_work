<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_employee_form.aspx.cs" Inherits="add_employee_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Employee</title>
    <script type="text/javascript">
    </script>
</head>

                                                     <%--css code here--%>
    <style>
        .textboxstyle
        {
            width:1130px;
            padding: 10px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border: none;
            border-bottom: 2px solid #999999;
            background-color:transparent;
        }
        .dropdowndesign
        {
            width:1130px;
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border: none;
            border-bottom: 2px solid #999999;
            background-color:transparent;
        }
        .radiobuttondesign
        {
            width:1130px;
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border: none;
            border-bottom: 2px solid #999999;
            background-color:transparent;
        }
        .headerstyle
        {
            height:100px;
        }
        .footerstyle
        {
            
            height:100px;
        }
        .lablestyle
        {
            width:300px;
            font-family:'American Typewriter';
            color:#999999;
        }
        .gridposition
        {
            position:relative;
            width:100%;
        }
        .submitbutton{
            position:relative;
            left:120px;
            background-color:#9B35B4;
            border-width:2px;  
            font-family:'American Typewriter';
            border-radius:2px;
            border-color:#9B35B4;
            color:white;
        }
        .buttondesign
        {
        background-color:white;
        border-width:2px;  
        border-style:outset;
        font-family:'American Typewriter';
        border-radius:5px;
        }
        .buttondesign:hover
        {
            background-color:orange;
        }
        .formdivdesign{
            padding:10px 20px;
            background-color:#ffffff;
            color:#999999;
            border-radius:5px;
        }
        .griddivstytle
        {
            padding:40px 20px;
            background-color:#ffffff;
            color:#999999;
            border-radius:5px;
        }
        .outerdiv
        {
            padding:100px 20px;
            margin: 8px 0;
            background-color:#e6e6e6;
        }
        .bankdetailstextbox
        {
            width:465px;
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border: none;
            border-bottom: 2px solid #999999;
            background-color:transparent;
        }

    </style>


                                                       <%--body code here--%>
<body>
    <form id="form1" runat="server" >
<div class="outerdiv">        
    <asp:Label Id="Label1" runat="server" Text="User Profile" CssClass="lablestyle" style="top:15px;position:absolute;"></asp:Label>                               
    <div class="formdivdesign">
        <asp:Label ID="head" runat="server" Text="Add Employee Details" style="top:87px; left:43px; position:absolute; height: 37px; width: 150px; background-color:#9B35B4;border-radius:5px; color:white;text-align:center;padding-top:5px;"></asp:Label>
        <br />
        <br />
        <table>

            <tr>
                <td>
                    <asp:Label Id="empcode" runat="server" Text="Employee code" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:TextBox ID="empcodebox" runat="server" CssClass="textboxstyle"></asp:TextBox><br />
                    <asp:Label Id="lblEmpcodevalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="name" runat="server" Text="Name" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:TextBox ID="namebox" runat="server" CssClass="textboxstyle" ></asp:TextBox><br />
                    <asp:Label Id="lblnamevalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label>
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="gender" runat="server" Text="Gender" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" AutoPostBack="true" ID="genderselect" RepeatDirection="Horizontal" CssClass="radiobuttondesign">
                        <asp:ListItem Value="Male" Selected="True"> Male </asp:ListItem>
                        <asp:ListItem Value="Female"> Female </asp:ListItem>
                        <asp:ListItem Value="Others"> Others </asp:ListItem>
                    </asp:RadioButtonList><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="deptid" runat="server" Text="Departement Id" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="deptidselect" CssClass="dropdowndesign">
                        <asp:ListItem Value="Select Departement"></asp:ListItem>  
                        <asp:ListItem>DPT01</asp:ListItem>
                        <asp:ListItem>DPT02</asp:ListItem>
                        <asp:ListItem>DPT03</asp:ListItem>
                        <asp:ListItem>DPT04</asp:ListItem>
                        <asp:ListItem>DPT05</asp:ListItem>
                        <asp:ListItem>DPT06</asp:ListItem>
                        <asp:ListItem>DPT07</asp:ListItem>
                        <asp:ListItem>DPT08</asp:ListItem>
                        <asp:ListItem>DPT09</asp:ListItem>
                        <asp:ListItem>DPT10</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label Id="lbldepartvalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="designation" runat="server" Text="Designation" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="designationselect" CssClass="dropdowndesign">
                        <asp:ListItem Value="Select Designation"></asp:ListItem>  
                        <asp:ListItem>H.R.</asp:ListItem>
                        <asp:ListItem>PHP developer</asp:ListItem>
                        <asp:ListItem>Android developer</asp:ListItem>
                        <asp:ListItem>Project Manager</asp:ListItem>
                        <asp:ListItem>General Manager</asp:ListItem>
                        <asp:ListItem>Business Development Manager</asp:ListItem>
                        <asp:ListItem>Internet Marketing Head</asp:ListItem>
                        <asp:ListItem>Content Writter</asp:ListItem>
                        <asp:ListItem>System Administrator</asp:ListItem>
                        <asp:ListItem>CEO/MD</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label Id="lbldesigvalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="dob" runat="server" Text="D.O.B" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                     
                   <asp:TextBox ID="dobbox" placeholder="YYYY/MM/DD" runat="server" CssClass="textboxstyle" ></asp:TextBox><br />
                    <asp:Label Id="lbldatevalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label>
                    <asp:Calendar ID="cal" runat="server" Visible="False" OnSelectionChanged="afterselect" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                    <asp:Button ID="datepicker" Text="select" runat ="server" OnClick="datepicker_Click" CssClass="buttondesign"/>
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="fname" runat="server" Text="Father Name" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:TextBox ID="fnamebox" runat="server" CssClass="textboxstyle"></asp:TextBox><br />
                    <asp:Label Id="lblfnamevalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="mname" runat="server" Text="Mother Name" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:TextBox ID="mnamebox" runat="server" CssClass="textboxstyle"></asp:TextBox><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="permanentadd" runat="server" Text="Permanent Address" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:TextBox ID="permanentaddbox" runat="server" CssClass="textboxstyle"></asp:TextBox><br />
                    <asp:Label Id="lbladdvalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="persentadd" runat="server" Text="Persent Address" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:TextBox ID="persentaddbox" runat="server" CssClass="textboxstyle"></asp:TextBox><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="martialstatus" runat="server" Text="Martial Status" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" AutoPostBack="true" ID="martialstatusselect" RepeatDirection="Horizontal">
                        <asp:ListItem Value="single" Selected="True"> Single </asp:ListItem>
                        <asp:ListItem Value="married"> Married </asp:ListItem>
                    </asp:RadioButtonList><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="bankname" runat="server" Text="Bank Name" CssClass="lablestyle"></asp:Label>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="banknamebox" runat="server" CssClass="bankdetailstextbox"></asp:TextBox><br />
                                
                                <asp:Label Id="lblbankevalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:Label Id="accno" runat="server" Text="Bank Account No." CssClass="lablestyle"></asp:Label>
                                
                            </td>
                            <td>
                                <asp:TextBox ID="accnobox" runat="server" CssClass="bankdetailstextbox" ></asp:TextBox><br />
                                <asp:Label Id="lblaccvalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label><br /><br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="ifsc" runat="server" Text="IFSC Code" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="ifscbox" runat="server" CssClass="bankdetailstextbox"></asp:TextBox><br />
                                
                                <asp:Label Id="lblifscvalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:Label Id="pan" runat="server" Text="PAN Card" CssClass="lablestyle"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="panbox" runat="server" CssClass="bankdetailstextbox"></asp:TextBox><br />
                                <asp:Label Id="lblpanvalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label><br /><br />
                            </td>
                        </tr>
                    </table>

                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label Id="contact" runat="server" Text="Contact No." CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:TextBox ID="contactbox" runat="server" CssClass="textboxstyle"></asp:TextBox><br />
                    <asp:Label Id="lblcontactvalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="email" runat="server" Text="E-mail Id" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:TextBox ID="emailbox" runat="server" CssClass="textboxstyle" ></asp:TextBox><br />
                    <asp:Label Id="lblemailvalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label><br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Id="uploadfile" runat="server" Text="Upload Document" CssClass="lablestyle"></asp:Label><br /><br />
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server"/><br />
                    <asp:Label Id="lblfilevalidator" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label>
                    <br /><br />
                </td>
                
            </tr>
            <tr>

                <td>
                    <asp:Button ID="submitbtn" runat="server" Text="Submit Form" Width="120px" Height="40px" OnClick="submitbtn_Click" CssClass="submitbutton"/><br />
                    <asp:Label Id="lbldefault" runat="server" CssClass="lablestyle" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
         <br />
          <br />          
          <br />
          <br />                             
    </div>
    <br />
    <br />
    <br />
    <br />
                                                                 <%--grid code here--%>
        <div class="griddivstytle">
        <asp:GridView ID="employeerecord" runat="server" CssClass="gridposition" AutoGenerateColumns ="False" DataKeyNames="empcode" CellPadding="3" 
            OnRowEditing="employeerecord_RowEditing" OnRowCancelingEdit="employeerecord_RowCancelingEdit" OnRowUpdating="employeerecord_RowUpdating" OnRowDeleting="employeerecord_RowDeleting"  ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="white" BorderStyle="None" BorderWidth="1px">
            <Columns>

                <asp:TemplateField HeaderText="EmpCode" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblEmpcode" runat="server" Text='<%# Eval("Empcode") %>'></asp:Label>
                    </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Dept_id" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblDept_id" runat="server" Text='<%# Eval("Dept_id") %>'></asp:Label>
                    </ItemTemplate>


<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Desig" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblDesig" runat="server" Text='<%# Eval("Desig") %>'></asp:Label>
                    </ItemTemplate>

                    <ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:CommandField  ShowEditButton="True" ItemStyle-Width="50px"/>
                <asp:CommandField  ShowDeleteButton="True" ItemStyle-Width="50px"/>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#e6e6e6" ForeColor="#9B35B4" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#999999" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
</div>

                                                   <%--footer code here--%>
    </form>
    
</body>
</html>
