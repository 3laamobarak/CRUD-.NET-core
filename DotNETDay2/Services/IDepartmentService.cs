using DotNETDay2.Models;

namespace DotNETDay2.Services
{
    public interface IDepartmentService
    {
        int create(Department Dept);
        int delete(int id);
        List<Department> getAll();
        Department getById(int id);
        List<Instructor> GetInstructorByDeptName(string name);
        int update(int id, Department newDept);
    }
}