using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagmentLibrary.Commands;
using EmployeeManagmentLibrary.Models;
using EmployeeManagmentLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MidatR_API_Demo_DotNet5.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<EmployeeModel>>> GetEmployees()
        {
            return await _mediator.Send(new GetEmployeeListQuery());
        }
        [HttpGet]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeById(int id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery(id));
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> AddEmployee(string firstName, string lastName)
        {
            return Ok(await _mediator.Send(new AddEmployeeCommand(firstName, lastName)));
        }
    }
}
