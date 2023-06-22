namespace REST_API_APARTMENT.Models
{
    public class House
    {
        //primary key cannot be changed
        public int Id { get; set; }

        public string? Street { get; set; } = null;

        public string? City { get; set; } = null;

        public string? State { get; set; } = null;

        public int Postcode { get; set; }
    }
}