namespace DSALeetCode;

public static class TwoSum2
{
    /// <summary>
    /// Solution idea <br/>
    /// 1 declare 2 target, target a:[0...target], b: [target...0] <br/>
    /// 2 loop and search array for 2 target, return index of 2 target <br/>
    /// 2.1 if either index = -1 => the combination of target is incorrect <br/>
    ///     -> a++, b-- <br/>
    /// 2.2 continue to loop until a > b
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int[] Solution(int[] numbers, int target)
    {
        #region cover edge cases

        if (numbers is null || numbers.Length < 2)
        {
            return Array.Empty<int>();
        }

        if (numbers.Length == 2)
        {
            return numbers[0] + numbers[1] != target
                ? Array.Empty<int>()
                : new[] { 1, 2 };
        }

        if (numbers[0] > target || numbers[numbers.Length - 1] < target)
        {
            return Array.Empty<int>();
        }

        #endregion

        // V2
        // possible improvement: randomization for left and right
        var random = new Random();
        int left = 0, right = numbers.Length - 1;
        while (left < right)
        {
            if (target == numbers[right] + numbers[left])
            {
                return new[] { left + 1, right + 1 };
            }
            else if (numbers[right] + numbers[left] > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        // V1
        // int leftTarget = 0, rightTarget = target;
        // int left = 0, right = 1;
        // while (leftTarget <= rightTarget)
        // {
        //     left = BinarySearchLeftMost(numbers, 0, leftTarget);
        //     // left = Array.IndexOf(numbers, leftTarget, 0);
        //     if (left == -1)
        //     {
        //         ++leftTarget;
        //         --rightTarget;
        //         continue;
        //     }
        //
        //     right = BinarySearch(numbers, left + 1, rightTarget, numbers.Length - 1);
        //     // right = Array.IndexOf(numbers, rightTarget, left + 1);
        //     if (right == -1 || left == right)
        //     {
        //         ++leftTarget;
        //         --rightTarget;
        //         continue;
        //     }
        //
        //     break;
        // }
        //
        // if (left != -1 && right != -1 && target == numbers[right] + numbers[left])
        // {
        //     return new[] { left + 1, right + 1 };
        // }

        return Array.Empty<int>();
    }

    public static int BinarySearchLeftMost(int[] array, int start, int target)
    {
        var index = BinarySearch(array, start, target, array.Length - 1);
        if (index == -1)
        {
            return index;
        }

        var leftMost = index;
        while (index > -1)
        {
            index = BinarySearch(array, 0, target, leftMost - 1);
            if (index > -1 && index < leftMost)
            {
                leftMost = index;
            }
        }

        return leftMost;
    }

    private static int BinarySearch(int[] array, int start, int target, int end)
    {
        int left = start, right = end;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (array[mid] == target)
            {
                return mid;
            }

            if (array[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return -1;
    }

    private static int BinarySearch<T>(IReadOnlyList<T> array, T target)
    {
        var comparer = Comparer<T>.Default;
        int left = 0, right = array.Count - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            switch (comparer.Compare(array[mid], target))
            {
                case 0:
                    return mid;
                case 1:
                    right = mid - 1;
                    break;
                default:
                    left = mid + 1;
                    break;
            }
        }

        return -1;
    }
}