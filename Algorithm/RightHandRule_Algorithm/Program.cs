using System;
using TextRPG;

namespace Algorithm
{
    class Program
    {
        static void Main()
        {
            int lastTick = 0;
            Console.CursorVisible = false;
            const int WAIT_TICK = 1000 / 30;

            Player player = new Player();
            Board board = new Board();
            board.Initialize(25,player);
            player.Initialize(1, 1,board);
            while (true)
            {
                #region
                int currentTick = System.Environment.TickCount;
                int elapsedTick = currentTick - lastTick;           //경과 시간
                if(elapsedTick < WAIT_TICK)                         //만약 경과 시간이 1/30초보다 작다면
                {
                    continue;
                }
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion
                //입력
                //로직
                player.Update(deltaTick);

                //렌더링
                Console.SetCursorPosition(0,0);
                board.Render();
            }
            
        }
        
    }
}
