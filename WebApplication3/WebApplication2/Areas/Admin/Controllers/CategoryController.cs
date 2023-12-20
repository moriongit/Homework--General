using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.ViewModel.CategoryVM;
using WebApplication2.ViewModel.ProductVM;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        Pustokdb _Pustokdb { get; }
        public CategoryController(Pustokdb Pustokdb)
        {
            _Pustokdb = Pustokdb;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _Pustokdb.Categories.Select(c => new CategoryListItemVM
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(CateogoryCreateItemVM item)
        {


            
            Category category = new Category
            {
                Name = item.Name,
            };
            await _Pustokdb.Categories.AddAsync(category);
            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _Pustokdb.Categories.FindAsync(id);
            _Pustokdb.Categories.Remove(data);
            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id <= 0) return BadRequest();

            var data = await _Pustokdb.Categories.FindAsync(id);
            if (data == null) return NotFound();
            return View(new CategoryUpdateVM
            {
                    Name = data.Name,
               

            });


        }
        [HttpPost]

        public async Task<IActionResult> Update(CategoryUpdateVM vm, int id)
        {
            var data = await _Pustokdb.Categories.FindAsync(id);
            data.Name= vm.Name;


            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
