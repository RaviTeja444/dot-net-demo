using PRMGroupOrganization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRMGroupOrganization.Models
{
    public class Employee:IEmployee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
        public string Designation { get; set; }
        public int BasicPay { get; set; }
        public double GrossPay { get; set; }
        public int DepartmentID { get; set; }

    }
}