using System;
using Tamagotchi.Animal;

namespace Tamagotchi
{
  /// <summary>
  /// Главный класс программы.
  /// </summary>
  public class Program
  {
    #region Константы

    /// <summary>
    /// Имя животного по умолчанию.
    /// </summary>
    private const string DefaultAnimalName = "Животное";

    #endregion

    #region Обработчики

    private static void OnProgramExit(object? sender, EventArgs e)
    {
      ShowEnding();
    }

    #endregion

    #region Методы

    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    public static void Main(string[] args)
    {
      StartTamagotchi(); 
    }

    /// <summary>
    /// Начать игру Тамагочи.
    /// </summary>
    private static void StartTamagotchi()
    {
      AppDomain.CurrentDomain.ProcessExit += OnProgramExit;
      ShowTamagotchiTitle();
      var animal = CreateAnimalFromUserInput();
      animal.Death += () => Environment.Exit(0);

      Console.WriteLine($"Питомец под именем {animal.Name} родился!");
      Console.WriteLine();

      while (true)
      {
        ShowAnimalAbilities();
        ConsoleKey userInput = Console.ReadKey(true).Key;
        if (userInput == ConsoleKey.D0)
          Environment.Exit(1);
        switch (userInput)
        {
          case ConsoleKey.D1:
            animal.Eat();
            break;
          case ConsoleKey.D2:
            animal.Drink();
            break;
          case ConsoleKey.D3:
            animal.Play();
            break;
          case  ConsoleKey.D4:
            animal.Sleep();
            break;
          case  ConsoleKey.D5:
            animal.Speak();
            break;
          case  ConsoleKey.S:
            Console.WriteLine(animal.GetStatus());
            break;
          default:
            Console.WriteLine("Неверный ввод");
            break;
        }
      }
    }

    /// <summary>
    /// Показать заголовок.
    /// </summary>
    private static void ShowTamagotchiTitle()
    {
      Console.WriteLine("~~~~~~~~~~~~~~~Т А М А Г О Ч И~~~~~~~~~~~~~~~");
    }

    /// <summary>
    /// Создать животное исходя из ответа пользователя.
    /// </summary>
    /// <returns>Выбранный вид животного.</returns>
    private static IAnimal CreateAnimalFromUserInput()
    {
      IAnimal? animal = null;
      string animalName = string.Empty;

      while (animal == null)
      {
        Console.WriteLine(GetChooseAnimalMessage());
        var userInput = Console.ReadKey(true).Key;
        if (userInput == ConsoleKey.D0)
        {
          Console.WriteLine();
          Environment.Exit(1);
        }

        if (string.IsNullOrEmpty(animalName))
        {
          Console.Write("Назовите животное или оставьте имя пустым: ");
          animalName = Console.ReadLine() ?? DefaultAnimalName;
        }

        switch (userInput)
        {
          case ConsoleKey.D1:
            animal = new Desman(animalName);
            break;
          case ConsoleKey.D2:
            animal = new Fox(animalName);
            break;
          case ConsoleKey.D3:
            animal = new Mouse(animalName);
            break;
          case ConsoleKey.D4:
            animal = new Dolphin(animalName);
            break;
          default:
            Console.WriteLine("Неверный ввод. Пожалуйста повторите");
            animal = null;
            break;
        }
      }

      return animal;
    }

    /// <summary>
    /// Получить сообщение с выбором животного.
    /// </summary>
    /// <returns>Сообщение с выбором животного.</returns>
    private static string GetChooseAnimalMessage()
    {
      return "Какое животное создать?" +
       $"{Environment.NewLine}1. Выхухоль" +
       $"{Environment.NewLine}2. Лиса" +
       $"{Environment.NewLine}3. Мышь" +
       $"{Environment.NewLine}4. Дельфин" +
       $"{Environment.NewLine}{Environment.NewLine}0. Выход из приложения";
    }

    /// <summary>
    /// Показать возможности животного.
    /// </summary>
    private static void ShowAnimalAbilities()
    {
      Console.WriteLine("[1] Покормить. [2] Напоить. [3] Поиграть. [4] Уложить спать. [5] Голос! [S] Показать текущие потребности. [0] Выход из приложения");
    }

    /// <summary>
    /// Показать финальное сообщение игры.
    /// </summary>
    private static void ShowEnding()
    {
      Console.WriteLine("~~~~~~~~~~~~~~~До новых встреч~~~~~~~~~~~~~~~");
    }

    #endregion
  }
}
