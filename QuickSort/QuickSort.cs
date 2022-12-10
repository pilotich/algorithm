class QuickSort
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
            Console.WriteLine("\nQuick");
            SortQuick(array, 0, array.Count - 1);
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
     * worst: O(n^2)
     * average: O(n log(n))
     * best: O(n log(n))
     * storage O(n)
     */
    public static void SortQuick(List<int> array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];
        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }
        
            while (array[j] > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                (array[i], array[j]) = (array[j], array[i]);
                i++;
                j--;
            }
        }
    
        if (leftIndex < j)
            SortQuick(array, leftIndex, j);
        if (i < rightIndex)
            SortQuick(array, i, rightIndex);
    }
}