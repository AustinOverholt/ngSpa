using System.ComponentModel.DataAnnotations;

namespace ngSpa.Model.Requests
{
    public class UserUpdateRequest : UserAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
