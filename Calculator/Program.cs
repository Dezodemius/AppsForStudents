using System;

namespace Calculator
{
  /// <summary>
  /// Главный класс программы.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Точека входа в программу.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    public static void Main(string[] args)
    {
      CalcSimply();
    }

    private static void CalcSimply()
    {
      double result;
      while (true)
      {
        var a = "dawdaw";
        Console.WriteLine(a[2]);
        Console.Write("a: ");
        var leftNumber = double.Parse(Console.ReadLine());

        ConsoleKey action = Console.ReadKey().Key;
        
        Console.Write(" b: ");
        var rightNumber = double.Parse(Console.ReadLine());

        switch (action)
        {
         case ConsoleKey.Add:
           result = leftNumber + rightNumber;
           break;
         case ConsoleKey.Subtract:
           result = leftNumber - rightNumber;
           break;
         default:
           result = -1;
           break;
        }
        Console.WriteLine(result);

      }
    }
  }
}