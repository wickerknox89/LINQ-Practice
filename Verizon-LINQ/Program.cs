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

        GetAllCountries(countries);
        GetAllStates(countries);
        GetAllCities(countries);

        // Get the name of the city with zipcode 3333 
        var cityName = GetCityName("3333", countries);
        Console.WriteLine($"\nCity : {cityName}");

        // Get the count of cities in the state of Texas 
        var cityCount = GetNumberOfCities("Texas", countries);
        Console.WriteLine($"\nCount of City : {cityCount}");



        Console.ReadLine();
    }

    public static List<Country> AddData()
    {
        var city1 = new City() { cityName = "Dallas", cityzip = "1234" };
        var city2 = new City() { cityName = "Austin", cityzip = "2345" };
        var city3 = new City() { cityName = "NewYork", cityzip = "6789" };
        var city4 = new City() { cityName = "NewJersy", cityzip = "3333" };
        var city5 = new City() { cityName = "Houston", cityzip = "4444" };
        var city6 = new City() { cityName = "Mumbai", cityzip = "400001" };
        var city7 = new City() { cityName = "Pune", cityzip = "411001" };
        var city8 = new City() { cityName = "Kanpur", cityzip = "208005" };
        var city9 = new City() { cityName = "Thiruvananthapuram", cityzip = "685004" };
        var city10 = new City() { cityName = "Nagpur", cityzip = "440005" };
        var city11 = new City() { cityName = "Allahabad", cityzip = "211005" };
        var city12 = new City() { cityName = "Cottbus", cityzip = "03048" };
        var city13 = new City() { cityName = "Potsdam", cityzip = "14473" };
        var city14 = new City() { cityName = "Leipzig", cityzip = "04109" };
        var city15 = new City() { cityName = "Dresden", cityzip = "01099" };
        var city16 = new City() { cityName = "Buckow", cityzip = "15377" };

        var state1 = new State() { stateName = "Texas", cities = new List<City>() { city1, city2, city5 } };
        var state2 = new State() { stateName = "New York", cities = new List<City>() { city3, city4 } };
        var state3 = new State() { stateName = "Maharashtra", cities = new List<City>() { city6, city7, city10 } };
        var state4 = new State() { stateName = "Uttar Pradesh", cities = new List<City>() { city8, city11 } };
        var state5 = new State() { stateName = "Kerala", cities = new List<City>() { city9 } };
        var state6 = new State() { stateName = "Brandenburg", cities = new List<City>() { city12, city13, city16 } };
        var state7 = new State() { stateName = "Saxony", cities = new List<City>() { city14, city15 } };
        
        List<Country> countries = new List<Country>();
        countries.Add(new Country() { countryName = "USA", states = new List<State>() { state1, state2 } });
        countries.Add(new Country() { countryName = "India", states = new List<State>() { state3, state4, state5  } });
        countries.Add(new Country() { countryName = "Germany", states = new List<State>() { state6, state7 } });

        return countries;
    }

    public static void PrintOnConsole(IEnumerable<string> result)
    {
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\n");
    }

    public static IEnumerable<string> GetAllCountries(List<Country> countries)
    {
        var result = countries.Select(x => x.countryName);
        PrintOnConsole(result);
        return result;
    }

    public static IEnumerable<string> GetAllStates(List<Country>countries)
    {
        // var result = countries.SelectMany(x => x.states).Select(y => y.stateName);
        var result = countries.SelectMany(x => x.states.Select(y => y.stateName));
        PrintOnConsole(result);
        return result;
    }

    public static IEnumerable<string> GetAllCities(List<Country> countries)
    {
        var result = countries.SelectMany(x => x.states.SelectMany(y => y.cities.Select(z => z.cityName))).ToList();
        result.ForEach(x => Console.WriteLine(x));
        return result;
    }

    public static string GetCityName(string zipcode, List<Country> countries)
    {
        var city = countries.SelectMany(x => x.states.SelectMany(y => y.cities.Where(z => z.cityzip == zipcode)));
        string cityName = "";
        foreach (var item in city)
        {
            cityName = item.cityName;
        }
        return cityName;
    }
    
    public static int GetNumberOfCities(string stateName, List<Country> countries)
    {
        int count = countries.SelectMany(x => x.states.Where(y => y.stateName == stateName).SelectMany(z => z.cities)).Count();
        IEnumerable<City> cities = countries.SelectMany(x => x.states.Where(y => y.stateName == stateName).SelectMany(z => z.cities));
        return count;
    }
}
