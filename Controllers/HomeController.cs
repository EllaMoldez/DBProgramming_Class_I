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
                employees = employees
                    .Where(x =>
                        x.First_Name.IndexOf(searchTerm) != -1
                    ).ToList();
            }

            // creating list of departments
            List<Department> departments = context.Departments.OrderBy(x => x.Dept_Name).ToList();

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

            context.Employees.Remove(employeeToRemove);
            //context.Employees.Remove(employeeToRemove.toString());
            context.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpsertEmployee(Employee employee)
        {
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
    }
}