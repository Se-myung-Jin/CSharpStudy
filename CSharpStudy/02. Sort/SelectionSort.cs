namespace CSharpStudy
{
    public partial class Sort
    {
        void SelectionSort(int[] arr)
        {
            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < len; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp; 
            }
        }
    }
}
