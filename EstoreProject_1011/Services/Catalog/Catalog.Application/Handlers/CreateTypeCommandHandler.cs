using Catalog.Application.Commands;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateTypeCommandHandler
        : IRequestHandler<CreateTypeCommand, Guid>
    {
        private readonly TypeRepository _typeRepository;

        public CreateTypeCommandHandler(TypeRepository typeRepository)
        {
            this._typeRepository = typeRepository;
        }

        public async Task<Guid> Handle(CreateTypeCommand request, 
            CancellationToken cancellationToken)
        {
            TypeModel typeModel = new TypeModel()
            {
                Id = Guid.NewGuid(),
                Name = request.CreateTypeDTO.Name
            };
              
            this._typeRepository.Types.Add(typeModel);  
            this._typeRepository.SaveChanges();

            return typeModel.Id;


        }
    }
}
