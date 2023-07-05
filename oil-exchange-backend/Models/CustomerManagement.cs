namespace oil_exchange_backend.Models
{
    public class CustomerManagement
    {
        public int id { get; set; }
        public string plaque { get; set; } = string.Empty;
        public DateTime servicedate { get; set; } = DateTime.Now;
        public string engineoil { get; set; } = string.Empty;
        public string gearboxoil { get; set; } = string.Empty;
        public string cabinfilter { get; set; } = string.Empty;
        public string oilfilter { get; set; } = string.Empty;
        public string airfilter { get; set; } = string.Empty;
        public string petrolfilter { get; set; } = string.Empty;
        public string breakeoil { get; set; } = string.Empty;
        public string untifreez { get; set; } = string.Empty;
        public string previouskilometer { get; set; } = string.Empty;
        public string nextkilometer { get; set; } = string.Empty;
        public int userid { get; set; }
        public string? hydraulicoil { get; set; } = string.Empty;

    }
}
