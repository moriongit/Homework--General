using AdminPanel.Helper;
using AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var dt = await SqlHelper.GetDatas("SELECT * FROM Worker");
            return View(dt);
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}