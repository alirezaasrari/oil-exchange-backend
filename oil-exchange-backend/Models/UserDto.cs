﻿namespace oil_exchange_backend.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public DateTime? registereddate { get; set; } = DateTime.Now;
        public string phonenumber { get; set; } = string.Empty;
        public string storename { get; set; } = string.Empty;
        public string pass { get; set; } = string.Empty;
    }
}
