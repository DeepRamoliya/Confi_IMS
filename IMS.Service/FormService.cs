using IMS.DataAccess;
using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service
{
    public class FormService
    {
        public readonly FormProvider _formsProvider;
        public FormService()
        {
            _formsProvider = new FormProvider();
        }

        public List<FormModel> GetAllForms()
        {
            var forms = _formsProvider.GetAllForms();
            return forms;
        }
        public FormModel SaveUpdateForm(FormModel forms)
        {
            return _formsProvider.SaveUpdateForm(forms);
        }
        public FormModel GetFormsById(int id)
        {
            var data = _formsProvider.GetFormsById(id);
            FormModel form = new FormModel()
            {
                Id = data.Id,
                Name = data.Name,
                NavigateURL = data.NavigateURL,
                DisplayOrder = data.DisplayOrder,
                FormAccessCode = data.FormAccessCode,
                IsActive = data.IsActive,
                IsDisplayMenu = data.IsDisplayMenu,
                ParentFormId = data.ParentFormId,
                CreatedOn = DateTime.Now,
            };
            return form;
        }
        public FormModel GetFormsByCode(string formcode)
        {
            return _formsProvider.GetFormsByCode(formcode);
        }
        public List<FormMst> CheckDuplicateFormAccessCode(string formAccessCode)
        {
            return _formsProvider.CheckDuplicateFormAccessCode(formAccessCode);
        }
    }
}
