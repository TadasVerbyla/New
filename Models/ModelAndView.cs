using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class ModelAndView
    {
        public bool empty { get; set; }
        public object model { get; set; } 
        //What is ModelMap, why does it have additionalProperties?
        public ModelMap modelMap { get; set; }
        public bool reference { get; set; }
        public ResponseStatus status { get; set; }
        public View view { get; set; }
        public string viewName { get; set; }

    }
}
public class ModelMap
{
    public object additionalProperties { get; set; }
}
