using Catalog.Core.DTOs;
using MediatR;

namespace Catalog.Application.Commands
{
    public record UpdateBrandCommand(BrandDTO BrandDTO)
        : IRequest<BrandDTO>
    {

    }
}
