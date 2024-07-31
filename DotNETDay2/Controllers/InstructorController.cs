using DotNETDay2.Models;
using DotNETDay2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
namespace DotNETDay2.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        IInstructorService InstructorService;
        IDepartmentService DepartmentService;
        //DI 
        //IOC container ==ServiceProvider
        public InstructorController(IInstructorService _instS,IDepartmentService _deptS)
        {
            InstructorService = _instS;
            DepartmentService = _deptS;
        }
        public IActionResult NameExist(string Name, int id)
        {
            if (id == 0)//new
            {
                Instructor inst = InstructorService.getbyName(Name);
                if (inst == null)
                    return Json(true);
                else return Json(false);
            }
            else//Edit
            {
                Instructor inst = InstructorService.getbyName(Name);
                if (inst == null)
                    return Json(true);
                else
                {
                    if (inst.ID == id)
                        return Json(true);
                    else
                        return Json(false);
                }
            }
        }
        public IActionResult Showinstructor()
        {
            List<instructorwithdeptname> lisdept = InstructorService.GetInstructorwithdeptnames();
            return View(lisdept);
        }

        public IActionResult Edit(int id)
        {

            List<Department> dept = DepartmentService.getAll();
            ViewData["depts"] = dept;
         
            Instructor inst =InstructorService.getById(id);
            return View(inst);
        }
        public IActionResult save([FromRoute]int id,Instructor newinstr)
        {
            InstructorService.update(id, newinstr);
            return RedirectToAction("showinstructor");  
        }
        public IActionResult Delete(int id)
        {

            Instructor inst = InstructorService.getById(id);
            if(inst!= null)
            {   
                InstructorService.delete(id);
            }
            return RedirectToAction("Showinstructor");
        }

        public IActionResult addnewuser() 
        {
            Instructor inst =new Instructor();

            List<Department>dept =DepartmentService.getAll();
            ViewData["depts"]=dept;

            return View(inst);
        }
        public IActionResult savenewuser(Instructor inst)
        {
            List<Department>dept=DepartmentService.getAll();
            ViewData["depts"] = dept;
            //if(inst.salary!=null && inst.address!=null &&inst.name!=null && inst.dept_id!=null) 
                inst.image = "image.png";
            if(ModelState.IsValid)
            {
                InstructorService.create(inst);
                return RedirectToAction("showinstructor");
            }
            return View("addnewuser", inst);
         
        }

        public IActionResult Details(int id)
        {
            List<Instructor> instmodel = InstructorService.details(id);
            return View("Details",instmodel);
        }
    }
}
