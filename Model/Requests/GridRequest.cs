﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngSpa.Model.Requests
{
    public class GridRequest
    {
        public int displayLength { get; set; }

        public int displayStart { get; set; }

        public int sortCol { get; set; }

        public string sortDir { get; set; }

        public string search { get; set; }

        public int totalRecords { get; set; }

        public int totalDisplayRecords { get; set; }
    }
}
