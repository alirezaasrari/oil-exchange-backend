namespace oil_exchange_backend.Models
{
    public class users
    {
        public int id { get; set; }
        public DateTime? registereddate { get; set; } = DateTime.Now;
        public string phonenumber { get; set; } = string.Empty;
        public string storename { get; set; } = string.Empty;   
        public int pass { get; set; }
    }
}
