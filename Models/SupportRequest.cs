using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class SupportRequest
    {
        public Guid id { get; set; }
        public Guid employeeId { get; set; }
        public Guid businessId { get; set; }
        public Guid orderId { get; set; }
        public Guid customerId { get; set; }
        public string issue { get; set; }
        public SupportStatus status { get; set; }
        public SupportType type { get; set; }
        public DateTime requestedOn { get; set; }
        public DateTime solvedOn { get; set; }
        
    }
}
