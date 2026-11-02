using EstoreAdminModel.Models.Types;
using EstoreAdminModel.Services;
using EStoreAdminRepository;

namespace EstoreAdminService
{
    public class TypeService : ITypeService
    {
        private readonly TypeRepository _typeRepository;

        public TypeService(TypeRepository typeRepository)
        {
            this._typeRepository = typeRepository;
        }

        public void CreateType(CreateTypeModel createTypeModel)
        {
            if (createTypeModel == null)
                throw new Exception("Create Type Model is not null or Empty");

            TypeModel typeModel = new TypeModel()
            {
                Id = Guid.NewGuid(),
                Name = createTypeModel.Name
            };

            this._typeRepository.Add(typeModel);
            this._typeRepository.SaveChanges();
        }

        public void DeleteType(Guid Id)
        {
            if (Id == Guid.Empty)
                throw new Exception("ID is not null or Empty");

            TypeModel? typeModel
                = this._typeRepository.Types.Where(e => e.Id == Id).FirstOrDefault();

            if (typeModel == null)
                throw new Exception("Type Model is not null or Empty");

            this._typeRepository.Remove(typeModel);
            this._typeRepository.SaveChanges();
        }

        public UpdateTypeModel EditType(Guid Id)
        {
            if (Id == Guid.Empty)
                throw new Exception("Id not found");

            TypeModel? typeModel
                = this._typeRepository.Types.Where(e => e.Id == Id).FirstOrDefault();

            if (typeModel == null)
                throw new Exception("Type Model is not null or Empty");

            UpdateTypeModel updateTypeModel
                = new UpdateTypeModel()
                {
                    Id = typeModel.Id,
                    Name = typeModel.Name
                };

            return updateTypeModel;

        }

        public List<TypeModel> GetAllTypes()
        {
            List<TypeModel> types =
                this._typeRepository.Types.ToList();
            return types;
        }

        public void UpdateType(UpdateTypeModel updateTypeModel)
        {
            if (updateTypeModel == null)
                throw new Exception("update type is not null or empty");

            TypeModel typeModel
                = new TypeModel()
                {
                    Id = updateTypeModel.Id,
                    Name = updateTypeModel.Name
                };

            this._typeRepository.Update(typeModel);
            this._typeRepository.SaveChanges();
        }
    }
}

