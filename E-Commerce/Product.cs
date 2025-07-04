using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool Expirable { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool Shippale { get; set; }
        public double Weight { get; set; }
    }
}
