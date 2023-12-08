using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        Pustokdb _Pustokdb;
        public HomeController(Pustokdb Pustokdb)
        {
            _Pustokdb = Pustokdb;
        }

       
        
        public async Task<IActionResult> Index()
        {
            
            var sliders = await _Pustokdb.Sliders.ToListAsync();
            return View(sliders);
        }
    }
}