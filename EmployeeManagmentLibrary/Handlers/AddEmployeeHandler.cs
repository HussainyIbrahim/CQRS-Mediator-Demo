using System.Threading;
using System.Threading.Tasks;
using EmployeeManagmentLibrary.Commands;
using EmployeeManagmentLibrary.Data;
using EmployeeManagmentLibrary.Models;
using MediatR;

namespace EmployeeManagmentLibrary.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, EmployeeModel>
    {
        private readonly IDataAccess _dataAccess;

        public AddEmployeeHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<EmployeeModel> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.AddEmployee(request.FirstName, request.LastName));
        }
    }
}
