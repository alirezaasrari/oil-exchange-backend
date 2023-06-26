namespace oil_exchange_backend.Models.ViewModels
{
    public class UsersVM
    {
        public DateTime? registereddate { get; set; }
        public string phonenumber { get; set; } = string.Empty;
        public string storename { get; set; } = string.Empty;   
        public int pass { get; set; }
    }
}
