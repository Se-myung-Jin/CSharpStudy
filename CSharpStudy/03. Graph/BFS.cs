namespace CSharpStudy
{
    public partial class Graph
    {
        public static void BFS(int start)
        {
            bool[] found = new bool[6];

            Queue<int> q = new Queue<int> ();
            q.Enqueue (start);
            found[start] = true;

            while(q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine(now);

                for (int next = 0; (next < 6); next++)
                {
                    if (adj[now, next] == 0) // 연결되지 않았으면 스킵
                        continue;
                    if (found[next]) // 이미 발견한 애라면 스킵
                        continue;
                    q.Enqueue (next);
                    found[next] = true; 
                }
            }
        }
    }
}