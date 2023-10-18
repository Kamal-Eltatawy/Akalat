using System.ComponentModel.DataAnnotations;

namespace Aklat.ViewModel
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }//extra info
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
    }
}
