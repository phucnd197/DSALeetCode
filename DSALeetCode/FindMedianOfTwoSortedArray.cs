namespace DSALeetCode;

public sealed class FindMedianOfTwoSortedArray
{
    public static double Solution(int[] nums1, int[] nums2)
    {
        var total = nums2.Length + nums1.Length;
        var isOdd = total % 2 != 0;
        var medianIndex = (isOdd ? (total + 1) / 2 : total / 2) - 1;
        int firstIndex = 0, secondIndex = 0, index = 0;
        while (index < total)
        {
            int? current = null;
            if (firstIndex > nums1.Length - 1)
            {
                current = nums2[secondIndex];
                ++secondIndex;
            }
            else if (secondIndex > nums2.Length - 1)
            {
                current = nums1[firstIndex];
                ++firstIndex;
            }
            else
            {
                var firstItem = nums1[firstIndex];
                var secondItem = nums2[secondIndex];
                if (firstItem <= secondItem)
                {
                    current = nums1[firstIndex];
                    ++firstIndex;
                }
                else
                {
                    current = nums2[secondIndex];
                    ++secondIndex;
                }
            }

            if (index == medianIndex)
            {
                if (isOdd)
                {
                    return current.Value;
                }

                if (firstIndex > nums1.Length - 1)
                {
                    return (double)(current.Value + nums2[secondIndex]) / (double)2;
                }

                if (secondIndex > nums2.Length - 1)
                {
                    return (double)(current.Value + nums1[firstIndex]) / (double)2;
                }

                var second = nums1[firstIndex] <= nums2[secondIndex] ? nums1[firstIndex] : nums2[secondIndex];
                return (double)(current.Value + second) / (double)2;
            }

            index++;
        }

        return -1;
    }
}