using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagmentLibrary.Models;
using EmployeeManagmentLibrary.Queries;
using MediatR;

namespace EmployeeManagmentLibrary.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeModel>
    {
        private readonly IMediator _mediator;

        public GetEmployeeByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<EmployeeModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employees = await _mediator.Send(new GetEmployeeListQuery());
            var employee = employees.FirstOrDefault(x => x.Id == request.Id);
            return employee;
        }
    }
}
