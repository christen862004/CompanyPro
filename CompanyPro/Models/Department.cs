using System.ComponentModel.DataAnnotations;

namespace CompanyPro.Models
{
    public class Department
    {
        //[Key]
        public int Id { get; set; }//primary key identty
        public string Name { get; set; }
        public string ManagerName { get; set; }

        public List<Employee> Emps { get; set; }
    }
}
