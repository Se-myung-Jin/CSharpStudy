namespace CSharpStudy
{
    class Program
    {
        static volatile int num = 0;
        static RecursiveRWLock rwLock = new RecursiveRWLock();
        static SpinLock sLock = new SpinLock();

        static void Main(string[] args)
        {
            Task task1 = new Task(Task1);
            Task task2 = new Task(Task2);

            task1.Start();
            task2.Start();

            Task.WaitAll(task1, task2);

            Console.WriteLine($"num : {num}");

            int[] array = new int[] { 5, 3, 8, 4, 9, 1, 6, 2, 7 };

            Sort.MergeSort(array, 0, 8);

            foreach (var i in array)
            {
                Console.WriteLine(i);
            }
        }

        static void Task1()
        {
            for (int i = 0; i < 1000000; i++)
            {
                sLock.Acquire();
                num++;
                sLock.Release();
            }
        }

        static void Task2()
        {
            for (int j = 0; j < 1000000; j++)
            {
                sLock.Acquire();
                num--;
                sLock.Release();
            }
        }
    }
}
