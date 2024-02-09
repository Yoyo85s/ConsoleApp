namespace ConsoleApp.Models
{
    public class FamilyStatus
    {
        public int FamilyStatusId { get; set; }
        public bool MaritalStatus { get; set; }
        public bool HasChildren { get; set; }

        // Foreign key
        public int PersonId { get; set; }

        // Navigation property
        public Person Person { get; set; }
    }


}
