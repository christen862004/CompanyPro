using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyPro.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Unique]
        [MaxLength(25,ErrorMessage ="Name Must be less than 25 char")]
        [MinLength(3,ErrorMessage ="NAme Must be more than 3 char")]
        public string Name { get; set; }

        [RegularExpression("(Cairo|Monofia|Alex)" 
            ,ErrorMessage = "Address must be Alex or Monofia or Cairo")]
        public string Address { get; set; }

        //[Range(6000,25000,ErrorMessage ="Salary must be between 6000 to 25000")]
        [DivByNo(20,ErrorMessage ="Salary Must be divided by 20")]
        [Remote("CheckSalary","Employee",
            ErrorMessage ="salary must more than 6000"
            ,AdditionalFields = "jobTitle")]//Employee/CheckSalary?Salary=3000
        public int Salary { get; set; }
        


        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be png or jpg")]
        public string? ImageURl { get; set; }
       
        [Display(Name="Job Title")]
        public string? jobTitle { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department")]
        

        public int DepartmentId { get; set; }
        //public bool isDelete { get; set; } = false;
        
        public Department? Department { get; set; }
    }
}
