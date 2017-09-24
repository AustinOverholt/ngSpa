using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngSpa.Model.Domain
{
    public class Scrape
    {
        public string html { get; set; }
        public string descendant { get; set; }
        public string attribute { get; set; }
    }
}
