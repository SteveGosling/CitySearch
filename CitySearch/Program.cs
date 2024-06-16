using CitySearch;
using CitySearch.Interfaces;

// initialise the city name collection
// this would normally be database driven AND cached from a real data source
var cityNames = new List<string> { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "London", "Bangalore", "Bangkok", "Bandung", "Bangui", "Leeds", "Lagos" };

ICityFinder cityFinder = new CitySearch.CityFinder(cityNames);

Console.WriteLine("Type the name of a city:");

var input = string.Empty;

while (true)
{
    ConsoleKeyInfo keyInfo = Console.ReadKey();

    // allow for removal of characters
    if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
    {
        input = input.Substring(0, input.Length - 1);
        Console.WriteLine("\b \b");
    }
    // check for allowed characters - letters, spaces and dashes
    else if (CitySearchHelper.IsAllowedChar(keyInfo.KeyChar))
    {
        input += keyInfo.KeyChar;
        Console.WriteLine(keyInfo.KeyChar);
    }

    if (!string.IsNullOrEmpty(input))
    {
        ICityResult result = cityFinder.Search(input);
        Console.WriteLine();
        Console.WriteLine($"Suggestions for next characters: {string.Join(", ", result.NextLetters)}");
        Console.WriteLine($"Suggestions for city: {string.Join(", ", result.NextCities)}");
    }
}