﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
