using System.ComponentModel.DataAnnotations;

namespace TestSamgau.Contracts.Parameters
{
    public class UserEditParameter
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
