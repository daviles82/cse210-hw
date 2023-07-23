using System;
using System.IO;

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

    public string GetFullAddress()
    {
        return $"{streetAddress}, {city}, {stateOrProvince}, {country}";
    }
}