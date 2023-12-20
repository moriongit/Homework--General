using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.ViewModel.TagVM;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TagController : Controller
    {
        
        Pustokdb _PustokDb { get; }

        public TagController(Pustokdb Pustokdb)
        {
            _PustokDb = Pustokdb;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _PustokDb.Tags.Select(t => new TagListItemVM
            {
                Id = t.Id,
                Name = t.Name,
            }).ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(TagCreateItemVM item)
        {
            Tag tag = new Tag
            {
                Name = item.Name,
            };
            await _PustokDb.Tags.AddAsync(tag);
            await _PustokDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
