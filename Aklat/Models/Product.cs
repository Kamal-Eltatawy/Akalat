using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aklat.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name Cant Be Empity ")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Product Name Must Be More Than 2 Less Than 50 Letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Product Description Cant Be Empity  ")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Product Description Must Be More Than 2 Less Than 50 Letters")]
        public string Description { get; set; }
        
        public string? Photo { get; set; }

        [NotMapped]

        public IFormFile File { get; set; }

        public int Stock {  get; set; }

        public bool IsDeleted { get; set; } = false;

        [Required]
        [Column(TypeName ="Money")]
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId {  get; set; }
        public Category? Category { get; set; }
        List<OrderProduct>? OrderProducts { get; set; }

    }
}
