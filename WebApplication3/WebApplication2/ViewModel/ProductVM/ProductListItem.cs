using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.ViewModel.ProductVM
{
    public class ProductListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool? IsDeleted { get; set; }
        public string Description { get; set; }
        public string? About { get; set; }
        public decimal SellPrice { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal CostPrice { get; set; }
        [Range(0, 100)]
        public float Discount { get; set; }
        public int ProductCode { get; set; }
        public List<ProductImages> ProductImage { get; set; }
       
        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;



    }
}
