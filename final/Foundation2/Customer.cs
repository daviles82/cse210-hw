using System;

namespace Foundation2
{
    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public bool IsInUSA()
        {
            return address.Country == "USA";
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }

        public double GetShippingCost()
        {
            return IsInUSA() ? 5 : 35;
        }
    }
}
