using System.ComponentModel.DataAnnotations;

namespace ngSpa.Model.Requests
{
    public class UserAddRequest
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ModifiedBy { get; set; }

        public string PhoneNumber { get; set; }
    }
}
