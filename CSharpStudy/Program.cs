namespace CSharpStudy
{
    class Program
    {
        static volatile int num = 0;
        static RecursiveRWLock rwLock = new RecursiveRWLock();

        static void Main(string[] args)
        {
            Task task1 = new Task(Task1);
            Task task2 = new Task(Task2);

            task1.Start();
            task2.Start();

            Task.WaitAll(task1, task2);

            Console.WriteLine($"num : {num}");
        }

        static void Task1()
        {
            for (int i = 0; i < 1000000; i++)
            {
                rwLock.WriteLock();
                num++;
                rwLock.WriteUnlock();
            }
        }

        static void Task2()
        {
            for (int j = 0; j < 1000000; j++)
            {
                rwLock.WriteLock();
                num--;
                rwLock.WriteUnlock();
            }
        }
    }
}
