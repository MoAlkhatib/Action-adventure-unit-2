using System;
using System.IO;
namespace MazeGame
{
  class MazeGame
  {
    static int Game_width;
    static int Game_height;
    static char[,] _Game_map;
    static int playerOne;
    static int playerTwo;
    static void GameMap()
    {
      Console.Clear();
      for (int j = 0; j < Game_height; j++)
      {
        for (int z = 0; z < Game_width; z++)
        {
          if (z == playerOne && j == playerTwo)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('☺');
            continue;
          }
          char signs = _Game_map[z, j];

          if (signs == 'G')
          {
            Console.ForegroundColor = ConsoleColor.Blue;
          }
          else if (signs == '♠')
          {
            Console.ForegroundColor = ConsoleColor.Blue;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Gray;
          }

          Console.Write(signs);
        }
        Console.WriteLine();
      }
    }

    static void Main(string[] args)
    {
      string[] data = File.ReadAllLines("Maze.txt");
      string leveltitle = data[0];
      string[] Dfont = data[1].Split('x');
      Game_width = int.Parse(Dfont[0]);
      Game_height = int.Parse(Dfont[1]);
      _Game_map = new char[Game_width, Game_height];
      var randomNumber = new Random();
      for (int Z = 0; Z < Game_height; Z++)
      {
        string stringLine = data[Z + 2];
        for (int x = 0; x < Game_width; x++)
        {
          char Sign = stringLine[x];
          if (Sign == 'S')
          {
            playerOne = x;
            playerTwo = Z;
            _Game_map[x, Z] = ' ';
            continue;
          }
          if (Z < 3 && randomNumber.Next((Z + 1) * 2) == 0)
          {
            Sign = '♠';
          }
          _Game_map[x, Z] = Sign;
        }
      }
      Console.WriteLine($"Get ready for: {leveltitle}");
      Console.WriteLine();
      Console.WriteLine("To Start Game Press anykey .........");
      Console.ReadKey();
      while (true)
      {
        GameMap();
        if (_Game_map[playerOne, playerTwo] == 'M')
        {
          Console.WriteLine();
          Console.WriteLine("You reached to the Goal. You are winner!");
          return;
        }
        ConsoleKeyInfo data_key = Console.ReadKey();
        int newPone = playerOne;
        int newPtwo = playerTwo;
        if (data_key.Key == ConsoleKey.DownArrow)
        {
          newPtwo++;
        }
        else if (data_key.Key == ConsoleKey.UpArrow)
        {
          newPtwo--;
        }
        else if (data_key.Key == ConsoleKey.RightArrow)
        {
          newPone++;
        }
        else if (data_key.Key == ConsoleKey.LeftArrow)
        {
          newPone--;
        }
        else if (data_key.Key == ConsoleKey.Escape)
        {
          return;
        }
        char newLocation = _Game_map[newPone, newPtwo];
        if (newLocation == ' ' || newLocation == 'M')
        {
          playerOne = newPone;
          playerTwo = newPtwo;
        }
      }
    }

    //
  }
}