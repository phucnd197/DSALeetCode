namespace DSALeetCode;

public sealed class TwoSumEqualTarget
{
    public static int[] Solution(int[] nums, int target)
    {
        if (nums.Length is 0 or 1)
        {
            return Array.Empty<int>();
        }

        if (nums.Length == 2)
        {
            return (nums[0] + nums[1]) == target ? new[] { 0, 1 } : Array.Empty<int>();
        }

        var dic = new Dictionary<int, int>();
        for (var index = 0; index < nums.Length; index++)
        {
            if (!dic.ContainsKey(nums[index]))
            {
                dic.Add(nums[index], index);
            }
        }

        for (var index = 0; index < nums.Length; index++)
        {
            if (dic.TryGetValue(target - nums[index], out var second))
            {
                if (index == second)
                {
                    continue;
                }

                return new[] { index, second };
            }
        }

        return Array.Empty<int>();
    }
}