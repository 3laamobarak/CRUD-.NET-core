using DotNETDay2.Models;

namespace DotNETDay2.Services
{
    public interface IInstructorService
    {
        int create(Instructor inst);
        int delete(int id);
        List<Instructor> getAll();
        Instructor getById(int id);
        Instructor getbyName(string Name);
        List<instructorwithdeptname> GetInstructorwithdeptnames();
        int update(int id, Instructor newinst);
        List<Instructor> details(int id);
    }
}