namespace oil_exchange_backend.Models
{
    public class StoreManagement
    {
        public int Id { get; set; }
        public DateTime registereddate { get; set; } = DateTime.Now;
        public int userid { get; set; }

        public int engineoilbuyed { get; set; } = 0;
        public int engineoilselled { get; set; } = 0;

        public int gearboxoilbuyed { get; set; } = 0;
        public int gearboxoilselled { get; set; } = 0;

        public int cabinfilterbuyed { get; set; } = 0;
        public int cabinfilterselled { get; set; } = 0;

        public int oilfilterbuyed { get; set; } = 0;
        public int oilfilterselled { get; set; } = 0;

        public int airfilterbuyed { get; set; } = 0;
        public int airfilterselled { get; set; } = 0;

        public int petrolfilterbuyed { get; set; } = 0;
        public int petrolfilterselled { get; set; } = 0;

        public int breakeoilbuyed { get; set; } = 0;
        public int breakeoilselled { get; set; } = 0;

        public int untifreezbuyed { get; set; } = 0;
        public int untifreezselled { get; set; } = 0;
        
        public int hydraulicoilbuyed { get; set; } = 0;
        public int hydraulicoilselled { get; set; } = 0;
    }
}
