namespace DSALeetCode;

public sealed class SingleNumber
{
    public static int Function(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        long uniqueNumber = 0;
        for (long index = 0; index < nums.Length; index++)
        {
            if ((nums[index] & uniqueNumber) == 0)
            {
                uniqueNumber |= nums[index];
            }
            else
            {
                uniqueNumber &= (uniqueNumber - nums[index]);
            }
        }

        for (var index = 0; index < nums.Length; index++)
        {
            if ((uniqueNumber & nums[index]) == nums[index])
            {
                return nums[index];
            }
        }

        return int.MinValue;
    }
}