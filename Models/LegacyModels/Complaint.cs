﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models.LegacyModels
{
    public class Complaint
    {
        public Guid id { get; set; }
        public Guid orderId { get; set; }
        public string text { get; set; }

    }
}
