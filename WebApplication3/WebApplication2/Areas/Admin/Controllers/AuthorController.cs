using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.ViewModel.AuthorVM;
using WebApplication2.ViewModel.CategoryVM;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        Pustokdb _Pustokdb { get; }
        public AuthorController(Pustokdb Pustokdb)
        {
            _Pustokdb = Pustokdb;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _Pustokdb.Authors.Select(c => new AuthorListItemVM
            {
                Id = c.Id,
                Name = c.Name,
                Surname = c.Surname

            }).ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(AuthorCreateItemVM item)
        {
            Author author = new Author
            {
                Name = item.Name,
                Surname = item.Surname
            };
            await _Pustokdb.Authors.AddAsync(author);
            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _Pustokdb.Authors.FindAsync(id);
            _Pustokdb.Authors.Remove(data);
            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id <= 0) return BadRequest();

            var data = await _Pustokdb.Authors.FindAsync(id);
            if (data == null) return NotFound();
            return View(new AuthorUpdateVM
            {
                Name = data.Name,
                Surname = data.Surname,


            });


        }
        [HttpPost]

        public async Task<IActionResult> Update(AuthorUpdateVM vm, int id)
        {
            var data = await _Pustokdb.Authors.FindAsync(id);
            data.Name = vm.Name;
            data.Surname = vm.Surname;


            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
