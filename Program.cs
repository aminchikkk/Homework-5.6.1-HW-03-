using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homework5._6
{
    internal class Program
    {
        private static byte numberOfFavouriteColors = 0;
        private static byte numberOfPets = 0;
        private static string error = "Проверьте правильность введенных данных";

        private static void Main(string[] args)
        {
            EnteringUserData();
            EnteringPetNames(numberOfPets, out string[] namesOfPets);
            EnteringNumberOfFavouriteColors();
            EnteringFavouriteColors(numberOfFavouriteColors, out string[] namesOfColors);
        }

        /// <summary>
        /// Метод, который заполняет данные с клавиатуры по пользователю (возвращает кортеж).
        /// </summary>
        public static (string name, string surname, byte age) EnteringUserData()
        {
            (string name, string surname, byte age) User;
            byte age = 0;
            Console.Write("Введите имя:");
            string? name = Console.ReadLine();
            User.name = name;
            Console.Write("Введите свою фамилию:");
            string? surname = Console.ReadLine();
            User.surname = surname;
            Console.Write("Введите свой возраст цифрами:");
            string? stringAge= Console.ReadLine();
            CheckNum(stringAge, out byte byteAge);
            User.age = age;
            Console.WriteLine("У вас есть питомец?");
            string? answer = Console.ReadLine();
            answer?.ToLower();
            if (answer == "да")
            {
                Console.WriteLine("Сколько у вас питомцев?");
                do
                {
                    try
                    {
                        numberOfPets = byte.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(error);
                    }
                } while (numberOfPets == 0);
            }
            return User;
        }

        /// <summary>
        /// Ввод кличек питомцев.
        /// </summary>
        public static void EnteringPetNames(byte numberOfPets, out string[] namesOfPets)
        {
            byte j = 0;
            namesOfPets = new string[numberOfPets];
            for (byte i = 1; i <= numberOfPets; i++)
            {
                Console.WriteLine($"Введите имя {i} питомца");
                namesOfPets[j] = Console.ReadLine();
                j++;
            }
        }

        /// <summary>
        /// Ввод любимых цветов.
        /// </summary>
        public static void EnteringFavouriteColors(byte numberOfColors, out string[] namesOfColors)
        {
            byte j = 0;
            namesOfColors = new string[numberOfColors];
            for (byte i = 1; i <= numberOfColors; i++)
            {
                Console.WriteLine($"Введите имя {i} любимого цвета");
                namesOfColors[j] = Console.ReadLine();
                j++;
            }
        }

        /// <summary>
        /// Ввод количества любимых цветов пользователя.
        /// </summary>
        public static void EnteringNumberOfFavouriteColors()
        {
            Console.WriteLine("Сколько у вас любимых цветов?");
            do
            {
                try
                {
                    numberOfFavouriteColors = byte.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(error);
                }
            } while (numberOfFavouriteColors == 0);
        }

        /// <summary>
        /// Проверка правильности ввода возраста.
        /// </summary>
        public static void CheckNum(string age, out byte byteAge)
        {
            byteAge = 0;
            do
            {
                try
                {
                    byteAge = byte.Parse(age);
                }
                catch
                {
                    age = null;
                    Console.WriteLine(error);
                    Console.WriteLine("Попробуйте снова!");
                    age=Console.ReadLine();
                }
            } while (byteAge == 0);
        }
    }
}