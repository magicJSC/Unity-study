using System;

namespace Exercise
{
    class Graph  //그래프 생성
    {
        int[,] adj = new int[6, 6]
        {
            { 0,1,0,1,0,0},
            { 1,0,1,1,0,0},
            { 0,1,0,0,0,0},
            { 1,1,0,0,1,0},
            { 0,0,0,1,0,1},
            { 0,0,0,0,1,0},
        };
        List<int>[] adj2 = new List<int>[]
        {
            new List<int> {1,3},
            new List<int> {0,2,3},
            new List<int> {1},
            new List<int> {0,1,4},
            new List<int> {3,5},
            new List<int> {4},
        };

        bool[] visited = new bool[6]; 
        // 1) 우선 now부터 방문하고
        // 2) now와 연결된 정점들을 하나씩 확임해서,아직 미발견(미방문) 상태라면 방문한다.
        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; //1) now부터 방문

            for(int next =0; next < 6; next++)
            {
                if (adj[now,next] == 0) //연결되어 있지 않으면 스킵
                    continue;
                if (visited[next])      //이미 방문했으면 스킵
                    continue;
                DFS(next);
            }
        }


        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; //1) now부터 방문

            foreach(int next in adj2[now])
            {
                if (visited[next])      //이미 방문했으면 스킵
                    continue;
                DFS2(next);
            }
        }

        public void SearchAll()  //그래프를 돌다가 길이 끊어져서 접점을 다 가지 못했을때를 대비
        {
            visited = new bool[6];      //일단 다 false로 만든다
            for (int now =0; now < 6; now++)
            {
                if (visited[now] == false)      //길이 이어지면 한번에 true가 되어서 쓸데없는 반복을 막는다
                {
                    DFS(now);
                }
            }
        }
    }
    class Study
    {


        static void Main(string[] args)
        {
            //DFS (Depth First Search 깊이 우선 탐색)
            //BFS (Breadth First Search 너비 우선 탐색)
            
            Graph graph = new Graph();
            graph.DFS2(1);
            

        }
    }
}