using EmployeeManagmentLibrary.Models;
using MediatR;

namespace EmployeeManagmentLibrary.Queries
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeModel>;
}
