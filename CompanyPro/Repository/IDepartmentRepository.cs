using CompanyPro.Models;

namespace CompanyPro.Repository
{
    public interface IDepartmentRepository
    {
        public string Id { get; set; }

        public List<Department> GetAll();

        public Department Get(int id);

        public void Insert(Department obj);

        public void Update(Department obj);

        public void Delete(int id);

        public int Save();
    }
}