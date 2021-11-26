using System;

namespace Tamagotchi.Animal
{
  /// <summary>
  /// Лис.
  /// </summary>
  public class Fox : AbstractAnimal
  {    
    public override void Speak()
    {
      base.Speak();
      Console.WriteLine("фыр-фыр");
    }

    public Fox(string name) : base(name)
    {
    }
  }
}