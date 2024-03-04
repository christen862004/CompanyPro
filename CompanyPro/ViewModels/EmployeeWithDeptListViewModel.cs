using CompanyPro.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyPro.ViewModels
{
    public class EmployeeWithDeptListViewModel
    {
        //Model Employee Edit
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public string? ImageURl { get; set; }
        public string? jobTitle { get; set; }
        public int DepartmentId { get; set; }
        //+DeptList
        public List<Department> Departments { get; set; }
    }
    //public class DeptVM
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
