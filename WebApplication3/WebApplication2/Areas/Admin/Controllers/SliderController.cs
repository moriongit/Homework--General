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
        Pustokdb _Pustokdb;

        public SliderController(Pustokdb Pustokdb)
        {
            _Pustokdb = Pustokdb;
        }

        public async Task<IActionResult> Index()
        {

            var items = await _Pustokdb.Sliders.Select(s => new SliderListItem
            {
                Title = s.Title,
                Text = s.Text,
                ImageUrl = s.ImageUrl,
                IsLeft = s.IsLeft,
                Id = s.Id
            }).ToListAsync();
            return View(items);


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

            Slider slider = new Slider
            {
                Title = vm.Title,
                Text = vm.Text,
                ImageUrl = vm.ImageUrl,
                IsLeft = vm.IsLeft


            };
            await _Pustokdb.Sliders.AddAsync(slider);
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
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id <=0) return BadRequest();

            var data = await _Pustokdb.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            return View(new SliderListItem { ImageUrl = data.ImageUrl, Text=data.Text, Title=data.Title });


        }

        public async Task<IActionResult> Update(SliderUpdateVM vm, int id)
        {
            var data = await _Pustokdb.Sliders.FindAsync(id);
            data.Title = vm.Title;
            data.IsLeft = vm.IsLeft;
            data.ImageUrl = vm.ImageUrl;
            data.Text = vm.Text;
            await _Pustokdb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }












    }
}


