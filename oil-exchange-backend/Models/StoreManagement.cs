namespace oil_exchange_backend.Models
{
    public class StoreManagement
    {
        public int Id { get; set; }
        public DateTime Registereddate { get; set; } = DateTime.Now;
        public int Userid { get; set; }

        public int Engineoilbuyed { get; set; } = 0;
        public int Engineoilselled { get; set; } = 0;

        public int Gearboxoilbuyed { get; set; } = 0;
        public int Gearboxoilselled { get; set; } = 0;

        public int Cabinfilterbuyed { get; set; } = 0;
        public int Cabinfilterselled { get; set; } = 0;

        public int Oilfilterbuyed { get; set; } = 0;
        public int Oilfilterselled { get; set; } = 0;

        public int Airfilterbuyed { get; set; } = 0;
        public int Airfilterselled { get; set; } = 0;

        public int Petrolfilterbuyed { get; set; } = 0;
        public int Petrolfilterselled { get; set; } = 0;

        public int Breakeoilbuyed { get; set; } = 0;
        public int Breakeoilselled { get; set; } = 0;

        public int Untifreezbuyed { get; set; } = 0;
        public int Untifreezselled { get; set; } = 0;
        
        public int Hydraulicoilbuyed { get; set; } = 0;
        public int Hydraulicoilselled { get; set; } = 0;
    }
}
