namespace TicTacToe
{
  public interface IPlayingStrategy
  {
    IPlayer FirstPlayer { get; set; }
    
    IPlayer SecondPlayer { get; set; }

    void Play();
  }
}