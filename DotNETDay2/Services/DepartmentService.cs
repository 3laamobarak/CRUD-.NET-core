using DotNETDay2.Models;

namespace DotNETDay2.Services
{
    public class DepartmentService : IDepartmentService
    {
        Day2context context;
        public DepartmentService(Day2context _context)
        {
            context = _context;            
        }
        public List<Department> getAll()
        {
            List<Department> Dept = context.Department.ToList();
            return Dept;
        }
        public Department getById(int id)
        {
            Department Dept = context.Department.FirstOrDefault(s => s.ID == id);
            return Dept;
        }
        public int create(Department Dept)
        {
            context.Department.Add(Dept);
            return context.SaveChanges();
        }
        public int update(int id, Department newDept)
        {
            Department oldDept = context.Department.FirstOrDefault(s => s.ID == id);
            oldDept.name = newDept.name;
            oldDept.manager = newDept.manager;
            return context.SaveChanges();
        }
        public int delete(int id)
        {
            Department Dept = context.Department.FirstOrDefault(s => s.ID == id);
            context.Department.Remove(Dept);
            return context.SaveChanges();
        }
        public List<Instructor> GetInstructorByDeptName(string name)
        {
            List<Instructor> inst = context.Instructor.Where(s => s.dept.name == name).ToList();
            return inst;
        }
    }
}
