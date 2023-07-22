using System;

namespace Foundation2
{
    public class Address
    {
        private string streetAddress, city, stateOrProvince, country;

        public Address(string streetAddress, string city, string stateOrProvince, string country)
        {
            this.streetAddress = streetAddress;
            this.city = city;
            this.stateOrProvince = stateOrProvince;
            this.country = country;
        }

        public bool IsInUSA()
        {
            return country == "USA";
        }

        public string GetFullAddress()
        {
            return $"{streetAddress}\n{city}, {stateOrProvince}\n{country}";
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
    }
}
