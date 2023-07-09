using System.ComponentModel.DataAnnotations;

namespace oil_exchange_backend.Models
{
    public class ResetPass
    {
        [Required]
        public string Token { get; set; } = string.Empty;

        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 charactor")]
        public string Pass { get; set; } = string.Empty;
        [Required, Compare("pass")]
        public string Confirmpass { get; set; } = string.Empty;
    }
}
