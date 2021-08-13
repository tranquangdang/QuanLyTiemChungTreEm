﻿using Models.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.Admin.Controllers
{
    public class VaccineController : BaseController
    {
        // GET: Admin/Vaccine
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var model = new VaccineDAO().ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
    }
}