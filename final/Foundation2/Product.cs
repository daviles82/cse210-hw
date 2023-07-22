using System;
using System.Collections.Generic;
using System.Linq;

namespace Foundation2
{
  public class Product
  {
      private string name, productId;
      private double price, quantity;

      public Product(string name, string productId, double price, double quantity)
      {
          this.name = name;
          this.productId = productId;
          this.price = price;
          this.quantity = quantity;
      }

      public double GetPrice()
      {
        return price * quantity;
      }

      public string GetName()
      {
          return name;
      }

      public string GetProductId()
      {
          return productId;
      }

          public double GetQuantity()
      {
          return quantity;
      }
  }
}