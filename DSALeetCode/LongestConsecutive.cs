namespace DSALeetCode;

public sealed class LongestConsecutive
{
    public static int Solution(int[] nums)
    {
        // covers special case
        if (nums.Length is 0 or 1)
        {
            return nums.Length;
        }

        var dic = new HashSet<int>(nums);
        // covers normal cases
        var result = 0;
        foreach (var num in nums)
        {
            var value = num;
            if (dic.Contains(value - 1))
            {
                continue;
            }

            var temp = 0;
            while (dic.Contains(value))
            {
                temp++;
                value++;
            }

            result = Math.Max(result, temp);
        }

        return result;
    }
}