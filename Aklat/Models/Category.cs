using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aklat.Models
{
    public class Category
    {
        public int ID { get; set; }

        //[UniqueCategoryName(context:]
        [Required(ErrorMessage = "Category Name Cant Be Empity ")]
        [StringLength(maximumLength:50 , MinimumLength =3 ,ErrorMessage = "Category Name Must Be More Than 3 Less Than 50 Letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category Type Cant Be Empity  ")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Category Type Must Be More Than 3 Less Than 50 Letters")]
        public string Type { get; set; }
        
        public bool IsDeleted { get; set; } = false;
    }
}
