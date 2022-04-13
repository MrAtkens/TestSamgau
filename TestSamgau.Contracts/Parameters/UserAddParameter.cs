using System.ComponentModel.DataAnnotations;

namespace TestSamgau.Contracts.Parameters
{
    public class UserAddParameter
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
      
    }
}
