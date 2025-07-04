using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal class ShippingService : IShippingService
    {
        public ShippingService()
        {
        }

        public void Shipment(Cart cart)
        {
            double totalweight = 0;
            Console.WriteLine("** Shipment notice **");
            foreach (var product in cart.Products) {
                if (product.Shippale)
                {
                    totalweight += GetWeight(product.Weight, product.Quantity);
                    Console.WriteLine($"{product.Quantity}x {GetName(product.Name)}\t{GetWeight(product.Weight, product.Quantity)}g");
                }
            }
            Console.WriteLine($"Total package weight {totalweight / 1000}kg");

        }
        public string GetName(string name)
        {
            return Store.GetProductByName(name).Name;
        }
        public double GetWeight(double weight,int quantity)
        {
            return weight*quantity;
        }

    }
}
