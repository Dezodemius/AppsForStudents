namespace Jukebox;

public static class Program
{
  public static void Main(string[] args)
  {
    var defaultPlates = new List<MusicPlate>
    {
      new MusicPlate("Slipknot", "People = Shit", 2001, "NU-metal", string.Empty),
      new MusicPlate("Beatles", "Yellow Submarine", 1966, "pop", string.Empty),
      new MusicPlate("Rammstein", "Zick Zack", 2022, "Indastrial-metal", string.Empty),
      new MusicPlate("Queen", "Bohemian Rhapsody", 1975, "Progressive Rock", string.Empty),
      new MusicPlate("Eisbrecher ", "Was ist hier los?", 2017, "Indastrial-metal", string.Empty),
    };

    var jukebox = new Jukebox(defaultPlates);
    jukebox.Play("Slipknot", "People = Shit");
    jukebox.Stop("Slipknot", "People = Shit");

    var darmnbassSong = new MusicPlate("B-Complex", "Beautiful Lies", 2010, "Drum'n'Bass", string.Empty);
    jukebox.AddPlate(darmnbassSong);
  }
}