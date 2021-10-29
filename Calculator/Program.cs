using System;
using System.Linq;

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
      StringParseCalc();
    }

    private static void CalcSimply()
    {
      double result;
      while (true)
      {
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

    private static void StringParseCalc()
    {
      double leftNumber;
      double rightNumber;
      string action;

      var userInput = Console.ReadLine().Split(" ");
      leftNumber = double.Parse(userInput[0]);
      action = userInput[1];
      rightNumber = double.Parse(userInput[2]);

      switch (action)
      {
        case "+":
          Console.WriteLine(leftNumber + rightNumber);
          break;       
        case "-":
          Console.WriteLine(leftNumber - rightNumber);
          break;        
        case "/":
          Console.WriteLine(leftNumber / rightNumber);
          break;        
        case "*":
          Console.WriteLine(leftNumber * rightNumber);
          break;
        default:
          Console.WriteLine("хз чё делать");
          break;
      }
    }
  }
}