using CitySearch;
using CitySearch.Interfaces;

var cityNames = new List<string> {   "New York", "Los Angeles", "Chicago", "Houston", "Phoenix",
                "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose" };//{ "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "London", "Bangalore", "Bangkok", "Bandung", "Bangui", "Leeds", "Lagos" };

ICityFinder cityFinder = new CityFinder(cityNames);

Console.WriteLine("Type the name of a city:");

var input = "";

while (true)
{
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
    {
        input = input.Substring(0, input.Length - 1);
        Console.WriteLine("\b \b");
    }
    else if (char.IsLetter(keyInfo.KeyChar))
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
