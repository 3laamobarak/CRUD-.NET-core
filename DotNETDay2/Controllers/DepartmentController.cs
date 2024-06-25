using DotNETDay2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNETDay2.Controllers
{
    public class DepartmentController : Controller
    {
        Day2context context =new Day2context();

        public IActionResult ShowDept()
        
        {
            List<Department> deptmodel =
                context.Department.ToList();
            return View(deptmodel);
        }

        public IActionResult add()
        {
            Department department = new Department();
            return View(department);
        }
        public IActionResult save(Department dept)
        {
            if(dept.manager!=null&& dept.name !=null)
            {
                context.Department.Add(dept);
                context.SaveChanges();
                return RedirectToAction("ShowDept");
            }
            return View("add",dept);
        }
        public IActionResult GetInstructorByDeptName(string name)
        {
            List<Department> dept = context.Department.ToList();
            ViewData["depts"] = dept;

            List<Instructor> inst = context.Instructor.Where(s => s.dept.name == name).ToList();
            return PartialView(inst);
        }
    }
}
