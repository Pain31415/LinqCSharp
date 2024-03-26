namespace LinqCSharp
{
    public class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public Employee(string fullName, string position, string contactNumber, string email, decimal salary)
        {
            FullName = fullName;
            Position = position;
            ContactNumber = contactNumber;
            Email = email;
            Salary = salary;
        }
    }

    public class Firm
    {
        public string Name { get; set; }
        public DateTime FoundedDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; }

        public Firm(string name, DateTime foundedDate, string businessProfile, string directorFullName, int numberOfEmployees, string address)
        {
            Name = name;
            FoundedDate = foundedDate;
            BusinessProfile = businessProfile;
            DirectorFullName = directorFullName;
            NumberOfEmployees = numberOfEmployees;
            Address = address;
            Employees = new List<Employee>();
        }
    }

    public static class FirmOperations
    {
        public static List<Employee> GetAllEmployees(this Firm firm)
        {
            return firm.Employees;
        }

        public static List<Employee> GetEmployeesWithSalaryGreaterThan(this Firm firm, decimal salary)
        {
            return firm.Employees.Where(emp => emp.Salary > salary).ToList();
        }

        public static List<Employee> GetEmployeesWithPosition(this List<Firm> firms, string position)
        {
            return firms.SelectMany(firm => firm.Employees.Where(emp => emp.Position.Equals(position, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public static List<Employee> GetEmployeesWithPhoneNumberStartingWith(this List<Firm> firms, string prefix)
        {
            return firms.SelectMany(firm => firm.Employees.Where(emp => emp.ContactNumber.StartsWith(prefix))).ToList();
        }

        public static List<Employee> GetEmployeesWithEmailStartingWith(this List<Firm> firms, string prefix)
        {
            return firms.SelectMany(firm => firm.Employees.Where(emp => emp.Email.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public static List<Employee> GetEmployeesWithName(this List<Firm> firms, string name)
        {
            return firms.SelectMany(firm => firm.Employees.Where(emp => emp.FullName.Equals(name, StringComparison.OrdinalIgnoreCase))).ToList();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Firm> firms = new List<Firm>
        {
            new Firm("ABC Inc.", DateTime.Now, "IT Services", "John Doe", 50, "New York"),
            new Firm("XYZ Corporation", DateTime.Now, "Consulting", "Jane Smith", 100, "Los Angeles")
        };

            firms[0].Employees.Add(new Employee("Alice Johnson", "Manager", "234567890", "alice@example.com", 5000));
            firms[0].Employees.Add(new Employee("Bob Williams", "Developer", "235678901", "bob@example.com", 4000));
            firms[1].Employees.Add(new Employee("Charlie Brown", "Consultant", "345678912", "charlie@example.com", 6000));
            firms[1].Employees.Add(new Employee("David Lee", "Manager", "456789123", "david@example.com", 5500));

            Console.WriteLine("Працівники ABC Inc.:");
            PrintEmployees(FirmOperations.GetAllEmployees(firms[0]));

            Console.WriteLine("\nПрацівники, зарплата яких більша за 4500 в ABC Inc.:");
            PrintEmployees(FirmOperations.GetEmployeesWithSalaryGreaterThan(firms[0], 4500));

            Console.WriteLine("\nПрацівники в усіх фірмах, які мають посаду 'Manager':");
            PrintEmployees(FirmOperations.GetEmployeesWithPosition(firms, "Manager"));

            Console.WriteLine("\nПрацівники в усіх фірмах, номер телефону яких починається з '23':");
            PrintEmployees(FirmOperations.GetEmployeesWithPhoneNumberStartingWith(firms, "23"));

            Console.WriteLine("\nПрацівники в усіх фірмах, email яких починається з 'di':");
            PrintEmployees(FirmOperations.GetEmployeesWithEmailStartingWith(firms, "di"));
        }

        public static void PrintEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"ПІБ: {employee.FullName}, Посада: {employee.Position}, " +
                    $"Телефон: {employee.ContactNumber}, Email: {employee.Email}, " +
                    $"Зарплата: {employee.Salary}");
            }
        }
    }
}
