using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Pos
    {
        public Pos(int y, int x) { Y = y; X = x; }
        public int Y;
        public int X;
    }
    class Player
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        Board _board;

        enum DIr
        {
            Up = 0,
            Left = 1,
            Down = 2,
            Right = 3,
        }

        int _dir = (int)DIr.Up;
        List<Pos> _point = new List<Pos>();
        public void Initialize(int PosY, int PosX, Board board)
        {
            this.PosX = PosX;
            this.PosY = PosY;

            _board = board;

            Astar();
        }

        struct PQNode : IComparable<PQNode>
        {
            public int F;
            public int G;
            public int Y;
            public int X;

            public int CompareTo(PQNode other)
            {
                if (F == other.F)
                    return 0;
                return F < other.F ? 1 : -1;
            }
        }

        void Astar()
        {
            //U L D R UL DL DR UR
            int[] deltaY = new int[] { -1, 0, 1, 0 ,-1 ,1,1,-1};
            int[] deltaX = new int[] { 0, -1, 0, 1 ,-1,-1,1,1};
            int[] cost = new int[] { 10, 10, 10, 10,14,14,14,14 };

            //점수 매기기 
            //F = G + H
            //G = 시작점에서 해단 좌표까지 이동하는데에 드는 비용(적을 수록 좋음,경로에 따라 다름)
            //H = 목적지에서 얼마나 가까운지(작을 수록 좋음,

            //(y,x)이미 방문했는지 여부(방문 = closed 상태)
            bool[,] closed = new bool[_board.Size,_board.Size];

            //(y,x) 가는 길을 한번이라도 발견했는지
            //발견X => MaxValue
            //발견O => F = G + H
            int[,] open = new int[_board.Size,_board.Size]; //OpenList
            for(int y =0; y < _board.Size; y++)
            {
                for(int x =0; x < _board.Size; x++)
                {
                    open[y, x] = Int32.MaxValue;
                }
            }

            Pos[,] parent = new Pos[_board.Size, _board.Size];
            //오픈리스트에 있는 정보들 중에서, 가장 좋은 정보를 빠르게 뽑아오기 위한 도구
            PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>();

            //시작점 발견 (예약 진행)
            open[PosY, PosX] = 10*Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX);
            pq.Push(new PQNode() { F= 10*Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX), G=0,Y=PosY,X=PosX});
            parent[PosY, PosX] = new Pos(PosY, PosX);

            while(pq.Count > 0)
            {
                //제일 좋은 후보를 찾는다
                PQNode node = pq.Pop();

                //동일한 좌표를 여러 경로로 찾아서,더 빠른 경로로 인해서 이미 방문(closed)된 경우로 스킵
                if (closed[node.Y, node.X])
                    continue;

                //방문한다
                closed[node.Y,node.X] = true;
                if (node.Y == _board.DestY && node.X == _board.DestX)
                    break;

                //상하좌우로 이동할 수 있는 좌표인지 확인해서 예약(open)한다
                for(int i=0; i < deltaY.Length; i++)
                {
                    int nextY = node.Y + deltaY[i];
                    int nextX = node.X + deltaX[i];

                    if (nextX < 0 || nextX >= _board.Size || nextY < 0 || nextY >= _board.Size)
                        continue;
                    if (_board.Tile[nextY, nextX] == Board.TileType.Wall)
                        continue;
                    if (closed[nextY, nextX])
                        continue;

                    int g = node.G + cost[i];
                    int h = 10 * Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX);
                    //다른 경로에서 더 빠른 길이 이미 있으면 스킵
                    if (open[nextY, nextX] < g + h)
                        continue;

                    // 예약 진행
                    open[nextY, nextX] = g + h;
                    pq.Push(new PQNode() { F = g + h, G = g, Y = nextY, X = nextX });
                    parent[nextY, nextX] = new Pos(node.Y, node.X);
                }
            }
            CalcPathFormParent(parent);
        }

        void CalcPathFormParent(Pos[,] parent)
        {
            int y = _board.DestY;
            int x = _board.DestX;

            //최단 경로를 만들어준다
            while (parent[y, x].Y != y || parent[y, x].X != x)
            {
                _point.Add(new Pos(y, x));
                Pos pos = parent[y, x];
                y = pos.Y;
                x = pos.X;
            }
            _point.Add(new Pos(y, x));
            _point.Reverse();
        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;
        int _lastindex = 0;
        public void Update(int deltaTick)   //deltatick으로 텀
        {
            if (_lastindex >= _point.Count)
            {
                return;
            }
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
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
