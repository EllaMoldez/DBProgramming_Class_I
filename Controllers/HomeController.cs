using DBProgramming_Class_I.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBProgramming_Class_I.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // init the context
            var context = new CompanyEntities();
            //**context is a connection between the back-end code and database

            // creating list of employees
            List<Employee> employees = context.Employees
                .Where(x =>
                    x.First_Name != null &&
                    x.Dept_Id != null)
                .OrderBy(x =>
                    x.First_Name)
                .ToList();

            string searchTerm = Request.QueryString.Get("searchTerm");

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                List<string> andSearchTerm = searchTerm.Split('+').ToList();
                employees = employees
                    .Where(x =>
                        x.First_Name.IndexOf(searchTerm) != -1 || x.Last_Name.IndexOf(searchTerm) != -1
                    ).ToList();
            }

            //string searchTerm2 = Request.QueryString.Get("searchTerm2");

            //if (!string.IsNullOrWhiteSpace(searchTerm2))
            //{
            //    List<string> andSearchTerm = searchTerm2.Split('+').ToList();
            //    employees = employees
            //        .Where(y =>
            //            y.Last_Name.IndexOf(searchTerm2) != -1
            //        ).ToList();
            //}

            // creating list of departments
            List<Department> departments = context.Departments.OrderBy(x => x.Dept_Name).ToList();

            //List<string> nameOfDepartments = context.Departments.Select(x => x.Dept.Name).ToList();

            CombinedLists combinedLists = new CombinedLists();
            combinedLists.Department = departments;
            combinedLists.Employees = employees;

            // return Model to View
            return View(combinedLists);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        //public ActionResult DeleteEmployee(string empId)
        public ActionResult DeleteEmployee(int empId)
        {
            var context = new CompanyEntities();
            List<Employee> employees = context.Employees.ToList();
            

            //LINQ
            var employeeToRemove = employees.FirstOrDefault(x => x.Emp_Id == empId);

            //**.Where does not return just 1
            //**.First give us the first encounter

            context.Employees.Remove(employeeToRemove);
            context.SaveChanges();

            //context.Employees.Remove(employeeToRemove.toString());

            //**transaction is a block of database code that signals the database

            return Json(true, JsonRequestBehavior.AllowGet);
            //return View("Index", "Home");
        }

        [HttpPost]
        public ActionResult UpsertEmployee(Employee employee)
        {
            //var context = new CompanyEntities();
            //List<Employee> employees = context.Employees.ToList();

            Random rnd = new Random();

            if (string.IsNullOrWhiteSpace((employee.Emp_Id).ToString()))
            {
                employee.Emp_Id = rnd.Next(1, 300000000);
                //employee.Emp_Id = rnd.Next(1, 300000000).ToString();
            }

            var context = new CompanyEntities();
            try
            {
                context.Employees.AddOrUpdate(employee);
                context.SaveChanges();

                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        //[HttpPost]
        //public JsonResult UpdateEmployee(Employee employee) 
        //{
        //    var context = new CompanyEntities();

        //    try 
        //    {
        //        context.Employees.Add(employee);
        //        context.SaveChanges();

        //        return Json(true);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(false);
        //    }

        //}
    }
}