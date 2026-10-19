// *****************************************************************
// Практическая работа №12                                         *
// Выполнил: Матченко М.С., группа 2-ИСП-оКФ                       *
// Вариант 3                                                       *
// Задание: Организация и использование функций                    *
// *****************************************************************
using System;
using System.Text;
namespace PR_12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Практическая работа №12";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            string select;
            string S;
            Console.WriteLine("Здравствуйте!");
            do // внешний цикл для повторного запуска 
            {
                Console.WriteLine("\n--- Новый расчет ---");
                while (true) // Цикл ввода строки S
                {
                    try
                    {
                        Console.Write("Введите строку с символами латинского алфавита: ");
                        S = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(S))
                        {
                            throw new ArgumentException("Строка не может быть пустой или состоять только из пробелов");
                        }
                        foreach (char c in S)
                        {
                            if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                            {
                                throw new ArgumentException($"В строке обнаружены недопустимые символы. Разрешены только символы латинского алфавита.");
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        HandleError(ex);
                        Console.WriteLine("Пожалуйста, повторите ввод...\n");
                    }
                }
                string result = SwapCase(S);
                Console.WriteLine("Преобразованная строка: " + result);
                Console.Write("\nХотите выполнить программу еще раз? (да - 1 / нет - любая клавиша): ");
                select = Console.ReadLine();
            }
            while (select == "1");
            Console.WriteLine("\nПрограмма завершена. Нажмите Enter для выхода...");
            Console.ReadLine();
        }
        public static void HandleError(Exception ex)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Возникла ошибка: " + ex.Message);
            Console.ForegroundColor = originalColor;
        }
        public static string SwapCase(string text)
        {
            var result = new StringBuilder(text.Length);
            foreach (char c in text)
            {
                if (char.IsLower(c))
                    result.Append(char.ToUpper(c));
                else 
                    result.Append(char.ToLower(c));
            }
            return result.ToString();
        }
    }
}