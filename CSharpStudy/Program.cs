namespace CSharpStudy
{
    class Program
    {
        static int num = 0;
        static SpinLock spinLock = new SpinLock();

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
            for (int i = 0; i < 100000; i++)
            {
                spinLock.AcquireV2();
                num++;
                spinLock.Release();
            }
        }

        static void Task2()
        {
            for (int j = 0; j < 100000; j++)
            {
                spinLock.AcquireV2();
                num--;
                spinLock.Release();
            }
        }
    }
}
