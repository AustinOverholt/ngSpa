using System.ComponentModel.DataAnnotations;

namespace ngSpa.Model.Requests
{
    public class UserUpdateRequest : UserAddRequest
    {
        public int Id { get; set; }
    }
}
