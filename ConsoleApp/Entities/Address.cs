namespace ConsoleApp.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        // Foreign key
        public int PersonId { get; set; }

        // Navigation property
        public Person Person { get; set; }
    }



}
