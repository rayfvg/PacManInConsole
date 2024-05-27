using System;
using System.IO;

namespace PacMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int PosX = 4;
            int PosY = 3;
            int CountScore = 0;

            char[,] map = CreateMap("map.txt");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                DrowMap(map);
                Console.CursorVisible = false;
                Console.SetCursorPosition(PosX, PosY);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("@");
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Score   " + CountScore);
                ConsoleKeyInfo currentKey = Console.ReadKey();

                HandleInput(currentKey, ref PosX, ref PosY, map, ref CountScore);

            }

        }
        private static char[,] CreateMap(string path)
        {
            string[] file = File.ReadAllLines("map.txt");

            char[,] map = new char[file[0].Length, file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[y][x];
                }
            }

            return map;
        }

        private static void DrowMap(char[,] map)
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }

        private static void HandleInput(ConsoleKeyInfo currentKey, ref int PosX, ref int PosY, char[,] map, ref int CountScore)
        {

            int[] direction = Direction(currentKey);

            int PacManPositionX = PosX + direction[0];
            int PacManPositionY = PosY + direction[1];

            char NextCell = map[PacManPositionX, PacManPositionY];

            if (NextCell == ' ' || NextCell == '.')
            {
                PosX = PacManPositionX;
                PosY = PacManPositionY;
                if (NextCell == '.')
                {
                    CountScore++;
                    map[PacManPositionX, PacManPositionY] = ' ';
                }
            }
              

        }
        private static int[] Direction(ConsoleKeyInfo currentKey)
        {
            int[] direction = { 0, 0 };
            if (currentKey.Key == ConsoleKey.UpArrow)
                direction[1] = -1;
            else if (currentKey.Key == ConsoleKey.DownArrow)
                direction[1] = 1;
            else if (currentKey.Key == ConsoleKey.RightArrow)
                direction[0] = 1;
            else if (currentKey.Key == ConsoleKey.LeftArrow)
                direction[0] = -1;
            return direction;
        }
    }
}
