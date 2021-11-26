using System;

namespace Tamagotchi.Animal
{
  /// <summary>
  /// Дельфин.
  /// </summary>
  public class Dolphin : AbstractAnimal
  {   
    public override void Speak()
    {
      base.Speak();
      Console.WriteLine("наркотики-ки-ки-ки-ки");
    }

    public Dolphin(string name) : base(name)
    {
    }
  }
}