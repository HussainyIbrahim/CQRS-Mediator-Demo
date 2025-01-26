

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagmentLibrary.Data;
using EmployeeManagmentLibrary.Models;
using EmployeeManagmentLibrary.Queries;
using MediatR;

namespace CQRS_MidatR_API_Demo_DotNet5.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeModel>>
    {
        private readonly IDataAccess _dataAccess;

        public GetEmployeeListHandler(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }
        public Task<List<EmployeeModel>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetEmployees());
        }
    }
}
