using EstoreAdminModel.Models.Types;

namespace EstoreAdminModel.Services
{
    public interface ITypeService
    {
        List<TypeModel> GetAllTypes();

        void DeleteType(Guid Id);

        void CreateType(CreateTypeModel createTypeModel);

        UpdateTypeModel EditType(Guid Id);

        void UpdateType(UpdateTypeModel updateTypeModel);
    }
}
