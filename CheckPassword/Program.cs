using System;

namespace Ugly
{
    class Program
    {
        private const int Password = 777;

        private static void Main(string[] args) => StartProgram();

        private static void StartProgram()
        {
            Console.Title = "Система безопасности";

            UserGreeting();
            CheckPassword();
        }

        private static void UserGreeting()
        {
            ChangeConsoleColor(ConsoleColor.Blue);

            Console.WriteLine("\t\t\tДобро пожаловать!");
            Console.Write("\nВведите пароль: ");

            ChangeConsoleColor(ConsoleColor.White);
        }

        private static void CheckPassword()
        {
            while (!int.TryParse(Console.ReadLine(), out int userInput) || userInput != Password)
            {
                ChangeConsoleColor(ConsoleColor.DarkRed);

                Console.WriteLine("\n\n\t\tНеверный пароль");
                Console.Write("\nПопробуйте ещё раз: ");

                ChangeConsoleColor(ConsoleColor.White);
            }

            ChangeConsoleColor(ConsoleColor.DarkGreen);

            Console.WriteLine("\nДобро пожаловать в систему!\nНагибатор 3000");

            Console.ReadKey(true);
        }

        private static void ChangeConsoleColor(ConsoleColor color) => Console.ForegroundColor = color;

    }
}