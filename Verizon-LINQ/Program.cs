using System;
using System.Linq;
using System.Collections.Generic;

public class Country
{
    public string countryName { get; set; }
    public List<State> states { get; set; }
}

public class State
{
    public string stateName { get; set; }
    public List<City> cities { get; set; }
}

public class City
{
    public string cityName { get; set; }
    public string cityzip { get; set; }
}

public class Program
{
    public static void Main()
    {
        var countries = AddData();
        var cityName = GetCityName("3333", countries);
        Console.WriteLine($"City : {cityName}");

        var cityCount = GetNumberOfCities("Texas", countries);
        Console.WriteLine($"Count of City : {cityCount}");
        
        Console.ReadLine();
    }

    public static List<Country> AddData()
    {
        var city1 = new City() { cityName = "Dallas", cityzip = "1234" };
        var city2 = new City() { cityName = "Austin", cityzip = "2345" };
        var city3 = new City() { cityName = "NewYork", cityzip = "6789" };
        var city4 = new City() { cityName = "NewJersy", cityzip = "3333" };
        var city5 = new City() { cityName = "Houston", cityzip = "4444" };

        var state1 = new State() { stateName = "Texas", cities = new List<City>() { city1, city2, city5 } };
        var state2 = new State() { stateName = "NewYork", cities = new List<City>() { city3, city4 } };
        
        List<Country> countries = new List<Country>();
        countries.Add(new Country() { countryName = "USA", states = new List<State>() { state1, state2 } });
        
        return countries;
    }

    public static string GetCityName(string zipcode, List<Country> countries)
    {
        IEnumerable<City> City = countries.SelectMany(x => x.states.SelectMany(y => y.cities.Where(z => z.cityzip == zipcode)));
        string cityName = "";
        foreach(var item in City)
        {
            cityName=item.cityName;
        }
        return cityName;
    }
    
    public static int GetNumberOfCities(string stateName, List<Country> countries)
    {
        var cityCount = countries.SelectMany(x => x.states.Where(y => y.stateName == stateName).SelectMany(z => z.cities)).Count();
        return cityCount;
    }
}
