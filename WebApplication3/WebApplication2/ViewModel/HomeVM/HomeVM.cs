using Microsoft.AspNetCore.Mvc;
using WebApplication2.ViewModel.ProductVM;
using WebApplication2.ViewModel.SliderVM;

namespace WebApplication2.ViewModel.HomeVM
{

    public class HomeVM
    {
        public IEnumerable<SliderListItem> Sliders { get; set; }
        public IEnumerable<ProductListItem> Products { get; set; }
    }
}
    

