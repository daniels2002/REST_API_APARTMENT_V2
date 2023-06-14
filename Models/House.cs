namespace REST_API_APARTMENT.Models
{
    public class House
    {
        public int Id { get; set; } //primary key cannot be changed

        public string Street { get; set; } = null;

        public string City { get; set; } = null;

        public string State { get; set; }=null;

        public int Postcode { get; set; }
    }
}
