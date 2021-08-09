﻿using Models.DAO;
using QuanLyTiemChung.Areas.Admin.Models;
using QuanLyTiemChung.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                var result = dao.login(user.Username, Encryptor.EncryptMD5(user.Password));
                if (result == "")
                {
                    Session.Add(Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result);
                }
            }
            return View("Index");
        }
    }
}