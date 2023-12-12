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
                    About = s.About,
                    SellPrice = s.SellPrice,
                    CostPrice = s.CostPrice,
                    Discount = s.Discount,
                    Category = s.Category,
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
                About = vm.About,
                SellPrice = vm.SellPrice,
                CostPrice = vm.CostPrice,
                Discount = vm.Discount,
                Category = vm.Category,
                ProductCode = vm.ProductCode,
                IsDeleted = vm.IsDeleted,
                CategoryID = vm.CategoryID,
                


            };
            await _Pustokdb.Products.AddAsync(product);
            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction("Index");


        }
       
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id <= 0) return BadRequest();

            var data = await _Pustokdb.Products.FindAsync(id);
            if (data == null) return NotFound();
            return View(new ProductUpdateVM { 
                Title = data.Title,
                Description = data.Description,
                IsDeleted = data.IsDeleted,
                About = data.About, 
                SellPrice = data.SellPrice,
                CostPrice = data.CostPrice,
                Discount = data.Discount,
                ProductCode = data.ProductCode,
                CategoryID = data.CategoryID,
                Category = data.Category,
            
            });


        }
        [HttpPost]

        public async Task<IActionResult> Update(ProductUpdateVM vm, int id)
        {
            var data = await _Pustokdb.Products.FindAsync(id);
            data.Title = vm.Title;
            data.Description = vm.Description;
            data.IsDeleted = vm.IsDeleted;
            data.About = vm.About;
            data.SellPrice = vm.SellPrice;
            data.CostPrice = vm.CostPrice;
            data.Discount = vm.Discount;
            data.ProductCode = vm.ProductCode;
            data.CategoryID = vm.CategoryID; 
            data.Category = vm.Category;
            

            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null) return BadRequest();

            var data = await _Pustokdb.Products.FindAsync(id);
            if (data == null) return NotFound();
            _Pustokdb.Products.Remove(data);
            await _Pustokdb.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

    }



}

