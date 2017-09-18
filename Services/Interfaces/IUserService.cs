using ngSpa.Model;
using System.Collections.Generic;

namespace ngSpa.Services.Interfaces
{
    public interface IUserService
    {
        List<Users> SelectAll();
    }
}
