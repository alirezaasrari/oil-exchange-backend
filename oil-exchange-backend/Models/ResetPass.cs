using System.ComponentModel.DataAnnotations;

namespace oil_exchange_backend.Models
{
    public class ResetPass
    {
        [Required]
        public string token { get; set; } = string.Empty;

        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 charactor")]
        public string pass { get; set; } = string.Empty;
        [Required, Compare("pass")]
        public string confirmpass { get; set; } = string.Empty;
    }
}
