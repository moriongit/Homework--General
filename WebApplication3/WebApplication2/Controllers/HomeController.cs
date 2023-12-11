using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.ViewModel.HomeVM;
using WebApplication2.ViewModel.ProductVM;
using WebApplication2.ViewModel.SliderVM;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        Pustokdb _Pustokdb;
        public HomeController(Pustokdb Pustokdb)
        {
            _Pustokdb = Pustokdb;
        }



        /* public async Task<IActionResult> Index()
         {

             var sliders = await _Pustokdb.Sliders.ToListAsync();
             return View(sliders);
         }*/

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM
            {
                Sliders = await _Pustokdb.Sliders.Select(s => new SliderListItem
                {
                    Id = s.Id,
                    ImageUrl = s.ImageUrl,
                    IsLeft = s.IsLeft,
                    Title = s.Title,
                    Text = s.Text,
                }).ToListAsync(),
                Products = await _Pustokdb.Products.Where(p => (bool)!p.IsDeleted).Select(p => new ProductListItem
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    IsDeleted = p.IsDeleted,
                    About = p.About,
                    CategoryID = p.CategoryID,
                    ProductCode = p.ProductCode,



                }).ToListAsync()
            };
            return View(vm);
        }
    }
}