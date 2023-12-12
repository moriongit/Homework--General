﻿using Microsoft.AspNetCore.Mvc;
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
                    AuthorID = s.AuthorID,

                    Author = s.Author,

                    IsDeleted = s.IsDeleted,

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

        public async Task<IActionResult> Create(BlogCreateItemVM vm)
        {


            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            Blog blog = new Blog
            {
                Name = vm.Name,
                Description = vm.Description,
                CreatedAt = vm.CreatedAt,
                LastUpdatedAt = vm.LastUpdatedAt,
                AuthorID = vm.AuthorID,
                Author = vm.Author,
                IsDeleted = vm.IsDeleted,




            };
            await _Pustokdb.Blogs.AddAsync(blog);
            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id <= 0) return BadRequest();

            var data = await _Pustokdb.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            return View(new BlogUpdateVM
            {
                Name = data.Name,
                Description = data.Description,
                CreatedAt = data.CreatedAt,
                LastUpdatedAt = data.LastUpdatedAt,
                AuthorID = data.AuthorID,
                Author = data.Author,
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
            data.CreatedAt = vm.CreatedAt;
            data.LastUpdatedAt = vm.LastUpdatedAt;
            data.AuthorID = vm.AuthorID;
            data.Author = vm.Author;


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