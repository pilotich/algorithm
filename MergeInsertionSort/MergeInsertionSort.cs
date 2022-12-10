class MergeInsertionSort
{
    private const int MIN_ARRAY_SIZE = 10;
    private const int MIDDLE_ARRAY_SIZE = 50;
    private const int MAX_ARRAY_SIZE = 100;
    private const int MAX_ELEMENT = 100;
    private static List<int> array = new List<int>();

    static void Main()
    {
        Random rand = new Random();
        int numElem = rand.Next(MIN_ARRAY_SIZE, MAX_ARRAY_SIZE);
        for (int i = 0; i < numElem; i++)
        {
            int value = rand.Next(1, MAX_ELEMENT);
            array.Add(value);
        }
        array.Sort();
        
        Console.Write("Random array: ");
        for (int i = 0; i < numElem; i++)
        {
            Console.Write(array[i] + ", ");
        }

        if (numElem <= MIDDLE_ARRAY_SIZE)
        {
            Console.WriteLine("\nMerge");
            sort(array, 0, array.Count - 1);
        }
        else
        {
            Console.WriteLine("\nInsertionSort");
            InsertionSort(array);
        }

    }

    /**
     * worst: O(n^2)
     * average: O(n^2)
     * best: O(n)
     */
    static void InsertionSort(List<int> arr)
    {
        int n = arr.Count;
        for (int i = 1; i < n; ++i) {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key) {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }

    /**
     * worst: O(nlogn)
     * average: O(nlogn)
     * best: O(nlogn)
     * storage: O(1)
     */
    static void merge(List<int> arr, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;
 
        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;
 
        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];

        i = 0;
        j = 0;

        int k = l;
        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                arr[k] = L[i];
                i++;
            }
            else {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1) {
            arr[k] = L[i];
            i++;
            k++;
        }

        while (j < n2) {
            arr[k] = R[j];
            j++;
            k++;
        }
    }
 
    /**
     * worst: O(nk + nlog(n/k))
     * average: O(n + nlog(n/k))
     * best: O(n + nlog(n/k))
     * storage: O(1)
     */
    static void sort(List<int> arr, int l, int r)
    {
        if (l < r) {
            int m = l + (r - l) / 2;

            sort(arr, l, m);
            sort(arr, m + 1, r);
            merge(arr, l, m, r);
        }
    }
}