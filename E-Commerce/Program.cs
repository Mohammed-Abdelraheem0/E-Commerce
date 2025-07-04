namespace E_Commerce
{
    internal class Program
    {
        static Customer CreateCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter Customer's Username.");
            customer.Username = Console.ReadLine();
            Console.WriteLine("Enter Customer's Password.");
            customer.Password = Console.ReadLine();
            Console.WriteLine("Enter the balance.");
            double balance;
            while(!double.TryParse(Console.ReadLine(), out balance))
            {
                Console.WriteLine("Invalid Balance.");
            }
            customer.Balance = balance;
            return customer;
        }
        static void AddProductToTest()
        {
            Product product = new Product();
            Console.WriteLine("Enter Product's name.");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter Product's quantity");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid quantity.");
            }
            product.Quantity = quantity;
            Console.WriteLine("Enter Product's price");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price.");
            }
            product.Price = price;
            Console.WriteLine("Can the product expire?\nEnter 1 to Yes or 2 to No.");
            int expire;
            while (!int.TryParse(Console.ReadLine(), out expire) || expire > 2 || expire < 1)
            {
                Console.WriteLine("Invalid Input.");

            }
            if (expire == 1)
            {
                Console.WriteLine("Enter the expire date.");
                DateTime date;
                while (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Invalid Date.");
                }
                product.ExpireDate = date;

            }
            Console.WriteLine("Can the product shipping?\nEnter 1 to Yes or 2 to No.");
            int shipping;
            while (!int.TryParse(Console.ReadLine(), out shipping) || shipping > 2 || shipping < 1)
            {
                Console.WriteLine("Invalid Input.");

            }
            if (shipping == 1)
            {
                Console.WriteLine("Enter Product's Weight.");
                double weight;
                while (!double.TryParse(Console.ReadLine(), out weight))
                {
                    Console.WriteLine("Invalid weight.");
                }
                product.Weight = weight;
            }
            Store.AddProduct(product);
            Console.WriteLine("Do you want to add another product?\nEnter 1 to Yes or 2 to No.");
                int type;
                while (!int.TryParse(Console.ReadLine(), out type) || type > 2 || type < 1)
                {
                    Console.WriteLine("Invalid Input.");

                }
                if (type == 1)
                {
                    AddProductToTest();
                }
            }
        static void Checkout(Customer customer, Cart cart)
        {
            if (cart.Shippable)
            {
                ShippingService shippingService = new ShippingService();
                shippingService.Shipment(cart);
            }
            Console.WriteLine("** Checkout receipt **");
            double subtotal = 0;
            foreach (var product in cart.Products)
            {
                subtotal += product.Quantity * product.Price;
            }
            if (subtotal * 1.1 > customer.Balance) {
                Console.WriteLine($"Error!! your balance isn't enough\nThe Amount is {1.1*subtotal} and your balance is {customer.Balance}.");
                return;
            }
            foreach (var product in cart.Products) {
                Console.WriteLine($"{product.Quantity}x {product.Name}\t{product.Quantity*product.Price}");
            }
            Console.WriteLine($"-----------------------------\nSubtotal\t{subtotal}\nShipping\t{subtotal * 0.1}\nAmount\t{subtotal * 1.1}\nSee you soon..");
        }
        static void Main(string[] args)
        {
            Cart cart = new Cart();
            Console.WriteLine("Enter Product to test.");
            AddProductToTest();
            Customer customer = CreateCustomer();
            while (true)
            {
                Console.WriteLine("What do you want to order?");
                Store.ShowProducts();
                
                string name=Console.ReadLine();
                Console.WriteLine("How much do you want?");
                int quantity;
                while (!int.TryParse(Console.ReadLine(),out quantity))
                {
                    Console.WriteLine("Invalid quantity.");
                }
                cart.Add(name, quantity);
                Console.WriteLine("Do you want to order another product?\nEnter 1 to Yes or 2 to No.");
                int type;
                while (!int.TryParse(Console.ReadLine(), out type) || type > 2 || type < 1)
                {
                    Console.WriteLine("Invalid Input.");

                }
                if (type == 2)
                {
                    break;
                }
            }
            if (cart.Empty())
            {
                Console.WriteLine("Error!! cart is empty.");
                return;
            }
            Checkout(customer, cart);

        }
    }
}

