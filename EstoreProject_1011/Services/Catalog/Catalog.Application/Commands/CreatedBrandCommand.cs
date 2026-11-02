using Catalog.Core.DTOs;
using MediatR;

namespace Catalog.Application.Commands
{
    public record CreatedBrandCommand(CreateBrandDTO CreateBrandDTO)
        : IRequest<Guid>
    {
    }
}
