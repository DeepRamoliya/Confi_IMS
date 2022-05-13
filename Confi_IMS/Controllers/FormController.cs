using IMS.Model;
using IMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Confi_IMS.Controllers
{
    public class FormController : Controller
    {
        
        
        private readonly FormService formService;
        public FormController()
        {
            formService = new FormService();
        }
        public ActionResult Index(int? page)
        {

            List<FormModel> FormsList = formService.GetAllForms();
            return View(FormsList);

        }

        public ActionResult Create(int? id)
        {
            string actionPermission = "";

            int userId = SessionHelper.UserId;
            FormModel model = new FormModel();
            if (id.HasValue)
            {
                var formDetail = formService.GetFormsById(id.Value);
                if (formDetail != null)
                {
                    model.Id = id.Value;
                    model.Id = formDetail.Id;
                    model.Name = formDetail.Name;
                    model.NavigateURL = formDetail.NavigateURL;
                    model.ParentFormId = formDetail.ParentFormId;
                    model.FormAccessCode = formDetail.FormAccessCode;
                    model.DisplayOrder = formDetail.DisplayOrder;
                    model.IsDisplayMenu = formDetail.IsDisplayMenu;
                    model.IsActive = formDetail.IsActive;
                }
            }
            BindDropdown(ref model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FormModel model)
        {
            string actionPermission = "";


            int userId = SessionHelper.UserId;


            formService.SaveUpdateForm(model);

            return RedirectToAction("Index");

        }

        private void BindDropdown(ref FormModel model)
        {
            BindParentForm(ref model);
        }

        public FormModel BindParentForm(ref FormModel model)
        {
            int currentFormId = model.Id;
            var getparentform = formService.GetAllForms().Where(f => f.Id != currentFormId).Select(a => new FormModel { Id = a.Id, Name = a.Name }).OrderBy(a => a.Name);
            model._ParentFormList.Add(new SelectListItem() { Text = "Select Parent", Value = "" });
            foreach (var item in getparentform)
            {
                model._ParentFormList.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }
            return model;
        }
        public JsonResult CheckDuplicateFormAccessCode(string FormAccessCode, int Id)
        {
            var checkduplicate = formService.CheckDuplicateFormAccessCode(FormAccessCode);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        
    }
}   
