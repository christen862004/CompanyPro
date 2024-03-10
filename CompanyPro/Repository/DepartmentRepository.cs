using CompanyPro.Models;

namespace CompanyPro.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        ITIContext context;
        public string Id { get; set; }

        public DepartmentRepository(ITIContext iticontext)//inject
        {
            context = iticontext;
            Id = Guid.NewGuid().ToString();
        }

        //get -find -insert -update -delete(CRUD)
        public List<Department> GetAll()
        {
            return context.Set<Department>().ToList();
        }
        public Department Get(int id)
        {
            return context.Set<Department>().Find(id);//.FirstOrDefault(e => e.Id == id);
        }
        public void Insert(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Department emp = Get(id);
            context.Remove(emp);
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
