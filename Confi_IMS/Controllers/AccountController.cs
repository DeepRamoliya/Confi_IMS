using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;
using IMS.DataAccess;
using static IMS.Model.AccountModel;
using IMS.Model;
using System.Threading.Tasks;
using IMS.DataAccess.Database;

namespace Confi_IMS.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                Confi_IMSEntities _db = new Confi_IMSEntities();
                var check = _db.User.FirstOrDefault(s => s.EmailId == _user.EmailId);
                if (check == null)
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _user.IsActive = true ;
                    _user.IsDeleted = false;
                    _user.IsEmailVerified = true;
                    _user.CreatedOn = DateTime.Now;
                    _user.CreatedBy = 1;
                    _user.UpdatedBy = 1;
                    _db.User.Add(_user);
                    _db.SaveChanges();
                    
                    return RedirectToAction("Login");

                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }



        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login, string ReturnUrl = "")
        {
            string message = "";
            if (ModelState.IsValid)
            {
                using (Confi_IMSEntities dc = new Confi_IMSEntities())
                {
                    var v = dc.User.Where(a => a.EmailId == login.EmailId).FirstOrDefault();
                    if (v != null)
                    {
                        SessionHelper.EmailId = login.EmailId;
                        string returnUrl = Request.QueryString["ReturnUrl"];
                        if (!v.IsEmailVerified)
                        {
                            ViewBag.Message = "Please verify your email first";
                            return View();
                        }
                        var p = dc.User.Where(a => a.Password == login.Password).FirstOrDefault();
                        if (p != null)
                        {
                            int timeout = login.RememberMe ? 525600 : 60; // 525600 min = 1 year
                            var ticket = new FormsAuthenticationTicket(login.EmailId, login.RememberMe, timeout);
                            string encrypted = FormsAuthentication.Encrypt(ticket);
                            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                            cookie.Expires = DateTime.Now.AddMinutes(timeout);
                            cookie.HttpOnly = true;
                            Response.Cookies.Add(cookie);

                            if (returnUrl == null)
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                return Redirect(Url.Content(returnUrl));
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Password", " Email id or Password is invalid.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("EmailId", "EmailId is not registered.");
                    }

                    return View(login);
                }
            }
            else
            {
                return View(login);
            }
        }
       
        public ActionResult LogOff()
        {
            //  WebSecurity.Logout();
            Session.Abandon();
            FormsAuthentication.SignOut();
            TempData["Message"] = "You Successfully Logout!!";
            return RedirectToAction("Index", "Home");
        }

        [NonAction]
        public bool IsEmailExist(string emailId)
        {
            using (Confi_IMSEntities dc = new Confi_IMSEntities())
            {
                var v = dc.User.Where(a => a.EmailId == emailId).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Account/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("okaytemporary@gmail.com", "OIMS");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "okaytemporary@12345"; // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/>  <br/>We got request for reset your account password. Please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ForgotPassword(string EmailId)
        {

            string message = "";
            bool status = false;

            using (Confi_IMSEntities dc = new Confi_IMSEntities())
            {
                var account = dc.User.Where(a => a.EmailId == EmailId).FirstOrDefault();
                if (account != null)
                {
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.EmailId, resetCode, "ResetPassword");
                    account.ResetPasswordCode = resetCode;
                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                    //in our model class in part 1
                    dc.Configuration.ValidateOnSaveEnabled = false;
                    dc.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);

                }
            }
        }



        public ActionResult ResetPassword(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }

            using (Confi_IMSEntities dc = new Confi_IMSEntities())
            {
                var user = dc.User.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (Confi_IMSEntities dc = new Confi_IMSEntities())
                {
                    var user = dc.User.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (user != null)
                    {
                        user.Password = Crypto.Hash(model.NewPassword);
                        user.ResetPasswordCode = "";
                        dc.Configuration.ValidateOnSaveEnabled = false;
                        dc.SaveChanges();
                        // message = "New password updated successfully";
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        //message = "Something invalid";
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return View(model);
        }




        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (Confi_IMSEntities dc = new Confi_IMSEntities())
                {
                    var oldpass = Crypto.Hash(model.OldPassword);
                    var userpass = dc.User.Where(a => a.Password != model.NewPassword && a.Password == oldpass).FirstOrDefault();
                    if (userpass != null)
                    {
                        userpass.Password = Crypto.Hash(model.NewPassword);
                        dc.Configuration.ValidateOnSaveEnabled = false;
                        dc.SaveChanges();
                        //message = "New password updated successfully";
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        //message = "Something invalid";
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                //ViewBag.Message = message;
            }
            return View("model");
        }

    }
}