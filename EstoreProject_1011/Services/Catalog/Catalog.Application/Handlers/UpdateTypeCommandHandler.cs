using Catalog.Application.Commands;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateTypeCommandHandler
        : IRequestHandler<UpdateTypeCommand, bool>
    {
        private readonly TypeRepository _typeRepository;

        public UpdateTypeCommandHandler(TypeRepository typeRepository)
        {
            this._typeRepository = typeRepository;
        }

        public async Task<bool> Handle(UpdateTypeCommand request, 
            CancellationToken cancellationToken)
        {
            if (request.TypeDTO == null)
                throw new Exception("TypeDTO cannot be null.");

            TypeModel typeModel = new TypeModel()
            {
                Id = request.TypeDTO.Id,
                Name = request.TypeDTO.Name
            };

            this._typeRepository.Types.Update(typeModel);
            this._typeRepository.SaveChanges();
            return true;
        }
        
    }
}
