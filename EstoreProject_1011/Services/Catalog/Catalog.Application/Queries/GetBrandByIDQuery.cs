using Catalog.Core.DTOs;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetBrandByIDQuery(Guid Id)
        : IRequest<BrandDTO>
    {
    }
}
