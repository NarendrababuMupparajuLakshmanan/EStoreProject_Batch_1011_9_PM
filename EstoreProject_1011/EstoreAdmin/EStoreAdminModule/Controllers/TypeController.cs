using EstoreAdminModel.Models.Types;
using EstoreAdminModel.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace EStoreAdminModule.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            this._typeService = typeService;
        }

        [HttpGet]
        [Route("/")]
        public ActionResult Index()
        {
            List<TypeModel> typeModels
                = this._typeService.GetAllTypes();

            return View(typeModels);
        }

        [HttpGet]
        [Route("Delete/{Id:guid}")]
        public ActionResult Delete(Guid Id)
        {

            this._typeService.DeleteType(Id);

            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("CreateType")]
        public ActionResult CreateType()
        {
            return View();
        }


        [HttpPost]
        [Route("CreateType")]
        public ActionResult CreateType(CreateTypeModel createTypeModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createTypeModel);
            }

            this._typeService.CreateType(createTypeModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditType/{Id:guid}")]
        public ActionResult EditType(Guid Id)
        {
            UpdateTypeModel updateTypeModel
                = this._typeService.EditType(Id);

            return View(updateTypeModel);
        }

        [HttpPost]
        [Route("EditType/{Id:guid}")]
        public ActionResult EditType(UpdateTypeModel updateTypeModel, Guid Id)
        {
            this._typeService.UpdateType(updateTypeModel);

            return RedirectToAction("Index");
        }
    }
}
