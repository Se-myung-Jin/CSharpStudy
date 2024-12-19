namespace CSharpStudy
{
    public partial class Graph
    {
        private static int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0 }
        };
        
        private static bool[] visited = new bool[6];
        public static void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0)//연결된 정점이라면 스킵
                    continue;
                if (visited[next])//이미 방문한 곳이라면 스킵
                    continue;

                DFS(next);
            }
        }
    }
}