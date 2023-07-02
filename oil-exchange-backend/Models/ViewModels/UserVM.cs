namespace oil_exchange_backend.Models.ViewModels
{
    public class UserVM
    {
        public DateTime? registereddate { get; set; } = DateTime.Now;
        public string phonenumber { get; set; } = string.Empty;
        public string storename { get; set; } = string.Empty;
        public byte[] passHash { get; set; } = new byte[32];
        public byte[] passSalt { get; set; } = new byte[32];    
    }
}
