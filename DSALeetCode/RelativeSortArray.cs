namespace DSALeetCode;

public class RelativeSortArray
{
    public static int[] Function(int[] arr1, int[] arr2)
    {
        var dic = new Dictionary<int, int>();
        var orderArray = new (int, int)[arr2.Length];
        for (var index = 0; index < arr2.Length; index++)
        {
            dic.Add(arr2[index], index);
            orderArray[index] = (arr2[index], 0);
        }

        int leftPointer = 0;
        var leftOver = new PriorityQueue<int, int>();
        while (leftPointer < arr1.Length)
        {
            if (dic.TryGetValue(arr1[leftPointer], out var resultIndex))
            {
                orderArray[resultIndex].Item2 += 1;
            }
            else
            {
                leftOver.Enqueue(arr1[leftPointer], arr1[leftPointer]);
            }

            leftPointer++;
        }

        var result = new int[arr1.Length];
        var mainIndex = 0;
        while (mainIndex < result.Length)
        {
            for (var index = 0; index < orderArray.Length; index++)
            {
                var repeat = orderArray[index].Item2;
                var value = orderArray[index].Item1;
                for (var inner = 0; inner < repeat; inner++)
                {
                    result[mainIndex] = value;
                    mainIndex++;
                }
            }
            while(leftOver.Count > 0)
            {
                result[mainIndex] = leftOver.Dequeue();
                mainIndex++;
            }
        }

        return result;
    }
}