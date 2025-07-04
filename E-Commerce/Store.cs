using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal class Store
    {
        static List<Product> products = new List<Product>();
        
        public static void ShowProducts() {
            
            foreach (var product in products) { 
                Console.WriteLine($"-{product.Name}."); 
            }
        }
        public static void AddProduct(Product product) { products.Add(product); }
        public static Product GetProductByName(string name)
        {
            return products.FirstOrDefault(x => x.Name.ToLower() == name.ToLower())!;
        }
        public static void reduceQuantity(Product product,int quantity)
        {
            product.Quantity -= quantity;
            if(product.Quantity <= 0)
            {
                products.Remove(product);
            }
        }
    }
}
