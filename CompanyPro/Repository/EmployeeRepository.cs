using CompanyPro.Models;

namespace CompanyPro.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        //Opration Employee
        ITIContext context;
        public EmployeeRepository(ITIContext context)
        {
            this.context = context;
        }
        public List<Employee> GetByDepartmentID(int deptId)
        {
            return context.Employee.Where(e=>e.DepartmentId== deptId).ToList();
        }
        //get -find -insert -update -delete(CRUD)
        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }
        public Employee Get(int id) {
            return context.Employee.FirstOrDefault(e => e.Id == id);
        }
        public void Insert(Employee obj)
        {
            context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Employee emp = Get(id);
            context.Remove(emp);
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
