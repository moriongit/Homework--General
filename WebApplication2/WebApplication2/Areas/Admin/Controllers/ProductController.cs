using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.ViewModel.ProductVM;


namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (Pustokdb context = new Pustokdb())
            {

                var items = await context.Products.Select(s => new ProductListItem
                {
                    Title = s.Title,
                    Description = s.Description,
                    Price = s.Price,
                    ProductCode = s.ProductCode,
                    IsDeleted = s.IsDeleted,
                    CategoryID = s.CategoryID,
                    Id = s.Id


                }).ToListAsync();
                return View(items);
            }

        }

        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]

        public async Task<IActionResult> Create(ProductCreateVM vm)
        {


            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            using Pustokdb db = new Pustokdb();
            Product product = new Product
            {
                Title = vm.Title,
                Description = vm.Description,
                Price = vm.Price,
                ProductCode = vm.ProductCode,
                IsDeleted = vm.IsDeleted,
                CategoryID = vm.CategoryID,
                


            };
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null) return BadRequest();
            using Pustokdb pd = new();
            var data = await pd.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            pd.Sliders.Remove(data);
            await pd.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }




    }



}

