namespace LinqCSharp
{
    public class Firm
    {
        public string Name { get; set; }
        public DateTime FoundedDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Address { get; set; }

        public Firm(string name, DateTime foundedDate, string businessProfile, string directorFullName, int numberOfEmployees, string address)
        {
            Name = name;
            FoundedDate = foundedDate;
            BusinessProfile = businessProfile;
            DirectorFullName = directorFullName;
            NumberOfEmployees = numberOfEmployees;
            Address = address;
        }
    }

    public class FirmOperations
    {
        public static List<Firm> GetAllFirms(List<Firm> firms)
        {
            return firms;
        }

        public static List<Firm> GetFirmsWithNameContaining(List<Firm> firms, string keyword)
        {
            return firms.Where(firm => firm.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Firm> GetFirmsByBusinessProfile(List<Firm> firms, string businessProfile)
        {
            return firms.Where(firm => firm.BusinessProfile.Equals(businessProfile, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Firm> GetFirmsByBusinessProfiles(List<Firm> firms, params string[] businessProfiles)
        {
            return firms.Where(firm => businessProfiles.Contains(firm.BusinessProfile, StringComparer.OrdinalIgnoreCase)).ToList();
        }

        public static List<Firm> GetFirmsWithEmployeeCountGreaterThan(List<Firm> firms, int count)
        {
            return firms.Where(firm => firm.NumberOfEmployees > count).ToList();
        }

        public static List<Firm> GetFirmsWithEmployeeCountInRange(List<Firm> firms, int minCount, int maxCount)
        {
            return firms.Where(firm => firm.NumberOfEmployees >= minCount && firm.NumberOfEmployees <= maxCount).ToList();
        }

        public static List<Firm> GetFirmsLocatedIn(List<Firm> firms, string city)
        {
            return firms.Where(firm => firm.Address.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Firm> GetFirmsWithDirectorLastName(List<Firm> firms, string lastName)
        {
            return firms.Where(firm => firm.DirectorFullName.EndsWith(lastName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Firm> GetFirmsFoundedMoreThanYearsAgo(List<Firm> firms, int years)
        {
            DateTime limitDate = DateTime.Now.AddYears(-years);
            return firms.Where(firm => firm.FoundedDate < limitDate).ToList();
        }

        public static List<Firm> GetFirmsFoundedDaysAgo(List<Firm> firms, int days)
        {
            DateTime limitDate = DateTime.Now.AddDays(-days);
            return firms.Where(firm => firm.FoundedDate == limitDate).ToList();
        }

        public static List<Firm> GetFirmsWithDirectorLastNameAndNameContaining(List<Firm> firms, string lastName, string keyword)
        {
            return firms.Where(firm => firm.DirectorFullName.EndsWith(lastName, StringComparison.OrdinalIgnoreCase) &&
                                        firm.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Firm> firms = new List<Firm>
        {
            new Firm("ABC Food Company", new DateTime(2010, 5, 15), "Food", "John Smith", 50, "London"),
            new Firm("XYZ Marketing Agency", new DateTime(2015, 10, 20), "Marketing", "Alice White", 120, "New York"),
            new Firm("Tech Solutions Ltd", new DateTime(2018, 8, 8), "IT", "Bob Black", 300, "San Francisco"),
            new Firm("Blue Ocean Consulting", new DateTime(2019, 12, 1), "Consulting", "Michael Brown", 80, "Los Angeles"),
            new Firm("Green Energy Innovations", new DateTime(2016, 3, 25), "Energy", "Sarah White", 200, "London"),
            new Firm("Red Tech", new DateTime(2017, 6, 10), "IT", "David Green", 150, "Seattle")
        };

            Console.WriteLine("Усі фірми:");
            PrintFirms(FirmOperations.GetAllFirms(firms));

            Console.WriteLine("\nФірми, які мають у назві слово «Food»:");
            PrintFirms(FirmOperations.GetFirmsWithNameContaining(firms, "Food"));

            Console.WriteLine("\nФірми, які працюють у галузі маркетингу:");
            PrintFirms(FirmOperations.GetFirmsByBusinessProfile(firms, "Marketing"));

            Console.WriteLine("\nФірми, які працюють у галузі маркетингу або IT:");
            PrintFirms(FirmOperations.GetFirmsByBusinessProfiles(firms, "Marketing", "IT"));

            Console.WriteLine("\nФірми, які мають більше 100 працівників:");
            PrintFirms(FirmOperations.GetFirmsWithEmployeeCountGreaterThan(firms, 100));

            Console.WriteLine("\nФірми, які мають від 100 до 300 працівників:");
            PrintFirms(FirmOperations.GetFirmsWithEmployeeCountInRange(firms, 100, 300));

            Console.WriteLine("\nФірми, що знаходяться в Лондоні:");
            PrintFirms(FirmOperations.GetFirmsLocatedIn(firms, "London"));

            Console.WriteLine("\nФірми, в яких прізвище директора закінчується на 'White':");
            PrintFirms(FirmOperations.GetFirmsWithDirectorLastName(firms, "White"));

            Console.WriteLine("\nФірми, засновані більше двох років тому:");
            PrintFirms(FirmOperations.GetFirmsFoundedMoreThanYearsAgo(firms, 2));

            Console.WriteLine("\nФірми, засновані 123 дні тому:");
            PrintFirms(FirmOperations.GetFirmsFoundedDaysAgo(firms, 123));

            Console.WriteLine("\nФірми, в яких прізвище директора - Black, і назва містить 'White':");
            PrintFirms(FirmOperations.GetFirmsWithDirectorLastNameAndNameContaining(firms, "Black", "White"));
        }
        public static void PrintFirms(List<Firm> firms)
        {
            foreach (var firm in firms)
            {
                Console.WriteLine($"Назва: {firm.Name}, " +
                                  $"Дата заснування: {firm.FoundedDate.ToShortDateString()}, " +
                                  $"Профіль бізнесу: {firm.BusinessProfile}, " +
                                  $"Директор: {firm.DirectorFullName}, " +
                                  $"Кількість працівників: {firm.NumberOfEmployees}, " +
                                  $"Адреса: {firm.Address}");
            }
        }
    }
}