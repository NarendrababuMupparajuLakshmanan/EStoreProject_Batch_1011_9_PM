using Catalog.Core.DTOs;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetAllBrandQuery(): IRequest<List<BrandDTO>>
    {
    }
}
