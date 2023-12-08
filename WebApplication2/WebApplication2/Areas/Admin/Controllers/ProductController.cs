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
        Pustokdb _Pustokdb;

        public ProductController(Pustokdb Pustokdb)
        {
            _Pustokdb = Pustokdb;
        }

        public async Task<IActionResult> Index()
        {
            
            {

                var items = await _Pustokdb.Products.Select(s => new ProductListItem
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

            
            Product product = new Product
            {
                Title = vm.Title,
                Description = vm.Description,
                Price = vm.Price,
                ProductCode = vm.ProductCode,
                IsDeleted = vm.IsDeleted,
                CategoryID = vm.CategoryID,
                


            };
            await _Pustokdb.Products.AddAsync(product);
            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null) return BadRequest();
            
            var data = await _Pustokdb.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            _Pustokdb.Sliders.Remove(data);
            await _Pustokdb.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }




    }



}

