namespace Jukebox;

/// <summary>
/// Музыкальная пластинка.
/// </summary>
public class MusicPlate
{
  /// <summary>
  /// Исполнитель.
  /// </summary>
  public string Artist { get; }

  /// <summary>
  /// Название.
  /// </summary>
  public string Title { get; }

  /// <summary>
  /// Год выпуска.
  /// </summary>
  public int Year { get; }

  /// <summary>
  /// Жанр.
  /// </summary>
  public string Genre { get; }

  /// <summary>
  /// Звуковая дорожка пластинки.
  /// </summary>
  public string Soundtrack { get; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="artist">Исполнитель.</param>
  /// <param name="title">Название.</param>
  /// <param name="year">Год выпуска.</param>
  /// <param name="genre">Жанр.</param>
  /// <param name="soundtrack">Звуковая дорожка пластинки.</param>
  public MusicPlate(string artist, string title, int year, string genre, string soundtrack)
  {
    this.Artist = artist;
    this.Title = title;
    this.Year = year;
    this.Genre = genre;
    this.Soundtrack = soundtrack;
  }
}