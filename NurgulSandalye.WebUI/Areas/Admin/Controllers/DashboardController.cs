﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurgulSandalye.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
