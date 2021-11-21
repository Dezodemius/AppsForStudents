using System.Collections.Generic;

namespace TicTacToe
{
  public class Human : IPlayer
  {
    #region IPlayer

    public PlayerSymbol PlayerSymbol { get; }

    public void MakeMove(IReadOnlyList<string> playingBoard)
    {
      throw new System.NotImplementedException();
    }

    #endregion

    #region Конструкторы

    public Human(PlayerSymbol playerSymbol)
    {
      this.PlayerSymbol = playerSymbol;
    }

    #endregion
  }
}