using DotNETDay2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace DotNETDay2.Controllers
{
    public class InstructorController : Controller
    {

        Day2context context = new Day2context();
        public IActionResult Showinstructor()
        {
            List<instructorwithdeptname> lisdept =
                context.Instructor
                .Include(s => s.dept)
                .Select(i => new instructorwithdeptname
                {
                    id = i.ID,
                    name = i.name,
                    salary = i.salary,
                    address= i.address,
                    departmentname = i.dept.name
                }).ToList();
            return View(lisdept);
        }

        public IActionResult Add(int id)
        {

            List<Department> dept = context.Department.ToList();
            ViewData["depts"] = dept;
            Instructor inst =context.Instructor.FirstOrDefault(s=>s.ID==id);
            return View(inst);
        }
        public IActionResult save([FromRoute]int id,Instructor newinstr)
        {
            Instructor inst = context.Instructor.FirstOrDefault(s => s.ID == id);
            inst.name=newinstr.name;
            inst.address=newinstr.address;
            inst.salary=newinstr.salary;
            inst.dept_id=newinstr.dept_id;
            context.SaveChanges();
            return RedirectToAction("showinstructor");  
        }
        public IActionResult Delete(int id)
        {
            Instructor inst = context.Instructor.FirstOrDefault(s => s.ID == id);
            if(inst!= null)
            {   
                context.Instructor.Remove(inst);
                context.SaveChanges();
            }
            return RedirectToAction("Showinstructor");
        }

        public IActionResult addnewuser() 
        {
            Instructor inst =new Instructor();

            List<Department>dept =context.Department.ToList();
            ViewData["depts"]=dept;

            return View(inst);
        }
        public IActionResult savenewuser(Instructor inst)
        {
            if(inst.salary!=null && inst.address!=null &&inst.name!=null && inst.dept_id!=null) 
            {
                inst.image = "image.1";
                context.Instructor.Add(inst);
                context.SaveChanges();
                return RedirectToAction("showinstructor");
            }
            return View("addnewuser", inst);
         
        }

        public IActionResult Details(int id)
        {
            List<Instructor> instmodel =
            context.Instructor.Where(s=>s.dept_id==id).ToList();
            return View("Details",instmodel);
        }
    }
}
