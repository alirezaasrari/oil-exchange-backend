namespace oil_exchange_backend.Models.ViewModels
{
    public class UserVM
    {
        public DateTime? Registereddate { get; set; } = DateTime.Now;
        public string Phonenumber { get; set; } = string.Empty;
        public string Storename { get; set; } = string.Empty;
        public byte[] PassHash { get; set; } = new byte[32];
        public byte[] PassSalt { get; set; } = new byte[32];    
    }
}
