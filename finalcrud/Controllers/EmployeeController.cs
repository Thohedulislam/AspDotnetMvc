using finalcrud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalcrud.Controllers
{
   
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeDB DB = new EmployeeDB();
        [HttpGet]
        public ActionResult Crud(int? id)
        {
            var emp = (from o in DB.Employees where o.EmpID == id select o).FirstOrDefault();
            ViewData["List"] = DB.Employees.ToList();
            ViewBag.key = DB.Departments;
            return View(emp);
        }
        [HttpPost]
        public ActionResult Crud(Employee employee, HttpPostedFileBase img)
        {
            string fileName = "";
            if(img != null)
            {
                fileName = img.FileName;
                string picture = System.IO.Path.GetFileName(fileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Picture/"), picture);
                img.SaveAs(path);
            }
            var emp = DB.Employees.Find(employee.EmpID);
            ViewBag.key = DB.Departments;
            if(emp == null)
            {
                employee.Photo = "/Picture/" + fileName;
                DB.Employees.Add(employee);
            }
            else
            {
                emp.EmpName = employee.EmpName;
                emp.Email = employee.Email;
                emp.Gender = employee.Gender;
                emp.Joindate = employee.Joindate;
                emp.DeptID = employee.DeptID;
                emp.Salary = employee.Salary;
                emp.Photo = "/Picture/" + fileName;
            }
            DB.SaveChanges();
            ViewData["List"] = DB.Employees.ToList();
            return RedirectToAction("Crud");
        }
        [HttpGet]
        [Route("Delete")]

        public ActionResult Delete(int id)
        {
            var emp = (from o in DB.Employees where o.EmpID == id select o).FirstOrDefault();
            DB.Employees.Remove(emp);
            DB.SaveChanges();
            return RedirectToAction("Crud");
        }
    }
}