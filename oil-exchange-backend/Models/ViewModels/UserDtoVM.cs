using System.ComponentModel.DataAnnotations;

namespace oil_exchange_backend.Models.ViewModels
{
    public class UserDtoVM
    {
        public DateTime? Registereddate { get; set; } = DateTime.Now;
        [Required]
        public string Phonenumber { get; set; } = string.Empty;
        [Required]
        public string Storename { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 charactor")]
        public string Pass { get; set; } = string.Empty;
        [Required, Compare("Pass")]
        public string Confirmpass { get; set; } = string.Empty;
    }
}
