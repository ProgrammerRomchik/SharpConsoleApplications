using System;

namespace Ugly
{
    class Program
    {
        private const int MaxPlayerHealth = 150;

        private static int _playerHealth = 100;
        private static int _enemyHealth = 100;

        private static int _playerDamage = 20;
        private static int _enemyDamage = 20;

        private static int _playerRegenerationNumber = 22;

        private static void Main(string[] args) => StartProgram();

        private static void StartProgram()
        {
            Console.Title = "Mortal Combat";

            PrintHeroInformation();

            while (_playerHealth > 0 && _enemyHealth > 0)
            {

                Console.WriteLine($"\n\tW - Атака(-{_playerDamage}) | A - Хилка(+{_playerRegenerationNumber}) | D - Блок(Пропуск удара)");

                Console.Write("\n\nДействие: ");

                ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                switch (consoleKey.Key)
                {
                    case ConsoleKey.W:

                        PrintAction(ConsoleColor.DarkRed, "Атака");

                        Damage();

                        PrintHeroInformation();

                        break;

                    case ConsoleKey.A:

                        PrintAction(ConsoleColor.DarkGreen, "Хилка");

                        _playerHealth -= _enemyDamage;

                        PlayerHealthRegeneration();

                        if (_playerHealth > MaxPlayerHealth)
                        {
                            _playerHealth = MaxPlayerHealth;
                            Console.WriteLine("\n\n\t\tТы превысил лимит лечение");

                            ResetConsoleColor();
                        }

                        PrintHeroInformation();
                        break;

                    case ConsoleKey.D:

                        PrintAction(ConsoleColor.DarkGray, "Блок");

                        PrintHeroInformation();
                        break;

                    default:
                        Console.WriteLine("\n\nТакой команды не существует...");
                        break;
                }
            }

            Die();
        }
        private static void PrintHeroInformation()
        {
            ChangeConsoleColor(ConsoleColor.DarkYellow);

            Console.WriteLine($"\n\t\t\t\t|Игрок: {_playerHealth} HP|\t|{_playerDamage} DM|");  
            Console.WriteLine($"\t\t\t\t|Враг: {_enemyHealth} HP|\t|{_enemyDamage} DM|");

            ResetConsoleColor();
        }

        private static void PrintAction(ConsoleColor color, string message)
        {
            ChangeConsoleColor(color);
            Console.WriteLine($"\n\n\t\t\t\t\t{message}");
            ResetConsoleColor();
        }


        private static void Damage()
        {
            _playerHealth -= _enemyDamage;
            _enemyHealth -= _playerDamage;

            if (_playerHealth < 0)
                _playerHealth = 0;

            if (_enemyHealth < 0)
                _enemyHealth = 0;
        }
        private static void PlayerHealthRegeneration() => _playerHealth += _playerRegenerationNumber;

        private static void Die()
        {
            if (_playerHealth <= 0 && _enemyHealth <= 0)
                Console.WriteLine("\n\n\t\tНичья");

            else if (_playerHealth <= 0)
                Console.WriteLine("\n\n\t\tВраг одержал победу");

            else if (_enemyHealth <= 0)
                Console.WriteLine("\n\n\t\tИгрок одержал победу");
        }


        private static void ChangeConsoleColor(ConsoleColor consoleColor) => Console.ForegroundColor = consoleColor;

        private static void ResetConsoleColor() => Console.ForegroundColor = ConsoleColor.White;
    }
}