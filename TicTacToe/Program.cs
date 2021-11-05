using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
  /// <summary>
  /// Главный класс программы.
  /// </summary>
  public static class Program
  {
    #region Константы

    /// <summary>
    /// Символ пустой клетки.
    /// </summary>
    private const string EmptyCell = " ";

    /// <summary>
    /// Символ "нолика".
    /// </summary>
    private const string Noughts = "O";

    /// <summary>
    /// Символ "крестика".
    /// </summary>
    private const string Crosses = "X";

    #endregion

    #region Поля

    /// <summary>
    /// Пустая доска для игры.
    /// </summary>
    private static readonly string[] defaultBoard = 
        { EmptyCell, EmptyCell, EmptyCell, EmptyCell, EmptyCell, EmptyCell, EmptyCell, EmptyCell, EmptyCell};

    /// <summary>
    /// Все победные комбинации.
    /// </summary>
    private static readonly List<int[]> allWinningCombinations = new List<int[]>
    {
        new []{0, 1, 2},
        new []{3, 4, 5},
        new []{6, 7, 8},
        new []{0, 3, 6},
        new []{1, 4, 7},
        new []{2, 5, 8},
        new []{0, 4, 8},
        new []{2, 4, 6}
    };

    #endregion

    #region Методы

    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    public static void Main(string[] args)
    {
      Console.Title = "Крестики-нолики епта";
      StartTicTacToe();
      Console.ReadKey();
    }

    /// <summary>
    /// Запустить игру.
    /// </summary>
    private static void StartTicTacToe()
    {
      Console.Write("\nХотите сыграть против другого игрока? [y/n] ");
      var choose = Console.ReadKey();

      var isPlayingWithHuman = choose.Key == ConsoleKey.Y;
      if (isPlayingWithHuman)
        PlayWithHuman();
      else
        PlayWithCPU();
    }

    /// <summary>
    /// Игра против человека.
    /// </summary>
    private static void PlayWithHuman()
    {
      while (true)
      {
        var currentBoard = defaultBoard;
        var winningCombination = Array.Empty<int>();
        ShowBoard(currentBoard);
        MakeMove(currentBoard, Crosses);
        if (CheckWin(currentBoard, Crosses, out winningCombination))
        {
          ShowWinningCombinationOnBoard(currentBoard, winningCombination);
          Console.WriteLine($"\nПобеда '{Crosses}'");
          break;
        }

        ShowBoard(currentBoard);
        MakeMove(currentBoard, Noughts);
        if (CheckWin(currentBoard, Noughts, out winningCombination))
        {
          ShowWinningCombinationOnBoard(currentBoard, winningCombination);
          Console.WriteLine($"\nПобеда '{Noughts}'");
          break;
        }

        if (currentBoard.All(i => i != EmptyCell))
        {
          Console.WriteLine("Ничья!");
          break;
        }
      }
    }

    /// <summary>
    /// Проверить наличие победы.
    /// </summary>
    /// <param name="board">Доска для игры.</param>
    /// <param name="player">Символ игрока чей ход.</param>
    /// <param name="winningCombination">Победная комбинация.</param>
    /// <returns><c>True</c>, если ход привёл к победе.</returns>
    private static bool CheckWin(IReadOnlyList<string> board, string player, out int[] winningCombination)
    {
      winningCombination = Array.Empty<int>();
      foreach (var combination in allWinningCombinations)
      {
        if (IsWinningCombination(board, combination, player))
        {
          winningCombination = combination;
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Проверить, что текущее сочитание комбинаций является победным.
    /// </summary>
    /// <param name="board">Доска для игры.</param>
    /// <param name="winningCombination">Победная комбинация.</param>
    /// <param name="winningSign">Символ, который должен привести к победе.</param>
    /// <returns><c>True</c>, если текущая комбинация является победной.</returns>
    private static bool IsWinningCombination(IReadOnlyList<string> board, int[] winningCombination, string winningSign)
    {
      foreach (var combinationElement in winningCombination)
      {
        if (board[combinationElement] == winningSign)
          continue;
        return false;
      }

      return true;
    }

    /// <summary>
    /// Сделать ход.
    /// </summary>
    /// <param name="board">Доска.</param>
    /// <param name="playerSign">Символ игрока.</param>
    private static void MakeMove(string[] board, string playerSign)
    {
      var isMoveCorrect = false;
      while (!isMoveCorrect)
      {
        Console.Write($"\nХод {playerSign}: ");
        var move = Console.ReadKey().KeyChar.ToString();
        if (int.TryParse(move, out var i) && 
            i > 0 && 
            board[i - 1] == " ")
        {
          board[i - 1] = playerSign;
          isMoveCorrect = true;
        }
        else
        {
          Console.WriteLine("Неверный ход!");
        }
      }
    }

    /// <summary>
    /// Играть против компьютера.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private static void PlayWithCPU()
    {
      Console.Write("\nКомпуктер будет ходить первым? [y] ");
      var choose = Console.ReadKey();
      bool cpuFirst = choose.Key == ConsoleKey.Y;

      while (true)
      {
        var currentBoard = defaultBoard;
        var winningCombination = Array.Empty<int>();

        string currentMoveSymbol;
        if (cpuFirst)
        {
          currentMoveSymbol = Crosses;
          MakeCPUMove(currentBoard, currentMoveSymbol);
        }
        else
        {
          ShowBoard(currentBoard);
          currentMoveSymbol = Crosses;
          MakeMove(currentBoard, currentMoveSymbol);
        }
        if (CheckWin(currentBoard, currentMoveSymbol, out winningCombination))
        {
          ShowWinningCombinationOnBoard(currentBoard, winningCombination);
          Console.WriteLine($"\nПобеда '{currentMoveSymbol}'");
          break;
        }

        if (currentBoard.All(i => i != EmptyCell))
        {
          Console.WriteLine("Ничья!");
          break;
        }

        if (cpuFirst)
        {
          ShowBoard(currentBoard);
          currentMoveSymbol = Noughts;
          MakeMove(currentBoard, currentMoveSymbol);
        }
        else
        {
          currentMoveSymbol = Noughts;
          MakeCPUMove(currentBoard, currentMoveSymbol);
        }
        if (CheckWin(currentBoard, currentMoveSymbol, out winningCombination))
        {
          ShowWinningCombinationOnBoard(currentBoard, winningCombination);
          Console.WriteLine($"\nПобеда '{currentMoveSymbol}'");
          break;
        }

        if (currentBoard.All(i => i != EmptyCell))
        {
          Console.WriteLine("Ничья!");
          break;
        }
      }
    }

    /// <summary>
    /// Сделать ход компьютера.
    /// </summary>
    /// <param name="board">Доска для игры.</param>
    /// <param name="symbol">Символ компьютера.</param>
    private static void MakeCPUMove(string[] board, string symbol)
    {
      var rand = new Random();
      List<int> availableMoves = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 }
        .Where(i => board[i] == EmptyCell)
        .ToList();
      availableMoves = availableMoves
        .OrderBy(i => rand.Next(availableMoves.Count))
        .ToList();
      foreach (var move in availableMoves)
      {
        var boardCopy = new List<string>(board)
        {
            [move] = symbol
        };
        if (CheckWin(boardCopy, symbol, out _))
        {
          board[move] = symbol;
          return;
        }
      }

      var randomMove = availableMoves[rand.Next(availableMoves.Count)];
      board[randomMove] = symbol;
    }
    
    /// <summary>
    /// Показать доску.
    /// </summary>
    /// <param name="board">Доска.</param>
    private static void ShowBoard(string[] board)
    {
      Console.WriteLine();
      Console.WriteLine("-------------");
      for (var i = 1; i <= board.Length; i++)
      {
        if (board[i - 1] == EmptyCell)
          Console.Write($"| {i} ");
        else
        {
          var defaultColor = Console.BackgroundColor;
          Console.Write("| ");
          Console.BackgroundColor = board[i -1] == Crosses ? ConsoleColor.DarkBlue : ConsoleColor.Red;
          Console.Write($"{board[i - 1]}");
          Console.BackgroundColor = defaultColor;
          Console.Write(" ");
        }
        if (i % Math.Sqrt(board.Length) == 0)
        {
          Console.WriteLine("|");
          Console.WriteLine("-------------");
        }
      }
    }

    /// <summary>
    /// Показать доску с расрашенной победной комбинацией.
    /// </summary>
    /// <param name="board">Доска для игры.</param>
    /// <param name="winningCombination">Победная комбинация.</param>
    private static void ShowWinningCombinationOnBoard(IReadOnlyList<string> board, int[] winningCombination)
    {
      Console.WriteLine();
      Console.WriteLine("-------------");
      for (var i = 1; i <= board.Count; i++)
      {
        if (board[i - 1] == EmptyCell)
          Console.Write($"| {i} ");
        else
        {
          var defaultBackgroundColor = Console.BackgroundColor;
          var cellBackgroundColor = defaultBackgroundColor;
          if (winningCombination.Contains(i - 1))
            cellBackgroundColor = ConsoleColor.DarkYellow;
          else
            cellBackgroundColor = board[i - 1] switch
            {
                Crosses => ConsoleColor.DarkBlue,
                Noughts => ConsoleColor.Red,
                _ => defaultBackgroundColor
            };

          Console.Write("| ");
          Console.BackgroundColor = cellBackgroundColor;
          Console.Write($"{board[i - 1]}");
          Console.BackgroundColor = defaultBackgroundColor;
          Console.Write(" ");
        }
        
        if (i % Math.Sqrt(board.Count) == 0)
        {
          Console.WriteLine("|");
          Console.WriteLine("-------------");
        }
      }
    }
    
    #endregion
  }
}