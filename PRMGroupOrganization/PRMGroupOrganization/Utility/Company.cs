using PRMGroupOrganization.Interfaces;
using PRMGroupOrganization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRMGroupOrganization.Utility
{
    public class Company:ICompany
    {
        public List<Department> dept = new List<Department>();
        public List<Employee> employees = new List<Employee>();
        int  deptnumber = 0;
        int empNo = 0;
        public int addDepartment(string deptName)
        {
            deptnumber++;
            //Guid deptnumber = Guid.NewGuid();
            dept.Add(new Department(deptnumber, deptName));
            return 0;
        }
        public int addEmployee(IEmployee e, out int id)
        {
            id = ++empNo;
            Employee ee = (Employee)e;
            ee.EmployeeID = id;
            if(ee.DepartmentID<deptnumber && ee.DepartmentID > 0)
            {
                return 0;
            }
            else
            {
                var res = employees.Where(x => x.DepartmentID == ee.DepartmentID).Where(x => x.Designation.ToUpper() == "MANAGER").ToList();
                if (res.Count > 0)
                {
                    return 0;
                }
                else
                {
                    employees.Add((Employee)e);
                }
               
            }
            
            return id ;
        }
        public int editEmployee(int employee)
        {
            foreach(Employee e in employees)
            {
                if (e.EmployeeID == employee)
                {
                    e.Designation = "Manager";
                }
                else
                {
                    return 0;
                }
            }
            return employee;
        }
        public IEmployee viewEmployee(int id)
        {
            return employees.Where(x => x.EmployeeID == id).FirstOrDefault();
        }
        public IEmployee viewEmployee(string name)
        {
            return employees.Where(x => x.FullName == name).FirstOrDefault();
        }
        public int deleteEmployee(int id)
        {
            foreach (Employee e in employees)
            {
                if (e.EmployeeID == id)
                {
                    employees.Remove(e);
                    break;
                }
                else
                {
                    return 0;
                }
            }
            return id;
        }
        public int viewStatistics(int id)
        {
            return employees.Count;
            
        }

        public List<Department> viewDepartments()
        {
            return dept;
        }

    }
}