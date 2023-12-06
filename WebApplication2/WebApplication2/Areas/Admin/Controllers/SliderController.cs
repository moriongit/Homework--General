using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.ViewModel.SliderVM;
using WebApplication2.Context;
using WebApplication2.Models;



namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {

        public async Task<IActionResult> Index()
        {
            using (Pustokdb context = new Pustokdb())
            {

                var items = await context.Sliders.Select(s => new SliderListItem
                {
                    Title = s.Title,
                    Text = s.Text,
                    ImageUrl = s.ImageUrl,
                    IsLeft = s.IsLeft,
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

        public async Task<IActionResult> Create(SliderCreateVM vm)
        {
            

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            using Pustokdb db = new Pustokdb();
            Slider slider = new Slider
            {
                Title = vm.Title,
                Text = vm.Text,
                ImageUrl = vm.ImageUrl,
                IsLeft = vm.IsLeft


            };
            await db.Sliders.AddAsync(slider);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null) return BadRequest();
            using   Pustokdb pd = new();
            var data = await pd.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            pd.Sliders.Remove(data);
            await pd.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));

        }

        
        
        
    }

    

       






       

    }


