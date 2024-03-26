namespace LinqCSharp
{
    public static class CityExtensions
    {
        public static List<string> GetAllCities(this List<string> cities)
        {
            return cities.ToList();
        }

        public static List<string> GetCitiesWithLength(this List<string> cities, int length)
        {
            return cities.Where(city => city.Length == length).ToList();
        }

        public static List<string> GetCitiesStartingWith(this List<string> cities, char letter)
        {
            return cities.Where(city => city.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<string> GetCitiesEndingWith(this List<string> cities, char letter)
        {
            return cities.Where(city => city.EndsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<string> GetCitiesStartingWithAndEndingWith(this List<string> cities, char startLetter, char endLetter)
        {
            return cities.Where(city => city.StartsWith(startLetter.ToString(), StringComparison.OrdinalIgnoreCase) &&
                                         city.EndsWith(endLetter.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<string> GetCitiesStartingWithNeDescending(this List<string> cities)
        {
            return cities.Where(city => city.StartsWith("Ne", StringComparison.OrdinalIgnoreCase))
                         .OrderByDescending(city => city)
                         .ToList();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> cities = new List<string> { "New York", "Los Angeles", "London", "Berlin", "Paris", "Tokyo" };

            Console.WriteLine("Усі міста:");
            Console.WriteLine(string.Join(", ", cities.GetAllCities()));

            Console.WriteLine("\nМіста з довжиною назви 7:");
            Console.WriteLine(string.Join(", ", cities.GetCitiesWithLength(7)));

            Console.WriteLine("\nМіста, назви яких починаються з літери A:");
            Console.WriteLine(string.Join(", ", cities.GetCitiesStartingWith('A')));

            Console.WriteLine("\nМіста, назви яких закінчуються на літеру n:");
            Console.WriteLine(string.Join(", ", cities.GetCitiesEndingWith('n')));

            Console.WriteLine("\nМіста, назви яких починаються з літери N і закінчуються літерою K:");
            Console.WriteLine(string.Join(", ", cities.GetCitiesStartingWithAndEndingWith('N', 'K')));

            Console.WriteLine("\nМіста, назви яких починаються з Ne (в порядку спадання):");
            Console.WriteLine(string.Join(", ", cities.GetCitiesStartingWithNeDescending()));
        }
    }
}
