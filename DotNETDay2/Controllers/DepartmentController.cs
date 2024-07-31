using DotNETDay2.Models;
using DotNETDay2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNETDay2.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        
        IDepartmentService departmentService;
        public DepartmentController(IDepartmentService _dept)
        {
            departmentService = _dept;
        }

        public IActionResult ShowDept()
        {
            List<Department> deptmodel = departmentService.getAll();
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
                departmentService.create(dept);
                return RedirectToAction("ShowDept");
            }
            return View("add",dept);
        }
        public IActionResult GetInstructorByDeptName(string name)
        {
            List<Department> dept = departmentService.getAll();
            ViewData["depts"] = dept;

            List<Instructor> inst = departmentService.GetInstructorByDeptName(name);
            return PartialView(inst);
        }

        public IActionResult Edit(int id)
        {
            Department inst = departmentService.getById(id);
            return View(inst);
        }
        public IActionResult SaveEdit([FromRoute]int id,Department dept)
        {
            departmentService.update(id,dept);
            return RedirectToAction("ShowDept");            
        }
        public IActionResult Delete(int id)
        {
            departmentService.delete(id);
            return RedirectToAction("showDept");
        }
    }
}
