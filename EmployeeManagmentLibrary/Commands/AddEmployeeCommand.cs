using EmployeeManagmentLibrary.Models;
using MediatR;

namespace EmployeeManagmentLibrary.Commands
{
    public record AddEmployeeCommand(string FirstName, string LastName) : IRequest<EmployeeModel>;
}
