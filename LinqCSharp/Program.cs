namespace LinqCSharp
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string University { get; set; }

        public Student(string firstName, string lastName, int age, string university)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            University = university;
        }
    }

    public class StudentOperations
    {
        public static List<Student> GetAllStudents(List<Student> students)
        {
            return students;
        }

        public static List<Student> GetStudentsWithFirstName(List<Student> students, string firstName)
        {
            return students.Where(student => student.FirstName == firstName).ToList();
        }

        public static List<Student> GetStudentsWithLastNameStartingWith(List<Student> students, string prefix)
        {
            return students.Where(student => student.LastName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Student> GetStudentsOlderThan(List<Student> students, int age)
        {
            return students.Where(student => student.Age > age).ToList();
        }

        public static List<Student> GetStudentsBetweenAges(List<Student> students, int minAge, int maxAge)
        {
            return students.Where(student => student.Age > minAge && student.Age < maxAge).ToList();
        }

        public static List<Student> GetStudentsAtUniversity(List<Student> students, string university)
        {
            return students.Where(student => student.University.Equals(university, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Student> GetStudentsAtUniversityOlderThan(List<Student> students, string university, int age)
        {
            return students.Where(student => student.University.Equals(university, StringComparison.OrdinalIgnoreCase) && student.Age > age)
                           .OrderByDescending(student => student.Age)
                           .ToList();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>
        {
            new Student("John", "Doe", 20, "MIT"),
            new Student("Jane", "Smith", 18, "Harvard"),
            new Student("Boris", "Johnson", 21, "Oxford"),
            new Student("Alice", "Brown", 22, "Stanford"),
            new Student("Bob", "Smithson", 19, "MIT"),
            new Student("Brenda", "Roberts", 23, "Oxford")
        };

            Console.WriteLine("Усі студенти:");
            PrintStudents(StudentOperations.GetAllStudents(students));

            Console.WriteLine("\nСтуденти з ім'ям Boris:");
            PrintStudents(StudentOperations.GetStudentsWithFirstName(students, "Boris"));

            Console.WriteLine("\nСтуденти з прізвищем, яке починається з Bro:");
            PrintStudents(StudentOperations.GetStudentsWithLastNameStartingWith(students, "Bro"));

            Console.WriteLine("\nСтуденти старші за 19 років:");
            PrintStudents(StudentOperations.GetStudentsOlderThan(students, 19));

            Console.WriteLine("\nСтуденти у віці від 20 до 23 років:");
            PrintStudents(StudentOperations.GetStudentsBetweenAges(students, 20, 23));

            Console.WriteLine("\nСтуденти, які навчаються в MIT:");
            PrintStudents(StudentOperations.GetStudentsAtUniversity(students, "MIT"));

            Console.WriteLine("\nСтуденти, які навчаються в Oxford, і вік яких старше 18 років (в порядку спадання за віком):");
            PrintStudents(StudentOperations.GetStudentsAtUniversityOlderThan(students, "Oxford", 18));
        }

        public static void PrintStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}, {student.Age} років, навчається в {student.University}");
            }
        }
    }
}
