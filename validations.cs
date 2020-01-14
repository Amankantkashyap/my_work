using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ClassLibrary
{
    public class validations
    {
        public validations()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [Required(ErrorMessage = "Employee Code is required")]
        public string EmployeeCode { get; set; }


        [Required(ErrorMessage = "Employee Name is required")]
        public string EmpName { get; set; }


        [Required(ErrorMessage = "Departement Id is required")]
        public string DeptId { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }


        [Required(ErrorMessage = "DOB is required")]
        [RegularExpression(@"^(19|20)\d\d[-/.]([1-9]|0[1-9]|1[012])[- /.]([1-9]|0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Please enter Valid Date of Birth")]
        public string DateOfBirth { get; set; }


        [Required(ErrorMessage = "Father Name is required")]
        public string FatherName { get; set; }


        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Bank Name is required")]
        public string BankName { get; set; }


        [Required(ErrorMessage = "Accoount No is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter Valid Account No.")]
        public string AccoountNo { get; set; }


        [Required(ErrorMessage = "IFSC Code is required")]
        [RegularExpression(@"[A-Z|a-z]{4}[0][\d]{6}$", ErrorMessage = "Please enter valid IFSC code.")]
        public string IfscCode { get; set; }


        [Required(ErrorMessage = "PAN Card  is required")]
        [RegularExpression(@"^[A-Z]{3}[G|A|F|C|T|H|P]{1}[A-Z]{1}\d{4}[A-Z]{1}$", ErrorMessage = "Please enter valid PAN Card no.")]
        public string PanCard { get; set; }


        [Required(ErrorMessage = "Mobile is required")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string mobile { get; set; }


        [Required(ErrorMessage = "E-mail is required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter proper email")]
        public string email { get; set; }


        [Required(ErrorMessage = "Please Upload Documents")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-\(\):])+(.doc|.docx|.pdf|.txt)$",
        ErrorMessage = "Only (.doc,.txt.pdf) files are allowed")]
        public string fileupload { get; set; }
        



    }
}