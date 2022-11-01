namespace DSALeetCode;

public static class TwoSum2
{
    public static int[] TwoSum(int[] numbers, int target)
    {
        int left = 0,
            right = numbers.Length - 1;
        // mid = (left + right) / 2;
        while (right > left)
        {
            if (target == numbers[right] + numbers[left])
            {
                return new[] { left + 1, right + 1 };
            }

            if (target < numbers[right])
            {
                right = FindRight(numbers, right, target);
                if (right == -1)
                {
                    return Array.Empty<int>();
                }
            }

            if (target != numbers[right] + numbers[left])
            {
                left = FindLeft(numbers, left, target - numbers[right]);
                if (left == -1)
                {
                }
            }
        }

        return Array.Empty<int>();
    }

    private static int FindRight(int[] numbers, int right, int target)
    {
        for (var index = 0; index < numbers.Length; index++)
        {
            if (numbers[right] <= target)
            {
                return right;
            }
            else
            {
                right = (0 + right) / 2;
            }
        }

        return -1;
    }

    private static int FindLeft(int[] numbers, int left, int leftOver)
    {
        
        return -1;
    }
}