using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foundation2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();

            Customer johnSmith = new Customer("John Smith", new Address("123 Main", "Brookshire", "Texas", "USA"));
            Product mormonBook = new Product("Mormon Book", "Mormon Book", 19.99, 5);
            Product bible = new Product("Bible", "Bible", 21.99, 2);
            Product welcomeMat = new Product("Welcome Mat", "Welcome Mat", 15.99, 1);

            Order order1 = new Order(johnSmith);
            order1.AddProduct(mormonBook);
            order1.AddProduct(bible);
            order1.AddProduct(welcomeMat);

            orders.Add(order1);

            Customer joseHerrero = new Customer("Jose Herrero", new Address("123 Central", "Cancun", "Quintana Roo", "Mexico"));
            Product mormonBook2 = new Product("Mormon Book", "Mormon Book", 19.99, 2);
            Product bible2 = new Product("Bible", "Bible", 21.99, 4);
            Product welcomeMat2 = new Product("Welcome Mat", "Welcome Mat", 15.99, 8);

            Order order2 = new Order(joseHerrero);
            order2.AddProduct(mormonBook2);
            order2.AddProduct(bible2);
            order2.AddProduct(welcomeMat2);

            orders.Add(order2);

            foreach (var order in orders)
            {
                Console.WriteLine($"Order for {order.Customer.GetName()}");
                Console.WriteLine($"Packing Label:\n{order.GetPackingLabel()}");
                Console.WriteLine($"Shipping Label:\n{order.GetShippingLabel()}");
                Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}\n");
            }
        }
    }
}
