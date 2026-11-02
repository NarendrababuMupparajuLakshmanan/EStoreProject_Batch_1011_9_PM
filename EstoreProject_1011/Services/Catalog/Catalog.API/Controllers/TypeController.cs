using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllTypes")]
        public IActionResult GetAllTypes()
        {
            var query = new GetAllTypeQuery();
            var result = this._mediator.Send(query).Result;

            return Ok(result);
        }

        [HttpGet]
        [Route("GetTypeByID/{id:guid}")]
        public IActionResult GetTypeByID(Guid id)
        {
            var query = new GetTypeByIDQuery(id);
            var result = this._mediator.Send(query).Result;

            return Ok(result);
        }
        
        [HttpPost]
        [Route("CreateType")]   
        public IActionResult CreateType(CreateTypeDTO typeDTO)
        {
            var command = new CreateTypeCommand(typeDTO);

            var result = this._mediator.Send(command).Result;

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteType/{id:guid}")]
        public IActionResult DeleteType(Guid id)
        {
            var command = new DeleteTypeCommand(id);
            var result = this._mediator.Send(command).Result;
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateType")]
        public IActionResult UpdateType(TypeDTO typeDTO)
        {
            var command = new UpdateTypeCommand(typeDTO);
            var result = this._mediator.Send(command).Result;
            return Ok(result);
        }
    }
}
