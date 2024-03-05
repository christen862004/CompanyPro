using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyPro.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public string? ImageURl { get; set; }
        [Display(Name="Job Title")]
        public string? jobTitle { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        //public bool isDelete { get; set; } = false;

        public Department Department { get; set; }
    }
}
