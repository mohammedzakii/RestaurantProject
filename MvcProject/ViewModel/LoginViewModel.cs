using System.ComponentModel.DataAnnotations;

namespace MvcProject.ViewModel
{
    public class LoginViewModel
    {
        [Key]
      public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool Remember_Me { get; set; }

    }
}
