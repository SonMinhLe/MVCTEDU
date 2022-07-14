using Models.DAO;
using Models.EF;
using MVCTEDU.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTEDU.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index(string searchString, int Page = 1, int PageSize = 10)
        {
            var dao = new UserDAO();
            var model = dao.ListAllpaging(searchString, Page, PageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var EncryptedMd5Pas = Encryptor.GetMD5(user.Password);
                user.Password = EncryptedMd5Pas;
                long ID = dao.Insert(user);

                if (ID > 0)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng ký không thành công!");
                }
            }

            return View();
        }

        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int ID)
        {
            var user = new UserDAO().ViewDetail(ID);
            return View(user);
        }

        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5Pas = Encryptor.GetMD5(user.Password);
                    user.Password = encryptedMd5Pas;
                }


                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật dữ liệu thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật dữ liệu không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ChangeStatus(int ID)
        {
            var result = new UserDAO().ChangeStatus(ID);
            return Json(new
            {
                status = result
            });
        }
    }
}