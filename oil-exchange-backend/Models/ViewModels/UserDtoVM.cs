using System.ComponentModel.DataAnnotations;

namespace oil_exchange_backend.Models.ViewModels
{
    public class UserDtoVM
    {
        public DateTime? registereddate { get; set; } = DateTime.Now;
        [Required]
        public string phonenumber { get; set; } = string.Empty;
        public string storename { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 charactor")]
        public string pass { get; set; } = string.Empty;
        [Required, Compare("pass")]
        public string confirmpass { get; set; } = string.Empty;
    }
}
