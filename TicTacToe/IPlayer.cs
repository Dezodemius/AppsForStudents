using System.Collections.Generic;

namespace TicTacToe
{
  public interface IPlayer
  {
    PlayerSymbol PlayerSymbol { get; }

    void MakeMove(IReadOnlyList<string> playingBoard);
  }
}