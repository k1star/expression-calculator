using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculatror.Classes
{
    public class Display
    {
        public static void Test(double first, double end, double result, char action)
        {
            Console.WriteLine($"\n| {first} {action} {end} = {result} |");
            Console.WriteLine("------------------");
        }

        public static void Test2(string expression, double result)
        {
            Console.WriteLine($"\nРешение: {expression} = {result}");
        }

        public static void PrintErrorMessage(Calculator.Error ex)
        {
            switch (ex)
            {
                case Calculator.Error.INVALID_SYMBOL:
                    Console.WriteLine("\nКод ошибки: 0\nВыражение содержит некорректный символ.");
                    break;
                case Calculator.Error.EMPTY_VALUE:
                    Console.WriteLine("\nКод ошибки: 1\nЗначение выражения пусто.");
                    break;
                case Calculator.Error.INVALID_BKD_NUMBER:
                    Console.WriteLine("\nКод ошибки: 2\nВыражение содержит некорректное количество скобок.");
                    break;
            }
        }
    }
}
