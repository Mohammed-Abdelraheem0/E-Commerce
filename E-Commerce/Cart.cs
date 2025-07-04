using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal class Cart
    {
        public List<Product> Products=new List<Product>();
        private bool shippable = false;
        public bool Shippable { get { return shippable; } }
        public void Add(string name,int quantity)
        {
            name = name.ToLower();
            Product product = Store.GetProductByName(name);
            if (product == null) {
                return;
            }

            if (product.Quantity < quantity)
            {
                Console.WriteLine($"Only {product.Quantity} available.\nWant to order them all?\nEnter 1 to Yes or 2 to Cancel the product.");
                int type;
                while (!int.TryParse(Console.ReadLine(), out type) || type > 2 || type < 1)
                {
                    Console.WriteLine("Invalid Input.");

                }
                if (type == 2) {
                    
                    return;
                }
                quantity=product.Quantity;
            }
            if (product.Shippale)
            {
                shippable = true;
            }
            if (product.ExpireDate < DateTime.Now)
            {
                Console.WriteLine("Product is expired\n");
                return;
            }
            Product product1 = Products.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            if (product1 == null) {
            product1= new Product()
            {
                Name = product.Name,
                Quantity = quantity,
                Price = product.Price,
                Expirable = product.Expirable,
                Shippale = product.Shippale,
                ExpireDate = product.ExpireDate,
                Weight = product.Weight
            };
                Products.Add(product1);
            }
            else
            {
                product1.Quantity += quantity;
            }
            Store.reduceQuantity(product, quantity);

        }
        public bool Empty()
        {
            return Products.Count == 0;
        }
    }
}
