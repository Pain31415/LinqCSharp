namespace LinqCSharp
{
    public class CityOperations
    {
        public static string[] GetAllCities(string[] cities)
        {
            return cities;
        }

        public static string[] GetCitiesWithLength(string[] cities, int length)
        {
            return cities.Where(city => city.Length == length).ToArray();
        }

        public static string[] GetCitiesStartingWith(string[] cities, char letter)
        {
            return cities.Where(city => city.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        public static string[] GetCitiesEndingWith(string[] cities, char letter)
        {
            return cities.Where(city => city.EndsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        public static string[] GetCitiesStartingWithAndEndingWith(string[] cities, char startLetter, char endLetter)
        {
            return cities.Where(city =>
                city.StartsWith(startLetter.ToString(), StringComparison.OrdinalIgnoreCase) &&
                city.EndsWith(endLetter.ToString(), StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        public static string[] GetCitiesStartingWithNeDescending(string[] cities)
        {
            return cities.Where(city => city.StartsWith("Ne", StringComparison.OrdinalIgnoreCase))
                         .OrderByDescending(city => city)
                         .ToArray();
        }

        public static void Main(string[] args)
        {
            string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose", "Austin", "Jacksonville", "San Francisco", "Columbus", "Fort Worth", "Indianapolis", "Charlotte", "Seattle", "Denver", "Washington" };

            Console.WriteLine($"Усі міста:\n{string.Join(", ", GetAllCities(cities))}");
            Console.WriteLine($"\nМіста з довжиною назви 7:\n{string.Join(", ", GetCitiesWithLength(cities, 7))}");
            Console.WriteLine($"\nМіста, назви яких починаються з літери A:\n{string.Join(", ", GetCitiesStartingWith(cities, 'A'))}");
            Console.WriteLine($"\nМіста, назви яких закінчуються на літеру n:\n{string.Join(", ", GetCitiesEndingWith(cities, 'n'))}");
            Console.WriteLine($"\nМіста, назви яких починаються з N і закінчуються на K:\n{string.Join(", ", GetCitiesStartingWithAndEndingWith(cities, 'N', 'K'))}");
            Console.WriteLine($"\nМіста, назви яких починаються з Ne (в порядку спадання):\n{string.Join(", ", GetCitiesStartingWithNeDescending(cities))}");
        }
    }
}
