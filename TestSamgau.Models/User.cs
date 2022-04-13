namespace TestSamgau.Models
{
    public class User : Entity
    {

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public double Rating { get; set; } = 0;
    }
}
