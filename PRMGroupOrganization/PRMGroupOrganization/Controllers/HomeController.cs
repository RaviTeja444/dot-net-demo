using PRMGroupOrganization.Interfaces;
using PRMGroupOrganization.Models;
using PRMGroupOrganization.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRMGroupOrganization.Controllers
{
    public class HomeController : Controller
    {
        public Company company;
        public HomeController()
        {
            company = new Company();
        }
        public ActionResult Index()
        {
            Company comp = Session["comp"] as Company;
            if (comp == null)
            {
                Session["comp"] = company;
            }
            
            
            return View();
        }
        
        public ActionResult AddDept()
        {
            return View();
        }

        public ActionResult AddDept1(string value)
        {
            Company comp = Session["comp"] as Company;
            comp.addDepartment(value);
            Session["comp"] = comp;
            ViewBag.deptid = value;
            return View();
        }
        
        public ActionResult AddEmp()
        {
           
            return View();
        }

        public ActionResult AddEmp1(string fullname,string dob,string exp,string design,string basicpay,string deptid)
        {
            Company comp = Session["comp"] as Company;
            Employee emp = new Employee();
            emp.FullName = fullname;
            emp.DateOfBirth = Convert.ToDateTime(dob);
            emp.Experience = Convert.ToInt32(exp);
            emp.Designation = design;
            emp.BasicPay = Convert.ToInt32(basicpay);
            emp.DepartmentID = Convert.ToInt32(deptid);
            if (emp.Designation.ToUpper() == "EMPLOYEE")
            {
                emp.GrossPay = emp.BasicPay + (0.1 * emp.BasicPay);
            }
            else
            {
                emp.GrossPay = emp.BasicPay + (0.1 * emp.BasicPay) + (0.1 * emp.BasicPay);
            }
            int id;
            int output= comp.addEmployee(emp, out id);
            Session["comp"] = comp;
            Session["allemp"] = comp.employees;
            if (output > 0)
            {
                ViewBag.grossSal = emp.GrossPay;
                return View();
            }

            else
            {
                ViewBag.grossSal = 0;
                return View();
            }
               
        }

        public ActionResult EditEmp()
        {

            return View();
        }
        
        public ActionResult EditEmp1(String empNo1)
        {
            Company comp = Session["comp"] as Company;
            int empid= comp.editEmployee(Convert.ToInt32(empNo1));
            Session["comp"] = comp;
            ViewBag.empid = empid;
            return View();
        }

        public ActionResult RemoveEmp()
        {

            return View();
        }

        public ActionResult RemoveEmp1(string empNo)
        {
            Company comp = Session["comp"] as Company;
            int empid = comp.deleteEmployee(Convert.ToInt32(empNo));
            Session["comp"] = comp;
            ViewBag.remid = empid;
            return View();
        }

        public ActionResult Stats()
        {
            Company comp = Session["comp"] as Company;
            int count= comp.viewStatistics(0);
            Session["comp"] = comp;
            ViewBag.count = count;
            return View();
        }

        public ActionResult Departments()
        {
            Company comp = Session["comp"] as Company;
            List<Department> count = comp.viewDepartments();
            Session["comp"] = comp;

            return View(count);
        }
        
         public ActionResult ViewEmp()
        {

            return View();
        }

        public ActionResult ViewEmp1(string empdetail)
        {
            Company comp = Session["comp"] as Company;
            Employee count = null;
            count = (Employee)comp.viewEmployee(Convert.ToInt32(empdetail));
            if (count==null)
            {
                count = (Employee)comp.viewEmployee(empdetail);
            }
            Session["comp"] = comp;
            return View(count);
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
    }
}