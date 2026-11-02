using Catalog.Core.DTOs;
using MediatR;

namespace Catalog.Application.Commands
{
    public record CreateTypeCommand(CreateTypeDTO CreateTypeDTO)
        : IRequest<Guid>
    {

    }
}
