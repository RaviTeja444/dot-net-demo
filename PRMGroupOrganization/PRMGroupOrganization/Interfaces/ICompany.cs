using PRMGroupOrganization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRMGroupOrganization.Interfaces
{
    public interface ICompany
    {
        int addDepartment(string deptName);
        int addEmployee(IEmployee e, out int id);
        int editEmployee(int employee);
        IEmployee viewEmployee(int id);
        IEmployee viewEmployee(string name);
        int deleteEmployee(int id);
        int viewStatistics(int id);
        List<Department> viewDepartments();

    }
}
