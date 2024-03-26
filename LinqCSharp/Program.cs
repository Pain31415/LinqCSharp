namespace LinqCSharp
{
    /// <summary>
    /// Клас для виконання операцій над масивом цілих чисел.
    /// </summary>
    public class ArrayOperations
    {
        /// <summary>
        /// Отримати весь масив цілих чисел.
        /// </summary>
        /// <param name="array">Вхідний масив цілих чисел.</param>
        /// <returns>Весь масив цілих чисел.</returns>
        public static int[] GetAllIntegers(int[] array)
        {
            return array;
        }

        /// <summary>
        /// Отримати парні цілі числа.
        /// </summary>
        /// <param name="array">Вхідний масив цілих чисел.</param>
        /// <returns>Масив, що містить лише парні цілі числа.</returns>
        public static int[] GetEvenIntegers(int[] array)
        {
            return array.Where(x => x % 2 == 0).ToArray();
        }

        /// <summary>
        /// Отримати непарні цілі числа.
        /// </summary>
        /// <param name="array">Вхідний масив цілих чисел.</param>
        /// <returns>Масив, що містить лише непарні цілі числа.</returns>
        public static int[] GetOddIntegers(int[] array)
        {
            return array.Where(x => x % 2 != 0).ToArray();
        }

        /// <summary>
        /// Отримати значення більше заданого.
        /// </summary>
        /// <param name="array">Вхідний масив цілих чисел.</param>
        /// <param name="threshold">Поріг, значення якого використовується для фільтрації.</param>
        /// <returns>Масив, що містить лише цілі числа більше заданого порогу.</returns>
        public static int[] GetValuesGreaterThan(int[] array, int threshold)
        {
            return array.Where(x => x > threshold).ToArray();
        }

        /// <summary>
        /// Отримати числа в заданому діапазоні.
        /// </summary>
        /// <param name="array">Вхідний масив цілих чисел.</param>
        /// <param name="min">Мінімальне значення діапазону (включно).</param>
        /// <param name="max">Максимальне значення діапазону (включно).</param>
        /// <returns>Масив, що містить лише цілі числа в заданому діапазоні.</returns>
        public static int[] GetNumbersInRange(int[] array, int min, int max)
        {
            return array.Where(x => x >= min && x <= max).ToArray();
        }

        /// <summary>
        /// Отримати числа, кратні семи. Результат відсортуйте за зростанням.
        /// </summary>
        /// <param name="array">Вхідний масив цілих чисел.</param>
        /// <returns>Масив, що містить лише цілі числа, кратні семи, відсортований за зростанням.</returns>
        public static int[] GetMultiplesOfSeven(int[] array)
        {
            return array.Where(x => x % 7 == 0).OrderBy(x => x).ToArray();
        }

        /// <summary>
        /// Отримати числа, кратні восьми. Результат відсортуйте за спаданням.
        /// </summary>
        /// <param name="array">Вхідний масив цілих чисел.</param>
        /// <returns>Масив, що містить лише цілі числа, кратні восьми, відсортований за спаданням.</returns>
        public static int[] GetMultiplesOfEightDescending(int[] array)
        {
            return array.Where(x => x % 8 == 0).OrderByDescending(x => x).ToArray();
        }

        // Приклад використання:
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 14, 16, 18, 21, 24, 28, 32 };

            Console.WriteLine("Усі цілі числа:");
            Console.WriteLine(string.Join(", ", GetAllIntegers(numbers)));

            Console.WriteLine("\nПарні цілі числа:");
            Console.WriteLine(string.Join(", ", GetEvenIntegers(numbers)));

            Console.WriteLine("\nНепарні цілі числа:");
            Console.WriteLine(string.Join(", ", GetOddIntegers(numbers)));

            Console.WriteLine("\nЗначення більше 10:");
            Console.WriteLine(string.Join(", ", GetValuesGreaterThan(numbers, 10)));

            Console.WriteLine("\nЧисла в діапазоні від 5 до 20:");
            Console.WriteLine(string.Join(", ", GetNumbersInRange(numbers, 5, 20)));

            Console.WriteLine("\nЧисла, кратні семи:");
            Console.WriteLine(string.Join(", ", GetMultiplesOfSeven(numbers)));

            Console.WriteLine("\nЧисла, кратні восьми (за спаданням):");
            Console.WriteLine(string.Join(", ", GetMultiplesOfEightDescending(numbers)));
        }
    }
}
