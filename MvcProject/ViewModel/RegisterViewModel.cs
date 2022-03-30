using System.ComponentModel.DataAnnotations;

namespace MvcProject.ViewModel
{
    public class RegisterViewModel
    {
        [Key]
        public string id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]

        [Compare("Password", ErrorMessage = "Password not match ConfirmPassword")]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
