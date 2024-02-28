namespace CompanyPro.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>();
            students.Add(new Student() { Id=1,Name="Ahmed",Address="Alex",ImageUrl="m.png",DeptId=1});
            students.Add(new Student() { Id = 2, Name = "Mohamed", Address = "Alex", ImageUrl = "m.png", DeptId = 1 });
            students.Add(new Student() { Id = 3, Name = "Sara", Address = "Cairo", ImageUrl = "2.jpg", DeptId = 2 });
            students.Add(new Student() { Id = 4, Name = "Asmaa", Address = "monof", ImageUrl = "2.jpg", DeptId = 3 });
            students.Add(new Student() { Id = 5, Name = "Alaa", Address = "Minia", ImageUrl = "m.png", DeptId = 2 });
        }
        public Student GetByID(int id)
        {
            return students.FirstOrDefault(e => e.Id == id);
        }
        public List<Student> GetAll()
        {
            return students;
        }
    }
}
