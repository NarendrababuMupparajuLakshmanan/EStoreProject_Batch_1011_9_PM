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
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("ListBrands")]
        public IActionResult ListBrands()
        {
            var query = new GetAllBrandQuery();

            var response = this._mediator.Send(query).Result;

            return Ok(response);
        }

        [HttpGet]
        [Route("GetBrandByID/{Id:guid}")]
        public IActionResult GetBrandByID(Guid Id)
        {
            var query = new GetBrandByIDQuery(Id);

            var response = this._mediator.Send(query).Result;

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateBrand")]
        public IActionResult CreateBrand(CreateBrandDTO createBrandDTO)
        {
            var command = new CreatedBrandCommand(createBrandDTO);

            var result = this._mediator.Send(command).Result;

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateBrand")]
        public IActionResult UpdateBrand(BrandDTO brandDTO)
        {
            var command = new UpdateBrandCommand(brandDTO);

            var result = this._mediator.Send(command).Result;

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteBrand")]
        public IActionResult DeleteBrand(Guid Id)
        {
            var command = new DeleteBrandCommand(Id);

            var result = this._mediator.Send(command).Result;

            return Ok(result);
        }
    }
}
