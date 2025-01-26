using System.Collections.Generic;
using EmployeeManagmentLibrary.Models;

namespace EmployeeManagmentLibrary.Data
{
    public interface IDataAccess
    {
        List<EmployeeModel> GetEmployees();
        EmployeeModel AddEmployee(string firtName, string lastName);
    }
}
