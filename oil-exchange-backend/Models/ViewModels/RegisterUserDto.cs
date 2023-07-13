using System.ComponentModel.DataAnnotations;

namespace oil_exchange_backend.Models.ViewModels
{
    public class RegisterUserDto
    {
        public int Phonenumber { get; set; } = 0;
        public string Storename { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
    }
}
