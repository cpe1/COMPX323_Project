using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPX323_Project
{
    public class Category
    {


        public Category(String name, String description)
        {
            this.name = name;
            this.description = description;
        }

        public String name { get; set; }
        public String description { get; set; }
    }
}
