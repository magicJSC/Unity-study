using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Pos
    {
        public Pos(int y,int x) { Y = y; X = x;  }
        public int Y;
        public int X;
    }
    class Player
    {
        public int PosX { get;private set; }
        public int PosY { get;private set; }
        Board _board;

        enum DIr
        {
            Up =0,
            Left = 1,
            Down = 2,
            Right=3,
        }

        int _dir = (int)DIr.Up;
        List<Pos> _point = new List<Pos>();
        public void Initialize(int PosY,int PosX,Board board)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            
            _board = board;

            //현재 바라보고 있는 기준으로,좌표 변화를 나타낸다
            int[] frontY = new int[] { -1,0,1,0 };
            int[] frontX = new int[] { 0,-1,0,1 };
            int[] rightY = new int[] {0,-1,0,1 };
            int[] rightX = new int[] {1,0,-1,0 };

            _point.Add(new Pos(PosY,PosX));
            //목적지 도착전에 실행
            while(PosX != board.DestX || PosY != board.DestY)
            {
                //현재 바라보는 방향에서 오른쪽으로 갈수있는지 확인
                if(board.Tlie[PosY + rightY[_dir], PosX + rightX[_dir]] == Board.TileType.Empty)
                {
                    //오른쪽 90도 회전
                    _dir = (_dir + 3) % 4;

                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];
                    _point.Add(new Pos(PosY, PosX));
                }
                //전진할 수 있는지 확인
                else if (board.Tlie[PosY + frontY[_dir], PosX + frontX[_dir]] == Board.TileType.Empty)
                {
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];
                    _point.Add(new Pos(PosY, PosX));
                }
                //왼쪽으로 방향 전환
                else
                {
                    _dir = (_dir + 5) % 4;
                }
            }
        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;
        int _lastindex = 0;
        public void Update(int deltaTick)   //deltatick으로 텀
        {
            if(_lastindex >= _point.Count)
            {
                return;
            }
            _sumTick += deltaTick;
            if( _sumTick >= MOVE_TICK )
            {
                _sumTick = 0;

                //0.1초마다 실행할 로직 넣어주기
                PosY = _point[_lastindex].Y;
                PosX = _point[_lastindex].X;
                _lastindex++;
            }
        }
    }
}
