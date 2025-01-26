using System.Collections.Generic;
using EmployeeManagmentLibrary.Models;
using MediatR;

namespace EmployeeManagmentLibrary.Queries
{
    public record GetEmployeeListQuery : IRequest<List<EmployeeModel>>;

}
