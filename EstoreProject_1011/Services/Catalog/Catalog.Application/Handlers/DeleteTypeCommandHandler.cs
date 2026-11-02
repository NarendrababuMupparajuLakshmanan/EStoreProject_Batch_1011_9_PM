using Catalog.Application.Commands;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class DeleteTypeCommandHandler
        : IRequestHandler<DeleteTypeCommand, bool>
    {
        private readonly TypeRepository _typeRepository;

        public DeleteTypeCommandHandler(TypeRepository typeRepository)
        {
            this._typeRepository = typeRepository;
        }

        public async Task<bool> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            TypeModel? typeModel
                = this._typeRepository.Types
                .Where(x => x.Id == request.Id)
                .FirstOrDefault();  

            if (typeModel == null)
                throw new Exception($"Type with ID {request.Id} not found.");

            this._typeRepository.Types.Remove(typeModel);
            this._typeRepository.SaveChanges();

            return true;
        }
    }
}
