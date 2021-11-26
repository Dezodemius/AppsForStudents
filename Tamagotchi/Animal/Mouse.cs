using System;

namespace Tamagotchi.Animal
{
  /// <summary>
  /// Мышь.
  /// </summary>
  public class Mouse : AbstractAnimal
  {   
    public override void Speak()
    {
      base.Speak();
      Console.WriteLine("пи-пи-пидор");
    }

    public Mouse(string name) : base(name)
    {
    }
  }
}