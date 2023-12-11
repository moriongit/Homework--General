namespace WebApplication2.ViewModel.ProductVM
{
    public class ProductListItem
    {
        public string? About { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool? IsDeleted { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ProductCode { get; set; }
        
        public int CategoryID { get; set; }
        

    }
}
