namespace CSharpStudy
{
    public partial class Sort
    {
        public static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                // Sort first and second halves
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        public static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            for (int i = 0; i < n1; i++)
                leftArray[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                rightArray[j] = arr[mid + 1 + j];

            int iIndex = 0, jIndex = 0;
            int k = left;

            while (iIndex < n1 && jIndex < n2)
            {
                if (leftArray[iIndex] <= rightArray[jIndex])
                {
                    arr[k] = leftArray[iIndex];
                    iIndex++;
                }
                else
                {
                    arr[k] = rightArray[jIndex];
                    jIndex++;
                }
                k++;
            }

            while (iIndex < n1)
            {
                arr[k] = leftArray[iIndex];
                iIndex++;
                k++;
            }

            while (jIndex < n2)
            {
                arr[k] = rightArray[jIndex];
                jIndex++;
                k++;
            }
        }

    }
}
