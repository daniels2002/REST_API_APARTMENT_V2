﻿namespace REST_API_APARTMENT.Models
{
    public class Appartment
    {
        public int Id { get; set; }

        public int Number { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }

        public int Residents { get; set; }
        public double LivingSpace { get; set; }

        public double TotalSpace { get; set; }
        public int HouseId { get; set; }

        // public House House { get; set; } = null!;

        // public List<Resident>? Resident { get; set; } = null!;
    }
}