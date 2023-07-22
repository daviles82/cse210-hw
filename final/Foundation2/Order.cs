using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foundation2
  {
  public class Order
  {
      private List<Product> products = new List<Product>();
      private Customer customer;

      public Order(Customer customer)
      {
          this.customer = customer;
      }

      public void AddProduct(Product product)
      {
          products.Add(product);
      }

        public Customer Customer
      {
          get { return customer; }
          set { customer = value; }
      }

      public double GetTotalCost()
      {
          double totalCost = 0;
          foreach (var product in products)
          {
              totalCost += product.GetPrice();
          }
          totalCost += customer.GetShippingCost();
          return totalCost;
      }


      public string GetPackingLabel()
      {
          StringBuilder sb = new StringBuilder();
          foreach (var product in products)
          {
              sb.AppendLine($"{product.GetName()} ({product.GetProductId()}) | Quantity: {product.GetQuantity()}");
          }
          return sb.ToString();
      }

      public string GetShippingLabel()
      {
          return $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
      }
  }
}
