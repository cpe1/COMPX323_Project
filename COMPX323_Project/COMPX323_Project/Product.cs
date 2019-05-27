using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace COMPX323_Project
{
    public class Product
    {
        public Product(decimal serial_number, String name, decimal price, String weight_unit, decimal stock, decimal discount)
        {
            this.serial_number = serial_number;
            this.name = name;
            this.price = price;
            this.weight_unit = weight_unit;
            this.stock = stock;
            this.discount = discount;
        }

        public decimal serial_number { get; set; }
        public String name { get; set; }
        public decimal price { get; set; }
        public String weight_unit { get; set; }
        public decimal stock { get; set; }
        public decimal discount { get; set; }

        public override string ToString()
        {
            return name.PadRight(60 - name.Length) + "\t\t" +
            price.ToString().PadRight(10 - price.ToString().Length) + "\t\t" +
            weight_unit.ToString().PadRight(10 - weight_unit.Length) + "\t\t" +
            ((int)stock).ToString().PadRight(10 - ((int)stock).ToString().Length) + "\t\t" +
            ((int)(discount * 100)).ToString().PadRight(10 - ((int)(discount*100)).ToString().Length);

        }
    }
}
