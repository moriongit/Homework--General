namespace WebApplication2.ViewModel.ProductVM
{
    public class ProductCreateVM
    {
       
        public string Title { get; set; }
        public bool? IsDeleted { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ProductCode { get; set; }

        public int CategoryID { get; set; }
    }
}
