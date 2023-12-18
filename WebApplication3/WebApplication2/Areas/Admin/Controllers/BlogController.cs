using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.ViewModel.BlogVM;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        Pustokdb _Pustokdb;

        public BlogController(Pustokdb Pustokdb)
        {
            _Pustokdb = Pustokdb;
        }

        public async Task<IActionResult> Index()
        {

            {

                var items = await _Pustokdb.Blogs.Select(s => new BlogListItemVM
                {
                    Name = s.Name,
                    Description = s.Description,
                    CreatedAt = s.CreatedAt,
                    LastUpdatedAt = s.LastUpdatedAt,
                    

                    Author = s.Author,
                    Tags = s.BlogTags.Select(bt => bt.Tag).ToList(),
                    IsDeleted = s.IsDeleted,

                    Id = s.Id


                }).ToListAsync();
                return View(items);
            }

        }

        public IActionResult Create()
        {
            ViewBag.Authors = _Pustokdb.Authors;
            ViewBag.Tags = _Pustokdb.Tags;
            
            return View();

        }

        [HttpPost]

        public async Task<IActionResult> Create(BlogCreateItemVM vm)
        {


            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            if (!await _Pustokdb.Authors.AnyAsync(c => c.Id == vm.AuthorID))
            {
                ModelState.AddModelError("AuthorID", "Author doesnt exist");
                ViewBag.Authors = _Pustokdb.Authors;
                ViewBag.Colors = new SelectList(_Pustokdb.Authors, "Id", "Name","Surname");

                return View(vm);
            }

            Blog blog = new Blog
            {
                Name = vm.Name,
                Description = vm.Description,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
                AuthorID = vm.AuthorID,
                
                IsDeleted = vm.IsDeleted,
                
                BlogTags = vm.TagId.Select(id => new BlogTag
                {
                    TagId = id,
                }).ToList(),



            };
            await _Pustokdb.Blogs.AddAsync(blog);
            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id <= 0) return BadRequest();
            ViewBag.Authors = _Pustokdb.Authors;

            var data = await _Pustokdb.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            return View(new BlogUpdateVM
            {
                Name = data.Name,
                Description = data.Description,
               
                Author = data.Author,
                AuthorID = data.AuthorID,
                IsDeleted = data.IsDeleted,


            });


        }
        [HttpPost]

        public async Task<IActionResult> Update(BlogUpdateVM vm, int id)
        {
            var data = await _Pustokdb.Blogs.FindAsync(id);
            data.Name = vm.Name;
            data.Description = vm.Description;
            data.IsDeleted = vm.IsDeleted;
            data.LastUpdatedAt = DateTime.Now;
            data.AuthorID = vm.AuthorID;
            data.Author = vm.Author;
            data.BlogTags = vm.TagId.Select(id => new BlogTag
            {
                TagId = id,
            }).ToList();


            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null) return BadRequest();

            var data = await _Pustokdb.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            _Pustokdb.Blogs.Remove(data);
            await _Pustokdb.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
