using System.ComponentModel.DataAnnotations;

namespace EstoreAdminModel.Models.Types
{
    public class CreateTypeModel
    {
        [Required(ErrorMessage="Type Name is Mandatory")]
        public string Name { get; set; } = string.Empty;
    }
}
