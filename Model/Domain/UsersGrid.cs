using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngSpa.Model.Domain
{
    public class UsersGrid
    {
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<Users> data { get; set; }
    }
}
