namespace ConsoleApp.Models
{
    public class Employment
    {
        public int EmploymentId { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public DateTime EmploymentDate { get; set; }

        // Foreign key
        public int PersonId { get; set; }

        // Navigation property
        public Person Person { get; set; }
    }

}
