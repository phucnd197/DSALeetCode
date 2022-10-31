namespace DSALeetCode;

public sealed class LengthOfLongestNonRepeateSubstring
{
    public static int Solution(string s)
    {
        if (s.Length is 0 or 1)
        {
            return s.Length;
        }

        var dic = new HashSet<char>();
        int leftPointer = 0, rightPointer = 0, result = 0;
        while (rightPointer < s.Length)
        {
            var currentChar = s[rightPointer];
            while (dic.Contains(currentChar))
            {
                if (dic.Count > result)
                {
                    result = dic.Count;
                }

                dic.Remove(s[leftPointer]);
                leftPointer++;
            }

            dic.Add(currentChar);
            rightPointer++;
        }

        return result;
    }
}