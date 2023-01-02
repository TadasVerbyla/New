using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class BusinessDTO
    {
        public string name { get; set; }
        public string address { get; set; }
        public DateTime? opening { get; set; }
        public DateTime? closing { get; set; }
        public string websiteLink { get; set; }
        public string accountNumber { get; set; }

    }
}
