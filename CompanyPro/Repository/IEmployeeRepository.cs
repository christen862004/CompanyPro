using CompanyPro.Models;

namespace CompanyPro.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetByDepartmentID(int deptId);

        public List<Employee> GetAll();

        public Employee Get(int id);

        public void Insert(Employee obj);

        public void Update(Employee obj);

        public void Delete(int id);

        public int Save();
        
    }
}