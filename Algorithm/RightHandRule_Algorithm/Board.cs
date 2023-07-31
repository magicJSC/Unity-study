using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] Tlie { get; private set; }
        public int Size { get; private set; }
        public int DestX { get; private set; }
        public int DestY { get; private set;}
        Player _player; 
        public enum TileType
        {
            Empty,
            Wall,
        }
        public void Initialize(int size,Player player)
        {
            if (size % 2 == 0)
            {
                return;
            }

            _player = player;
            Tlie = new TileType[size, size];
            Size = size;

            DestY = Size - 2;
            DestX = Size - 2;
            GenerateBySideWinder();


        }
        public void GenerateBySideWinder()
        {
            //길을 다 막는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tlie[y, x] = TileType.Wall;
                    }
                    else
                    {
                        Tlie[y, x] = TileType.Empty;
                    }
                }
            }

            //길을 뚫어 버리는 작업
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                int count = 0;
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;
                    if (y == Size - 2 && x == Size - 2)
                    {
                        continue;
                    }
                    if (y == Size - 2)
                    {
                        Tlie[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tlie[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    if (rand.Next(0, 2) == 0)
                    {
                        Tlie[y, x + 1] = TileType.Empty;
                        count++;
                        continue;
                    }
                    else
                    {
                        int randomindex = rand.Next(0, count);
                        Tlie[y + 1, x - randomindex * 2] = TileType.Empty;
                        count = 1;
                        continue;
                    }

                }
            }
        }
        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    //플레이어 X좌표를 갖고 와서,좌표와 현재 x,y가 일치하면 플레이어 색깔로 변경
                    if (_player.PosY == y && _player.PosX == x)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if(y == DestY && x == DestX)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    { Console.ForegroundColor = GetTileColor(Tlie[y, x]); }
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevColor;
        }
        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Wall:
                    return ConsoleColor.Red;
                case TileType.Empty:
                    return ConsoleColor.Green;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}
