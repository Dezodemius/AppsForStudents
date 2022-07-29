namespace Jukebox;

/// <summary>
/// Музыкальный проигрыватель.
/// </summary>
public class Jukebox
{
  /// <summary>
  /// Музыкальные пластинки проигрывателя.
  /// </summary>
  private readonly List<MusicPlate> plates;

  /// <summary>
  /// Добавить пластинку в проигрыватель.
  /// </summary>
  /// <param name="plate">Пластинка.</param>
  public void AddPlate(MusicPlate plate)
  {
    this.plates.Add(plate);
  }

  /// <summary>
  /// Получить пластинку.
  /// </summary>
  /// <param name="artist">Автор пластинки.</param>
  /// <param name="title">Название пластинки.</param>
  /// <returns>Музыкальная пластинка.</returns>
  public MusicPlate GetPlate(string artist, string title)
  {
    return this.plates.First(p => p.Artist == title && p.Title == title);
  }

  /// <summary>
  /// Получить все пластинки.
  /// </summary>
  /// <returns>Все пластинки.</returns>
  public List<MusicPlate> GetAllPlates()
  {
    return this.plates;
  }

  /// <summary>
  /// Убрать пластинку из проигрывателя.
  /// </summary>
  /// <param name="plate">Пластинка, которую необходимо убрать.</param>
  public void RemovePlate(MusicPlate plate)
  {
    this.plates.RemoveAll(p => p == plate);
  }

  /// <summary>
  /// Убрать пластинку из проигрывателя.
  /// </summary>
  /// <param name="artist">Автор пластинки.</param>
  /// <param name="title">Название пластинки.</param>
  /// <remarks>Убирает все пластинки с указанным называнием.</remarks>
  public void RemovePlate(string artist, string title)
  {
    this.plates.RemoveAll(p => p.Title == title);
  }

  /// <summary>
  /// Запустить пластинку.
  /// </summary>
  /// <param name="artist">Автор пластинки.</param>
  /// <param name="title">Название пластинки.</param>
  public void Play(string artist, string title)
  {
    var plate = this.GetPlate(artist, title);
    Console.WriteLine("Playing {0}...", plate.Title);
  }

  /// <summary>
  /// Остановить проигрывание.
  /// </summary>
  /// <param name="artist">Автор пластинки.</param>
  /// <param name="title">Название пластинки.</param>
  public void Stop(string artist, string title)
  {
    var plate = this.GetPlate(artist, title);
    Console.WriteLine("Stop playing {0}", plate.Title);
  }

  /// <summary>
  /// Конструктор.
  /// </summary>
  public Jukebox()
  {
    this.plates = new List<MusicPlate>();
  }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="plates">Музыкальные пластинки.</param>
  public Jukebox(List<MusicPlate> plates)
  {
    this.plates = plates;
  }
}