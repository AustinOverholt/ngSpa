using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngSpa.Services
{
   public class BaseService
    {
        protected string connString = System.Configuration.ConfigurationManager.ConnectionStrings["Defaultconnection"].ConnectionString;
    }
}
