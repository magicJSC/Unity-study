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
        public TileType[,] _tile;
        public int _size;

        public enum TileType
        {
            Empty,
            Wall,
        }
        public void Initialize(int size)
        {
            if(size % 2 == 0)
            {
                return;
            }
            _tile = new TileType[size, size];
            _size = size;

            GenerateBySideWinder();

            
        }
        public void GenerateBySideWinder()
        {
            //길을 다 막는 작업
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        _tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        _tile[y, x] = TileType.Empty;
                    }
                }
            }

            //길을 뚫어 버리는 작업
            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                int count = 0;
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;
                    if (y == _size - 2 && x == _size -2)
                    {
                        continue;
                    }
                    if ( y == _size -2)
                    {
                        _tile[y, x+1] = TileType.Empty;
                        continue;
                    }
                    if(x == _size -2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    if (rand.Next(0, 2) == 0)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        count++;
                        continue;
                    }
                    else
                    {
                        int randomindex = rand.Next(0, count);
                        _tile[y + 1, x - randomindex * 2] = TileType.Empty;
                        count = 1;
                        continue;
                    }
                    
                }
            }
        }
        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    Console.ForegroundColor = GetTileColor(_tile[y,x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor= prevColor;
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
