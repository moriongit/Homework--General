using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using Pustokdb context = new Pustokdb();
            var sliders = await context.Sliders.ToListAsync();
            return View(sliders);
        }
    }
}