using DotNETDay2.Models;
using System.Data.Entity;

namespace DotNETDay2.Services
{
    public class InstructorService : IInstructorService
    {
        Day2context context;
        public InstructorService(Day2context _context)
        {
            context = _context;
        }
        public List<instructorwithdeptname> GetInstructorwithdeptnames()
        {

            List<instructorwithdeptname> lisdep = context.Instructor
                .Include(s => s.dept).
                Select(i => new instructorwithdeptname
                {
                    id = i.ID,
                    name = i.name,
                    address = i.address,
                    salary = i.salary,
                    departmentname = i.dept.name
                }).ToList();

            return lisdep;
        }
        public List<Instructor> getAll()
        {
            List<Instructor> inst = context.Instructor.ToList();
            return inst;
        }
        public Instructor getById(int id)
        {
            Instructor inst = context.Instructor.FirstOrDefault(s => s.ID == id);
            return inst;
        }
        public Instructor getbyName(string Name)
        {
            Instructor inst = context.Instructor.FirstOrDefault(s => s.name == Name);
            return inst;
        }
        public int create(Instructor inst)
        {
            context.Instructor.Add(inst);
            return context.SaveChanges();
        }
        public int update(int id, Instructor newinst)
        {
            Instructor oldinst = context.Instructor.FirstOrDefault(s => s.ID == id);
            oldinst.name = newinst.name;
            oldinst.address = newinst.address;
            oldinst.dept = newinst.dept;
            oldinst.salary = newinst.salary;
            return context.SaveChanges();
        }
        public int delete(int id)
        {
            Instructor inst = context.Instructor.FirstOrDefault(s => s.ID == id);
            context.Instructor.Remove(inst);
            return context.SaveChanges();
        }
        public List<Instructor> details(int id)
        {
           return context.Instructor.Where(s => s.dept_id == id).ToList();
        }
    }
}
