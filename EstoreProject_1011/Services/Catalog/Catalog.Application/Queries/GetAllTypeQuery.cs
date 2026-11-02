using Catalog.Core.DTOs;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetAllTypeQuery:
        IRequest<List<TypeDTO>>
    {
    }
}
