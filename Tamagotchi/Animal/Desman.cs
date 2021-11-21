using System;

namespace Tamagotchi.Animal
{
  /// <summary>
  /// Выхухоль.
  /// </summary>
  public class Desman : AbstractAnimal
  {
    public override void Speak()
    {
      base.Speak();
      Console.WriteLine("<звуки выхухоли>");
    }

    public Desman(string name) : base(name)
    {
    }
  }
}