namespace ConsoleApp.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public Address Address { get; set; }
        public FamilyStatus FamilyStatus { get; set; }
        public Employment Employment { get; set; }
        public Contact Contact { get; set; }
    }



}
