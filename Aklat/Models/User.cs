using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Aklat.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "User Name Cant Be Empity ")]
        [StringLength(maximumLength: 15, MinimumLength = 2, ErrorMessage = "User Name Must Be More Than 3 Less Than 15 Letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "User Adress Cant Be Empity ")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "User Adress Must Be More Than 3 Less Than 50 Letters")]
        public string Adress {  get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
