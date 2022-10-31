namespace DSALeetCode;

public sealed class BinarySearch
{
    public static int Solution(int[] nums, int target)
    {
        var bottom = 0;
        var top = nums.Length - 1;
        while (bottom <= top)
        {
            var medium = (top + bottom) / 2;
            var current = nums[medium];
            if (current > target)
            {
                top = medium - 1;
            }
            else if (current < target)
            {
                bottom = medium + 1;
            }
            else
            {
                return medium;
            }
        }

        return -1;
    }
}