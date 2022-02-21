using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPINorthwind_1.DTOClasses
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCount { get; set; }


    }
}