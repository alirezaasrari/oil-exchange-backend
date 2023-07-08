namespace oil_exchange_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public DateTime? Registereddate { get; set; } = DateTime.Now;
        public string Phonenumber { get; set; } = string.Empty;
        public string Storename { get; set; } = string.Empty;
        public byte[] PassHash { get; set; } = new byte[32];
        public byte[] PassSalt { get; set; } = new byte[32];
        public string? Token { get; set; } = string.Empty;
        public string? Passwordresettoken { get; set; } = string.Empty;

    }
}
