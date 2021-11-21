using System;
using System.Threading;

namespace Tamagotchi.Animal
{
  /// <summary>
  /// Абстрактное животное.
  /// </summary>
  public class AbstractAnimal : IAnimal
  {
    #region Константы

    /// <summary>
    /// Время, через которое начнётся голод.
    /// </summary>
    private const int StartStarvingPeriod = 1000 * 60 * 4;

    /// <summary>
    /// Время, через которое начнётся жажда.
    /// </summary>
    private const int StartFeelingThirstyPeriod = 1000 * 60 * 3;

    /// <summary>
    /// Время, через которое начнётся сонливость.
    /// </summary>
    private const int StartWantToSleepPeriod = 1000 * 60 * 8;

    /// <summary>
    /// Время, через которое начнётся скука.
    /// </summary>
    private const int StartBoringPeriod = 1000 * 60 * 12;

    /// <summary>
    /// Время, через которое случится смерть от голода.
    /// </summary>
    private const int DeathFromHungryPeriod = StartStarvingPeriod;

    /// <summary>
    /// Время, через которое случится смерть от жажды.
    /// </summary>
    private const int DeathFromThirstyPeriod = StartFeelingThirstyPeriod;

    /// <summary>
    /// Время, через которое случится смерть от бессонницы.
    /// </summary>
    private const int DeathFromInsomniaPeriod = StartWantToSleepPeriod;

    /// <summary>
    /// Время, через которое случится смерть от скуки.
    /// </summary>
    private const int DeathFromBoringPeriod = StartBoringPeriod;

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Дата рождения.
    /// </summary>
    private readonly DateTime birthDay;

    #region Таймеры

    /// <summary>
    /// Обратный отсчёт для начала голода.
    /// </summary>
    private readonly Timer startStarvingTimer;

    /// <summary>
    /// Обратный отсчёт для начала испытывания жажды.
    /// </summary>
    private readonly Timer startFeelingThirstyTimer;

    /// <summary>
    /// Обратный отсчёт, чтобы начать хотеть спать.
    /// </summary>
    private readonly Timer startWantToSleepTimer;

    /// <summary>
    /// Обратный отсчёт для начала страданий от скуки.
    /// </summary>
    private readonly Timer startBoringTimer;

    /// <summary>
    /// Обратный отсчёт до смерти.
    /// </summary>
    private readonly Timer startDyingTimer;

    #endregion

    #region Признаки состояний животного

    /// <summary>
    /// Признак голода.
    /// </summary>
    private bool isStarving;

    /// <summary>
    /// Признак жажды.
    /// </summary>
    private bool isFeelsThirsty;

    /// <summary>
    /// Признак желания поспать.
    /// </summary>
    private bool isWantToSleep;

    /// <summary>
    /// Признак скуки.
    /// </summary>
    private bool isBoring;

    #endregion

    #endregion

    #region IAnimal

    public event Action Death;

    public string Name { get; }
    public double Age { get; set; }

    public void Eat()
    {
      if (this.isStarving)
      {
        this.startDyingTimer.Change(Timeout.Infinite, Timeout.Infinite);
        this.startStarvingTimer.Change(StartStarvingPeriod, Timeout.Infinite);
        this.isStarving = false;

        Console.WriteLine($"{this.Name} поел.");
      }
      else
      {
        Console.WriteLine($"{this.Name} не хочет есть!");
      }
    }

    public void Drink()
    {
      if (this.isFeelsThirsty)
      {
        this.startDyingTimer.Change(Timeout.Infinite, Timeout.Infinite);
        this.startFeelingThirstyTimer.Change(StartFeelingThirstyPeriod, Timeout.Infinite);
        this.isFeelsThirsty = false;

        Console.WriteLine($"{this.Name} попил.");
      }
      else
      {
        Console.WriteLine($"{this.Name} не хочет пить!");
      }
    }

    public void Sleep()
    {
      if (this.isWantToSleep)
      {
        this.startDyingTimer.Change(Timeout.Infinite, Timeout.Infinite);
        this.startWantToSleepTimer.Change(StartWantToSleepPeriod, Timeout.Infinite);
        this.isWantToSleep = false;

        Console.WriteLine($"{this.Name} спит.");
      }
      else
      {
        Console.WriteLine($"{this.Name} не хочет спать!");
      }
    }

    public void Play()
    {
      if (this.isBoring)
      {
        this.startDyingTimer.Change(Timeout.Infinite, Timeout.Infinite);
        this.startBoringTimer.Change(StartBoringPeriod, Timeout.Infinite);
        this.isBoring = false;

        Console.WriteLine($"{this.Name} поиграл.");
      }
      else
      {
        Console.WriteLine($"{this.Name} не хочет играть!");
      }
    }

    public virtual void Speak()
    {
      Console.Write($"{this.Name}: ");
    }

    public string GetStatus()
    {
      var statusMessage = string.Empty;
      if (this.isStarving)
        statusMessage += "Голод.";
      if (this.isFeelsThirsty)
        statusMessage += "Жажда.";
      if (this.isWantToSleep)
        statusMessage += "Сонливость.";
      if (this.isBoring)
        statusMessage += "Скука.";
      return string.IsNullOrEmpty(statusMessage) ? "Всё хорошо" : statusMessage;
    }

    #endregion

    
    #region IDisposable

    public void Dispose()
    {
      startStarvingTimer.Dispose();
      startFeelingThirstyTimer.Dispose();
      startWantToSleepTimer.Dispose();
      startBoringTimer.Dispose();
      startDyingTimer.Dispose();
    }

    #endregion

    #region Обработчики

    private void OnDeath()
    {
      this.Death?.Invoke();
    }
    private void OnStartStarving(object? state)
    {
      Console.WriteLine($">> {this.Name} хочет есть");
      this.isStarving = true;
      this.startDyingTimer.Change(DeathFromHungryPeriod, Timeout.Infinite);
    }  

    private void OnStartFeelingThirsty(object? state)
    {
      Console.WriteLine($">> {this.Name} хочет пить");
      this.isFeelsThirsty = true;
      this.startDyingTimer.Change(DeathFromThirstyPeriod, Timeout.Infinite);
    }

    private void OnStartWantToSleep(object? state)
    {
      Console.WriteLine($">> {this.Name} хочет спать");
      this.isWantToSleep = true;
      this.startDyingTimer.Change(DeathFromInsomniaPeriod, Timeout.Infinite);
    }

    private void OnStartBoring(object? state)
    {
      Console.WriteLine($">> {this.Name} хочет играть");
      this.isBoring = true;
      this.startDyingTimer.Change(DeathFromBoringPeriod, Timeout.Infinite);
    }

    private void OnKillAnimal(object? state)
    {
      this.startStarvingTimer.Change(Timeout.Infinite, Timeout.Infinite);
      this.startBoringTimer.Change(Timeout.Infinite, Timeout.Infinite);
      this.startFeelingThirstyTimer.Change(Timeout.Infinite, Timeout.Infinite);
      this.startWantToSleepTimer.Change(Timeout.Infinite, Timeout.Infinite);

      Console.WriteLine($"RIP {this.Name}. {this.birthDay} - {DateTime.Now - this.birthDay}");
      this.OnDeath();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя животного.</param>
    public AbstractAnimal(string name)
    {
      this.Name = name;
      this.Age = 0;

      this.birthDay = DateTime.Now;

      this.startStarvingTimer = 
        new Timer(this.OnStartStarving, null, StartStarvingPeriod, Timeout.Infinite);
      this.startFeelingThirstyTimer = 
        new Timer(this.OnStartFeelingThirsty, null, StartFeelingThirstyPeriod, Timeout.Infinite);
      this.startWantToSleepTimer = 
        new Timer(this.OnStartWantToSleep, null, StartWantToSleepPeriod, Timeout.Infinite);
      this.startBoringTimer = 
        new Timer(this.OnStartBoring, null, StartBoringPeriod, Timeout.Infinite);

      this.startDyingTimer = new Timer(this.OnKillAnimal, null, Timeout.Infinite, Timeout.Infinite);
    }

    #endregion
  }
}