using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IMS.DataAccess
{
    public class FormProvider :BaseProvider
    {
        public FormProvider()
        {

        }

        public int CreateForms(FormMst forms)
        {
            _db.FormMst.Add(forms);
            _db.SaveChanges();
            try
            {
                _db.FormMst.Add(forms);
                _db.SaveChanges();
                return forms.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateForms(FormMst forms)
        {
            try
            {
                _db.Entry(forms).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return forms.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FormMst GetFormsById(int id)
        {
            return _db.FormMst.Find(id);
        }

        public FormModel GetFormsByCode(string formcode)
        {
            var FormCode = _db.FormMst.Where(a => a.FormAccessCode == formcode).FirstOrDefault();
            FormModel formmodel = new FormModel()
            {
                Id = FormCode.Id,
                Name = FormCode.Name,
                NavigateURL = FormCode.NavigateURL,
                DisplayOrder = FormCode.DisplayOrder,
                FormAccessCode = FormCode.FormAccessCode,
                IsActive = FormCode.IsActive,
                IsDisplayMenu = FormCode.IsDisplayMenu,
                ParentFormId = FormCode.ParentFormId
            };
            return formmodel;
        }
        public FormModel SaveUpdateForm(FormModel model)
        {

            FormMst obj = new FormMst();
            if (model.Id > 0)
            {
                obj = GetFormsById(model.Id);
            }
            {
                obj.Name = model.Name;
                obj.NavigateURL = model.NavigateURL;
                obj.DisplayOrder = model.DisplayOrder;
                obj.IsActive = model.IsActive;
                obj.IsDisplayMenu = model.IsDisplayMenu;
                obj.ParentFormId = model.ParentFormId;
                obj.CreatedOn = DateTime.Now;
                obj.Id = model.Id;
                if (obj.Id == 0)
                {
                    obj.FormAccessCode = model.FormAccessCode.ToUpper();
                    obj.CreatedBy = SessionHelper.UserId;
                    obj.CreatedOn = DateTime.UtcNow;
                    model.Id = CreateForms(obj);
                }
                else
                {
                    obj.UpdatedBy = SessionHelper.UserId;
                    obj.UpdatedOn = DateTime.UtcNow;
                    UpdateForms(obj);
                }
                return model;
            }
        }

        public List<FormModel> GetAllForms()
        {
            var getallforms = (from f in _db.FormMst
                               select new
                               {
                                   Id = f.Id,
                                   Name = ((f.ParentFormId == null ? 0 : f.ParentFormId) == 0 ? f.Name : ((from fc in _db.FormMst where fc.Id == (f.ParentFormId == null ? 0 : f.ParentFormId) select fc).FirstOrDefault().Name) + " " + ">>" + " " + f.Name),
                                   NavigateURL = f.NavigateURL,
                                   DisplayOrder = f.DisplayOrder,
                                   FormAccessCode = f.FormAccessCode,
                                   IsActive = f.IsActive,
                                   IsDisplayMenu = f.IsDisplayMenu,
                                   ParentFormId = f.ParentFormId
                               }).AsEnumerable().Select(x => new FormModel()
                               {
                                   Id = x.Id,
                                   Name = x.Name,
                                   NavigateURL = x.NavigateURL,
                                   DisplayOrder = x.DisplayOrder,
                                   FormAccessCode = x.FormAccessCode,
                                   IsActive = x.IsActive,
                                   IsDisplayMenu = x.IsDisplayMenu,
                                   ParentFormId = x.ParentFormId
                               }).OrderByDescending(a => a.Id).ToList();

            return getallforms;
        }
        public List<FormMst> CheckDuplicateFormAccessCode(string formAccessCode)
        {
            var getForm = (from form in _db.FormMst
                           where form.FormAccessCode.ToUpper().Trim() == formAccessCode.ToUpper().Trim()
                           select form).ToList();
            return getForm;
        }

    }
}
