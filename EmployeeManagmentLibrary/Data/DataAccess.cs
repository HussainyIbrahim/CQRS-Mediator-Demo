using System.Collections.Generic;
using System.Linq;
using EmployeeManagmentLibrary.Models;

namespace EmployeeManagmentLibrary.Data
{
    public class DataAccess : IDataAccess
    {
        private List<EmployeeModel> _employees = new();
        public DataAccess()
        {
            _employees.Add(new EmployeeModel { Id = 1, FirstName = "hussainy", LastName = "ibrahim" });
            _employees.Add(new EmployeeModel { Id = 2, FirstName = "hussainy2", LastName = "ibrahim2" });
        }
        public EmployeeModel AddEmployee(string firtName, string lastName)
        {
            var employee = new EmployeeModel { Id = _employees.Max(x => x.Id) + 1, FirstName = firtName, LastName = lastName };
            _employees.Add(employee);
            return employee;
        }

        public List<EmployeeModel> GetEmployees()
        {
            return _employees;
        }
    }
}
