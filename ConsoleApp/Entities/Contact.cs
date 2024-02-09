namespace ConsoleApp.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string MobileNumber1 { get; set; }
        public string? MobileNumber2 { get; set; }
        public string Email1 { get; set; }
        public string? Email2 { get; set; }

        // Foreign key
        public int PersonId { get; set; }

        // Navigation property
        public Person Person { get; set; }
    }



}
