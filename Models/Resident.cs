namespace REST_API_APARTMENT.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Person_code { get; set; }
        public DateTime Birth_time { get; set; }

        public int Telephone { get; set; }
        public string Email { get; set; }

        public int AppartmentId { get; set; }
        public Appartment Appartment { get; set; }
    }
}
