﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models.LegacyModels
{
    public class Review
    {
        public string comment { get; set; }
        public Guid id { get; set; }
        public int score { get; set; }
    }
}
