using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRMGroupOrganization.Models
{
    public class Department
    {
        //public int MyProperty { get; set; }
        public int DepartmentID;

        public string DepartmentName;

        public Department()
        {

        }

        public Department(int DepartmentID, string DepartmentName)
        {
            this.DepartmentID = DepartmentID;
            this.DepartmentName = DepartmentName;
        }
    }
}